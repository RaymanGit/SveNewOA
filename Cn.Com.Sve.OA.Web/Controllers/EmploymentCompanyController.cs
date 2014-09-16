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
	public partial class EmploymentCompanyController : BaseController {
		private object ToJson(EmploymentCompany e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				Type = e.Type,
				Important = e.Important,
				Website = e.Website,
				Telephone = e.Telephone,
				Fax = e.Fax,
				Address = e.Address,
				CityId = e.CityId,
				Introduction = e.Introduction,
				SourceType = e.SourceType,
				Referer = e.Referer,
				UserId = e.UserId,
				EmployedQty = e.EmployedQty,
				OldOaId = e.OldOaId,
				TempProvId = e.TempProvId,
				TempProvName = e.TempProvName,
				TempCityId = e.TempCityId,
				TempCityName = e.TempCityName
			};
		}


		partial void AddRowToGridModel(LigerGridModel m, EmploymentCompany e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(EmploymentCompany e, ref ActionResult ar) {
			ar = this.RedirectToAction("Display", new { id = e.Id });
		}
		partial void AfterUpdateData(EmploymentCompany e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}
		// 信息管理入口
		public ActionResult Search(EmploymentCompanyCriteria c) {
			if (c == null) c = new EmploymentCompanyCriteria();
			this.ViewBag.Criteria = c;
			var m = this.Service.Search(c);
			return this.View(m);
		}
		public ActionResult Display(int id) {
			var m = this.Service.FindById(id);
			var vService = new EmploymentCompanyContactVisitLogService(new SysContext { CurrentUser = AppContext.CurrentUser });
			this.ViewBag.VisitLogs = vService.FindByCompanyId(id).OrderByDescending(o=>o.Time).ToList();
			this.ViewBag.CurrentUser = AppContext.CurrentUser;
			return this.View(m);
		}

		[HttpGet]
		public ActionResult AddNew() {
			this.BeforeShowAddView();
			return this.View();
		}
		[HttpPost]
		public ActionResult AddNew(EmploymentCompany e) {
			ActionResult ar = null;
			try {
				this.BeforeAddData(e, ref ar);
				if (ar == null) {
					this.Service.Add(e);
					e = this.Service.FindById(e.Id);
					//ar = this.Json(new AjaxOperationResult { Data = e, Successful = true });
					this.AfterAddData(e, ref ar);
				}
			} catch (Exception ex) {
				ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
			return ar;
		}
	}
}
