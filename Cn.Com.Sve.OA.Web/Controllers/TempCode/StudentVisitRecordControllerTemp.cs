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
    public partial class StudentVisitRecordControllerTemp : BaseController {
    		private object ToJson(StudentVisitRecord e) {
    			return new {
    				Id=e.Id,
    			ClazzId=e.ClazzId,
    			StudentId=e.StudentId,
    			Time=e.Time,
    			VisitorId=e.VisitorId,
    			Goal=e.Goal,
    			Content=e.Content,
    			Question=e.Question,
    			ReviewerId=e.ReviewerId,
    			ReviewTime=e.ReviewTime,
    			ReviewComment=e.ReviewComment
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, StudentVisitRecord e);
    	partial void AfterAddData(StudentVisitRecord e, ref ActionResult ar);
    	partial void AfterUpdateData(StudentVisitRecord e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, StudentVisitRecord e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(StudentVisitRecord e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(StudentVisitRecord e, ref ActionResult ar) {
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
