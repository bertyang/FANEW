using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anchor.FA.Model;
using Anchor.FA.BLL.IBLL;
using Anchor.FA.Utility;
using System.Collections;
using System.Text;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Runtime.Serialization.Json;
using System.Web.Routing;
using System.Linq.Expressions;




namespace Anchor.FA.Web.Controllers
{
    /// <summary>
    /// 病历管理
    /// 贾明
    /// </summary>

    public class MedicalController : BaseController
    {
        //
        // GET: /Medical/
        private static object m_SyncRoot = new Object();//互斥对象


        #region 病历管理

        #region 初始化方法

        #region 病例与收费管理
        /// <summary>
        /// 病例与收费管理主页面初始化方法
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult MedicalManagement()
        {
            string startTime = DateTime.Now.AddDays(-AppConfig.DayDistance).ToString("yyyy-MM-dd ");
            this.ViewData["Begin"] = AppConfig.SelectTime;
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd ");
            string end = DateTime.Now.ToString("HH:mm:ss");
            this.ViewData["End"] = end;

            this.ViewData["IsPatient"] = AppConfig.IsPatient;
            this.ViewData["IsDirectSave"] = AppConfig.IsDirectSave;
            this.ViewData["Patient_RDLC_Path"] = AppConfig.Patient_RDLC_Path;
            this.ViewData["IsPrint"] = AppConfig.IsPrint;
            this.ViewData["AddPatientPage"] = AppConfig.AddPatientPage;
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;
            ViewData["accout"] = User.Identity.Name.Split('|')[1];
            ViewData["userId"] = User.Identity.Name.Split('|')[0];

            #region 获取权限集合
            List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            string tempRole = "";
            if (workRole[0] != null)
            {
                int i = 0;
                foreach (var item in workRole)
                {
                    if (item.RoleID == 0 || item.RoleID == 1)
                    {
                        tempRole = "1";

                        break;
                    }
                    else
                    {
                        if (workRole.Count == 1)
                        {
                            tempRole = item.RoleID.ToString();

                        }
                        else
                        {

                            if (workRole.Count == i)
                            {
                                tempRole += item.RoleID.ToString();

                            }
                            else
                            {
                                tempRole += item.RoleID.ToString() + ",";

                            }
                        }
                        i++;
                    }
                }
            }
            ViewData["Role"] = tempRole;

            #endregion

            #region 体格检查与救治措施的缓存

            //var result = new object();
            //var results = new object();
            //string TaskCode = "";
            //string PatientOrder = "";
            ////增加缓存
            //lock (m_SyncRoot)
            //{
            //    IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            //    result = CacheUtility.GetCacheObject("Physical");
            //    results = CacheUtility.GetCacheObject("Measure");
            //    if (result == null || results == null)
            //    {
            //        result = MedicalManagement.AddPhysicalExamination(TaskCode, PatientOrder);
            //        results = MedicalManagement.AddPhysicalExaminationLoad(TaskCode, PatientOrder);
            //        CacheUtility.SetCacheObject("Physical", result);
            //        CacheUtility.SetCacheObject("Measure", results);
            //    }
            //}
            //this.ViewData["test"] = result;
            //this.ViewData["testMeasure"] = results;

            #endregion

            return View();
        }

        #endregion

        #region 急救员转送记录
        /// <summary>
        /// 病例与收费管理主页面初始化方法
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult MedicalFirstAider()
        {
            string startTime = DateTime.Now.AddDays(-AppConfig.DayDistance).ToString("yyyy-MM-dd ");
            this.ViewData["Begin"] = AppConfig.SelectTime;
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd ");
            string end = DateTime.Now.ToString("HH:mm:ss");
            this.ViewData["End"] = end;

            this.ViewData["IsPatient"] = AppConfig.IsPatient;
            this.ViewData["IsDirectSave"] = AppConfig.IsDirectSave;
            this.ViewData["Patient_RDLC_Path"] = AppConfig.Patient_RDLC_Path;
            this.ViewData["IsPrint"] = AppConfig.IsPrint;
            this.ViewData["AddPatientPage"] = AppConfig.AddPatientPage;
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;
            ViewData["accout"] = User.Identity.Name.Split('|')[1];
            ViewData["userId"] = User.Identity.Name.Split('|')[0];

            #region 获取权限集合
            List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            string tempRole = "";
            if (workRole[0] != null)
            {
                int i = 0;
                foreach (var item in workRole)
                {
                    if (item.RoleID == 0 || item.RoleID == 1)
                    {
                        tempRole = "1";

                        break;
                    }
                    else
                    {
                        if (workRole.Count == 1)
                        {
                            tempRole = item.RoleID.ToString();

                        }
                        else
                        {

                            if (workRole.Count == i)
                            {
                                tempRole += item.RoleID.ToString();

                            }
                            else
                            {
                                tempRole += item.RoleID.ToString() + ",";

                            }
                        }
                        i++;
                    }
                }
            }
            ViewData["Role"] = tempRole;

            #endregion
            return View();
        }

        #endregion


        #region 病历新增--------------杭州
        /// <summary>
        /// 病历新增页面初始化方法
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="Type">填写状态</param>
        /// <returns></returns>
        public ActionResult AddPatientRecord(string TaskCode, string Type, int PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            //int AddPatientOrder = GetPatientOrder(TaskCode);
            if (Type == "add" || Type == "ManageAdd")
            {
                C_Patient result = MedicalManagement.GetAddPatient(Type, TaskCode);
                ViewData["Entity"] = result;
            }
            else
            {
                M_PatientRecord result = MedicalManagement.GetAllPatient(TaskCode, PatientOrder);
                ViewData["Entity"] = result;
            }

            //ViewData["PatientOrder"] = AddPatientOrder;
            ViewData["PersonCode"] = User.Identity.Name.Split('|')[0];
            ViewData["PersonName"] = User.Identity.Name.Split('|')[1];
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;

            #region 为病历页面的CheckBoxList项目赋值
            CheckViewModel model = new CheckViewModel();
            model.PastHistoryChoose = MedicalManagement.GetCheckBoxModel("HistoryBingShi");
            model.AllergicHistoryChoose = MedicalManagement.GetCheckBoxModel("MedicalBingShi");
            model.VisitsType = MedicalManagement.GetCheckBoxModel("CureResult");
            model.Pupil = MedicalManagement.GetCheckBoxModelTG("Pupil");
            model.Head = MedicalManagement.GetCheckBoxModelTG("Head");
            model.Neck = MedicalManagement.GetCheckBoxModelTG("Neck");
            model.Chest = MedicalManagement.GetCheckBoxModelTG("Chest");
            model.Lung = MedicalManagement.GetCheckBoxModelTG("Lung");
            model.LungLeft = MedicalManagement.GetCheckBoxModelTG("LungLeft");
            model.LungRight = MedicalManagement.GetCheckBoxModelTG("LungRight");
            model.Belly = MedicalManagement.GetCheckBoxModelTG("Belly");
            model.Limbs = MedicalManagement.GetCheckBoxModelTG("Limbs");
            model.Limb = MedicalManagement.GetCheckBoxModelTG("Limb");
            #endregion

            #region 为病历页面的RadioButtonList赋值

            var MPDS = new object();//MPDS
            var Thorax = new object();//胸廓挤压试验
            var Pelvis = new object();//骨盆挤压试验
            var Nervous = new object();//神经系统

            //增加缓存
            lock (m_SyncRoot)
            {
                MPDS = CacheUtility.GetCacheObject("MPDS");
                Thorax = CacheUtility.GetCacheObject("Thorax");
                Pelvis = CacheUtility.GetCacheObject("Pelvis");
                //Nervous = CacheUtility.GetCacheObject("Nervous");
                if (MPDS == null || Thorax == null || Pelvis == null || Nervous == null)
                {
                    MPDS = MedicalManagement.GetCheckBoxOrRadioButtonList("MPDS-", "MPDSJudge", "radio");
                    Thorax = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Thorax-", "Thorax", "radio");
                    Pelvis = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Pelvis-", "Pelvis", "radio");
                    //Nervous = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Nervous-", "Nervous", "radio");

                    CacheUtility.SetCacheObject("MPDS", MPDS);
                    CacheUtility.SetCacheObject("Thorax", Thorax);
                    CacheUtility.SetCacheObject("Pelvis", Pelvis);
                    //CacheUtility.SetCacheObject("Nervous", Nervous);
                }
            }
            this.ViewData["MPDS"] = MPDS;
            this.ViewData["Thorax"] = Thorax;
            this.ViewData["Pelvis"] = Pelvis;
            //this.ViewData["Nervous"] = Nervous;

            #endregion


            #region 获取权限集合
            bool TempIsDoctor = false;
            this.ViewData["IsDoctor"] = AppConfig.IsDoctor;
            List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            if (workRole[0] != null)
            {
                foreach (var item in workRole)
                {
                    if (this.ViewData["IsDoctor"].ToString() == "True")
                    {
                        if (item.RoleID == 0 || item.RoleID == 1 || item.RoleID == 4 || item.RoleID == 104 || item.RoleID == 117 || item.RoleID == 119)
                        {
                            TempIsDoctor = true;
                        }
                    }
                }
            }

            if (TempIsDoctor == true)
            {
                this.ViewData["TitleName"] = true;
            }
            else
            {
                this.ViewData["TitleName"] = false;
            }
            #endregion


            return View(model);

        }
        #endregion

        #region 病历新增--------------无锡
        /// <summary>
        /// 病历新增页面初始化方法
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="Type">填写状态</param>
        /// <returns></returns>
        public ActionResult AddPatientRecordWX(string TaskCode, string Type, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            //int AddPatientOrder = GetPatientOrder(TaskCode);
            if (Type == "add" || Type == "ManageAdd")
            {
                C_Patient result = MedicalManagement.GetAddPatient(Type, TaskCode);
                ViewData["Entity"] = result;
            }
            else
            {
                M_PatientRecord result = MedicalManagement.GetAllPatient(TaskCode, Convert.ToInt32(PatientOrder));
                ViewData["Entity"] = result;
            }

            //ViewData["PatientOrder"] = AddPatientOrder;
            ViewData["TaskCode"] = TaskCode;
            ViewData["PatientRecordID"] = TaskCode + PatientOrder;
            this.ViewData["Patient_RDLC_Path"] = AppConfig.Patient_RDLC_Path;
            ViewData["PersonCode"] = User.Identity.Name.Split('|')[0];
            ViewData["PersonName"] = User.Identity.Name.Split('|')[1];
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;

            #region 为病历页面的CheckBoxList项目赋值
            CheckViewModel model = new CheckViewModel();
            model.Symptom = MedicalManagement.GetCheckBoxModel("Symptom");
            model.PastHistoryChoose = MedicalManagement.GetCheckBoxModel("HistoryBingShi");
            model.AllergicHistoryChoose = MedicalManagement.GetCheckBoxModel("MedicalBingShi");
            //model.VisitsType = MedicalManagement.GetCheckBoxModel("CureResult");
            this.ViewData["VisitsType"] = MedicalManagement.GetCheckBoxOrRadioButtonList("CZLX-", "CureResult", "checkbox");
            model.Pupil = MedicalManagement.GetCheckBoxModelTG("Pupil");
            model.Head = MedicalManagement.GetCheckBoxModelTG("Head");
            model.Neck = MedicalManagement.GetCheckBoxModelTG("Neck");
            model.Chest = MedicalManagement.GetCheckBoxModelTG("Chest");
            model.Lung = MedicalManagement.GetCheckBoxModelTG("Lung");
            model.LungLeft = MedicalManagement.GetCheckBoxModelTG("LungLeft");
            model.LungRight = MedicalManagement.GetCheckBoxModelTG("LungRight");
            model.Belly = MedicalManagement.GetCheckBoxModelTG("Belly");
            model.Limbs = MedicalManagement.GetCheckBoxModelTG("Limbs");
            model.Limb = MedicalManagement.GetCheckBoxModelTG("Limb");
            #endregion

            #region 为病历页面的RadioButtonList赋值

            var MPDS = new object();//MPDS
            var Thorax = new object();//胸廓挤压试验
            var Pelvis = new object();//骨盆挤压试验
            var Nervous = new object();//神经系统

            //增加缓存
            lock (m_SyncRoot)
            {
                MPDS = CacheUtility.GetCacheObject("MPDS");
                Thorax = CacheUtility.GetCacheObject("Thorax");
                Pelvis = CacheUtility.GetCacheObject("Pelvis");
                //Nervous = CacheUtility.GetCacheObject("Nervous");
                if (MPDS == null || Thorax == null || Pelvis == null || Nervous == null)
                {
                    MPDS = MedicalManagement.GetCheckBoxOrRadioButtonList("MPDS-", "MPDSJudge", "radio");
                    Thorax = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Thorax-", "Thorax", "radio");
                    Pelvis = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Pelvis-", "Pelvis", "radio");
                    //Nervous = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Nervous-", "Nervous", "radio");

                    CacheUtility.SetCacheObject("MPDS", MPDS);
                    CacheUtility.SetCacheObject("Thorax", Thorax);
                    CacheUtility.SetCacheObject("Pelvis", Pelvis);
                    //CacheUtility.SetCacheObject("Nervous", Nervous);
                }
            }
            this.ViewData["MPDS"] = MPDS;
            this.ViewData["Thorax"] = Thorax;
            this.ViewData["Pelvis"] = Pelvis;
            //this.ViewData["Nervous"] = Nervous;

            #endregion


            #region 获取权限集合
            bool TempIsDoctor = false;
            this.ViewData["IsDoctor"] = AppConfig.IsDoctor;
            List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            if (workRole[0] != null)
            {
                foreach (var item in workRole)
                {
                    if (this.ViewData["IsDoctor"].ToString() == "True")
                    {
                        if (item.RoleID == 0 || item.RoleID == 1 || item.RoleID == 4 || item.RoleID == 104 || item.RoleID == 117 || item.RoleID == 119)
                        {
                            TempIsDoctor = true;
                        }
                    }
                    if (item.RoleID == 5)
                    {
                        this.ViewData["HuShi"] = true;
                    }
                    else {
                        this.ViewData["HuShi"] = false;
                    }
                }
            }

            if (TempIsDoctor == true)
            {
                this.ViewData["TitleName"] = true;
            }
            else
            {
                this.ViewData["TitleName"] = false;
            }
            #endregion


            return View(model);

        }
        #endregion

        #region 病历填写--------------长春
        /// <summary>
        /// 病历填写初始化方法
        /// </summary>
        /// <returns></returns>
        //public ActionResult AddPatientRecordCC()
        //{
        //    IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

        //    ViewData["PersonCode"] = User.Identity.Name.Split('|')[0];
        //    ViewData["PersonName"] = User.Identity.Name.Split('|')[1];

        //    List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
        //    string WorkID = "";
        //    string PassWord = "";
        //    if (workRole[0] != null)
        //    {
        //        int i = 1;
        //        foreach (var item in workRole)
        //        {

        //            if (workRole.Count == 1)
        //            {
        //                if (item.RoleID == 5)
        //                {
        //                    if (!string.IsNullOrEmpty(item.EmpNo))
        //                    {
        //                        WorkID = GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
        //                        PassWord = GetOldPersonID(Convert.ToInt32(item.EmpNo)).口令;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (item.RoleID == 5)
        //                {
        //                    if (!string.IsNullOrEmpty(item.EmpNo))
        //                    {
        //                        WorkID = GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
        //                        PassWord = GetOldPersonID(Convert.ToInt32(item.EmpNo)).口令;
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    WorkID = "99999";
        //                    PassWord = GetOldPersonID(99999).口令;
        //                }
        //            }
        //            i++;
        //        }
        //    }
        //    return Redirect(AppConfig.AddPatientRecordCC + WorkID + "&PassWord=" + PassWord + "&PopedomCode=2001");
        //    //return View();

        //}
        #endregion

        #region 药品耗材维护--------------长春
        /// <summary>
        /// 药品耗材维护页面初始化方法
        /// </summary>
        /// <returns></returns>
        //public ActionResult TreeDic()
        //{
        //    IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
        //    string WorkID = "99999";
        //    string PassWord = "LaEgNNFNTgs=";
        //    return Redirect(AppConfig.TreeDic + "TChargeItem&WorkID=" + WorkID + "&PassWord=" + PassWord + "&PopedomCode=2002");
        //    //return View();

        //}
        #endregion


        #region 病历查看
        /// <summary>
        /// 病历新增页面初始化方法--杭州
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="Type">填写状态</param>
        /// <returns></returns>
        public ActionResult LookPatientRecord(string TaskCode, string Type, int PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            //int AddPatientOrder = GetPatientOrder(TaskCode);
            if (Type == "add" || Type == "ManageAdd")
            {
                C_Patient result = MedicalManagement.GetAddPatient(Type, TaskCode);
                ViewData["Entity"] = result;
            }
            else
            {
                M_PatientRecord result = MedicalManagement.GetAllPatient(TaskCode, PatientOrder);
                ViewData["Entity"] = result;
            }

            //ViewData["PatientOrder"] = AddPatientOrder;
            ViewData["PersonCode"] = User.Identity.Name.Split('|')[0];


            #region 为病历页面的CheckBoxList项目赋值
            CheckViewModel model = new CheckViewModel();
            model.Symptom = MedicalManagement.GetCheckBoxModel("Symptom");
            model.PastHistoryChoose = MedicalManagement.GetCheckBoxModel("HistoryBingShi");
            model.AllergicHistoryChoose = MedicalManagement.GetCheckBoxModel("MedicalBingShi");
            model.VisitsType = MedicalManagement.GetCheckBoxModel("CureResult");
            model.Pupil = MedicalManagement.GetCheckBoxModelTG("Pupil");
            model.Head = MedicalManagement.GetCheckBoxModelTG("Head");
            model.Neck = MedicalManagement.GetCheckBoxModelTG("Neck");
            model.Chest = MedicalManagement.GetCheckBoxModelTG("Chest");
            model.Lung = MedicalManagement.GetCheckBoxModelTG("Lung");
            model.LungLeft = MedicalManagement.GetCheckBoxModelTG("LungLeft");
            model.LungRight = MedicalManagement.GetCheckBoxModelTG("LungRight");
            model.Belly = MedicalManagement.GetCheckBoxModelTG("Belly");
            model.Limbs = MedicalManagement.GetCheckBoxModelTG("Limbs");
            model.Limb = MedicalManagement.GetCheckBoxModelTG("Limb");
            #endregion

            #region 为病历页面的RadioButtonList赋值

            var MPDS = new object();//MPDS
            var Thorax = new object();//胸廓挤压试验
            var Pelvis = new object();//骨盆挤压试验
            var Nervous = new object();//神经系统

            //增加缓存
            lock (m_SyncRoot)
            {
                MPDS = CacheUtility.GetCacheObject("MPDS");
                Thorax = CacheUtility.GetCacheObject("Thorax");
                Pelvis = CacheUtility.GetCacheObject("Pelvis");
                //Nervous = CacheUtility.GetCacheObject("Nervous");
                if (MPDS == null || Thorax == null || Pelvis == null || Nervous == null)
                {
                    MPDS = MedicalManagement.GetCheckBoxOrRadioButtonList("MPDS-", "MPDSJudge", "radio");
                    Thorax = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Thorax-", "Thorax", "radio");
                    Pelvis = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Pelvis-", "Pelvis", "radio");
                    //Nervous = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Nervous-", "Nervous", "radio");

                    CacheUtility.SetCacheObject("MPDS", MPDS);
                    CacheUtility.SetCacheObject("Thorax", Thorax);
                    CacheUtility.SetCacheObject("Pelvis", Pelvis);
                    //CacheUtility.SetCacheObject("Nervous", Nervous);
                }
            }
            this.ViewData["MPDS"] = MPDS;
            this.ViewData["Thorax"] = Thorax;
            this.ViewData["Pelvis"] = Pelvis;
            //this.ViewData["Nervous"] = Nervous;

            #endregion

            return View(model);

        }
        /// <summary>
        /// 病历新增页面初始化方法--无锡
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="Type">填写状态</param>
        /// <returns></returns>
        public ActionResult LookPatientRecordWX(string TaskCode, string Type, int PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            //int AddPatientOrder = GetPatientOrder(TaskCode);
            if (Type == "add" || Type == "ManageAdd")
            {
                C_Patient result = MedicalManagement.GetAddPatient(Type, TaskCode);
                ViewData["Entity"] = result;
            }
            else
            {
                M_PatientRecord result = MedicalManagement.GetAllPatient(TaskCode, PatientOrder);
                ViewData["Entity"] = result;
            }

            //ViewData["PatientOrder"] = AddPatientOrder;
            ViewData["PersonCode"] = User.Identity.Name.Split('|')[0];


            #region 为病历页面的CheckBoxList项目赋值
            CheckViewModel model = new CheckViewModel();
            model.Symptom = MedicalManagement.GetCheckBoxModel("Symptom");
            model.PastHistoryChoose = MedicalManagement.GetCheckBoxModel("HistoryBingShi");
            model.AllergicHistoryChoose = MedicalManagement.GetCheckBoxModel("MedicalBingShi");
            model.VisitsType = MedicalManagement.GetCheckBoxModel("CureResult");
            model.Pupil = MedicalManagement.GetCheckBoxModelTG("Pupil");
            model.Head = MedicalManagement.GetCheckBoxModelTG("Head");
            model.Neck = MedicalManagement.GetCheckBoxModelTG("Neck");
            model.Chest = MedicalManagement.GetCheckBoxModelTG("Chest");
            model.Lung = MedicalManagement.GetCheckBoxModelTG("Lung");
            model.LungLeft = MedicalManagement.GetCheckBoxModelTG("LungLeft");
            model.LungRight = MedicalManagement.GetCheckBoxModelTG("LungRight");
            model.Belly = MedicalManagement.GetCheckBoxModelTG("Belly");
            model.Limbs = MedicalManagement.GetCheckBoxModelTG("Limbs");
            model.Limb = MedicalManagement.GetCheckBoxModelTG("Limb");
            #endregion

            #region 为病历页面的RadioButtonList赋值

            var MPDS = new object();//MPDS
            var Thorax = new object();//胸廓挤压试验
            var Pelvis = new object();//骨盆挤压试验
            var Nervous = new object();//神经系统

            //增加缓存
            lock (m_SyncRoot)
            {
                MPDS = CacheUtility.GetCacheObject("MPDS");
                Thorax = CacheUtility.GetCacheObject("Thorax");
                Pelvis = CacheUtility.GetCacheObject("Pelvis");
                //Nervous = CacheUtility.GetCacheObject("Nervous");
                if (MPDS == null || Thorax == null || Pelvis == null || Nervous == null)
                {
                    MPDS = MedicalManagement.GetCheckBoxOrRadioButtonList("MPDS-", "MPDSJudge", "radio");
                    Thorax = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Thorax-", "Thorax", "radio");
                    Pelvis = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Pelvis-", "Pelvis", "radio");
                    //Nervous = MedicalManagement.GetCheckBoxOrRadioButtonListForTG("Nervous-", "Nervous", "radio");

                    CacheUtility.SetCacheObject("MPDS", MPDS);
                    CacheUtility.SetCacheObject("Thorax", Thorax);
                    CacheUtility.SetCacheObject("Pelvis", Pelvis);
                    //CacheUtility.SetCacheObject("Nervous", Nervous);
                }
            }
            this.ViewData["MPDS"] = MPDS;
            this.ViewData["Thorax"] = Thorax;
            this.ViewData["Pelvis"] = Pelvis;
            //this.ViewData["Nervous"] = Nervous;

            #endregion

            return View(model);

        }
        #endregion

        #region Checkboxlist自定义控件需要用到的模型视图
        public class CheckViewModel
        {
            //存储从数据库获取的值
            public IList<C_CheckModel> Symptom { get; set; }//症状关键词
            public IList<C_CheckModel> PastHistoryChoose { get; set; }//既往病史
            public IList<C_CheckModel> AllergicHistoryChoose { get; set; }//既往病史
            public IList<C_CheckModel> VisitsType { get; set; }//出诊类型
            public IList<C_CheckModel> Pupil { get; set; }//瞳孔
            public IList<C_CheckModel> Head { get; set; }//头部
            public IList<C_CheckModel> Neck { get; set; }//颈部
            public IList<C_CheckModel> Chest { get; set; }//胸部
            public IList<C_CheckModel> Lung { get; set; }//肺部
            public IList<C_CheckModel> LungLeft { get; set; }//左肺
            public IList<C_CheckModel> LungRight { get; set; }//右肺
            public IList<C_CheckModel> Belly { get; set; }//腹部
            public IList<C_CheckModel> Limbs { get; set; }//脊柱
            public IList<C_CheckModel> Limb { get; set; }//四肢
            //存储从页面获取的值
            public CheckModels SymptomModels { get; set; }//症状关键词
            public CheckModels PastHistoryModels { get; set; }//既往病史
            public CheckModels AllergicHistoryModels { get; set; }//既往病史
            public CheckModels VisitsTypeModels { get; set; }//出诊类型
            public CheckModels PupilModels { get; set; }//瞳孔
            public CheckModels HeadModels { get; set; }//头部
            public CheckModels NeckModels { get; set; }//颈部
            public CheckModels ChestModels { get; set; }//胸部
            public CheckModels LungModels { get; set; }//肺部
            public CheckModels LungLeftModels { get; set; }//左肺
            public CheckModels LungRightModels { get; set; }//右肺
            public CheckModels BellyModels { get; set; }//腹部
            public CheckModels LimbsModels { get; set; }//脊柱
            public CheckModels LimbModels { get; set; }//四肢
        }
        public class CheckModels
        {
            public string[] CheckModelIDs { get; set; }
        }
        #endregion

        #region 初步诊断
        public ActionResult SelectHidPrimaryDiagnoses()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("Menu");
                if (result == null)
                {
                    DataTable cet = MedicalManagement.GetAllTZICD();
                    result = GetMenuListZou(cet);
                    CacheUtility.SetCacheObject("Menu", result);
                }
            }
            this.ViewData["MenuList"] = result;
            return View();
        }
        public ActionResult SelectFirstDiagnose()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("MenuFirstDiagnose");
                if (result == null)
                {
                    DataTable cet = MedicalManagement.GetAllTZICD();
                    result = GetMenuListZou(cet);
                    CacheUtility.SetCacheObject("MenuFirstDiagnose", result);
                }
            }
            this.ViewData["FirstDiagnoseList"] = result;
            return View();
        }
        #endregion

        #region 加载初步诊断树形菜单

        #region 获取第一层的
        /// <summary>
        /// 获取第一层的
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetDataRowDeep1(DataTable dt)
        {
            DataRow[] drs;
            drs = dt.Select("上级编码=" + 0 + "");
            return drs;
        }
        #endregion

        #region 第二层 上级编码
        /// <summary>
        /// 第二层 上级编码
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetDataRowDeep2(object code, DataTable dt)
        {
            return dt.Select("上级编码=" + code + "");
        }
        #endregion

        #region 第三层
        /// <summary>
        /// 第三层 
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetDataRowDeep3(object code, DataTable dt)
        {
            return dt.Select("上级编码=" + code + "");
        }
        #endregion

        #region 初步诊断树形菜单
        protected string GetMenuListZou(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Data.DataRow dr1 in GetDataRowDeep1(dt))//第一层
            {
                System.Data.DataRow[] dr2s = GetDataRowDeep2(dr1["编码"], dt);
                sb.AppendFormat("<li class=\"dp1\">{0}<span></span><ul>", dr1["名称"]);
                foreach (System.Data.DataRow dr2 in dr2s)//第二层
                {
                    System.Data.DataRow[] dr3s = GetDataRowDeep2(dr2["编码"], dt);
                    if (dr3s.Length == 0)
                    {
                        sb.AppendFormat(
                            "<li><input type='checkbox' value='{0}' coding=\"{1}\" py=\"{2}\" onclick=\"zjchecked(this)\" />",
                            dr2["名称"], dr2["编码"], dr2["字头"]);
                    }
                    else
                    {
                        sb.Append("<li class=\"dp2\">");
                    }
                    sb.AppendFormat(@"<span>{0}</span><ul>", dr2["名称"]);

                    foreach (System.Data.DataRow dr3 in dr3s)//第三层
                    {
                        System.Data.DataRow[] dr4s = GetDataRowDeep3(dr3["编码"], dt);
                        if (dr4s.Length == 0)
                        {
                            sb.AppendFormat(
                                "<li><input type='checkbox' value='{0}' coding=\"{1}\" py=\"{2}\" onclick=\"zjchecked(this)\" />",
                                dr3["名称"], dr3["编码"], dr3["字头"]);
                        }
                        else
                        {
                            sb.Append("<li class=\"dp3\">");
                        }
                        sb.AppendFormat(@"<span>{0}</span><ul>", dr3["名称"]);
                        foreach (System.Data.DataRow dr4 in dr4s)//第四层
                        {
                            sb.AppendFormat(@"<li><input type='checkbox' value='{0}'coding='{1}' py='{2}'  onclick='zjchecked(this)' /><span>{3}</span></li>"
        , dr4["名称"], dr4["编码"], dr4["字头"], dr4["名称"]);
                        }
                        sb.Append(@"</ul></li>");
                    }
                    sb.Append(@"</ul></li>");
                }
                sb.Append(@"</ul></li>");
            }
            return sb.ToString();
        }
        #endregion

        #endregion

        #region 救治措施

        #region 救治措施
        /// <summary>
        /// 打开救治措施中转页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult MeasurePage(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("MeasurePage");
                if (result == null)
                {
                    DataTable cet = MedicalManagement.GetAllMeasure();
                    result = GetJZMenuListZou(cet);
                    CacheUtility.SetCacheObject("MeasurePage", result);
                }
            }
            this.ViewData["MenuList"] = result;
            return View();
        }
        #endregion

        #region 插入救治措施
        /// <summary>
        /// 打开救治措施中转页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult MeasureAddPage(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("MeasureAddPage");
                if (result == null)
                {
                    DataTable cet = MedicalManagement.GetAllMeasure();
                    result = GetJZMenuListZou(cet);
                    CacheUtility.SetCacheObject("MeasureAddPage", result);
                }
            }
            this.ViewData["MenuList"] = result;
            return View();
        }
        #endregion

        #region 加载救治措施树形菜单


        public ActionResult GetMeasureTree(string Name)
        {
            try
            {
                IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
                List<C_EFFECTIVEDIAGINFO_TREE> cet = MedicalManagement.GetMeasureTree(Name);
                this.ViewData["MeasureTree"] = this.Json(cet);
                return this.Json(cet);
            }
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                return this.Json(dict);
            }
        }

        #region 获取第一层的
        /// <summary>
        /// 获取第一层的
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetJZDataRowDeep1(DataTable dt)
        {
            DataRow[] drs;
            drs = dt.Select("UpperID='" + 0 + "'");
            return drs;
        }
        #endregion

        #region 第二层 上级编码
        /// <summary>
        /// 第二层 上级编码
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetJZDataRowDeep2(object code, DataTable dt)
        {
            return dt.Select("UpperID='" + code + "'");
        }
        #endregion

        #region 第三层
        /// <summary>
        /// 第三层 
        /// </summary>
        /// <returns></returns>
        protected DataRow[] GetJZDataRowDeep3(object code, DataTable dt)
        {
            return dt.Select("UpperID=" + code + "");
        }
        #endregion

        #region 救治措施树形菜单
        protected string GetJZMenuListZou(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Data.DataRow dr1 in GetJZDataRowDeep1(dt))//第一层
            {
                System.Data.DataRow[] dr2s = GetJZDataRowDeep2(dr1["ProjectID"], dt);
                sb.AppendFormat("<li class=\"dp1\">{0}<span></span><ul>", dr1["Prefixes"]);
                foreach (System.Data.DataRow dr2 in dr2s)//第二层
                {
                    System.Data.DataRow[] dr3s = GetJZDataRowDeep2(dr2["UpperID"], dt);
                    if (dr3s.Length >= 1)
                    {
                        sb.AppendFormat(
                            "<li><input type='checkbox' value='{0}' coding=\"{1}\" py=\"{2}\" onclick=\"zjchecked(this)\" />",
                            dr2["Prefixes"], dr2["ProjectID"], dr2["ProjectID"]);
                    }
                    else
                    {
                        sb.Append("<li class=\"dp2\">");
                    }
                    sb.AppendFormat(@"<span>{0}</span>", dr2["Prefixes"]);

                }
                sb.Append(@"</ul></li>");
            }
            return sb.ToString();
        }
        #endregion

        #endregion

        #endregion

        #region 病历修改记录
        /// <summary>
        /// 病历修改记录
        /// </summary>
        /// <param name="PatientRecordID">病历ID</param>
        /// <returns></returns>
        public ActionResult UpdateLog(string PatientRecordID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            return View();
        }
        #endregion

        #region 救治记录
        /// <summary>
        /// 救治记录页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult NursingRecordt(string TaskCode, string PatientOrder)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewData["Name"] = User.Identity.Name.Split('|')[1];
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;
            return View();
        }
        public ActionResult CheckNusingRecord(string TaskCode, string PatientOrder)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewData["Name"] = User.Identity.Name.Split('|')[1];
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;
            return View();
        }
        #endregion

        #region 单独用药
        /// <summary>
        /// 单独用药页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult AddNusingRecord(string TaskCode, string PatientOrder, string addtype)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            this.ViewData["PatientRecordID"] = TaskCode + PatientOrder;
            this.ViewData["RecordOrder"] = GetGoodsNameRecord(TaskCode + PatientOrder, addtype) + 1;
            ViewData["Name"] = User.Identity.Name.Split('|')[1];
            return View();
        }

        #endregion

        #region 单独用药----编辑
        /// <summary>
        /// 编辑单独用药页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult EditNusingRecord(string TaskCode, string PatientOrder, string Edit)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string PatientRecordID;
            PatientRecordID = TaskCode + PatientOrder;
            this.ViewData["RecordOrder"] = GetGoodsNameRecord(PatientRecordID, Edit);
            ViewData["Name"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        public ActionResult CheckEditNusingRecord(string TaskCode, string PatientOrder, string Edit)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string PatientRecordID;
            PatientRecordID = TaskCode + PatientOrder;
            this.ViewData["RecordOrder"] = GetGoodsNameRecord(PatientRecordID, Edit);
            ViewData["Name"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        #endregion

        #region 救治措施
        /// <summary>
        /// 救治措施页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns></returns>
        public ActionResult AddPhysicalExamination(string TaskCode, string PatientOrder)
        {
            var result = new object();
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            //增加缓存
            lock (m_SyncRoot)
            {
                IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

                result = CacheUtility.GetCacheObject("Physical");
                if (result == null)
                {
                    result = MedicalManagement.AddPhysicalExamination(TaskCode, PatientOrder);
                    CacheUtility.SetCacheObject("Physical", result);
                }
            }
            this.ViewData["test"] = result;
            return View();
        }
        #endregion

        #region 病例----工作流审核页面
        /// <summary>
        /// 病例审核页面初始化方法
        /// </summary>
        /// <param name="FlowNo">工作流表单号</param>
        /// <returns>ActionResult</returns>
        public ActionResult PatientView(int FlowNo)
        {
            IFlow flow = ctx["Flow"] as IFlow;

            ViewData["TaskListHTML"] = flow.TaskListScript(int.Parse(Request.QueryString["flowInstId"]));
            ViewData["url"] = AppConfig.Patient_RDLC_Path + "&flowNo=" + FlowNo;

            return View();
        }

        #endregion

        #region Utstein----添加
        /// <summary>
        /// Utstein页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <param name="Type">是否编辑</param>
        /// <returns>ActionResult</returns>
        public ActionResult AddUtstein(string TaskCode, string PatientOrder, string Type, string DocName, string PatientName, string Sex, string Age, string History)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.ViewData["startTime"] = startTime;
            C_Utsteins Utsteins = GetUtsteins(TaskCode, PatientOrder, Type);
            Utsteins.DocName = DocName;
            Utsteins.PatientName = PatientName;
            Utsteins.Sex = Sex;
            Utsteins.Age = Age;
            Utsteins.History = History;
            this.ViewData["UtsteinEntity"] = Utsteins;
            this.ViewData["Sex"] = Sex;
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            return View();
        }

        #endregion

        #region Utstein----编辑
        /// <summary>
        /// Utstein页面初始化方法
        /// </summary>
        /// <param name="TaskCode">病历编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <param name="Type">是否编辑</param>
        /// <returns>ActionResult</returns>
        public ActionResult EditUtstein(string TaskCode, string PatientOrder, string Type)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.ViewData["startTime"] = startTime;
            M_Utstein Utsteins = GetUtstein(TaskCode, PatientOrder, Type);
            this.ViewData["UtsteinEntity"] = Utsteins;
            this.ViewData["Sex"] = Utsteins.Sex;
            this.ViewData["PatientRecordID"] = Utsteins.PatientRecordID;
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            return View();
        }

        #endregion

        #region 病例打印
        public ActionResult PatientReport()
        {
            return View();
        }
        #endregion

        #region 病历模版
        public ActionResult Template()
        {
            return View();
        }
        #endregion

        #endregion

        #region 病历审核与撤回

        #region 病历审核
        /// <summary>
        /// 病例审核
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历编号</param>
        /// <param name="WorkID">人员ID</param>
        /// <returns></returns>
        public ActionResult ApplyFlow(string TaskCode, string PatientOrder, string WorkID)
        {
            IAccidentPatient MedicalManagement = ctx["NewPatient"] as IAccidentPatient;
            //bool save = false;
            int tempPatientOrder = Convert.ToInt32(PatientOrder);
            int tempWorkID = Convert.ToInt32(WorkID);
            try
            {
                //save = MedicalManagement.ApplyFlow(6, TaskCode, tempPatientOrder, tempWorkID);
                Dictionary<string, object> dicts = new Dictionary<string, object>();
                dicts.Add("InfoMessage", MedicalManagement.ApplyFlow(6, TaskCode, tempPatientOrder, tempWorkID));
                return this.Json(dicts);
            }
            //catch (Exception e)
            //{
            //    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/ApplyFlow()", e.Message);
            //    save = false
            //}
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/ApplyFlow()", e.ToString());
                return this.Json(dict);
            }
            //return save;
        }
        #endregion

        #region 病历撤回
        /// <summary>
        /// 病历撤回
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历编号</param>
        /// <param name="WorkID">人员ID</param>
        /// <returns></returns>
        public ActionResult BillInBackAudit(string TaskCode, string PatientOrder, string WorkID)
        {
            IAccidentPatient MedicalManagement = ctx["NewPatient"] as IAccidentPatient;
            //bool save = false;
            int tempPatientOrder = Convert.ToInt32(PatientOrder);
            int tempWorkID = Convert.ToInt32(WorkID);
            try
            {
                //save = MedicalManagement.BillInBackAudit(6, TaskCode, tempPatientOrder, tempWorkID);
                Dictionary<string, object> dicts = new Dictionary<string, object>();
                dicts.Add("InfoMessage", MedicalManagement.BillInBackAudit(6, TaskCode, tempPatientOrder, tempWorkID));
                return this.Json(dicts);
            }
            catch (Exception e)
            {
                //Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/BillInBackAudit()", e.ToString());
                //save = false;
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/BillInBackAudit()", e.ToString());
                return this.Json(dict);
            }
            //return save;
        }
        #endregion

        #endregion

        #region 病历抽查

        #region 病历抽查页面初始化
        public ActionResult MedicaCheckPatient()
        {
            string startTime = DateTime.Now.AddDays(-AppConfig.DayDistance).ToString("yyyy-MM-dd ");
            this.ViewData["Begin"] = AppConfig.SelectTime;
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd ");
            string end = DateTime.Now.ToString("HH:mm:ss");
            this.ViewData["End"] = end;

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;
            ViewData["accout"] = User.Identity.Name.Split('|')[1];
            ViewData["userId"] = User.Identity.Name.Split('|')[0];
            this.ViewData["Patient_RDLC_Path"] = AppConfig.Patient_RDLC_Path;
            this.ViewData["LookPatientPage"] = AppConfig.LookPatientPage;
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;
            this.ViewData["AddPatientPage"] = AppConfig.AddPatientPage;
            return View();
        }
        public ActionResult DocMedicaCheckPatient()
        {
            string startTime = DateTime.Now.AddDays(-AppConfig.DayDistance).ToString("yyyy-MM-dd ");
            this.ViewData["Begin"] = AppConfig.SelectTime;
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd ");
            string end = DateTime.Now.ToString("HH:mm:ss");
            this.ViewData["End"] = end;
            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;
            ViewData["accout"] = User.Identity.Name.Split('|')[1];
            ViewData["userId"] = User.Identity.Name.Split('|')[0];
            this.ViewData["Patient_RDLC_Path"] = AppConfig.Patient_RDLC_Path;
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;
            this.ViewData["LookPatientPage"] = AppConfig.LookPatientPage;
            this.ViewData["AddPatientPage"] = AppConfig.AddPatientPage;

            #region 获取权限集合
            List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            string tempRole = "";
            if (workRole[0] != null)
            {
                int i = 0;
                foreach (var item in workRole)
                {
                    if (item.RoleID == 0 || item.RoleID == 1)
                    {
                        tempRole = "1";

                        break;
                    }
                    else
                    {
                        if (workRole.Count == 1)
                        {
                            tempRole = item.RoleID.ToString();

                        }
                        else
                        {

                            if (workRole.Count == i)
                            {
                                tempRole += item.RoleID.ToString();

                            }
                            else
                            {
                                tempRole += item.RoleID.ToString() + ",";

                            }
                        }
                        i++;
                    }
                }
            }
            ViewData["Role"] = tempRole;

            #endregion

            return View();
        }
        #endregion

        #region 病历抽查-救治记录页面初始化
        public ActionResult CheckNursingRecord(string TaskCode, string PatientOrder)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }
        #endregion

        #region 病历抽查-救治记录页面初始化-单独用药
        public ActionResult CheckNursingRecordDrug(string TaskCode, string PatientOrder, string addtype)
        {
            this.ViewData["TaskCode"] = TaskCode;
            this.ViewData["PatientOrder"] = PatientOrder;
            this.ViewData["startTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string PatientRecordID;
            if (Convert.ToInt32(PatientOrder) == 0)
            {
                PatientRecordID = TaskCode + (Convert.ToInt32(PatientOrder) + 1).ToString();
            }
            else
            {
                if (addtype == "add")
                {
                    PatientRecordID = GetPatientOrder(TaskCode).ToString();
                    PatientRecordID = TaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }
                else
                {
                    PatientRecordID = TaskCode + PatientOrder;
                }

            }
            this.ViewData["RecordOrder"] = GetGoodsNameRecord(PatientRecordID, addtype) + 1;
            return View();
        }
        #endregion

        #region 抽查结果初始化
        public ActionResult CheckPatientResult(string TaskCode, int PatientOrder)
        {
            IAccidentPatient AccidentPatient = ctx["NewPatient"] as IAccidentPatient;
            M_PatientCheck checkEntity = AccidentPatient.queryCheckEntity(TaskCode, PatientOrder);
            if (checkEntity == null)
            {
                checkEntity = new M_PatientCheck();
                checkEntity.TaskID = TaskCode;
                checkEntity.TaskXH = PatientOrder;
                checkEntity.CheckerID = this.CurrentUser.ID;
                //checkEntity.Cert=this.CurrentUser.
                checkEntity.CheckTime = DateTime.Now;
                checkEntity.CheckResult = "0";
                checkEntity.Content = string.Empty;
            }
            this.ViewData["entity"] = checkEntity;

            return View();
        }
        #endregion

        #region 保存抽查结果
        public bool SaveCheckResult(M_PatientCheck entity)
        {
            IAccidentPatient AccidentPatient = ctx["NewPatient"] as IAccidentPatient;
            bool b = false;
            try
            {
                b = AccidentPatient.SaveCheckResult(entity, this.CurrentUser.Name);
            }
            catch (Exception e)
            {
                b = false;
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveCheckResult()", e.ToString());
            }

            return b;
        }
        #endregion

        #region 加载全部病历数据

        /// <summary>
        /// 加载全部病历数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="Driver">司机</param>
        /// <param name="Doctor">医生</param>
        /// <param name="LinkPhone">联系电话</param>
        /// <param name="LocalAdd">现场地址</param>
        /// <param name="Station">分站</param>
        /// <param name="IsCharge">收费情况</param>
        /// <param name="IsDoc">是否医生</param>
        /// <param name="FirstDiagnoseName">第一诊断</param>
        /// <param name="PatientType">病历类型</param>
        /// <param name="PatientName">患者姓名</param>
        /// <returns>Json</returns>
        public ActionResult MedicaCheckPatientLoad(int page, int rows, string order, string sort, DateTime start, DateTime end, string Driver, string Doctor,
             string LinkPhone, string LocalAdd, string Station, string IsCharge, string IsDoc, string FirstDiagnoseName, string PatientType, string PatientName)
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            ViewData["userId"] = User.Identity.Name.Split('|')[0];
            int FillPersonCode = Convert.ToInt32(ViewData["userId"]);
            try
            {
                if (IsDoc == "0" || IsDoc == "1")
                {
                    var result = MedicalManagement.GetAllPatients(page, rows, order, sort, start, end, Driver, Doctor,
                     LinkPhone, LocalAdd, Station, IsCharge, FirstDiagnoseName, PatientType, PatientName);
                    return Json(result);
                }
                else
                {
                    var result = MedicalManagement.GetAllPatientsDoc(page, rows, order, sort, start, end, Driver, Doctor,
                         LinkPhone, LocalAdd, Station, IsCharge, FirstDiagnoseName, PatientType, PatientName, FillPersonCode);
                    return Json(result);
                }
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetAllPatients()", e.ToString());
                return null;
            }


        }

        #endregion

        #endregion

        #region 添加编辑保存方法

        #region 病历----添加

        /// <summary>
        /// 添加病历
        /// </summary>
        /// <param name="C_AddPatientRecordModel">病历实体</param>
        /// <returns>Bool</returns>
        public bool SavePatient(C_AddPatientRecordModel model)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            if (model != null)
            {
                try
                {
                    save = MedicalManagement.SavePatient(model);
                }


                catch (Exception e)
                {
                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePatient()", e.ToString());
                    save = false;
                }
            }
            return save;

        }
        #endregion

        #region 体格检查----添加
        /// <summary>
        /// 体格检查----添加
        /// </summary>
        /// <param name="Physical">体格检查List</param>
        /// <returns>bool</returns>
        public ActionResult SavePatientTgjc(List<C_PhysicalItem> Physical)
        {
            string PatientOrder = "";
            string TaskCode = "";
            string Edit = "";
            string Type = "";
            int PersonID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            if (Physical != null)
            {
                PatientOrder = Physical[0].PatientOrder;
                TaskCode = Physical[0].TaskCode;
                Edit = Physical[0].Edit;
                Type = Physical[0].Type;
                try
                {
                    Dictionary<string, object> dicts = new Dictionary<string, object>();
                    dicts.Add("save", MedicalManagement.SavePatientTgjc(Physical, Edit, Type, TaskCode, PatientOrder, PersonID));
                    return this.Json(dicts);
                }
                catch (Exception e)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("InfoID", "0");
                    dict.Add("InfoMessage", e.Message);
                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePatientTgjc()", e.ToString());
                    return this.Json(dict);
                }

            }
            else
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", "您还没有填写体格检查的相关内容！");
                return this.Json(dict);
            }
        }
        #endregion

        #region 救治措施----添加
        /// <summary>
        /// 救治措施----添加
        /// </summary>
        /// <param name="Measure">救治措施List</param>
        /// <returns>bool</returns>
        public bool SavePatientJzcs(List<C_PhysicalItem> Measure)
        {
            string PatientOrder = "";
            string TaskCode = "";
            string Edit = "";
            string Type = "";
            int PersonID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            if (Measure != null)
            {
                PatientOrder = Measure[Measure.Count - 1].PatientOrder;
                TaskCode = Measure[Measure.Count - 1].TaskCode;
                Edit = Measure[Measure.Count - 1].Edit;
                Type = Measure[Measure.Count - 1].Type;
            }
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                if (Measure != null)
                {
                    save = MedicalManagement.SavePatientJzcs(Measure, Edit, Type, TaskCode, PatientOrder, PersonID);
                }
                else
                {
                    save = true;
                }
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePatientJzcs()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion


        #region 救治措施----插入
        /// <summary>
        /// 救治措施----插入
        /// </summary>
        /// <param name="Measure">救治措施List</param>
        /// <returns>bool</returns>
        public bool SaveAddPatientJzcs(List<C_PhysicalItem> Measure)
        {
            string PatientOrder = "";
            string TaskCode = "";
            string Edit = "";
            string Type = "";
            int DoOrder = 0;
            int PersonID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            if (Measure != null)
            {
                PatientOrder = Measure[0].PatientOrder;
                TaskCode = Measure[0].TaskCode;
                Edit = Measure[0].Edit;
                Type = Measure[0].Type;
                DoOrder = Measure[0].DoOrder;
            }
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                if (Measure != null)
                {
                    save = MedicalManagement.SaveAddPatientJzcs(Measure, Edit, Type, TaskCode, PatientOrder, PersonID, DoOrder);
                }
                else
                {
                    save = true;
                }
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePatientJzcs()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion

        #region Utstein----添加

        /// <summary>
        /// 添加Utstein
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveUtstein()
        {
            string PatientOrder = Request["PatientOrder"].ToString();
            string TaskCode = Request["TaskCode"].ToString();
            string Edit = Request["Edit"].ToString();

            #region 为M_Utstein赋值

            M_Utstein UtsteinDetaile = new M_Utstein();
            if (Request["HelpTime"] != null && Request["HelpTime"] != "")
            {
                UtsteinDetaile.HelpTime = Convert.ToDateTime(Request["HelpTime"]);
            }
            if (Request["ComaTime"] != null && Request["ComaTime"] != "")
            {
                UtsteinDetaile.ComaTime = Convert.ToDateTime(Request["ComaTime"]);
            }
            if (Request["DrivingTime"] != null && Request["DrivingTime"] != "")
            {
                UtsteinDetaile.DrivingTime = Convert.ToDateTime(Request["DrivingTime"]);
            }
            if (Request["ArriveTime"] != null && Request["ArriveTime"] != "")
            {
                UtsteinDetaile.ArriveTime = Convert.ToDateTime(Request["ArriveTime"]);
            }
            if (Request["LeaveTime"] != null && Request["LeaveTime"] != "")
            {
                UtsteinDetaile.LeaveTime = Convert.ToDateTime(Request["LeaveTime"]);
            }
            if (Request["ArriveHosTime"] != null && Request["ArriveHosTime"] != "")
            {
                UtsteinDetaile.ArriveHosTime = Convert.ToDateTime(Request["ArriveHosTime"]);
            }
            UtsteinDetaile.TelZD = Request["TelZD"];
            UtsteinDetaile.TelZDTrue = Request["TelZDTrue"];
            UtsteinDetaile.CCPerson = Request["CCPerson"];
            UtsteinDetaile.DocLS = Request["DocLS"];
            UtsteinDetaile.SeriesTime = Request["SeriesTime"];
            UtsteinDetaile.DocName = Request["DocName"];
            UtsteinDetaile.DocTitle = Request["DocTitle"];
            UtsteinDetaile.DocAge = Request["DocAge"];
            UtsteinDetaile.WorkYear = Request["WorkYear"];
            UtsteinDetaile.PatientName = Request["PatientName"];
            UtsteinDetaile.Sex = Request["Sex"];
            UtsteinDetaile.Age = Request["Age"];
            UtsteinDetaile.Death = Request["Death"];
            UtsteinDetaile.Healthy = Request["Healthy"];
            UtsteinDetaile.History = Request["History"];
            UtsteinDetaile.DieReson = Request["DieReson"];
            UtsteinDetaile.Trauma = Request["Trauma"];
            UtsteinDetaile.Witness = Request["Witness"];
            UtsteinDetaile.WitnessType = Request["WitnessType"];
            UtsteinDetaile.WitnessCure = Request["WitnessCure"];
            UtsteinDetaile.Cure = Request["Cure"];
            UtsteinDetaile.RightSure = Request["RightSure"];
            UtsteinDetaile.Ffracture = Request["Ffracture"];
            UtsteinDetaile.Breathe = Request["Breathe"];
            UtsteinDetaile.Recovery = Request["Recovery"];
            UtsteinDetaile.RecoveryNo = Request["RecoveryNo"];
            UtsteinDetaile.Press = Request["Press"];
            UtsteinDetaile.ParticipateIn = Request["ParticipateIn"];

            if (Request["startTime"] != null && Request["startTime"] != "")
            {
                UtsteinDetaile.startTime = Convert.ToDateTime(Request["startTime"]);
            }

            if (Request["ECGTime"] != null && Request["ECGTime"] != "")
            {
                UtsteinDetaile.ECGTime = Convert.ToDateTime(Request["ECGTime"]);
            }
            UtsteinDetaile.Rhythms = Request["Rhythms"];
            UtsteinDetaile.DJcount = Request["DJcount"];
            UtsteinDetaile.Energy = Request["Energy"];
            UtsteinDetaile.Tracheal = Request["Tracheal"];
            UtsteinDetaile.CGresult = Request["CGresult"];
            UtsteinDetaile.Saccule = Request["Saccule"];
            UtsteinDetaile.Oropharyngeal = Request["Oropharyngeal"];
            UtsteinDetaile.LaryngealMask = Request["LaryngealMask"];
            UtsteinDetaile.JMKT = Request["JMKT"];
            UtsteinDetaile.KTresult = Request["KTresult"];
            UtsteinDetaile.SSXS = Request["SSXS"];
            UtsteinDetaile.Dose = Request["Dose"];
            UtsteinDetaile.Count = Request["Count"];
            UtsteinDetaile.XGJYS = Request["XGJYS"];
            UtsteinDetaile.Amiodarone = Request["Amiodarone"];
            UtsteinDetaile.FSTime = Request["FSTime"];
            UtsteinDetaile.IScffs = Request["IScffs"];
            UtsteinDetaile.Clinical = Request["Clinical"];
            UtsteinDetaile.Finish = Request["Finish"];
            UtsteinDetaile.ROSC = Request["ROSC"];
            UtsteinDetaile.HFTime = Request["HFTime"];
            if (Request["Recover"] != null && Request["Recover"] != "")
            {
                UtsteinDetaile.Recover = Convert.ToDateTime(Request["Recover"]);
            }
            UtsteinDetaile.HidPrimaryDiagnoses = Request["HidPrimaryDiagnoses"];
            UtsteinDetaile.ROSCTime = Request["ROSCTime"];
            UtsteinDetaile.Conscious = Request["Conscious"];
            UtsteinDetaile.RecoverTime = Request["RecoverTime"];
            if (Request["Concrete"] != null && Request["Concrete"] != "")
            {
                UtsteinDetaile.Concrete = Convert.ToDateTime(Request["Concrete"]);
            }
            UtsteinDetaile.Mind = Request["Mind"];
            UtsteinDetaile.RecoverMind = Request["RecoverMind"];
            if (Request["ConcreteMind"] != null && Request["ConcreteMind"] != "")
            {
                UtsteinDetaile.ConcreteMind = Convert.ToDateTime(Request["ConcreteMind"]);
            }
            UtsteinDetaile.LapseTo = Request["LapseTo"];
            UtsteinDetaile.Hosp = Request["Hosp"];
            UtsteinDetaile.Organization = Request["Organization"];
            #endregion

            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.SaveUtstein(UtsteinDetaile, Edit, TaskCode, PatientOrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveUtstein()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion

        #region 体格检查记录----添加

        /// <summary>
        /// 添加体格检查记录
        /// </summary>
        /// <returns>Bool</returns>
        public bool SavePhysical()
        {
            string tempDetaile = Request["param"].ToString();
            string[] mytempDetaile = tempDetaile.Split(',');
            string param = mytempDetaile[0];
            string PatientRecordID;
            string tempTaskCode = Request["TaskCode"].ToString();

            #region 获取病历ID
            if (param == "add" || param == "ManageAdd")
            {
                if (Convert.ToInt32(Request["PatientOrder"]) == 0)
                {
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
                }
                else
                {
                    PatientRecordID = GetPatientOrder(tempTaskCode).ToString();
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }

            }
            else
            {
                if (Convert.ToInt32(Request["PatientOrder"]) == 0)
                {
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
                }
                else
                {
                    PatientRecordID = tempTaskCode + Request["PatientOrder"];
                }

            }
            #endregion

            IList<C_Detaile> list = new List<C_Detaile>();

            #region 创建C_Detaile实例
            C_Detaile htTemp1 = new C_Detaile();
            C_Detaile htTemp2 = new C_Detaile();
            C_Detaile htTemp3 = new C_Detaile();
            C_Detaile htTemp4 = new C_Detaile();
            C_Detaile htTemp5 = new C_Detaile();
            C_Detaile htTemp6 = new C_Detaile();
            C_Detaile htTemp7 = new C_Detaile();
            C_Detaile htTemp8 = new C_Detaile();
            C_Detaile htTemp9 = new C_Detaile();
            C_Detaile htTemp10 = new C_Detaile();
            C_Detaile htTemp11 = new C_Detaile();
            C_Detaile htTemp12 = new C_Detaile();
            C_Detaile htTemp13 = new C_Detaile();
            C_Detaile htTemp14 = new C_Detaile();
            C_Detaile htTemp15 = new C_Detaile();
            C_Detaile htTemp16 = new C_Detaile();
            C_Detaile htTemp17 = new C_Detaile();
            //C_Detaile htTemp18 = new C_Detaile();
            //C_Detaile htTemp19 = new C_Detaile();
            //C_Detaile htTemp20 = new C_Detaile();
            //C_Detaile htTemp21 = new C_Detaile();
            //C_Detaile htTemp22 = new C_Detaile();
            //C_Detaile htTemp23 = new C_Detaile();
            //C_Detaile htTemp24 = new C_Detaile();
            //C_Detaile htTemp25 = new C_Detaile();
            //C_Detaile htTemp26 = new C_Detaile();
            //C_Detaile htTemp27 = new C_Detaile();
            //C_Detaile htTemp28 = new C_Detaile();
            //C_Detaile htTemp29 = new C_Detaile();
            //C_Detaile htTemp30 = new C_Detaile();
            //C_Detaile htTemp31 = new C_Detaile();
            //C_Detaile htTemp32 = new C_Detaile();
            //C_Detaile htTemp33 = new C_Detaile();
            //C_Detaile htTemp34 = new C_Detaile();
            //C_Detaile htTemp35 = new C_Detaile();
            //C_Detaile htTemp36 = new C_Detaile();
            //C_Detaile htTemp37 = new C_Detaile();
            //C_Detaile htTemp38 = new C_Detaile();
            //C_Detaile htTemp39 = new C_Detaile();
            //C_Detaile htTemp40 = new C_Detaile();
            //C_Detaile htTemp41 = new C_Detaile();
            //C_Detaile htTemp42 = new C_Detaile();
            //C_Detaile htTemp43 = new C_Detaile();
            //C_Detaile htTemp44 = new C_Detaile();
            //C_Detaile htTemp45 = new C_Detaile();
            //C_Detaile htTemp46 = new C_Detaile();
            //C_Detaile htTemp47 = new C_Detaile();
            //C_Detaile htTemp48 = new C_Detaile();
            //C_Detaile htTemp49 = new C_Detaile();
            //C_Detaile htTemp50 = new C_Detaile();
            //C_Detaile htTemp51 = new C_Detaile();
            //C_Detaile htTemp52 = new C_Detaile();
            //C_Detaile htTemp53 = new C_Detaile();
            //C_Detaile htTemp54 = new C_Detaile();
            //C_Detaile htTemp55 = new C_Detaile();
            //C_Detaile htTemp56 = new C_Detaile();
            //C_Detaile htTemp57 = new C_Detaile();
            //C_Detaile htTemp58 = new C_Detaile();
            //C_Detaile htTemp59 = new C_Detaile();
            //C_Detaile htTemp60 = new C_Detaile();
            //C_Detaile htTemp61 = new C_Detaile();
            //C_Detaile htTemp62 = new C_Detaile();
            //C_Detaile htTemp63 = new C_Detaile();
            //C_Detaile htTemp64 = new C_Detaile();
            //C_Detaile htTemp65 = new C_Detaile();
            //C_Detaile htTemp66 = new C_Detaile();
            //C_Detaile htTemp67 = new C_Detaile();
            //C_Detaile htTemp68 = new C_Detaile();
            //C_Detaile htTemp69 = new C_Detaile();
            //C_Detaile htTemp70 = new C_Detaile();
            //C_Detaile htTemp71 = new C_Detaile();
            //C_Detaile htTemp72 = new C_Detaile();
            //C_Detaile htTemp73 = new C_Detaile();
            //C_Detaile htTemp74 = new C_Detaile();
            //C_Detaile htTemp75 = new C_Detaile();
            //C_Detaile htTemp76 = new C_Detaile();
            //C_Detaile htTemp77 = new C_Detaile();
            //C_Detaile htTemp78 = new C_Detaile();
            //C_Detaile htTemp79 = new C_Detaile();
            //C_Detaile htTemp80 = new C_Detaile();
            //C_Detaile htTemp81 = new C_Detaile();
            //C_Detaile htTemp82 = new C_Detaile();
            #endregion

            #region 为C_Detaile赋值

            htTemp1.Name = "blood"; htTemp1.Value = mytempDetaile[1]; list.Add(htTemp1);
            htTemp2.Name = "Pulse"; htTemp2.Value = mytempDetaile[2]; list.Add(htTemp2);
            htTemp3.Name = "Respiratio"; htTemp3.Value = mytempDetaile[3]; list.Add(htTemp3);
            htTemp4.Name = "Temperatur"; htTemp4.Value = mytempDetaile[4]; list.Add(htTemp4);

            htTemp5.Name = "Mind"; htTemp5.Value = mytempDetaile[5]; list.Add(htTemp5);
            htTemp6.Name = "Pupil"; htTemp6.Value = mytempDetaile[6]; list.Add(htTemp6);
            htTemp7.Name = "Refle"; htTemp7.Value = mytempDetaile[7]; list.Add(htTemp7);
            htTemp8.Name = "Pate"; htTemp8.Value = mytempDetaile[8]; list.Add(htTemp8);
            htTemp9.Name = "Heart"; htTemp9.Value = mytempDetaile[9]; list.Add(htTemp9);
            htTemp10.Name = "DoubleLung"; htTemp10.Value = mytempDetaile[10]; list.Add(htTemp10);
            htTemp11.Name = "Chest"; htTemp11.Value = mytempDetaile[11]; list.Add(htTemp11);
            htTemp12.Name = "Belly"; htTemp12.Value = mytempDetaile[12]; list.Add(htTemp12);
            htTemp13.Name = "Limbs"; htTemp13.Value = mytempDetaile[13]; list.Add(htTemp13);
            htTemp14.Name = "HZOther"; htTemp14.Value = mytempDetaile[14]; list.Add(htTemp14);
            htTemp15.Name = "Sugar"; htTemp15.Value = mytempDetaile[15]; list.Add(htTemp15);
            htTemp16.Name = "Saturation"; htTemp16.Value = mytempDetaile[16]; list.Add(htTemp16);
            htTemp17.Name = "ECG"; htTemp17.Value = mytempDetaile[17]; list.Add(htTemp17);

            //htTemp5.Name = "Generala"; htTemp5.Value = mytempDetaile[5]; list.Add(htTemp5);
            //htTemp6.Name = "Awareness"; htTemp6.Value = mytempDetaile[6]; list.Add(htTemp6);
            //htTemp7.Name = "Parole"; htTemp7.Value = mytempDetaile[7]; list.Add(htTemp7);
            //htTemp8.Name = "Postural"; htTemp8.Value = mytempDetaile[8]; list.Add(htTemp8);
            //htTemp9.Name = "Skin"; htTemp9.Value = mytempDetaile[9]; list.Add(htTemp9);
            //htTemp10.Name = "Sweating"; htTemp10.Value = mytempDetaile[10]; list.Add(htTemp10);
            //htTemp11.Name = "Sclera"; htTemp11.Value = mytempDetaile[11]; list.Add(htTemp11);
            //htTemp12.Name = "Chemosis"; htTemp12.Value = mytempDetaile[12]; list.Add(htTemp12);
            //htTemp13.Name = "PupilLeft"; htTemp13.Value = mytempDetaile[13]; list.Add(htTemp13);
            //htTemp14.Name = "PupilRight"; htTemp14.Value = mytempDetaile[14]; list.Add(htTemp14);
            //htTemp15.Name = "Lips"; htTemp15.Value = mytempDetaile[15]; list.Add(htTemp15);
            //htTemp16.Name = "LightRefle"; htTemp16.Value = mytempDetaile[16]; list.Add(htTemp16);
            //htTemp17.Name = "Holdout"; htTemp17.Value = mytempDetaile[17]; list.Add(htTemp17);
            //htTemp18.Name = "Meninx"; htTemp18.Value = mytempDetaile[18]; list.Add(htTemp18);
            //htTemp19.Name = "Distention"; htTemp19.Value = mytempDetaile[19]; list.Add(htTemp19);
            //htTemp20.Name = "CarotidPul"; htTemp20.Value = mytempDetaile[20]; list.Add(htTemp20);
            //htTemp21.Name = "Thorax"; htTemp21.Value = mytempDetaile[21]; list.Add(htTemp21);
            //htTemp22.Name = "Rib"; htTemp22.Value = mytempDetaile[22]; list.Add(htTemp22);
            //htTemp23.Name = "Breathing"; htTemp23.Value = mytempDetaile[23]; list.Add(htTemp23);
            //htTemp24.Name = "Sounds"; htTemp24.Value = mytempDetaile[24]; list.Add(htTemp24);
            //htTemp25.Name = "Rales"; htTemp25.Value = mytempDetaile[25]; list.Add(htTemp25);
            //htTemp26.Name = "Wheeze"; htTemp26.Value = mytempDetaile[26]; list.Add(htTemp26);
            //htTemp27.Name = "Bulging"; htTemp27.Value = mytempDetaile[27]; list.Add(htTemp27);
            //htTemp28.Name = "Varices"; htTemp28.Value = mytempDetaile[28]; list.Add(htTemp28);
            //htTemp29.Name = "Kidney"; htTemp29.Value = mytempDetaile[29]; list.Add(htTemp29);
            //htTemp30.Name = "Pain"; htTemp30.Value = mytempDetaile[30]; list.Add(htTemp30);
            //htTemp31.Name = "Rebound"; htTemp31.Value = mytempDetaile[31]; list.Add(htTemp31);
            //htTemp32.Name = "Liver"; htTemp32.Value = mytempDetaile[32]; list.Add(htTemp32);
            //htTemp33.Name = "Spleen"; htTemp33.Value = mytempDetaile[33]; list.Add(htTemp33);
            //htTemp34.Name = "Murphy"; htTemp34.Value = mytempDetaile[34]; list.Add(htTemp34);
            //htTemp35.Name = "Dullness"; htTemp35.Value = mytempDetaile[35]; list.Add(htTemp35);
            //htTemp36.Name = "HeartRate"; htTemp36.Value = mytempDetaile[36]; list.Add(htTemp36);
            //htTemp37.Name = "Muscle"; htTemp37.Value = mytempDetaile[37]; list.Add(htTemp37);
            //htTemp38.Name = "Cardiovert"; htTemp38.Value = mytempDetaile[38]; list.Add(htTemp38);
            //htTemp39.Name = "HeartBorde"; htTemp39.Value = mytempDetaile[39]; list.Add(htTemp39);
            //htTemp40.Name = "HeartSound"; htTemp40.Value = mytempDetaile[40]; list.Add(htTemp40);
            //htTemp41.Name = "ValveNoise"; htTemp41.Value = mytempDetaile[41]; list.Add(htTemp41);
            //htTemp42.Name = "Spine"; htTemp42.Value = mytempDetaile[42]; list.Add(htTemp42);
            //htTemp43.Name = "Limb"; htTemp43.Value = mytempDetaile[43]; list.Add(htTemp43);
            //htTemp44.Name = "MuscleTone"; htTemp44.Value = mytempDetaile[44]; list.Add(htTemp44);
            //htTemp45.Name = "Reflex"; htTemp45.Value = mytempDetaile[45]; list.Add(htTemp45);
            //htTemp46.Name = "Pathology"; htTemp46.Value = mytempDetaile[46]; list.Add(htTemp46);
            //htTemp47.Name = "Trauma"; htTemp47.Value = mytempDetaile[47]; list.Add(htTemp47);
            //htTemp48.Name = "Check"; htTemp48.Value = mytempDetaile[48]; list.Add(htTemp48);
            //htTemp49.Name = "Sugar"; htTemp49.Value = mytempDetaile[49]; list.Add(htTemp49);
            //htTemp50.Name = "Saturation"; htTemp50.Value = mytempDetaile[50]; list.Add(htTemp50);
            //htTemp51.Name = "BaseOther"; htTemp51.Value = mytempDetaile[51]; list.Add(htTemp51);
            //htTemp52.Name = "ECG"; htTemp52.Value = mytempDetaile[52]; list.Add(htTemp52);
            //htTemp53.Name = "AppOther"; htTemp53.Value = mytempDetaile[53]; list.Add(htTemp53);
            //htTemp54.Name = "Nasal"; htTemp54.Value = mytempDetaile[54]; list.Add(htTemp54);
            //htTemp55.Name = "Mask"; htTemp55.Value = mytempDetaile[55]; list.Add(htTemp55);
            //htTemp56.Name = "Guardian"; htTemp56.Value = mytempDetaile[56]; list.Add(htTemp56);
            //htTemp57.Name = "Suction"; htTemp57.Value = mytempDetaile[57]; list.Add(htTemp57);
            //htTemp58.Name = "Needle"; htTemp58.Value = mytempDetaile[58]; list.Add(htTemp58);
            //htTemp59.Name = "Cardiac"; htTemp59.Value = mytempDetaile[59]; list.Add(htTemp59);
            //htTemp60.Name = "Cooling"; htTemp60.Value = mytempDetaile[60]; list.Add(htTemp60);
            //htTemp61.Name = "Debrideme"; htTemp61.Value = mytempDetaile[61]; list.Add(htTemp61);
            //htTemp62.Name = "Hemosta"; htTemp62.Value = mytempDetaile[62]; list.Add(htTemp62);
            //htTemp63.Name = "StopBlood"; htTemp63.Value = mytempDetaile[63]; list.Add(htTemp63);
            //htTemp64.Name = "Cavity"; htTemp64.Value = mytempDetaile[64]; list.Add(htTemp64);
            //htTemp65.Name = "Fixed"; htTemp65.Value = mytempDetaile[65]; list.Add(htTemp65);
            //htTemp66.Name = "Press"; htTemp66.Value = mytempDetaile[66]; list.Add(htTemp66);
            //htTemp67.Name = "Deliver"; htTemp67.Value = mytempDetaile[67]; list.Add(htTemp67);
            //htTemp68.Name = "Other"; htTemp68.Value = mytempDetaile[68]; list.Add(htTemp68);
            //htTemp69.Name = "Vein"; htTemp69.Value = mytempDetaile[69]; list.Add(htTemp69);
            //htTemp70.Name = "Push"; htTemp70.Value = mytempDetaile[70]; list.Add(htTemp70);
            //htTemp71.Name = "Drip"; htTemp71.Value = mytempDetaile[71]; list.Add(htTemp71);
            //htTemp72.Name = "Injection"; htTemp72.Value = mytempDetaile[72]; list.Add(htTemp72);
            //htTemp73.Name = "Oral"; htTemp73.Value = mytempDetaile[73]; list.Add(htTemp73);
            //htTemp74.Name = "Tongue"; htTemp74.Value = mytempDetaile[74]; list.Add(htTemp74);
            //htTemp75.Name = "Intubation"; htTemp75.Value = mytempDetaile[75]; list.Add(htTemp75);
            //htTemp76.Name = "Saccule"; htTemp76.Value = mytempDetaile[76]; list.Add(htTemp76);
            //htTemp77.Name = "Breathe"; htTemp77.Value = mytempDetaile[77]; list.Add(htTemp77);
            //htTemp78.Name = "Defibrilla"; htTemp78.Value = mytempDetaile[78]; list.Add(htTemp78);
            //htTemp79.Name = "NasalZ"; htTemp79.Value = mytempDetaile[79]; list.Add(htTemp79);
            //htTemp80.Name = "OnTheWay"; htTemp80.Value = mytempDetaile[80]; list.Add(htTemp80);
            //htTemp81.Name = "SacculeZ"; htTemp81.Value = mytempDetaile[81]; list.Add(htTemp81);
            //htTemp82.Name = "BreatheZ"; htTemp82.Value = mytempDetaile[82]; list.Add(htTemp82);

            #endregion

            bool save = false;

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            if (ModelState.IsValid)
            {
                try
                {
                    save = MedicalManagement.SavePhysical(list, PatientRecordID);
                }
                catch (Exception e)
                {
                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePhysical()", e.ToString());
                    save = false;
                }
            }

            return save;
        }

        #endregion

        #region 救治措施记录----添加

        /// <summary>
        /// 添加救治记录
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveMeasure()
        {
            string tempDetaile = Request["param"].ToString();
            string[] mytempDetaile = tempDetaile.Split(',');
            string param = mytempDetaile[0];
            string PatientRecordID;
            string tempTaskCode = Request["TaskCode"].ToString();

            #region 获取病历ID
            if (param == "add" || param == "ManageAdd")
            {
                if (Convert.ToInt32(Request["PatientOrder"]) == 0)
                {
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
                }
                else
                {
                    PatientRecordID = GetPatientOrder(tempTaskCode).ToString();
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }

            }
            else
            {
                if (Convert.ToInt32(Request["PatientOrder"]) == 0)
                {
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
                }
                else
                {
                    PatientRecordID = tempTaskCode + Request["PatientOrder"];
                }

            }
            #endregion

            IList<C_Detaile> list = new List<C_Detaile>();

            #region 创建C_Detaile实例
            //C_Detaile htTemp1 = new C_Detaile();
            //C_Detaile htTemp2 = new C_Detaile();
            //C_Detaile htTemp3 = new C_Detaile();
            //C_Detaile htTemp4 = new C_Detaile();
            //C_Detaile htTemp5 = new C_Detaile();
            //C_Detaile htTemp6 = new C_Detaile();
            //C_Detaile htTemp7 = new C_Detaile();
            //C_Detaile htTemp8 = new C_Detaile();
            //C_Detaile htTemp9 = new C_Detaile();
            //C_Detaile htTemp10 = new C_Detaile();
            //C_Detaile htTemp11 = new C_Detaile();
            //C_Detaile htTemp12 = new C_Detaile();
            //C_Detaile htTemp13 = new C_Detaile();
            //C_Detaile htTemp14 = new C_Detaile();
            //C_Detaile htTemp15 = new C_Detaile();
            //C_Detaile htTemp16 = new C_Detaile();
            //C_Detaile htTemp17 = new C_Detaile();
            C_Detaile htTemp18 = new C_Detaile();
            C_Detaile htTemp19 = new C_Detaile();
            C_Detaile htTemp20 = new C_Detaile();
            C_Detaile htTemp21 = new C_Detaile();
            C_Detaile htTemp22 = new C_Detaile();
            C_Detaile htTemp23 = new C_Detaile();
            C_Detaile htTemp24 = new C_Detaile();
            C_Detaile htTemp25 = new C_Detaile();
            C_Detaile htTemp26 = new C_Detaile();
            C_Detaile htTemp27 = new C_Detaile();
            C_Detaile htTemp28 = new C_Detaile();
            C_Detaile htTemp29 = new C_Detaile();
            C_Detaile htTemp30 = new C_Detaile();
            C_Detaile htTemp31 = new C_Detaile();
            C_Detaile htTemp32 = new C_Detaile();
            C_Detaile htTemp33 = new C_Detaile();
            C_Detaile htTemp34 = new C_Detaile();
            C_Detaile htTemp35 = new C_Detaile();
            C_Detaile htTemp36 = new C_Detaile();
            C_Detaile htTemp37 = new C_Detaile();
            C_Detaile htTemp38 = new C_Detaile();
            C_Detaile htTemp39 = new C_Detaile();
            C_Detaile htTemp40 = new C_Detaile();
            C_Detaile htTemp41 = new C_Detaile();
            C_Detaile htTemp42 = new C_Detaile();
            C_Detaile htTemp43 = new C_Detaile();
            C_Detaile htTemp44 = new C_Detaile();
            C_Detaile htTemp45 = new C_Detaile();
            C_Detaile htTemp46 = new C_Detaile();
            //C_Detaile htTemp47 = new C_Detaile();
            //C_Detaile htTemp48 = new C_Detaile();
            //C_Detaile htTemp49 = new C_Detaile();
            //C_Detaile htTemp50 = new C_Detaile();
            //C_Detaile htTemp51 = new C_Detaile();
            //C_Detaile htTemp52 = new C_Detaile();
            //C_Detaile htTemp53 = new C_Detaile();
            //C_Detaile htTemp54 = new C_Detaile();
            //C_Detaile htTemp55 = new C_Detaile();
            //C_Detaile htTemp56 = new C_Detaile();
            //C_Detaile htTemp57 = new C_Detaile();
            //C_Detaile htTemp58 = new C_Detaile();
            //C_Detaile htTemp59 = new C_Detaile();
            //C_Detaile htTemp60 = new C_Detaile();
            //C_Detaile htTemp61 = new C_Detaile();
            //C_Detaile htTemp62 = new C_Detaile();
            //C_Detaile htTemp63 = new C_Detaile();
            //C_Detaile htTemp64 = new C_Detaile();
            //C_Detaile htTemp65 = new C_Detaile();
            //C_Detaile htTemp66 = new C_Detaile();
            //C_Detaile htTemp67 = new C_Detaile();
            //C_Detaile htTemp68 = new C_Detaile();
            //C_Detaile htTemp69 = new C_Detaile();
            //C_Detaile htTemp70 = new C_Detaile();
            //C_Detaile htTemp71 = new C_Detaile();
            //C_Detaile htTemp72 = new C_Detaile();
            //C_Detaile htTemp73 = new C_Detaile();
            //C_Detaile htTemp74 = new C_Detaile();
            //C_Detaile htTemp75 = new C_Detaile();
            //C_Detaile htTemp76 = new C_Detaile();
            //C_Detaile htTemp77 = new C_Detaile();
            //C_Detaile htTemp78 = new C_Detaile();
            //C_Detaile htTemp79 = new C_Detaile();
            //C_Detaile htTemp80 = new C_Detaile();
            //C_Detaile htTemp81 = new C_Detaile();
            //C_Detaile htTemp82 = new C_Detaile();
            #endregion

            #region 为C_Detaile赋值

            //htTemp1.Name = "blood"; htTemp1.Value = mytempDetaile[1]; list.Add(htTemp1);
            //htTemp2.Name = "Pulse"; htTemp2.Value = mytempDetaile[2]; list.Add(htTemp2);
            //htTemp3.Name = "Respiratio"; htTemp3.Value = mytempDetaile[3]; list.Add(htTemp3);
            //htTemp4.Name = "Temperatur"; htTemp4.Value = mytempDetaile[4]; list.Add(htTemp4);



            htTemp18.Name = "Nasal"; htTemp18.Value = mytempDetaile[18]; list.Add(htTemp18);
            htTemp19.Name = "Mask"; htTemp19.Value = mytempDetaile[19]; list.Add(htTemp19);
            htTemp20.Name = "Guardian"; htTemp20.Value = mytempDetaile[20]; list.Add(htTemp20);
            htTemp21.Name = "Suction"; htTemp21.Value = mytempDetaile[21]; list.Add(htTemp21);
            htTemp22.Name = "Needle"; htTemp22.Value = mytempDetaile[22]; list.Add(htTemp22);
            htTemp23.Name = "Cardiac"; htTemp23.Value = mytempDetaile[23]; list.Add(htTemp23);
            htTemp24.Name = "Cooling"; htTemp24.Value = mytempDetaile[24]; list.Add(htTemp24);
            htTemp25.Name = "Debrideme"; htTemp25.Value = mytempDetaile[25]; list.Add(htTemp25);
            htTemp26.Name = "Hemosta"; htTemp26.Value = mytempDetaile[26]; list.Add(htTemp26);
            htTemp27.Name = "StopBlood"; htTemp27.Value = mytempDetaile[27]; list.Add(htTemp27);
            htTemp28.Name = "Cavity"; htTemp28.Value = mytempDetaile[28]; list.Add(htTemp28);
            htTemp29.Name = "Fixed"; htTemp29.Value = mytempDetaile[29]; list.Add(htTemp29);
            htTemp30.Name = "Press"; htTemp30.Value = mytempDetaile[30]; list.Add(htTemp30);
            htTemp31.Name = "Deliver"; htTemp31.Value = mytempDetaile[31]; list.Add(htTemp31);
            htTemp32.Name = "Other"; htTemp32.Value = mytempDetaile[32]; list.Add(htTemp32);
            htTemp33.Name = "Vein"; htTemp33.Value = mytempDetaile[33]; list.Add(htTemp33);
            htTemp34.Name = "Push"; htTemp34.Value = mytempDetaile[34]; list.Add(htTemp34);
            htTemp35.Name = "Drip"; htTemp35.Value = mytempDetaile[35]; list.Add(htTemp35);
            htTemp36.Name = "Injection"; htTemp36.Value = mytempDetaile[36]; list.Add(htTemp36);
            htTemp37.Name = "Oral"; htTemp37.Value = mytempDetaile[37]; list.Add(htTemp37);
            htTemp38.Name = "Tongue"; htTemp38.Value = mytempDetaile[38]; list.Add(htTemp38);
            htTemp39.Name = "Intubation"; htTemp39.Value = mytempDetaile[39]; list.Add(htTemp39);
            htTemp40.Name = "Saccule"; htTemp40.Value = mytempDetaile[40]; list.Add(htTemp40);
            htTemp41.Name = "Breathe"; htTemp41.Value = mytempDetaile[41]; list.Add(htTemp41);
            htTemp42.Name = "Defibrilla"; htTemp42.Value = mytempDetaile[42]; list.Add(htTemp42);
            htTemp43.Name = "NasalZ"; htTemp43.Value = mytempDetaile[43]; list.Add(htTemp43);
            htTemp44.Name = "OnTheWay"; htTemp44.Value = mytempDetaile[44]; list.Add(htTemp44);
            htTemp45.Name = "SacculeZ"; htTemp45.Value = mytempDetaile[45]; list.Add(htTemp45);
            htTemp46.Name = "BreatheZ"; htTemp46.Value = mytempDetaile[46]; list.Add(htTemp46);
            //htTemp5.Name = "Generala"; htTemp5.Value = mytempDetaile[5]; list.Add(htTemp5);
            //htTemp6.Name = "Awareness"; htTemp6.Value = mytempDetaile[6]; list.Add(htTemp6);
            //htTemp7.Name = "Parole"; htTemp7.Value = mytempDetaile[7]; list.Add(htTemp7);
            //htTemp8.Name = "Postural"; htTemp8.Value = mytempDetaile[8]; list.Add(htTemp8);
            //htTemp9.Name = "Skin"; htTemp9.Value = mytempDetaile[9]; list.Add(htTemp9);
            //htTemp10.Name = "Sweating"; htTemp10.Value = mytempDetaile[10]; list.Add(htTemp10);
            //htTemp11.Name = "Sclera"; htTemp11.Value = mytempDetaile[11]; list.Add(htTemp11);
            //htTemp12.Name = "Chemosis"; htTemp12.Value = mytempDetaile[12]; list.Add(htTemp12);
            //htTemp13.Name = "PupilLeft"; htTemp13.Value = mytempDetaile[13]; list.Add(htTemp13);
            //htTemp14.Name = "PupilRight"; htTemp14.Value = mytempDetaile[14]; list.Add(htTemp14);
            //htTemp15.Name = "Lips"; htTemp15.Value = mytempDetaile[15]; list.Add(htTemp15);
            //htTemp16.Name = "LightRefle"; htTemp16.Value = mytempDetaile[16]; list.Add(htTemp16);
            //htTemp17.Name = "Holdout"; htTemp17.Value = mytempDetaile[17]; list.Add(htTemp17);
            //htTemp18.Name = "Meninx"; htTemp18.Value = mytempDetaile[18]; list.Add(htTemp18);
            //htTemp19.Name = "Distention"; htTemp19.Value = mytempDetaile[19]; list.Add(htTemp19);
            //htTemp20.Name = "CarotidPul"; htTemp20.Value = mytempDetaile[20]; list.Add(htTemp20);
            //htTemp21.Name = "Thorax"; htTemp21.Value = mytempDetaile[21]; list.Add(htTemp21);
            //htTemp22.Name = "Rib"; htTemp22.Value = mytempDetaile[22]; list.Add(htTemp22);
            //htTemp23.Name = "Breathing"; htTemp23.Value = mytempDetaile[23]; list.Add(htTemp23);
            //htTemp24.Name = "Sounds"; htTemp24.Value = mytempDetaile[24]; list.Add(htTemp24);
            //htTemp25.Name = "Rales"; htTemp25.Value = mytempDetaile[25]; list.Add(htTemp25);
            //htTemp26.Name = "Wheeze"; htTemp26.Value = mytempDetaile[26]; list.Add(htTemp26);
            //htTemp27.Name = "Bulging"; htTemp27.Value = mytempDetaile[27]; list.Add(htTemp27);
            //htTemp28.Name = "Varices"; htTemp28.Value = mytempDetaile[28]; list.Add(htTemp28);
            //htTemp29.Name = "Kidney"; htTemp29.Value = mytempDetaile[29]; list.Add(htTemp29);
            //htTemp30.Name = "Pain"; htTemp30.Value = mytempDetaile[30]; list.Add(htTemp30);
            //htTemp31.Name = "Rebound"; htTemp31.Value = mytempDetaile[31]; list.Add(htTemp31);
            //htTemp32.Name = "Liver"; htTemp32.Value = mytempDetaile[32]; list.Add(htTemp32);
            //htTemp33.Name = "Spleen"; htTemp33.Value = mytempDetaile[33]; list.Add(htTemp33);
            //htTemp34.Name = "Murphy"; htTemp34.Value = mytempDetaile[34]; list.Add(htTemp34);
            //htTemp35.Name = "Dullness"; htTemp35.Value = mytempDetaile[35]; list.Add(htTemp35);
            //htTemp36.Name = "HeartRate"; htTemp36.Value = mytempDetaile[36]; list.Add(htTemp36);
            //htTemp37.Name = "Muscle"; htTemp37.Value = mytempDetaile[37]; list.Add(htTemp37);
            //htTemp38.Name = "Cardiovert"; htTemp38.Value = mytempDetaile[38]; list.Add(htTemp38);
            //htTemp39.Name = "HeartBorde"; htTemp39.Value = mytempDetaile[39]; list.Add(htTemp39);
            //htTemp40.Name = "HeartSound"; htTemp40.Value = mytempDetaile[40]; list.Add(htTemp40);
            //htTemp41.Name = "ValveNoise"; htTemp41.Value = mytempDetaile[41]; list.Add(htTemp41);
            //htTemp42.Name = "Spine"; htTemp42.Value = mytempDetaile[42]; list.Add(htTemp42);
            //htTemp43.Name = "Limb"; htTemp43.Value = mytempDetaile[43]; list.Add(htTemp43);
            //htTemp44.Name = "MuscleTone"; htTemp44.Value = mytempDetaile[44]; list.Add(htTemp44);
            //htTemp45.Name = "Reflex"; htTemp45.Value = mytempDetaile[45]; list.Add(htTemp45);
            //htTemp46.Name = "Pathology"; htTemp46.Value = mytempDetaile[46]; list.Add(htTemp46);
            //htTemp47.Name = "Trauma"; htTemp47.Value = mytempDetaile[47]; list.Add(htTemp47);
            //htTemp48.Name = "Check"; htTemp48.Value = mytempDetaile[48]; list.Add(htTemp48);
            //htTemp49.Name = "Sugar"; htTemp49.Value = mytempDetaile[49]; list.Add(htTemp49);
            //htTemp50.Name = "Saturation"; htTemp50.Value = mytempDetaile[50]; list.Add(htTemp50);
            //htTemp51.Name = "BaseOther"; htTemp51.Value = mytempDetaile[51]; list.Add(htTemp51);
            //htTemp52.Name = "ECG"; htTemp52.Value = mytempDetaile[52]; list.Add(htTemp52);
            //htTemp53.Name = "AppOther"; htTemp53.Value = mytempDetaile[53]; list.Add(htTemp53);
            //htTemp54.Name = "Nasal"; htTemp54.Value = mytempDetaile[54]; list.Add(htTemp54);
            //htTemp55.Name = "Mask"; htTemp55.Value = mytempDetaile[55]; list.Add(htTemp55);
            //htTemp56.Name = "Guardian"; htTemp56.Value = mytempDetaile[56]; list.Add(htTemp56);
            //htTemp57.Name = "Suction"; htTemp57.Value = mytempDetaile[57]; list.Add(htTemp57);
            //htTemp58.Name = "Needle"; htTemp58.Value = mytempDetaile[58]; list.Add(htTemp58);
            //htTemp59.Name = "Cardiac"; htTemp59.Value = mytempDetaile[59]; list.Add(htTemp59);
            //htTemp60.Name = "Cooling"; htTemp60.Value = mytempDetaile[60]; list.Add(htTemp60);
            //htTemp61.Name = "Debrideme"; htTemp61.Value = mytempDetaile[61]; list.Add(htTemp61);
            //htTemp62.Name = "Hemosta"; htTemp62.Value = mytempDetaile[62]; list.Add(htTemp62);
            //htTemp63.Name = "StopBlood"; htTemp63.Value = mytempDetaile[63]; list.Add(htTemp63);
            //htTemp64.Name = "Cavity"; htTemp64.Value = mytempDetaile[64]; list.Add(htTemp64);
            //htTemp65.Name = "Fixed"; htTemp65.Value = mytempDetaile[65]; list.Add(htTemp65);
            //htTemp66.Name = "Press"; htTemp66.Value = mytempDetaile[66]; list.Add(htTemp66);
            //htTemp67.Name = "Deliver"; htTemp67.Value = mytempDetaile[67]; list.Add(htTemp67);
            //htTemp68.Name = "Other"; htTemp68.Value = mytempDetaile[68]; list.Add(htTemp68);
            //htTemp69.Name = "Vein"; htTemp69.Value = mytempDetaile[69]; list.Add(htTemp69);
            //htTemp70.Name = "Push"; htTemp70.Value = mytempDetaile[70]; list.Add(htTemp70);
            //htTemp71.Name = "Drip"; htTemp71.Value = mytempDetaile[71]; list.Add(htTemp71);
            //htTemp72.Name = "Injection"; htTemp72.Value = mytempDetaile[72]; list.Add(htTemp72);
            //htTemp73.Name = "Oral"; htTemp73.Value = mytempDetaile[73]; list.Add(htTemp73);
            //htTemp74.Name = "Tongue"; htTemp74.Value = mytempDetaile[74]; list.Add(htTemp74);
            //htTemp75.Name = "Intubation"; htTemp75.Value = mytempDetaile[75]; list.Add(htTemp75);
            //htTemp76.Name = "Saccule"; htTemp76.Value = mytempDetaile[76]; list.Add(htTemp76);
            //htTemp77.Name = "Breathe"; htTemp77.Value = mytempDetaile[77]; list.Add(htTemp77);
            //htTemp78.Name = "Defibrilla"; htTemp78.Value = mytempDetaile[78]; list.Add(htTemp78);
            //htTemp79.Name = "NasalZ"; htTemp79.Value = mytempDetaile[79]; list.Add(htTemp79);
            //htTemp80.Name = "OnTheWay"; htTemp80.Value = mytempDetaile[80]; list.Add(htTemp80);
            //htTemp81.Name = "SacculeZ"; htTemp81.Value = mytempDetaile[81]; list.Add(htTemp81);
            //htTemp82.Name = "BreatheZ"; htTemp82.Value = mytempDetaile[82]; list.Add(htTemp82);

            #endregion

            bool save = false;

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            if (ModelState.IsValid)
            {
                try
                {
                    save = MedicalManagement.SavePhysical(list, PatientRecordID);
                }
                catch (Exception e)
                {
                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SavePhysical()", e.ToString());
                    save = false;
                }
            }

            return save;
        }

        #endregion

        #region 单条救治记录----添加
        /// <summary>
        /// 添加单条救治记录
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveNursingRecord()
        {
            string type = Request["Type"].ToString();
            string edit = Request["Edit"].ToString();
            //string PersonCode = Request["PersonCode"].ToString();
            string PersonCode = User.Identity.Name.Split('|')[0];
            string PatientRecordID;
            string tempTaskCode = Request["TaskCode"].ToString();
            if (Convert.ToInt32(Request["PatientOrder"]) == 0)
            {
                PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
            }
            else
            {
                if (type == "add" || type == "ManageAdd")
                {
                    PatientRecordID = GetPatientOrder(tempTaskCode).ToString();
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }
                else
                {
                    PatientRecordID = tempTaskCode + Request["PatientOrder"].ToString();
                }

            }
            M_TreatmentRecord TreatmentRecord = new M_TreatmentRecord();
            TreatmentRecord.PatientRecordID = PatientRecordID;
            //TreatmentRecord.ProjectID = Request["ProjectID"];
            TreatmentRecord.TROrder = Request["TROrder"];
            TreatmentRecord.MeasureContent = Request["MeasureContent"];
            if (Request["DoTime"] != null && Request["DoTime"] != "")
            {
                TreatmentRecord.DoTime = Convert.ToDateTime(Request["DoTime"]);
            }
            TreatmentRecord.Results = Request["Results"];
            TreatmentRecord.ResponsClassify = Request["Select1"];
            //TreatmentRecord.Units = Request["Units"];
            if (Request["Units"] != "" && Request["Units"] != null)
            {
                TreatmentRecord.Number = Convert.ToDouble(Request["Number"]);
            }
            //TreatmentRecord.Valuation = Convert.ToDouble(Request["Valuation"]);
            TreatmentRecord.Place = Request["Place"];
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.SaveNursingRecord(TreatmentRecord, type, edit, PersonCode);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveNursingRecord()", e.ToString());
                save = false;
            }

            return save;
        }

        #endregion

        #region 病历模版----添加
        /// <summary>
        /// 添加病历模版
        /// </summary>
        /// <param name="TemplateName">模版名称</param>
        /// <param name="ChiefComplaint">主诉</param>
        /// <param name="PresentHistory">现病史</param>
        /// <param name="MedicalHistory">既往病史</param>
        /// <param name="DrugAllergyHistory">药物过敏史</param>
        /// <param name="Diagnoses">详细诊断</param>
        /// <param name="OnTheWay">途中变化记录</param>
        /// <param name="Type">是否编辑</param>
        /// <returns></returns>
        public bool SaveTemplates(int TemplateID, string TemplateName, string ChiefComplaint, string PresentHistory, string MedicalHistory, string DrugAllergyHistory, string Diagnoses, string OnTheWay, string Type)
        {
            M_Template Template = new M_Template();
            if (Type != "add")
            {
                Template.TemplateID = TemplateID;
            }
            Template.TemplateName = TemplateName;
            Template.ChiefComplaint = ChiefComplaint;
            Template.PresentHistory = PresentHistory;
            Template.MedicalHistory = MedicalHistory;
            Template.DrugAllergyHistory = DrugAllergyHistory;
            Template.Diagnoses = Diagnoses;
            Template.OnTheWay = OnTheWay;
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.SaveTemplates(Template, Type);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveTemplates()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion

        #region 单独用药类型救治措施----添加
        /// <summary>
        /// 添加单独用药类型救治措施
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveRecord()
        {
            string type = Request["Type"].ToString();
            string edit = Request["Edit"].ToString();
            string PersonCode = Request["PersonCode"].ToString();
            string PatientRecordID;
            string tempTaskCode = Request["TaskCode"].ToString();
            string Category = Request["Category"].ToString();
            string GoodsID = Request["GoodsID"].ToString();

            string Price = Request["Price"].ToString();
            if (Convert.ToInt32(Request["PatientOrder"]) == 0)
            {
                PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
            }
            else
            {
                if (type == "add" || type == "ManageAdd")
                {
                    PatientRecordID = GetPatientOrder(tempTaskCode).ToString();
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }
                else
                {
                    PatientRecordID = tempTaskCode + Request["PatientOrder"].ToString();
                }

            }
            M_TreatmentRecord TreatmentRecord = new M_TreatmentRecord();
            TreatmentRecord.ProjectID = Request["ProjectID"];
            TreatmentRecord.PatientRecordID = PatientRecordID;
            TreatmentRecord.ResponsClassify = Request["Select1"];
            TreatmentRecord.TROrder = Request["TROrder"];
            TreatmentRecord.MeasureContent = Request["MeasureContent"];
            if (Request["DoTime"] != null && Request["DoTime"] != "")
            {
                TreatmentRecord.DoTime = Convert.ToDateTime(Request["DoTime"]);
            }
            TreatmentRecord.Results = Request["Results"];
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.SaveRecord(TreatmentRecord, type, edit);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveRecord()", e.ToString());
                save = false;
            }

            return save;
        }

        #endregion

        #region 单独用药中的药品或者耗材----添加
        /// <summary>
        /// 添加单独用药中的药品或者耗材
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveDetailRecord()
        {
            string type = Request["Type"].ToString();
            string PatientRecordID;
            string tempTaskCode = Request["TaskCode"].ToString();
            string Category = Request["Category"].ToString();
            string GoodsID = Request["GoodsID"].ToString();
            string GoodsName = Request["GoodsName"].ToString();
            string Price = Request["Price"].ToString();
            string Spec = Request["Spec"].ToString();
            if (Convert.ToInt32(Request["PatientOrder"]) == 0)
            {
                PatientRecordID = tempTaskCode + (Convert.ToInt32(Request["PatientOrder"]) + 1).ToString();
            }
            else
            {
                if (type == "add" || type == "ManageAdd")
                {
                    PatientRecordID = GetPatientOrder(tempTaskCode).ToString();
                    PatientRecordID = tempTaskCode + (Convert.ToInt32(PatientRecordID) + 1).ToString();
                }
                else
                {
                    PatientRecordID = tempTaskCode + Request["PatientOrder"].ToString();
                }

            }
            M_TreatmentRecord TreatmentRecord = new M_TreatmentRecord();
            TreatmentRecord.ProjectID = Request["ProjectID"];
            TreatmentRecord.PatientRecordID = PatientRecordID;
            TreatmentRecord.TROrder = Request["TROrder"];
            TreatmentRecord.MeasureContent = Request["MeasureContent"];
            if (Request["DoTime"] != null && Request["DoTime"] != "")
            {
                TreatmentRecord.DoTime = Convert.ToDateTime(Request["DoTime"]);
            }
            TreatmentRecord.Results = Request["Results"];


            M_DrugUseRecord DrugUseRecord = new M_DrugUseRecord();
            M_ConsumableRecord M_ConsumableRecord = new M_ConsumableRecord();
            if (Category == "药品")
            {

                DrugUseRecord.PatientRecordID = PatientRecordID;
                if (type != "add")
                {
                    DrugUseRecord.TROrder = Request["TROrder"];
                }
                DrugUseRecord.DrugsID = Convert.ToInt32(GoodsID);
                DrugUseRecord.Num = 1;
                DrugUseRecord.ActualDose = 1;
                DrugUseRecord.Price = Convert.ToDouble(Price);
                DrugUseRecord.GoodsName = GoodsName;
                DrugUseRecord.Spec = Spec;
            }
            else
            {
                //耗材

                M_ConsumableRecord.PatientRecordID = PatientRecordID;
                if (type != "add")
                {
                    M_ConsumableRecord.CROrder = Request["TROrder"];
                }
                M_ConsumableRecord.ResID = Convert.ToInt32(GoodsID);
                M_ConsumableRecord.Num = 1;
                M_ConsumableRecord.Price = Convert.ToDouble(Price);
                M_ConsumableRecord.GoodsName = GoodsName;
                M_ConsumableRecord.Spec = Spec;
            }

            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                if (Category == "药品")
                {
                    save = MedicalManagement.SaveDrugUseRecord(DrugUseRecord, type);
                }
                else
                {
                    save = MedicalManagement.SaveConsumableRecord(M_ConsumableRecord, type);
                }

            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveRecord()", e.ToString());
                save = false;
            }

            return save;
        }

        #endregion

        #region 救治记录的顺序----修改
        /// <summary>
        /// 修改救治记录的顺序
        /// </summary>
        /// <param name="PatientRecordID">救治记录编码</param>
        /// <param name="DoOrder">执行顺序</param>
        /// <returns>bool</returns>
        public bool UpAndDown(string PatientRecordID, string DoOrder)
        {
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.UpAndDown(PatientRecordID, DoOrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/UpAndDown()", e.ToString());
                save = false;
            }

            return save;
        }

        #endregion

        #region 耗材列表中的数量----修改
        public bool EditGoods(string PatientRecordID, string Name, float Num, string UseNum, int ID, string TableName, float LossVal)
        {
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.EditGoods(PatientRecordID, Name.Trim(), Num, UseNum, ID, TableName, LossVal);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/EditGoods()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion

        #region 病例列表中的标识修改
        /// <summary>
        /// 病例列表中的标识修改
        /// </summary>
        /// <param name="Mark">病例标识</param>
        /// <returns></returns>
        public ActionResult SavePatientTableMark(string left, string right, string PatientOrder, string Mark)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            string TaskCode = left + right;
            var result = MedicalManagement.SavePatientTableMark(TaskCode, PatientOrder, Mark);

            return Json(result);
        }
        #endregion

        #region 病例列表中的随访修改
        /// <summary>
        /// 病例列表中的随访修改
        /// </summary>
        /// <param name="M_FollowUpRecord">随访记录</param>
        /// <returns></returns>
        public ActionResult SaveFollowUp(M_FollowUpRecord M_FollowUpRecord)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = MedicalManagement.SaveFollowUp(M_FollowUpRecord);
            return Json(result);
        }
        #endregion

        #region 新增转送记录
        /// <summary>
        /// 新增转送记录
        /// </summary>
        /// <param name="M_TransportRecord">转送记录</param>
        /// <returns></returns>
        public ActionResult SaveFirstAider(M_TransportRecord M_TransportRecord)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            M_TransportRecord.FirstAider = User.Identity.Name.Split('|')[1];
            M_TransportRecord.RecordCreateTime = DateTime.Now;
            var result = MedicalManagement.SaveFirstAider(M_TransportRecord);

            return Json(result);
        }
        #endregion

        #endregion

        #region 查询方法

        #region 病历相关基础信息

        public ActionResult PatientInfoLoad(string TypeCode)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.PatientInfoLoad(TypeCode);

            return Json(result);

        }
        public ActionResult GetOption(string Code)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetOption(Code);

            return Json(result);

        }
        public ActionResult TZLocalAddrTypeLoad()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("TZLocalAddrType");
                if (result == null)
                {
                    result = MedicalManagement.TZLocalAddrTypeLoad();
                    CacheUtility.SetCacheObject("TZLocalAddrType", result);
                }
            }

            return Json(result);

        }
        public ActionResult CmbSendAddrLoad()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("CmbSendAddr");
                if (result == null)
                {
                    result = MedicalManagement.CmbSendAddrLoad();
                    CacheUtility.SetCacheObject("CmbSendAddr", result);
                }
            }

            return Json(result);

        }
        public ActionResult TZSendAddrTypeLoad()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("TZSendAddrType");
                if (result == null)
                {
                    result = MedicalManagement.TZSendAddrTypeLoad();
                    CacheUtility.SetCacheObject("TZSendAddrType", result);
                }
            }

            return Json(result);

        }
        public ActionResult GetHidPrimaryDiagnoses(string Name)
        {
            try
            {
                IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
                List<C_EFFECTIVEDIAGINFO_TREE> cet = MedicalManagement.GetTree(Name);
                this.ViewData["DiagnosesTree"] = this.Json(cet);
                return this.Json(cet);
            }
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                return this.Json(dict);
            }
        }
        public ActionResult IllStateLoad(string TypeCode)
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("IllState");
                if (result == null)
                {
                    result = MedicalManagement.IllStateLoad();
                    CacheUtility.SetCacheObject("IllState", result);
                }
            }

            return Json(result);

        }
        public ActionResult GetMeasure()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("GetMeasure");
                if (result == null)
                {
                    result = MedicalManagement.GetMeasure();
                    CacheUtility.SetCacheObject("GetMeasure", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetDisptcher()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("Disptcher");
                if (result == null)
                {
                    result = MedicalManagement.GetDisptcher();
                    CacheUtility.SetCacheObject("Disptcher", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetTaskAbendReason()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("TaskAbendReason");
                if (result == null)
                {
                    result = MedicalManagement.GetTaskAbendReason();
                    CacheUtility.SetCacheObject("TaskAbendReason", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetStation()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("Station");
                if (result == null)
                {
                    result = MedicalManagement.GetStation();
                    CacheUtility.SetCacheObject("Station", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetAmbulance()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("Ambulance");
                if (result == null)
                {
                    result = MedicalManagement.GetAmbulance();
                    CacheUtility.SetCacheObject("Ambulance", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetAlarmEventType()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("AlarmEventType");
                if (result == null)
                {
                    result = MedicalManagement.GetAlarmEventType();
                    CacheUtility.SetCacheObject("AlarmEventType", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetAccidentType()
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = new object();
            //增加缓存
            lock (m_SyncRoot)
            {
                result = CacheUtility.GetCacheObject("AccidentType");
                if (result == null)
                {
                    result = MedicalManagement.GetAccidentType();
                    CacheUtility.SetCacheObject("AccidentType", result);
                }
            }

            return Json(result);
        }
        public ActionResult GetGlasgow(int ID)
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            var result = MedicalManagement.GetGlasgow(ID);
            return Json(result);
        }
        #endregion

        #region 任务列表

        /// <summary>
        /// 加载全部任务数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="Driver">司机</param>
        /// <param name="Doctor">医生</param>
        /// <param name="Disptcher">调度员</param>
        /// <param name="StretcherBearers">担架工</param>
        /// <param name="LinkPhone">联系电话</param>
        /// <param name="LocalAdd">现场地址</param>
        /// <param name="TaskResult">出车结果</param>
        /// <param name="Station">分站</param>
        /// <param name="Ambulance">车辆</param>
        /// <param name="AlarmEventType">事件类型</param>
        /// <param name="IsFill">是否填写病历</param>
        /// <param name="IsCharge">收费情况</param>
        /// <param name="IsDoc">是否医生</param>
        /// <param name="PatientName">患者姓名</param>
        /// <returns>Json</returns>
        public ActionResult MedicalManagementLoad(int page, int rows, string order, string sort, DateTime start, DateTime end, string Driver, string Doctor, string Disptcher,
            string StretcherBearers, string LinkPhone, string LocalAdd, string TaskResult, string Station, string Ambulance, string AlarmEventType, string IsFill, string IsCharge, string IsDoc, string PatientName)
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            if (IsDoc == "0" || IsDoc == "1")
            {
                var result = MedicalManagement.LoadAllByPage(page, rows, order, sort, start, end, Driver, Doctor, Disptcher,
                    StretcherBearers, LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PatientName);
                return Json(result);
            }
            else
            {
                List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                string PersonID = "";
                if (workRole[0] != null)
                {
                    int i = 1;
                    foreach (var item in workRole)
                    {

                        if (workRole.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(item.EmpNo))
                            {
                                PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                            }
                        }
                        else
                        {
                            if (workRole.Count == i)
                            {
                                if (!string.IsNullOrEmpty(item.EmpNo))
                                {
                                    PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                                }

                            }
                            else
                            {
                                if (item.EmpNo != null && item.EmpNo != "")
                                {
                                    if (i > 1)
                                    {
                                        if (!string.IsNullOrEmpty(item.EmpNo))
                                        {
                                            PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码 + ",";
                                        }
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(item.EmpNo))
                                        {
                                            PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                                        }
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
                try
                {
                    var result = MedicalManagement.GetAllByPage(page, rows, order, sort, start, end, Driver, Doctor, Disptcher, StretcherBearers,
                    LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PersonID, PatientName);
                    return Json(result);
                }
                catch (Exception e)
                {
                    string log = string.Format(@"page:{0}, rows:{1}, order:{2}, sort:{3}, start:{4}, end:{5}, Driver:{6}, Doctor:{7}, Disptcher:{8}, StretcherBearers:{9},
                    LinkPhone:{10}, LocalAdd:{11}, TaskResult:{12}, Station:{13}, Ambulance:{14}, AlarmEventType:{15}, IsFill:{16}, IsCharge:{17}, PersonID:{18}, PatientName:{19}", page, rows, order, sort, start, end, Driver, Doctor, Disptcher, StretcherBearers,
                    LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PersonID, PatientName);

                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetAllByPage()", log + e.ToString());
                    return null;
                }

            }
        }

        #endregion

        #region 急救员转送记录

        /// <summary>
        /// 加载全部急救员转送记录
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="Driver">司机</param>
        /// <param name="Doctor">医生</param>
        /// <param name="Disptcher">调度员</param>
        /// <param name="StretcherBearers">担架工</param>
        /// <param name="LinkPhone">联系电话</param>
        /// <param name="LocalAdd">现场地址</param>
        /// <param name="TaskResult">出车结果</param>
        /// <param name="Station">分站</param>
        /// <param name="Ambulance">车辆</param>
        /// <param name="AlarmEventType">事件类型</param>
        /// <param name="IsFill">是否填写病历</param>
        /// <param name="IsCharge">收费情况</param>
        /// <param name="IsDoc">是否医生</param>
        /// <param name="PatientName">患者姓名</param>
        /// <returns>Json</returns>
        public ActionResult MedicalFirstAiderLoad(int page, int rows, string order, string sort, DateTime start, DateTime end, string Driver, string Doctor, string Disptcher,
            string StretcherBearers, string LinkPhone, string LocalAdd, string TaskResult, string Station, string Ambulance, string AlarmEventType, string IsFill, string IsCharge, string IsDoc, string PatientName)
        {

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            if (IsDoc == "0" || IsDoc == "1")
            {
                var result = MedicalManagement.LoadFirstAiderAllByPage(page, rows, order, sort, start, end, Driver, Doctor, Disptcher,
                    StretcherBearers, LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PatientName);
                return Json(result);
            }
            else
            {
                List<B_WORKER_ROLE> workRole = GetWorkRole(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                string PersonID = "";
                if (workRole[0] != null)
                {
                    int i = 1;
                    foreach (var item in workRole)
                    {

                        if (workRole.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(item.EmpNo))
                            {
                                PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                            }
                        }
                        else
                        {
                            if (workRole.Count == i)
                            {
                                if (!string.IsNullOrEmpty(item.EmpNo))
                                {
                                    PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                                }

                            }
                            else
                            {
                                if (item.EmpNo != null && item.EmpNo != "")
                                {
                                    if (i > 1)
                                    {
                                        if (!string.IsNullOrEmpty(item.EmpNo))
                                        {
                                            PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码 + ",";
                                        }
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(item.EmpNo))
                                        {
                                            PersonID += GetOldPersonID(Convert.ToInt32(item.EmpNo)).编码;
                                        }
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
                try
                {
                    var result = MedicalManagement.GetFirstAiderAllByPage(page, rows, order, sort, start, end, Driver, Doctor, Disptcher, StretcherBearers,
                    LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PersonID, PatientName);
                    return Json(result);
                }
                catch (Exception e)
                {
                    string log = string.Format(@"page:{0}, rows:{1}, order:{2}, sort:{3}, start:{4}, end:{5}, Driver:{6}, Doctor:{7}, Disptcher:{8}, StretcherBearers:{9},
                    LinkPhone:{10}, LocalAdd:{11}, TaskResult:{12}, Station:{13}, Ambulance:{14}, AlarmEventType:{15}, IsFill:{16}, IsCharge:{17}, PersonID:{18}, PatientName:{19}", page, rows, order, sort, start, end, Driver, Doctor, Disptcher, StretcherBearers,
                    LinkPhone, LocalAdd, TaskResult, Station, Ambulance, AlarmEventType, IsFill, IsCharge, PersonID, PatientName);

                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetAllByPage()", log + e.ToString());
                    return null;
                }

            }
        }

        #endregion

        #region 根据任务表获取病历相关信息
        public ActionResult GetAddPatient(string type, string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            C_Patient result = MedicalManagement.GetAddPatient(type, TaskCode);
            this.ViewData["Entity"] = result;
            return Json(result);
        }

        #endregion

        #region 根据病历ID获取病历修改记录
        public ActionResult GetUpdateLog(string PatientRecordID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetUpdateLog(PatientRecordID);
            return Json(result);
        }

        #endregion

        #region 救治记录列表

        /// <summary>
        /// 加载救治记录列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <param name="IsEdit">是否编辑</param>
        /// <returns></returns>
        public ActionResult GetMeasureRecord(int page, int rows, string order, string sort, string TaskCode, string PatientOrder, string IsEdit, string GroupID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            //if (PatientOrder != "0")
            //{
            //    if (IsEdit == "add" || IsEdit == "ManageAdd")
            //    {
            //        PatientOrder = GetPatientOrder(TaskCode).ToString();
            //    }
            //}
            var result = MedicalManagement.GetMeasureRecord(page, rows, order, sort, TaskCode, PatientOrder, IsEdit, GroupID);

            return Json(result);
        }

        #endregion

        #region 获取根据救治记录ID跟病历ID获取药品耗材名称
        /// <summary>
        ///  获取根据救治记录ID跟病历ID获取药品耗材名称
        /// </summary>
        /// <param name="PatientRecordID">病历ID</param>
        /// <param name="TROrde">救治记录ID</param>
        /// <returns></returns>
        public object GetPatientGoodNames(string PatientRecordID, string TROrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var GoodNames = MedicalManagement.GetPatientGoodNames(PatientRecordID, TROrder);

            return GoodNames;
        }
        #endregion

        #region 耗材或者药品记录

        public ActionResult GetGoodsName(int page, int rows, string order, string sort, string PatientRecordID, string ProjectID, string TROrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetGoodsName(page, rows, order, sort, PatientRecordID, ProjectID, TROrder);

            return Json(result);

        }
        #endregion

        #region 耗材或者药品记录-单独用药
        public int GetGoodsNameRecord(string PatientRecordID, string Edit)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            int result = MedicalManagement.GetGoodsNameRecord(PatientRecordID, Edit);

            return result;

        }
        #endregion

        #region 病例-打印内容
        /// <summary>
        /// 病例打印
        /// </summary>
        /// <param name="left">任务编码-左</param>
        /// <param name="right">任务编码-右</param>
        /// <param name="OrderID">病例编号</param>
        /// <param name="PatientID">病例ID</param>
        /// <returns></returns>
        public ActionResult PatientReportLoad(string left, string right, string OrderID, string PatientID)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            string TaskID = left + right;
            PatientID = TaskID + OrderID;
            map.Add("TaskID", TaskID);
            map.Add("xh", OrderID);
            map.Add("PatientID", PatientID);

            string rootpath = Server.MapPath("/Areas/Report/ReportBuf/");
            string filename = Anchor.FA.Utility.ExcelReportFactory.CreateReport(rootpath, "Patient.xls", "Patient.ds", map);

            return Json("/Areas/Report/ReportBuf/" + filename);
        }
        public ActionResult SavePatientReport(string left, string right, string PatientOrder)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            string TaskCode = left + right;

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.SavePatientReport(TaskCode, PatientOrder);

            return Json(result);
        }
        public ActionResult SavePatientStatus(string left, string right, string PatientOrder)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            string TaskCode = left + right;

            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.SavePatientStatus(TaskCode, PatientOrder);

            return Json(result);
        }
        #endregion

        #region 病历列表-病历管理

        /// <summary>
        /// 病历管理中获取病历列表的方法
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="TaskID">任务编码</param>
        /// <returns></returns>
        public ActionResult MedicalManagementPatientLoad(int page, int rows, string order, string sort, string TaskID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            TTaskPersonLink TTaskPersonLink = MedicalManagement.GetPersonID(TaskID);
            string UserId = "";
            if (TTaskPersonLink != null)
            {
                UserId = TTaskPersonLink.人员编码;
            }

            var result = MedicalManagement.LoadAllPatientByPage(page, rows, order, sort, TaskID, UserId);

            return Json(result);

        }

        #endregion

        #region 根据任务编码获取病例序号的最大值
        /// <summary>
        /// 根据病例ID加载救治记录中序号的最大值
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <returns>object</returns>
        public int GetPatientOrder(string TaskCode)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            int result = MedicalManagement.GetPatientOrder(TaskCode);

            return result;

        }

        #endregion

        #region 根据任务编码获取用药跟耗材序号的最大值
        /// <summary>
        /// 根据任务编码获取用药跟耗材序号的最大值
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <returns>object</returns>
        public int GetDrugRecord(string PatientRecordID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            int result = MedicalManagement.GetDrugRecord(PatientRecordID);

            return result;

        }

        #endregion

        #region 是否存在救治记录

        /// <summary>
        /// 根据病例ID判断是否存在救治记录
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <param name="IsEdit">是否编辑</param>
        /// <returns>object</returns>
        public bool GetMeasureRecordCount(string TaskCode, string PatientOrder, string IsEdit)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.GetMeasureRecordCount(TaskCode, PatientOrder, IsEdit);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetMeasureRecordCount()", e.ToString());
                save = false;
            }
            return save;
        }
        #endregion

        #region 单独用药记录数

        /// <summary>
        /// 根据病例ID加载单独用药记录数
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <param name="IsEdit">是否编辑</param>
        /// <returns>object</returns>
        public bool GetRecord(string TaskCode, string PatientOrder, string IsEdit, string TROrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                //TROrder = (GetDrugRecord(TaskCode + PatientOrder) + 1).ToString();

                save = MedicalManagement.GetRecord(TaskCode, PatientOrder, IsEdit, TROrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetRecord()", e.ToString());
                save = false;
            }
            return save;
        }

        #endregion

        #region 角色

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="workerID">人员编码</param>
        /// <returns>List<B_WORKER_ROLE></returns>
        public List<B_WORKER_ROLE> GetWorkRole(int workerID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement; ;
            List<B_WORKER_ROLE> roleID = MedicalManagement.GetWorkRole(workerID);
            return roleID;
        }

        #endregion

        #region 获取老版人员编码

        /// <summary>
        /// 获取老版人员编码
        /// </summary>
        /// <param name="workerID">人员编码</param>
        /// <returns>List<TPerson></returns>
        public TPerson GetOldPersonID(int workerID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement; ;
            TPerson PersonID = MedicalManagement.GetOldPersonID(workerID);
            return PersonID;
        }

        #endregion


        #region 获取Utstein基本信息

        /// <summary>
        /// 获取Utstein基本信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <param name="Type">病历填写状态</param>
        /// <returns>C_Utsteins</returns>
        public C_Utsteins GetUtsteins(string TaskCode, string PatientOrder, string Type)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            C_Utsteins Utsteins = MedicalManagement.GetUtsteins(TaskCode, PatientOrder, Type);
            return Utsteins;
        }

        #endregion

        #region Utstein记录数

        /// <summary>
        /// Utstein基本信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns>M_Utstein</returns>
        public M_Utstein GetUtstein(string TaskCode, string PatientOrder, string Type)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            M_Utstein Utsteins = MedicalManagement.GetUtsteinsCount(TaskCode, PatientOrder, Type);
            return Utsteins;
        }

        #endregion

        #region 是否填写Utstein基本信息

        /// <summary>
        /// 是否填写Utstein基本信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns>int</returns>
        public int GetUtsteinsCount(string TaskCode, string PatientOrder, string Type)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            M_Utstein Utsteins = MedicalManagement.GetUtsteinsCount(TaskCode, PatientOrder, Type);
            int count;
            if (Utsteins != null)
            {
                count = 1;
            }
            else
            {
                count = 0;
            }
            return count;
        }

        #endregion

        #region 病历模版列表
        /// <summary>
        /// 获取病历模版列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="TemplateName">模版名称</param>
        /// <returns></returns>
        public ActionResult GetTAllTemplate(int page, int rows, string order, string sort, string TemplateName)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetTAllTemplate(page, rows, order, sort, TemplateName);

            return Json(result);
        }
        #endregion

        #region 获取病历模版
        /// <summary>
        /// 获取病历模版
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTemplate()
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetTemplate();

            return Json(result);
        }
        #endregion

        #region 病历模版
        /// <summary>
        /// 获取病历模版列表
        /// </summary>
        /// <param name="TemplateName">模版名称</param>
        /// <returns></returns>
        public ActionResult GetAllTemplate(string TemplateName)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetAllTemplate(TemplateName);

            return Json(result);
        }
        #endregion

        #region 个人库存药品
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="categoryID"></param>
        /// <param name="name"></param>
        /// <param name="num"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public ActionResult GoodsLoad(int page, int rows, string order, string sort, string categoryID, string name, int? num, string text)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GoodsLoad(page, rows, order, sort, categoryID, name, num, text);

            return Json(result);
        }
        #endregion

        #region 获取填写的体格检查信息
        /// <summary>
        /// 获取填写的体格检查信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">序号</param>
        /// <returns></returns>
        public ActionResult GetPhysical(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                List<C_TreatmentRecord> result = MedicalManagement.GetPhysical(TaskCode, PatientOrder);
                return Json(result);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetPhysical()", e.ToString());
                return null;
            }

            //C_Physical C_Physical = new C_Physical();
            //foreach (M_TreatmentRecord mtr in result)
            //{
            //    #region 基础

            //    if (mtr.ProjectID == "Blood")
            //    {
            //        C_Physical.Blood = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Pulse")
            //    {
            //        C_Physical.Pulse = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Respiratio")
            //    {
            //        C_Physical.Respiratio = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Temperatur")
            //    {
            //        C_Physical.Temperatur = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Mind")
            //    {
            //        C_Physical.Mind = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Pupil")
            //    {
            //        C_Physical.Pupil = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Refle")
            //    {
            //        C_Physical.Refle = mtr.MeasureContent;
            //    }

            //    #endregion

            //    #region 体检

            //    if (mtr.ProjectID == "Pate")
            //    {
            //        C_Physical.Pate = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Heart")
            //    {
            //        C_Physical.Heart = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "DoubleLung")
            //    {
            //        C_Physical.DoubleLung = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Chest")
            //    {
            //        C_Physical.Chest = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Belly")
            //    {
            //        C_Physical.Belly = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "Limbs")
            //    {
            //        C_Physical.Limbs = mtr.MeasureContent;
            //    }
            //    if (mtr.ProjectID == "HZOther")
            //    {
            //        C_Physical.HZOther = mtr.MeasureContent;
            //    }

            //    #endregion

            //    #region 辅助检查

            //    if (mtr.ProjectID == "Sugar")
            //    {
            //        C_Physical.Sugar = mtr.MeasureContent;
            //    }

            //    if (mtr.ProjectID == "Saturation")
            //    {
            //        C_Physical.Saturation = mtr.MeasureContent;
            //    }

            //    if (mtr.ProjectID == "ECG")
            //    {
            //        C_Physical.ECG = "true";
            //    }

            //    #endregion
            //}

        }
        #endregion

        #region 是否需要选择致伤原因
        /// <summary>
        /// 是否需要选择致伤原因
        /// </summary>
        /// <param name="TemplateName">编码集合</param>
        /// <returns>bool</returns>
        public bool GetInjuredReason(string TemplateName)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            bool save = false;
            if (TemplateName != null)
            {
                try
                {
                    save = MedicalManagement.GetInjuredReason(TemplateName);
                }
                catch (Exception e)
                {
                    Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetInjuredReason()", e.ToString());
                    save = false;
                }
            }
            return save;
        }
        #endregion

        #region 是否填写随访基本信息

        /// <summary>
        /// 是否填写随访基本信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历序号</param>
        /// <returns>ActionResult</returns>
        public ActionResult GetFollowUpCount(string left, string right, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            string TaskCode = left + right;
            var result = MedicalManagement.GetFollowUpCount(TaskCode, PatientOrder);
            return Json(result);
        }
        #endregion

        #region 获取转送记录信息

        /// <summary>
        /// 获取转送记录信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="TROrder">序号</param>
        /// <returns>ActionResult</returns>
        public ActionResult GetFirstAider(string TaskCode, string TROrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetFirstAider(TaskCode, TROrder);
            return Json(result);
        }
        #endregion

        #endregion

        #region 删除方法

        #region 救治记录----全部

        /// <summary>
        /// 根据病例ID删除救治记录
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <returns>bool</returns>
        public bool DeleteNursingRecord(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.DeleteNursingRecord(TaskCode, PatientOrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeleteNursingRecord()", e.ToString());
                save = false;
            }
            return save;
        }

        #endregion

        #region 救治记录----根据序号删除
        /// <summary>
        /// 根据序号删除救治记录
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <param name="TROrder">序号</param>
        /// <returns>Bool</returns>
        public bool DeleteSingleNursingRecord(string TaskCode, string PatientOrder, string TROrder, string Type)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.DeleteSingleNursingRecord(TaskCode, PatientOrder, TROrder, Type);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeleteNursingRecord()", e.ToString());
                save = false;
            }
            return save;
        }

        #endregion

        #region 耗材列表中的列
        public bool deleteGoods(string PatientRecordID, int ID, string TableName)
        {
            bool save = false;
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            try
            {
                save = MedicalManagement.deleteGoods(PatientRecordID, ID, TableName);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/deleteGoods()", e.ToString());
                save = false;
            }

            return save;
        }
        #endregion

        #region 单独用药记录

        /// <summary>
        /// 删除单独用药记录
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <returns>bool</returns>
        public bool DeleteRecord(string TaskCode, string PatientOrder, string Edit, string tempOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                if (PatientOrder != "0")
                {
                    if (Edit == "add" || Edit == "ManageAdd")
                    {
                        PatientOrder = GetPatientOrder(TaskCode).ToString();
                    }
                }
                save = MedicalManagement.DeleteRecord(TaskCode, PatientOrder, Edit, tempOrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeleteRecord()", e.ToString());
                save = false;
            }
            return save;
        }

        #endregion

        #region 病例

        /// <summary>
        /// 根据病例ID删除病例
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病例序号</param>
        /// <returns>object</returns>
        public bool DeletePatient(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.DeletePatient(TaskCode, PatientOrder);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeletePatient()", e.ToString());
                save = false;
            }
            return save;
        }

        #endregion

        #region 删除转运记录
        /// <summary>
        /// 根据病例ID删除病例
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <returns>bool</returns>
        public bool DeleteFirstAider(string TaskCode)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.DeleteFirstAider(TaskCode);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeleteFirstAider()", e.ToString());
                save = false;
            }
            return save;
        }
        #endregion

        #region 病历模版
        /// <summary>
        /// 删除病历模版
        /// </summary>
        /// <param name="TemplateID"></param>
        /// <returns></returns>
        public bool DeleteTemplate(int TemplateID)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
            bool save = false;
            try
            {
                save = MedicalManagement.DeleteTemplate(TemplateID);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DeleteTemplate()", e.ToString());
                save = false;
            }
            return save;
        }
        #endregion

        #endregion

        #endregion

        #region 收费

        #region 收费页面----初始化
        /// <summary>
        /// 收费页面加载方法
        /// </summary>
        /// <param name="code">任务编码</param>
        /// <param name="OrderCode">病例序号</param>
        /// <returns></returns>
        public ActionResult ChargeDetail(string code, string OrderCode, string TaskID, string type)
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            IAccidentPatient MedicalManagement = ctx["NewPatient"] as IAccidentPatient;
            this.ViewData["IsPatientAudit"] = AppConfig.IsPatientAudit;
            if (code == "null")
            {
                code = TaskID;
            }
            if (OrderCode != "9" && OrderCode != "null")
            {
                M_PatientRecord patient = MedicalManagement.queryByPrimaryKey(code, int.Parse(OrderCode));
                this.ViewData["patientEntity"] = patient;
                this.ViewData["StretcherBearers"] = patient.StretcherBearersI + "," + patient.StretcherBearersII;
            }
            else
            {
                M_PatientRecord patient = new M_PatientRecord();
                patient.Name = "";
                patient.Sex = "";
                patient.Age = "";
                patient.IllnessSort = "";
                patient.FirstAideEffect = "";

                patient.Doctor = "";
                patient.Nurse = "";
                patient.Driver = "";
                patient.StretcherBearersI = "";
                patient.StretcherBearersII = "";
                patient.Station = "";
                this.ViewData["patientEntity"] = patient;
                this.ViewData["StretcherBearers"] = patient.StretcherBearersI + "," + patient.StretcherBearersII;
            }

            string ChargeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.ViewData["ChargeTime"] = ChargeTime;
            this.ViewData["entity"] = charge.GetBasicInfo(code);
            M_ChargeMain main = charge.GetNewChargeMain(code, OrderCode);
            this.ViewData["entity2"] = main;
            this.ViewData["reason"] = main.OweReason;
            if (main.IsInvalid == true)
            {
                this.ViewData["IsInvalid"] = "是";
            }
            if (main.IsInvalid == false)
            {
                this.ViewData["IsInvalid"] = "否";
            }
            if (main.IsInvalid == null)
            {
                this.ViewData["IsInvalid"] = "--请选择--";
            }
            if (main.BillType != null)
            {
                this.ViewData["BillType"] = main.BillType;
            }
            else
            {
                this.ViewData["BillType"] = "--请选择--";
            }

            this.ViewData["taskcode"] = code;
            this.ViewData["OrderCode"] = OrderCode;
            this.ViewData["type"] = type;
            ViewData["WorkID"] = User.Identity.Name.Split('|')[0];
            return View();
        }
        #endregion

        #region 收费审核----初始化
        /// <summary>
        /// 加载收费审核页面方法
        /// </summary>
        /// <param name="FlowNo">工作流表单号</param>
        /// <returns>ActionResult</returns>
        public ActionResult ChargeView(int FlowNo)
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            IAccidentPatient MedicalManagement = ctx["NewPatient"] as IAccidentPatient;
            IFlow flow = ctx["Flow"] as IFlow;

            M_ChargeMain main = charge.GetChargeMain(FlowNo);
            this.ViewData["entity2"] = main;
            this.ViewData["reason"] = main.OweReason;
            this.ViewData["taskcode"] = main.TaskID;
            this.ViewData["OrderCode"] = main.PatientID.Substring(20, 1);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(int.Parse(Request.QueryString["flowInstId"]));

            if (main.PatientID.Substring(20, 1) != "9" && main.PatientID.Substring(20, 1) != "null")
            {
                M_PatientRecord patient = MedicalManagement.queryByPrimaryKey(main.TaskID, int.Parse(main.PatientID.Substring(20, 1)));
                this.ViewData["patientEntity"] = patient;
            }
            else
            {
                M_PatientRecord patient = new M_PatientRecord();
                patient.Name = "";
                patient.Sex = "";
                patient.Age = "";
                patient.IllnessSort = "";
                patient.IllnessChange = "";
                this.ViewData["patientEntity"] = patient;
            }

            string ChargeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.ViewData["ChargeTime"] = ChargeTime;
            this.ViewData["entity"] = charge.GetBasicInfo(main.TaskID);

            return View();
        }
        #endregion

        #region 收费明细项
        /// <summary>
        /// 加载收费明细项
        /// </summary>
        /// <param name="taskcode">任务编码</param>
        /// <param name="OrderCode">病历序号</param>
        /// <returns></returns>
        public ActionResult ChargeDetailLoad(string taskcode, string OrderCode)
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            var result = charge.ChargeDetailLoad(taskcode, OrderCode);
            return Json(result);
        }
        #endregion

        #region 根据病历ID获取收费项对应默认收费明细
        /// <summary>
        /// 根据病历ID获取收费项对应默认收费明细
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="OrderCode">病历序号</param>
        /// <returns>ActionResult</returns>
        public ActionResult GetChargeRecord(string TaskCode, string OrderCode, string ItemName)
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            var result = charge.GetChargeRecord(TaskCode, OrderCode, ItemName);

            return Json(result);

        }
        #endregion

        #region 病历列表

        /// <summary>
        /// 病历管理中获取病历列表的方法
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">分页行数</param>
        /// <param name="order">排序</param>
        /// <param name="sort">排序字段</param>
        /// <param name="TaskID">任务编码</param>
        /// <returns></returns>
        public ActionResult GetChargeTable(int page, int rows, string order, string sort, string TaskCode)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetChargeTable(page, rows, order, sort, TaskCode);

            return Json(result);

        }

        #endregion

        #region 是否填写收费信息
        /// <summary>
        /// 是否填写收费信息
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">序号</param>
        /// <returns></returns>
        public ActionResult GetAllCharge(string TaskCode, string PatientOrder)
        {
            IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;

            var result = MedicalManagement.GetAllCharge(TaskCode, PatientOrder);

            return Json(result);
        }
        #endregion

        #region 应收总额
        public ActionResult GetSumAmount(string taskcode, string OrderCode)
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            var result = charge.GetSumAmount(taskcode, OrderCode);

            return Json(result);
        }
        #endregion

        #region 保存收费信息
        /// <summary>
        /// 保存收费信息
        /// </summary>
        /// <returns>Bool</returns>
        public bool SaveChargeDetail()
        {
            string type = Request["Type"].ToString();

            #region 为收费主表实例赋值

            M_ChargeMain ChargeMain = new M_ChargeMain();
            ChargeMain.KM = Convert.ToDouble(Request["Kilometre"]);
            ChargeMain.BillNo = Request["Charge_Code"];
            if (Request["OweReason"] != "请选择")
            {
                ChargeMain.OweReason = Request["OweReason"];
            }
            ChargeMain.TaskID = Request["TaskCode"];
            string Order = Request["OrderCode"].ToString();
            if (Order == "null")
            {
                ChargeMain.PatientID = Request["TaskCode"] + "9";
            }
            else
            {
                ChargeMain.PatientID = Request["TaskCode"] + Request["OrderCode"];
            }
            ChargeMain.WorkID = Convert.ToInt32(Request["WorkID"]);
            if (Request["ChargeTime"] != null && Request["ChargeTime"] != "")
            {
                ChargeMain.ChargeTime = Convert.ToDateTime(Request["ChargeTime"]);
            }
            if (Request["IsOweFee"] == "是")
            {
                ChargeMain.IsOweFee = true;
            }
            else
            {
                ChargeMain.IsOweFee = false;
            }
            if (Request["OriCharge"] != "" && Request["OriCharge"] != null)
            {
                ChargeMain.ShouldIn = Convert.ToDouble(Request["OriCharge"]);
            }
            if (Request["RealCharge"] != "" && Request["RealCharge"] != null)
            {
                ChargeMain.RealIn = Convert.ToDouble(Request["RealCharge"]);
            }
            if (Request["IsInvalid"] == "是")
            {
                ChargeMain.IsInvalid = true;
            }
            if (Request["IsInvalid"] == "否")
            {
                ChargeMain.IsInvalid = false;
            }
            if (Request["IsInvalid"] == "--请选择--")
            {
                ChargeMain.IsInvalid = null;
            }
            if (Request["BillType"] != "" && Request["BillType"] != null)
            {
                ChargeMain.BillType = Request["BillType"];
            }
            #endregion

            #region 创建M_ChargeDetail实例
            IList<M_ChargeDetail> list = new List<M_ChargeDetail>();
            M_ChargeDetail htTemp1 = new M_ChargeDetail();
            M_ChargeDetail htTemp2 = new M_ChargeDetail();
            M_ChargeDetail htTemp3 = new M_ChargeDetail();
            M_ChargeDetail htTemp4 = new M_ChargeDetail();
            M_ChargeDetail htTemp5 = new M_ChargeDetail();
            M_ChargeDetail htTemp6 = new M_ChargeDetail();
            M_ChargeDetail htTemp7 = new M_ChargeDetail();
            M_ChargeDetail htTemp8 = new M_ChargeDetail();
            #endregion

            #region 为M_ChargeDetail赋值
            htTemp1.ChargeItemID = 102; htTemp1.Amount = Convert.ToDouble(Request["value"]); list.Add(htTemp1);
            htTemp2.ChargeItemID = 103; htTemp2.Amount = Convert.ToDouble(Request["value1"]); list.Add(htTemp2);
            htTemp3.ChargeItemID = 104; htTemp3.Amount = Convert.ToDouble(Request["value2"]); list.Add(htTemp3);
            htTemp4.ChargeItemID = 105; htTemp4.Amount = Convert.ToDouble(Request["value3"]); list.Add(htTemp4);
            htTemp5.ChargeItemID = 106; htTemp5.Amount = Convert.ToDouble(Request["value4"]); list.Add(htTemp5);
            htTemp6.ChargeItemID = 107; htTemp6.Amount = Convert.ToDouble(Request["value5"]); list.Add(htTemp6);
            htTemp7.ChargeItemID = 108; htTemp7.Amount = Convert.ToDouble(Request["value6"]); list.Add(htTemp7);
            htTemp8.ChargeItemID = 109; htTemp8.Amount = Convert.ToDouble(Request["value7"]); list.Add(htTemp8);
            if (AppConfig.IsPatientAudit)
            {
                M_ChargeDetail htTemp9 = new M_ChargeDetail();
                M_ChargeDetail htTemp10 = new M_ChargeDetail();
                M_ChargeDetail htTemp11 = new M_ChargeDetail();
                htTemp9.ChargeItemID = 101; htTemp9.Amount = Convert.ToDouble(Request["value8"]); list.Add(htTemp9);
                htTemp10.ChargeItemID = 110; htTemp10.Amount = Convert.ToDouble(Request["value9"]); list.Add(htTemp10);
                htTemp11.ChargeItemID = 111; htTemp11.Amount = Convert.ToDouble(Request["value10"]); list.Add(htTemp11);
            }

            #endregion

            bool save = false;
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            try
            {
                save = charge.SaveChargeDetail(ChargeMain, type, list);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/SaveChargeDetail()", e.ToString());
                save = false;
            }

            return save;
        }

        #endregion

        #region 收费归集
        /// <summary>
        /// 收费归集
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="OrderCode">病例序号</param>
        /// <returns>bool</returns>
        public bool DerivedCharge(string TaskCode, int OrderCode, string AiderCharge)
        {
            ICharge MedicalManagement = ctx["NewCharge"] as ICharge;
            bool save = false;
            try
            {
                save = MedicalManagement.DerivedCharge(7, TaskCode, OrderCode, AiderCharge);
            }
            catch (Exception e)
            {
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/DerivedCharge()", e.ToString());
                save = false;
            }
            return save;
        }
        #endregion

        #region 收费审核与撤回
        /// <summary>
        /// 收费审核
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历编号</param>
        /// <param name="WorkID">人员ID</param>
        /// <returns></returns>
        public ActionResult AuditCharge(string TaskCode, string PatientOrder, string WorkID)
        {
            ICharge MedicalManagement = ctx["NewCharge"] as ICharge;
            // bool save = false;
            int tempPatientOrder;
            if (PatientOrder != "null")
            {
                tempPatientOrder = Convert.ToInt32(PatientOrder);
            }
            else
            {
                tempPatientOrder = Convert.ToInt32("9");
            }
            int tempWorkID = Convert.ToInt32(WorkID);
            try
            {
                //save = MedicalManagement.ApplyFlow(7, TaskCode, tempPatientOrder, tempWorkID);
                Dictionary<string, object> dicts = new Dictionary<string, object>();
                dicts.Add("InfoMessage", MedicalManagement.ApplyFlow(7, TaskCode, tempPatientOrder, tempWorkID));
                return this.Json(dicts);
            }
            catch (Exception e)
            {
                //Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/AuditCharge()", e.ToString());
                //save = false;
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/AuditCharge()", e.ToString());
                return this.Json(dict);
            }
            //return save;
        }
        /// <summary>
        /// 收费撤回
        /// </summary>
        /// <param name="TaskCode">任务编码</param>
        /// <param name="PatientOrder">病历编号</param>
        /// <param name="WorkID">人员ID</param>
        /// <returns></returns>
        public ActionResult RetractCharge(string TaskCode, string PatientOrder, string WorkID)
        {
            ICharge MedicalManagement = ctx["NewCharge"] as ICharge;
            //bool save = false;
            int tempPatientOrder;
            if (PatientOrder != "null")
            {
                tempPatientOrder = Convert.ToInt32(PatientOrder);
            }
            else
            {
                tempPatientOrder = Convert.ToInt32("9");
            }
            int tempWorkID = Convert.ToInt32(WorkID);
            try
            {
                // save = MedicalManagement.BillInBackAudit(7, TaskCode, tempPatientOrder, tempWorkID);
                Dictionary<string, object> dicts = new Dictionary<string, object>();
                dicts.Add("InfoMessage", MedicalManagement.BillInBackAudit(7, TaskCode, tempPatientOrder, tempWorkID));
                return this.Json(dicts);
            }
            catch (Exception e)
            {
                //Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/BillInBackAudit()", e.Message);
                //save = false;
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/RetractCharge()", e.ToString());
                return this.Json(dict);
            }
            //return save;
        }
        #endregion

        #region 欠费原因
        public ActionResult DebtReasons()
        {
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            return Json(charge.DebtReasons());
        }
        #endregion

        #endregion

        #region Test

        #region 作废
        public ActionResult ChargeSave(TChargeRecordMain entity2)
        {
            string detail = Request.Form["entity3"].ToString();
            IChargeDetail charge = ctx["charge"] as IChargeDetail;
            if (ModelState.IsValid)
            {
                bool result;
                try
                {
                    result = charge.save(entity2, detail);
                }
                catch (Exception)
                {
                    result = false;
                }

                if (result)
                {
                    return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "保存失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
        #endregion

        #region  主页面初始化方法
        /// <summary>
        ///  主页面初始化方法
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult test1()
        {
            string startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd HH:mm:ss");

            //this.ViewData["IsPatient"] = AppConfig.IsPatient;

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;

            ViewData["accout"] = User.Identity.Name.Split('|')[1];
            ViewData["userId"] = User.Identity.Name.Split('|')[0];
            return View();
        }
        #endregion

        #region Webservice测试

        //public bool SavePatienRecord()
        //{
        //    IMedicalManagement MedicalManagement = ctx["MedicalManagement"] as IMedicalManagement;
        //AmbulanceService.Service1SoapClient asd = new AmbulanceService.Service1SoapClient();

        //List<AmbulanceService.PatientRecordInfo> PatientRecordInfo = new List<AmbulanceService.PatientRecordInfo>();
        //List<AmbulanceService.MeasureInfo> MeasureInfo = new List<AmbulanceService.MeasureInfo>();
        #region 创建PatientRecordInfo实例
        //AmbulanceService.PatientRecordInfo htTemp0 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp1 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp2 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp3 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp4 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp5 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp6 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp7 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp8 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp9 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp10 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp11 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp12 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp13 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp14 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp15 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp16 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp17 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp18 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp19 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp20 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp21 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp22 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp23 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp24 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp25 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp26 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp27 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp28 = new AmbulanceService.PatientRecordInfo();
        //AmbulanceService.PatientRecordInfo htTemp29 = new AmbulanceService.PatientRecordInfo();
        #endregion

        //#region 为PatientRecordInfo赋值

        //htTemp0.ID = 0; htTemp0.Value = "20110317205726020101,2"; PatientRecordInfo.Add(htTemp0);
        //htTemp1.ID = 1; htTemp1.Value = "测试姓"; PatientRecordInfo.Add(htTemp1);
        //htTemp2.ID = 2; htTemp2.Value = "男"; PatientRecordInfo.Add(htTemp2);
        //htTemp3.ID = 3; htTemp3.Value = "50"; PatientRecordInfo.Add(htTemp3);
        //htTemp4.ID = 4; htTemp4.Value = "中国"; PatientRecordInfo.Add(htTemp4);
        //htTemp5.ID = 5; htTemp5.Value = "教师"; PatientRecordInfo.Add(htTemp5);
        //htTemp6.ID = 6; htTemp6.Value = "党员"; PatientRecordInfo.Add(htTemp6);
        //htTemp7.ID = 7; htTemp7.Value = "汉族"; PatientRecordInfo.Add(htTemp7);
        //htTemp8.ID = 8; htTemp8.Value = "妻子"; PatientRecordInfo.Add(htTemp8);
        //htTemp9.ID = 9; htTemp9.Value = "120"; PatientRecordInfo.Add(htTemp9);
        //htTemp10.ID = 10; htTemp10.Value = "杭州市西湖楼外楼"; PatientRecordInfo.Add(htTemp10);
        //htTemp11.ID = 11; htTemp11.Value = "西湖苏堤"; PatientRecordInfo.Add(htTemp11);
        //htTemp12.ID = 12; htTemp12.Value = "102"; PatientRecordInfo.Add(htTemp12);
        //htTemp13.ID = 13; htTemp13.Value = "省中医院"; PatientRecordInfo.Add(htTemp13);
        //htTemp14.ID = 14; htTemp14.Value = "101"; PatientRecordInfo.Add(htTemp14);
        //htTemp15.ID = 15; htTemp15.Value = "无"; PatientRecordInfo.Add(htTemp15);
        //htTemp16.ID = 16; htTemp16.Value = "无"; PatientRecordInfo.Add(htTemp16);
        //htTemp17.ID = 17; htTemp17.Value = "无"; PatientRecordInfo.Add(htTemp17);
        //htTemp18.ID = 18; htTemp18.Value = "无"; PatientRecordInfo.Add(htTemp18);
        //htTemp19.ID = 19; htTemp19.Value = "挤压伤"; PatientRecordInfo.Add(htTemp19);
        //htTemp20.ID = 20; htTemp20.Value = "160,161,175"; PatientRecordInfo.Add(htTemp20);
        //htTemp21.ID = 21; htTemp21.Value = "详细诊断"; PatientRecordInfo.Add(htTemp21);
        //htTemp21.ID = 22; htTemp22.Value = "未知"; PatientRecordInfo.Add(htTemp22);
        //htTemp23.ID = 23; htTemp23.Value = "无"; PatientRecordInfo.Add(htTemp23);
        //htTemp24.ID = 24; htTemp24.Value = "无"; PatientRecordInfo.Add(htTemp24);
        //htTemp25.ID = 25; htTemp25.Value = "有效"; PatientRecordInfo.Add(htTemp25);
        //htTemp26.ID = 26; htTemp26.Value = "送往医院"; PatientRecordInfo.Add(htTemp26);
        //htTemp27.ID = 27; htTemp27.Value = ""; PatientRecordInfo.Add(htTemp27);
        //htTemp28.ID = 28; htTemp28.Value = "120"; PatientRecordInfo.Add(htTemp28);
        //htTemp29.ID = 29; htTemp29.Value = "1"; PatientRecordInfo.Add(htTemp29);
        //#endregion
        //    bool save = false;
        //    try
        //    {
        //        int num = asd.SavePatientRecord(PatientRecordInfo.ToArray(), MeasureInfo.ToArray());
        //        if (num != -1)
        //        {
        //            save = true;
        //        }
        //        else
        //        {
        //            save = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log4Net.LogError("Anchor.FA.Web.Controllers.MedicalController/GetMeasureRecord()", e.Message);
        //        save = false;
        //    }
        //    return save;
        //}
        #region 病例实体

        public class PatientRecordInfo
        {
            public int ID { get; set; }
            public string Value { get; set; }
        }

        #endregion
        #region 救治措施实体

        public class MeasureInfo
        {
            public int ID { get; set; }
            public string Value { get; set; }
            public int OrderID { get; set; }
        }

        #endregion
        #endregion


        #endregion

    }
}
