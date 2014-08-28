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
	public partial class BigInfoSourceController : BaseController {
		private object ToJson(BigInfoSource e) {
			return new {
				Id = e.Id,
				Name = e.Name
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, BigInfoSource e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(BigInfoSource e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(BigInfoSource e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetCascadeComboData() {
			ISmallInfoSourceService sService = new SmallInfoSourceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = this.Service.FindAll();
			r.ForEach(o => {
				var p = new { Id = o.Id, Name = o.Name, SmallSource = new List<object>() };
				sService.FindByInfoSourceBigId(o.Id).ForEach(c => {
					p.SmallSource.Add(new { Id = c.Id, Name = c.Name });
				});
				m.Add(p);
			});
			return this.Json(new { BigSource = m }, JsonRequestBehavior.AllowGet);
		}
		public ActionResult GetCascadeComboData2() {
			ISmallInfoSourceService sService = new SmallInfoSourceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = this.Service.FindAll();
			r.ForEach(o => {
				if (!o.Name.Trim().Equals("电访资料")) {
					var p = new { Id = o.Id, Name = o.Name, SmallSource = new List<object>() };
					sService.FindByInfoSourceBigId(o.Id).ForEach(c => {
						p.SmallSource.Add(new { Id = c.Id, Name = c.Name });
					});
					m.Add(p);
				}
			});
			return this.Json(new { BigSource = m }, JsonRequestBehavior.AllowGet);
		}

	}
}
