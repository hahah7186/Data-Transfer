/* ========================================================================
 * Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
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

namespace Quickstarts.DataAccessClient
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
            this.components = new System.ComponentModel.Container();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.BrowsingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Browse_MonitorMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_ReadHistoryMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Monitoring_DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_FastMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_1000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_2500MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_5000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_NoneMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_AbsoluteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_25MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_PercentageMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_1MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectServerCTRL = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.TopPN = new System.Windows.Forms.SplitContainer();
            this.BrowseNodesTV = new System.Windows.Forms.TreeView();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.MonitoredItemIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeadbandCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisplayNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownVacuumDegreeRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVacuumDegreeLeft = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPressureRight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownPressureLeft = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.StartReportBtn = new System.Windows.Forms.Button();
            this.numericUpDownTemperatureRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTemperatureLeft = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteLogBtn = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.MainPN = new System.Windows.Forms.SplitContainer();
            this.MenuBar.SuspendLayout();
            this.BrowsingMenu.SuspendLayout();
            this.MonitoringMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPN)).BeginInit();
            this.TopPN.Panel1.SuspendLayout();
            this.TopPN.Panel2.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVacuumDegreeRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVacuumDegreeLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPressureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPressureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPN)).BeginInit();
            this.MainPN.Panel1.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.ServerMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(884, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fILEToolStripMenuItem.Text = "程式";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_ConnectMI,
            this.Server_DisconnectMI});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new System.Drawing.Size(58, 20);
            this.ServerMI.Text = "服务器";
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new System.Drawing.Size(126, 22);
            this.Server_ConnectMI.Text = "連接";
            this.Server_ConnectMI.Click += new System.EventHandler(this.Server_ConnectMI_ClickAsync);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new System.Drawing.Size(126, 22);
            this.Server_DisconnectMI.Text = "斷開連接";
            this.Server_DisconnectMI.Click += new System.EventHandler(this.Server_DisconnectMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 524);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(884, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // BrowsingMenu
            // 
            this.BrowsingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Browse_MonitorMI,
            this.Browse_WriteMI,
            this.Browse_ReadHistoryMI});
            this.BrowsingMenu.Name = "BrowsingMenu";
            this.BrowsingMenu.Size = new System.Drawing.Size(151, 70);
            this.BrowsingMenu.Opening += new System.ComponentModel.CancelEventHandler(this.BrowsingMenu_Opening);
            // 
            // Browse_MonitorMI
            // 
            this.Browse_MonitorMI.Name = "Browse_MonitorMI";
            this.Browse_MonitorMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_MonitorMI.Text = "Monitor";
            this.Browse_MonitorMI.Click += new System.EventHandler(this.Browse_MonitorMI_Click);
            // 
            // Browse_WriteMI
            // 
            this.Browse_WriteMI.Name = "Browse_WriteMI";
            this.Browse_WriteMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_WriteMI.Text = "Write...";
            this.Browse_WriteMI.Click += new System.EventHandler(this.Browse_WriteMI_Click);
            // 
            // Browse_ReadHistoryMI
            // 
            this.Browse_ReadHistoryMI.Name = "Browse_ReadHistoryMI";
            this.Browse_ReadHistoryMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_ReadHistoryMI.Text = "Read History...";
            this.Browse_ReadHistoryMI.Click += new System.EventHandler(this.Browse_ReadHistoryMI_Click);
            // 
            // MonitoringMenu
            // 
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_WriteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(169, 114);
            // 
            // Monitoring_DeleteMI
            // 
            this.Monitoring_DeleteMI.Name = "Monitoring_DeleteMI";
            this.Monitoring_DeleteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeleteMI.Text = "Delete";
            this.Monitoring_DeleteMI.Click += new System.EventHandler(this.Monitoring_DeleteMI_Click);
            // 
            // Monitoring_WriteMI
            // 
            this.Monitoring_WriteMI.Name = "Monitoring_WriteMI";
            this.Monitoring_WriteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_WriteMI.Text = "Write...";
            this.Monitoring_WriteMI.Click += new System.EventHandler(this.Monitoring_WriteMI_Click);
            // 
            // Monitoring_MonitoringModeMI
            // 
            this.Monitoring_MonitoringModeMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_MonitoringMode_DisabledMI,
            this.Monitoring_MonitoringMode_SamplingMI,
            this.Monitoring_MonitoringMode_ReportingMI});
            this.Monitoring_MonitoringModeMI.Name = "Monitoring_MonitoringModeMI";
            this.Monitoring_MonitoringModeMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_MonitoringModeMI.Text = "Monitoring Mode";
            // 
            // Monitoring_MonitoringMode_DisabledMI
            // 
            this.Monitoring_MonitoringMode_DisabledMI.Name = "Monitoring_MonitoringMode_DisabledMI";
            this.Monitoring_MonitoringMode_DisabledMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_DisabledMI.Text = "Disabled";
            this.Monitoring_MonitoringMode_DisabledMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_SamplingMI
            // 
            this.Monitoring_MonitoringMode_SamplingMI.Name = "Monitoring_MonitoringMode_SamplingMI";
            this.Monitoring_MonitoringMode_SamplingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_SamplingMI.Text = "Sampling";
            this.Monitoring_MonitoringMode_SamplingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_ReportingMI
            // 
            this.Monitoring_MonitoringMode_ReportingMI.Name = "Monitoring_MonitoringMode_ReportingMI";
            this.Monitoring_MonitoringMode_ReportingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_ReportingMI.Text = "Reporting";
            this.Monitoring_MonitoringMode_ReportingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_SamplingIntervalMI
            // 
            this.Monitoring_SamplingIntervalMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_SamplingInterval_FastMI,
            this.Monitoring_SamplingInterval_1000MI,
            this.Monitoring_SamplingInterval_2500MI,
            this.Monitoring_SamplingInterval_5000MI});
            this.Monitoring_SamplingIntervalMI.Name = "Monitoring_SamplingIntervalMI";
            this.Monitoring_SamplingIntervalMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_SamplingIntervalMI.Text = "Samping Interval";
            // 
            // Monitoring_SamplingInterval_FastMI
            // 
            this.Monitoring_SamplingInterval_FastMI.Name = "Monitoring_SamplingInterval_FastMI";
            this.Monitoring_SamplingInterval_FastMI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_FastMI.Text = "Fast as Possible";
            this.Monitoring_SamplingInterval_FastMI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_1000MI
            // 
            this.Monitoring_SamplingInterval_1000MI.Name = "Monitoring_SamplingInterval_1000MI";
            this.Monitoring_SamplingInterval_1000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_1000MI.Text = "1000ms";
            this.Monitoring_SamplingInterval_1000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_2500MI
            // 
            this.Monitoring_SamplingInterval_2500MI.Name = "Monitoring_SamplingInterval_2500MI";
            this.Monitoring_SamplingInterval_2500MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_2500MI.Text = "2500ms";
            this.Monitoring_SamplingInterval_2500MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_5000MI
            // 
            this.Monitoring_SamplingInterval_5000MI.Name = "Monitoring_SamplingInterval_5000MI";
            this.Monitoring_SamplingInterval_5000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_5000MI.Text = "5000ms";
            this.Monitoring_SamplingInterval_5000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_DeadbandMI
            // 
            this.Monitoring_DeadbandMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_NoneMI,
            this.Monitoring_Deadband_AbsoluteMI,
            this.Monitoring_Deadband_PercentageMI});
            this.Monitoring_DeadbandMI.Name = "Monitoring_DeadbandMI";
            this.Monitoring_DeadbandMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeadbandMI.Text = "Deadband";
            // 
            // Monitoring_Deadband_NoneMI
            // 
            this.Monitoring_Deadband_NoneMI.Name = "Monitoring_Deadband_NoneMI";
            this.Monitoring_Deadband_NoneMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_NoneMI.Text = "None";
            this.Monitoring_Deadband_NoneMI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_AbsoluteMI
            // 
            this.Monitoring_Deadband_AbsoluteMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Absolute_5MI,
            this.Monitoring_Deadband_Absolute_10MI,
            this.Monitoring_Deadband_Absolute_25MI});
            this.Monitoring_Deadband_AbsoluteMI.Name = "Monitoring_Deadband_AbsoluteMI";
            this.Monitoring_Deadband_AbsoluteMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_AbsoluteMI.Text = "Absolute";
            // 
            // Monitoring_Deadband_Absolute_5MI
            // 
            this.Monitoring_Deadband_Absolute_5MI.Name = "Monitoring_Deadband_Absolute_5MI";
            this.Monitoring_Deadband_Absolute_5MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_5MI.Text = "5";
            this.Monitoring_Deadband_Absolute_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_10MI
            // 
            this.Monitoring_Deadband_Absolute_10MI.Name = "Monitoring_Deadband_Absolute_10MI";
            this.Monitoring_Deadband_Absolute_10MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_10MI.Text = "10";
            this.Monitoring_Deadband_Absolute_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_25MI
            // 
            this.Monitoring_Deadband_Absolute_25MI.Name = "Monitoring_Deadband_Absolute_25MI";
            this.Monitoring_Deadband_Absolute_25MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_25MI.Text = "25";
            this.Monitoring_Deadband_Absolute_25MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_PercentageMI
            // 
            this.Monitoring_Deadband_PercentageMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Percentage_1MI,
            this.Monitoring_Deadband_Percentage_5MI,
            this.Monitoring_Deadband_Percentage_10MI});
            this.Monitoring_Deadband_PercentageMI.Name = "Monitoring_Deadband_PercentageMI";
            this.Monitoring_Deadband_PercentageMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_PercentageMI.Text = "Percentage";
            // 
            // Monitoring_Deadband_Percentage_1MI
            // 
            this.Monitoring_Deadband_Percentage_1MI.Name = "Monitoring_Deadband_Percentage_1MI";
            this.Monitoring_Deadband_Percentage_1MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_1MI.Text = "1%";
            this.Monitoring_Deadband_Percentage_1MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_5MI
            // 
            this.Monitoring_Deadband_Percentage_5MI.Name = "Monitoring_Deadband_Percentage_5MI";
            this.Monitoring_Deadband_Percentage_5MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_5MI.Text = "5%";
            this.Monitoring_Deadband_Percentage_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_10MI
            // 
            this.Monitoring_Deadband_Percentage_10MI.Name = "Monitoring_Deadband_Percentage_10MI";
            this.Monitoring_Deadband_Percentage_10MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_10MI.Text = "10%";
            this.Monitoring_Deadband_Percentage_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // ConnectServerCTRL
            // 
            this.ConnectServerCTRL.Configuration = null;
            this.ConnectServerCTRL.DisableDomainCheck = false;
            this.ConnectServerCTRL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectServerCTRL.Location = new System.Drawing.Point(0, 24);
            this.ConnectServerCTRL.MaximumSize = new System.Drawing.Size(2048, 23);
            this.ConnectServerCTRL.MinimumSize = new System.Drawing.Size(500, 23);
            this.ConnectServerCTRL.Name = "ConnectServerCTRL";
            this.ConnectServerCTRL.PreferredLocales = null;
            this.ConnectServerCTRL.ServerUrl = "";
            this.ConnectServerCTRL.SessionName = null;
            this.ConnectServerCTRL.Size = new System.Drawing.Size(884, 23);
            this.ConnectServerCTRL.StatusStrip = this.StatusBar;
            this.ConnectServerCTRL.TabIndex = 4;
            this.ConnectServerCTRL.UserIdentity = null;
            this.ConnectServerCTRL.UseSecurity = true;
            this.ConnectServerCTRL.ReconnectStarting += new System.EventHandler(this.Server_ReconnectStarting);
            this.ConnectServerCTRL.ReconnectComplete += new System.EventHandler(this.Server_ReconnectComplete);
            this.ConnectServerCTRL.ConnectComplete += new System.EventHandler(this.Server_ConnectComplete);
            // 
            // TopPN
            // 
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            // 
            // TopPN.Panel1
            // 
            this.TopPN.Panel1.Controls.Add(this.BrowseNodesTV);
            // 
            // TopPN.Panel2
            // 
            this.TopPN.Panel2.Controls.Add(this.MonitoredItemsLV);
            this.TopPN.Panel2.Controls.Add(this.panel1);
            this.TopPN.Size = new System.Drawing.Size(884, 448);
            this.TopPN.SplitterDistance = 257;
            this.TopPN.TabIndex = 0;
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.ContextMenuStrip = this.BrowsingMenu;
            this.BrowseNodesTV.Location = new System.Drawing.Point(0, 0);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.Size = new System.Drawing.Size(254, 448);
            this.BrowseNodesTV.TabIndex = 0;
            this.BrowseNodesTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseNodesTV_BeforeExpand);
            this.BrowseNodesTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseNodesTV_AfterSelect);
            this.BrowseNodesTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseNodesTV_MouseDown);
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonitoredItemIdCH,
            this.DeadbandCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH,
            this.DisplayNameCH});
            this.MonitoredItemsLV.ContextMenuStrip = this.MonitoringMenu;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(2, 139);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(618, 309);
            this.MonitoredItemsLV.TabIndex = 0;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            // 
            // MonitoredItemIdCH
            // 
            this.MonitoredItemIdCH.Text = "ID";
            // 
            // DeadbandCH
            // 
            this.DeadbandCH.Text = "節點號";
            this.DeadbandCH.Width = 110;
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "數值";
            this.ValueCH.Width = 90;
            // 
            // QualityCH
            // 
            this.QualityCH.Text = "質量狀態";
            this.QualityCH.Width = 70;
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "時間";
            this.TimestampCH.Width = 109;
            // 
            // DisplayNameCH
            // 
            this.DisplayNameCH.Text = "變量名稱";
            this.DisplayNameCH.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownVacuumDegreeRight);
            this.panel1.Controls.Add(this.numericUpDownVacuumDegreeLeft);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numericUpDownPressureRight);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericUpDownPressureLeft);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.StartReportBtn);
            this.panel1.Controls.Add(this.numericUpDownTemperatureRight);
            this.panel1.Controls.Add(this.numericUpDownTemperatureLeft);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DeleteLogBtn);
            this.panel1.Controls.Add(this.checkBox);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 127);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDownVacuumDegreeRight
            // 
            this.numericUpDownVacuumDegreeRight.Location = new System.Drawing.Point(378, 94);
            this.numericUpDownVacuumDegreeRight.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeRight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeRight.Name = "numericUpDownVacuumDegreeRight";
            this.numericUpDownVacuumDegreeRight.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownVacuumDegreeRight.TabIndex = 15;
            this.numericUpDownVacuumDegreeRight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeRight.ValueChanged += new System.EventHandler(this.NumericUpDownVacuumDegreeRight_ValueChanged);
            // 
            // numericUpDownVacuumDegreeLeft
            // 
            this.numericUpDownVacuumDegreeLeft.Location = new System.Drawing.Point(104, 94);
            this.numericUpDownVacuumDegreeLeft.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeLeft.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeLeft.Name = "numericUpDownVacuumDegreeLeft";
            this.numericUpDownVacuumDegreeLeft.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownVacuumDegreeLeft.TabIndex = 14;
            this.numericUpDownVacuumDegreeLeft.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownVacuumDegreeLeft.ValueChanged += new System.EventHandler(this.NumericUpDownVacuumDegreeLeft_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "吸盤真空值右";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "吸盤真空值左";
            // 
            // numericUpDownPressureRight
            // 
            this.numericUpDownPressureRight.Location = new System.Drawing.Point(378, 67);
            this.numericUpDownPressureRight.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.numericUpDownPressureRight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPressureRight.Name = "numericUpDownPressureRight";
            this.numericUpDownPressureRight.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownPressureRight.TabIndex = 11;
            this.numericUpDownPressureRight.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numericUpDownPressureRight.ValueChanged += new System.EventHandler(this.numericUpDownPressureRight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "壓力左";
            // 
            // numericUpDownPressureLeft
            // 
            this.numericUpDownPressureLeft.Location = new System.Drawing.Point(104, 67);
            this.numericUpDownPressureLeft.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.numericUpDownPressureLeft.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPressureLeft.Name = "numericUpDownPressureLeft";
            this.numericUpDownPressureLeft.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownPressureLeft.TabIndex = 9;
            this.numericUpDownPressureLeft.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numericUpDownPressureLeft.ValueChanged += new System.EventHandler(this.numericUpDownPressureLeft_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "壓力左";
            // 
            // StartReportBtn
            // 
            this.StartReportBtn.Location = new System.Drawing.Point(403, 10);
            this.StartReportBtn.Name = "StartReportBtn";
            this.StartReportBtn.Size = new System.Drawing.Size(200, 23);
            this.StartReportBtn.TabIndex = 7;
            this.StartReportBtn.Text = "開始報站";
            this.StartReportBtn.UseVisualStyleBackColor = true;
            this.StartReportBtn.Click += new System.EventHandler(this.StartReportBtn_Click);
            // 
            // numericUpDownTemperatureRight
            // 
            this.numericUpDownTemperatureRight.Location = new System.Drawing.Point(378, 40);
            this.numericUpDownTemperatureRight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownTemperatureRight.Name = "numericUpDownTemperatureRight";
            this.numericUpDownTemperatureRight.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownTemperatureRight.TabIndex = 6;
            this.numericUpDownTemperatureRight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownTemperatureRight.ValueChanged += new System.EventHandler(this.NumericUpDownTemperatureRight_ValueChanged);
            // 
            // numericUpDownTemperatureLeft
            // 
            this.numericUpDownTemperatureLeft.Location = new System.Drawing.Point(104, 40);
            this.numericUpDownTemperatureLeft.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownTemperatureLeft.Name = "numericUpDownTemperatureLeft";
            this.numericUpDownTemperatureLeft.Size = new System.Drawing.Size(155, 20);
            this.numericUpDownTemperatureLeft.TabIndex = 5;
            this.numericUpDownTemperatureLeft.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownTemperatureLeft.ValueChanged += new System.EventHandler(this.NumericUpDownTemperatureLeft_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "溫控右";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "溫控左";
            // 
            // DeleteLogBtn
            // 
            this.DeleteLogBtn.Location = new System.Drawing.Point(171, 10);
            this.DeleteLogBtn.Name = "DeleteLogBtn";
            this.DeleteLogBtn.Size = new System.Drawing.Size(207, 23);
            this.DeleteLogBtn.TabIndex = 1;
            this.DeleteLogBtn.Text = "刪除過期日誌";
            this.DeleteLogBtn.UseVisualStyleBackColor = true;
            this.DeleteLogBtn.Click += new System.EventHandler(this.DeleteLogBtn_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Checked = true;
            this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox.Location = new System.Drawing.Point(16, 16);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(130, 17);
            this.checkBox.TabIndex = 2;
            this.checkBox.Text = "是否向SFC系統上傳";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // MainPN
            // 
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 47);
            this.MainPN.Name = "MainPN";
            this.MainPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainPN.Panel1
            // 
            this.MainPN.Panel1.Controls.Add(this.TopPN);
            this.MainPN.Size = new System.Drawing.Size(884, 477);
            this.MainPN.SplitterDistance = 448;
            this.MainPN.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 546);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ConnectServerCTRL);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "自動清溢膠-數據轉發";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.BrowsingMenu.ResumeLayout(false);
            this.MonitoringMenu.ResumeLayout(false);
            this.TopPN.Panel1.ResumeLayout(false);
            this.TopPN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPN)).EndInit();
            this.TopPN.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVacuumDegreeRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVacuumDegreeLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPressureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPressureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureLeft)).EndInit();
            this.MainPN.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPN)).EndInit();
            this.MainPN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem ServerMI;
        private System.Windows.Forms.ToolStripMenuItem Server_ConnectMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DisconnectMI;
        private System.Windows.Forms.ContextMenuStrip BrowsingMenu;
        private System.Windows.Forms.ToolStripMenuItem Browse_MonitorMI;
        private System.Windows.Forms.ToolStripMenuItem Browse_WriteMI;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_FastMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_1000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_2500MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_5000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeadbandMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_NoneMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_AbsoluteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_10MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_25MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_PercentageMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_1MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_10MI;
        private System.Windows.Forms.ToolStripMenuItem Browse_ReadHistoryMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_WriteMI;
        private Opc.Ua.Client.Controls.ConnectServerCtrl ConnectServerCTRL;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer TopPN;
        private System.Windows.Forms.TreeView BrowseNodesTV;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader DeadbandCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownPressureLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartReportBtn;
        private System.Windows.Forms.NumericUpDown numericUpDownTemperatureRight;
        private System.Windows.Forms.NumericUpDown numericUpDownTemperatureLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteLogBtn;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.SplitContainer MainPN;
        private System.Windows.Forms.ColumnHeader DisplayNameCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownPressureRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownVacuumDegreeRight;
        private System.Windows.Forms.NumericUpDown numericUpDownVacuumDegreeLeft;
    }
}
