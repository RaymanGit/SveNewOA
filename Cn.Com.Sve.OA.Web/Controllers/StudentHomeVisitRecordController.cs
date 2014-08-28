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
	public partial class StudentHomeVisitRecordController : BaseController {
		private object ToJson(StudentHomeVisitRecord e) {
			return new {
				Id = e.Id,
				ClazzId = e.ClazzId,
				StudentId = e.StudentId,
				Time = e.Time,
				VisitType = e.VisitType,
				BeginTime = e.BeginTime,
				EndTime = e.EndTime,
				GiveContactCard = e.GiveContactCard,
				Visitees = e.Visitees,
				PhoneNo = e.PhoneNo,
				Visitors = e.Visitors,
				Advice = e.Advice,
				Summary = e.Summary,
				ReviewerId = e.ReviewerId,
				ReviewTime = e.ReviewTime,
				ReviewComment = e.ReviewComment,
				InputUserId = e.InputUserId
			};
		}
    

		partial void AddRowToGridModel(LigerGridModel m, StudentHomeVisitRecord e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(StudentHomeVisitRecord e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(StudentHomeVisitRecord e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}


		private Student_HomeVisit_ViewModel BuildVisitViewModel(int studentId) {
			var m = new Student_HomeVisit_ViewModel();
			var studentService = new StudentService(new SysContext { CurrentUser = AppContext.CurrentUser });
			m.Student = studentService.FindById(studentId);
			m.Records = this.Service.FindByStudentId(studentId).OrderByDescending(o => o.Time).ToList();
			return m;
		}

		[HttpGet]
		public ActionResult Input(int id) {
			var m = this.BuildVisitViewModel(id);
			m.ShowInput = true;
			m.CurrentUser = AppContext.CurrentUser;
			return this.View("DisplayByStudent", m);
		}
		[HttpPost]
		public ActionResult Input(StudentHomeVisitRecord r) {
			this.Service.Add(r);
			var m = this.BuildVisitViewModel(r.StudentId);
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
		public ActionResult EditInfo(StudentHomeVisitRecord r) {
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
				var m = this.BuildVisitViewModel(r.StudentId);
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
		public ActionResult EditConfirm(StudentHomeVisitRecord r) {
			this.Service.Update(r);
			this.ViewBag.Msg = "操作成功！";
			r = this.Service.FindById(r.Id);

			return this.View(r);
		}

		[HttpGet]
		public ActionResult Search() {
			var m = new Student_HomeVisit_ViewModel {
				Criteria = new StudentHomeVisitRecordCriteria(),
				CurrentUser = AppContext.CurrentUser,
				Records = new List<StudentHomeVisitRecord>(),
				ShowConfirmEdit = true,
				ShowDelete = true,
				ShowInput = false
			};
			m.Criteria.TimeFromSrh = DateTime.Today.AddDays(-7);
			m.Criteria.TimeToSrh = DateTime.Today.AddDays(1);
			return this.View(m);
		}
		[HttpPost]
		public ActionResult Search(StudentHomeVisitRecordCriteria c) {
			c.sortname = "time";
			c.sortorder = "desc";
			var m = new Student_HomeVisit_ViewModel {
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
