/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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

namespace Opc.Ua.Configuration
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearRecentFileListsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_ExitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_AboutMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPN = new System.Windows.Forms.Panel();
            this.TabsPN = new System.Windows.Forms.TabControl();
            this.ManageSecurityTAB = new System.Windows.Forms.TabPage();
            this.ImportCertificateListToTrustLB = new System.Windows.Forms.Label();
            this.ExportApplicationCertificateLB = new System.Windows.Forms.Label();
            this.ExportApplicationCertificateBTN = new System.Windows.Forms.Button();
            this.TrustAnotherApplicationLB = new System.Windows.Forms.Label();
            this.TrustAnotherApplicationBTN = new System.Windows.Forms.Button();
            this.ManageApplicationSecurityCTRL = new Opc.Ua.Configuration.ManagedApplicationCtrl();
            this.DeleteAllTrustedCertificatesLB = new System.Windows.Forms.Label();
            this.DeleteAllTrustedCertificatesBTN = new System.Windows.Forms.Button();
            this.RegisterWithDiscoveryServerLB = new System.Windows.Forms.Label();
            this.RegisterWithDiscoveryServerBTN = new System.Windows.Forms.Button();
            this.ImportCertificateListToTrustBTN = new System.Windows.Forms.Button();
            this.ImportCertificateToTrustLB = new System.Windows.Forms.Label();
            this.ImportCertificateToTrustBTN = new System.Windows.Forms.Button();
            this.SelectCertificateToTrustLB = new System.Windows.Forms.Label();
            this.SelectCertificateToTrustBTN = new System.Windows.Forms.Button();
            this.ViewTrustedCertificatesLB = new System.Windows.Forms.Label();
            this.ViewTrustedCertificatesBTN = new System.Windows.Forms.Button();
            this.ManageApplicationLB = new System.Windows.Forms.Label();
            this.ApplicationTAB = new System.Windows.Forms.TabPage();
            this.ManageFirewallAccessLB = new System.Windows.Forms.Label();
            this.ManageFirewallAccessBTN = new System.Windows.Forms.Button();
            this.ManageApplicationPermissionsLB = new System.Windows.Forms.Label();
            this.AssignTrustListLB = new System.Windows.Forms.Label();
            this.AssignApplicationCertificateLB = new System.Windows.Forms.Label();
            this.CreateApplicationCertificateLB = new System.Windows.Forms.Label();
            this.ImportApplicationCertificateLB = new System.Windows.Forms.Label();
            this.ViewApplicationCertificateLB = new System.Windows.Forms.Label();
            this.AssignApplicationCertificateBTN = new System.Windows.Forms.Button();
            this.ManageApplicationPermissionsBTN = new System.Windows.Forms.Button();
            this.AssignTrustListBTN = new System.Windows.Forms.Button();
            this.CreateApplicationCertificateBTN = new System.Windows.Forms.Button();
            this.ImportApplicationCertificateBTN = new System.Windows.Forms.Button();
            this.ViewApplicationCertificateBTN = new System.Windows.Forms.Button();
            this.ApplicationToManageLB = new System.Windows.Forms.Label();
            this.ApplicationToManageCTRL = new Opc.Ua.Configuration.ManagedApplicationCtrl();
            this.CertificatesTAB = new System.Windows.Forms.TabPage();
            this.BindSslCertificateLB = new System.Windows.Forms.Label();
            this.BindSslCertificateBTN = new System.Windows.Forms.Button();
            this.IssueSslCertificateLB = new System.Windows.Forms.Label();
            this.IssueSslCertificateBTN = new System.Windows.Forms.Button();
            this.ImportCertificateListToStoreLB = new System.Windows.Forms.Label();
            this.ImportCertificateListToStoreBTN = new System.Windows.Forms.Button();
            this.ImportCertificateToStoreLB = new System.Windows.Forms.Label();
            this.ImportCertificateToStoreBTN = new System.Windows.Forms.Button();
            this.ExportPrivateKeyLB = new System.Windows.Forms.Label();
            this.ExportPrivateKeyBTN = new System.Windows.Forms.Button();
            this.ImportAndIssueCertificateLB = new System.Windows.Forms.Label();
            this.ImportAndIssueCertificateBTN = new System.Windows.Forms.Button();
            this.IssuerBrowseBTN = new System.Windows.Forms.Button();
            this.IssuerKeyFilePathTB = new System.Windows.Forms.TextBox();
            this.IssuerKeyFilePathLB = new System.Windows.Forms.Label();
            this.SelectAndIssueCertificateLB = new System.Windows.Forms.Label();
            this.SelectAndIssueCertificateBTN = new System.Windows.Forms.Button();
            this.ViewCertificatesLB = new System.Windows.Forms.Label();
            this.CreateCertificateAuthorityLB = new System.Windows.Forms.Label();
            this.ViewCertificatesBTN = new System.Windows.Forms.Button();
            this.CreateCertificateAuthorityBTN = new System.Windows.Forms.Button();
            this.ManagedStoreCTRL = new Opc.Ua.Client.Controls.CertificateStoreCtrl();
            this.ComServersTAB = new System.Windows.Forms.TabPage();
            this.ComServersCTRL = new Opc.Ua.Client.Controls.PseudoComServerListCtrl();
            this.ComTopPN = new System.Windows.Forms.Panel();
            this.NewComServerBTN = new System.Windows.Forms.Button();
            this.WrapComServerBTN = new System.Windows.Forms.Button();
            this.WrapComServerLB = new System.Windows.Forms.Label();
            this.NewComServerLB = new System.Windows.Forms.Label();
            this.HttpAccessRulesTAB = new System.Windows.Forms.TabPage();
            this.HttpAccessRuleCTRL = new Opc.Ua.Configuration.HttpAccessRulelListCtrl();
            this.MenuBar.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.TabsPN.SuspendLayout();
            this.ManageSecurityTAB.SuspendLayout();
            this.ApplicationTAB.SuspendLayout();
            this.CertificatesTAB.SuspendLayout();
            this.ComServersTAB.SuspendLayout();
            this.ComTopPN.SuspendLayout();
            this.HttpAccessRulesTAB.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 500);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1070, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMI,
            this.HelpMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1070, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "menuStrip1";
            // 
            // FileMI
            // 
            this.FileMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearRecentFileListsMI,
            this.File_ExitMI});
            this.FileMI.Name = "FileMI";
            this.FileMI.Size = new System.Drawing.Size(39, 20);
            this.FileMI.Text = "File";
            // 
            // ClearRecentFileListsMI
            // 
            this.ClearRecentFileListsMI.Name = "ClearRecentFileListsMI";
            this.ClearRecentFileListsMI.Size = new System.Drawing.Size(203, 22);
            this.ClearRecentFileListsMI.Text = "Clear Recent File Lists";
            this.ClearRecentFileListsMI.Click += new System.EventHandler(this.ClearRecentFileListsMI_Click);
            // 
            // File_ExitMI
            // 
            this.File_ExitMI.Name = "File_ExitMI";
            this.File_ExitMI.Size = new System.Drawing.Size(203, 22);
            this.File_ExitMI.Text = "Exit";
            this.File_ExitMI.Click += new System.EventHandler(this.File_ExitMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.Help_AboutMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new System.Drawing.Size(45, 20);
            this.HelpMI.Text = "Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // Help_AboutMI
            // 
            this.Help_AboutMI.Name = "Help_AboutMI";
            this.Help_AboutMI.Size = new System.Drawing.Size(126, 22);
            this.Help_AboutMI.Text = "About";
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.TabsPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 24);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.MainPN.Size = new System.Drawing.Size(1070, 476);
            this.MainPN.TabIndex = 3;
            // 
            // TabsPN
            // 
            this.TabsPN.Controls.Add(this.ManageSecurityTAB);
            this.TabsPN.Controls.Add(this.ApplicationTAB);
            this.TabsPN.Controls.Add(this.CertificatesTAB);
            this.TabsPN.Controls.Add(this.ComServersTAB);
            this.TabsPN.Controls.Add(this.HttpAccessRulesTAB);
            this.TabsPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabsPN.Location = new System.Drawing.Point(0, 2);
            this.TabsPN.Name = "TabsPN";
            this.TabsPN.SelectedIndex = 0;
            this.TabsPN.Size = new System.Drawing.Size(1070, 474);
            this.TabsPN.TabIndex = 0;
            this.TabsPN.SelectedIndexChanged += new System.EventHandler(this.TabsPN_SelectedIndexChanged);
            // 
            // ManageSecurityTAB
            // 
            this.ManageSecurityTAB.Controls.Add(this.ImportCertificateListToTrustLB);
            this.ManageSecurityTAB.Controls.Add(this.ExportApplicationCertificateLB);
            this.ManageSecurityTAB.Controls.Add(this.ExportApplicationCertificateBTN);
            this.ManageSecurityTAB.Controls.Add(this.TrustAnotherApplicationLB);
            this.ManageSecurityTAB.Controls.Add(this.TrustAnotherApplicationBTN);
            this.ManageSecurityTAB.Controls.Add(this.ManageApplicationSecurityCTRL);
            this.ManageSecurityTAB.Controls.Add(this.DeleteAllTrustedCertificatesLB);
            this.ManageSecurityTAB.Controls.Add(this.DeleteAllTrustedCertificatesBTN);
            this.ManageSecurityTAB.Controls.Add(this.RegisterWithDiscoveryServerLB);
            this.ManageSecurityTAB.Controls.Add(this.RegisterWithDiscoveryServerBTN);
            this.ManageSecurityTAB.Controls.Add(this.ImportCertificateListToTrustBTN);
            this.ManageSecurityTAB.Controls.Add(this.ImportCertificateToTrustLB);
            this.ManageSecurityTAB.Controls.Add(this.ImportCertificateToTrustBTN);
            this.ManageSecurityTAB.Controls.Add(this.SelectCertificateToTrustLB);
            this.ManageSecurityTAB.Controls.Add(this.SelectCertificateToTrustBTN);
            this.ManageSecurityTAB.Controls.Add(this.ViewTrustedCertificatesLB);
            this.ManageSecurityTAB.Controls.Add(this.ViewTrustedCertificatesBTN);
            this.ManageSecurityTAB.Controls.Add(this.ManageApplicationLB);
            this.ManageSecurityTAB.Location = new System.Drawing.Point(4, 22);
            this.ManageSecurityTAB.Name = "ManageSecurityTAB";
            this.ManageSecurityTAB.Size = new System.Drawing.Size(1062, 448);
            this.ManageSecurityTAB.TabIndex = 6;
            this.ManageSecurityTAB.Text = "Manage Security";
            this.ManageSecurityTAB.UseVisualStyleBackColor = true;
            // 
            // ImportCertificateListToTrustLB
            // 
            this.ImportCertificateListToTrustLB.AutoSize = true;
            this.ImportCertificateListToTrustLB.Location = new System.Drawing.Point(215, 174);
            this.ImportCertificateListToTrustLB.Name = "ImportCertificateListToTrustLB";
            this.ImportCertificateListToTrustLB.Size = new System.Drawing.Size(401, 12);
            this.ImportCertificateListToTrustLB.TabIndex = 59;
            this.ImportCertificateListToTrustLB.Text = "Updates the application trust list by adding the contents of another trust list.";
            // 
            // ExportApplicationCertificateLB
            // 
            this.ExportApplicationCertificateLB.AutoSize = true;
            this.ExportApplicationCertificateLB.Location = new System.Drawing.Point(215, 257);
            this.ExportApplicationCertificateLB.Name = "ExportApplicationCertificateLB";
            this.ExportApplicationCertificateLB.Size = new System.Drawing.Size(225, 12);
            this.ExportApplicationCertificateLB.TabIndex = 58;
            this.ExportApplicationCertificateLB.Text = "Exports the application certificate to a file.";
            // 
            // ExportApplicationCertificateBTN
            // 
            this.ExportApplicationCertificateBTN.Location = new System.Drawing.Point(18, 252);
            this.ExportApplicationCertificateBTN.Name = "ExportApplicationCertificateBTN";
            this.ExportApplicationCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.ExportApplicationCertificateBTN.TabIndex = 57;
            this.ExportApplicationCertificateBTN.Text = "Export Application Certificate...";
            this.ExportApplicationCertificateBTN.UseVisualStyleBackColor = true;
            this.ExportApplicationCertificateBTN.Click += new System.EventHandler(this.ExportApplicationCertificateBTN_Click);
            // 
            // TrustAnotherApplicationLB
            // 
            this.TrustAnotherApplicationLB.AutoSize = true;
            this.TrustAnotherApplicationLB.Location = new System.Drawing.Point(215, 67);
            this.TrustAnotherApplicationLB.Name = "TrustAnotherApplicationLB";
            this.TrustAnotherApplicationLB.Size = new System.Drawing.Size(271, 12);
            this.TrustAnotherApplicationLB.TabIndex = 56;
            this.TrustAnotherApplicationLB.Text = "Sets up a trust relationship with another application";
            // 
            // TrustAnotherApplicationBTN
            // 
            this.TrustAnotherApplicationBTN.Location = new System.Drawing.Point(18, 63);
            this.TrustAnotherApplicationBTN.Name = "TrustAnotherApplicationBTN";
            this.TrustAnotherApplicationBTN.Size = new System.Drawing.Size(191, 21);
            this.TrustAnotherApplicationBTN.TabIndex = 55;
            this.TrustAnotherApplicationBTN.Text = "Trust Another Application...";
            this.TrustAnotherApplicationBTN.UseVisualStyleBackColor = true;
            this.TrustAnotherApplicationBTN.Click += new System.EventHandler(this.TrustAnotherApplicationBTN_Click);
            // 
            // ManageApplicationSecurityCTRL
            // 
            this.ManageApplicationSecurityCTRL.Location = new System.Drawing.Point(141, 21);
            this.ManageApplicationSecurityCTRL.MaximumSize = new System.Drawing.Size(4096, 22);
            this.ManageApplicationSecurityCTRL.MinimumSize = new System.Drawing.Size(300, 22);
            this.ManageApplicationSecurityCTRL.Name = "ManageApplicationSecurityCTRL";
            this.ManageApplicationSecurityCTRL.Size = new System.Drawing.Size(693, 22);
            this.ManageApplicationSecurityCTRL.TabIndex = 54;
            this.ManageApplicationSecurityCTRL.ApplicationChanged += new System.EventHandler(this.ApplicationToManageCTRL_ApplicationChanged);
            // 
            // DeleteAllTrustedCertificatesLB
            // 
            this.DeleteAllTrustedCertificatesLB.AutoSize = true;
            this.DeleteAllTrustedCertificatesLB.Location = new System.Drawing.Point(215, 201);
            this.DeleteAllTrustedCertificatesLB.Name = "DeleteAllTrustedCertificatesLB";
            this.DeleteAllTrustedCertificatesLB.Size = new System.Drawing.Size(264, 12);
            this.DeleteAllTrustedCertificatesLB.TabIndex = 53;
            this.DeleteAllTrustedCertificatesLB.Text = "Deletes all certificates in the application trust list.";
            // 
            // DeleteAllTrustedCertificatesBTN
            // 
            this.DeleteAllTrustedCertificatesBTN.Location = new System.Drawing.Point(18, 198);
            this.DeleteAllTrustedCertificatesBTN.Name = "DeleteAllTrustedCertificatesBTN";
            this.DeleteAllTrustedCertificatesBTN.Size = new System.Drawing.Size(191, 21);
            this.DeleteAllTrustedCertificatesBTN.TabIndex = 52;
            this.DeleteAllTrustedCertificatesBTN.Text = "Delete All Trusted Certificates...";
            this.DeleteAllTrustedCertificatesBTN.UseVisualStyleBackColor = true;
            this.DeleteAllTrustedCertificatesBTN.Click += new System.EventHandler(this.DeleteAllTrustedCertificatesBTN_Click);
            // 
            // RegisterWithDiscoveryServerLB
            // 
            this.RegisterWithDiscoveryServerLB.AutoSize = true;
            this.RegisterWithDiscoveryServerLB.Location = new System.Drawing.Point(215, 230);
            this.RegisterWithDiscoveryServerLB.Name = "RegisterWithDiscoveryServerLB";
            this.RegisterWithDiscoveryServerLB.Size = new System.Drawing.Size(350, 12);
            this.RegisterWithDiscoveryServerLB.TabIndex = 51;
            this.RegisterWithDiscoveryServerLB.Text = "Adds the application to the Local Discovery Server (LDS) trust list.";
            // 
            // RegisterWithDiscoveryServerBTN
            // 
            this.RegisterWithDiscoveryServerBTN.Location = new System.Drawing.Point(18, 225);
            this.RegisterWithDiscoveryServerBTN.Name = "RegisterWithDiscoveryServerBTN";
            this.RegisterWithDiscoveryServerBTN.Size = new System.Drawing.Size(191, 21);
            this.RegisterWithDiscoveryServerBTN.TabIndex = 50;
            this.RegisterWithDiscoveryServerBTN.Text = "Register with Discovery Server";
            this.RegisterWithDiscoveryServerBTN.UseVisualStyleBackColor = true;
            this.RegisterWithDiscoveryServerBTN.Click += new System.EventHandler(this.RegisterWithDiscoveryServerBTN_Click);
            // 
            // ImportCertificateListToTrustBTN
            // 
            this.ImportCertificateListToTrustBTN.Location = new System.Drawing.Point(18, 170);
            this.ImportCertificateListToTrustBTN.Name = "ImportCertificateListToTrustBTN";
            this.ImportCertificateListToTrustBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportCertificateListToTrustBTN.TabIndex = 46;
            this.ImportCertificateListToTrustBTN.Text = "Import List of Certificates to Trust...";
            this.ImportCertificateListToTrustBTN.UseVisualStyleBackColor = true;
            this.ImportCertificateListToTrustBTN.Click += new System.EventHandler(this.ImportCertificateListToTrustBTN_Click);
            // 
            // ImportCertificateToTrustLB
            // 
            this.ImportCertificateToTrustLB.AutoSize = true;
            this.ImportCertificateToTrustLB.Location = new System.Drawing.Point(215, 148);
            this.ImportCertificateToTrustLB.Name = "ImportCertificateToTrustLB";
            this.ImportCertificateToTrustLB.Size = new System.Drawing.Size(272, 12);
            this.ImportCertificateToTrustLB.TabIndex = 45;
            this.ImportCertificateToTrustLB.Text = "Imports a certificate file to the application trust list.";
            // 
            // ImportCertificateToTrustBTN
            // 
            this.ImportCertificateToTrustBTN.Location = new System.Drawing.Point(18, 143);
            this.ImportCertificateToTrustBTN.Name = "ImportCertificateToTrustBTN";
            this.ImportCertificateToTrustBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportCertificateToTrustBTN.TabIndex = 44;
            this.ImportCertificateToTrustBTN.Text = "Import Certificate to Trust...";
            this.ImportCertificateToTrustBTN.UseVisualStyleBackColor = true;
            this.ImportCertificateToTrustBTN.Click += new System.EventHandler(this.ImportCertificateToTrustBTN_Click);
            // 
            // SelectCertificateToTrustLB
            // 
            this.SelectCertificateToTrustLB.AutoSize = true;
            this.SelectCertificateToTrustLB.Location = new System.Drawing.Point(215, 121);
            this.SelectCertificateToTrustLB.Name = "SelectCertificateToTrustLB";
            this.SelectCertificateToTrustLB.Size = new System.Drawing.Size(381, 12);
            this.SelectCertificateToTrustLB.TabIndex = 43;
            this.SelectCertificateToTrustLB.Text = "Copies a certificate from in existing trust list to the application trust list.";
            // 
            // SelectCertificateToTrustBTN
            // 
            this.SelectCertificateToTrustBTN.Location = new System.Drawing.Point(18, 116);
            this.SelectCertificateToTrustBTN.Name = "SelectCertificateToTrustBTN";
            this.SelectCertificateToTrustBTN.Size = new System.Drawing.Size(191, 21);
            this.SelectCertificateToTrustBTN.TabIndex = 42;
            this.SelectCertificateToTrustBTN.Text = "Select Certificate to Trust...";
            this.SelectCertificateToTrustBTN.UseVisualStyleBackColor = true;
            this.SelectCertificateToTrustBTN.Click += new System.EventHandler(this.SelectCertificateToTrustBTN_Click);
            // 
            // ViewTrustedCertificatesLB
            // 
            this.ViewTrustedCertificatesLB.AutoSize = true;
            this.ViewTrustedCertificatesLB.Location = new System.Drawing.Point(215, 94);
            this.ViewTrustedCertificatesLB.Name = "ViewTrustedCertificatesLB";
            this.ViewTrustedCertificatesLB.Size = new System.Drawing.Size(403, 12);
            this.ViewTrustedCertificatesLB.TabIndex = 39;
            this.ViewTrustedCertificatesLB.Text = "Displays the certificate trust list that is currently assigned to the application" +
    ".";
            // 
            // ViewTrustedCertificatesBTN
            // 
            this.ViewTrustedCertificatesBTN.Location = new System.Drawing.Point(18, 90);
            this.ViewTrustedCertificatesBTN.Name = "ViewTrustedCertificatesBTN";
            this.ViewTrustedCertificatesBTN.Size = new System.Drawing.Size(191, 21);
            this.ViewTrustedCertificatesBTN.TabIndex = 38;
            this.ViewTrustedCertificatesBTN.Text = "View Trusted Certificates...";
            this.ViewTrustedCertificatesBTN.UseVisualStyleBackColor = true;
            this.ViewTrustedCertificatesBTN.Click += new System.EventHandler(this.ViewTrustedCertificatesBTN_Click);
            // 
            // ManageApplicationLB
            // 
            this.ManageApplicationLB.AutoSize = true;
            this.ManageApplicationLB.Location = new System.Drawing.Point(18, 26);
            this.ManageApplicationLB.Name = "ManageApplicationLB";
            this.ManageApplicationLB.Size = new System.Drawing.Size(122, 12);
            this.ManageApplicationLB.TabIndex = 29;
            this.ManageApplicationLB.Text = "Application To Manage";
            // 
            // ApplicationTAB
            // 
            this.ApplicationTAB.Controls.Add(this.ManageFirewallAccessLB);
            this.ApplicationTAB.Controls.Add(this.ManageFirewallAccessBTN);
            this.ApplicationTAB.Controls.Add(this.ManageApplicationPermissionsLB);
            this.ApplicationTAB.Controls.Add(this.AssignTrustListLB);
            this.ApplicationTAB.Controls.Add(this.AssignApplicationCertificateLB);
            this.ApplicationTAB.Controls.Add(this.CreateApplicationCertificateLB);
            this.ApplicationTAB.Controls.Add(this.ImportApplicationCertificateLB);
            this.ApplicationTAB.Controls.Add(this.ViewApplicationCertificateLB);
            this.ApplicationTAB.Controls.Add(this.AssignApplicationCertificateBTN);
            this.ApplicationTAB.Controls.Add(this.ManageApplicationPermissionsBTN);
            this.ApplicationTAB.Controls.Add(this.AssignTrustListBTN);
            this.ApplicationTAB.Controls.Add(this.CreateApplicationCertificateBTN);
            this.ApplicationTAB.Controls.Add(this.ImportApplicationCertificateBTN);
            this.ApplicationTAB.Controls.Add(this.ViewApplicationCertificateBTN);
            this.ApplicationTAB.Controls.Add(this.ApplicationToManageLB);
            this.ApplicationTAB.Controls.Add(this.ApplicationToManageCTRL);
            this.ApplicationTAB.Location = new System.Drawing.Point(4, 22);
            this.ApplicationTAB.Name = "ApplicationTAB";
            this.ApplicationTAB.Size = new System.Drawing.Size(1062, 452);
            this.ApplicationTAB.TabIndex = 5;
            this.ApplicationTAB.Text = "Manage Application";
            this.ApplicationTAB.UseVisualStyleBackColor = true;
            // 
            // ManageFirewallAccessLB
            // 
            this.ManageFirewallAccessLB.AutoSize = true;
            this.ManageFirewallAccessLB.Location = new System.Drawing.Point(215, 225);
            this.ManageFirewallAccessLB.Name = "ManageFirewallAccessLB";
            this.ManageFirewallAccessLB.Size = new System.Drawing.Size(288, 12);
            this.ManageFirewallAccessLB.TabIndex = 30;
            this.ManageFirewallAccessLB.Text = "Manages the firewall access granted to the application.";
            // 
            // ManageFirewallAccessBTN
            // 
            this.ManageFirewallAccessBTN.Location = new System.Drawing.Point(18, 221);
            this.ManageFirewallAccessBTN.Name = "ManageFirewallAccessBTN";
            this.ManageFirewallAccessBTN.Size = new System.Drawing.Size(191, 21);
            this.ManageFirewallAccessBTN.TabIndex = 29;
            this.ManageFirewallAccessBTN.Text = "Manage Firewall Access...";
            this.ManageFirewallAccessBTN.UseVisualStyleBackColor = true;
            this.ManageFirewallAccessBTN.Click += new System.EventHandler(this.ManageFirewallAccessBTN_Click);
            // 
            // ManageApplicationPermissionsLB
            // 
            this.ManageApplicationPermissionsLB.AutoSize = true;
            this.ManageApplicationPermissionsLB.Location = new System.Drawing.Point(215, 198);
            this.ManageApplicationPermissionsLB.Name = "ManageApplicationPermissionsLB";
            this.ManageApplicationPermissionsLB.Size = new System.Drawing.Size(277, 12);
            this.ManageApplicationPermissionsLB.TabIndex = 22;
            this.ManageApplicationPermissionsLB.Text = "Manages accounts granted access to the application.";
            // 
            // AssignTrustListLB
            // 
            this.AssignTrustListLB.AutoSize = true;
            this.AssignTrustListLB.Location = new System.Drawing.Point(215, 174);
            this.AssignTrustListLB.Name = "AssignTrustListLB";
            this.AssignTrustListLB.Size = new System.Drawing.Size(199, 12);
            this.AssignTrustListLB.TabIndex = 14;
            this.AssignTrustListLB.Text = "Assigns a trust list to the application.";
            // 
            // AssignApplicationCertificateLB
            // 
            this.AssignApplicationCertificateLB.AutoSize = true;
            this.AssignApplicationCertificateLB.Location = new System.Drawing.Point(215, 148);
            this.AssignApplicationCertificateLB.Name = "AssignApplicationCertificateLB";
            this.AssignApplicationCertificateLB.Size = new System.Drawing.Size(257, 12);
            this.AssignApplicationCertificateLB.TabIndex = 10;
            this.AssignApplicationCertificateLB.Text = "Assigns an existing certificate to the application.";
            // 
            // CreateApplicationCertificateLB
            // 
            this.CreateApplicationCertificateLB.AutoSize = true;
            this.CreateApplicationCertificateLB.Location = new System.Drawing.Point(215, 121);
            this.CreateApplicationCertificateLB.Name = "CreateApplicationCertificateLB";
            this.CreateApplicationCertificateLB.Size = new System.Drawing.Size(306, 12);
            this.CreateApplicationCertificateLB.TabIndex = 8;
            this.CreateApplicationCertificateLB.Text = "Creates a new certificate and assigns it to the application.";
            // 
            // ImportApplicationCertificateLB
            // 
            this.ImportApplicationCertificateLB.AutoSize = true;
            this.ImportApplicationCertificateLB.Location = new System.Drawing.Point(215, 94);
            this.ImportApplicationCertificateLB.Name = "ImportApplicationCertificateLB";
            this.ImportApplicationCertificateLB.Size = new System.Drawing.Size(363, 12);
            this.ImportApplicationCertificateLB.TabIndex = 6;
            this.ImportApplicationCertificateLB.Text = "Imports a certificate file into a store and assigns it to the application.";
            // 
            // ViewApplicationCertificateLB
            // 
            this.ViewApplicationCertificateLB.AutoSize = true;
            this.ViewApplicationCertificateLB.Location = new System.Drawing.Point(215, 67);
            this.ViewApplicationCertificateLB.Name = "ViewApplicationCertificateLB";
            this.ViewApplicationCertificateLB.Size = new System.Drawing.Size(353, 12);
            this.ViewApplicationCertificateLB.TabIndex = 4;
            this.ViewApplicationCertificateLB.Text = "Displays the certificate that is currently assigned to the application";
            // 
            // AssignApplicationCertificateBTN
            // 
            this.AssignApplicationCertificateBTN.Location = new System.Drawing.Point(18, 143);
            this.AssignApplicationCertificateBTN.Name = "AssignApplicationCertificateBTN";
            this.AssignApplicationCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.AssignApplicationCertificateBTN.TabIndex = 9;
            this.AssignApplicationCertificateBTN.Text = "Assign Application Certificate...";
            this.AssignApplicationCertificateBTN.UseVisualStyleBackColor = true;
            this.AssignApplicationCertificateBTN.Click += new System.EventHandler(this.AssignApplicationCertificateBTN_Click);
            // 
            // ManageApplicationPermissionsBTN
            // 
            this.ManageApplicationPermissionsBTN.Location = new System.Drawing.Point(18, 194);
            this.ManageApplicationPermissionsBTN.Name = "ManageApplicationPermissionsBTN";
            this.ManageApplicationPermissionsBTN.Size = new System.Drawing.Size(191, 21);
            this.ManageApplicationPermissionsBTN.TabIndex = 21;
            this.ManageApplicationPermissionsBTN.Text = "Manage Application Permissions...";
            this.ManageApplicationPermissionsBTN.UseVisualStyleBackColor = true;
            this.ManageApplicationPermissionsBTN.Click += new System.EventHandler(this.ManageApplicationPermissionsBTN_Click);
            // 
            // AssignTrustListBTN
            // 
            this.AssignTrustListBTN.Location = new System.Drawing.Point(18, 169);
            this.AssignTrustListBTN.Name = "AssignTrustListBTN";
            this.AssignTrustListBTN.Size = new System.Drawing.Size(191, 21);
            this.AssignTrustListBTN.TabIndex = 13;
            this.AssignTrustListBTN.Text = "Assign Certificate Trust List...";
            this.AssignTrustListBTN.UseVisualStyleBackColor = true;
            this.AssignTrustListBTN.Click += new System.EventHandler(this.AssignTrustListBTN_Click);
            // 
            // CreateApplicationCertificateBTN
            // 
            this.CreateApplicationCertificateBTN.Location = new System.Drawing.Point(18, 116);
            this.CreateApplicationCertificateBTN.Name = "CreateApplicationCertificateBTN";
            this.CreateApplicationCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.CreateApplicationCertificateBTN.TabIndex = 7;
            this.CreateApplicationCertificateBTN.Text = "Create Application Certificate...";
            this.CreateApplicationCertificateBTN.UseVisualStyleBackColor = true;
            this.CreateApplicationCertificateBTN.Click += new System.EventHandler(this.CreateApplicationCertificateBTN_Click);
            // 
            // ImportApplicationCertificateBTN
            // 
            this.ImportApplicationCertificateBTN.Location = new System.Drawing.Point(18, 90);
            this.ImportApplicationCertificateBTN.Name = "ImportApplicationCertificateBTN";
            this.ImportApplicationCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportApplicationCertificateBTN.TabIndex = 5;
            this.ImportApplicationCertificateBTN.Text = "Import Application Certificate...";
            this.ImportApplicationCertificateBTN.UseVisualStyleBackColor = true;
            this.ImportApplicationCertificateBTN.Click += new System.EventHandler(this.ImportApplicationCertificateBTN_Click);
            // 
            // ViewApplicationCertificateBTN
            // 
            this.ViewApplicationCertificateBTN.Location = new System.Drawing.Point(18, 63);
            this.ViewApplicationCertificateBTN.Name = "ViewApplicationCertificateBTN";
            this.ViewApplicationCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.ViewApplicationCertificateBTN.TabIndex = 3;
            this.ViewApplicationCertificateBTN.Text = "View Application Certificate...";
            this.ViewApplicationCertificateBTN.UseVisualStyleBackColor = true;
            this.ViewApplicationCertificateBTN.Click += new System.EventHandler(this.ViewApplicationCertificateBTN_Click);
            // 
            // ApplicationToManageLB
            // 
            this.ApplicationToManageLB.AutoSize = true;
            this.ApplicationToManageLB.Location = new System.Drawing.Point(18, 26);
            this.ApplicationToManageLB.Name = "ApplicationToManageLB";
            this.ApplicationToManageLB.Size = new System.Drawing.Size(122, 12);
            this.ApplicationToManageLB.TabIndex = 0;
            this.ApplicationToManageLB.Text = "Application To Manage";
            // 
            // ApplicationToManageCTRL
            // 
            this.ApplicationToManageCTRL.Location = new System.Drawing.Point(141, 21);
            this.ApplicationToManageCTRL.MaximumSize = new System.Drawing.Size(4096, 22);
            this.ApplicationToManageCTRL.MinimumSize = new System.Drawing.Size(300, 22);
            this.ApplicationToManageCTRL.Name = "ApplicationToManageCTRL";
            this.ApplicationToManageCTRL.Size = new System.Drawing.Size(693, 22);
            this.ApplicationToManageCTRL.TabIndex = 28;
            this.ApplicationToManageCTRL.ApplicationChanged += new System.EventHandler(this.ApplicationToManageCTRL_ApplicationChanged);
            // 
            // CertificatesTAB
            // 
            this.CertificatesTAB.Controls.Add(this.BindSslCertificateLB);
            this.CertificatesTAB.Controls.Add(this.BindSslCertificateBTN);
            this.CertificatesTAB.Controls.Add(this.IssueSslCertificateLB);
            this.CertificatesTAB.Controls.Add(this.IssueSslCertificateBTN);
            this.CertificatesTAB.Controls.Add(this.ImportCertificateListToStoreLB);
            this.CertificatesTAB.Controls.Add(this.ImportCertificateListToStoreBTN);
            this.CertificatesTAB.Controls.Add(this.ImportCertificateToStoreLB);
            this.CertificatesTAB.Controls.Add(this.ImportCertificateToStoreBTN);
            this.CertificatesTAB.Controls.Add(this.ExportPrivateKeyLB);
            this.CertificatesTAB.Controls.Add(this.ExportPrivateKeyBTN);
            this.CertificatesTAB.Controls.Add(this.ImportAndIssueCertificateLB);
            this.CertificatesTAB.Controls.Add(this.ImportAndIssueCertificateBTN);
            this.CertificatesTAB.Controls.Add(this.IssuerBrowseBTN);
            this.CertificatesTAB.Controls.Add(this.IssuerKeyFilePathTB);
            this.CertificatesTAB.Controls.Add(this.IssuerKeyFilePathLB);
            this.CertificatesTAB.Controls.Add(this.SelectAndIssueCertificateLB);
            this.CertificatesTAB.Controls.Add(this.SelectAndIssueCertificateBTN);
            this.CertificatesTAB.Controls.Add(this.ViewCertificatesLB);
            this.CertificatesTAB.Controls.Add(this.CreateCertificateAuthorityLB);
            this.CertificatesTAB.Controls.Add(this.ViewCertificatesBTN);
            this.CertificatesTAB.Controls.Add(this.CreateCertificateAuthorityBTN);
            this.CertificatesTAB.Controls.Add(this.ManagedStoreCTRL);
            this.CertificatesTAB.Location = new System.Drawing.Point(4, 22);
            this.CertificatesTAB.Name = "CertificatesTAB";
            this.CertificatesTAB.Padding = new System.Windows.Forms.Padding(3);
            this.CertificatesTAB.Size = new System.Drawing.Size(1062, 452);
            this.CertificatesTAB.TabIndex = 1;
            this.CertificatesTAB.Text = "Manage Certificates";
            this.CertificatesTAB.UseVisualStyleBackColor = true;
            // 
            // BindSslCertificateLB
            // 
            this.BindSslCertificateLB.AutoSize = true;
            this.BindSslCertificateLB.Location = new System.Drawing.Point(222, 324);
            this.BindSslCertificateLB.Name = "BindSslCertificateLB";
            this.BindSslCertificateLB.Size = new System.Drawing.Size(196, 12);
            this.BindSslCertificateLB.TabIndex = 55;
            this.BindSslCertificateLB.Text = "Binds an SSL/TLS certificate to port.";
            // 
            // BindSslCertificateBTN
            // 
            this.BindSslCertificateBTN.Location = new System.Drawing.Point(18, 319);
            this.BindSslCertificateBTN.Name = "BindSslCertificateBTN";
            this.BindSslCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.BindSslCertificateBTN.TabIndex = 54;
            this.BindSslCertificateBTN.Text = "Bind SSL/TLS Certificate...";
            this.BindSslCertificateBTN.UseVisualStyleBackColor = true;
            this.BindSslCertificateBTN.Click += new System.EventHandler(this.BindSslCertificateBTN_Click);
            // 
            // IssueSslCertificateLB
            // 
            this.IssueSslCertificateLB.AutoSize = true;
            this.IssueSslCertificateLB.Location = new System.Drawing.Point(222, 297);
            this.IssueSslCertificateLB.Name = "IssueSslCertificateLB";
            this.IssueSslCertificateLB.Size = new System.Drawing.Size(187, 12);
            this.IssueSslCertificateLB.TabIndex = 53;
            this.IssueSslCertificateLB.Text = "Creates a new SSL/TLS certificate.";
            // 
            // IssueSslCertificateBTN
            // 
            this.IssueSslCertificateBTN.Location = new System.Drawing.Point(18, 293);
            this.IssueSslCertificateBTN.Name = "IssueSslCertificateBTN";
            this.IssueSslCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.IssueSslCertificateBTN.TabIndex = 52;
            this.IssueSslCertificateBTN.Text = "Issue SSL/TLS Certificate...";
            this.IssueSslCertificateBTN.UseVisualStyleBackColor = true;
            this.IssueSslCertificateBTN.Click += new System.EventHandler(this.IssueSslCertificateBTN_Click);
            // 
            // ImportCertificateListToStoreLB
            // 
            this.ImportCertificateListToStoreLB.AutoSize = true;
            this.ImportCertificateListToStoreLB.Location = new System.Drawing.Point(222, 270);
            this.ImportCertificateListToStoreLB.Name = "ImportCertificateListToStoreLB";
            this.ImportCertificateListToStoreLB.Size = new System.Drawing.Size(208, 12);
            this.ImportCertificateListToStoreLB.TabIndex = 51;
            this.ImportCertificateListToStoreLB.Text = "Imports all certificates in another store.";
            // 
            // ImportCertificateListToStoreBTN
            // 
            this.ImportCertificateListToStoreBTN.Location = new System.Drawing.Point(18, 266);
            this.ImportCertificateListToStoreBTN.Name = "ImportCertificateListToStoreBTN";
            this.ImportCertificateListToStoreBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportCertificateListToStoreBTN.TabIndex = 50;
            this.ImportCertificateListToStoreBTN.Text = "Import Certificates into Store...";
            this.ImportCertificateListToStoreBTN.UseVisualStyleBackColor = true;
            this.ImportCertificateListToStoreBTN.Click += new System.EventHandler(this.ImportCertificateListToStoreBTN_Click);
            // 
            // ImportCertificateToStoreLB
            // 
            this.ImportCertificateToStoreLB.AutoSize = true;
            this.ImportCertificateToStoreLB.Location = new System.Drawing.Point(222, 244);
            this.ImportCertificateToStoreLB.Name = "ImportCertificateToStoreLB";
            this.ImportCertificateToStoreLB.Size = new System.Drawing.Size(251, 12);
            this.ImportCertificateToStoreLB.TabIndex = 49;
            this.ImportCertificateToStoreLB.Text = "Imports a certificate file to the certificate store.";
            // 
            // ImportCertificateToStoreBTN
            // 
            this.ImportCertificateToStoreBTN.Location = new System.Drawing.Point(18, 239);
            this.ImportCertificateToStoreBTN.Name = "ImportCertificateToStoreBTN";
            this.ImportCertificateToStoreBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportCertificateToStoreBTN.TabIndex = 48;
            this.ImportCertificateToStoreBTN.Text = "Import Certificate to Store...";
            this.ImportCertificateToStoreBTN.UseVisualStyleBackColor = true;
            this.ImportCertificateToStoreBTN.Click += new System.EventHandler(this.ImportCertificateToStoreBTN_Click);
            // 
            // ExportPrivateKeyLB
            // 
            this.ExportPrivateKeyLB.AutoSize = true;
            this.ExportPrivateKeyLB.Location = new System.Drawing.Point(222, 217);
            this.ExportPrivateKeyLB.Name = "ExportPrivateKeyLB";
            this.ExportPrivateKeyLB.Size = new System.Drawing.Size(352, 12);
            this.ExportPrivateKeyLB.TabIndex = 13;
            this.ExportPrivateKeyLB.Text = "Saves a certificate and its private key to a password protected file.";
            // 
            // ExportPrivateKeyBTN
            // 
            this.ExportPrivateKeyBTN.Location = new System.Drawing.Point(18, 212);
            this.ExportPrivateKeyBTN.Name = "ExportPrivateKeyBTN";
            this.ExportPrivateKeyBTN.Size = new System.Drawing.Size(191, 21);
            this.ExportPrivateKeyBTN.TabIndex = 12;
            this.ExportPrivateKeyBTN.Text = "Export Private Key...";
            this.ExportPrivateKeyBTN.UseVisualStyleBackColor = true;
            this.ExportPrivateKeyBTN.Click += new System.EventHandler(this.ExportPrivateKeyBTN_Click);
            // 
            // ImportAndIssueCertificateLB
            // 
            this.ImportAndIssueCertificateLB.AutoSize = true;
            this.ImportAndIssueCertificateLB.Location = new System.Drawing.Point(222, 190);
            this.ImportAndIssueCertificateLB.Name = "ImportAndIssueCertificateLB";
            this.ImportAndIssueCertificateLB.Size = new System.Drawing.Size(373, 12);
            this.ImportAndIssueCertificateLB.TabIndex = 11;
            this.ImportAndIssueCertificateLB.Text = "Imports a certificate file and issues new one with the same information.";
            // 
            // ImportAndIssueCertificateBTN
            // 
            this.ImportAndIssueCertificateBTN.Location = new System.Drawing.Point(18, 186);
            this.ImportAndIssueCertificateBTN.Name = "ImportAndIssueCertificateBTN";
            this.ImportAndIssueCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.ImportAndIssueCertificateBTN.TabIndex = 10;
            this.ImportAndIssueCertificateBTN.Text = "Import and Issue Certificate...";
            this.ImportAndIssueCertificateBTN.UseVisualStyleBackColor = true;
            this.ImportAndIssueCertificateBTN.Click += new System.EventHandler(this.ImportAndIssueCertificateBTN_Click);
            // 
            // IssuerBrowseBTN
            // 
            this.IssuerBrowseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IssuerBrowseBTN.Location = new System.Drawing.Point(708, 75);
            this.IssuerBrowseBTN.Name = "IssuerBrowseBTN";
            this.IssuerBrowseBTN.Size = new System.Drawing.Size(75, 21);
            this.IssuerBrowseBTN.TabIndex = 9;
            this.IssuerBrowseBTN.Text = "Browse...";
            this.IssuerBrowseBTN.UseVisualStyleBackColor = true;
            this.IssuerBrowseBTN.Click += new System.EventHandler(this.IssuerBrowseBTN_Click);
            // 
            // IssuerKeyFilePathTB
            // 
            this.IssuerKeyFilePathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IssuerKeyFilePathTB.Location = new System.Drawing.Point(93, 77);
            this.IssuerKeyFilePathTB.Name = "IssuerKeyFilePathTB";
            this.IssuerKeyFilePathTB.Size = new System.Drawing.Size(609, 19);
            this.IssuerKeyFilePathTB.TabIndex = 8;
            // 
            // IssuerKeyFilePathLB
            // 
            this.IssuerKeyFilePathLB.AutoSize = true;
            this.IssuerKeyFilePathLB.Location = new System.Drawing.Point(18, 78);
            this.IssuerKeyFilePathLB.Name = "IssuerKeyFilePathLB";
            this.IssuerKeyFilePathLB.Size = new System.Drawing.Size(67, 12);
            this.IssuerKeyFilePathLB.TabIndex = 7;
            this.IssuerKeyFilePathLB.Text = "CA Key File";
            this.IssuerKeyFilePathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectAndIssueCertificateLB
            // 
            this.SelectAndIssueCertificateLB.AutoSize = true;
            this.SelectAndIssueCertificateLB.Location = new System.Drawing.Point(222, 163);
            this.SelectAndIssueCertificateLB.Name = "SelectAndIssueCertificateLB";
            this.SelectAndIssueCertificateLB.Size = new System.Drawing.Size(403, 12);
            this.SelectAndIssueCertificateLB.TabIndex = 6;
            this.SelectAndIssueCertificateLB.Text = "Selects an existing certificate and issues new one with the same information.";
            // 
            // SelectAndIssueCertificateBTN
            // 
            this.SelectAndIssueCertificateBTN.Location = new System.Drawing.Point(18, 159);
            this.SelectAndIssueCertificateBTN.Name = "SelectAndIssueCertificateBTN";
            this.SelectAndIssueCertificateBTN.Size = new System.Drawing.Size(191, 21);
            this.SelectAndIssueCertificateBTN.TabIndex = 5;
            this.SelectAndIssueCertificateBTN.Text = "Select and Issue Certificate...";
            this.SelectAndIssueCertificateBTN.UseVisualStyleBackColor = true;
            this.SelectAndIssueCertificateBTN.Click += new System.EventHandler(this.SelectAndIssueCertificateBTN_Click);
            // 
            // ViewCertificatesLB
            // 
            this.ViewCertificatesLB.AutoSize = true;
            this.ViewCertificatesLB.Location = new System.Drawing.Point(222, 110);
            this.ViewCertificatesLB.Name = "ViewCertificatesLB";
            this.ViewCertificatesLB.Size = new System.Drawing.Size(196, 12);
            this.ViewCertificatesLB.TabIndex = 4;
            this.ViewCertificatesLB.Text = "Displays the certificates in the store.";
            // 
            // CreateCertificateAuthorityLB
            // 
            this.CreateCertificateAuthorityLB.AutoSize = true;
            this.CreateCertificateAuthorityLB.Location = new System.Drawing.Point(222, 137);
            this.CreateCertificateAuthorityLB.Name = "CreateCertificateAuthorityLB";
            this.CreateCertificateAuthorityLB.Size = new System.Drawing.Size(369, 12);
            this.CreateCertificateAuthorityLB.TabIndex = 2;
            this.CreateCertificateAuthorityLB.Text = "Creates a certificate that can be used to issue application certificates.";
            // 
            // ViewCertificatesBTN
            // 
            this.ViewCertificatesBTN.Location = new System.Drawing.Point(18, 105);
            this.ViewCertificatesBTN.Name = "ViewCertificatesBTN";
            this.ViewCertificatesBTN.Size = new System.Drawing.Size(191, 21);
            this.ViewCertificatesBTN.TabIndex = 3;
            this.ViewCertificatesBTN.Text = "View Certificates...";
            this.ViewCertificatesBTN.UseVisualStyleBackColor = true;
            this.ViewCertificatesBTN.Click += new System.EventHandler(this.ViewCertificatesBTN_Click);
            // 
            // CreateCertificateAuthorityBTN
            // 
            this.CreateCertificateAuthorityBTN.Location = new System.Drawing.Point(18, 132);
            this.CreateCertificateAuthorityBTN.Name = "CreateCertificateAuthorityBTN";
            this.CreateCertificateAuthorityBTN.Size = new System.Drawing.Size(191, 21);
            this.CreateCertificateAuthorityBTN.TabIndex = 1;
            this.CreateCertificateAuthorityBTN.Text = "Create Certificate Authority...";
            this.CreateCertificateAuthorityBTN.UseVisualStyleBackColor = true;
            this.CreateCertificateAuthorityBTN.Click += new System.EventHandler(this.CreateCertificateAuthorityBTN_Click);
            // 
            // ManagedStoreCTRL
            // 
            this.ManagedStoreCTRL.Location = new System.Drawing.Point(18, 26);
            this.ManagedStoreCTRL.MinimumSize = new System.Drawing.Size(300, 47);
            this.ManagedStoreCTRL.Name = "ManagedStoreCTRL";
            this.ManagedStoreCTRL.Size = new System.Drawing.Size(765, 47);
            this.ManagedStoreCTRL.StorePath = "X:\\OPC\\Source\\UA311\\Source\\Utilities\\CertificateGenerator";
            this.ManagedStoreCTRL.TabIndex = 0;
            // 
            // ComServersTAB
            // 
            this.ComServersTAB.Controls.Add(this.ComServersCTRL);
            this.ComServersTAB.Controls.Add(this.ComTopPN);
            this.ComServersTAB.Location = new System.Drawing.Point(4, 22);
            this.ComServersTAB.Name = "ComServersTAB";
            this.ComServersTAB.Padding = new System.Windows.Forms.Padding(3);
            this.ComServersTAB.Size = new System.Drawing.Size(1062, 448);
            this.ComServersTAB.TabIndex = 2;
            this.ComServersTAB.Text = "Manage COM Interop";
            this.ComServersTAB.UseVisualStyleBackColor = true;
            // 
            // ComServersCTRL
            // 
            this.ComServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComServersCTRL.Instructions = null;
            this.ComServersCTRL.Location = new System.Drawing.Point(3, 91);
            this.ComServersCTRL.Name = "ComServersCTRL";
            this.ComServersCTRL.Size = new System.Drawing.Size(1056, 354);
            this.ComServersCTRL.TabIndex = 1;
            // 
            // ComTopPN
            // 
            this.ComTopPN.Controls.Add(this.NewComServerBTN);
            this.ComTopPN.Controls.Add(this.WrapComServerBTN);
            this.ComTopPN.Controls.Add(this.WrapComServerLB);
            this.ComTopPN.Controls.Add(this.NewComServerLB);
            this.ComTopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComTopPN.Location = new System.Drawing.Point(3, 3);
            this.ComTopPN.Name = "ComTopPN";
            this.ComTopPN.Size = new System.Drawing.Size(1056, 88);
            this.ComTopPN.TabIndex = 0;
            // 
            // NewComServerBTN
            // 
            this.NewComServerBTN.Location = new System.Drawing.Point(25, 19);
            this.NewComServerBTN.Name = "NewComServerBTN";
            this.NewComServerBTN.Size = new System.Drawing.Size(119, 21);
            this.NewComServerBTN.TabIndex = 0;
            this.NewComServerBTN.Text = "Wrap UA Server...";
            this.NewComServerBTN.UseVisualStyleBackColor = true;
            this.NewComServerBTN.Click += new System.EventHandler(this.NewComServerBTN_Click);
            // 
            // WrapComServerBTN
            // 
            this.WrapComServerBTN.Location = new System.Drawing.Point(25, 46);
            this.WrapComServerBTN.Name = "WrapComServerBTN";
            this.WrapComServerBTN.Size = new System.Drawing.Size(119, 21);
            this.WrapComServerBTN.TabIndex = 2;
            this.WrapComServerBTN.Text = "Wrap COM Servers...";
            this.WrapComServerBTN.UseVisualStyleBackColor = true;
            this.WrapComServerBTN.Click += new System.EventHandler(this.WrapComServerBTN_Click);
            // 
            // WrapComServerLB
            // 
            this.WrapComServerLB.AutoSize = true;
            this.WrapComServerLB.Location = new System.Drawing.Point(147, 51);
            this.WrapComServerLB.Name = "WrapComServerLB";
            this.WrapComServerLB.Size = new System.Drawing.Size(221, 12);
            this.WrapComServerLB.TabIndex = 3;
            this.WrapComServerLB.Text = "Make a COM Server visible to UA Clients.";
            this.WrapComServerLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewComServerLB
            // 
            this.NewComServerLB.AutoSize = true;
            this.NewComServerLB.Location = new System.Drawing.Point(147, 24);
            this.NewComServerLB.Name = "NewComServerLB";
            this.NewComServerLB.Size = new System.Drawing.Size(221, 12);
            this.NewComServerLB.TabIndex = 1;
            this.NewComServerLB.Text = "Make a UA Server visible to COM Clients.";
            this.NewComServerLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HttpAccessRulesTAB
            // 
            this.HttpAccessRulesTAB.Controls.Add(this.HttpAccessRuleCTRL);
            this.HttpAccessRulesTAB.Location = new System.Drawing.Point(4, 22);
            this.HttpAccessRulesTAB.Name = "HttpAccessRulesTAB";
            this.HttpAccessRulesTAB.Size = new System.Drawing.Size(1062, 452);
            this.HttpAccessRulesTAB.TabIndex = 3;
            this.HttpAccessRulesTAB.Text = "HTTP Access Rules";
            this.HttpAccessRulesTAB.UseVisualStyleBackColor = true;
            // 
            // HttpAccessRuleCTRL
            // 
            this.HttpAccessRuleCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HttpAccessRuleCTRL.Instructions = null;
            this.HttpAccessRuleCTRL.Location = new System.Drawing.Point(0, 0);
            this.HttpAccessRuleCTRL.Name = "HttpAccessRuleCTRL";
            this.HttpAccessRuleCTRL.Size = new System.Drawing.Size(1062, 452);
            this.HttpAccessRuleCTRL.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 522);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "UA Configuration Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.TabsPN.ResumeLayout(false);
            this.ManageSecurityTAB.ResumeLayout(false);
            this.ManageSecurityTAB.PerformLayout();
            this.ApplicationTAB.ResumeLayout(false);
            this.ApplicationTAB.PerformLayout();
            this.CertificatesTAB.ResumeLayout(false);
            this.CertificatesTAB.PerformLayout();
            this.ComServersTAB.ResumeLayout(false);
            this.ComTopPN.ResumeLayout(false);
            this.ComTopPN.PerformLayout();
            this.HttpAccessRulesTAB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem FileMI;
        private System.Windows.Forms.ToolStripMenuItem File_ExitMI;
        private System.Windows.Forms.ToolStripMenuItem HelpMI;
        private System.Windows.Forms.ToolStripMenuItem Help_AboutMI;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.TabControl TabsPN;
        private System.Windows.Forms.TabPage CertificatesTAB;
        private System.Windows.Forms.TabPage ComServersTAB;
        private Opc.Ua.Client.Controls.PseudoComServerListCtrl ComServersCTRL;
        private System.Windows.Forms.TabPage HttpAccessRulesTAB;
        private HttpAccessRulelListCtrl HttpAccessRuleCTRL;
        private System.Windows.Forms.Button ViewCertificatesBTN;
        private System.Windows.Forms.Button CreateCertificateAuthorityBTN;
        private Opc.Ua.Client.Controls.CertificateStoreCtrl ManagedStoreCTRL;
        private System.Windows.Forms.Panel ComTopPN;
        private System.Windows.Forms.Button NewComServerBTN;
        private System.Windows.Forms.Button WrapComServerBTN;
        private System.Windows.Forms.Label WrapComServerLB;
        private System.Windows.Forms.Label NewComServerLB;
        private System.Windows.Forms.Label ViewCertificatesLB;
        private System.Windows.Forms.Label CreateCertificateAuthorityLB;
        private System.Windows.Forms.ToolStripMenuItem ClearRecentFileListsMI;
        private System.Windows.Forms.TabPage ManageSecurityTAB;
        private ManagedApplicationCtrl ManageApplicationSecurityCTRL;
        private System.Windows.Forms.Label RegisterWithDiscoveryServerLB;
        private System.Windows.Forms.Button RegisterWithDiscoveryServerBTN;
        private System.Windows.Forms.Button ImportCertificateListToTrustBTN;
        private System.Windows.Forms.Label ImportCertificateToTrustLB;
        private System.Windows.Forms.Button ImportCertificateToTrustBTN;
        private System.Windows.Forms.Label SelectCertificateToTrustLB;
        private System.Windows.Forms.Button SelectCertificateToTrustBTN;
        private System.Windows.Forms.Label ViewTrustedCertificatesLB;
        private System.Windows.Forms.Button ViewTrustedCertificatesBTN;
        private System.Windows.Forms.Label ManageApplicationLB;
        private System.Windows.Forms.Button TrustAnotherApplicationBTN;
        private System.Windows.Forms.Label TrustAnotherApplicationLB;
        private System.Windows.Forms.Label DeleteAllTrustedCertificatesLB;
        private System.Windows.Forms.Button DeleteAllTrustedCertificatesBTN;
        private System.Windows.Forms.TabPage ApplicationTAB;
        private ManagedApplicationCtrl ApplicationToManageCTRL;
        private System.Windows.Forms.Label ManageApplicationPermissionsLB;
        private System.Windows.Forms.Label AssignTrustListLB;
        private System.Windows.Forms.Label AssignApplicationCertificateLB;
        private System.Windows.Forms.Label CreateApplicationCertificateLB;
        private System.Windows.Forms.Label ImportApplicationCertificateLB;
        private System.Windows.Forms.Label ViewApplicationCertificateLB;
        private System.Windows.Forms.Button AssignApplicationCertificateBTN;
        private System.Windows.Forms.Button ManageApplicationPermissionsBTN;
        private System.Windows.Forms.Button AssignTrustListBTN;
        private System.Windows.Forms.Button CreateApplicationCertificateBTN;
        private System.Windows.Forms.Button ImportApplicationCertificateBTN;
        private System.Windows.Forms.Button ViewApplicationCertificateBTN;
        private System.Windows.Forms.Label ApplicationToManageLB;
        private System.Windows.Forms.Label ManageFirewallAccessLB;
        private System.Windows.Forms.Button ManageFirewallAccessBTN;
        private System.Windows.Forms.Label SelectAndIssueCertificateLB;
        private System.Windows.Forms.Button SelectAndIssueCertificateBTN;
        private System.Windows.Forms.Button IssuerBrowseBTN;
        private System.Windows.Forms.TextBox IssuerKeyFilePathTB;
        private System.Windows.Forms.Label IssuerKeyFilePathLB;
        private System.Windows.Forms.Label ImportAndIssueCertificateLB;
        private System.Windows.Forms.Button ImportAndIssueCertificateBTN;
        private System.Windows.Forms.Label ExportPrivateKeyLB;
        private System.Windows.Forms.Button ExportPrivateKeyBTN;
        private System.Windows.Forms.Label ExportApplicationCertificateLB;
        private System.Windows.Forms.Button ExportApplicationCertificateBTN;
        private System.Windows.Forms.Label ImportCertificateListToStoreLB;
        private System.Windows.Forms.Button ImportCertificateListToStoreBTN;
        private System.Windows.Forms.Label ImportCertificateToStoreLB;
        private System.Windows.Forms.Button ImportCertificateToStoreBTN;
        private System.Windows.Forms.Label ImportCertificateListToTrustLB;
        private System.Windows.Forms.Label BindSslCertificateLB;
        private System.Windows.Forms.Button BindSslCertificateBTN;
        private System.Windows.Forms.Label IssueSslCertificateLB;
        private System.Windows.Forms.Button IssueSslCertificateBTN;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
    }
}
