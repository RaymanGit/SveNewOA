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
	public partial class SalesTeamMemberController : BaseController {
		public IUserService UserService { get; set; }

		private object ToJson(SalesTeamMember e) {
			return new {
				Id = e.Id,
				SalesTeamId = e.SalesTeamId,
				SalesTeamName = e.SalesTeam.Name,
				UserId = e.UserId,
				UserName = e.User.Name,
				DefaultUrl = e.User.DefaultUrl,
				IsLeader = e.IsLeader
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, SalesTeamMember e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(SalesTeamMember e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(SalesTeamMember e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		partial void BeforeAddData(SalesTeamMember e, ref ActionResult ar) {
			if (!String.IsNullOrEmpty(e.DefaultUrl)) {
				if (this.UserService == null) {
					this.UserService = new UserService(new SysContext { CurrentUser = AppContext.CurrentUser });
				}
				var user = this.UserService.FindById(e.UserId);
				user.DefaultUrl = e.DefaultUrl;
				this.UserService.Update(user);
			}
		}

		partial void BeforeUpdateData(SalesTeamMember e, ref ActionResult ar) {
			if (!String.IsNullOrEmpty(e.DefaultUrl)) {
				if (this.UserService == null) {
					this.UserService = new UserService(new SysContext { CurrentUser = AppContext.CurrentUser });
				}
				var user = this.UserService.FindById(e.UserId);
				user.DefaultUrl = e.DefaultUrl;
				this.UserService.Update(user);
			}
		}

		public ActionResult GetCascadeComboData() {
			ISalesTeamService sService = new SalesTeamService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = sService.FindAll();
			r.ForEach(o => {
				var p = new { Id = o.Id, Name = o.Name, Members = new List<object>() };
				this.Service.FindBySalesTeamId(o.Id).ForEach(c => {
					p.Members.Add(new { Id = c.UserId, Name = c.User.Name });
				});
				m.Add(p);
			});
			return this.Json(new { Teams = m }, JsonRequestBehavior.AllowGet);
		}

	}
}
