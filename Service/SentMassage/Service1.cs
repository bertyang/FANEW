using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;

using Anchor120V7.InnerComm;
using Anchor120V7.InnerComm.InnerCommModel;
using SentMassage.Coreservice;

namespace SentMassage
{
    public partial class Service1 : ServiceBase
    {
        #region 变量
        private int _intExpiredNoticeInterval = 60000;

        System.Timers.Timer timer = new System.Timers.Timer();
        private static InnerCommEntrance Entrance = null;//内部通信接口 
        string connectionString = SqlHelper.GetConnSting();

        #endregion

        public Service1()
        {
            InitializeComponent();
        }

        public void SendSMS(object sender, EventArgs e)
        {
            try
            {
                //初始化通服
                Coreservice.ServiceSoap coreService = new Coreservice.ServiceSoapClient();
                ParameterNetInfo netinfo = coreService.GetParameterNetInfo(1); ;//中心
                List<string> GPSIPlist = new List<string>(netinfo.GpsServerIPList);
                Entrance = new InnerCommEntrance(netinfo.BroadcastIP, netinfo.CommonPort, netinfo.CtiServerIP, netinfo.CtiPort, GPSIPlist, netinfo.GpsPort, netinfo.RecordPort);

                DataSet dsMessage = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select * from B_Remind where 是否发送='N'");

                if (dsMessage.Tables[0].Rows.Count == 0) return;

                for (int i = 0; i < dsMessage.Tables[0].Rows.Count; i++)
                {
                    DateTime time = ((DateTime)dsMessage.Tables[0].Rows[i]["提醒时间"]);

                    if (time <= DateTime.Now)
                    {
                        string phone = dsMessage.Tables[0].Rows[i]["发送对象"].ToString();
                        string content = dsMessage.Tables[0].Rows[i]["内容"].ToString();
                        string number = dsMessage.Tables[0].Rows[i]["编码"].ToString();
                        string worker = dsMessage.Tables[0].Rows[i]["操作员编码"].ToString(); 

                        Other_SMGInfo smginfo = new Other_SMGInfo();
                        smginfo.DeskCode = "00";
                        smginfo.TelCodeList = phone.TrimEnd(',').Split(',').ToList();
                        smginfo.SMGContent = content;
                        smginfo.OperatorCode = worker;
                        int result = Entrance.GetSendInstence().Other_SendSMG(smginfo);

                        //if (result == 29)
                        //{
                            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "update  [B_Remind] set 是否发送='Y' where 编码=" + number);
                        //}

                        LogManager.WriteLog(LogFile.Trace, string.Format("phone:{0},content:{1},result:{2}", phone, content, result));
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LogFile.Error, ex.ToString());
            }
        }

        protected override void OnStart(string[] args)
        {

            //Config Timber
            timer.Interval = _intExpiredNoticeInterval;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SendSMS);
            timer.AutoReset = true;
            timer.Enabled = true;


        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }

        private DataSet GetDataSet(string connString, string sql)
        {
            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(connString);
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}