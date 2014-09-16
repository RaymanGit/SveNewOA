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


namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class EmploymentCompanyContactVisitLogController : BaseController {
		private object ToJson(EmploymentCompanyContactVisitLog e) {
			return new {
				Id = e.Id,
				CompanyContactId = e.CompanyContactId,
				Time = e.Time,
				VisitorId = e.VisitorId,
				Type = e.Type,
				Content = e.Content
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, EmploymentCompanyContactVisitLog e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(EmploymentCompanyContactVisitLog e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(EmploymentCompanyContactVisitLog e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}
		// 添加访谈信息
		[HttpGet]
		public ActionResult AddNew(int contactId) {
			var s = new EmploymentCompanyContactService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var m = new EmploymentCompanyContactVisitLog { Time = DateTime.Today, Type = "电访" };
			this.ViewBag.Contact=s.FindById(contactId);
			this.ViewBag.Visitor=AppContext.CurrentUser;
			return this.View(m);
		}
		[HttpPost]
		public ActionResult AddNew(EmploymentCompanyContactVisitLog e) {
			try {
				this.Service.Add(e);
				e = this.Service.FindById(e.Id);
			} catch (Exception ex) {
				return this.Content(ex.Message);
			}
			return this.RedirectToAction("Display", "EmploymentCompany", new { id = e.CompanyContact.CompanyId });
		}
		public ActionResult EditSync(int id) {
			var e = this.Service.FindById(id);
			if (e != null) {
				this.BeforeShowEditView(e);
				return this.View(e);
			} else {
				return this.Content("找不到数据！");
			}
		}
		[HttpPost]
		public ActionResult UpdateSync(EmploymentCompanyContactVisitLog e) {
			this.Service.Update(e);
			e = this.Service.FindById(e.Id);
			return this.RedirectToAction("Display", "EmploymentCompany", new { id = e.CompanyContact.CompanyId });
		}
		[HttpGet]
		public ActionResult DeleteSync(int id) {
			var e = this.Service.FindById(id);
			var s = new EmploymentCompanyContactService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var c = s.FindById(e.CompanyContactId);

			this.Service.DeleteById(id);
			return this.RedirectToAction("Display", "EmploymentCompany", new { id = c.CompanyId });
		}
	}
}
