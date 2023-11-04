using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anchor.FA.Model;
using Anchor.FA.BLL.IBLL;
using Anchor.FA.BLL.BasicInfo;
using System.Text;

namespace Anchor.FA.Web.Controllers
{
    public class HospitalBeforeController : BaseController
    {
        #region 车辆放空记录

        //
        // GET: /HospitalBefore/

        public ActionResult AumEmpty()
        {
            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:00:00";
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:00:00";

            this.ViewData["begin"] = begin;
            this.ViewData["end"] = end;
            //this.ViewData["role"] = ISPermit(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            //this.ViewData["user"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AumEmptyEdit(string id)
        {
            IAumEmpty aum = ctx["AumEmpty"] as IAumEmpty;
            R_AumEmpty am = aum.Edit(id) as R_AumEmpty;
            if (id == null)//新增
            {
                am.WorkID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                this.ViewData["userName"] = User.Identity.Name.Split('|')[1];

            }
            else//修改
            {
                Anchor.FA.BLL.Organize.Worker w = new BLL.Organize.Worker();
                B_WORKER bw = w.GetWorkerById(am.WorkID);
                this.ViewData["userName"] = bw.Name;
            }
            this.ViewData["entity"] = am;            
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult AumEmptyDelete(IList<string> idList)
        {
            IAumEmpty am = ctx["AumEmpty"] as IAumEmpty;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = am.Delete(idList);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" });
                }
            }
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult AumEmptySave(R_AumEmpty entity)
        {
            IAumEmpty am = ctx["AumEmpty"] as IAumEmpty;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    entity.Remark = entity.Remark == null ? "" : entity.Remark;
                    save = am.Save(entity);
                }
                catch (Exception)
                {

                    save = false;
                }
                if (save)
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
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="rows"></param>
        ///// <param name="order"></param>
        ///// <param name="sort"></param>
        ///// <returns></returns>
        //public ActionResult AumEmptyLoad(DateTime begin, DateTime end, int page, int rows, string order, string sort)
        //{
        //    IAumEmpty aum = ctx["AumEmpty"] as IAumEmpty;

        //    var result = aum.LoadAllAumEmptyByPage(begin, end, page, rows, order, sort);

        //    return Json(result);
        //}
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public ActionResult AumEmptySearch(DateTime begin, DateTime end, string Name, int page, int rows, string order, string sort)
        {
            IAumEmpty am = ctx["AumEmpty"] as IAumEmpty;
            int workID =Convert.ToInt32( User.Identity.Name.Split('|')[0]);
            var result = am.AumEmptySearch(begin,end, Name, page, rows, order, sort,workID);
            return this.Json(result);
        }

        #endregion 

        #region 车辆加油记录

        public ActionResult AumRefuel()
        {
            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:00:00";
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:00:00";
            this.ViewData["begin"] = begin;
            this.ViewData["end"] = end;
            //this.ViewData["role"] = ISPermit(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            //this.ViewData["user"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AumRefuelEdit(string id)
        {
            IAumRefuel aum = ctx["AumRefuel"] as IAumRefuel;
            R_AumRefuel am = aum.Edit(id) as R_AumRefuel;
            if (id == null)//新增
            {
                am.WorkID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                this.ViewData["userName"] = User.Identity.Name.Split('|')[1];
                this.ViewData["ambulance"] = "";
            }
            else//修改
            {
                Anchor.FA.BLL.Organize.Worker w = new BLL.Organize.Worker();
                B_WORKER bw = w.GetWorkerById(am.WorkID);
                this.ViewData["userName"] = bw.Name;
                this.ViewData["ambulance"] = am.AmbulanceID;
            }
            this.ViewData["entity"] = am;
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult AumRefuelDelete(IList<string> idList)
        {
            IAumRefuel am = ctx["AumRefuel"] as IAumRefuel;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = am.Delete(idList);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" });
                }
            }
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult AumRefuelSave(R_AumRefuel entity)
        {
            IAumRefuel am = ctx["AumRefuel"] as IAumRefuel;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    //entity.Remark = entity.Remark == null ? "" : entity.Remark;
                    save = am.Save(entity);
                }
                catch (Exception)
                {

                    save = false;
                }
                if (save)
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
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="rows"></param>
        ///// <param name="order"></param>
        ///// <param name="sort"></param>
        ///// <returns></returns>
        //public ActionResult AumRefuelLoad(DateTime begin, DateTime end, int page, int rows, string order, string sort)
        //{
        //    IAumRefuel aum = ctx["AumRefuel"] as IAumRefuel;

        //    var result = aum.LoadAllAumRefuelByPage(begin, end, page, rows, order, sort);

        //    return Json(result);
        //}
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public ActionResult AumRefuelSearch(DateTime begin, DateTime end, string Name, int page, int rows, string order, string sort)
        {
            IAumRefuel am = ctx["AumRefuel"] as IAumRefuel;
            int workID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            var result = am.AumRefuelSearch(begin, end, Name, page, rows, order, sort, workID);
            return this.Json(result);
        }

        #endregion

        #region 车辆交接记录

        public ActionResult AumTrans()
        {
            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:00:00";
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:00:00";
            this.ViewData["begin"] = begin;
            this.ViewData["end"] = end;
            //this.ViewData["role"] = ISPermit(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            //this.ViewData["user"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AumTransEdit(string id)
        {
            IAumTrans aum = ctx["AumTrans"] as IAumTrans;
            R_AumTrans am = aum.Edit(id) as R_AumTrans;
            if (id == null)//新增
            {
                am.WorkID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                this.ViewData["userName"] = User.Identity.Name.Split('|')[1];
                this.ViewData["ambulance"] = "";
            }
            else//修改
            {
                Anchor.FA.BLL.Organize.Worker w = new BLL.Organize.Worker();
                B_WORKER bw = w.GetWorkerById(am.WorkID);
                this.ViewData["userName"] = bw.Name;
                this.ViewData["ambulance"] = am.AmbulanceID;
            }
            this.ViewData["entity"] = am;
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult AumTransDelete(IList<string> idList)
        {
            IAumTrans am = ctx["AumTrans"] as IAumTrans;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = am.Delete(idList);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" });
                }
            }
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult AumTransSave(R_AumTrans entity)
        {
            IAumTrans am = ctx["AumTrans"] as IAumTrans;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    //entity.Remark = entity.Remark == null ? "" : entity.Remark;
                    save = am.Save(entity);
                }
                catch (Exception)
                {

                    save = false;
                }
                if (save)
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
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="rows"></param>
        ///// <param name="order"></param>
        ///// <param name="sort"></param>
        ///// <returns></returns>
        //public ActionResult AumTransLoad(DateTime begin, DateTime end, int page, int rows, string order, string sort)
        //{
        //    IAumTrans aum = ctx["AumTrans"] as IAumTrans;

        //    var result = aum.LoadAllAumTransByPage(begin, end, page, rows, order, sort);

        //    return Json(result);
        //}
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public ActionResult AumTransSearch(DateTime begin, DateTime end, string Name, int page, int rows, string order, string sort)
        {
            IAumTrans am = ctx["AumTrans"] as IAumTrans;
            int workID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            var result = am.AumTransSearch(begin, end, Name, page, rows, order, sort, workID);
            return this.Json(result);
        }

        #endregion

        #region  行车记录

        public ActionResult DriveRecord()
        {
            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:00:00";
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:00:00";

            this.ViewData["begin"] = begin;
            this.ViewData["end"] = end;
            //this.ViewData["role"] = ISPermit(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            //this.ViewData["user"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DriveRecordEdit(string id)
        {
            IDriveRecord aum = ctx["DriveRecord"] as IDriveRecord;
            R_DriveRecord am = aum.Edit(id) as R_DriveRecord;
            if (id == null)//新增
            {
                am.WorkID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                this.ViewData["userName"] = User.Identity.Name.Split('|')[1];
            }
            else//修改
            {
                Anchor.FA.BLL.Organize.Worker w = new BLL.Organize.Worker();
                B_WORKER bw = w.GetWorkerById(am.WorkID);
                this.ViewData["userName"] = bw.Name;
            }
            this.ViewData["entity"] = am;
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult DriveRecordDelete(IList<string> idList)
        {
            IDriveRecord am = ctx["DriveRecord"] as IDriveRecord;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = am.Delete(idList);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" });
                }
            }
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult DriveRecordSave(R_DriveRecord entity)
        {
            IDriveRecord am = ctx["DriveRecord"] as IDriveRecord;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    entity.Remark = entity.Remark == null ? "" : entity.Remark;
                    save = am.Save(entity);
                }
                catch (Exception)
                {

                    save = false;
                }
                if (save)
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
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="rows"></param>
        ///// <param name="order"></param>
        ///// <param name="sort"></param>
        ///// <returns></returns>
        //public ActionResult DriveRecordLoad(DateTime begin, DateTime end, int page, int rows, string order, string sort)
        //{
        //    IDriveRecord aum = ctx["DriveRecord"] as IDriveRecord;

        //    var result = aum.LoadAllDriveRecordByPage(begin, end, page, rows, order, sort);

        //    return Json(result);
        //}
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public ActionResult DriveRecordSearch(DateTime begin, DateTime end, string Name, int page, int rows, string order, string sort)
        {
            IDriveRecord am = ctx["DriveRecord"] as IDriveRecord;
            int workID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            var result = am.DriveRecordSearch(begin, end, Name, page, rows, order, sort, workID);
            return this.Json(result);
        }

        #endregion

        #region 司机工作汇总

        public ActionResult DriverWork()
        {
            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:00:00";
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:00:00";
            this.ViewData["begin"] = begin;
            this.ViewData["end"] = end;
            //this.ViewData["role"] = ISPermit(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            //this.ViewData["user"] = User.Identity.Name.Split('|')[1];
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DriverWorkEdit(string id)
        {
            IDriverWork aum = ctx["DriverWork"] as IDriverWork;
            R_DriverWork am = aum.Edit(id) as R_DriverWork;
            if (id == null)//新增
            {
                am.WorkID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                this.ViewData["userName"] = User.Identity.Name.Split('|')[1];
            }
            else//修改
            {
                Anchor.FA.BLL.Organize.Worker w = new BLL.Organize.Worker();
                B_WORKER bw = w.GetWorkerById(am.WorkID);
                this.ViewData["userName"] = bw.Name;
            }
            this.ViewData["entity"] = am;
            this.ViewData["station"] = am.StaCode;
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult DriverWorkDelete(IList<string> idList)
        {
            IDriverWork am = ctx["DriverWork"] as IDriverWork;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = am.Delete(idList);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" });
                }
            }
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult DriverWorkSave(R_DriverWork entity)
        {
            IDriverWork am = ctx["DriverWork"] as IDriverWork;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    entity.Remark = entity.Remark == null ? "" : entity.Remark;
                    save = am.Save(entity);
                }
                catch (Exception)
                {

                    save = false;
                }
                if (save)
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
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="rows"></param>
        ///// <param name="order"></param>
        ///// <param name="sort"></param>
        ///// <returns></returns>
        //public ActionResult DriverWorkLoad(int page, int rows, string order, string sort)
        //{
        //    IDriverWork aum = ctx["DriverWork"] as IDriverWork;

        //    var result = aum.LoadAllDriverWorkByPage(page, rows, order, sort);

        //    return Json(result);
        //}
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public ActionResult DriverWorkSearch(string Name, string sta, int page, int rows, string order, string sort)
        {
            IDriverWork am = ctx["DriverWork"] as IDriverWork;
            int workID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
            var result = am.DriverWorkSearch(Name, sta, page, rows, order, sort, workID);
            return this.Json(result);
        }

        #endregion

        public bool ISPermit(int workid)
        {
            IAumEmpty aum = ctx["AumEmpty"] as IAumEmpty;
            return aum.ISPermit(workid);
        }
    }
}
