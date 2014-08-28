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
    public partial class QualificationUnrestrictedUserControllerTemp : BaseController {
    		private object ToJson(QualificationUnrestrictedUser e) {
    			return new {
    				Id=e.Id,
    			UserName=e.UserName
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, QualificationUnrestrictedUser e);
    	partial void AfterAddData(QualificationUnrestrictedUser e, ref ActionResult ar);
    	partial void AfterUpdateData(QualificationUnrestrictedUser e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, QualificationUnrestrictedUser e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(QualificationUnrestrictedUser e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(QualificationUnrestrictedUser e, ref ActionResult ar) {
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
