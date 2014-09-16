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
    public partial class EmploymentCompanyContactVisitLogControllerTemp : BaseController {
    		private object ToJson(EmploymentCompanyContactVisitLog e) {
    			return new {
    				Id=e.Id,
    			CompanyContactId=e.CompanyContactId,
    			Time=e.Time,
    			VisitorId=e.VisitorId,
    			Type=e.Type,
    			Content=e.Content
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, EmploymentCompanyContactVisitLog e);
    	partial void AfterAddData(EmploymentCompanyContactVisitLog e, ref ActionResult ar);
    	partial void AfterUpdateData(EmploymentCompanyContactVisitLog e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, EmploymentCompanyContactVisitLog e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(EmploymentCompanyContactVisitLog e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(EmploymentCompanyContactVisitLog e, ref ActionResult ar) {
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
