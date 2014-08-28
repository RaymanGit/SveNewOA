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
    public partial class ImportDupliateControllerTemp : BaseController {
    		private object ToJson(ImportDupliate e) {
    			return new {
    				Id=e.Id,
    			ImportKey=e.ImportKey,
    			CustomerId=e.CustomerId,
    			ImportId=e.ImportId,
    			SchoolName=e.SchoolName,
    			Name=e.Name,
    			Tel=e.Tel,
    			Mobile=e.Mobile,
    			Score=e.Score,
    			ErrorMsg=e.ErrorMsg
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, ImportDupliate e);
    	partial void AfterAddData(ImportDupliate e, ref ActionResult ar);
    	partial void AfterUpdateData(ImportDupliate e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, ImportDupliate e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(ImportDupliate e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(ImportDupliate e, ref ActionResult ar) {
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
