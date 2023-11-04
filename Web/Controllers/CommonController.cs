using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Anchor.FA.Model;
using Anchor.FA.BLL.IBLL;

namespace Anchor.FA.Web.Controllers
{
    public class CommonController : BaseController
    {
        //
        // GET: /Common/

        public ActionResult Index()
        {
            return View();
        }

        #region 公用数据
        public ActionResult Data()
        {
            return View();
        }

        public ActionResult DataType()
        {

            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            var result = data.DataType();
            return Json(result);
        }

        public ActionResult SearchLoadAll(string type)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            var result = data.SearchLoadAll(type);
            return Json(result);
        }

        public ActionResult DataLoad(int page, int rows, string order, string sort, string type)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            var result = data.LoadAllDataByPage(page, rows, order, sort, type);
            return Json(result);
        }

        public ActionResult DataEdit(int? id)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            this.ViewData["entity"] = data.Edit(id);
            return View();
        }

        public ActionResult DataSave(G_DATA entity)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = data.Save(entity);
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

        public ActionResult DataDelete(IList<int> idList)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = data.Delete(idList);
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

        public ActionResult LoadNurse()
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            var result = data.LoadNurse();
            return Json(result);
        }

        public ActionResult GetDataByType(string type)
        {
            BLL.BasicInfo.CommonData data = new BLL.BasicInfo.CommonData();
            var result = data.GetDataByType(type);
            return Json(result);
        }
        #endregion

        #region 公用数据管理
        public ActionResult Config()
        {
            return View();
        }
        public ActionResult ConfigLoad(int page, int rows, string order, string sort)
        {
            BLL.BasicInfo.Config config = new BLL.BasicInfo.Config();

            var result = config.LoadAllActionByPage(page, rows, order, sort);

            return Json(result);
        }
        //public ActionResult ActionLoadAll()
        //{
        //    BLL.BasicInfo.Config action = new BLL.BasicInfo.Config();

        //    var result = action.GetAllAction();

        //    return Json(result);
        //}

        //public ActionResult ActionLoadTree()
        //{
        //    //BLL.Organize.Action action = new BLL.Organize.Action();
        //    //return this.Json(Aciton.GetMenu("0"));
        //    return this.Json(Anchor.FA.BLL.Organize.Action.GetMenuRange("0"));
        //}

        public ActionResult ConfigEdit(string key)
        {
            BLL.BasicInfo.Config config = new BLL.BasicInfo.Config();
            G_CONFIG cot = config.Edit(key) as G_CONFIG;
            this.ViewData["entity"] = cot;
            return View();
        }

        public ActionResult ConfigSave(G_CONFIG entity)
        {
            BLL.BasicInfo.Config config = new BLL.BasicInfo.Config();
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    save = config.Save(entity);
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
      
        #endregion
    }
}
