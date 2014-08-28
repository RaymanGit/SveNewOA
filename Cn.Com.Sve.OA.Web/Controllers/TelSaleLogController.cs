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
	public partial class TelSaleLogController : BaseController {
		private object ToJson(TelSaleLog e) {
			return new {
				Id = e.Id,
				CustomerId = e.CustomerId,
				Content = e.Content,
				NextTelTime = e.NextTelTime,
				SalesmanId = e.SalesmanId,
				SalesmanName = e.Salesman.Name,
				TelTime = e.TelTime,
				IsConvert = e.IsConvert,
				IsSignUp = e.IsSignUp,
				ConsultType = e.Customer.ConsultType,
				GaoKaoScore = e.Customer.GaoKaoScore,
				GaoKaoBatch = e.Customer.GaoKaoBatch,
				Important = e.Customer.Important,
				IsLeaderFollow = e.Customer.IsLeaderFollow,
				NextTeleSalesTime = e.Customer.NextTeleSalesTime,
				Keywords = e.Customer.Keywords
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, TelSaleLog e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(TelSaleLog e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(TelSaleLog e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		partial void BeforeAddData(TelSaleLog e, ref ActionResult ar) {
			e.IsConvert = e.ConsultType.Contains("上门") || e.ConsultType.Contains("报名") || e.ConsultType.Contains("定位");
			e.IsSignUp = e.ConsultType.Contains("报名");
			e.NextTelTime = e.NextTeleSalesTime;
			e.SalesmanId = AppContext.CurrentUser.Id;
			e.TelTime = DateTime.Now;

			var cs = new CustomerService(new SysContext { CurrentUser = AppContext.CurrentUser },this.Service.Db);
			var c = cs.FindById(e.CustomerId);
			c.ConsultType = e.ConsultType;
			c.GaoKaoScore = e.GaoKaoScore;
			c.GaoKaoBatch = e.GaoKaoBatch;
			c.Important = e.Important;
			c.IsLeaderFollow = e.IsLeaderFollow;
			c.NextTeleSalesTime = e.NextTeleSalesTime;
			c.Keywords = e.Keywords;
			c.LastSaleLog = e.Content;
			c.LastSalesTime = e.TelTime;
			c.TeleSalesTimes++;
		}

		partial void BeforeUpdateData(TelSaleLog e, ref ActionResult ar) {
			e.IsConvert = e.ConsultType.Contains("上门") || e.ConsultType.Contains("报名") || e.ConsultType.Contains("定位");
			e.IsSignUp = e.ConsultType.Contains("报名");
			e.NextTelTime = e.NextTeleSalesTime;
			e.SalesmanId = AppContext.CurrentUser.Id;
			e.TelTime = DateTime.Now;

			var cs = new CustomerService(new SysContext { CurrentUser = AppContext.CurrentUser },this.Service.Db);
			var c = cs.FindById(e.CustomerId);
			c.ConsultType = e.ConsultType;
			c.GaoKaoScore = e.GaoKaoScore;
			c.GaoKaoBatch = e.GaoKaoBatch;
			c.Important = e.Important;
			c.IsLeaderFollow = e.IsLeaderFollow;
			c.NextTeleSalesTime = e.NextTeleSalesTime;
			c.Keywords = e.Keywords;
			c.LastSaleLog = e.Content;
			c.LastSalesTime = e.TelTime;
			//c.TeleSalesTimes++;
		}

		[HttpGet]
		public ActionResult TelSalesSummary() {
			return this.View();
		}
		public ActionResult GetTelSalesSummary(DateTime? startDate, DateTime? endDate) {
			var m = new { Rows = this.Service.GetTelSalesSummaryReport(startDate, endDate) };
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult TelSalesSummaryBySchool() {
			return this.View();
		}
		public ActionResult GetTelSalesSummaryBySchool(DateTime? startDate, DateTime? endDate) {
			var m = new { Rows = this.Service.GetTelSalesSummaryReportBySchool(startDate, endDate) };
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
	}
}
