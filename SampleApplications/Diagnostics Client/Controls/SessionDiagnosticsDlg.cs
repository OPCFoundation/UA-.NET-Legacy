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

namespace Opc.Ua.Client.Diagnostic.Controls
{
  public partial class SessionDiagnosticsDlg : Form
  {
    public SessionDiagnosticsDlg(Session session, NodeId sessionNodeId)
    {
      InitializeComponent();

      List<DiagnosticListViewItem> list = CreateItems(session, sessionNodeId);
      serverDiagnosticCtrl1.LoadItems(session, list);
    }
    public SessionDiagnosticsDlg(Session session, NodeId sessionNodeId, Subscription subscription)
    {
      InitializeComponent();
      List<DiagnosticListViewItem> list = CreateItems(session, sessionNodeId);
      serverDiagnosticCtrl1.LoadItems(session, list, subscription);
    }
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      serverDiagnosticCtrl1.Close();
    }
    private List<DiagnosticListViewItem> CreateItems(Session session, NodeId sessionNodeId)
    {
      List<DiagnosticListViewItem> items = new List<DiagnosticListViewItem>();

      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics", 0, true, false));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.SessionId", 1, false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ClientName", 1, false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.LocaleIds", 1, true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ActualSessionTimeout", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ClientConnectionTime", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ClientLastContactTime", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CurrentSubscriptionsCount", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CurrentMonitoredItemsCount", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CurrentPublishRequestsInQueue", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CurrentPublishTimerExpirations", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.KeepAliveCount", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CurrentRepublishRequestsInQueue", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.MaxRepublishRequestsInQueue", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.RepublishCounter", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.PublishingCount", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.PublishingQueueOverflowCount", 1 ,false, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ReadCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.HistoryReadCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.WriteCount", 1, true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.HistoryUpdateCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CallCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CreateMonitoredItemsCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ModifyMonitoredItemsCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.SetMonitoringModeCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.SetTriggeringCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.DeleteMonitoredItemsCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.CreateSubscriptionCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.ModifySubscriptionCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.SetPublishingModeCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.PublishCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.RepublishCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.TransferSubscriptionCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.DeleteSubscriptionsCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.AddNodesCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.AddReferencesCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.DeleteNodesCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.DeleteReferencesCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.BrowseCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.BrowseNextCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.TranslateBrowsePathsToNodeIdsCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.QueryFirstCount", 1 ,true, true));
      items.Add(new DiagnosticListViewItem(sessionNodeId, "SessionDiagnostics.QueryNextCount", 1 ,true, true));
      return items;                                
    }

  }
}
