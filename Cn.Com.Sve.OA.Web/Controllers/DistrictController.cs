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
	public partial class DistrictController : BaseController {
		partial void AddRowToGridModel(LigerGridModel m, District e) {
			m.Rows.Add(new {
				Id = e.Id,
				Name = e.Name,
				CityId = e.CityId,
				CityName = e.City.Name,
				ProvinceId = e.City.Province.Id,
				ProvinceName = e.City.Province.Name,
				PhonePrefix = e.PhonePrefix,
				Postcode = e.Postcode
			});
		}
		partial void AfterAddData(District e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = new {
					Id = e.Id,
					Name = e.Name,
					CityId = e.CityId,
					CityName = e.City.Name,
					ProvinceId = e.City.Province.Id,
					ProvinceName = e.City.Province.Name,
					PhonePrefix = e.PhonePrefix,
					Postcode = e.Postcode
				},
				Successful = true
			});
		}
		partial void AfterUpdateData(District e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = new {
					Id = e.Id,
					Name = e.Name,
					CityId = e.CityId,
					CityName = e.City.Name,
					ProvinceId = e.City.Province.Id,
					ProvinceName = e.City.Province.Name,
					PhonePrefix = e.PhonePrefix,
					Postcode = e.Postcode
				},
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			IProvinceService provService = new ProvinceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			ICityService cityService = new CityService(new SysContext { CurrentUser = AppContext.CurrentUser });
			List<object> m = new List<object>();
			var r = provService.FindAll();
			r.ForEach(o => {
				var p = new { Id = o.Id, Name = o.Name, Cities = new List<object>() };
				cityService.FindByProvinceId(o.Id).ForEach(c => {
					p.Cities.Add(new { Id = c.Id, Name = c.Name });
				});
				m.Add(p);
			});
			return this.Json(new { Provinces = m }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Suggest(string prefix, int qty) {
			List<object> m = new List<object>();
			var r = this.Service.FindForSuggest(new DistrictCriteria { NameSrh = prefix, pagesize = qty, sortname = "name", sortorder = "asc" });
			r.Data.ForEach(o => {
				m.Add(new { Id = o.Id, Name = o.City.Province.Name + o.City.Name + o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
	}
}
