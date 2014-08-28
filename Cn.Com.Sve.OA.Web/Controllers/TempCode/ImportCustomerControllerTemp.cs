using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cn.Com.Sve.OA.BusinessService;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
using Cn.Com.Sve.OA.Web.Models;
using Cn.RaymanLee.Web.UI.ViewModels.LigerUI;
using Cn.RaymanLee.Data;


namespace Cn.Com.Sve.OA.Web.Controllers.TempCode {
    public partial class ImportCustomerControllerTemp : BaseController {
    		private object ToJson(ImportCustomer e) {
    			return new {
    				Id=e.Id,
    			ImportKey=e.ImportKey,
    			SchoolId=e.SchoolId,
    			SchoolName=e.SchoolName,
    			Level=e.Level,
    			MarketYear=e.MarketYear,
    			InfoSource=e.InfoSource,
    			Name=e.Name,
    			Gender=e.Gender,
    			Tel=e.Tel,
    			ProvinceId=e.ProvinceId,
    			ProvinceName=e.ProvinceName,
    			CityId=e.CityId,
    			CityName=e.CityName,
    			DistrictId=e.DistrictId,
    			DistrictName=e.DistrictName,
    			Address=e.Address,
    			Mobile=e.Mobile,
    			QQ=e.QQ,
    			Clazz=e.Clazz,
    			Score=e.Score,
    			Postcode=e.Postcode,
    			Contact=e.Contact,
    			ImportType=e.ImportType,
    			IsProcessed=e.IsProcessed,
    			ErrorMsg=e.ErrorMsg
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, ImportCustomer e);
    	partial void AfterAddData(ImportCustomer e, ref ActionResult ar);
    	partial void AfterUpdateData(ImportCustomer e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, ImportCustomer e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(ImportCustomer e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(ImportCustomer e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    
    	public ActionResult GetInitData() {
    		return this.Json(new {}, JsonRequestBehavior.AllowGet);
    	}
    }
}
