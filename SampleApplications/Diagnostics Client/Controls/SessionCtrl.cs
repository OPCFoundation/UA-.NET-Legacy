/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Sample.Controls;

namespace Opc.Ua.Client.Diagnostic.Controls
{
  public partial class SessionCtrl : UserControl
  {
    #region Private Fields

    private Session m_Session;
    private Subscription m_Subscription;
    private MonitoredItemNotificationEventHandler m_ItemNotification;
    public List<Form> m_Forms = new List<Form>();

    #endregion

    public SessionCtrl()
    {
      InitializeComponent();

      // You need an image list for the indent feature of the list control to work
      listView1.SmallImageList = new GuiUtils().ImageList;

			SetColumns();

      listView1.Sorting = SortOrder.None;
      listView1.View = View.Details;
      listView1.HideSelection = false;
      listView1.MultiSelect = false;
      listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      listView1.FullRowSelect = true;
      listView1.Width = 200;

      m_ItemNotification = new MonitoredItemNotificationEventHandler(ItemNotification);
    }

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		protected virtual void SetColumns()
		{		
			listView1.Clear();

      listView1.Columns.Add("Session Name", 100, HorizontalAlignment.Left);
      listView1.Columns.Add("Session ID", 100, HorizontalAlignment.Left);
      listView1.Columns.Add("Client Name", 100, HorizontalAlignment.Left);
      listView1.Columns.Add("Client Connection Time", 100, HorizontalAlignment.Left);
		}

    public void Initialize(Session session, Subscription subscription)
    {
      m_Session = session;
      m_Subscription = subscription;
      listView1.Items.Clear();

      // Now monitor the server object for AuditSession Events
      NodeId serverNodeId = new NodeId(Objects.Server);
      Node serverNode = m_Session.NodeCache.Find(serverNodeId) as Node;
      MonitoredItem serverItem = new MonitoredItem(m_Subscription.DefaultItem);
      serverItem.StartNodeId = serverNode.NodeId;
      serverItem.NodeClass = NodeClass.Object;
      m_Subscription.AddItem(serverItem);
      serverItem.Notification += m_ItemNotification;

      AddSessions();

      m_Subscription.ModifyItems();
      m_Subscription.ApplyChanges();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Items"></param>
    public void Initialize(Session session)
    {

      Subscription subscription = new Subscription(session.DefaultSubscription);
      subscription.DisplayName = session.ToString() + ".AllSessions";
      bool bResult = session.AddSubscription(subscription);
      subscription.Create();
      Initialize(session, subscription);

    }

    /// <summary>
    /// 
    /// </summary>
    private void AddSessions()
    {
      Browser browser = new Browser(m_Session);
      browser.MaxReferencesReturned = 0;
      browser.BrowseDirection   = BrowseDirection.Forward;
      browser.IncludeSubtypes   = true;
      browser.NodeClassMask     = (int)NodeClass.Object;
      browser.ContinueUntilDone = true;
      NodeId browseid = new NodeId(Objects.Server_ServerDiagnostics_SessionsDiagnosticsSummary);
      browser.ReferenceTypeId =  null;
      ReferenceDescriptionCollection refs = browser.Browse(browseid);

      foreach(ReferenceDescription rf in refs)
      {
        if(m_Session.TypeTree.IsTypeOf(new ExpandedNodeId(rf.TypeDefinition), new ExpandedNodeId(ObjectTypes.SessionDiagnosticsObjectType)))
        {
          if(listView1.Items.IndexOfKey(rf.NodeId.ToString()) == -1)
          {
            ListViewItem lvi = listView1.Items.Add(rf.NodeId.ToString(), rf.DisplayName.Text.ToString(), -1);
            lvi.Tag = rf.NodeId;
            lvi.IndentCount = 0;

            string SessionID = "SessionDiagnostics.SessionId";
            string ClientName = "SessionDiagnostics.ClientName";
            string ClientConnectionTime = "SessionDiagnostics.ClientConnectionTime";

            ListViewItem.ListViewSubItem SessionIDSubItem = lvi.SubItems.Add("");
            SessionIDSubItem.Name = rf.NodeId.Identifier.ToString() + "." + SessionID;
            ListViewItem.ListViewSubItem ClientNameSubItem = lvi.SubItems.Add("");
            ClientNameSubItem.Name = rf.NodeId.Identifier.ToString() + "." + ClientName;
            ListViewItem.ListViewSubItem ClientConnectionTimeSubItem = lvi.SubItems.Add("");
            ClientConnectionTimeSubItem.Name = rf.NodeId.Identifier.ToString() + "." + ClientConnectionTime;

            MonitoredItem sessionItem = new MonitoredItem(m_Subscription.DefaultItem);
            sessionItem.StartNodeId = (NodeId)rf.NodeId;
            sessionItem.RelativePath = SessionID;
            sessionItem.NodeClass = NodeClass.Object;
            sessionItem.AttributeId = Attributes.Value;
            m_Subscription.AddItem(sessionItem);
            sessionItem.Notification += m_ItemNotification;


            INode node = m_Session.NodeCache.Find(rf.NodeId);

            TypedMonitoredItem SessionIDItem = new TypedMonitoredItem(m_Subscription.DefaultItem);
            SessionIDItem.StartNodeId = (NodeId)rf.NodeId;
            SessionIDItem.RelativePath = SessionID;
            SessionIDItem.NodeClass = NodeClass.Variable;
            SessionIDItem.AttributeId = Attributes.Value;
            m_Subscription.AddItem(SessionIDItem);
            SessionIDItem.Notification += m_ItemNotification;
            SessionIDSubItem.Tag = SessionIDItem;
            Utils.Trace("Adding: {0}, {1} as subitem in AddSessions()", SessionIDItem.StartNodeId.ToString(), SessionIDItem.RelativePath.ToString());


            TypedMonitoredItem ClientNameItem = new TypedMonitoredItem(m_Subscription.DefaultItem);
            ClientNameItem.StartNodeId = (NodeId)rf.NodeId;
            ClientNameItem.RelativePath = ClientName;
            ClientNameItem.NodeClass = NodeClass.Variable;
            ClientNameItem.AttributeId = Attributes.Value;
            m_Subscription.AddItem(ClientNameItem);
            ClientNameItem.Notification += m_ItemNotification;
            ClientNameSubItem.Tag = ClientNameItem;
            Utils.Trace("Adding: {0}, {1} as subitem in AddSessions()", ClientNameItem.StartNodeId.ToString(), ClientNameItem.RelativePath.ToString());

            DateTimeMonitoredItem ClientConnectionTimeItem = new DateTimeMonitoredItem(m_Subscription.DefaultItem);
            ClientConnectionTimeItem.StartNodeId = (NodeId)rf.NodeId;
            ClientConnectionTimeItem.RelativePath = ClientConnectionTime;
            ClientConnectionTimeItem.NodeClass = NodeClass.Variable;
            ClientConnectionTimeItem.AttributeId = Attributes.Value;
            m_Subscription.AddItem(ClientConnectionTimeItem);
            ClientConnectionTimeItem.Notification += m_ItemNotification;
            ClientConnectionTimeSubItem.Tag = ClientConnectionTimeItem;
            Utils.Trace("Adding: {0}, {1} as subitem in AddSessions()", ClientConnectionTimeItem.StartNodeId.ToString(), ClientConnectionTimeItem.RelativePath.ToString());
          }
          else
          {
            Utils.Trace("Key already exists in listview. rf.BrowseName: {0},rf.NodeId: {1}, rf.TypeDefinition: {2}", rf.BrowseName.ToString(), rf.NodeId.ToString(), rf.TypeDefinition.ToString());
          }
        }
        else
        {
          Utils.Trace("Unknown Object rf.BrowseName: {0},rf.NodeId: {1}, rf.TypeDefinition: {2}", rf.BrowseName.ToString(), rf.NodeId.ToString(), rf.TypeDefinition.ToString());
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Close()
    {
      foreach (Form form in m_Forms)
      {
        form.Close();
      }
      m_Forms.Clear();

      foreach (ListViewItem lvi in listView1.Items)
      {
        RemoveSessionItem(lvi, false);
      }
      m_Subscription.ApplyChanges();
      m_Session.RemoveSubscription(m_Subscription);
    }

    /// <summary>
    /// Processes a Publish response from the server.
    /// </summary>
    /// 
    void ItemNotification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new MonitoredItemNotificationEventHandler(ItemNotification), monitoredItem, e);
        return;
      }
      else if (!IsHandleCreated)
      {
        return;
      }
      try
      {
        if (monitoredItem != null)
        {
          string Key = monitoredItem.StartNodeId.Identifier.ToString() + "." + monitoredItem.RelativePath;
          ListViewItem[] lvis = listView1.Items.Find(Key, true);
          Opc.Ua.MonitoredItemNotification change = e.NotificationValue as Opc.Ua.MonitoredItemNotification;
          if(change != null)
          {
            DataValue dv = change.Value;
            if (lvis.Length == 1)
            {
              ListViewItem lvi = lvis[0];
              int subindex = lvi.SubItems.IndexOfKey(Key);
              ListViewItem.ListViewSubItem si = lvi.SubItems[subindex];
              TypedMonitoredItem mi = si.Tag as TypedMonitoredItem;
              
              if (mi != null)
              {
                if (mi.ClientHandle == monitoredItem.ClientHandle)
                {
                  if (dv != null && dv.Value != null)
                  {
                    if (monitoredItem.Status.Id == StatusCodes.BadNodeIdUnknown)
                    {
                      // Randy said we would get this, but we don't
                      RemoveSessionItem(lvi, true);
                    }
                    else
                    {
                     si.Text = mi.ToString(dv);
                    }
                  }
                  else
                  {
                    // This is what we get
                    RemoveSessionItem(lvi, true);
                  }
                }
                else
                {
                  Utils.Trace("(mi.ClientHandle != monitoredItem.ClientHandle " + MethodBase.GetCurrentMethod());
                }
              }
              else
              {
                Utils.Trace("mi is null " + MethodBase.GetCurrentMethod());
              }
            }
            else
            {
              Utils.Trace("lvis.Length != 1 " + MethodBase.GetCurrentMethod());
            }
          }
          else
          {
            EventFieldList eventFields = e.NotificationValue as EventFieldList;
            if (eventFields != null)
            {

              // get the event fields.
              NodeId eventType      = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.EventType) as NodeId;
              string sourceName     = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.SourceName) as string;
              DateTime? time        = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.Time) as DateTime?;
              ushort? severity      = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.Severity) as ushort?;
              LocalizedText message = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.Message) as LocalizedText;
              NodeId sourceNode     = monitoredItem.GetFieldValue(eventFields, ObjectTypes.BaseEventType, BrowseNames.SourceNode) as NodeId;
              //Utils.Trace("eventType: {0}, message: {1}, sourceName: {2} sourceNode: {3}", eventType.ToString(), message.Text.ToString(), sourceName.ToString(), sourceNode.ToString());
              if (eventType == new NodeId(ObjectTypes.AuditActivateSessionEventType))
              {
                Utils.Trace("AuditActivateSessionEventType detected " + MethodBase.GetCurrentMethod());
                AddSessions();
                m_Subscription.ModifyItems();
                m_Subscription.ApplyChanges();
              }
            }
            else
            {
              Utils.Trace("eventFields is null " + MethodBase.GetCurrentMethod());
            }
          }
        }
        else
        {
          Utils.Trace("monitoredItem is null " + MethodBase.GetCurrentMethod());
        }
      }
      catch (Exception exception)
      {
        GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }

    /// <summary>
    /// Removes a session item from the subscription and list view
    /// </summary>
    /// <param name="lvi"></param>
    private void RemoveSessionItem(ListViewItem lvi, bool applyChanges)
    {
      for (int i = 0; i < lvi.SubItems.Count; i++)
      {
        ListViewItem.ListViewSubItem si = lvi.SubItems[i];
        MonitoredItem mi = si.Tag as MonitoredItem;
        if (mi != null)
        {
          mi.Notification -= m_ItemNotification;
          m_Subscription.RemoveItem(mi);
        }
      }
      listView1.Items.Remove(lvi);
      if (applyChanges == true)
      {
        m_Subscription.ApplyChanges();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void diagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (listView1.SelectedItems.Count > 0)
        {
          ListViewItem lvi = listView1.SelectedItems[0];
          string nodeId = lvi.Tag.ToString();
          SessionDiagnosticsDlg dlg = new SessionDiagnosticsDlg(m_Session, new NodeId(nodeId));
          dlg.Text = m_Session.Endpoint.EndpointUrl.ToString() + " - " + lvi.Text + " - SessionDiagnostics";
          m_Forms.Add(dlg);
          dlg.Show();
        }
      }
      catch (Exception exception)
      {
        GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void securityDiagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (listView1.SelectedItems.Count > 0)
        {
          ListViewItem lvi = listView1.SelectedItems[0];
          Browser browser = new Browser(m_Session);
          browser.MaxReferencesReturned = 0;
          browser.BrowseDirection = BrowseDirection.Forward;
          browser.IncludeSubtypes = true;
          browser.NodeClassMask = (int)NodeClass.Variable;
          browser.ContinueUntilDone = true;
          browser.ReferenceTypeId = null;
          NodeId sessionNodeId = new NodeId(lvi.Tag.ToString());
          ReferenceDescriptionCollection refs = browser.Browse(sessionNodeId);

          foreach (ReferenceDescription rf in refs)
          {
            if (m_Session.TypeTree.IsTypeOf(new ExpandedNodeId(rf.TypeDefinition), new ExpandedNodeId(VariableTypes.SessionSecurityDiagnosticsType)))
            {
              MonitoredItem mi = new MonitoredItem(m_Subscription.DefaultItem);
              NodeId id = new NodeId(rf.NodeId.ToString());
              INode node = m_Session.NodeCache.Find(id);
              mi.StartNodeId = id;
              mi.NodeClass = node.NodeClass;
              mi.AttributeId = Attributes.Value;
              mi.DisplayName = m_Session.NodeCache.GetDisplayText(node);
              mi.MonitoringMode = MonitoringMode.Reporting;
              m_Subscription.PublishingEnabled = true;
              m_Subscription.AddItem(mi);
              m_Subscription.ModifyItems();
              m_Subscription.ApplyChanges();
              MonitoredItemDlg dlg = new MonitoredItemDlg();
              m_Forms.Add(dlg);
              dlg.Show(mi);
              break;
            }
          }
        }
      }
      catch (Exception exception)
      {
        GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void subscriptionDiagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (listView1.SelectedItems.Count > 0)
        {
          ListViewItem lvi = listView1.SelectedItems[0];
          Browser browser = new Browser(m_Session);
          browser.MaxReferencesReturned = 0;
          browser.BrowseDirection = BrowseDirection.Forward;
          browser.IncludeSubtypes = true;
          browser.NodeClassMask = (int)NodeClass.Variable;
          browser.ContinueUntilDone = true;
          browser.ReferenceTypeId = null;
          NodeId sessionNodeId = new NodeId(lvi.Tag.ToString());
          ReferenceDescriptionCollection refs = browser.Browse(sessionNodeId);

          foreach (ReferenceDescription rf in refs)
          {
            if (m_Session.TypeTree.IsTypeOf(new ExpandedNodeId(rf.TypeDefinition), new ExpandedNodeId(VariableTypes.SubscriptionDiagnosticsArrayType)))
            {
              MonitoredItem mi = new MonitoredItem(m_Subscription.DefaultItem);
              NodeId id = new NodeId(rf.NodeId.ToString());
              INode node = m_Session.NodeCache.Find(id);
              mi.StartNodeId = id;
              mi.NodeClass = node.NodeClass;
              mi.AttributeId = Attributes.Value;
              mi.DisplayName = m_Session.NodeCache.GetDisplayText(node);
              mi.MonitoringMode = MonitoringMode.Reporting;
              m_Subscription.PublishingEnabled = true;
              m_Subscription.AddItem(mi);
              m_Subscription.ModifyItems();
              m_Subscription.ApplyChanges();
              MonitoredItemDlg dlg = new MonitoredItemDlg();
              m_Forms.Add(dlg);
              dlg.Show(mi);
              
              break;

            }
          }
        }
      }
      catch (Exception exception)
      {
        GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }
  }
  public class TypedMonitoredItem : MonitoredItem
  {
    public TypedMonitoredItem(MonitoredItem template)
      : base(template)
    {
    }
    public virtual string ToString(DataValue dv)
    {
      return dv.Value.ToString();
    }
  }
  public class DateTimeMonitoredItem : TypedMonitoredItem
  {
    public DateTimeMonitoredItem(MonitoredItem template)
      : base(template)
    {
    }
    public override string ToString(DataValue dv)
    {
      DateTime dt = DateTime.Parse(dv.ToString());
      return dt.ToLocalTime().ToString();
    }
  }

}
