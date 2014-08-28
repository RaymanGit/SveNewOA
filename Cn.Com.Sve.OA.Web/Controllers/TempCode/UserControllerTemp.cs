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
    public partial class UserControllerTemp : BaseController {
    		private object ToJson(User e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			Password=e.Password,
    			Status=e.Status,
    			LastLoginTime=e.LastLoginTime,
    			LastLoginIP=e.LastLoginIP,
    			DefaultUrl=e.DefaultUrl
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, User e);
    	partial void AfterAddData(User e, ref ActionResult ar);
    	partial void AfterUpdateData(User e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, User e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(User e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(User e, ref ActionResult ar) {
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
