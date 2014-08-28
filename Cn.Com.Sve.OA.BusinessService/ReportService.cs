using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;

using FileHelpers;
using FileHelpers.DataLink;

namespace Cn.Com.Sve.OA.BusinessService {
	public interface IReportService {
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReport(DateTime? startTime, DateTime? endTime);
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByStudent(string clazzName, DateTime? startTime, DateTime? endTime);
		List<SignUpSummaryReportItem> GetSignUpSummaryReport();
		List<SignUpSummaryReportItem> GetSignUpSummaryReportByMonth(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeam(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesman(int year, int teamId);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesmanAndMonth(int year, int teamId);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndMonth(int year, int teamId);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesman(int year, int month, int teamId);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesTeam(int year, int month);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndDistrict(int year, int month);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSchool(int year, int month);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndEduLevel(int year, int month);
		List<SalesTeamSchoolQtyReportItem> GetSchoolQtyReportBySalesTeam(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByDistrict(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySchool(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportByEduLevel(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndSchool(int year, int teamId);
		List<SignUpRankingListItem> GetSignUpRankingList(DateTime? startTime, DateTime? endTime, string orderBy, string rankBy);
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByTeacher(DateTime? startTime, DateTime? endTime);
	}
	public class ReportService : IReportService {
		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReport(DateTime? startTime, DateTime? endTime) {
			var ds = new ReportRepository();
			startTime = (startTime != null) ? startTime : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endTime = (endTime != null) ? endTime : DateTime.Today;
			return ds.GetStudentVisitSummaryReport(startTime.Value, endTime.Value);
		}
		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByStudent(string clazzName, DateTime? startTime, DateTime? endTime) {
			var ds = new ReportRepository();
			if (String.IsNullOrEmpty(clazzName)) clazzName = "%";
			if (!startTime.HasValue) {
				startTime = new DateTime(1990, 1, 1);
			}
			if (!endTime.HasValue) {
				endTime = DateTime.Today.AddDays(1);
			}
			return ds.GetStudentVisitSummaryReportByStudent(clazzName, startTime, endTime);
		}
		// 招生统计报表-总表
		public List<SignUpSummaryReportItem> GetSignUpSummaryReport() {
			var ds = new ReportRepository();
			return ds.GetSignUpSummaryReport();
		}
		// 招生统计报表-按月统计
		public List<SignUpSummaryReportItem> GetSignUpSummaryReportByMonth(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonth(year);
			return m;
		}
		// 招生统计报表-按电话营销组统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeam(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySalesTeam(year);
			return m;
		}
		// 招生统计报表-按电话营销员统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesman(int year, int teamId) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySalesman(year,teamId);
			return m;
		}
		// 招生统计报表-按电话营销员、按月细化统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesmanAndMonth(int year, int salesmanId) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySalesmanAndMonth(year, salesmanId);
			return m;
		}
		// 招生统计报表-按电话营销组、按月细化统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndMonth(int year, int teamId) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySalesTeamAndMonth(year, teamId);
			return m;
		}
		// 招生统计报表-按组按月统计各组员的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesman(int year, int month, int teamId) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonthAndSalesman(year, month, teamId);
			return m;
		}
		// 招生统计报表-按月统计各组的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesTeam(int year, int month) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonthAndSalesTeam(year, month);
			return m;
		}
		// 招生统计报表-按月统计各区域的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndDistrict(int year, int month) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonthAndDistrict(year, month);
			return m;
		}
		// 招生统计报表-按月统计各学校的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSchool(int year, int month) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonthAndSchool(year, month);
			return m;
		}
		// 招生统计报表-按月统计各种学历层次的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndEduLevel(int year, int month) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByMonthAndEduLevel(year, month);
			return m;
		}
		// 招生统计报表-按组统计学校数量和资料数量
		public List<SalesTeamSchoolQtyReportItem> GetSchoolQtyReportBySalesTeam(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSchoolQtyReportBySalesTeam(year);
			return m;
		}
		// 招生统计报表-按区域统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByDistrict(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByDistrict(year);
			return m;
		}
		// 招生统计报表-按学校统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySchool(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySchool(year);
			return m;
		}
		// 招生统计报表-按学历统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByEduLevel(int year) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportByEduLevel(year);
			return m;
		}
		// 招生统计报表-按电话营销组和学校统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndSchool(int year, int teamId) {
			var ds = new ReportRepository();
			var m = ds.GetSignUpSummaryReportBySalesTeamAndSchool(year, teamId);
			return m;
		}
		// 招生统计报表-招生排名
		public List<SignUpRankingListItem> GetSignUpRankingList(DateTime? startTime, DateTime? endTime, string orderBy, string rankBy) {
			string o = "SignUpQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
			if (!String.IsNullOrEmpty(orderBy)) {
				switch (orderBy.ToLower()) {
					case "signupqty":
						o = "SignUpQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "dropinqty":
						o = "DropInQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "telsignupqty":
						o = "TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "nontelsignupqty":
						o = "NonTelSignUpQty DESC, TelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "teldropinqty":
						o = "TelDropInQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "nonteldropinqty":
						o = "NonTelDropInQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					case "signuprate":
						o = "SignUpRate DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, DropInRate DESC";
						break;
					case "dropinrate":
						o = "DropInRate DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC";
						break;
					case "telqty":
						o = "TelQty DESC, TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
					default:
						o = "TelSignUpQty DESC, NonTelSignUpQty DESC, TelDropInQty DESC, NonTelDropInQty DESC, SignUpRate DESC, DropInRate DESC";
						break;
				}
			}
			var ds = new ReportRepository();
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
			var m = ds.GetSignUpRankingList(startTime.Value, endTime.Value, o, (String.IsNullOrEmpty(rankBy) ? "SignUpQty" : rankBy));
			return m;
		}

		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByTeacher(DateTime? startTime, DateTime? endTime) {
			var ds = new ReportRepository();
			var m = ds.GetStudentVisitSummaryReportByTeacher(startTime, endTime);
			return m;
		}
	}
}