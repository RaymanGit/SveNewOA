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
    public partial class EmploymentCompanyControllerTemp : BaseController {
    		private object ToJson(EmploymentCompany e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			Type=e.Type,
    			Important=e.Important,
    			Website=e.Website,
    			Telephone=e.Telephone,
    			Fax=e.Fax,
    			Address=e.Address,
    			CityId=e.CityId,
    			Introduction=e.Introduction,
    			SourceType=e.SourceType,
    			Referer=e.Referer,
    			UserId=e.UserId,
    			EmployedQty=e.EmployedQty,
    			OldOaId=e.OldOaId,
    			TempProvId=e.TempProvId,
    			TempProvName=e.TempProvName,
    			TempCityId=e.TempCityId,
    			TempCityName=e.TempCityName,
    			AddTime=e.AddTime
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, EmploymentCompany e);
    	partial void AfterAddData(EmploymentCompany e, ref ActionResult ar);
    	partial void AfterUpdateData(EmploymentCompany e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, EmploymentCompany e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(EmploymentCompany e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(EmploymentCompany e, ref ActionResult ar) {
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
