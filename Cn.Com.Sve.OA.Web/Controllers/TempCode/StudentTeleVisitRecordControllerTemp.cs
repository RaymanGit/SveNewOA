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
    public partial class StudentTeleVisitRecordControllerTemp : BaseController {
    		private object ToJson(StudentTeleVisitRecord e) {
    			return new {
    				Id=e.Id,
    			ClazzId=e.ClazzId,
    			StudentId=e.StudentId,
    			Time=e.Time,
    			VisitorId=e.VisitorId,
    			Interviewee=e.Interviewee,
    			PhoneNo=e.PhoneNo,
    			Advice=e.Advice,
    			Summary=e.Summary,
    			ReviewerId=e.ReviewerId,
    			ReviewTime=e.ReviewTime,
    			ReviewComment=e.ReviewComment
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, StudentTeleVisitRecord e);
    	partial void AfterAddData(StudentTeleVisitRecord e, ref ActionResult ar);
    	partial void AfterUpdateData(StudentTeleVisitRecord e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, StudentTeleVisitRecord e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(StudentTeleVisitRecord e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(StudentTeleVisitRecord e, ref ActionResult ar) {
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
