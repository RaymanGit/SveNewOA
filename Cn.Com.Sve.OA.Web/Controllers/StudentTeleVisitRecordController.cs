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
using Cn.Com.Sve.OA.Web.Models.ViewModels;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class StudentTeleVisitRecordController : BaseController {
		private object ToJson(StudentTeleVisitRecord e) {
			return new {
				Id = e.Id,
				ClazzId = e.ClazzId,
				StudentId = e.StudentId,
				Time = e.Time,
				VisitorId = e.VisitorId,
				Interviewee = e.Interviewee,
				PhoneNo = e.PhoneNo,
				Advice = e.Advice,
				Summary = e.Summary,
				ReviewerId = e.ReviewerId,
				ReviewTime = e.ReviewTime,
				ReviewComment = e.ReviewComment
			};
		}

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
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		private Student_TeleVisit_ViewModel BuildTeleVisitViewModel(int studentId) { 
			var m = new Student_TeleVisit_ViewModel();
			var studentService = new StudentService(new SysContext { CurrentUser = AppContext.CurrentUser });
			m.Student = studentService.FindById(studentId);
			m.Records = this.Service.FindByStudentId(studentId).OrderByDescending(o => o.Time).ToList();
			return m;
		}

		[HttpGet]
		public ActionResult Input(int id) {
			var m = this.BuildTeleVisitViewModel(id);
			m.ShowInput = true;
			m.CurrentUser = AppContext.CurrentUser;
			return this.View("DisplayByStudent", m);
		}
		[HttpPost]
		public ActionResult Input(StudentTeleVisitRecord r) {
			this.Service.Add(r);
			var m = this.BuildTeleVisitViewModel(r.StudentId);
			m.ShowInput = true;
			m.CurrentUser = AppContext.CurrentUser;
			return this.View("DisplayByStudent", m);
		}
		[HttpGet]
		public ActionResult EditInfo(int id) {
			var r = this.Service.FindById(id);
			if (r != null) {
				return this.View(r);
			} else {
				return this.Content("未找到指定记录！");
			}
		}
		[HttpPost]
		public ActionResult EditInfo(StudentTeleVisitRecord r) {
			this.Service.Update(r);
			this.ViewBag.Msg = "操作成功！";
			r = this.Service.FindById(r.Id);
			return this.View(r);
		}

		[HttpGet]
		public ActionResult DeleteInfo(int id) {
			var r = this.Service.FindById(id);
			if (r != null) {
				int sid = r.StudentId;
				this.Service.DeleteById(id);
				var m = this.BuildTeleVisitViewModel(r.StudentId);
				m.ShowInput = true;
				m.CurrentUser = AppContext.CurrentUser;
				return this.View("DisplayByStudent", m);
			} else {
				return this.Content("未找到指定记录！");
			}
		}
		[HttpGet]
		public ActionResult EditConfirm(int id) {
			var r = this.Service.FindById(id);
			if (r != null) {
				this.ViewBag.User = AppContext.CurrentUser;
				return this.View(r);
			} else {
				return this.Content("未找到指定记录！");
			}
		}
		[HttpPost]
		public ActionResult EditConfirm(StudentTeleVisitRecord r) {
			this.Service.Update(r);
			this.ViewBag.Msg = "操作成功！";
			r = this.Service.FindById(r.Id);

			return this.View(r);
		}

		[HttpGet]
		public ActionResult Search() {
			var m = new Student_TeleVisit_ViewModel {
				Criteria = new StudentTeleVisitRecordCriteria(),
				CurrentUser = AppContext.CurrentUser,
				Records = new List<StudentTeleVisitRecord>(),
				ShowConfirmEdit = true,
				ShowDelete = true,
				ShowInput = false
			};
			m.Criteria.TimeFromSrh = DateTime.Today.AddDays(-7);
			m.Criteria.TimeToSrh = DateTime.Today.AddDays(1);
			return this.View(m);
		}
		[HttpPost]
		public ActionResult Search(StudentTeleVisitRecordCriteria c) {
			c.sortname = "time";
			c.sortorder = "desc";
			var m = new Student_TeleVisit_ViewModel {
				Criteria = c,
				CurrentUser = AppContext.CurrentUser,
				Records = this.Service.Search(c).Data,
				ShowConfirmEdit = true,
				ShowDelete = true,
				ShowInput = false
			};
			return this.View(m);
		}
	}
}
