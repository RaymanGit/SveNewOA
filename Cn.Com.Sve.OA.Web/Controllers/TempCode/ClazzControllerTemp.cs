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
    public partial class ClazzControllerTemp : BaseController {
    		private object ToJson(Clazz e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			Semester=e.Semester,
    			StudentQty=e.StudentQty,
    			LimitedQty=e.LimitedQty,
    			TeacherA=e.TeacherA,
    			TeacherB=e.TeacherB,
    			Master=e.Master,
    			Governor=e.Governor,
    			OpenDate=e.OpenDate,
    			ClosedDate=e.ClosedDate,
    			FinishedDate=e.FinishedDate,
    			IsOpen=e.IsOpen,
    			IsClosed=e.IsClosed,
    			IsFinished=e.IsFinished,
    			CreateTime=e.CreateTime,
    			UpdateTime=e.UpdateTime,
    			KickOffDate=e.KickOffDate
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, Clazz e);
    	partial void AfterAddData(Clazz e, ref ActionResult ar);
    	partial void AfterUpdateData(Clazz e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, Clazz e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(Clazz e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(Clazz e, ref ActionResult ar) {
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
