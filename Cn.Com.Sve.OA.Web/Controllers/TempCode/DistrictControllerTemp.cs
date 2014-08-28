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
    public partial class DistrictControllerTemp : BaseController {
    		private object ToJson(District e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			CityId=e.CityId,
    			PhonePrefix=e.PhonePrefix,
    			Postcode=e.Postcode
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, District e);
    	partial void AfterAddData(District e, ref ActionResult ar);
    	partial void AfterUpdateData(District e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, District e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(District e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(District e, ref ActionResult ar) {
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
