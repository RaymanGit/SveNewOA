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
	public partial class EmploymentCompanyContactController : BaseController {
		private object ToJson(EmploymentCompanyContact e) {
			return new {
				Id = e.Id,
				CompanyId = e.CompanyId,
				Name = e.Name,
				Mobile = e.Mobile,
				Position = e.Position,
				Telephone = e.Telephone,
				QQ = e.QQ,
				Email = e.Email,
				Introduction = e.Introduction,
				OldOaId = e.OldOaId,
				OldOaCompanyId = e.OldOaCompanyId
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, EmploymentCompanyContact e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(EmploymentCompanyContact e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(EmploymentCompanyContact e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetContactsByCompanylId(int id) {
			var c = new EmploymentCompanyContactCriteria { CompanyIdSrh = id };
			var m = new LigerGridModel();
			this.BeforeGetData(c);
			var r = this.Service.FindByCriteria(c);
			this.AfterGetData(m, c, r);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				this.AddRowToGridModel(m, o);
			});
			this.AfterBuildGridModel(m, c, r);
			return this.Json(m, JsonRequestBehavior.AllowGet);

		}

	}
}
