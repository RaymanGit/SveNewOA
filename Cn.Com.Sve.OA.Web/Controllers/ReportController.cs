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
	public class ReportController : Controller {
		public IReportService Service { get; set; }
		public ReportController() {
			this.Service = new ReportService();
		}
		//[HttpGet]
		//public ActionResult StudentVisitSummaryReport() {
		//    return this.View();
		//}

		//public ActionResult GetStudentVisitSummaryReport(StudentVisitSummaryReportCriteria c) {
		//    var m = new LigerGridModel();
		//    var r = this.Service.GetStudentVisitSummaryReport(c);
		//    m.Total = r.Count;
		//    foreach (var o in r) {
		//        m.Rows.Add(new { ClazzId = o.ClazzId, ClazzName = o.ClazzName, TeleQty = o.TeleQty, HomeQty = o.HomeQty, VisitQty = o.VisitQty });
		//    }
		//    return this.Json(m, JsonRequestBehavior.AllowGet);
		//}

		#region 招生统计
		// 招生统计报表-总表
		public ActionResult GetSignUpSummaryReport() {
			var m = this.Service.GetSignUpSummaryReport();
			return this.View(m);
		}
		// 招生统计报表-按月统计
		public ActionResult GetSignUpSummaryByMonthReport(int year) {
			var m = this.Service.GetSignUpSummaryReportByMonth(year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按电话营销组统计
		public ActionResult GetSignUpSummaryReportBySalesTeam(int year) {
			var m = this.Service.GetSignUpSummaryReportBySalesTeam(year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按电话营销员统计
		public ActionResult GetSignUpSummaryReportBySalesman(int year, int teamId) {
			var m = this.Service.GetSignUpSummaryReportBySalesman(year, teamId);
			this.ViewBag.Year = year;
			this.ViewBag.Teamid = teamId;
			return this.View(m);
		}
		// 招生统计报表-按电话营销员、按月细化统计
		public ActionResult GetSignUpSummaryReportBySalesmanAndMonth(int year, int salesmanId) {
			var m = this.Service.GetSignUpSummaryReportBySalesmanAndMonth(year, salesmanId);
			this.ViewBag.Year = year;
			this.ViewBag.Teamid = salesmanId;
			return this.View(m);
		}
		// 招生统计报表-按电话营销组、按月细化统计
		public ActionResult GetSignUpSummaryReportBySalesTeamAndMonth(int year, int teamId) {
			var m = this.Service.GetSignUpSummaryReportBySalesTeamAndMonth(year, teamId);
			this.ViewBag.Year = year;
			this.ViewBag.Teamid = teamId;
			return this.View(m);
		}
		// 招生统计报表-按月按组统计各组员的量
		public ActionResult GetSignUpSummaryReportByMonthAndSalesman(int year, int month, int teamId) {
			var m = this.Service.GetSignUpSummaryReportByMonthAndSalesman(year, month, teamId);
			this.ViewBag.Year = year;
			this.ViewBag.Teamid = teamId;
			this.ViewBag.Month = month;
			return this.View(m);
		}
		// 招生统计报表-按月统计各组的量
		public ActionResult GetSignUpSummaryReportByMonthAndSalesTeam(int year, int month) {
			var m = this.Service.GetSignUpSummaryReportByMonthAndSalesTeam(year, month);
			this.ViewBag.Year = year;
			this.ViewBag.Month = month;
			return this.View(m);
		}
		// 招生统计报表-按月统计各区域的量
		public ActionResult GetSignUpSummaryReportByMonthAndDistrict(int year, int month) {
			var m = this.Service.GetSignUpSummaryReportByMonthAndDistrict(year, month);
			this.ViewBag.Year = year;
			this.ViewBag.Month = month;
			return this.View(m);
		}
		// 招生统计报表-按月统计各学校的量
		public ActionResult GetSignUpSummaryReportByMonthAndSchool(int year, int month) {
			var m = this.Service.GetSignUpSummaryReportByMonthAndSchool(year, month);
			this.ViewBag.Year = year;
			this.ViewBag.Month = month;
			return this.View(m);
		}
		// 招生统计报表-按月统计各学历层次的量
		public ActionResult GetSignUpSummaryReportByMonthAndEduLevel(int year, int month) {
			var m = this.Service.GetSignUpSummaryReportByMonthAndEduLevel(year, month);
			this.ViewBag.Year = year;
			this.ViewBag.Month = month;
			return this.View(m);
		}
		// 招生统计报表-按组统计学校数量和资料数量
		public ActionResult GetSchoolQtyReportBySalesTeam(int? year) {
			var m = this.Service.GetSchoolQtyReportBySalesTeam(year ?? DateTime.Today.Year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按区域统计
		public ActionResult GetSignUpSummaryReportByDistrict(int? year) {
			var m = this.Service.GetSignUpSummaryReportByDistrict(year ?? DateTime.Today.Year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按学校统计
		public ActionResult GetSignUpSummaryReportBySchool(int? year) {
			var m = this.Service.GetSignUpSummaryReportBySchool(year ?? DateTime.Today.Year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按学历统计
		public ActionResult GetSignUpSummaryReportByEduLevel(int? year) {
			var m = this.Service.GetSignUpSummaryReportByEduLevel(year ?? DateTime.Today.Year);
			this.ViewBag.Year = year;
			return this.View(m);
		}
		// 招生统计报表-按电话营销组和学校统计
		public ActionResult GetSignUpSummaryReportBySalesTeamAndSchool(int year, int teamId) {
			var m = this.Service.GetSignUpSummaryReportBySalesTeamAndSchool(year, teamId);
			this.ViewBag.Year = year;
			this.ViewBag.Teamid = teamId;
			return this.View(m);
		}
		// 招生统计报表-招生排名
		public ActionResult GetSignUpRankingList(DateTime? startTime, DateTime? endTime, string orderBy) {
			if (startTime == null || endTime == null) {
				var n = 0;
				switch (DateTime.Today.DayOfWeek) {
					case DayOfWeek.Monday:
						n = -1;
						break;
					case DayOfWeek.Tuesday:
						n = -2;
						break;
					case DayOfWeek.Wednesday:
						n = -3;
						break;
					case DayOfWeek.Thursday:
						n = -4;
						break;
					case DayOfWeek.Friday:
						n = -5;
						break;
					case DayOfWeek.Saturday:
						n = -6;
						break;
					default:
						break;
				}
				startTime = DateTime.Today.AddDays(n);
				endTime = startTime.Value.AddDays(8);
			}
			if (startTime == null) {
				startTime = new DateTime(2000, 1, 1);
			}
			if (endTime == null) {
				endTime = new DateTime(2099, 12, 31);
			}
			var m = this.Service.GetSignUpRankingList(startTime, endTime, orderBy, orderBy);
			//this.ViewBag.Year = year ?? DateTime.Today.Year;
			this.ViewBag.StartTime = startTime;
			this.ViewBag.EndTime = endTime;
			return this.View(m);
		}

		// 班级三访统计
		public ActionResult StudentVisitSummaryReport(DateTime? startTime, DateTime? endTime) {
			startTime = (startTime != null) ? startTime : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endTime = (endTime != null) ? endTime : DateTime.Today;

			var m = this.Service.GetStudentVisitSummaryReport(startTime, endTime);
			this.ViewBag.StartTime = startTime;
			this.ViewBag.EndTime = endTime;
			return this.View(m);
		}
		// 三访统计 - 按学生
		public ActionResult StudentVisitSummaryReportByStudent(string clazzName, DateTime? startTime, DateTime? endTime) {
			//startTime = (startTime != null) ? startTime : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endTime = (endTime != null) ? endTime : DateTime.Today.AddDays(1);

			var m = this.Service.GetStudentVisitSummaryReportByStudent(clazzName, startTime, endTime);
			//this.ViewBag.StartTime = startTime;
			this.ViewBag.EndTime = endTime;
			this.ViewBag.ClazzName = clazzName;
			return this.View(m);
		}

		
		// 三访统计，按老师
		[HttpGet]
		public ActionResult StudentVisitSummaryReportByTeacher() {
			return this.View();
		}

		public ActionResult GetStudentVisitSummaryReportByTeacher(StudentVisitSummaryReportCriteria c) {
			var m = new LigerGridModel();
			var r = this.Service.GetStudentVisitSummaryReportByTeacher(c.BeginTime, c.EndTime);
			m.Total = r.Count;
			foreach (var o in r) {
				m.Rows.Add(new { TeacherName = o.TeacherName,TeleQty = o.TeleQty, VisitQty = o.VisitQty, HomeQty=o.HomeQty });
			}
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region 就业报表
		// 就业访谈报表
		public ActionResult EmploymentVisitReviewReprt(DateTime? startTime, DateTime? endTime) {
			startTime = (startTime != null) ? startTime : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endTime = (endTime != null) ? endTime : DateTime.Today;

			var m = this.Service.GetEmploymentVisitReviewReprt(startTime, endTime);
			this.ViewBag.StartTime = startTime;
			this.ViewBag.EndTime = endTime;
			return this.View(m);
		}
		// 就业新增企业报表
		public ActionResult NewEmployeeCompanyReport(DateTime? startTime, DateTime? endTime) {
			startTime = (startTime != null) ? startTime : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endTime = (endTime != null) ? endTime : DateTime.Today;

			var m = this.Service.GetNewEmployeeCompanyReport(startTime, endTime);
			this.ViewBag.StartTime = startTime;
			this.ViewBag.EndTime = endTime;
			return this.View(m);
		}

		#endregion
	}
}
