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
	public partial class UserController : BaseController {
		private object ToJson(User e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				Password = e.Password,
				Status = e.Status,
				LastLoginTime = e.LastLoginTime,
				LastLoginIP = e.LastLoginIP
			};
		}
		partial void AddRowToGridModel(LigerGridModel m, User e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(User e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(User e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		partial void BeforeAddData(User e, ref ActionResult ar) {
			e.Status = "正常";
			if (!String.IsNullOrEmpty(e.NewPassword)) {
				e.Password = e.NewPassword;
			}
		}
		partial void BeforeUpdateData(User e, ref ActionResult ar) {
			if (!String.IsNullOrEmpty(e.NewPassword)) {
				e.Password = e.NewPassword;
			}
		}

		public ActionResult GetInitData() {
			return this.Json(new {}, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Suggest(string prefix, int qty) {
			List<object> m = new List<object>();
			var r = this.Service.FindByCriteria(new UserCriteria { NameSrh = prefix, pagesize = qty, sortname = "name", sortorder = "asc" });
			r.Data.ForEach(o => {
				m.Add(new { Id = o.Id, Name = o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
	}
}
