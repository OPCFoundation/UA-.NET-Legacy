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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.Client.Diagnostic.Controls
{
  /// <summary>
  /// 
  /// </summary>
  enum SubItemIndexes
  {
    Name = 0,
    Value = 1,
    Type = 2,
    StatusCode = 3,
    SourceTimeStamp = 4,
    ServerTimeStamp = 5
  }

  /// <summary>
  /// 
  /// </summary>
  public class DiagnosticListViewItem : NodeId
  {
    private bool m_ShowValue = true;
    private bool m_ShowDetails = false;

    private MonitoredItem m_MonitoredItem;
    public MonitoredItem MonitoredItem
    {
      get { return m_MonitoredItem; }
      set { m_MonitoredItem = value; }
    }
    protected string m_Name;
    public string Name
    {
      get { return m_Name; }
    }
    private int m_IndentationLevel = 0;
    public int IndentationLevel
    {
      get { return m_IndentationLevel; }
    }
    public virtual bool HasDetails()
    {
      return m_ShowDetails;
    }

    private string m_RelativePath;
    public string RelativePath
    {
      get { return m_RelativePath; }
    }
    public DiagnosticListViewItem(NodeId startNodeId, string relativePath, int indentationLevel, bool showDetails, bool showValue): base (startNodeId)
    {
      m_RelativePath = relativePath;
      m_IndentationLevel = indentationLevel;
      m_Name = relativePath;
      m_ShowDetails =  showDetails;
      m_ShowValue = showValue;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mi"></param>
    /// <param name="lv"></param>
    protected virtual void AddToListView(MonitoredItem mi, ListView lv)
    {
      ListViewItem lvi = lv.Items.Add(mi.ClientHandle.ToString(), Name, -1);
      lvi.IndentCount = IndentationLevel;

      lvi.SubItems.Add("").Name = "Value";
      lvi.SubItems.Add("").Name = "Type";
      lvi.SubItems.Add("").Name = "StatusCode";
      lvi.SubItems.Add("").Name = "SourceTimeStamp";
      lvi.SubItems.Add("").Name = "ServerTimeStamp";
      lvi.Tag = this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="session"></param>
    /// <param name="subscription"></param>
    /// <param name="lv"></param>
    /// <returns></returns>
    public virtual MonitoredItem CreateMonitoredItem(Session session, Subscription subscription, ListView lv)
    {
      MonitoredItem mi = new MonitoredItem(subscription.DefaultItem);
      INode node = session.NodeCache.Find(this);
      mi.DisplayName = session.NodeCache.GetDisplayText(node);
      mi.StartNodeId = this;
      mi.RelativePath = this.RelativePath;
      mi.NodeClass = NodeClass.Variable;
      mi.AttributeId = Attributes.Value;
      subscription.AddItem(mi);
      AddToListView(mi, lv);
      return mi;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lvi"></param>
    /// <param name="dv"></param>
    /// <param name="session"></param>
    protected virtual void UpdateTypeInListView(ListViewItem lvi, DataValue dv, Session session)
    {
      if (dv.Value != null)
      {
        Array array = dv.Value as Array;
        if (array != null)
        {
          ExtensionObject extension1 = array.GetValue(0) as ExtensionObject;
          if (extension1 != null)
          {
            IEncodeable encodeable = extension1.Body as IEncodeable;
            if (encodeable != null)
            {
              string name = encodeable.GetType().Name;
              lvi.SubItems[(int)SubItemIndexes.Type].Text = String.Format("{0}[{1}]", name, array.Length);
            }
          }
          else
          {
            lvi.SubItems[(int)SubItemIndexes.Type].Text = String.Format("{0}[{1}]", dv.Value.GetType().GetElementType().ToString(), array.Length);
          }
        }
        else
        {
          ExpandedNodeId datatypeId = null;
          ExtensionObject extension = dv.Value as ExtensionObject;
          if (extension != null)
          {
            IEncodeable encodeable = extension.Body as IEncodeable;
            if (encodeable != null)
            {
              datatypeId = encodeable.TypeId;
            }
            else
            {
              datatypeId = DataTypes.GetDataTypeId(dv.Value);
            }
          }
          else
          {
            datatypeId = DataTypes.GetDataTypeId(dv.Value);
          }
          Node datatype = session.NodeCache.Find(datatypeId) as Node;
          if (datatype != null)
          {
            lvi.SubItems[(int)SubItemIndexes.Type].Text = datatype.ToString();
          }
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lvi"></param>
    /// <param name="dv"></param>
    /// <param name="session"></param>
    protected virtual void UpdateValueInListView(ListViewItem lvi, DataValue dv, Session session)
    {
      if (dv.Value != null)
      {
        ExtensionObject extension = dv.Value as ExtensionObject;
        Array array = dv.Value as Array;
        if (array != null)
        {
          lvi.SubItems[(int)SubItemIndexes.Value].Text = String.Format("{0}[{1}]", dv.Value.GetType().GetElementType().Name, array.Length);
          ExtensionObject extension1 = array.GetValue(0) as ExtensionObject;
          if (extension1 != null)
          {
            // This returns "Opc.Ua.ArrayType" where arraytype is the correct array type name, should use this for the type column
            lvi.SubItems[(int)SubItemIndexes.Value].Text = extension1.ToString();
            //int i = 0;
            foreach (object o in array)
            {
              ExtensionObject extension2 = o as ExtensionObject;
              if (extension1 != null)
              {
                IEncodeable encodeable1 = extension2.Body as IEncodeable;
                if (encodeable1 != null)
                {
                  string name = encodeable1.GetType().Name;
                  //Utils.Trace("encodeable1.GetType().Name: {0}, array[{1}]", name, i++);
                  PropertyInfo[] properties = encodeable1.GetType().GetProperties();
                  foreach (PropertyInfo property in properties)
                  {
                    //Utils.Trace("property.Name: {0},  property.GetValue: {1}", property.Name, property.GetValue(encodeable1, null) != null ? property.GetValue(encodeable1, null).ToString():"null");
                    //Utils.Trace("property.Name: {0},  ", property.Name);
                  }
                }
              }
            }
          }
          else
          {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            sb.Append("{");
            foreach (object o in array)
            {
              sb.Append(o.ToString());
              if (i++ < array.Length)
              {
                sb.Append(", ");
              }
            }
            sb.Append("}");
            lvi.SubItems[(int)SubItemIndexes.Value].Text = sb.ToString();
          }
        }
        else if (extension != null)
        {
          IEncodeable encodeable = extension.Body as IEncodeable;
          if (encodeable != null)
          {
            lvi.SubItems[(int)SubItemIndexes.Value].Text = extension.ToString(); ;
          }
          else
          {
            lvi.SubItems[(int)SubItemIndexes.Value].Text = extension.Body.ToString();
          }
        }
        else
        {
          lvi.SubItems[(int)SubItemIndexes.Value].Text = dv.Value.ToString();
        }
        lvi.ToolTipText = lvi.SubItems[(int)SubItemIndexes.Value].Text;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lvi"></param>
    /// <param name="dv"></param>
    /// <param name="session"></param>
    public virtual void UpdateInListView(ListViewItem lvi, DataValue dv, Session session)
    {
      if(m_ShowValue == true)
      {
        UpdateValueInListView(lvi, dv, session);
      }
      UpdateTypeInListView(lvi, dv, session);
      lvi.SubItems[(int)SubItemIndexes.StatusCode].Text = StatusCode.LookupSymbolicId(dv.StatusCode.Code);
      lvi.SubItems[(int)SubItemIndexes.ServerTimeStamp].Text = dv.ServerTimestamp.ToLocalTime().ToString();
      lvi.SubItems[(int)SubItemIndexes.SourceTimeStamp].Text = dv.SourceTimestamp.ToLocalTime().ToString();
    }
  }
}
