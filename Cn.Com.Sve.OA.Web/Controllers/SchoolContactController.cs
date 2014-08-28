using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cn.Com.Sve.OA.BusinessService;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
using Cn.Com.Sve.OA.Web.Models;
using Cn.Com.Sve.OA.Web.Models.ViewModels;
using Cn.RaymanLee.Web.UI.ViewModels.LigerUI;
using Cn.RaymanLee.Data;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class SchoolContactController : BaseController {
		public ISchoolService SchoolService { get; set; }
		private object ToJson(SchoolContact e) {
			return new {
				Id = e.Id,
				SchoolId = e.SchoolId,
				Year = e.Year,
				Title = e.Title,
				Name = e.Name,
				Telephone = e.Telephone,
				Mobile = e.Mobile,
				QQ = e.QQ,
				Address = e.Address,
				Remark = e.Remark,
				TopFlag = e.TopFlag,
				OldOaId = e.OldOaId
			};
		}

		//partial void AddRowToGridModel(LigerGridModel m, SchoolContact e);
		//partial void AfterAddData(SchoolContact e, ref ActionResult ar);
		//partial void AfterUpdateData(SchoolContact e, ref ActionResult ar);
		partial void AddRowToGridModel(LigerGridModel m, SchoolContact e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(SchoolContact e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(SchoolContact e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult ListBySchool(int schoolId) {
			this.SchoolService = new SchoolService(new SysContext{ CurrentUser = AppContext.CurrentUser });
			var m = new School_Contact_ViewModel();
			m.School = this.SchoolService.FindById(schoolId);
			//m.Contacts = this.Service.FindBySchoolId(schoolId);
			return this.View(m);
		}
	}
}
