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
using Cn.Com.Sve.OA.Web.Models.ViewModels;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class SchoolController : BaseController {
		public ISchoolAdService SchoolAdService { get; set; }
		private object ToJson(School e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				DistrictId = e.DistrictId,
				DistrictName = (e.District == null) ? "" : e.District.Name,
				CityId = (e.District == null || e.District.City == null) ? "" : e.District.City.Id.ToString(),
				CityName = (e.District == null || e.District.City == null) ? "" : e.District.City.Name,
				ProvinceId = (e.District == null || e.District.City == null || e.District.City.Province == null) ? "" : e.District.City.Province.Id.ToString(),
				ProvinceName = (e.District == null || e.District.City == null || e.District.City.Province == null) ? "" : e.District.City.Province.Name,
				IsSold = e.IsSold,
				FullDistrictName = e.District.FullName,
				Levels = e.Levels,
				Type = e.Type,
				DevBy = e.DevBy,
				DevDate = e.DevDate.HasValue ? e.DevDate.Value.ToString("yyyy-MM-dd") : "",
				Important = e.Important.GetValueOrDefault() ? "是" : "否"
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, School e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(School e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(School e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		
		public ActionResult GetInitData() {
			IProvinceService provService = new ProvinceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			ICityService cityService = new CityService(new SysContext { CurrentUser = AppContext.CurrentUser });
			IDistrictService districtService = new DistrictService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var provinces = provService.FindAll();
			var cities = cityService.FindAll();
			var districts = districtService.FindAll();
			
			List<object> m = new List<object>();

			provinces.ForEach(o => {
				var p = new { Id = o.Id, Name = o.Name, Cities = new List<object>() };
				cities.Where(c => c.ProvinceId.Equals(o.Id)).ToList().ForEach(c => { 
					var city = new { Id = c.Id, Name = c.Name, Districts = new List<object>() };
					districts.Where(d => d.CityId.Equals(c.Id)).ToList().ForEach(d => {
						city.Districts.Add(new { Id = d.Id, Name = d.Name });
					});
					p.Cities.Add(city);
				});
				m.Add(p);
			});
			return this.Json(new { Provinces = m }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Suggest(string prefix, int qty) {
			List<object> m = new List<object>();
			var r = this.Service.FindByCriteria(new SchoolCriteria { NameSrh = prefix, pagesize = qty, sortname = "name", sortorder = "asc" });
			r.Data.ForEach(o => {
				m.Add(new { Id = o.Id, Name = o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// 渠道学校资料维护入口
		/// </summary>
		/// <returns></returns>
		public ActionResult HuWai() {
			return View();
		}
		/// <summary>
		/// 渠道学校资料维护入口页的查询
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public ActionResult GetDataForHuWai(SchoolCriteria c) {
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
		/// <summary>
		/// 渠道学校 - 学校基本信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult HuWaiDisplay(int id) {
			//var m = new School_HuWaiDisplay_ViewModel();
			//m.School = this.Service.FindById(id);
			//m.SchoolAds = this.SchoolAdService.FindBySchoolId(id);
			return this.View(this.Service.FindById(id));
		}
		/// <summary>
		/// 根据学校ID读取校园宣传资料情况
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult GetAdBySchoolId(int id) {
			this.SchoolAdService = new SchoolAdService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var list = this.SchoolAdService.FindBySchoolId(id);
			var m = new LigerGridModel();
			m.Total = list.Count;
			list.ForEach(o => {
				m.Rows.Add(new {
					BuTiao = o.BuTiao,
					DaoJiShiPai = o.DaoJiShiPai,
					GuaLi = o.GuaLi,
					HighClassQty = o.HighClassQty,
					HighStudentQty = o.HighStudentQty,
					Id = o.Id,
					JiaoShiBiaoYu = o.JiaoShiBiaoYu,
					LouTiBiaoYu = o.LouTiBiaoYu,
					LowClassQty = o.LowClassQty,
					LowStudentQty = o.LowStudentQty,
					ShiTangBiaoYu = o.ShiTangBiaoYu,
					ShuShiBiaoYu = o.ShuShiBiaoYu,
					TaiLi = o.TaiLi,
					Year = o.Year
				});
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
		public ActionResult DeleteAd(int id) {
			return null;
		}
	}
}
