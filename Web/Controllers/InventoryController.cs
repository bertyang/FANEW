using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anchor.FA.Model;
using Anchor.FA.BLL.IBLL;
using System.IO;
using Anchor.FA.Utility;
using System.Text;
using System.IO;
using System.Data;

namespace Anchor.FA.Web.Controllers
{
    public class InventoryController : BaseController
    {
        #region 生产厂家
        public ActionResult Manufacturer()
        {
            return View();
        }
        public ActionResult ManufacturerLoad(int page, int rows, string order, string sort)
        {
            IManufacturer Manufacturer = ctx["Manufacturer"] as IManufacturer;

            var result = Manufacturer.LoadAllByPage(page, rows, order, sort);

            return Json(result);
        }

        public ActionResult ManufacturerEdit(int? id)
        {
            IManufacturer Manufacturer = ctx["Manufacturer"] as IManufacturer;
            this.ViewData["entity"] = Manufacturer.Edit(id);
            return View();
        }

        public ActionResult ManufacturerSave(S_MANUFACTURER entity)
        {
            IManufacturer Manufacturer = ctx["Manufacturer"] as IManufacturer;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    save = Manufacturer.Save(entity);
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

        public ActionResult ManufacturerDelete(IList<int> idList)
        {
            IManufacturer Manufacturer = ctx["Manufacturer"] as IManufacturer;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = Manufacturer.Delete(idList);
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

        public ActionResult ManufacturerLoadAll()
        {
            IManufacturer Manufacturer = ctx["Manufacturer"] as IManufacturer;

            var result = Manufacturer.GetAllManufacturer();

            return Json(result);
        }
        #endregion

        #region 供应商
        public ActionResult Supplier()
        {
            return View();
        }
        public ActionResult SupplierLoad(int page, int rows, string order, string sort)
        {
            ISupplier Supplier = ctx["Supplier"] as ISupplier;

            var result = Supplier.LoadAllByPage(page, rows, order, sort);

            return Json(result);
        }

        public ActionResult SupplierEdit(int? id)
        {
            ISupplier Supplier = ctx["Supplier"] as ISupplier;
            this.ViewData["entity"] = Supplier.Edit(id);
            return View();
        }

        public ActionResult SupplierSave(S_SUPPLIER entity)
        {
            ISupplier Supplier = ctx["Supplier"] as ISupplier;
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    save = Supplier.Save(entity);
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

        public ActionResult SupplierDelete(IList<int> idList)
        {
            ISupplier Supplier = ctx["Supplier"] as ISupplier;
            if (ModelState.IsValid)
            {
                bool delete;
                try
                {
                    delete = Supplier.Delete(idList);
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

        public ActionResult SupplierLoadAll()
        {
            ISupplier Supplier = ctx["Supplier"] as ISupplier;

            var result = Supplier.GetAllSupplier();

            return Json(result);
        }
        #endregion

        #region 物品类别
        public ActionResult Category()
        {
            return View();
        }


        public ActionResult CategoryTree(string categoryID)
        { 
            try
            {
                ICategory Category = ctx["Category"] as ICategory;
                List<C_CATEGORY_TREE> cot = Category.GetTree(categoryID);
                if (cot == null)
                {
                    return View("Category");
                }
                return this.Json(cot);
            }
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                return this.Json(dict);
            }
        }

        public ActionResult CategoryEdit(int categoryID)
        {
            ICategory Category = ctx["Category"] as ICategory;
            S_CATEGORY cot = Category.GetCategory(categoryID);

            this.ViewData["categoryId"] = categoryID;
            this.ViewData["parentCategoryId"] = cot.ParentID;

            this.ViewData["entity"] = cot;

            //判断是否含有子类
            var ch = Category.GetCategoryByParentID(categoryID);
            if (ch.Count == 0)
            {
                this.ViewData["children"] = 0;
            }
            else
            {
                this.ViewData["children"] = 1;
            }

            //判断是否含有物品
            var result = Category.GetGoodsByCategoryID(categoryID);
            if (result.Count == 0)
            {
                this.ViewData["goods"] = 0;
            }
            else
            {
                this.ViewData["goods"] = 1;
            }

            return View();
        }

        public ActionResult CategoryAdd(int id)
        {
            this.ViewData["entity"] = new S_CATEGORY();
            this.ViewData["category"] = id;
            return View();
        }

        public ActionResult CategorySave(S_CATEGORY entity)
        {

            ICategory Category = ctx["Category"] as ICategory;

            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    save = Category.SaveCategory(entity);
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

        public ActionResult CategoryDelete(string id)
        {
            ICategory Category = ctx["Category"] as ICategory;
            bool delete;
            try
            {
                delete = Category.CategoryDelete(id);
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
                return Json(new { IsSuccess = false, Message = "删除失败，请删除其子节点" });
            }
        }

        #endregion





        #region 物品资料
        #region 物品
        public ActionResult Goods()
        {
            return View();
        }
        public ActionResult GoodsSelect(string categoryId)
        {
            this.ViewData["categoryId"] = categoryId;

            return View();
        }
        public ActionResult GoodsPage(int? categoryID,int? goodsId)
        {
            ICategory Category = ctx["Category"] as ICategory;

            //前次选择物品id
            if (goodsId == null)
                this.ViewData["selectedGoodsID"] = string.Empty;
            else
                this.ViewData["selectedGoodsID"] = goodsId;
            ////前次页码
            //if (pageNumber == null || pageNumber == 0)
            //    this.ViewData["pageNumber"] = "1";
            //else
            //    this.ViewData["pageNumber"] = pageNumber;


            this.ViewData["category"] = categoryID;

            if (categoryID != null)
            {
                var result = Category.GetCategoryByParentID((int)categoryID);
                //判断是否含有子类
                if (result.Count == 0)
                {
                    this.ViewData["children"] = 0;
                }
                else
                {
                    this.ViewData["children"] = 1;
                }

            }
            return View();
        }

        public ActionResult GoodsLoad(int page, int rows, string order, string sort, string categoryID, string name, int? num,string text)
        {
            BLL.Inventory.Goods good = new BLL.Inventory.Goods();

            var result = good.LoadGoodsByPage(page, rows, order, sort, categoryID, name, num, text);

            return Json(result);
        }

        public ActionResult AllGoodsLoad(int page, int rows, string order, string sort, string categoryID, string name, int? num, string text)
        {
            BLL.Inventory.Goods good = new BLL.Inventory.Goods();

            var result = good.LoadAllGoodsByPage(page, rows, order, sort, categoryID, name, num, text);

            return Json(result);
        }

        //public ActionResult GoodsView(int goodsId)
        //{
        //    IGoods goods = ctx["Goods"] as IGoods;
        //    IWorker worker = ctx["Worker"] as IWorker;
        //    IOrganization org = ctx["Organize"] as IOrganization;
        //    ICategory cate = ctx["Category"] as ICategory;

        //    S_GOODS cot = goods.GetGoodsById(goodsId);

        //    this.ViewData["entity"] = cot;
        //    this.ViewData["Active"] = cot.Active == "Y" ? "是" : "否";

        //    return View();
        //}

        public ActionResult GoodsEdit(int? categoryID, int? goodsId)
        {
            IGoods goods = ctx["Goods"] as IGoods;
            IWorker worker = ctx["Worker"] as IWorker;

            S_GOODS cot = goods.GetGoodsById(goodsId);

            this.ViewData["entity"] = cot;

            this.ViewData["goodsId"] = goodsId;
            this.ViewData["goodsCategory"] = goodsId == null ? categoryID : cot.CategoryID; //所选物品类别

            this.ViewData["category"] = categoryID;   //左侧树所选类别
            this.ViewData["manufacturer"] = cot.ManufacturerID == null ? 0 : cot.ManufacturerID;
            this.ViewData["supplier"] = cot.SupplierID == null ? 0 : cot.SupplierID;
            this.ViewData["form"] = cot.Form;

            return View();
        }


        public ActionResult GoodsType()
        {
            ICommon CommonData = ctx["CommonData"] as ICommon;
            var result = CommonData.GetDataByType("Drug");
            return Json(result);
        }

        public ActionResult GoodsSaveCheck(int category, string goodsName)    
        {
            IGoods goods = ctx["Goods"] as IGoods;
            List<S_GOODS> cot = goods.GetGoodsByCategory(category);
            foreach (S_GOODS entity in cot)
            {
                if (entity.Name == goodsName)
                {
                    return Json(new { IsSuccess = true, Message = "名称重复，请重新输入" }, "text/html", JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }


        public ActionResult GoodsSave(S_GOODS entity)
        {
            IGoods goods = ctx["Goods"] as IGoods;
            entity.Active = Request.Form["active"];


            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = goods.Save(entity);
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

        public ActionResult GoodsDelete(IList<int> idList)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = goods.Delete(idList);
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GoodsPicUpload(HttpPostedFileBase upfile)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            string fileurl = goods.GoodsPicUpload(upfile, Server.MapPath("/Upload/"));
            //fileurl = HttpUtility.UrlEncode(fileurl);

            return Json(new { IsSuccess = true, Message = fileurl }, "text/html", JsonRequestBehavior.AllowGet);
            //return Json(fileurl);
        }

        #endregion
        #region 批次
        //public ActionResult GoodsBatchPage(int? categoryID, int goodsId)
        //{
        //    this.ViewData["GoodsId"] = goodsId;
        //    this.ViewData["categoryID"] = categoryID;
        //    return View();
        //}

        public ActionResult GoodsBatchLoad(int? page, int? rows, string order, string sort, int goodsID)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            var result = goods.LoadAllGoodsBatchByPage(page, rows, order, sort, goodsID);

            return Json(result);
        }

        public ActionResult GoodsBatchAmountLoad(int? page, int? rows, string order, string sort, int goodsId, int houseId)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            var result = goods.LoadAllGoodsBatchAmountByPage(page, rows, order, sort, goodsId, houseId);

            return Json(result);
        }

        public ActionResult GoodsBatchEdit(int goodsId, int? categoryID,string batchNo)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            S_GOODS_BATCH batch = goods.GetGoodsBatchByID(goodsId, batchNo);
            this.ViewData["entity"] = batch;

            S_GOODS g = goods.GetGoodsById(goodsId);
            this.ViewData["Goods"] = g.Name;

            ICategory ic = ctx["Category"] as ICategory;
            S_CATEGORY c = ic.GetCategory(g.CategoryID);
            this.ViewData["ProfitRatio"] = c.ProfitRatio;

            //this.ViewData["Goods"] = goods.GetGoodsById(goodsId).Name;

            //this.ViewData["pageNumber"] = pageNumber;
            this.ViewData["goodsId"] = goodsId;
            this.ViewData["category"] = categoryID == null ? 1 : categoryID;
            //this.ViewData["BatchNo"] = batchNo;
            //this.ViewData["ManufactureDate"] = batch.ManufactureDate == null ? DateTime.Today.ToString("yyyy-MM-dd") : batch.ManufactureDate.ToString("yyyy-MM-dd");
            //this.ViewData["ValidityPeriod"] = batch.ValidityPeriod == null ? DateTime.Today.ToString("yyyy-MM-dd") : batch.ValidityPeriod.ToString("yyyy-MM-dd");

            return View();
        }
        public ActionResult GoodsBatch()
        {
            return View();
        }
        public ActionResult GoodsBatchDelete(int goodsId, string batchNo)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = goods.DeleteBatch(goodsId, batchNo);
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

        public ActionResult GoodsBatchSave(S_GOODS_BATCH entity)
        {
            IGoods goods = ctx["Goods"] as IGoods;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = goods.SaveBatch(entity);
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

        #endregion
        #region 物品角色库存
        
        public ActionResult RoleGoods()
        {
            return View();
        }

        public ActionResult RoleGoodsEdit(string RoleID,string categoryId,int? pageNumber)
        {
            this.ViewData["RoleID"] = RoleID;
            this.ViewData["categoryId"] = categoryId;
            //前次页码
            if (pageNumber == null || pageNumber == 0)
                this.ViewData["pageNumber"] = "1";
            else
                this.ViewData["pageNumber"] = pageNumber;
            return View();
        }

        public ActionResult RoleGoodsEditLoad(int page, int rows, string order, string sort
            , string RoleID, string categoryID, string name, int? num, string text)
        {
            var result = Anchor.FA.BLL.Inventory.RoleGoods.LoadAllGoodsUDByPage(page, rows, order, sort, RoleID, categoryID, name, num, text);

            return Json(result);
        }
        public ActionResult RoleGoodsEditSave(List<C_RoleGoodsSave> updateRow)
        {
            string result = Anchor.FA.BLL.Inventory.RoleGoods.Update(updateRow);
            return Json(result);
        }
        #endregion
        #region 库房类型物品库存

        public ActionResult StoreHouseTypeGoods()
        {
            return View();
        }

        public ActionResult StoreHouseTypeGoodsEdit(string StoreHouseType, int? pageNumber)
        {
            this.ViewData["StoreHouseType"] = StoreHouseType;
            //前次页码
            if (pageNumber == null || pageNumber == 0)
                this.ViewData["pageNumber"] = "1";
            else
                this.ViewData["pageNumber"] = pageNumber;
            return View();
        }

        public ActionResult StoreHouseTypeGoodsEditLoad(int page, int rows, string order, string sort
            , string StoreHouseType, string categoryID, string name, int? num, string text)
        {
            var result = Anchor.FA.BLL.Inventory.StoreHouseTypeGoods.LoadAllGoodsUDByPage(page, rows, order, sort, StoreHouseType, categoryID, name, num, text);

            return Json(result);
        }
        public ActionResult StoreHouseTypeGoodsEditSave(List<C_RoleGoodsSave> updateRow)
        {
            string result = Anchor.FA.BLL.Inventory.StoreHouseTypeGoods.Update(updateRow);
            return Json(result);
        }
        #endregion


        #region 台账

        public ActionResult GoodsInsOuts(int LocationID, int GoodsID, string BatchNo)
        {
            this.ViewData["LocationID"] = LocationID;
            this.ViewData["GoodsID"] = GoodsID;
            this.ViewData["BatchNo"] = BatchNo;

            IStorehouse Storehouse = ctx["Storehouse"] as IStorehouse;
            IGoods Goods = ctx["Goods"] as IGoods;

            S_STORE_HOUSE_LOCATION sl = Storehouse.GetStorageLocation(LocationID);
            this.ViewData["StorageLocation"] = sl;
            this.ViewData["Storage"] = Storehouse.GetStorehouse(sl.StoreHouseID);
            this.ViewData["Goods"] = Goods.GetGoodsById(GoodsID);

            this.ViewData["BeginDate"] = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            this.ViewData["EndDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            this.ViewData["Time"] = DateTime.Now.ToString("HH:mm:ss");
            return View();
        }



        public ActionResult GoodsInsOutsSearch(DateTime begin, DateTime end, string order, string sort
            , int GoodsId, string BatchNo, int LocationID)
        {

            var result =Anchor.FA.BLL.Inventory.Goods.GoodsInsOutsSearch(begin, end, 1, 10, order, sort
            , GoodsId, BatchNo, LocationID);

            return Json(result);
        }
        public ActionResult GoodsInsOutsGetCurrentAmountSum(int GoodsId, string BatchNo, int LocationID)
        {
            var result = Anchor.FA.BLL.Inventory.BLL_RealTime_Stock.getCurrentAmountSum(GoodsId, LocationID, BatchNo);
            return Json(result);
        }
        #endregion

        #region 库房资料
        public ActionResult Storehouse()
        {
            return View();
        }

        public ActionResult StorehouseTree(string storeHouseId)
        {
            try
            { 
                IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

                if (storeHouseId == "0")
                {
                    S_STORE_HOUSE house = storehouse.GetStoreHouseByManager(CurrentUserID).FirstOrDefault();

                    if(house!=null)
                    {
                        storeHouseId = house.ID.ToString();
                    }
                }
                List<C_ORGANIZE_TREE> cot = storehouse.GetTree(storeHouseId);
                return this.Json(cot);
            }
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                return this.Json(dict);
            }
        }

        public ActionResult StorehousePage(int? orgId, string houseId)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            this.ViewData["orgId"] = orgId;
            this.ViewData["houseId"] = houseId == null ? "" : houseId;

            S_STORE_HOUSE cot = storehouse.GetStorehouse(null);
            this.ViewData["sort"] = cot.Sort;
            return View();
        }
        public ActionResult StorehouseLoad(int page, int rows, string order, string sort, int? orgId, int? CurrentUserID, string houseId)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            var result = storehouse.LoadAllStorehouseByPage(page, rows, order, sort, orgId, CurrentUserID,houseId);

            return Json(result);
        }

        public ActionResult StorehouseList()
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;
            List<S_STORE_HOUSE> list = storehouse.GetAllStoreHouse();
            return Json(list);
        }

        public ActionResult StorehouseSaveCheck(int orgID, string houseName) 
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;
            List<S_STORE_HOUSE> cot = storehouse.GetStorehouseByOrg(orgID);
            foreach (S_STORE_HOUSE entity in cot)
            {
                if (entity.Name == houseName)
                {
                    return Json(new { IsSuccess = true, Message = "库存名称重复，请重新输入" }, "text/html", JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }
        public ActionResult StorehouseSave(S_STORE_HOUSE entity)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = storehouse.SaveStorehouse(entity);
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

        public ActionResult StorehouseDelete(IList<int> idList)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = storehouse.DeleteStorehouse(idList);
                }
                catch (Exception)
                {

                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "保存成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "保存失败" });
                }
            }

            return View();

        }

        public ActionResult StorageLocationPage(string StoreHouseID)
        {
            int houseId = int.Parse(StoreHouseID.Substring(6));//去掉"house-"前缀
            this.ViewData["houseId"] = houseId;
            return View();
        }
        public ActionResult StorageLocationLoad(int page, int rows, string order, string sort, int houseId)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            var result = storehouse.LoadAllStorageLocationByPage(page, rows, order, sort, houseId);

            return Json(result);
        }

        public ActionResult StorageLocationSaveCheck(int houseID, string locationName)   
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;
            List<S_STORE_HOUSE_LOCATION> cot = storehouse.GetStorageLocationByHouse(houseID);
            foreach (S_STORE_HOUSE_LOCATION entity in cot)
            {
                if (entity.Name == locationName)
                {
                    return Json(new { IsSuccess = true, Message = "库位名称重复，请重新输入" }, "text/html", JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult StorageLocationSave(S_STORE_HOUSE_LOCATION entity)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = storehouse.SaveStorageLocation(entity);
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

        public ActionResult StorageLocationDelete(IList<int> idList)
        {
            IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = storehouse.DeleteStorageLocation(idList);
                }
                catch (Exception)
                {

                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "保存成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "保存失败" });
                }
            }

            return View();

        }

        #endregion

        #region 入库单
        #region 入库单主表
        public ActionResult BillInPage(string BillNo, int? pageNumber, string CurrentUser, string StartTime, string Status, string WorkFlowId, string categoryId)
        {
            this.ViewData["WorkFlowId"] = Request.QueryString["workFlowId"];
            //得到单据名称
            string WorkFlowName = getWorkFlowName(Request.QueryString["workFlowId"]);
            this.ViewData["WorkFlowName"] = WorkFlowName == null ? "入库单" : WorkFlowName;

            this.ViewData["categoryId"] = Request.QueryString["categoryId"];

            //前次选择单据号码
            if (BillNo == null || BillNo == "")
                this.ViewData["selectedBillno"] = string.Empty;
            else
                this.ViewData["selectedBillno"] = BillNo;
            //前次页码
            if (pageNumber == null || pageNumber == 0)
                this.ViewData["pageNumber"] = "1";
            else
                this.ViewData["pageNumber"] = pageNumber;

            if (CurrentUser == null || CurrentUser == "")
            {
                this.ViewData["CurrentUser"] = this.CurrentUser.Name;
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["CurrentUser"] = CurrentUser;
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            this.ViewData["CurrentUserID"] = this.CurrentUser.ID;
;
            return View();
        }
        public ActionResult BillInLoad(int page, int rows, string order, string sort, int WorkFlowId, int? workId, DateTime startTime, string status)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            //入库单缺省类型为2

            if (startTime == null)
            {
                startTime = DateTime.Today;
                startTime.AddDays(-7);//缺省查询一周内入库单
            }

            if (workId == null)
            {
                workId = this.CurrentUser.ID;//缺省查询当前用户相关单据
            }

            if (status == "null" || status == "")
                status = "C";

            var result = billIn.LoadBillInByPage(page, rows, order, sort, WorkFlowId, workId, startTime, status);
            return Json(result);
        }
        public ActionResult BillInDetailLoad(int page, int rows, string order, string sort, string billNO)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            var result = billIn.LoadBillInDetailByPage(page, rows, order, sort, billNO);
            return Json(result);
        }
        public ActionResult BillInCreateWorkerID()
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            var result = billIn.BillInCreateWorkerID();
            return Json(result);
        }
        public ActionResult BillInSave(S_BILL_IN entity)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    entity.StoreHouseID = int.Parse(Request.Form["StoreHouseID"].Substring(6));//去掉"house-"前缀
                    save = billIn.Save(entity);
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
        public ActionResult BillInDelete(string BillNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = billIn.DeleteBillIn(BillNo);
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
        public ActionResult BillInAudit(string BillNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    S_BILL_IN bill = billIn.GetBillByNO(BillNo);
                    if (bill == null)
                        return Json(new { IsSuccess = false, Message = "提交审核失败" });

                    audit = billIn.ApplyFlow(bill);
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
        public ActionResult BillInAuditCheck(string billNo) 
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            List<S_BILL_IN_DETAIL> cot = billIn.GetDetailByNO(billNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.BatchNo == "" || entity.LocationID == 0)
                {
                    return Json(new { IsSuccess = true, Message = "您还有未填写完整的明细项!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedImpactBillIn(string BillNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            if (ModelState.IsValid)
            {
                bool red;

                try
                {
                    red = billIn.RedImpactBill(this.CurrentUser.ID, BillNo);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = false, Message = e.Message });
                }

                if (red)
                {
                    return Json(new { IsSuccess = true, Message = "红冲成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "红冲失败" });
                }
            }

            return View();
        }
        public ActionResult RedImpactBillOut(string BillNo)
        {
            IBillOut bill = ctx["BillOut"] as IBillOut;

            if (ModelState.IsValid)
            {
                bool red;

                try
                {
                    red = bill.RedImpactBillOut(this.CurrentUser.ID, BillNo);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = false, Message = e.Message });
                }

                if (red)
                {
                    return Json(new { IsSuccess = true, Message = "红冲成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "红冲失败" });
                }
            }

            return View();
        }
        public ActionResult RedImpactBillTransfer(string BillNo)
        {
            IBillTransfer bill = ctx["BillTransfer"] as IBillTransfer;

            if (ModelState.IsValid)
            {
                bool red;

                try
                {
                    red = bill.RedImpactBill(this.CurrentUser.ID, BillNo);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = false, Message = e.Message });
                }

                if (red)
                {
                    return Json(new { IsSuccess = true, Message = "红冲成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "红冲失败" });
                }
            }

            return View();
        }

        public ActionResult BillInView(string BillNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            var result = billIn.ViewBillIn(BillNo);
            JsonResult r = Json(result);
            return r;
        }
        public ActionResult BillInAuditView(int FlowNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            IFlow flow = ctx["Flow"] as IFlow;

            //得到单据名称
            string WorkFlowName = getWorkFlowName(Request.QueryString["flowId"]);
            this.ViewData["WorkFlowName"] = WorkFlowName == null ? "单据" : WorkFlowName;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_BILL_IN bill = billIn.QueryBillByFlowNo(FlowNo);
            this.ViewData["BillNo"] = bill.BillNo;
            if (bill.OldBillNo == null)
                this.ViewData["OldBillNo"] = string.Empty;
            else
                this.ViewData["OldBillNo"] = bill.OldBillNo;

            if (!string.IsNullOrEmpty(Request.QueryString["isPrint"]))
            {
                ViewData["isPrint"] = 1;
            }
            else
            {
                ViewData["isPrint"] = 0;
            }
            return View();
        }
        public ActionResult BillInBackAudit(string BillNo)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            if (ModelState.IsValid)
            {
                bool back;

                try
                {
                    back = billIn.BillInBackAudit(BillNo, this.CurrentUser.ID);
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
        #endregion

        #region 入库单明细
        public ActionResult BillInDetailEdit(string BillNo, int StoreHouseID, int? LocationID, int? GoodsID, string BatchNo,string Spec, string StoreHouseName, string LocationName, string GoodsName, string unit, string categoryId)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            List<S_BILL_IN_DETAIL> cot = billIn.GetDetailByNO(BillNo);  //获得此单据已经存在的明细
            this.ViewData["cot"] = cot;

            this.ViewData["BillNo"] = BillNo;
            this.ViewData["categoryId"] = categoryId;

            this.ViewData["StoreHouseID"] = StoreHouseID;
            this.ViewData["StoreHouse"] = StoreHouseName;

            if (GoodsID != null)
            {
                this.ViewData["LocationID"] = LocationID;
                this.ViewData["Location"] = LocationName;
                this.ViewData["GoodsName"] = GoodsName;
                this.ViewData["Unit"] = unit;
                this.ViewData["SaveType"] = "Update";
                this.ViewData["Spec"] = Spec;

                PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_in_detail");
                key.AddKeyValue("billno", BillNo);
                key.AddKeyValue("locationid", LocationID);
                key.AddKeyValue("goodsid", GoodsID);
                key.AddKeyValue("batchno", BatchNo);
                
                S_BILL_IN_DETAIL detail = billIn.GetDetailByPrimaryKey(key);
                this.ViewData["entity"] = detail;
            }
            else
            {
                S_BILL_IN_DETAIL d = new S_BILL_IN_DETAIL();
                d.BillNo = BillNo;
                d.BatchNo = string.Empty;
                d.ManufactureDate = DateTime.Today.AddDays(-7);
                d.ValidityPeriod = DateTime.Today;

                this.ViewData["SaveType"] = "Insert";
                this.ViewData["GoodsName"] = string.Empty;
                this.ViewData["Unit"] = string.Empty;
                this.ViewData["Spec"] = string.Empty;
                this.ViewData["entity"] = d;

                IStorehouse store = ctx["Storehouse"] as IStorehouse;
                List<S_STORE_HOUSE_LOCATION> listLocation = store.GetStorageLocationByHouse(StoreHouseID);

                if (listLocation.Count == 1)
                {
                    this.ViewData["LocationID"] = listLocation[0].ID;//库位只有一个的话，默认选中此库位
                }
                else
                {
                    this.ViewData["LocationID"] = -1;
                    this.ViewData["Location"] = string.Empty;
                }
            }
            return View();
        }

        public ActionResult BillInDetailAdd(string BillNo,string StrGoodsID) 
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            List<int> listGoodsID = new List<int>();
            foreach (string id in StrGoodsID.Split(','))
            {
                listGoodsID.Add(int.Parse(id));
            }
            if (ModelState.IsValid)
            {
                bool save;
                try
                {
                    save = billIn.InsertDetail(BillNo, listGoodsID);
                }
                catch (Exception ex)
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

        public ActionResult BillInDetailSaveCheck(string billNo, int goodsId, string batchNo, int locationId)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            List<S_BILL_IN_DETAIL> cot = billIn.GetDetailByNO(billNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.LocationID == locationId && entity.GoodsID == goodsId && entity.BatchNo == batchNo)
                {
                    return Json(new { IsSuccess = true, Message = "已经存在与“库位”、“物品”、“批次”都相同的记录" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult BillInDetailUpdate(S_BILL_IN_DETAIL entity, string OldBatch, int OldLocation,double OutPrice)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;

            //S_BILL_IN_DETAIL entity = new S_BILL_IN_DETAIL();
            //entity.BillNo = BillNo;
            //entity.GoodsID = GoodsId;
            //entity.BatchNo = BatchNo;
            //entity.LocationID = LocationId;
            //entity.ManufactureDate = ManufactureDate;
            //entity.ValidityPeriod = ValidityPeriod;
            //entity.Price = Convert.ToDecimal(Price);
            //entity.Amount = Amount;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billIn.UpdateDetail(entity, OldBatch, OldLocation, OutPrice);
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

        public ActionResult BillInDetailDelete(string BillNo, int GoodsId, string BatchNo, int LocationId)
        {
            IBillIn billIn = ctx["BillIn"] as IBillIn;
            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_in_detail");
                    key.AddKeyValue("billno", BillNo);
                    key.AddKeyValue("goodsid", GoodsId);
                    key.AddKeyValue("batchno", BatchNo);
                    key.AddKeyValue("locationid", LocationId);

                    delete = billIn.DeleteDetail(new List<PrimaryKeyEntity>() { key });
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
        #endregion
        //原有代码

        public ActionResult HouseTree(int CurrentUserID, int? transferIn) 
        {
            try
            {
                IStorehouse storehouse = ctx["Storehouse"] as IStorehouse;
                List<C_ORGANIZE_TREE> cot = storehouse.GetHouseTree(CurrentUserID,transferIn);
                return this.Json(cot);
            }
            catch (Exception e)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("InfoID", "0");
                dict.Add("InfoMessage", e.Message);
                return this.Json(dict);
            }
        }

        public ActionResult BillInType()
        {
            ICommon CommonData = ctx["CommonData"] as ICommon;
            var result = CommonData.GetDataByType("Bill");
            return Json(result);
        }

        public ActionResult PrintBillInList(string billNo)
        {
            var ReportPath = Server.MapPath("~/Views/Inventory/RDLC/BillIn.rdlc");

            IBillIn billIn = ctx["BillIn"] as IBillIn;
            IWorker worker = ctx["Worker"] as IWorker;
            IStorehouse store= ctx["Storehouse"] as IStorehouse;
            IFlow flow = ctx["Flow"] as IFlow;
            S_BILL_IN s = billIn.GetBillByNO(billNo);

            var localReport = new Microsoft.Reporting.WebForms.LocalReport { ReportPath = ReportPath };

            Microsoft.Reporting.WebForms.ReportParameter pBillNo = new Microsoft.Reporting.WebForms.ReportParameter("BillNo", s.BillNo);
            Microsoft.Reporting.WebForms.ReportParameter pOldBillNo = new Microsoft.Reporting.WebForms.ReportParameter("OldBillNo", string.IsNullOrEmpty(s.OldBillNo) ? " " : s.OldBillNo);
            Microsoft.Reporting.WebForms.ReportParameter pBillTime = new Microsoft.Reporting.WebForms.ReportParameter("BillTime", s.BillTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateTime = new Microsoft.Reporting.WebForms.ReportParameter("CreateTime", s.CreateTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateWorker = new Microsoft.Reporting.WebForms.ReportParameter("CreateWorker", worker.GetWorkerById(s.CreateWorkerID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pInviceNo = new Microsoft.Reporting.WebForms.ReportParameter("InviceNo", string.IsNullOrEmpty(s.InvoiceNo) ? " " : s.InvoiceNo);
            Microsoft.Reporting.WebForms.ReportParameter pStoreHourse = new Microsoft.Reporting.WebForms.ReportParameter("StoreHourse", store.GetStorehouse((int)s.StoreHouseID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pRemark = new Microsoft.Reporting.WebForms.ReportParameter("Remark", string.IsNullOrEmpty(s.Remark) ? " " : s.Remark);

            localReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { pBillNo, pOldBillNo, pBillTime, pCreateTime, pCreateWorker, pInviceNo, pStoreHourse, pRemark });

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_BillIn_Detail", billIn.QueryDetailByBillNo(billNo)));
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_WorkFlow_ApproveList", flow.TaskList(s.WorkFlowId,(int)s.WorkFlowNo)));

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
                string.Format("<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.4in</MarginLeft><MarginRight>0.3in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>", reportType);

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, "application/pdf");
        }

        #endregion

        #region 盘点
        public ActionResult BillInventoryPage(string BillNo, string CurrentUser, string StartTime, string Status, string WorkFlowId, string categoryId)
        {
            this.ViewData["WorkFlowId"] = Request.QueryString["workFlowId"];
            this.ViewData["categoryId"] = Request.QueryString["categoryId"];

            if (CurrentUser == null || CurrentUser == "")
            {
                this.ViewData["BillNo"] = string.Empty;
                this.ViewData["CurrentUser"] = this.CurrentUser.Name;
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["BillNo"] = BillNo;
                this.ViewData["CurrentUser"] = CurrentUser;
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            this.ViewData["CurrentUserID"] = this.CurrentUser.ID;
            return View();
        }

        public ActionResult BillInventoryCreateWorkerID()
        {
            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;

            var result = billInventory.BillInCreateWorkerID();
            return Json(result);
        }

        public ActionResult BillInventoryLoad(int page, int rows, string order, string sort, int? workId, DateTime startTime, string status)
        {
            if (startTime == null)
            {
                startTime = DateTime.Today;
                startTime.AddDays(-7);//缺省查询一周内入库单
            }

            if (workId == null)
            {
                workId = this.CurrentUser.ID;//缺省查询当前用户相关单据
            }

            if (status == "null" || status == "")
                status = "C";

            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;
            var result = billInventory.loadBillInventoryByPage(page, rows, order, sort, workId, startTime, status);
            return Json(result);
        }

        public ActionResult BillInventorySave(S_BILL_INVENTORY entity)
        {
            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billInventory.Save(entity);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = false, Message = e.Message }, "text/html", JsonRequestBehavior.AllowGet);
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "保存成功!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "保存失败!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

  
        public ActionResult BillInventoryDelete(string BillNo)
        {
            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = billInventory.DeleteBillInventory(BillNo);
                }
                catch (Exception)
                {

                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功!" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败!" });
                }
            }

            return View();
        }

        public ActionResult BillInventoryAudit(string BillNo)
        {
            IBillInventory billIn = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    audit = billIn.ApplyFlow(BillNo);
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

        public ActionResult BillInventoryView(string BillNo)
        {
            IBillInventory ibill = ctx["BillInventory"] as IBillInventory;

            var result = ibill.ViewBillInventory(BillNo);

            JsonResult r = Json(result);

            return r;
        }

        public ActionResult BillInventoryAuditView(int flowNo)
        {
            IBillInventory ibill = ctx["BillInventory"] as IBillInventory;

            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_BILL_INVENTORY bill = ibill.QueryBillByFlowNo(flowNo);

            this.ViewData["BillNo"] = bill.BillNo;

            return View();
        }

        public ActionResult BillInventoryBackAudit(string BillNo)
        {
            IBillInventory billIn = ctx["BillInventory"] as IBillInventory;
            if (ModelState.IsValid)
            {
                bool back;

                try
                {
                    back = billIn.BillInventoryBackAudit(BillNo, this.CurrentUser.ID);
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

        public ActionResult BillInventoryDetailCreateView(string BillNo, string categoryId)
        {
            this.ViewData["BillNo"] = BillNo;
            this.ViewData["categoryId"] = categoryId;
            return View();
        }

        public ActionResult BillInventoryDetailCreate(string BillNo, string StoreHouseId, string GoodsId)
        {
            IBillInventory inventory = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool create;

                try
                {
                    create = inventory.BillInventoryCreate(BillNo, StoreHouseId, GoodsId);
                }
                catch (Exception e)
                {

                    return Json(new { IsSuccess = true, Message = e.Message }, "text/html", JsonRequestBehavior.AllowGet);
                }

                if (create)
                {
                    return Json(new { IsSuccess = true, Message = "盘点明细生成成功!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "盘点明细生成失败!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult BillInventoryDetailLoad(int page, int rows, string order, string sort, string BillNo)
        {
            IBillInventory inventory = ctx["BillInventory"] as IBillInventory;
            var result = inventory.loadBillInventoryDetailByPage(page, rows, order, sort, BillNo);
            return Json(result);
        }

        public ActionResult BillInventoryDetailEdit(string BillNo,string Spec, int? LocationID, int? GoodsID, string BatchNo, string BookAmount, string Price, string categoryId)
        {
            this.ViewData["BillNo"] = BillNo;
            this.ViewData["categoryId"] = categoryId;

            if (GoodsID == null)
            {
                this.ViewData["LocationID"] = -1;
                this.ViewData["GoodsID"] = -1;
                this.ViewData["BatchNo"] = string.Empty;
                this.ViewData["SaveType"] = "Insert";
                this.ViewData["BookAmount"] = string.Empty;
                this.ViewData["Price"] = string.Empty;
                this.ViewData["Spec"] = string.Empty;
            }
            else
            {
                this.ViewData["LocationID"] = LocationID;
                this.ViewData["GoodsID"] = GoodsID;
                this.ViewData["BatchNo"] = BatchNo;
                this.ViewData["BookAmount"] = BookAmount;
                this.ViewData["Price"] = Price;
                this.ViewData["SaveType"] = "Update";
                this.ViewData["Spec"] = Spec;
            }
            return View();
        }

        public ActionResult BillInventoryDetailInfo(string BillNo, int? LocationID, int? GoodsID, string BatchNo)
        {
            IBillInventory bill = ctx["BillInventory"] as IBillInventory;

            return Json(bill.queryBillInventoryDetailInfo(BillNo, LocationID, GoodsID, BatchNo));
        }

        public ActionResult BillInventoryDetailSaveCheck(string billNo, int goodsId, string batchNo, int locationId) 
        {
            IBillInventory bill = ctx["BillInventory"] as IBillInventory;
            List<S_BILL_INVENTORY_DETAIL> cot = bill.GetDetailByNO(billNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.LocationID == locationId && entity.GoodsID == goodsId && entity.BatchNo == batchNo)
                {
                    return Json(new { IsSuccess = true, Message = "已经存在与“库位”、“物品”、“批次”都相同的记录" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult BillInventoryDetailSave(S_BILL_INVENTORY_DETAIL entity, string SaveType)
        {
            IBillInventory billIn = ctx["BillInventory"] as IBillInventory;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    if ("Insert" == SaveType)
                    {
                        save = billIn.InsertDetail(entity);
                    }
                    else
                    {
                        save = billIn.UpdateDetail(entity);
                    }
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

        public ActionResult BillInventoryDetailDelete(IList<string> BillNo, IList<int> LocationID, IList<int> GoodsID, IList<string> BatchNo)
        {
            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    int l = BillNo.Count;
                    IList<Anchor.FA.Model.PrimaryKeyEntity> list = new List<Anchor.FA.Model.PrimaryKeyEntity>();
                    for (int i = 0; i < l; i++)
                    {
                        Anchor.FA.Model.PrimaryKeyEntity key = new PrimaryKeyEntity("S_BILL_INVENTORY_DETAIL");
                        key.AddKeyValue("BillNo", BillNo[i]);
                        key.AddKeyValue("LocationID", LocationID[i]);
                        key.AddKeyValue("GoodsID", GoodsID[i]);
                        key.AddKeyValue("BatchNo", BatchNo[i]);
                        list.Add(key);
                    }
                    delete = billInventory.DeleteDetail(list);
                }
                catch (Exception)
                {

                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功!" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败!" });
                }
            }

            return View();
        }

        public ActionResult BillInventoryDetailRecordSave(IList<string> BillNo, IList<int> LocationID, IList<int> GoodsID, IList<string> BatchNo, IList<double> RealAmount)
        {
            IBillInventory billInventory = ctx["BillInventory"] as IBillInventory;

            if (ModelState.IsValid)
            {
                bool save = true;

                try
                {
                    if (BillNo != null)
                    {
                        int l = BillNo.Count;
                        IList<S_BILL_INVENTORY_DETAIL> list = new List<S_BILL_INVENTORY_DETAIL>();
                        for (int i = 0; i < l; i++)
                        {
                            S_BILL_INVENTORY_DETAIL detail = new S_BILL_INVENTORY_DETAIL();
                            detail.BillNo = BillNo[i];
                            detail.LocationID = LocationID[i];
                            detail.GoodsID = GoodsID[i];
                            detail.BatchNo = BatchNo[i];
                            detail.realAmount = RealAmount[i];
                            list.Add(detail);
                        }
                        save = billInventory.BillInventoryDetailRecordSave(list);
                    }
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "盘点结果保存成功!" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "盘点结果保存失败!" });
                }
            }

            return View();
        }
        
        public ActionResult PrintBillInventoryList(string billNo)
        {
            var ReportPath = Server.MapPath("~/Views/Inventory/RDLC/Rep_BillInventoryList.rdlc");

            Anchor.FA.BLL.IBLL.IBillInventory billInventory = ctx["BillInventory"] as Anchor.FA.BLL.IBLL.IBillInventory;
            Anchor.FA.Model.S_BILL_INVENTORY s = billInventory.GetBillByNO(billNo);
            string billTime = s.BillTime.ToString("yyyy-MM-dd");

            object Model = billInventory.queryDetailByBillNo(billNo);

            var localReport = new Microsoft.Reporting.WebForms.LocalReport { ReportPath = ReportPath };

            Microsoft.Reporting.WebForms.ReportParameter pBillNo = new Microsoft.Reporting.WebForms.ReportParameter("BillNo", billNo);
            Microsoft.Reporting.WebForms.ReportParameter pBillTime = new Microsoft.Reporting.WebForms.ReportParameter("BillTime", billTime);
            localReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { pBillNo, pBillTime });

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            var reportDataSource = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_BillInventoryList", Model);
            localReport.DataSources.Add(reportDataSource);

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
                string.Format("<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.4in</MarginLeft><MarginRight>0.3in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>", reportType);

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, "application/pdf");
        }
        #endregion

        private string getWorkFlowName(string workFlowId)
        {
            IFlow Flow = ctx["Flow"] as IFlow;
            if (string.IsNullOrEmpty(workFlowId))
                return null;
            int flowId = Convert.ToInt32(workFlowId);
            F_FLOW f = Flow.GetFlow(flowId);
            if (f == null)
                return null;
            return f.Name;
        }
        #region 出库单
        public ActionResult BillOutPage(string BillNo, int? pageNumber, string CurrentUser, string StartTime, string Status, string WorkFlowId, string categoryId)
        {
            this.ViewData["WorkFlowId"] = Request.QueryString["workFlowId"];
            //得到单据名称
            string WorkFlowName=getWorkFlowName(Request.QueryString["workFlowId"]);
            this.ViewData["WorkFlowName"] = WorkFlowName == null ? "出库单" : WorkFlowName;

            this.ViewData["categoryId"] = Request.QueryString["categoryId"];

            //前次选择单据号码
            if (BillNo == null || BillNo == "")
                this.ViewData["selectedBillno"] = string.Empty;
            else
                this.ViewData["selectedBillno"] = BillNo;
            //前次页码
            if (pageNumber == null || pageNumber == 0)
                this.ViewData["pageNumber"] = "1";
            else
                this.ViewData["pageNumber"] = pageNumber;

            if (CurrentUser == null || CurrentUser == "")
            {
                this.ViewData["CurrentUser"] = this.CurrentUser.Name;
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["CurrentUser"] = CurrentUser;
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            this.ViewData["CurrentUserID"] = this.CurrentUser.ID;
            return View();
        }

        public ActionResult BillOutLoad(int page, int rows, string order, string sort, int? WorkFlowId, int? workId, DateTime startTime, string status)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            //出库单缺省类型为3

            if (startTime == null)
            {
                startTime = DateTime.Today;
                startTime.AddDays(-7);//缺省查询一周内出库单
            }

            if (workId == null)
            {
                workId = this.CurrentUser.ID;//缺省查询当前用户相关单据
            }

            if (status == "null" || status == "")
                status = "C";

            var result = billOut.LoadBillOutByPage(page, rows, order, sort, WorkFlowId, workId, startTime, status);
            return Json(result);
        }

        public ActionResult BillOutView(string BillNo)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;

            var result = billOut.ViewBillOut(BillNo);
            JsonResult r = Json(result);
            return r;
        }

        public ActionResult BillOutDelete(string BillNo)
        {
            IBillOut billIOut = ctx["BillOut"] as IBillOut;

            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = billIOut.DeleteBillOut(BillNo);
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

        //public ActionResult BillOutAuditCheck(string billNo)
        //{
        //    IBillOut billOut = ctx["BillOut"] as IBillOut;
        //    List<S_BILL_OUT_DETAIL> cot = billOut.GetDetailByNO(billNo);  //获得此单据已经存在的明细 

        //    foreach (var entity in cot)
        //    {
        //        if (entity.BatchNo == "")
        //        {
        //            return Json(new { IsSuccess = true, Message = "您还有未填写完整的明细项!" }, "text/html", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        //}

        public ActionResult BillOutAudit(string BillNo)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    S_BILL_OUT bill = billOut.GetBillByNO(BillNo);
                    if (bill == null)
                        return Json(new { IsSuccess = false, Message = "提交审核失败" });

                    string re = Anchor.FA.BLL.Inventory.BLL_BillOut.ApplyFlow(bill);
                    if (re != null)
                        return Json(new { IsSuccess = false, Message = re });
                    audit = true;
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

        public ActionResult BillOutBackAudit(string BillNo)
        {
            if (ModelState.IsValid)
            {
                bool back;
                try
                {
                    string re = Anchor.FA.BLL.Inventory.BLL_BillOut.BillOutBackAudit(BillNo, this.CurrentUser.ID);
                    if (re != null)
                        return Json(new { IsSuccess = false, Message = re });
                    back = true;
                    //back = billOut.BillOutBackAudit(BillNo, this.CurrentUser.ID);
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

        public ActionResult BillOutDetailEdit(string BillNo,int StoreHouseID, int? LocationID, int? GoodsID, string BatchNo,string Spec,string StoreHouseName, string LocationName, string GoodsName, string unit, string categoryId)
        {
            this.ViewData["BillNo"] = BillNo;
            this.ViewData["categoryId"] = categoryId;

            this.ViewData["StoreHouseID"] = StoreHouseID;
            this.ViewData["StoreHouse"] = StoreHouseName;

            if (GoodsID != null)
            {
                this.ViewData["LocationID"] = LocationID;
                this.ViewData["LocationName"] = LocationName;
                this.ViewData["GoodsName"] = GoodsName;
                this.ViewData["Unit"] = unit;
                this.ViewData["Spec"] = Spec;
                this.ViewData["SaveType"] = "Update";

                PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_out_detail");
                key.AddKeyValue("billno", BillNo);
                key.AddKeyValue("locationid", LocationID);
                key.AddKeyValue("goodsid", GoodsID);
                key.AddKeyValue("batchno", BatchNo);
                IBillOut billOut = ctx["BillOut"] as IBillOut;
                S_BILL_OUT_DETAIL detail = billOut.GetDetailByPrimaryKey(key);

                IRealTimeStock realStock = ctx["RealTimeStock"] as IRealTimeStock;
                S_REALTIME_STOCK real = realStock.GetRealStockByPrimaryKey(key); 

                this.ViewData["entity"] = detail;
                this.ViewData["price"] = detail.Price.ToString("0.00");
                this.ViewData["currentAmount"] = real.CurrentAmount; 
            }
            else
            {
                S_BILL_OUT_DETAIL d = new S_BILL_OUT_DETAIL();
                d.BillNo = BillNo;
                d.BatchNo = string.Empty;
                d.ManufactureDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                d.ValidityPeriod = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

                this.ViewData["SaveType"] = "Insert";
                this.ViewData["LocationId"] = -1;
                this.ViewData["LocationName"] = string.Empty;
                this.ViewData["GoodsName"] = string.Empty;
                this.ViewData["Unit"] = string.Empty;
                this.ViewData["Spec"] = string.Empty;
                this.ViewData["entity"] = d;
            }
            return View();
        }

        public ActionResult BillOutDetailDelete(string BillNo, int GoodsId, string BatchNo, int LocationId)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_in_detail");
                    key.AddKeyValue("billno", BillNo);
                    key.AddKeyValue("goodsid", GoodsId);
                    key.AddKeyValue("batchno", BatchNo);
                    key.AddKeyValue("locationid", LocationId);

                    delete = billOut.DeleteDetail(new List<PrimaryKeyEntity>() { key });
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

        public ActionResult BillOutDetailLoad(int page, int rows, string order, string sort, string billNO)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;

            var result = billOut.LoadBillOutDetailByPage(page, rows, order, sort, billNO);
            return Json(result);
        }
        public ActionResult BillOutDetailAdd(string BillNo, int StoreHouseID, string StrGoodsID)
        { 
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            List<int> listGoodsID = new List<int>();
            foreach (string id in StrGoodsID.Split(','))
            {
                listGoodsID.Add(int.Parse(id));
            }
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billOut.InsertDetail(BillNo,listGoodsID);
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

        public ActionResult BillOutDetailSaveCheck(string billNo, int goodsId, string batchNo, int locationId)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            List<S_BILL_OUT_DETAIL> cot = billOut.GetDetailByNO(billNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.LocationID == locationId && entity.GoodsID == goodsId && entity.BatchNo == batchNo)
                {
                    return Json(new { IsSuccess = true, Message = "已经存在与“库位”、“物品”、“批次”都相同的记录" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult BillOutDetailUpdate(string BillNo, int GoodsId, string BatchNo, int LocationId, DateTime ManufactureDate, DateTime ValidityPeriod, double Price, double Amount, string OldBatch, int OldLocation)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;

            S_BILL_OUT_DETAIL entity = new S_BILL_OUT_DETAIL();
            entity.BillNo = BillNo;
            entity.GoodsID = GoodsId;
            entity.BatchNo = BatchNo;
            entity.LocationID = LocationId;
            entity.ManufactureDate = ManufactureDate;
            entity.ValidityPeriod = ValidityPeriod;
            entity.Price = entity.Price = Convert.ToDecimal(Price);
            entity.Amount = Amount;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billOut.UpdateDetail(entity, OldBatch, OldLocation);
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

        public ActionResult BillOutCreateWorkerID()
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;

            var result = billOut.BillOutCreateWorkerID();
            return Json(result);
        }

        public ActionResult BillOutAuditView(int FlowNo)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            IFlow flow = ctx["Flow"] as IFlow;

            //得到单据名称
            string WorkFlowName = getWorkFlowName(Request.QueryString["flowId"]);
            this.ViewData["WorkFlowName"] = WorkFlowName == null ? "单据" : WorkFlowName;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_BILL_OUT bill = billOut.QueryBillByFlowNo(FlowNo);
            this.ViewData["BillNo"] = bill.BillNo;
            if (bill.OldBillNo == null)
                this.ViewData["OldBillNo"] = string.Empty;
            else
                this.ViewData["OldBillNo"] = bill.OldBillNo;
            return View();
        }

        public ActionResult BillOutSave(S_BILL_OUT entity)
        {
            IBillOut billOut = ctx["BillOut"] as IBillOut;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    entity.StoreHouseID = int.Parse(Request.Form["StoreHouseID"].Substring(6));//去掉"house-"前缀

                    save = billOut.Save(entity);
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

        //public ActionResult BillOutCheckRealTimeStock(string billNo)
        //{
        //    IBillOut billOut = ctx["BillOut"] as IBillOut;
        //    S_BILL_OUT bill = billOut.GetBillByNO(billNo);

        //    try
        //    {
        //        if (billOut.CheckRealTimeStock(bill))
        //        {
        //            return Json(new { IsSuccess = true, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { IsSuccess = false, Message = "单据中存在出库数量大于实时库存数量的明细项！" }, "text/html", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Net.LogError("Inventory_BillOut", ex.ToString());
        //    }
        //    return View();
        //}
        public ActionResult PrintBillOutList(string billNo)
        {
            var ReportPath = Server.MapPath("~/Views/Inventory/RDLC/BillOut.rdlc");

            IBillOut billOut = ctx["BillOut"] as IBillOut;
            IWorker worker = ctx["Worker"] as IWorker;
            IStorehouse store = ctx["Storehouse"] as IStorehouse;
            IFlow flow = ctx["Flow"] as IFlow;
            S_BILL_OUT s = billOut.GetBillByNO(billNo);

            var localReport = new Microsoft.Reporting.WebForms.LocalReport { ReportPath = ReportPath };

            Microsoft.Reporting.WebForms.ReportParameter pBillNo = new Microsoft.Reporting.WebForms.ReportParameter("BillNo", s.BillNo);
            Microsoft.Reporting.WebForms.ReportParameter pOldBillNo = new Microsoft.Reporting.WebForms.ReportParameter("OldBillNo", string.IsNullOrEmpty(s.OldBillNo) ? " " : s.OldBillNo);
            Microsoft.Reporting.WebForms.ReportParameter pBillTime = new Microsoft.Reporting.WebForms.ReportParameter("BillTime", s.BillTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateTime = new Microsoft.Reporting.WebForms.ReportParameter("CreateTime", s.CreateTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateWorker = new Microsoft.Reporting.WebForms.ReportParameter("CreateWorker", worker.GetWorkerById(s.CreateWorkerID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pStoreHourse = new Microsoft.Reporting.WebForms.ReportParameter("StoreHourse", store.GetStorehouse((int)s.StoreHouseID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pRemark = new Microsoft.Reporting.WebForms.ReportParameter("Remark", string.IsNullOrEmpty(s.Remark) ? " " : s.Remark);

            localReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { pBillNo, pOldBillNo, pBillTime, pCreateTime, pCreateWorker, pStoreHourse, pRemark });

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_BillOut_Detail", billOut.QueryDetailByBillNo(billNo)));
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_WorkFlow_ApproveList", flow.TaskList(s.WorkFlowId, (int)s.WorkFlowNo)));

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
                string.Format("<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.4in</MarginLeft><MarginRight>0.3in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>", reportType);

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, "application/pdf");
        }
        #endregion

        #region 转库单

        #region 转库单主表
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <returns></returns>
        public ActionResult BillTransferPage(string BillNo, int? pageNumber, string CurrentUser, string StartTime, string Status, string WorkFlowId, string categoryId)
        {
            
            this.ViewData["WorkFlowId"] = Request.QueryString["workFlowId"];
            this.ViewData["categoryId"] = Request.QueryString["categoryId"];

            //前次选择单据号码
            if (BillNo == null || BillNo == "")
                this.ViewData["selectedBillno"] = string.Empty;
            else
                this.ViewData["selectedBillno"] = BillNo;
            //前次页码
            if (pageNumber == null || pageNumber == 0)
                this.ViewData["pageNumber"] = "1";
            else
                this.ViewData["pageNumber"] = pageNumber;

            if (CurrentUser == null || CurrentUser == "")
            {
                this.ViewData["CurrentUser"] = this.CurrentUser.Name;
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["CurrentUser"] = CurrentUser;
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            this.ViewData["CurrentUserID"] = this.CurrentUser.ID;
            return View();
        }

        /// <summary>
        /// 页面加载及查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <param name="WorkFlowId"></param>
        /// <param name="workId"></param>
        /// <param name="startTime"></param>
        /// <param name="status"></param>
        /// <param name="txt_in">入库库房ID</param>
        /// <param name="txt_out">出库库房ID</param>
        /// <returns></returns>
        public ActionResult BillTransferLoad(int page, int rows, string order, string sort, int? WorkFlowId, int? workId, DateTime startTime, string status, int? txt_in, int? txt_out) 
        {

            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            //转库单缺省类型为4

            if (startTime == null)
            {
                startTime = DateTime.Today;
                startTime.AddDays(-7);//缺省查询一周内入库单
            }

            if (workId == null)
            {
                workId = this.CurrentUser.ID;//缺省查询当前用户相关单据
            }

            if (status == "null" || status == "")
                status = "C";

            var result = billTransfer.LoadBillTransferByPage(page, rows, order, sort, WorkFlowId, workId, startTime, status, txt_in, txt_out);
            return Json(result);
        }

        /// <summary>
        /// 加载转库的库管员
        /// </summary>
        /// <returns></returns>
        public ActionResult BillTransferCreateWorkerID()
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            var result = billTransfer.BillTransferCreateWorkerID();
            return Json(result);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult BillTransferSave(S_BILL_TRANSFER entity)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            entity.InStoreHouseID = int.Parse(Request.Form["InStoreHouseID"].Substring(6));//去掉"house-"前缀
            entity.OutStoreHouseID = int.Parse(Request.Form["OutStoreHouseID"].Substring(6));//去掉"house-"前缀
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billTransfer.Save(entity);
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public ActionResult BillTransferDelete(string BillNo)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            bool delete;

            try
            {
                delete = billTransfer.DeleteBillTransfer(BillNo);
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

        public ActionResult BillTransferAuditCheck(string billNo) 
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            List<S_BILL_TRANSFER_DETAIL> cot = billTransfer.GetDetailByNO(billNo);  //获得此单据已经存在的明细 

            foreach (var entity in cot)
            {
                if (entity.BatchNo == "" || entity.InLocationID == 0)
                {
                    return Json(new { IsSuccess = true, Message = "您还有未填写完整的明细项!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public ActionResult BillTransferAudit(string BillNo)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    S_BILL_TRANSFER bill = billTransfer.GetBillByNO(BillNo);
                    if (bill == null)
                        return Json(new { IsSuccess = false, Message = "提交审核失败" });

                    audit = billTransfer.ApplyFlow(bill);
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
        public ActionResult BillTransferBackAudit(string BillNo)
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

        /// <summary>
        /// 入库库位
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public ActionResult BillLocation(int houseId) 
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            var result = billTransfer.GetLocation(houseId);
            return Json(result);
        }

        #region 审核页面
        public ActionResult BillTransferView(string BillNo)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            var result = billTransfer.ViewBillTransfer(BillNo);
            JsonResult r = Json(result);
            return r;
        }

        public ActionResult BillTransferAuditView(int FlowNo)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_BILL_TRANSFER bill = billTransfer.QueryBillByFlowNo(FlowNo);
            this.ViewData["BillNo"] = bill.BillNo;
            if (bill.OldBillNo == null)
                this.ViewData["OldBillNo"] = string.Empty;
            else
                this.ViewData["OldBillNo"] = bill.OldBillNo;
            return View();
        }
        #endregion

        #endregion

        #region 转库单明细
        /// <summary>
        /// 加载转库单明细
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <param name="billNo"></param>
        /// <returns></returns>
        public ActionResult BillTransferDetailLoad(int page, int rows, string order, string sort, string billNo)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            var result = billTransfer.LoadBillTransferDetailByPage(page, rows, order, sort, billNo);
            return Json(result);
        }

        public ActionResult BillTransferDetailEdit(string BillNo, string Spec, int InStoreHouseID, string InStoreHouseName, int? InLocationID, string InLocationName, int OutStoreHouseID, string OutStoreHouseName, int? OutLocationID, string OutLocationName, int? GoodsID, string BatchNo, string GoodsName, string unit, string categoryId) 
        {
            this.ViewData["BillNo"] = BillNo;
            this.ViewData["categoryId"] = categoryId;

            this.ViewData["InStoreHouseID"] = InStoreHouseID;
            this.ViewData["InStoreHouse"] = InStoreHouseName;

            this.ViewData["OutStoreHouseID"] = OutStoreHouseID;
            this.ViewData["OutStoreHouse"] = OutStoreHouseName;

            if (GoodsID != null)
            {
                this.ViewData["InLocationID"] = InLocationID;
                this.ViewData["InLocation"] = InLocationName;
                this.ViewData["OutLocationID"] = OutLocationID;
                this.ViewData["OutLocation"] = OutLocationName;
                this.ViewData["GoodsName"] = GoodsName;
                this.ViewData["Unit"] = unit;
                this.ViewData["Spec"] = Spec;
                this.ViewData["SaveType"] = "Update";

                PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_transfer_detail");
                key.AddKeyValue("billno", BillNo);
                key.AddKeyValue("inlocationid", InLocationID);
                key.AddKeyValue("outlocationid", OutLocationID);
                key.AddKeyValue("goodsid", GoodsID);
                key.AddKeyValue("batchno", BatchNo);
                IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
                S_BILL_TRANSFER_DETAIL detail = billTransfer.GetDetailByPrimaryKey(key);
                this.ViewData["entity"] = detail;
                this.ViewData["price"] = detail.Price.ToString("0.00");

                PrimaryKeyEntity real_key = new PrimaryKeyEntity("s_realtime_stock");
                real_key.AddKeyValue("billno", BillNo);
                real_key.AddKeyValue("locationid", OutLocationID);
                real_key.AddKeyValue("goodsid", GoodsID);
                real_key.AddKeyValue("batchno", BatchNo);
                IRealTimeStock realStock = ctx["RealTimeStock"] as IRealTimeStock;
                S_REALTIME_STOCK real = realStock.GetRealStockByPrimaryKey(real_key);
                this.ViewData["currentAmount"] = real.CurrentAmount; 
            }
            else
            {
                S_BILL_TRANSFER_DETAIL d = new S_BILL_TRANSFER_DETAIL();
                d.BillNo = BillNo;
                d.BatchNo = string.Empty;
                d.ManufactureDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                d.ValidityPeriod = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

                this.ViewData["SaveType"] = "Insert";
                this.ViewData["OutLocationID"] = -1;
                this.ViewData["OutLocation"] = string.Empty;
                this.ViewData["GoodsName"] = string.Empty;
                this.ViewData["Unit"] = string.Empty;
                this.ViewData["Spec"] = string.Empty;
                this.ViewData["entity"] = d;
                //this.ViewData["currentAmount"] = 0;

                IStorehouse store = ctx["Storehouse"] as IStorehouse;
                List<S_STORE_HOUSE_LOCATION> listLocation = store.GetStorageLocationByHouse(InStoreHouseID);

                if (listLocation.Count == 1)
                {
                    this.ViewData["InLocationID"] = listLocation[0].ID;//库位只有一个的话，默认选中此库位
                }
                else
                {
                    this.ViewData["InLocationID"] = -1;
                    this.ViewData["InLocation"] = string.Empty;
                }
            }

            return View();
        }

        public ActionResult BillTransferDetailAdd(string BillNo,string StrGoodsID)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            List<int> listGoodsID = new List<int>();
            foreach (string id in StrGoodsID.Split(','))
            {
                listGoodsID.Add(int.Parse(id));
            }
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billTransfer.InsertDetail(BillNo,listGoodsID);
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

        public ActionResult BillTransferDetailSaveCheck(string billNo, int goodsId, string batchNo, int inlocationId, int outlocationId)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            List<S_BILL_TRANSFER_DETAIL> cot = billTransfer.GetDetailByNO(billNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.GoodsID == goodsId && entity.BatchNo == batchNo && entity.InLocationID == inlocationId && entity.OutLocationID == outlocationId)
                {
                    return Json(new { IsSuccess = true, Message = "已经存在与“物品”、“批次”、“入库库位”、“出库库位”都相同的记录" }, "text/html", JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);

        }
        public ActionResult BillTransferDetailUpdate(string BillNo, int GoodsId, string BatchNo, int InLocationID, int OutLocationID, DateTime ManufactureDate, DateTime ValidityPeriod, double Price, double Amount, string OldBatch, int OldInLocation, int OldOutLocation)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            S_BILL_TRANSFER_DETAIL entity = new S_BILL_TRANSFER_DETAIL();
            entity.BillNo = BillNo;
            entity.GoodsID = GoodsId;
            entity.BatchNo = BatchNo;
            entity.InLocationID = InLocationID;
            entity.OutLocationID = OutLocationID;
            entity.ManufactureDate = ManufactureDate;
            entity.ValidityPeriod = ValidityPeriod;
            entity.Price = entity.Price = Convert.ToDecimal(Price);
            entity.Amount = Amount;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billTransfer.UpdateDetail(entity, OldBatch, OldInLocation, OldOutLocation);
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
        ///// 保存转库单明细
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <param name="SaveType"></param>
        ///// <returns></returns>
        //public ActionResult BillTransferDetailSave(S_BILL_TRANSFER_DETAIL entity, string SaveType)
        //{
        //    IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
        //    if (ModelState.IsValid)
        //    {
        //        bool save;

        //        try
        //        {
        //            if ("Insert" == SaveType)
        //            {
        //                save = billTransfer.InsertDetail(entity);
        //            }
        //            else
        //            {
        //                save = billTransfer.UpdateDetail(entity);
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            save = false;
        //        }

        //        if (save)
        //        {
        //            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { IsSuccess = false, Message = "保存失败" }, "text/html", JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return View();
        //}

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="BillNo">单据号</param>
        /// <param name="GoodsId">物品ID</param>
        /// <param name="BatchNo">批次号</param>
        /// <param name="InLocationID">入库库位ID</param>
        /// <param name="OutlocationID">出库库位ID</param>
        /// <returns></returns>
        public ActionResult BillTransferDetailDelete(string BillNo, int GoodsId, string BatchNo, int InLocationID, int OutlocationID)
        {
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    PrimaryKeyEntity key = new PrimaryKeyEntity("s_bill_transfer_detail");
                    key.AddKeyValue("billno", BillNo);
                    key.AddKeyValue("goodsid", GoodsId);
                    key.AddKeyValue("batchno", BatchNo);
                    key.AddKeyValue("Inlocationid", InLocationID);
                    key.AddKeyValue("Outlocationid", OutlocationID);

                    delete = billTransfer.DeleteDetail(new List<PrimaryKeyEntity>() { key });
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
        #endregion

        public ActionResult BillTransferCheckRealTimeStock(string billNo) 
        {
            try
            {
                IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
                S_BILL_TRANSFER bill = billTransfer.GetBillByNO(billNo);

                if (billTransfer.CheckRealTimeStock(bill))
                {
                    return Json(new { IsSuccess = true, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "单据中存在转出数量大于实时库存数量的明细项！" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogError("Inventory_BillTransfer", ex.ToString());
            }
            return View();
        }


        public ActionResult PrintBillTransferList(string billNo)
        {
            var ReportPath = Server.MapPath("~/Views/Inventory/RDLC/BillTransfer.rdlc");

            IBillTransfer BillTransfer = ctx["BillTransfer"] as IBillTransfer;
            IWorker worker = ctx["Worker"] as IWorker;
            IStorehouse store = ctx["Storehouse"] as IStorehouse;
            IFlow flow = ctx["Flow"] as IFlow;
            S_BILL_TRANSFER s = BillTransfer.GetBillByNO(billNo);

            var localReport = new Microsoft.Reporting.WebForms.LocalReport { ReportPath = ReportPath };

            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_BillOut_Detail", BillTransfer.QueryDetailByBillNo(billNo)));
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_WorkFlow_ApproveList", flow.TaskList(s.WorkFlowId, (int)s.WorkFlowNo)));

            Microsoft.Reporting.WebForms.ReportParameter pBillNo = new Microsoft.Reporting.WebForms.ReportParameter("BillNo", s.BillNo);
            Microsoft.Reporting.WebForms.ReportParameter pOldBillNo = new Microsoft.Reporting.WebForms.ReportParameter("OldBillNo", string.IsNullOrEmpty(s.OldBillNo) ? " " : s.OldBillNo);
            Microsoft.Reporting.WebForms.ReportParameter pBillTime = new Microsoft.Reporting.WebForms.ReportParameter("BillTime", s.BillTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateTime = new Microsoft.Reporting.WebForms.ReportParameter("CreateTime", s.CreateTime.ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateWorker = new Microsoft.Reporting.WebForms.ReportParameter("CreateWorker", worker.GetWorkerById(s.CreateWorkerID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pInStoreHourse = new Microsoft.Reporting.WebForms.ReportParameter("InStoreHourse", store.GetStorehouse((int)s.InStoreHouseID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pOutStoreHourse = new Microsoft.Reporting.WebForms.ReportParameter("OutStoreHourse", store.GetStorehouse((int)s.OutStoreHouseID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pRemark = new Microsoft.Reporting.WebForms.ReportParameter("Remark", string.IsNullOrEmpty(s.Remark) ? " " : s.Remark);

            localReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { pBillNo, pOldBillNo, pBillTime, pCreateTime, pCreateWorker, pInStoreHourse, pOutStoreHourse, pRemark });

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
                string.Format("<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.4in</MarginLeft><MarginRight>0.3in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>", reportType);

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, "application/pdf");
        }
        #endregion

        #region 实时库存
        //public ActionResult RealTimeStock(string categoryId)
        //{
        //    this.ViewData["categoryId"] = categoryId;
        //    return View();
        //}

        //public ActionResult QueryStock(int page, int rows, int goodsId)
        //{
        //    IRealTimeStock stock = ctx["RealTimeStock"] as IRealTimeStock;

        //    return Json(stock.Query(goodsId, page, rows));
        //}

        //public ActionResult Real_StoreHouse(string houseId)
        //{
        //    this.ViewData["houseId"] = int.Parse(houseId.Substring(6));
        //    return View();
        //}
        //public ActionResult LoadGoodsByStoreHouse(int page, int rows, string order, string sort, int houseId, string name, int? num, string text) 
        //{
        //    IRealTimeStock stock = ctx["RealTimeStock"] as IRealTimeStock;

        //    var result = stock.LoadGoodsByStoreHouse(page, rows, order, sort, houseId, name, num,text);

        //    return Json(result);
        //}

        public ActionResult RealTimeStock(string categoryId, string storeHouseId,string me)
        {
            if (me == "t")
            {
                S_STORE_HOUSE_LOCATION l=Anchor.FA.BLL.Inventory.Storehouse.GetStoreHouseLocation(this.CurrentUserID);
                if (l != null)
                {
                    this.ViewData["storeHouseId"] = l.StoreHouseID;
                }
                else
                { 
                    //需要让本人查不到任何库存
                    this.ViewData["storeHouseId"] = -1;//库存号为-1不存在
                }
            }
            else
            {
                this.ViewData["storeHouseId"] = storeHouseId;
            }
            this.ViewData["categoryId"] = categoryId;
            return View();
        }
        public ActionResult LoadGoodsByStoreHouse(int page, int rows, string order, string sort
            , string SetStoreHouseId, string SetCategoryId
    , string CateoryId, string TreeStoreHouseId, string GoodsID, string GoodsName, string Abbreviation, string Spec)
        {
            var result = Anchor.FA.BLL.Inventory.BLL_RealTime_Stock.LoadGoodsByStoreHouse(page, rows, order, sort
                ,SetStoreHouseId,SetCategoryId
            , CateoryId, TreeStoreHouseId, GoodsID, GoodsName, Abbreviation, Spec);

            return Json(result);
        }

        public ActionResult ExportGoodsByStoreHouse(string SetStoreHouseId, string SetCategoryId, 
string CateoryId, string TreeStoreHouseId, string GoodsID, string GoodsName, string Abbreviation, string Spec)
        {
            DataSet dsReport = Anchor.FA.BLL.Inventory.BLL_RealTime_Stock.ExportGoodsByStoreHouse(SetStoreHouseId, SetCategoryId,
CateoryId, TreeStoreHouseId,  GoodsID, GoodsName, Abbreviation,  Spec);

            string folderPath = Server.MapPath("~/ExcelFile");

            if (!folderPath.EndsWith("/") && !folderPath.EndsWith("\\"))
            {
                folderPath += "/";
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            string excelPath = folderPath + "\\" + fileName;

            FA.Utility.Excel.ExportToExcel(dsReport, excelPath);

            return File(excelPath, "application/ms-excel", fileName);
        }

        #endregion

        #region 领药申请单
        public ActionResult DrugApplyPage(string categoryId, int WorkFlowId, string StartTime, string Status)
        {
            this.ViewData["categoryId"] = categoryId;
            this.ViewData["WorkFlowId"] = WorkFlowId;

            if (StartTime == null || StartTime == "")
            {
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            this.ViewData["CurrentUserID"] = this.CurrentUser.ID;
            //添加 判断本人是否有库位
            if (Anchor.FA.BLL.Inventory.Storehouse.GetStoreHouseLocation(this.CurrentUserID) == null)
            {
                this.ViewData["HaveStoreHouseLocation"] = "F";
            }
            else
            {
                this.ViewData["HaveStoreHouseLocation"] = "T";
            }
            return View();
        }

        public ActionResult DrugApplyLoad(int page, int rows, string order, string sort, int workFlowId,DateTime startTime, string status)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;

            var result = drugApply.DrugApplyLoad(page, rows, order, sort, workFlowId,startTime, status, this.CurrentUser.ID);
            return Json(result);
        }

        //public ActionResult DrugApplyCreateBill(bool IsAuto)
        //{
        //    IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
        //    int userid = this.CurrentUser.ID;
        //    S_Drug_Apply result = drugApply.CreateBill(userid, IsAuto);
        //    return Json(result);
        //}

        public ActionResult DrugApplySave(S_Drug_Apply entity, string IsAuto)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool save;
                string ms = "保存失败";
                try
                {
                    save = drugApply.SaveBill(entity, IsAuto);

                }
                catch (Exception ex)
                {
                    ms ="保存失败! "+ ex.ToString();
                    Log4Net.LogError("DrugApplySave", ex.ToString());
                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = ms }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult DrugApplyDelete(int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.DeleteBill(BillNo);
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult DrugApplyDetailLoad(int page, int rows, string order, string sort, int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            var result = drugApply.LoadDetail(page, rows, order, sort, BillNo);
            return Json(result);
        }

        public ActionResult DrugApplyDetailSaveCheck(int billNo, int goodsId)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.DetailSaveCheck(billNo, goodsId);
                }
                catch (Exception)
                {
                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "物品重复，请重新选择！" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult DrugApplyDetailAdd(int? CenterStoreHouse, int BillNo, string StrGoodsID) 
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            List<int> listGoodsID = new List<int>();
            foreach (string id in StrGoodsID.Split(','))   
            {
                listGoodsID.Add(int.Parse(id)); 
            }
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.InsertDetail(CenterStoreHouse,BillNo, listGoodsID);
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

        public ActionResult DrugApplyDetailUpdate(int BillNo, int GoodsID, double Amount)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;

            S_Drug_Apply_Detail entity = new S_Drug_Apply_Detail();
            entity.BillNo = BillNo;
            entity.GoodsID = GoodsID;
            entity.Amount = Amount;

            if (ModelState.IsValid)
            {
                bool save = true;

                try
                {
                    save = drugApply.UpdateDetail(entity);
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

        public ActionResult DrugApplyDetailEdit(string CenterStoreHouse, string categoryId, string SaveType,string BillNo, int? GoodsID, string Spec, string GoodsName, string unit, float? Amount)
        {
            this.ViewData["CenterStoreHouse"] = CenterStoreHouse == null ? "" : CenterStoreHouse;
            this.ViewData["categoryId"] = categoryId;
            this.ViewData["SaveType"] = SaveType;
            this.ViewData["BillNo"] = BillNo;
            if (GoodsID == null)
            {
                this.ViewData["GoodsID"] = string.Empty;
                this.ViewData["Spec"] = string.Empty;
                this.ViewData["GoodsName"] = string.Empty;
                this.ViewData["Unit"] = string.Empty;
                this.ViewData["Amount"] = string.Empty;
            }
            else
            {
                this.ViewData["GoodsID"] = GoodsID;
                this.ViewData["Spec"] = Spec;
                this.ViewData["GoodsName"] = GoodsName;
                this.ViewData["Unit"] = unit;
                this.ViewData["Amount"] = Amount.ToString();
            }
            return View();
        }


        public ActionResult DrugApplyDetailDelete(int BillNo, int GoodsId)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = drugApply.DeleteDetail(BillNo, GoodsId);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除明细成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除明细失败" });
                }
            }

            return View();
        }

        public ActionResult DrugApplyAuditView(int flowNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_Drug_Apply apply = drugApply.queryByFlowNo(flowNo);
            this.ViewData["BillNo"] = apply.BillNo;

            return View();
        }

        //public ActionResult DrugApplyPerformPage(int CenterStoreHouse, string categoryId,string StartTime, string Status)
        //{
        //    this.ViewData["CenterStoreHouse"] = CenterStoreHouse;
        //    this.ViewData["categoryId"] = categoryId;

        //    if (StartTime == null || StartTime == "")
        //    {
        //        ViewData["Status"] = "S";
        //        DateTime start = DateTime.Today;
        //        start = start.AddDays(-7);
        //        this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
        //    }
        //    else
        //    {
        //        this.ViewData["Status"] = Status;
        //        this.ViewData["StartTime"] = StartTime;
        //    }
        //    return View();
        //}

        public ActionResult DrugApplyPerformCheckRealStock(int BillNo) 
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;

            S_Drug_Apply bill = drugApply.queryByBillNo(BillNo);
            S_BILL_TRANSFER main = billTransfer.GetBillByNO(bill.TransferBillNo);
            try
            {
                if (billTransfer.CheckRealTimeStock(main))
                {
                    return Json(new { IsSuccess = true, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "单据中存在实领数量大于实时库存数量的明细项！" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogError("Inventory_BillTransfer", ex.ToString());
            }
            return View();
        }

        public ActionResult DrugApplyPerformView(int CenterStoreHouse, string categoryId, int flowNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            int userID = this.CurrentUser.ID;

            S_Drug_Apply bill = drugApply.queryByFlowNo(flowNo);
            if (bill != null)
            {
                if (!"Y".Equals(bill.Status) & !"D".Equals(bill.Status) & !"O".Equals(bill.Status))
                {
                    if (string.IsNullOrEmpty(bill.TransferBillNo))
                    {
                        //第一次进审核页面
                        drugApply.PerformApply(CenterStoreHouse, bill.BillNo, userID); 
                    }
                    else
                    { 
                        //检查是否所有库存数量大于0的物品批次都已生成转库单
                        drugApply.CheckPerform(bill.TransferBillNo);    
                    }
                }
                this.ViewData["BillNo"] = bill.BillNo;
            }

            this.ViewData["StoreHouseID"] = CenterStoreHouse;
            this.ViewData["categoryId"] = categoryId;
           
            return View();
        }

        public ActionResult DrugApplyView(int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            var bill = drugApply.queryInfoByBillNo(BillNo);
            return Json(bill);
        }

        /// <summary>
        /// 申请单物品出库明细
        /// </summary>
        /// <param name="BillNo">申请单单据号</param>
        /// <param name="GoodsID">物品编号</param>
        /// <returns></returns>
        public ActionResult DrugApply2TransferLoad(int BillNo, int GoodsID, int StoreHouseID)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            var result = drugApply.Apply2TransferGoodsLoad(BillNo, GoodsID, StoreHouseID);
            return Json(result);
        }

        /// <summary>
        /// 发药
        /// </summary>
        /// <param name="BillNo"></param>
        /// <param name="GoodsID"></param>
        /// <param name="InLocationID"></param>
        /// <param name="OutLocationID"></param>
        /// <param name="BatchNo"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public ActionResult DrugApplyPerformRecordSave(string BillNo, int GoodsID, IList<int> InLocationID, IList<int> OutLocationID, IList<string> BatchNo, IList<double> Amount)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.PerformRecordSave(BillNo, GoodsID, InLocationID, OutLocationID, BatchNo, Amount);
                }
                catch (Exception)
                {
                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "领用明细保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "领用明细保存失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        /// <summary>
        /// 发药完成
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public ActionResult DrugApplyOver(int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            IBillTransfer billTransfer = ctx["BillTransfer"] as IBillTransfer;
            IApprovedAction approve = ctx["BillTransfer"] as IApprovedAction;

            if (ModelState.IsValid)
            {
                bool audit;

                try
                {
                    S_Drug_Apply bill = drugApply.queryByBillNo(BillNo);
                    if (bill == null)
                        return Json(new { IsSuccess = false, Message = "申请单确认失败" });

                    S_BILL_TRANSFER bill_t = billTransfer.GetBillByNO(bill.TransferBillNo);
                    if (bill_t == null)
                        return Json(new { IsSuccess = false, Message = "申请单确认失败" });

                    bill_t.WorkFlowNo = bill.WorkFlowNo;
                    bill_t.WorkFlowId = 4;
                    bill_t.Remark = "来自领药申请单:" + BillNo;

                    audit = billTransfer.Save(bill_t);
                    if (audit)
                    {
                        audit = approve.Complete(bill_t.WorkFlowNo.Value, "Y");
                        if (audit)
                        {
                            audit = drugApply.UpdateStatus(bill, "O");
                        }
                    }
                }
                catch (Exception)
                {

                    audit = false;
                }

                if (audit)
                {
                    return Json(new { IsSuccess = true, Message = "申请单确认成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "申请单确认失败" });
                }
            }

            return View();
        }

        public ActionResult DrugApplyAuditCheck(int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            List<S_Drug_Apply_Detail> cot = drugApply.GetDetailByBillNo(BillNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.Amount == 0)
                {
                    return Json(new { IsSuccess = true, Message = "您还有未填写数量的明细项!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DrugApplyAudit(int WorkFlowId, int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.ApplyFlow(WorkFlowId, BillNo);
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "提交审核成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "提交审核失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult DrugApplyBackAudit(int WorkFlowId, int BillNo)
        {
            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = drugApply.BillTransferBackAudit(WorkFlowId, BillNo);
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "撤销审核成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "撤销审核失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult PrintDrugApplyList(int billNo)
        {
            var ReportPath = Server.MapPath("~/Views/Inventory/RDLC/DrugApply.rdlc");

            IDrugApply drugApply = ctx["DrugApply"] as IDrugApply;
            IWorker worker = ctx["Worker"] as IWorker;
            IStorehouse store = ctx["Storehouse"] as IStorehouse;
            IFlow flow = ctx["Flow"] as IFlow;
            S_Drug_Apply s = drugApply.queryByBillNo(billNo);

            var localReport = new Microsoft.Reporting.WebForms.LocalReport { ReportPath = ReportPath };

            Microsoft.Reporting.WebForms.ReportParameter pBillNo = new Microsoft.Reporting.WebForms.ReportParameter("BillNo", s.BillNo.ToString());
            Microsoft.Reporting.WebForms.ReportParameter pCreateTime = new Microsoft.Reporting.WebForms.ReportParameter("CreateTime", ((DateTime)s.CreateTime).ToString("yyyy-MM-dd"));
            Microsoft.Reporting.WebForms.ReportParameter pCreateWorker = new Microsoft.Reporting.WebForms.ReportParameter("CreateWorker", worker.GetWorkerById(s.CreateWorkerID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pStoreHourse = new Microsoft.Reporting.WebForms.ReportParameter("StoreHourse", store.GetStorehouse((int)s.StoreHouseID).Name);
            Microsoft.Reporting.WebForms.ReportParameter pRemark = new Microsoft.Reporting.WebForms.ReportParameter("Remark", string.IsNullOrEmpty(s.Remark) ? " " : s.Remark);

            localReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { pBillNo,pCreateTime, pCreateWorker, pStoreHourse, pRemark });

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_DrugApply_Detail", drugApply.LoadDetailByBillNo(billNo)));
            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet_WorkFlow_ApproveList", flow.TaskList(s.WorkFlowId, (int)s.WorkFlowNo)));

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
                string.Format("<DeviceInfo><OutputFormat>{0}</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight><MarginTop>0.2in</MarginTop><MarginLeft>0.4in</MarginLeft><MarginRight>0.3in</MarginRight><MarginBottom>0.2in</MarginBottom></DeviceInfo>", reportType);

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, "application/pdf");
        }

        #endregion

        #region 领用申请单
        public ActionResult BillApplyPage(string categoryId, int WorkFlowId, string StartTime, string Status)
        {
            this.ViewData["categoryId"] = categoryId;
            this.ViewData["WorkFlowId"] = WorkFlowId;

            if (StartTime == null || StartTime == "")
            {
                this.ViewData["Status"] = "S";
                DateTime start = DateTime.Today;
                start = start.AddMonths(-1);
                this.ViewData["StartTime"] = start.ToString("yyyy-MM-dd");
            }
            else
            {
                this.ViewData["Status"] = Status;
                this.ViewData["StartTime"] = StartTime;
            }
            return View();
        }

        public ActionResult BillApplyCreateBill()
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            int userid = this.CurrentUser.ID;
            S_BILL_APPLY result = billApply.CreateBill(userid);
            return Json(result);
        }


        public ActionResult BillApplyLoad(int page, int rows, string order, string sort, DateTime startTime, string status)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            var result = billApply.BillApplyLoad(page, rows, order, sort, startTime, status, this.CurrentUser.ID);
            return Json(result);
        }

        public ActionResult BillApplyLoadPerform(int page, int rows, string order, string sort, DateTime startTime, string status)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            var result = billApply.BillApplyLoad(page, rows, order, sort, startTime, status);
            return Json(result);
        }


        public ActionResult BillApplySave(S_BILL_APPLY entity)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.SaveBill(entity);
                }
                catch (Exception ex)
                {
                    Log4Net.LogError("BillApplySave", ex.ToString());

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

        public ActionResult BillApplyDelete(int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.DeleteBill(BillNo);
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "删除成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult BillApplyAuditCheck(int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            List<S_BILL_APPLY_DETAIL> cot = billApply.GetDetailByBillNo(BillNo);  //获得此单据已经存在的明细

            foreach (var entity in cot)
            {
                if (entity.Amount == 0)
                {
                    return Json(new { IsSuccess = true, Message = "您还有未填写数量的明细项!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { IsSuccess = false, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult BillApplyAudit(int WorkFlowId, int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.ApplyFlow(WorkFlowId, BillNo);
                }
                catch (Exception ex)
                {
                    Log4Net.LogError("BillApplyAudit",ex.ToString());
                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "提交审核成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "提交审核失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult BillApplyBackAudit(int WorkFlowId, int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.BillApplyBackAudit(WorkFlowId, BillNo);
                }
                catch (Exception)
                {

                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "撤销审核成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "撤销审核失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult BillApplyDetailLoad(int page, int rows, string order, string sort, int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            var result = billApply.LoadDetail(page, rows, order, sort, BillNo);
            return Json(result);
        }

        public ActionResult BillApplyDetailDelete(int BillNo, int GoodsId)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            if (ModelState.IsValid)
            {
                bool delete;

                try
                {
                    delete = billApply.DeleteDetail(BillNo, GoodsId);
                }
                catch (Exception)
                {
                    delete = false;
                }

                if (delete)
                {
                    return Json(new { IsSuccess = true, Message = "删除明细成功" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "删除明细失败" });
                }
            }

            return View();
        }

        public ActionResult BillApplyDetailUpdate(int BillNo, int GoodsID, double Amount)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            S_BILL_APPLY_DETAIL entity = new S_BILL_APPLY_DETAIL();
            entity.BillNo = BillNo;
            entity.GOODSID = GoodsID;
            entity.Amount = Amount;

            if (ModelState.IsValid)
            {
                bool save = true;

                try
                {
                    save = billApply.UpdateDetail(entity);
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
        public ActionResult BillApplyDetailAdd(int? CenterStoreHouse, int BillNo, string StrGoodsID)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            List<int> listGoodsID = new List<int>();
            foreach (string id in StrGoodsID.Split(','))
            {
                listGoodsID.Add(int.Parse(id));
            }
            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.InsertDetail(CenterStoreHouse, BillNo, listGoodsID);
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

        public ActionResult BillApplyAuditView(int flowNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            S_BILL_APPLY apply = billApply.queryByFlowNo(flowNo);
            this.ViewData["BillNo"] = apply.BillNo;

            return View();
        }

        public ActionResult BillApplyView(int BillNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            var bill = billApply.queryInfoByBillNo(BillNo);
            return Json(bill);
        }

        public ActionResult BillApplyPerformView(int CenterStoreHouse, string categoryId, int flowNo)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            IFlow flow = ctx["Flow"] as IFlow;

            int flowInstId = int.Parse(Request.QueryString["flowInstId"]);
            this.ViewData["TaskListHTML"] = flow.TaskListScript(flowInstId);

            int userID = this.CurrentUser.ID;

            S_BILL_APPLY bill = billApply.queryByFlowNo(flowNo);
            if (bill != null)
            {
                if (!"Y".Equals(bill.Status))
                {
                    if (string.IsNullOrEmpty(bill.BillOutNo))
                    {
                        //第一次进审核页面
                        billApply.PerformApply(CenterStoreHouse, bill.BillNo, userID);
                    }
                    else
                    {
                        //检查是否所有库存数量大于0的物品批次都已生成转库单
                        billApply.CheckPerform(bill.BillOutNo);
                    }
                }
                this.ViewData["BillNo"] = bill.BillNo;
            }

            this.ViewData["StoreHouseID"] = CenterStoreHouse;
            this.ViewData["categoryId"] = categoryId;

            return View();
        }

        public ActionResult LoadOutGoods(int BillNo, int GoodsID, int StoreHouseID)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;
            var result = billApply.LoadOutGoods(BillNo, GoodsID, StoreHouseID);
            return Json(result);
        }

        public ActionResult BillApplyPerformRecordSave(string BillNo, int GoodsID, IList<int> InLocationID, IList<int> OutLocationID, IList<string> BatchNo, IList<double> Amount)
        {
            IBillApply billApply = ctx["BillApply"] as IBillApply;

            if (ModelState.IsValid)
            {
                bool save;

                try
                {
                    save = billApply.PerformRecordSave(BillNo, GoodsID, OutLocationID, BatchNo, Amount);
                }
                catch (Exception)
                {
                    save = false;
                }

                if (save)
                {
                    return Json(new { IsSuccess = true, Message = "领用明细保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "领用明细保存失败" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        public ActionResult BillApplyPerformCheckRealStock(int BillNo)
        {
            IBillApply drugApply = ctx["BillApply"] as IBillApply;
            IBillOut billOut = ctx["BillOut"] as IBillOut;

            S_BILL_APPLY bill = drugApply.queryByBillNo(BillNo);
            S_BILL_OUT main = billOut.GetBillByNO(bill.BillOutNo);

            try
            {
                if (billOut.CheckRealTimeStock(main))
                {
                    return Json(new { IsSuccess = true, Message = "" }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "单据中存在实领数量大于可用数量的明细项！" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogError("Inventory_BillOut", ex.ToString());
            }
            return View();
        }
        #endregion
    }
}
