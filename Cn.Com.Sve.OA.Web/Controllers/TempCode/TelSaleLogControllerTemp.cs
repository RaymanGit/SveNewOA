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
    public partial class TelSaleLogControllerTemp : BaseController {
    		private object ToJson(TelSaleLog e) {
    			return new {
    				Id=e.Id,
    			CustomerId=e.CustomerId,
    			Content=e.Content,
    			NextTelTime=e.NextTelTime,
    			SalesmanId=e.SalesmanId,
    			TelTime=e.TelTime,
    			IsConvert=e.IsConvert,
    			IsSignUp=e.IsSignUp,
    			ConsultType=e.ConsultType
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, TelSaleLog e);
    	partial void AfterAddData(TelSaleLog e, ref ActionResult ar);
    	partial void AfterUpdateData(TelSaleLog e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, TelSaleLog e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(TelSaleLog e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(TelSaleLog e, ref ActionResult ar) {
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
