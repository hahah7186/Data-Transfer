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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Quickstarts.DataAccessClient.Common;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Quickstarts.DataAccessClient
{
    /// <summary>
    /// The main form for a simple Data Access Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        private MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }

        /// <summary>
        /// 初始化Form
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
            //讀取XML配置文件
            ReadXmlnFill();

            ConnectServerCTRL.Configuration = m_configuration = configuration;
            ConnectServerCTRL.ServerUrl = (this.initialPlcUrl != "") ? this.initialPlcUrl : "opc.tcp://192.168.73.1:4840";
            //ConnectServerCTRL.ServerUrl = "opc.tcp://192.168.1.1:4840";
            this.Text = m_configuration.ApplicationName;

            // create the callback.
            m_MonitoredItem_Notification = new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
            //设置扫码类型的字典
            SetCodeTypeDict();

            LogHelper.WriteLog("程式啟動！");

            if (ReportStation()) {
                MessageBox.Show("開機報站成功！");
                LogHelper.WriteLog("開機報站成功");
            }
            //與服務器建立鏈接
            ConnectServerCTRL.Connect(this.initialPlcUrl,false);
        }

        private void SetCodeTypeDict()
        {
            this.codeTypeDic = new Dictionary<string, string>();

            this.codeTypeDic.Add("10", "Data matrix");
            this.codeTypeDic.Add("11", "QR code");
            this.codeTypeDic.Add("12", "VeriCode");
            this.codeTypeDic.Add("13", "PDF417");
            this.codeTypeDic.Add("14", "DotCode");
            this.codeTypeDic.Add("20", "Code 128");
            this.codeTypeDic.Add("21", "Code 92");
            this.codeTypeDic.Add("22", "Code 39");
            this.codeTypeDic.Add("23", "Code 39 with checksum");
            this.codeTypeDic.Add("24", "Interleaved 2 of 5");
            this.codeTypeDic.Add("25", "Interleaved 2 of 5 with checksum");
            this.codeTypeDic.Add("26", "Codebar");
            this.codeTypeDic.Add("27", "EAN 13");
            this.codeTypeDic.Add("28", "EAN 8");
        }

        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private bool m_connectedOnce;
        private Subscription m_subscription;
        private MonitoredItemNotificationEventHandler m_MonitoredItem_Notification;
        //checkbox，是否選擇向MES系統上傳
        private bool is_Post2MES = true;
        //數據實體，報站——上傳數據
        private DataEntity.Data_Starting_Up data_Starting_Up;
        //數據實體，報站——服務器反饋數據
        private DataEntity.Res_Data_Starting_Up res_Data_Starting_Up;
        //數據實體，清膠——上傳數據
        private DataEntity.Display_Clean_Glue display_Clean_Glue_Left;
        private DataEntity.Display_Clean_Glue display_Clean_Glue_Right;
        //數據實體，清膠——服務器反饋數據
        //預設刪除過期日誌期限，由XML配置文件中讀取
        private int deletedLogDays = 15;
        //溫控左——監控控件numericUpDownLeft
        private UInt16 leftTemperature = 200;
        //溫控右——監控控件numericUpDownRight
        private UInt16 rightTemperature = 200;
        //壓力左——監控控件numericUpDownPressure
        private UInt16 leftPressure = 350;
        //壓力右——監控控件numericUpDownPressure
        private UInt16 rightPressure = 350;
        //請求流水碼——流水碼 000001~999999 循環使用
        private int ReqSeqNo = 1;
        
        //设置左——开始时间的NodeId
        private string leftStartTimeNodeId = "";
        //设置左——结束时间的NodeId
        private string leftEndTimeNodeId = "";
        //设置左——扫码的NodeId
        private string leftBarcodeNodeId = "";
        //设置右——开始时间的NodeId
        private string rightStartTimeNodeId = "";
        //设置右——结束时间的NodeId
        private string rightEndTimeNodeId = "";
        //设置右——扫码的NodeId
        private string rightBarcodeNodeId = "";

        //初始的URL
        private string initialPlcUrl = "";

        //開始作料時間——左
        private DateTime startTimeLeft;
        //結束作料時間——左
        private DateTime endTimeLeft;

        //開始作料時間——右
        private DateTime startTimeRight;
        //結束作料時間——右
        private DateTime endTimeRight;

        //当前刀的位置——左的NodeId
        private string leftCurBladePosNodeId = "";
        //当前刀的位置——右的NodeId
        private string rightCurBladePosNodeId = "";

        //当前刀的位置——左
        private string curBladePosLeft = "";
        //当前刀的位置——右
        private string curBladePosRight = "";

        //產品編號——左NodeId
        private string leftPartNodeId = "";
        //產品編號——右NodeId
        private string rightPartNodeId = "";

        //產品編號——左NodeId
        private string partLeft = "";
        //產品編號——右NodeId
        private string partRight = "";

        private UInt16 leftVacuumDegree = 50;
        private UInt16 rightVacuumDegree = 50;
        //吸盤真空參數——左NodeId
        //private string leftRealmCauumNodeId = "";
        //吸盤真空參數——右NodeId
        //private string rightRealmCauumNodeId = "";

        //吸盤真空參數——左
        //private string realmCauumLeft = "";
        //吸盤真空參數——右
        //private string realmCauumRight = "";

        //厂区的名称
        private string shopfloorName;

        private Dictionary<string, string> codeTypeDic;
        #endregion

        #region Event Handlers
        /// <summary>
        /// Á¬½Óµ½PLC.
        /// </summary>
        private async void Server_ConnectMI_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await ConnectServerCTRL.Connect();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// ´Óµ±Ç°sessionÉÏ¶Ï¿ªÁ¬½Ó¡£
        /// </summary>
        private void Server_DisconnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Disconnect();
                m_subscription.Dispose();
                m_subscription = null;
                m_session = null;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Prompts the user to choose a server on another host.
        /// </summary>
        private void Server_DiscoverMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Discover(null);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the application after connecting to or disconnecting from the server.
        /// </summary>
        private void Server_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                if (m_session == null)
                {
                    MonitoredItemsLV.Items.Clear();
                    BrowseNodesTV.Nodes.Clear();
                    BrowseNodesTV.Enabled = false;
                    MonitoredItemsLV.Enabled = false;
                    return;
                }

                // set a suitable initial state.
                if (m_session != null && !m_connectedOnce)
                {
                    m_connectedOnce = true;
                }

                PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);

                BrowseNodesTV.Enabled = true;
                MonitoredItemsLV.Enabled = true;
                LogHelper.WriteLog("已與PLC建立鏈接。");
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }

            NodeId[] nodeIds = new NodeId[] {
                new NodeId(this.leftCurBladePosNodeId),
                new NodeId(this.leftBarcodeNodeId),
                new NodeId(this.leftStartTimeNodeId),
                new NodeId(this.leftEndTimeNodeId),
                new NodeId(this.leftPartNodeId),
                //new NodeId(this.leftRealmCauumNodeId),
                new NodeId(this.rightCurBladePosNodeId),
                new NodeId(this.rightBarcodeNodeId),
                new NodeId(this.rightStartTimeNodeId),
                new NodeId(this.rightEndTimeNodeId),
                new NodeId(this.rightPartNodeId),
                //new NodeId(this.rightRealmCauumNodeId)
            };

            foreach (NodeId nod in nodeIds) {
                InitialCreateMonitoredItem(nod);
            }

        }

        private void InitialCreateMonitoredItem(NodeId nodeId)
        {
            ListViewItem item = CreateMonitoredItem(nodeId, nodeId.ToString());

            if (item != null)
            {
                m_subscription.ApplyChanges();

                MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    item.SubItems[5].Text = monitoredItem.Status.Error.StatusCode.ToString();
                }
                MonitoredItemsLV.Columns[0].Width = -2;
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[5].Width = -2;
            }
            else
            {
                MessageBox.Show("节点：" + nodeId.ToString() + "建立失败，请查看MachineConfiguration.xml里面该节点配置是否正确。");
            }
        }

        /// <summary>
        /// Updates the application after a communicate error was detected.
        /// </summary>
        private void Server_ReconnectStarting(object sender, EventArgs e)
        {
            try
            {
                BrowseNodesTV.Enabled = false;
                MonitoredItemsLV.Enabled = false;
                //AttributesLV.Items.Clear();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the application after reconnecting to the server.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                foreach (Subscription subscription in m_session.Subscriptions)
                {
                    m_subscription = subscription;
                    break;
                }

                BrowseNodesTV.Enabled = true;
                MonitoredItemsLV.Enabled = true;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }

            LogHelper.WriteLog("重新與PLC建立鏈接。");
        }

        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectServerCTRL.Disconnect();
            LogHelper.WriteLog("程式關閉。");
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 讀取XML配置文件，寫入MachineConfiguration
        /// </summary>
        private void ReadXmlnFill()
        {
            //讀取XML配置文件
            //machineConfiguration = new MachineConfiguration();
            data_Starting_Up = new DataEntity.Data_Starting_Up();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@CommonConfig.XMLPATH);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略注釋
                XmlReader reader = XmlReader.Create(@CommonConfig.XMLPATH, settings);
                doc.Load(reader);

                XmlNode xr = doc.SelectSingleNode("MachineConfiguration");

                XmlNodeList xnl = xr.ChildNodes;
                XmlNode xn0 = xnl.Item(0);
                this.initialPlcUrl = xn0.InnerText;
                XmlNode xn1 = xnl.Item(1);
                this.data_Starting_Up.machine_id = xn1.InnerText;
                XmlNode xn2 = xnl.Item(2);
                this.data_Starting_Up.station_id = xn2.InnerText;
                XmlNode xn3 = xnl.Item(3);
                this.data_Starting_Up.ip = xn3.InnerText;
                XmlNode xn4 = xnl.Item(4);
                this.deletedLogDays = Convert.ToUInt16(xn4.InnerText);
                XmlNode xn5 = xnl.Item(5);
                this.leftStartTimeNodeId = xn5.InnerText;
                XmlNode xn6 = xnl.Item(6);
                this.leftEndTimeNodeId = xn6.InnerText;
                XmlNode xn7 = xnl.Item(7);
                this.leftBarcodeNodeId = xn7.InnerText;
                XmlNode xn8 = xnl.Item(8);
                this.leftCurBladePosNodeId = xn8.InnerText;
                XmlNode xn9 = xnl.Item(9);
                this.rightStartTimeNodeId = xn9.InnerText;
                XmlNode xn10 = xnl.Item(10);
                this.rightEndTimeNodeId = xn10.InnerText;
                XmlNode xn11 = xnl.Item(11);
                this.rightBarcodeNodeId = xn11.InnerText;
                XmlNode xn12 = xnl.Item(12);
                this.rightCurBladePosNodeId = xn12.InnerText;
                XmlNode xn13 = xnl.Item(13);
                this.leftPartNodeId = xn13.InnerText;
                XmlNode xn14 = xnl.Item(14);
                this.rightPartNodeId = xn14.InnerText;
                //XmlNode xn15 = xnl.Item(15);
                //this.leftRealmCauumNodeId = xn15.InnerText;
                //XmlNode xn16 = xnl.Item(16);
                //this.rightRealmCauumNodeId = xn16.InnerText;
                XmlNode xn15 = xnl.Item(15);
                this.shopfloorName = xn15.InnerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(CommonConfig.TEXT_READ_XML_FAILURE);
                LogHelper.WriteLog(CommonConfig.TEXT_READ_XML_FAILURE, ex);
                return;
            }
        }

        /// <summary>
        /// 刪除過期日誌，傳入參數為過期時間
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        private void DeleteExpiredLogs(int days)
        {
            //string currentRuningPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //string logPath = /*currentRuningPath +*/ "Log\\LogInfo\\";
            string logPath = CommonConfig.LOGPATH;

            DirectoryInfo di = new DirectoryInfo(@logPath);
            FileInfo[] fi = di.GetFiles("*.log");

            List<FileInfo> deletedFilesList = new List<FileInfo>();

            if (fi.Length > 0)
            {//如果目錄下有日誌文件
                DateTime dtNow = DateTime.Now;
                StringBuilder deleteExpiredLogName = new StringBuilder("");
                foreach (FileInfo tmpfi in fi)
                {
                    //對比最後修改時間和當前時間
                    TimeSpan ts = dtNow.Subtract(tmpfi.LastWriteTime);
                    if (ts.Days > days)//如果日期多餘設定日期
                    {
                        deletedFilesList.Add(tmpfi);
                        deleteExpiredLogName.Append(tmpfi.Name + "；");
                    }
                }
                if (deletedFilesList.Count > 0)
                {
                    if (MessageBox.Show("日誌刪除不可恢復，是否確認刪除以下日誌文件？" + deleteExpiredLogName.ToString() + "?", "確定", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (FileInfo deletedFile in deletedFilesList)
                            deletedFile.Delete();
                        LogHelper.WriteLog("已刪除如下日誌文件：\r\n" + deleteExpiredLogName);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("目錄中未查到過期日誌！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("日誌目錄下文件為空！");
                return;
            }
        }

        /// <summary>
        /// 查看過期時間是否過期，小於等于零——未過期，大於零——未過期
        /// </summary>
        /// <param name="expired_date">e.g."2020-08-17 18:22:53"</param>
        private int CheckExpiredDate(string expired_date) {
            DateTime dt = DateTime.Parse(expired_date);
            return dt.CompareTo(DateTime.Now);
        }

        /// <summary>
        /// Populates the branch in the tree view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        /// <param name="nodes">The node collect to populate.</param>
        private void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            try
            {
                nodes.Clear();

                // find all of the components of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;
                
                // find all nodes organized by the node.
                BrowseDescription nodeToBrowse2 = new BrowseDescription();

                nodeToBrowse2.NodeId = sourceId;
                nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
                nodeToBrowse2.IncludeSubtypes = true;
                nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);
                nodesToBrowse.Add(nodeToBrowse2);

                // fetch references from the server.
                ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);
                
                // process results.
                for (int ii = 0; ii < references.Count; ii++)
                {
                    ReferenceDescription target = references[ii];

                    // add node.
                    TreeNode child = new TreeNode(Utils.Format("{0}", target));
                    
                    child.Tag = target;
                    child.Nodes.Add(new TreeNode());
                    nodes.Add(child);
                }

                // update the attributes display.
                DisplayAttributes(sourceId);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Displays the attributes and properties in the attributes view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        private void DisplayAttributes(NodeId sourceId)
        {
            try
            {
                //AttributesLV.Items.Clear();

                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

                // attempt to read all possible attributes.
                for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = sourceId;
                    nodeToRead.AttributeId = ii;
                    nodesToRead.Add(nodeToRead);
                }

                int startOfProperties = nodesToRead.Count;

                // find all of the pror of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = 0;
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);

                // fetch property references from the server.
                ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);

                if (references == null)
                {
                    return;
                }

                for (int ii = 0; ii < references.Count; ii++)
                {
                    // ignore external references.
                    if (references[ii].NodeId.IsAbsolute)
                    {
                        continue;
                    }

                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                    nodeToRead.AttributeId = Attributes.Value;
                    nodesToRead.Add(nodeToRead);
                }

                // read all values.
                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.Read(
                    null,
                    0,
                    TimestampsToReturn.Neither,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                // process results.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    string name = null;
                    string datatype = null;
                    string value = null;

                    // process attribute value.
                    if (ii < startOfProperties)
                    {
                        // ignore attributes which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue;
                        }

                        // get the name of the attribute.
                        name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // process property value.
                    else
                    {
                        // ignore properties which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                        {
                            continue;
                        }

                        // get the name of the property.
                        name = Utils.Format("{0}", references[ii-startOfProperties]);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = String.Empty;
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // add the attribute name/value to the list view.
                    //ListViewItem item = new ListViewItem(name);
                    //item.SubItems.Add(datatype);
                    //item.SubItems.Add(value);
                    //AttributesLV.Items.Add(item);
                }

                // adjust width of all columns.
                //for (int ii = 0; ii < AttributesLV.Columns.Count; ii++)
                //{
                //    AttributesLV.Columns[ii].Width = -2;
                //}
                //Console.WriteLine(AttributesLV.Items.ToString());
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Converts a monitoring filter to text for display.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The deadback formatted as a string.</returns>
        private string DeadbandFilterToText(MonitoringFilter filter)
        {
            DataChangeFilter datachangeFilter = filter as DataChangeFilter;

            if (datachangeFilter != null)
            {
                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Absolute)
                {
                    return Utils.Format("{0:##.##}", datachangeFilter.DeadbandValue);
                }

                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Percent)
                {
                    return Utils.Format("{0:##.##}%", datachangeFilter.DeadbandValue);
                }
            }

            return "None";
        }

        private bool ReportStation()
        {
            string Report_Json = JsonConvert.SerializeObject(data_Starting_Up);
            Report_Json = String.Format("data={0}&version={1}", Report_Json, "1.0");

            string strHttpResult = "";
            try
            {
                LogHelper.WriteLog("開始報站，參數如下：\r\n" + Report_Json);

                string reportStationUrl = "";

                switch (shopfloorName)
                {
                    case "GL":
                        reportStationUrl = HttpUrls.GL_URL_STARTING_UP;
                        break;
                    case "LH":
                        reportStationUrl = HttpUrls.LH_URL_STARTING_UP;
                        break;
                    case "ZZK":
                        reportStationUrl = HttpUrls.ZZK_URL_STARTING_UP;
                        break;
                    case "ZZC":
                        reportStationUrl = HttpUrls.ZZC_URL_STARTING_UP;
                        break;
                    default:
                        reportStationUrl = HttpUrls.GL_URL_STARTING_UP;
                        break;
                }

                //開始報站，傳入參數
                strHttpResult = HttpUitls.Post(Report_Json, reportStationUrl);
                //獲得服務器反饋值，並且記錄日誌
                LogHelper.WriteLog("報站，服務器反饋參數如下:\r\n" + HttpUitls.ConvertJsonString(strHttpResult));
            }
            catch (Exception ex)
            {
                //連接服務器失敗，記錄日誌，並頁面提示
                LogHelper.WriteLog("報站失敗，原因如下：\r\n" + ex.Message, ex);
                MessageBox.Show("報站失敗，詳細錯誤請查看日誌！");
                return false;
            }
            try
            {
                //this.res_Data_Starting_Up = (DataEntity.Res_Data_Starting_Up)JsonConvert.DeserializeObject(strHttpResult);

                res_Data_Starting_Up = JsonConvert.DeserializeObject<DataEntity.Res_Data_Starting_Up>(strHttpResult);

                display_Clean_Glue_Left.token = res_Data_Starting_Up.token;
                display_Clean_Glue_Right.token = res_Data_Starting_Up.token;

                display_Clean_Glue_Left.machineinfo = new DataEntity.Machineinfo()
                {
                    host_ip = res_Data_Starting_Up.ip,
                    machine_id = res_Data_Starting_Up.station_id,
                    control_machine_id = res_Data_Starting_Up.host_id,
                    module_id = res_Data_Starting_Up.station_id,
                    equipment_type = "Guide_Blade",
                    location = res_Data_Starting_Up.floor_no,
                    line = res_Data_Starting_Up.line_name
                };
                display_Clean_Glue_Right.machineinfo = new DataEntity.Machineinfo()
                {
                    host_ip = res_Data_Starting_Up.ip,
                    machine_id = res_Data_Starting_Up.station_id,
                    control_machine_id = res_Data_Starting_Up.host_id,
                    module_id = res_Data_Starting_Up.station_id,
                    equipment_type = "Guide_Blade",
                    location = res_Data_Starting_Up.floor_no,
                    line = res_Data_Starting_Up.line_name
                };

                ChangeSystemTime(res_Data_Starting_Up.expiry_date);
            }
            catch (Exception ex)
            {
                //服務器反饋值解析Object失敗，記錄日誌，並頁面提示
                LogHelper.WriteLog("解析SFC服務器反饋參數失敗！\r\n服务器反馈参数如下:\r\n" + strHttpResult + "报错信息如下：\r\n" + ex.Message, ex);
                MessageBox.Show("解析SFC服務器反饋參數失敗！請與服務器管理員溝通！");
                return false;
            }
            //每次报站，先检查
            DeleteExpiredLogsWithoutMessage((this.deletedLogDays > 0) ? this.deletedLogDays : 15);

            //提示報站成功
            //MessageBox.Show("報站成功！");
            return true;
        }

        private void DeleteExpiredLogsWithoutMessage(int days)
        {
            string logPath = CommonConfig.LOGPATH;

            DirectoryInfo di = new DirectoryInfo(@logPath);
            FileInfo[] fi = di.GetFiles("*.log");

            if (fi.Length > 0)
            {//如果目錄下有日誌文件
                DateTime dtNow = DateTime.Now;
                StringBuilder deleteExpiredLogName = new StringBuilder("");
                foreach (FileInfo tmpfi in fi)
                {
                    //對比最後修改時間和當前時間
                    TimeSpan ts = dtNow.Subtract(tmpfi.LastWriteTime);
                    if (ts.Days > days)//如果日期多餘設定日期
                    {
                        tmpfi.Delete();
                    }
                }
            }
        }

        private void ChangeSystemTime(string timeStr)
        {
            //根據服務器反饋時間，修改當前時間和日期
            string strCurTime = timeStr;
            DateTime dt = DateTime.Parse(strCurTime);
            dt = dt.AddHours(-4);
            bool result = SyncServerTime.SetDate(dt);
            if (result)
            {
                MessageBox.Show("修改系統時間成功！");
            }
            else {
                MessageBox.Show("修改系統時間失敗！");
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the Click event of the Help_ContentsMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Help_ContentsMI_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start( Path.GetDirectoryName(Application.ExecutablePath) + "\\WebHelp\\daclientoverview.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("不能讀取幫助文檔: \r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Fetches the children for a node the first time the node is expanded in the tree view.
        /// </summary>
        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != String.Empty)
                {
                    return;
                }

                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the display after a node is selected.
        /// </summary>
        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Ensures the correct node is selected before displaying the context menu.
        /// </summary>
        private void BrowseNodesTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                BrowseNodesTV.SelectedNode = BrowseNodesTV.GetNodeAt(e.X, e.Y);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        
        /// <summary>
        /// Handles the Click event of the Browse_MonitorMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Browse_MonitorMI_Click(object sender, EventArgs e)
        {
            try
            {  
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                ListViewItem item = CreateMonitoredItem((NodeId)reference.NodeId, Utils.Format("{0}", reference));
                if (item != null)
                {
                    m_subscription.ApplyChanges();

                    MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

                    if (ServiceResult.IsBad(monitoredItem.Status.Error))
                    {
                        item.SubItems[5].Text = monitoredItem.Status.Error.StatusCode.ToString();
                    }

                    //item.SubItems.Add(monitoredItem.DisplayName);
                    //1
                    //item.SubItems[1].Text = monitoredItem.MonitoringMode.ToString();
                    //2
                    //item.SubItems[2].Text = monitoredItem.SamplingInterval.ToString();
                    //3
                    //item.SubItems[3].Text = DeadbandFilterToText(monitoredItem.Filter);

                    MonitoredItemsLV.Columns[0].Width = -2;
                    MonitoredItemsLV.Columns[1].Width = -2;
                    MonitoredItemsLV.Columns[5].Width = -2;
                }
                else {
                    return;
                }

            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Creates the monitored item.
        /// </summary>
        private ListViewItem CreateMonitoredItem(NodeId nodeId, string displayName)
        {
            //if (this.res_Data_Starting_Up.station_id == null) {
            //    MessageBox.Show("尚未報站，請先報站！");
            //    return null;
            //}
            
            if (m_subscription == null)
            {
                m_subscription = new Subscription(m_session.DefaultSubscription);

                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 1000;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 10;
                m_subscription.MaxNotificationsPerPublish = 1000;
                m_subscription.Priority = 100;

                m_session.AddSubscription(m_subscription);

                m_subscription.Create();
            }

            // add the new monitored item.
            MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);

            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            monitoredItem.SamplingInterval = 1000;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = true;

            monitoredItem.Notification += m_MonitoredItem_Notification;

            m_subscription.AddItem(monitoredItem);

            // add the attribute name/value to the list view.
            ListViewItem item = new ListViewItem(monitoredItem.ClientHandle.ToString());
            monitoredItem.Handle = item;
            //0
            item.SubItems.Add(monitoredItem.StartNodeId.ToString());
            //1
            //item.SubItems.Add(monitoredItem.MonitoringMode.ToString());
            //2
            //item.SubItems.Add(monitoredItem.SamplingInterval.ToString());
            //3
            //item.SubItems.Add(DeadbandFilterToText(monitoredItem.Filter));
            //4
            item.SubItems.Add(String.Empty);
            //5
            item.SubItems.Add(String.Empty);
            //6
            item.SubItems.Add(String.Empty);
            //7
            item.SubItems.Add(String.Empty);

            item.Tag = monitoredItem;
            MonitoredItemsLV.Items.Add(item);
            item.SubItems[5].Text = monitoredItem.DisplayName;
            //if (ServiceResult.IsBad(monitoredItem.Status.Error))
            //{
            //    item.SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
            //}

            return item;
        }

        /// <summary>
        /// Prompts the use to write the value of a varible.
        /// </summary>
        private void Browse_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                new WriteValueDlg().ShowDialog(m_session, (NodeId)reference.NodeId, Attributes.Value);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        
        /// <summary>
        /// Handles the Click event of the Browse_ReadHistoryMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Browse_ReadHistoryMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                new ReadHistoryDlg().ShowDialog(m_session, (NodeId)reference.NodeId);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the display with a new value for a monitored variable. 
        /// </summary>
        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                return;
            }

            try
            {
                if (m_session == null)
                {
                    return;
                }

                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                if (notification == null)
                {
                    return;
                }

                ListViewItem item = (ListViewItem)monitoredItem.Handle;
                //LogHelper.WriteLog(monitoredItem.DisplayName + "：" + monitoredItem.StartNodeId);
                //獲取PLC端數據改變的通知，然後顯示在屏幕上
                //5
                item.SubItems[2].Text = Utils.Format("{0}", notification.Value.WrappedValue);
                //6
                item.SubItems[3].Text = Utils.Format("{0}", notification.Value.StatusCode);
                //7
                item.SubItems[4].Text = Utils.Format("{0:HH:mm:ss.fff}", notification.Value.SourceTimestamp.ToLocalTime());

                //監控NodeId,不同的Id進入對應不同的邏輯處理
                if (monitoredItem.StartNodeId.ToString() == this.leftBarcodeNodeId)
                {
                    string codeNType = notification.Value.WrappedValue.ToString();
                    string subBarcode = "";
                    string subType = "";
                    string subCodeType = "";
                    if (codeNType.Length > 0)
                    {
                        subBarcode = codeNType;
                        subType = codeNType.Substring(codeNType.Length - 2);
                        try
                        {
                            subCodeType = this.codeTypeDic[subType];
                        }
                        catch (Exception)
                        {

                            subCodeType = "DISPLAY";
                        }
                    }
                    else {
                        subCodeType = "DISPLAY";
                    }
                    
                    this.display_Clean_Glue_Left.productinfo = new DataEntity.Productinfo() {
                        barcode = subBarcode == ""? "G9P0324JFMCLQHKA1+A1110" : subBarcode,
                        code_type = "DISPLAY"/*subCodeType*/,
                        process_type = "Assembly",
                        station_id = this.res_Data_Starting_Up.wrkst_name
                    };
                }
                else if (monitoredItem.StartNodeId.ToString() == this.rightBarcodeNodeId) {
                    string codeNType = notification.Value.WrappedValue.ToString();
                    string subBarcode = "";
                    string subType = "";
                    string subCodeType = "";
                    if (codeNType.Length > 0)
                    {
                        subBarcode = codeNType;
                        subType = codeNType.Substring(codeNType.Length - 2);
                        try
                        {
                            subCodeType = this.codeTypeDic[subType];
                        }
                        catch (Exception)
                        {

                            subCodeType = "DISPLAY";
                        }
                    }
                    else
                    {
                        subCodeType = "DISPLAY";
                    }

                    this.display_Clean_Glue_Right.productinfo = new DataEntity.Productinfo()
                    {
                        barcode = subBarcode == "" ? "G9P0324JFMCLQHKA1+A1110" : subBarcode,
                        code_type = "DISPLAY"/*subCodeType*/,
                        process_type = "Assembly",
                        station_id = this.res_Data_Starting_Up.wrkst_name
                    };
                }
                else if (monitoredItem.StartNodeId.ToString() == this.leftStartTimeNodeId)
                {
                    //this.display_Clean_Glue_Left.productinfo.barcode = "";
                    string strStartTime = notification.Value.WrappedValue.ToString();

                    startTimeLeft = DateTime.Parse(strStartTime);
                }
                else if (monitoredItem.StartNodeId.ToString() == this.rightStartTimeNodeId)
                {
                    //this.display_Clean_Glue_Right.productinfo.barcode = "";
                    string strStartTime = notification.Value.WrappedValue.ToString();

                    startTimeRight = DateTime.Parse(strStartTime);
                }
                else if (monitoredItem.StartNodeId.ToString() == this.leftCurBladePosNodeId)
                {
                    curBladePosLeft = notification.Value.WrappedValue.ToString();
                }
                else if (monitoredItem.StartNodeId.ToString() == this.rightCurBladePosNodeId)
                {
                    curBladePosRight = notification.Value.WrappedValue.ToString();
                }
                else if (monitoredItem.StartNodeId.ToString() == this.leftPartNodeId)
                {
                    partLeft = notification.Value.WrappedValue.ToString();
                }
                else if (monitoredItem.StartNodeId.ToString() == this.rightPartNodeId)
                {
                    partRight = notification.Value.WrappedValue.ToString();
                }
                //else if (monitoredItem.StartNodeId.ToString() == this.leftRealmCauumNodeId)
                //{
                //    realmCauumLeft = notification.Value.WrappedValue.ToString();
                //}
                //else if (monitoredItem.StartNodeId.ToString() == this.rightRealmCauumNodeId)
                //{
                //    realmCauumRight = notification.Value.WrappedValue.ToString();
                //}
                else if (monitoredItem.StartNodeId.ToString() == this.leftEndTimeNodeId)
                {
                    string strEndTime = notification.Value.WrappedValue.ToString();

                    endTimeLeft = DateTime.Parse(strEndTime);
                    //this.display_Clean_Glue.recipeinfo.end_time = endTime.ToString("yyyymmddhhmmss");
                    if (endTimeLeft > startTimeLeft && this.is_Post2MES /*&& (this.display_Clean_Glue.productinfo.barcode!="")*/) { //作料時間校驗
                        //準備發送數據，需要先檢驗token，若token已經過期，則重新報站
                        if (CheckExpiredDate(this.res_Data_Starting_Up.expiry_date) <= 0) { //過期
                            ReportStation();
                        }
                        //如果選中“是否向SFC系統上傳”,則執行以下上傳邏輯
                        DataEntity.Parainfo prod_data1 = new DataEntity.Parainfo()
                        {
                            item_name = "Temperature",
                            item_val = this.leftTemperature.ToString()
                        };

                        DataEntity.Parainfo prod_data2 = new DataEntity.Parainfo()
                        {
                            item_name = "Pressure",
                            item_val = this.leftPressure.ToString()
                        };

                        DataEntity.Parainfo prod_data3 = new DataEntity.Parainfo()
                        {
                            item_name = "Blade_Position_#",
                            item_val = this.curBladePosLeft.ToString()
                        };

                        DataEntity.Parainfo prod_data4 = new DataEntity.Parainfo()
                        {
                            item_name = "Part_#",
                            item_val = this.partLeft.ToString()
                        };

                        DataEntity.Parainfo prod_data5 = new DataEntity.Parainfo()
                        {
                            item_name = "Vacuum_Degree",
                            //item_val = this.realmCauumLeft.ToString()
                            item_val = this.leftVacuumDegree.ToString()
                        };

                        DataEntity.Parainfo[] prod_data = new DataEntity.Parainfo[] { prod_data1, prod_data2, prod_data3, prod_data4, prod_data5 };

                        this.display_Clean_Glue_Left.recipeinfo = new DataEntity.Recipeinfo() {
                            start_time = startTimeLeft.ToString("yyyyMMddHHmmss"),
                            end_time = endTimeLeft.ToString("yyyyMMddHHmmss"),
                            fixture_id = "",
                            cavity = "A",
                            parainfo = prod_data,
                        };

                        this.display_Clean_Glue_Left.request_id = res_Data_Starting_Up.ip.Replace(".", "")
                            + DateTime.Now.ToString("yyyyMMddhhmmssfff")
                            + FullFillInteger(ReqSeqNo).ToString();
                        //每次用完重新置位
                        if (ReqSeqNo >= 999999)
                        {
                            ReqSeqNo = 1;
                        }
                        else {
                            ReqSeqNo = ReqSeqNo + 1;
                        }

                        //打包上傳清膠參數到SFC服務器
                        string strJson2Server = JsonConvert.SerializeObject(display_Clean_Glue_Left);
                        strJson2Server = String.Format("data={0}&version={1}", strJson2Server, "1.0");
                        //string strJson2Server = PakageDataPassStationReportJson(notification);
                        //記錄日誌信息
                        LogHelper.WriteLog("上傳SFC服務器清膠參數：\r\n" + strJson2Server);
                        //設置服務器返回json字符串
                        string strHttpResult = "";
                        try
                        {
                            string datauploadDisplayCleanGlueUrl = "";
                            switch (shopfloorName)
                            {
                                case "GL":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "LH":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.LH_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "ZZK":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.ZZK_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "ZZC":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.ZZC_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                default:
                                    datauploadDisplayCleanGlueUrl = HttpUrls.GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                            }
                            //調用HTTP協議上傳json,等待服務器反饋json
                            strHttpResult = HttpUitls.Post(strJson2Server, datauploadDisplayCleanGlueUrl);
                            //等待服務器反饋數據，然後記錄日誌
                            LogHelper.WriteLog("SFC服務器反饋清膠參數：\r\n" + HttpUitls.ConvertJsonString(strHttpResult));
                        }
                        catch (Exception ex)
                        {
                            //上傳數據異常，記錄日誌
                            LogHelper.WriteLog("上傳SFC清膠參數異常，清檢查網路連接：\r\n" + ex.Message);
                        }
                    }
                }
                else if (monitoredItem.StartNodeId.ToString() == this.rightEndTimeNodeId)
                {
                    string strEndTime = notification.Value.WrappedValue.ToString();

                    endTimeRight = DateTime.Parse(strEndTime);
                    //this.display_Clean_Glue.recipeinfo.end_time = endTime.ToString("yyyymmddhhmmss");
                    if (endTimeRight > startTimeRight && this.is_Post2MES /*&& (this.display_Clean_Glue.productinfo.barcode!="")*/)
                    { //作料時間校驗
                        //準備發送數據，需要先檢驗token，若token已經過期，則重新報站
                        if (CheckExpiredDate(this.res_Data_Starting_Up.expiry_date) <= 0)
                        { //過期
                            ReportStation();
                        }
                        //如果選中“是否向SFC系統上傳”,則執行以下上傳邏輯
                        DataEntity.Parainfo prod_data1 = new DataEntity.Parainfo()
                        {
                            item_name = "Temperature",
                            item_val = this.rightTemperature.ToString()
                        };
                        DataEntity.Parainfo prod_data2 = new DataEntity.Parainfo()
                        {
                            item_name = "Pressure",
                            item_val = this.rightPressure.ToString()
                        };
                        DataEntity.Parainfo prod_data3 = new DataEntity.Parainfo()
                        {
                            item_name = "Blade_Position_#",
                            item_val = this.curBladePosRight.ToString()
                        };
                        DataEntity.Parainfo prod_data4 = new DataEntity.Parainfo()
                        {
                            item_name = "Part_#",
                            item_val = this.partRight.ToString()
                        };
                        DataEntity.Parainfo prod_data5 = new DataEntity.Parainfo()
                        {
                            item_name = "Vacuum_Degree",
                            //item_val = this.realmCauumRight.ToString()
                            item_val = this.rightVacuumDegree.ToString()
                        };

                        DataEntity.Parainfo[] prod_data = new DataEntity.Parainfo[] { prod_data1, prod_data2, prod_data3, prod_data4, prod_data5 };

                        this.display_Clean_Glue_Right.recipeinfo = new DataEntity.Recipeinfo()
                        {
                            start_time = startTimeRight.ToString("yyyyMMddHHmmss"),
                            end_time = endTimeRight.ToString("yyyyMMddHHmmss"),
                            fixture_id = "",
                            cavity = "B",
                            parainfo = prod_data,
                        };

                        this.display_Clean_Glue_Right.request_id = res_Data_Starting_Up.ip.Replace(".", "")
                            + DateTime.Now.ToString("yyyyMMddhhmmssfff")
                            + FullFillInteger(ReqSeqNo).ToString();
                        //每次用完重新置位
                        if (ReqSeqNo == 999999)
                        {
                            ReqSeqNo = 1;
                        }
                        else
                        {
                            ReqSeqNo = ReqSeqNo + 1;
                        }

                        //打包上傳清膠參數到SFC服務器
                        string strJson2Server = JsonConvert.SerializeObject(display_Clean_Glue_Right);
                        strJson2Server = String.Format("data={0}&version={1}", strJson2Server, "1.0");
                        //string strJson2Server = PakageDataPassStationReportJson(notification);
                        //記錄日誌信息
                        LogHelper.WriteLog("上傳SFC服務器清膠參數：\r\n" + strJson2Server);
                        //設置服務器返回json字符串
                        string strHttpResult = "";
                        try
                        {
                            string datauploadDisplayCleanGlueUrl = "";
                            switch (shopfloorName)
                            {
                                case "GL":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "LH":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.LH_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "ZZK":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.ZZK_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                case "ZZC":
                                    datauploadDisplayCleanGlueUrl = HttpUrls.ZZC_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                                default:
                                    datauploadDisplayCleanGlueUrl = HttpUrls.GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE;
                                    break;
                            }
                            //調用HTTP協議上傳json,等待服務器反饋json
                            strHttpResult = HttpUitls.Post(strJson2Server, HttpUrls.GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE);
                            //等待服務器反饋數據，然後記錄日誌
                            LogHelper.WriteLog("SFC服務器反饋清膠參數：\r\n" + HttpUitls.ConvertJsonString(strHttpResult));
                        }
                        catch (Exception ex)
                        {
                            //上傳數據異常，記錄日誌
                            LogHelper.WriteLog("上傳SFC清膠參數異常，清檢查網路連接：\r\n" + ex.Message);
                        }
                    }
                }
                else {

                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// 打包清溢膠JSON參數
        /// </summary>
        private string PakageDataPassStationReportJson(MonitoredItemNotification notification)
        {
            //Random rnd = new Random();

            //DataEntity.Data_Pass_Station_Report data_Pass_Station_Report = new DataEntity.Data_Pass_Station_Report();
            //DataEntity.Bind_Code bind_Code = new DataEntity.Bind_Code();
            //bind_Code.code_sn = "A" + rnd.Next(100, 1000);
            //bind_Code.code_type = "FIXTURE";
            //bind_Code.replace = "2";
            //bind_Code.trans = "N";
            //List<DataEntity.Bind_Code> bind_Code_list = new List<DataEntity.Bind_Code>();
            //bind_Code_list.Add(bind_Code);

            //data_Pass_Station_Report.bill_no = rnd.Next(10000, 100000).ToString();
            //data_Pass_Station_Report.bind_code_list = bind_Code_list;
            //data_Pass_Station_Report.config = "";
            //data_Pass_Station_Report.controller_id = "Hans005";
            //data_Pass_Station_Report.floor_id = "C08-3F";
            //data_Pass_Station_Report.host_id = "hans007";
            //data_Pass_Station_Report.host_ip = "10.197.102.106";
            //data_Pass_Station_Report.line_id = "L2";
            //data_Pass_Station_Report.machine_id = "Hans005";
            //data_Pass_Station_Report.part = "";
            //data_Pass_Station_Report.phase = "";
            //data_Pass_Station_Report.process_id = rnd.Next(100000000, 1000000000).ToString();
            //data_Pass_Station_Report.prod_code = "DR8805600CZMNBCA401";
            //data_Pass_Station_Report.prod_type = "FRAME";
            //data_Pass_Station_Report.product = "701";
            //data_Pass_Station_Report.request_id = "1017358157201805151020433031";
            //data_Pass_Station_Report.side_id = "GL";
            //data_Pass_Station_Report.end_time = "20180515102133";
            //data_Pass_Station_Report.start_time = "20180515102033";
            //data_Pass_Station_Report.token = "84876f2e45e9";
            //data_Pass_Station_Report.wip_type = "wipin";
            //data_Pass_Station_Report.wo_no = "";
            //data_Pass_Station_Report.work_start_time = "20180515102033";
            //data_Pass_Station_Report.work_end_time = "20180515102133";
            //data_Pass_Station_Report.work_qis = notification.Value.WrappedValue.ToString();
            //data_Pass_Station_Report.work_trans = "deal";
            //data_Pass_Station_Report.wrkst_name = "FrameDispense";
            //data_Pass_Station_Report.wrkst_type = "fullcheck";
            //return JsonConvert.SerializeObject(data_Pass_Station_Report);
            return "";
        }

        private string FullFillInteger(int num) {

            string strVal = "";

            if (num > 0 && num < 10)
            {
                strVal = "00000" + num.ToString();
            }
            else if (num >= 10 && num < 100)
            {
                strVal = "0000" + num.ToString();
            }
            else if (num >= 100 && num < 1000)
            {
                strVal = "000" + num.ToString();
            }
            else if (num >= 1000 && num < 10000)
            {
                strVal = "00" + num.ToString();
            }
            else if (num >= 10000 && num < 100000)
            {
                strVal = "0" + num.ToString();
            }
            else if (num >= 100000 && num < 1000000)
            {
                strVal = num.ToString();
            }
            else {
                strVal = "000001";
            }
            return strVal;
        }

        /// <summary>
        /// Changes the monitoring mode for the currently selected monitored items.
        /// </summary>
        private void Monitoring_MonitoringMode_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the monitoring mode being requested.
                MonitoringMode monitoringMode = MonitoringMode.Disabled;

                if (sender == Monitoring_MonitoringMode_ReportingMI)
                {
                    monitoringMode = MonitoringMode.Reporting;
                }

                if (sender == Monitoring_MonitoringMode_SamplingMI)
                {
                    monitoringMode = MonitoringMode.Sampling;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.SetMonitoringMode(monitoringMode, itemsToChange);

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[5].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[5].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        //item.SubItems[2].Text = itemsToChange[ii].Status.MonitoringMode.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Changes the sampling interval for the currently selected monitored items.
        /// </summary>
        private void Monitoring_SamplingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the sampling interval being requested.
                double samplingInterval = 0;

                if (sender == Monitoring_SamplingInterval_1000MI)
                {
                    samplingInterval = 1000;
                }
                else if (sender == Monitoring_SamplingInterval_2500MI)
                {
                    samplingInterval = 2500;
                }
                else if (sender == Monitoring_SamplingInterval_5000MI)
                {
                    samplingInterval = 5000;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.SamplingInterval = (int)samplingInterval;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[5].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[5].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        //item.SubItems[3].Text = itemsToChange[ii].Status.SamplingInterval.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Changes the deadband for the currently selected monitored items.
        /// </summary>
        private void Monitoring_Deadband_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the filter being requested.
                DataChangeFilter filter = new DataChangeFilter();
                filter.Trigger = DataChangeTrigger.StatusValue;

                if (sender == Monitoring_Deadband_Absolute_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 10.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_25MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 25.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_1MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 1.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 10.0;
                }
                else
                {
                    filter = null;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Filter = filter;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[5].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            itemsToChange[ii].Filter = null;
                            item.SubItems[5].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        //item.SubItems[4].Text = DeadbandFilterToText(itemsToChange[ii].Status.Filter);
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Handles the Click event of the Monitoring_DeleteMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Monitoring_DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // collect the items to delete.
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Notification -= m_MonitoredItem_Notification;
                        itemsToDelete.Add(MonitoredItemsLV.SelectedItems[ii]);

                        if (m_subscription != null)
                        {
                            m_subscription.RemoveItem(monitoredItem);
                        }
                    }
                }

                // update the server.
                if (m_subscription != null)
                {
                    m_subscription.ApplyChanges();

                    // check the status.
                    for (int ii = 0; ii < itemsToDelete.Count; ii++)
                    {
                        MonitoredItem monitoredItem = itemsToDelete[ii].Tag as MonitoredItem;

                        if (ServiceResult.IsBad(monitoredItem.Status.Error))
                        {
                            itemsToDelete[ii].SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
                            continue;
                        }
                    }
                }

                // remove the items.
                for (int ii = 0; ii < itemsToDelete.Count; ii++)
                {
                    itemsToDelete[ii].Remove();
                }

                MonitoredItemsLV.Columns[0].Width = -2;
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[5].Width = -2;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void BrowsingMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Browse_MonitorMI.Enabled = true;
            Browse_ReadHistoryMI.Enabled = true;
            Browse_WriteMI.Enabled = true;

            if (m_session == null || BrowseNodesTV.SelectedNode == null)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }

            ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

            if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }
        }

        private void Monitoring_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[0].Tag as MonitoredItem;

                if (monitoredItem != null)
                {
                    new WriteValueDlg().ShowDialog(m_session, (NodeId)monitoredItem.ResolvedNodeId, Attributes.Value);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Creates monitored items from a saved list of node ids.
        /// </summary>
        private void File_LoadMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Saves the current monitored items.
        /// </summary>
        private void File_SaveMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Sets the locale to use.
        /// </summary>
        private void Server_SetLocaleMI_Click(object sender, EventArgs e)
        {

            try
            {
                if (m_session == null)
                {
                    return;
                }

                string locale = new SelectLocaleDlg().ShowDialog(m_session);

                if (locale == null)
                {
                    return;
                }

                ConnectServerCTRL.PreferredLocales = new string[] { locale };
                m_session.ChangePreferredLocales(new StringCollection(ConnectServerCTRL.PreferredLocales));
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void Server_SetUserMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit the application?", "UA Sample Client", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DeleteLogBtn_Click(object sender, EventArgs e)
        {
            //調用刪除過期日誌方法
            DeleteExpiredLogs((this.deletedLogDays > 0) ? this.deletedLogDays : 15);
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true) this.is_Post2MES = true;
            else this.is_Post2MES = false;
        }
        private void StartReportBtn_Click(object sender, EventArgs e)
        {
            //調用報站方法
            bool reportResult = this.ReportStation();
            if (reportResult)
            {
                MessageBox.Show("報站成功！");
            }
        }        
        //左溫控更改事件
        private void NumericUpDownTemperatureLeft_ValueChanged(object sender, EventArgs e)
        {
            this.leftTemperature = Convert.ToUInt16(numericUpDownTemperatureLeft.Value);
        }

        //右溫控更改事件
        private void NumericUpDownTemperatureRight_ValueChanged(object sender, EventArgs e)
        {
            this.rightTemperature = Convert.ToUInt16(numericUpDownTemperatureRight.Value);
        }
        #endregion

        //壓力更改事件
        private void numericUpDownPressureLeft_ValueChanged(object sender, EventArgs e)
        {
            this.leftPressure = Convert.ToUInt16(numericUpDownPressureLeft.Value);
        }

        private void numericUpDownPressureRight_ValueChanged(object sender, EventArgs e)
        {
            this.rightPressure = Convert.ToUInt16(numericUpDownPressureRight.Value);
        }

        private void NumericUpDownVacuumDegreeLeft_ValueChanged(object sender, EventArgs e)
        {
            this.leftVacuumDegree = Convert.ToUInt16(numericUpDownVacuumDegreeLeft.Value);
        }

        private void NumericUpDownVacuumDegreeRight_ValueChanged(object sender, EventArgs e)
        {
            this.rightVacuumDegree = Convert.ToUInt16(numericUpDownVacuumDegreeRight.Value);
        }
    }
}
