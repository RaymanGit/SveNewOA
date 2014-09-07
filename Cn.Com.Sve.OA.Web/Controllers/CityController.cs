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
	public partial class CityController : BaseController {

		partial void AddRowToGridModel(LigerGridModel m, City e) {
			m.Rows.Add(new {
				Id = e.Id,
				Name = e.Name,
				ProvinceId = e.ProvinceId,
				ProvinceName = e.Province.Name
			});
		}
		partial void AfterAddData(City e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult { Data = new { Id = e.Id, Name = e.Name, Province = new { Id=e.Province.Id, Name=e.Province.Name } }, Successful = true });
		}
		partial void AfterUpdateData(City e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult { Data = new { Id = e.Id, Name = e.Name, Province = new { Id = e.Province.Id, Name = e.Province.Name } }, Successful = true });
		}
		public ActionResult GetInitData() {
			IProvinceService provService = new ProvinceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = provService.FindAll();
			r.ForEach(o => {
				m.Add(new { Id=o.Id, Name=o.Name });
			});
			return this.Json(new { Provinces=m }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Suggest(string prefix, int qty) {
			List<object> m = new List<object>();
			var r = this.Service.FindForSuggest(new CityCriteria { NameSrh = prefix, pagesize = qty, sortname = "name", sortorder = "asc" });
			r.Data.ForEach(o => {
				m.Add(new { Id = o.Id, Name = o.Province.Name + o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

	}
}
