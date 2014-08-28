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
    public partial class UserGroupModulePermissionControllerTemp : BaseController {
    		private object ToJson(UserGroupModulePermission e) {
    			return new {
    				Id=e.Id,
    			UserGroupId=e.UserGroupId,
    			ModuleId=e.ModuleId
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, UserGroupModulePermission e);
    	partial void AfterAddData(UserGroupModulePermission e, ref ActionResult ar);
    	partial void AfterUpdateData(UserGroupModulePermission e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, UserGroupModulePermission e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(UserGroupModulePermission e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(UserGroupModulePermission e, ref ActionResult ar) {
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
