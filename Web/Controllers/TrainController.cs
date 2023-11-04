using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anchor.FA.BLL.IBLL;
using Anchor.FA.Model;

namespace Anchor.FA.Web.Controllers
{
    public class TrainController : BaseController
    {
        #region 培训档案
        public ActionResult TrainingDoc() 
        {
            string startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;

            return View();
        }

        public ActionResult TrainingDocLoad(int page, int rows, string order, string sort, DateTime startTime, DateTime endTime, int? type)
        {
            ITrain train = ctx["Train"] as ITrain;

            var result = train.LoadTrainingDocByPage(page, rows, order, sort, startTime, endTime, type);

            return Json(result);
        }

        public ActionResult TrainingDocEdit(int? id)
        {
            ITrain train = ctx["Train"] as ITrain;

            var cot = train.GetTrainingDoc(id);
            this.ViewData["entity"] = cot;
            this.ViewData["type"] = cot.Type;

            if (cot.ID == 0)
            {
                this.ViewData["createWorkerID"] = User.Identity.Name.Split('|')[0];
                this.ViewData["createWorkerName"] = User.Identity.Name.Split('|')[1];
            }
            else
            {
                IWorker worker = ctx["Worker"] as IWorker;
                this.ViewData["createWorkerID"] = cot.CreateWorkerID;
                this.ViewData["createWorkerName"] = worker.GetWorkerById(cot.CreateWorkerID).Name;
            }
            return View();
        }

        public ActionResult TrainingDocSave(O_TrainingDoc entity)
        {
            ITrain train = ctx["Train"] as ITrain;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = train.SaveTrainingDoc(entity);
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

        public ActionResult TrainingDocDelete(IList<int> idList)
        {
            ITrain train = ctx["Train"] as ITrain;
            bool delete;
            try
            {
                delete = train.DeleteTrainingDoc(idList);
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

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public ActionResult TrainingDocAudit(int id) 
        {
            ITrain train = ctx["Train"] as ITrain;

            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    O_TrainingDoc t = train.GetTrainingDoc(id);
                    if (t == null) 
                        return Json(new { IsSuccess = false, Message = "提交审核失败" });

                    audit = train.ApplyFlow(t);
                }
                catch (Exception)
                {

                    audit = false;
                }

                if (audit)
                {
                    return Json(new { IsSuccess = true, Message = "提交审核成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "提交审核失败" });
                }
            }

            return View();
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public ActionResult TrainingDocBackAudit(string BillNo) 
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            if (ModelState.IsValid)
            {
                bool back;

                try
                {
                    back = billTransfer.BillTransferBackAudit(BillNo, this.CurrentUser.ID);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = false, Message = e.Message });
                }

                if (back)
                {
                    return Json(new { IsSuccess = true, Message = "撤回审核成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "撤回审核失败" });
                }
            }
            return View();
        }

        #region 审核页面
        public ActionResult TrainingDocAuditView(int id)  
        {
            ITrain train = ctx["Train"] as ITrain;

            this.ViewData["ID"] = id;
            return View();
        }

        public ActionResult TrainingDocView(int id)   
        {
            ITrain train = ctx["Train"] as ITrain;

            var result = train.ViewTrainingDoc(id);
            JsonResult r = Json(result);
            return r;
        }

        #endregion
        #endregion

        #region 课程计划
        public ActionResult Course() 
        {
            string startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;

            return View();
        }

        public ActionResult CourseLoad(int page, int rows, string order, string sort, DateTime startTime, DateTime endTime, int? courseType) 
        {
            ITrain train = ctx["Train"] as ITrain;

            var result = train.LoadCourseByPage(page, rows, order, sort, startTime, endTime, courseType);

            return Json(result);
        }

        public ActionResult CourseSave(O_Course entity)
        {
            ITrain train = ctx["Train"] as ITrain;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = train.SaveCourse(entity);
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

        public ActionResult CourseDelete(IList<int> idList)
        {
            ITrain train = ctx["Train"] as ITrain;
            bool delete;
            try
            {
                delete = train.DeleteCourse(idList);
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
        #endregion 

        #region 讲师档案
        public ActionResult LecturerDoc() 
        {
            string startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;

            return View();
        }

        public ActionResult LecturerDocLoad(int page, int rows, string order, string sort, string name, int? type) 
        { 
            ITrain train = ctx["Train"] as ITrain;

            var result = train.LoadLecturerDocByPage(page, rows, order, sort, name,type);

            return Json(result);
        }

        public ActionResult LecturerDocSave(O_LecturerDoc entity) 
        {
            ITrain train = ctx["Train"] as ITrain;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = train.SaveLecturerDoc(entity);
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

        public ActionResult LecturerDocDelete(IList<int> idList)
        {
            ITrain train = ctx["Train"] as ITrain;
            bool delete;
            try
            {
                delete = train.DeleteLecturerDoc(idList);
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
        #endregion 

        #region 学员档案
        public ActionResult StudentDoc() 
        {
            string startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endTime = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");

            this.ViewData["startTime"] = startTime;
            this.ViewData["endTime"] = endTime;

            return View();
        }

        public ActionResult StudentDocLoad(int page, int rows, string order, string sort, DateTime startTime, DateTime endTime, int? type)
        {
            ITrain train = ctx["Train"] as ITrain;

            var result = train.LoadStudentDocByPage(page, rows, order, sort, startTime, endTime, type);

            return Json(result);
        }

        public ActionResult StudentDocEdit(int? id)
        {
            ITrain train = ctx["Train"] as ITrain;

            var cot = train.GetStudentDoc(id);
            this.ViewData["entity"] = cot;
            this.ViewData["LearningDate"] = cot.LearningDate.ToString("yyyy-MM-dd");
            this.ViewData["ValidityCertificate"] = cot.ValidityCertificate.ToString("yyyy-MM-dd");

            return View();
        }

        public ActionResult StudentDocSave(O_StudentDoc entity)
        {
            ITrain train = ctx["Train"] as ITrain;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = train.SaveStudentDoc(entity);
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

        public ActionResult StudentDocDelete(IList<int> idList)
        { 
            ITrain train = ctx["Train"] as ITrain;
            bool delete;
            try
            {
                delete = train.DeleteStudentDoc(idList);
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

        #endregion

    }
}
