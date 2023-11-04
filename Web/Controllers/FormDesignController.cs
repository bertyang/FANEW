using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Anchor.FA.FormMaker;
using Anchor.FA.BLL.FormDesign;
using Anchor.FA.Utility;

namespace Anchor.FA.Web.Controllers
{
    public class FormDesignController : Controller
    {
        //
        // GET: /FormDesign/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Maintain()
        {
            return Redirect("~/FormDesign/FormDesignLayoutMaintain.aspx?" + Request.QueryString);
        }

        public ActionResult DesignTable()
        {
            return Redirect("~/FormDesign/FormDesignTable.aspx?" + Request.QueryString);
        }

        public ActionResult FieldSelectTypeMain()
        {
            return Redirect("~/FormDesign/FieldSelectTypeMain.aspx?" + Request.QueryString);
        }

        public ActionResult FieldSelectType()
        {
            return Redirect("~/FormDesign/FormDesignFieldSelectType.aspx?" + Request.QueryString);
        }

        public ActionResult Create()
        {
            return Redirect("~/FormDesign/FormDesignGenerate.aspx?" + Request.QueryString);
        }

        public ActionResult SumTextBoxElement()
        {
            return Redirect("~/FormDesign/Element/SumTextBoxElement.aspx?" + Request.QueryString);
        }

        public ActionResult ComputeTextBoxElement()
        {
            return Redirect("~/FormDesign/Element/ComputeTextBoxElement.aspx?" + Request.QueryString);
        }

        public ActionResult LinkElement()
        {
            return Redirect("~/FormDesign/Element/LinkElement.aspx?" + Request.QueryString);
        }

        public ActionResult LongTextboxElement()
        {
            return Redirect("~/FormDesign/Element/LongTextboxElement.aspx?" + Request.QueryString);
        }
                      
         public ActionResult TextboxElement()
        {
            return Redirect("~/FormDesign/Element/TextboxElement.aspx?" + Request.QueryString);
        }

        public ActionResult MailTextboxElement()
        {
            return Redirect("~/FormDesign/Element/MailTextboxElement.aspx?" + Request.QueryString);
        }

        public ActionResult PhoneTextboxElement()
        {
            return Redirect("~/FormDesign/Element/PhoneTextboxElement.aspx?" + Request.QueryString);
        }

        public ActionResult CalendarElement()
        {
            return Redirect("~/FormDesign/Element/CalendarElement.aspx?" + Request.QueryString);
        }

        public ActionResult UploadElement()
        {
            return Redirect("~/FormDesign/Element/UploadElement.aspx?" + Request.QueryString);
        }

        public ActionResult SeparatorElement()
        {
            return Redirect("~/FormDesign/Element/SeparatorElement.aspx?" + Request.QueryString);
        }

        public ActionResult RelatedFormElement()
        {
            return Redirect("~/FormDesign/Element/RelatedFormElement.aspx?" + Request.QueryString);
        }

        public ActionResult NumberTextBoxElement()
        {
            return Redirect("~/FormDesign/Element/NumberTextBoxElement.aspx?" + Request.QueryString);
        }

        public ActionResult DropdownListElement()
        {
            return Redirect("~/FormDesign/Element/DropdownListElement.aspx?" + Request.QueryString);
        }

        public ActionResult CheckboxListElement()
        {
            return Redirect("~/FormDesign/Element/CheckboxListElement.aspx?" + Request.QueryString);
        }

        public ActionResult RadioButtonElement()
        {
            return Redirect("~/FormDesign/Element/RadioButtonElement.aspx?" + Request.QueryString);
        }

        public ActionResult EmployeePicker()
        {
            return Redirect("~/FormDesign/Element/EmployeePicker.aspx?" + Request.QueryString);
        }

        public ActionResult Generate(int flowId)
        {
            decimal version = new BLL.FormDesign.DesignForm().GenerateForm(flowId, "", "0");
    
            string compileOutput = string.Empty;
            bool overrideCustom = false;

            try
            {
                overrideCustom = CodeGeneratorFactory.Create("OVS2005", flowId, version, "zh-CN", flowId.ToString()).GenerateCode();

            }
            catch (Exception ex)
            {
                Log4Net.LogError("FormDesign",  ex.ToString());
                overrideCustom = false;
            }

            if (overrideCustom)
            {
                return Json(new { IsSuccess = true, Message = "保存成功" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "保存成功" });
            }

        }
    }
}
