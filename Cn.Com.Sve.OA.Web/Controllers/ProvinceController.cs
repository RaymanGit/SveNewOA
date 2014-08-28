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
	public partial class ProvinceController : BaseController {
		partial void AddRowToGridModel(LigerGridModel m, Province e) {
			m.Rows.Add(new {
				Id = e.Id,
				Name = e.Name
			});
		}
		public ActionResult GetComboData() {
			List<object> m = new List<object>();
			m.Add(new { Id=-1, Name="所有" });
			var r = this.Service.FindAll();
			r.ForEach(o => {
				m.Add(new { Id=o.Id, Name=o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
		partial void AfterAddData(Province e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult { Data = e, Successful = true });
		}
	}
}
