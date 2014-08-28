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
	public partial class SmallInfoSourceController : BaseController {
		private object ToJson(SmallInfoSource e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				InfoSourceBigId = e.InfoSourceBigId,
				InfoSourceBigName = e.BigInfoSource.Name
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, SmallInfoSource e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(SmallInfoSource e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(SmallInfoSource e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			IBigInfoSourceService service = new BigInfoSourceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = service.FindAll();
			r.ForEach(o => {
				m.Add(new { Id=o.Id, Name=o.Name });
			});
			return this.Json(new { BigInfoSources=m }, JsonRequestBehavior.AllowGet);
		}
	}
}
