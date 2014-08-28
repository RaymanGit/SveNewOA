using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Cn.RaymanLee.Data;
using Cn.RaymanLee.Utils;

namespace Cn.Com.Sve.OA.DataServices {
	public partial interface ICustomerRepository : IRepository<Customer, int> {
		List<School> FindSchoolsBySalesTeam(int teamId);
		List<School> FindSchoolsBySalesman(int userId);
		PagedModel<Customer> Search(CustomerCriteria c, int currentUserId);
		List<SchoolAssignState> FindSchoolAssignState();
		PagedModel<Customer> FindDuplicate(CustomerCriteria c);
		List<SchoolAssignState> GetAssignReport(string teamName, string salesmanName);
		List<SalesTeamSummaryReport> GetSalesTeamSummaryReport(DateTime startDate, DateTime endDate);
		List<SalesTeamSummaryReportBySchool> GetSalesTeamSummaryReportBySchool(DateTime startDate, DateTime endDate);
		CustomerAssignSummary GetCustomerAssignSummaryByTeam(string teamName);
		void DeleteBySchoolId(int schoolId);

	}
	public partial class CustomerRepository : ICustomerRepository {
		public List<SchoolAssignState> FindSchoolAssignState() {
			List<SchoolAssignState> schools = new List<SchoolAssignState>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" SELECT C.*, S.Name AS SchoolName, T.Name AS SalesTeamName, U.Name AS SalesmanName ");
			sb.Append(" FROM ( SELECT DISTINCT C.SchoolId, C.SalesTeamId, C.SalesmanId ");
			sb.Append(" FROM Marketing_Customer C ) C  ");
			sb.Append(" INNER JOIN BaseInfo_School S ON C.SchoolId = S.Id ");
			sb.Append(" LEFT JOIN Marketing_SalesTeam T ON C.SalesTeamId = T.Id ");
			sb.Append(" LEFT JOIN Sys_User U ON C.SalesmanId = U.Id ");
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					schools.Add(new SchoolAssignState {
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						SalesTeamId = ir["SalesTeamId"].ToNullableInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						SalesmanId = ir["SalesmanId"].ToNullableInt(),
						SalesmanName = ir["SalesmanName"].ToStr()
					});
				}
			}
			db = null;
			return schools;
		}
		public List<School> FindSchoolsBySalesTeam(int teamId) {
			List<School> schools = new List<School>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" SELECT S.*, D.Name AS DistrictName, C.Id AS CityId, C.Name AS CityName, P.Id AS ProvinceId, P.Name AS ProvinceName ");
			sb.Append(" FROM BaseInfo_School S ");
			sb.Append(" INNER JOIN BaseInfo_District D ON S.DistrictId=D.Id ");
			sb.Append(" INNER JOIN BaseInfo_City C ON D.CityId = C.Id ");
			sb.Append(" INNER JOIN BaseInfo_Province P ON C.ProvinceId = P.Id ");
			sb.AppendFormat(" WHERE S.Id IN (SELECT SchoolId FROM Marketing_Customer C WHERE C.SalesTeamId = {0}) ", teamId);
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					schools.Add(new School {
						Id = ir["Id"].ToInt(),
						Name = ir["Name"].ToStr(),
						DistrictId = ir["DistrictId"].ToNullableInt(),
						IsSold = ir["IsSold"].ToBoolean(),
						CityName = ir["CityName"].ToStr(),
						ProvinceName = ir["ProvinceName"].ToStr(),
						DistrictName = ir["DistrictName"].ToStr()
					});
				}
			}
			db = null;
			return schools;
		}
		public List<School> FindSchoolsBySalesman(int userId) {
			List<School> schools = new List<School>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" SELECT S.*, D.Name AS DistrictName, C.Id AS CityId, C.Name AS CityName, P.Id AS ProvinceId, P.Name AS ProvinceName ");
			sb.Append(" FROM BaseInfo_School S ");
			sb.Append(" INNER JOIN BaseInfo_District D ON S.DistrictId=D.Id ");
			sb.Append(" INNER JOIN BaseInfo_City C ON D.CityId = C.Id ");
			sb.Append(" INNER JOIN BaseInfo_Province P ON C.ProvinceId = P.Id ");
			sb.AppendFormat(" WHERE S.Id IN (SELECT SchoolId FROM Marketing_Customer C WHERE C.SalesmanId = {0}) ", userId);
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					schools.Add(new School {
						Id = ir["Id"].ToInt(),
						Name = ir["Name"].ToStr(),
						DistrictId = ir["DistrictId"].ToNullableInt(),
						IsSold = ir["IsSold"].ToBoolean(),
						CityName = ir["CityName"].ToStr(),
						ProvinceName = ir["ProvinceName"].ToStr(),
						DistrictName = ir["DistrictName"].ToStr()
					});
				}
			}
			db = null;
			return schools;
		}
		public PagedModel<Customer> Search(CustomerCriteria c, int currentUserId) {
			StringBuilder sb = new StringBuilder();
			var m = new PagedModel<Customer>();
			m.Data = new List<Customer>();
			var db = DatabaseFactory.CreateDatabase();

			string orderby = "";
			string orderby2 = "";
			#region 排序处理
			if (String.IsNullOrEmpty(c.sortname)) {
				c.sortname = "name";
			}
			if (String.IsNullOrEmpty(c.sortorder)) {
				c.sortorder = "asc";
			}
			if (c.sortname.ToLower().Equals("salesmanname")) {
				orderby = String.Format(" ORDER BY [Salesman].[Name] {0}", c.sortorder);
			} else if (c.sortname.ToLower().Equals("salesteamname")) {
				orderby = String.Format(" ORDER BY SalesTeam.[Name] {0}", c.sortorder);
			} else {
				orderby = String.Format(" ORDER BY C.[{0}] {1}", c.sortname, c.sortorder);
			}
				orderby2 = String.Format(" ORDER BY [{0}] {1}", c.sortname, c.sortorder);
			#endregion

			sb.Append("SELECT ROW_NUMBER() OVER (").Append(orderby).Append(") RowNo, ");
			sb.Append(" C.*, [BaseInfo_School].[Name] AS SchoolName, [Salesman].[Name] AS SalesmanName, Clazz.[Name] AS InClazzName, ");
			sb.Append(" Consultant1.[Name] AS ConsultantName1, Consultant2.[Name] AS ConsultantName2, ");
			sb.Append(" SalesTeam.[Name] AS SalesTeamName, District.[Name] AS DistrictName, ");
			sb.Append(" City.[Name] AS CityName, Province.[Name] AS ProvinceName ");
			sb.Append(" FROM Marketing_Customer C ");
			sb.Append(" LEFT JOIN BaseInfo_School ON C.SchoolId = [BaseInfo_School].[Id] ");
			sb.Append(" LEFT JOIN Sys_User Salesman ON C.SalesmanId = Salesman.Id ");
			sb.Append(" LEFT JOIN Student_Clazz Clazz ON C.InClazzId = Clazz.Id ");
			sb.Append(" LEFT JOIN Sys_User Consultant1 ON C.ConsultantId1 = Consultant1.Id ");
			sb.Append(" LEFT JOIN Sys_User Consultant2 ON C.ConsultantId2 = Consultant2.Id ");
			sb.Append(" LEFT JOIN Marketing_SalesTeam SalesTeam ON C.SalesTeamId = SalesTeam.Id ");
			sb.Append(" LEFT JOIN BaseInfo_District District ON C.DistrictId = District.Id ");
			sb.Append(" INNER JOIN BaseInfo_City City ON District.CityId = City.Id ");
			sb.Append(" INNER JOIN BaseInfo_Province Province ON City.ProvinceId = Province.Id ");
			sb.Append(" INNER JOIN BaseInfo_InfoSourceSmall ISS ON C.SmallInfoSourceId = ISS.Id ");
			sb.Append(" INNER JOIN BaseInfo_InfoSourceBig ISB ON ISS.InfoSourceBigId = ISB.Id ");
			sb.Append(" WHERE 1=1 ");

			#region 权限控制
			var saCount= db.ExecuteScalar(CommandType.Text, "SELECT COUNT(Id) FROM Sys_Supervisor S WHERE S.[User]=" + 
				currentUserId.ToString() + " AND S.Type='查看所有生源'");
			if (saCount == null || Int32.Parse(saCount.ToString()) == 0) { 
				// 当前用户没有特权，则读取当前用户担任组长和组员的的招生小组的ID
				sb.Append(" AND ( 1 = 0 ");
				// 组长则添加本组的生源
				using (var ir = db.ExecuteReader(CommandType.Text,
					"SELECT DISTINCT M.SalesTeamId FROM Marketing_SalesTeamMember M WHERE UserId = " + currentUserId.ToString() +
					" AND IsLeader = 1")) {
					while (ir.Read()) {
						sb.Append(" OR C.SalesTeamId = ").Append(ir[0]);
					}
					ir.Close();
				}
				// 组员则添加自己的生源
				sb.Append(" OR C.SalesmanId = ").Append(currentUserId);
				sb.Append(") ");
			}
			#endregion

			#region 查询条件过滤
			if (!String.IsNullOrEmpty(c.InClazzNameSrh)) {
				sb.AppendFormat(" AND Clazz.[Name] LIKE '%{0}%' ", c.InClazzNameSrh);
			}
			if (c.SchoolIdSrh.HasValue) {
				sb.AppendFormat(" AND C.SchoolId = {0} ", c.SchoolIdSrh.Value);
			}
			if (!String.IsNullOrEmpty(c.ConsultTypeSrh)) {
				sb.AppendFormat(" AND C.ConsultType = '{0}' ", c.ConsultTypeSrh);
			}
			if (c.SalesTeamIdSrh.HasValue) {
				sb.AppendFormat(" AND C.SalesTeamid = {0} ", c.SalesTeamIdSrh);
			}
			if (c.SalesmanIdSrh.HasValue) {
				sb.AppendFormat(" AND C.SalesmanId = {0} ", c.SalesmanIdSrh);
			}
			if (!String.IsNullOrEmpty(c.EduLevelSrh)) {
				sb.AppendFormat(" AND C.EduLevel = '{0}' ", c.EduLevelSrh);
			}
			if (c.ImportantSrh.HasValue && c.ImportantSrh.Value) {
				sb.Append(" AND C.Important = 1 ");
			}
			if (c.IsTodaySrh.HasValue && c.IsTodaySrh.Value) {
				sb.AppendFormat(" AND C.NextTeleSalesTime >= '{0:d}' ", DateTime.Today);
				sb.AppendFormat(" AND C.NextTeleSalesTime < '{0:d}' ", DateTime.Today.AddDays(1));
			}
			if (c.IsDropInSrh.HasValue && c.IsDropInSrh.Value) {
				sb.Append(" AND C.IsDropIn = 1 ");
				if (c.DropInTimeFromSrh.HasValue) {
					sb.AppendFormat(" AND C.DropInTime >= '{0:d}' ", c.DropInTimeFromSrh);
				}
				if (c.DropInTimeToSrh.HasValue) {
					sb.AppendFormat(" AND C.DropInTime <= '{0:d}' ", c.DropInTimeToSrh);
				}
			}
			if (c.IsDinWeiSrh.HasValue && c.IsDinWeiSrh.Value) {
				sb.Append(" AND C.IsDinWei = 1 ");
				if (c.DropInTimeFromSrh.HasValue) {
					sb.AppendFormat(" AND C.DinWeiTime >= '{0:d}' ", c.DinWeiTimeFromSrh);
				}
				if (c.DropInTimeToSrh.HasValue) {
					sb.AppendFormat(" AND C.DinWeiTime <= '{0:d}' ", c.DinWeiTimeToSrh);
				}
			}
			if (c.IsSignUpSrh.HasValue && c.IsSignUpSrh.Value) {
				sb.Append(" AND C.IsSignUp = 1 ");
				if (c.DropInTimeFromSrh.HasValue) {
					sb.AppendFormat(" AND C.SignUpTime >= '{0:d}' ", c.SignUpTimeFromSrh);
				}
				if (c.DropInTimeToSrh.HasValue) {
					sb.AppendFormat(" AND C.SignUpTime <= '{0:d}' ", c.SignUpTimeToSrh);
				}
			}
			if (c.IsPaySrh.HasValue && c.IsPaySrh.Value) {
				sb.Append(" AND C.IsPay = 1 ");
				if (c.DropInTimeFromSrh.HasValue) {
					sb.AppendFormat(" AND C.PayTime >= '{0:d}' ", c.PayTimeFromSrh);
				}
				if (c.DropInTimeToSrh.HasValue) {
					sb.AppendFormat(" AND C.PayTime <= '{0:d}' ", c.PayTimeToSrh);
				}
			}
			if (c.IsRefundSrh.HasValue && c.IsRefundSrh.Value) {
				sb.Append(" AND C.IsRefund = 1 ");
				if (c.DropInTimeFromSrh.HasValue) {
					sb.AppendFormat(" AND C.RefundTime >= '{0:d}' ", c.RefundTimeFromSrh);
				}
				if (c.DropInTimeToSrh.HasValue) {
					sb.AppendFormat(" AND C.RefundTime <= '{0:d}' ", c.RefundTimeToSrh);
				}
			}
			if (!String.IsNullOrEmpty(c.NameSrh)) {
				sb.AppendFormat(" AND C.Name LIKE '%{0}%' ", c.NameSrh);
			}
			if (!String.IsNullOrEmpty(c.ClazzSrh)) {
				sb.AppendFormat(" AND C.Clazz LIKE '%{0}%' ", c.ClazzSrh);
			}
			if (!String.IsNullOrEmpty(c.TelephoneSrh)) {
				sb.AppendFormat(" AND ( C.Telephone LIKE '%{0}%' OR C.Mobile LIKE '%{0}%' OR C.Address LIKE '%{0}%' OR C.QQ LIKE '%{0}%' ) ", c.TelephoneSrh);
			}
			if (!String.IsNullOrEmpty(c.KeywordsSrh)) {
				sb.AppendFormat(" AND C.Keywords LIKE '%{0}%' ", c.KeywordsSrh);
			}
			if (!String.IsNullOrEmpty(c.SchoolNameSrh)) {
				sb.AppendFormat(" AND [BaseInfo_School].[Name] LIKE '%{0}%' ", c.SchoolNameSrh);
			}
			if (!String.IsNullOrEmpty(c.SalesmanNameSrh)) {
				sb.AppendFormat(" AND [Salesman].[Name] LIKE '%{0}%' ", c.SalesmanNameSrh);
				//u = u.Where(o => o.Salesman != null && o.Salesman.Name.Contains(c.SalesmanNameSrh));
			}
			if (c.IsLeaderFollowSrh.HasValue && c.IsLeaderFollowSrh.Value) {
				sb.Append(" AND C.IsLeaderFollow = 1 ");
			}
			if (c.LastSalesTimeSrh.HasValue) {
				sb.AppendFormat(" AND C.LastSalesTime BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' ", c.LastSalesTimeSrh.Value.Date, c.LastSalesTimeSrh.Value.Date.AddDays(1));
			}
			if (c.HasTelSaleLogs.HasValue && c.HasTelSaleLogs.Value) { 
				sb.Append(" AND C.LastSalesTime IS NOT NULL ");
			}
			if (c.NoTelSalesSrh.HasValue && c.NoTelSalesSrh.Value) {
				sb.Append(" AND ISB.Name <> '电访资料' ");
			}
			if (!String.IsNullOrEmpty(c.SourceTypeSrh) && c.SourceTypeSrh.Trim().Equals("电访")) { 
				sb.Append(" AND ISB.Name = '电访资料' ");
			}
			if (!String.IsNullOrEmpty(c.SourceTypeSrh) && c.SourceTypeSrh.Trim().Equals("常规")) { 
				sb.Append(" AND ISB.Name <> '电访资料' ");
			}
			#endregion


			var sql = sb.ToString();
			var oCount = db.ExecuteScalar(CommandType.Text, "SELECT COUNT(Id) FROM (" + sql + ") A ");
			m.RecordCount = (oCount == null) ? 0 : Int32.Parse(oCount.ToString());

			if (!c.pagesize.HasValue) {
				c.pagesize = 20;
			}
			if (m.RecordCount > 0) { 
				int page = c.page ?? 1;
				sql = String.Format("SELECT * FROM ({0}) TBL WHERE TBL.[RowNo] BETWEEN {1} AND {2} {3}", sql, c.pagesize * (page - 1), c.pagesize * page, orderby2);

				using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
					while (ir.Read()) {
						m.Data.Add(new Customer {
							Address = ir["Address"].ToStr(),
							AppointmentTime = ir["AppointmentTime"].ToNullableDateTime(),
							CityName = ir["CityName"].ToStr(),
							Clazz = ir["Clazz"].ToStr(),
							ConsultantId1 = ir["ConsultantId1"].ToNullableInt(),
							ConsultantId2 = ir["ConsultantId2"].ToNullableInt(),
							ConsultantName1 = ir["ConsultantName1"].ToStr(),
							ConsultantName2 = ir["ConsultantName2"].ToStr(),
							ConsultantRemark = ir["ConsultantRemark"].ToStr(),
							ConsultTime = ir["ConsultTime"].ToNullableDateTime(),
							ConsultType = ir["ConsultType"].ToStr(),
							CreateTeacherId = ir["CreateTeacherId"].ToNullableInt(),
							DinWeiTime = ir["DinWeiTime"].ToNullableDateTime(),
							DistrictId = ir["DistrictId"].ToNullableInt(),
							DistrictName = ir["DistrictName"].ToStr(),
							DropInTime = ir["DropInTime"].ToNullableDateTime(),
							EduLevel = ir["EduLevel"].ToStr(),
							Email = ir["Email"].ToStr(),
							GaoKaoBatch = ir["GaoKaoBatch"].ToStr(),
							GaoKaoScore = ir["GaoKaoScore"].ToNullableInt(),
							Gender = ir["Gender"].ToStr(),
							Id = ir["Id"].ToInt(),
							Important = ir["Important"].ToBoolean(),
							InClazzId = ir["InClazzId"].ToInt(),
							InClazzName = ir["InClazzName"].ToStr(),
							IsClosed = ir["IsClosed"].ToBoolean(),
							IsDinWei = ir["IsDinWei"].ToBoolean(),
							IsDorm = ir["IsDorm"].ToNullableBoolean(),
							IsDropIn = ir["IsDropIn"].ToBoolean(),
							IsGaoKao = ir["IsGaoKao"].ToBoolean(),
							IsImport = ir["IsImport"].ToBoolean(),
							IsLeaderFollow = ir["IsLeaderFollow"].ToBoolean(),
							IsPay = ir["IsPay"].ToBoolean(),
							IsRefund = ir["IsRefund"].ToBoolean(),
							IsSignUp = ir["IsSignUp"].ToBoolean(),
							Keywords = ir["Keywords"].ToStr(),
							LastSaleLog = ir["LastSaleLog"].ToStr(),
							LastSalesTime = ir["LastSalesTime"].ToNullableDateTime(),
							MarketYear = ir["MarketYear"].ToInt(),
							Mobile = ir["Mobile"].ToStr(),
							Name = ir["Name"].ToStr(),
							NetConsultantId = ir["NetConsultantId"].ToNullableInt(),
							NextTeleSalesTime = ir["NextTeleSalesTime"].ToNullableDateTime(),
							PayTime = ir["PayTime"].ToNullableDateTime(),
							Postcode = ir["Postcode"].ToStr(),
							ProvinceName = ir["ProvinceName"].ToStr(),
							QQ = ir["QQ"].ToStr(),
							RefundTime = ir["RefundTime"].ToNullableDateTime(),
							Remark = ir["Remark"].ToStr(),
							SalesmanId = ir["SalesmanId"].ToNullableInt(),
							SalesmanName = ir["SalesmanName"].ToStr(),
							SalesTeamId = ir["SalesTeamId"].ToNullableInt(),
							SalesTeamName = ir["SalesTeamName"].ToStr(),
							SchoolId = ir["SchoolId"].ToNullableInt(),
							SchoolName = ir["SchoolName"].ToStr(),
							SignUpTime = ir["SignUpTime"].ToNullableDateTime(),
							SmallInfoSourceId = ir["SmallInfoSourceId"].ToInt(),
							Status = ir["Status"].ToStr(),
							Telephone = ir["Telephone"].ToStr(),
							TeleSalesTimes = ir["TeleSalesTimes"].ToInt()
						});
					}
					ir.Close();
				}
			}
			db = null;
			return m;
		}
		public PagedModel<Customer> FindDuplicate(CustomerCriteria c) {
			StringBuilder sb = new StringBuilder();
			var m = new PagedModel<Customer>();
			m.Data = new List<Customer>();
			var db = DatabaseFactory.CreateDatabase();

			string orderby = "";
			string orderby2 = "";
			#region 排序处理
			if (String.IsNullOrEmpty(c.sortname)) {
				c.sortname = "name";
			}
			if (String.IsNullOrEmpty(c.sortorder)) {
				c.sortorder = "asc";
			}
			if (c.sortname.ToLower().Equals("salesmanname")) {
				orderby = String.Format(" ORDER BY [Salesman].[Name] {0}", c.sortorder);
			} else if (c.sortname.ToLower().Equals("salesteamname")) {
				orderby = String.Format(" ORDER BY SalesTeam.[Name] {0}", c.sortorder);
			} else {
				orderby = String.Format(" ORDER BY C.[{0}] {1}", c.sortname, c.sortorder);
			}
				orderby2 = String.Format(" ORDER BY [{0}] {1}", c.sortname, c.sortorder);
			#endregion

			sb.Append("SELECT ROW_NUMBER() OVER (").Append(orderby).Append(") RowNo, ");
			sb.Append(" C.*, [BaseInfo_School].[Name] AS SchoolName, [Salesman].[Name] AS SalesmanName, Clazz.[Name] AS InClazzName, ");
			sb.Append(" Consultant1.[Name] AS ConsultantName1, Consultant2.[Name] AS ConsultantName2, ");
			sb.Append(" SalesTeam.[Name] AS SalesTeamName, District.[Name] AS DistrictName, ");
			sb.Append(" City.[Name] AS CityName, Province.[Name] AS ProvinceName ");
			sb.Append(" FROM Marketing_Customer C ");
			sb.Append(" LEFT JOIN BaseInfo_School ON C.SchoolId = [BaseInfo_School].[Id] ");
			sb.Append(" LEFT JOIN Sys_User Salesman ON C.SalesmanId = Salesman.Id ");
			sb.Append(" LEFT JOIN Student_Clazz Clazz ON C.InClazzId = Clazz.Id ");
			sb.Append(" LEFT JOIN Sys_User Consultant1 ON C.ConsultantId1 = Consultant1.Id ");
			sb.Append(" LEFT JOIN Sys_User Consultant2 ON C.ConsultantId2 = Consultant2.Id ");
			sb.Append(" LEFT JOIN Marketing_SalesTeam SalesTeam ON C.SalesTeamId = SalesTeam.Id ");
			sb.Append(" LEFT JOIN BaseInfo_District District ON C.DistrictId = District.Id ");
			sb.Append(" INNER JOIN BaseInfo_City City ON District.CityId = City.Id ");
			sb.Append(" INNER JOIN BaseInfo_Province Province ON City.ProvinceId = Province.Id ");
			sb.Append(" WHERE 1=0 ");


			#region 查询条件过滤
			if (!String.IsNullOrEmpty(c.NameSrh)) {
				sb.AppendFormat(" OR TRIM(C.Name) = '{0}' ", c.NameSrh.Trim());
			}
			if (!String.IsNullOrEmpty(c.TelephoneSrh)) {
				sb.AppendFormat(" OR TRIM(C.Telephone) = '{0}' ", c.TelephoneSrh.Trim());
			}
			if (!String.IsNullOrEmpty(c.MobileSrh)) {
				sb.AppendFormat(" OR TRIM(C.Mobile) = '{0}' ", c.MobileSrh.Trim());
			}
			#endregion


			var sql = sb.ToString();
			var oCount = db.ExecuteScalar(CommandType.Text, "SELECT COUNT(Id) FROM (" + sql + ") A ");
			m.RecordCount = (oCount == null) ? 0 : Int32.Parse(oCount.ToString());

			if (!c.pagesize.HasValue) {
				c.pagesize = 20;
			}
			if (m.RecordCount > 0) { 
				int page = c.page ?? 1;
				sql = String.Format("SELECT * FROM ({0}) TBL WHERE TBL.[RowNo] BETWEEN {1} AND {2} {3}", sql, c.pagesize * (page - 1), c.pagesize * page, orderby2);

				using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
					while (ir.Read()) {
						m.Data.Add(new Customer {
							Address = ir["Address"].ToStr(),
							AppointmentTime = ir["AppointmentTime"].ToNullableDateTime(),
							CityName = ir["CityName"].ToStr(),
							Clazz = ir["Clazz"].ToStr(),
							ConsultantId1 = ir["ConsultantId1"].ToNullableInt(),
							ConsultantId2 = ir["ConsultantId2"].ToNullableInt(),
							ConsultantName1 = ir["ConsultantName1"].ToStr(),
							ConsultantName2 = ir["ConsultantName2"].ToStr(),
							ConsultantRemark = ir["ConsultantRemark"].ToStr(),
							ConsultTime = ir["ConsultTime"].ToNullableDateTime(),
							ConsultType = ir["ConsultType"].ToStr(),
							CreateTeacherId = ir["CreateTeacherId"].ToNullableInt(),
							DinWeiTime = ir["DinWeiTime"].ToNullableDateTime(),
							DistrictId = ir["DistrictId"].ToNullableInt(),
							DistrictName = ir["DistrictName"].ToStr(),
							DropInTime = ir["DropInTime"].ToNullableDateTime(),
							EduLevel = ir["EduLevel"].ToStr(),
							Email = ir["Email"].ToStr(),
							GaoKaoBatch = ir["GaoKaoBatch"].ToStr(),
							GaoKaoScore = ir["GaoKaoScore"].ToNullableInt(),
							Gender = ir["Gender"].ToStr(),
							Id = ir["Id"].ToInt(),
							Important = ir["Important"].ToBoolean(),
							InClazzId = ir["InClazzId"].ToInt(),
							InClazzName = ir["InClazzName"].ToStr(),
							IsClosed = ir["IsClosed"].ToBoolean(),
							IsDinWei = ir["IsDinWei"].ToBoolean(),
							IsDorm = ir["IsDorm"].ToNullableBoolean(),
							IsDropIn = ir["IsDropIn"].ToBoolean(),
							IsGaoKao = ir["IsGaoKao"].ToBoolean(),
							IsImport = ir["IsImport"].ToBoolean(),
							IsLeaderFollow = ir["IsLeaderFollow"].ToBoolean(),
							IsPay = ir["IsPay"].ToBoolean(),
							IsRefund = ir["IsRefund"].ToBoolean(),
							IsSignUp = ir["IsSignUp"].ToBoolean(),
							Keywords = ir["Keywords"].ToStr(),
							LastSaleLog = ir["LastSaleLog"].ToStr(),
							LastSalesTime = ir["LastSalesTime"].ToNullableDateTime(),
							MarketYear = ir["MarketYear"].ToInt(),
							Mobile = ir["Mobile"].ToStr(),
							Name = ir["Name"].ToStr(),
							NetConsultantId = ir["NetConsultantId"].ToNullableInt(),
							NextTeleSalesTime = ir["NextTeleSalesTime"].ToNullableDateTime(),
							PayTime = ir["PayTime"].ToNullableDateTime(),
							Postcode = ir["Postcode"].ToStr(),
							ProvinceName = ir["ProvinceName"].ToStr(),
							QQ = ir["QQ"].ToStr(),
							RefundTime = ir["RefundTime"].ToNullableDateTime(),
							Remark = ir["Remark"].ToStr(),
							SalesmanId = ir["SalesmanId"].ToNullableInt(),
							SalesmanName = ir["SalesmanName"].ToStr(),
							SalesTeamId = ir["SalesTeamId"].ToNullableInt(),
							SalesTeamName = ir["SalesTeamName"].ToStr(),
							SchoolId = ir["SchoolId"].ToNullableInt(),
							SchoolName = ir["SchoolName"].ToStr(),
							SignUpTime = ir["SignUpTime"].ToNullableDateTime(),
							SmallInfoSourceId = ir["SmallInfoSourceId"].ToInt(),
							Status = ir["Status"].ToStr(),
							Telephone = ir["Telephone"].ToStr(),
							TeleSalesTimes = ir["TeleSalesTimes"].ToInt()
						});
					}
					ir.Close();
				}
			}
			db = null;
			return m;
		}
		/// <summary>
		/// 查询生源分配情况（数量）
		/// </summary>
		/// <returns></returns>
		public List<SchoolAssignState> GetAssignReport(string teamName, string salesmanName) {
			List<SchoolAssignState> schools = new List<SchoolAssignState>();
			List<SchoolAssignState> teams = new List<SchoolAssignState>();
			List<SchoolAssignState> mans = new List<SchoolAssignState>();

			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(@"SELECT S.Id AS SchoolId, S.Name AS SchoolName, '' AS SalesTeamName, '' AS SalesmanName, COUNT(C.Id) AS Qty
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_School S ON C.SchoolId = S.Id ");
			sb.Append("LEFT JOIN Marketing_SalesTeam T ON C.SalesTeamId = T.Id LEFT JOIN Sys_User U ON C.SalesmanId = U.Id WHERE 1=1 ");
			if (!String.IsNullOrEmpty(teamName)) {
				sb.AppendFormat("AND ISNULL(T.Name,'未分配') LIKE '%{0}%'", teamName.Trim());
			}
			if (!String.IsNullOrEmpty(salesmanName)) {
				sb.AppendFormat("AND ISNULL(U.Name,'未分配') LIKE '%{0}%'", salesmanName.Trim());
			}
			sb.Append(@"GROUP BY S.id, S.Name ORDER BY S.Name");
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					schools.Add(new SchoolAssignState {
						children = new List<SchoolAssignState>(),
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});
				}
				ir.Close();
			}
			sb.Clear();
			sb.Append(@"SELECT S.Id AS SchoolId, S.Name AS SchoolName, T.Id AS SalesTeamId, ISNULL(T.Name,'未分配') AS SalesTeamName, '' AS SalesmanName, COUNT(C.Id) AS Qty
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_School S ON C.SchoolId = S.Id
				LEFT JOIN Marketing_SalesTeam T ON C.SalesTeamId = T.Id
				LEFT JOIN Sys_User U ON C.SalesmanId = U.Id WHERE 1=1 ");
			if (!String.IsNullOrEmpty(teamName)) {
				sb.AppendFormat("AND ISNULL(T.Name,'未分配') LIKE '%{0}%'", teamName.Trim());
			}
			if (!String.IsNullOrEmpty(salesmanName)) {
				sb.AppendFormat("AND ISNULL(U.Name,'未分配') LIKE '%{0}%'", salesmanName.Trim());
			}
			sb.Append("GROUP BY S.Id, S.Name, T.Id, T.Name ORDER By S.Name, T.Name");
			sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					teams.Add(new SchoolAssignState {
						children = new List<SchoolAssignState>(),
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						SalesTeamId = ir["SalesTeamId"].ToNullableInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});
				}
				ir.Close();
			}
			sb.Clear();
			sb.Append(@"SELECT S.Id AS SchoolId, S.Name AS SchoolName, T.Id AS SalesTeamId, ISNULL(T.Name,'未分配') AS SalesTeamName, U.Id AS SalesmanId, ISNULL(U.Name,'未分配') AS SalesmanName , COUNT(C.Id) AS Qty
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_School S ON C.SchoolId = S.Id
				LEFT JOIN Marketing_SalesTeam T ON C.SalesTeamId = T.Id
				LEFT JOIN Sys_User U ON C.SalesmanId = U.Id WHERE 1=1 ");
			if (!String.IsNullOrEmpty(teamName)) {
				sb.AppendFormat("AND ISNULL(T.Name,'未分配') LIKE '%{0}%'", teamName.Trim());
			}
			if (!String.IsNullOrEmpty(salesmanName)) {
				sb.AppendFormat("AND ISNULL(U.Name,'未分配') LIKE '%{0}%'", salesmanName.Trim());
			}
			sb.Append("GROUP BY S.Id, S.Name, T.Id, T.Name, U.Id, U.Name ORDER By S.Name, T.Name, U.Name");
			sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					mans.Add(new SchoolAssignState {
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						SalesTeamId = ir["SalesTeamId"].ToNullableInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						SalesmanId = ir["SalesmanId"].ToNullableInt(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});
				}
				ir.Close();
			}

			schools.ForEach(s => {
				teams.Where(t => t.SchoolId.Equals(s.SchoolId)).ToList().ForEach(t => {
					if (t.SalesTeamId.HasValue) {
						mans.Where(m => m.SalesTeamId.HasValue && m.SalesTeamId.Equals(t.SalesTeamId)
							&& m.SchoolId.Equals( t.SchoolId) ).ToList().ForEach(m => {
							t.children.Add(m);
						});
					}
					if (t.children.Count == 0) t.children = null;
					s.children.Add(t);
				});
				if (s.children.Count == 0) s.children = null;
			});

			db = null;
			return schools;
		}
		/// <summary>
		/// 按夏季招生小组统计
		/// </summary>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		public List<SalesTeamSummaryReport> GetSalesTeamSummaryReport(DateTime startDate, DateTime endDate) {
			List<SalesTeamSummaryReport> teams = new List<SalesTeamSummaryReport>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT SalesTeamId, T.Name AS SalesTeamName,
	SUM(Total) AS Total, SUM(N) AS N, 
	SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
	SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
	SUM(DinWei) AS DinWei FROM (
SELECT C.SalesTeamId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
GROUP BY C.SalesTeamId
UNION
SELECT C.SalesTeamId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.LastSalesTime IS NULL
GROUP BY C.SalesTeamId
UNION
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.SalesTeamId
UNION
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.SalesTeamId
UNION
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.SalesTeamId
UNION
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.SalesTeamId
UNION 
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE C.IsDinWei = 1 AND C.DinWeiTime >= @StartTime AND C.DinWeiTime <= @EndTime
GROUP BY C.SalesTeamId
) A INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id
GROUP BY A.SalesTeamId, T.Name
ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, T.Name";
			sql = sql.Replace("@StartTime", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndTime", String.Format("'{0:yyyy-MM-dd}'", endDate));
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					teams.Add(new SalesTeamSummaryReport {
						children = new List<SalesTeamSummaryReport>(),
						SalesmanId = 0,
						SalesmanName = String.Empty,
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
				ir.Close();
			}

			sql = @"SELECT SalesTeamId, T.Name AS SalesTeamName, SalesmanId, U.Name AS SalesmanName,
	SUM(Total) AS Total, SUM(N) AS N,
	SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
	SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
	SUM(DinWei) AS DinWei FROM (
SELECT C.SalesTeamId, C.SalesmanId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
GROUP BY C.SalesTeamId, C.SalesmanId
UNION
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.LastSalesTime IS NULL
GROUP BY C.SalesTeamId, C.SalesmanId
UNION
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.SalesTeamId, C.SalesmanId
UNION
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.SalesTeamId, C.SalesmanId
UNION
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.SalesTeamId, C.SalesmanId
UNION
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.SalesTeamId, C.SalesmanId
UNION 
SELECT C.SalesTeamId, C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE C.IsDinWei = 1 AND C.DinWeiTime >= @StartTime AND C.DinWeiTime <= @EndTime
GROUP BY C.SalesTeamId, C.SalesmanId
) A INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id
INNER JOIN Sys_User U ON A.SalesmanId = U.Id
GROUP BY A.SalesTeamId, T.Name, A.SalesmanId, U.Name
ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, T.Name, U.Name";
			sql = sql.Replace("@StartTime", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndTime", String.Format("'{0:yyyy-MM-dd}'", endDate));
			var temp = new List<SalesTeamSummaryReport>();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					temp.Add(new SalesTeamSummaryReport {
						children = new List<SalesTeamSummaryReport>(),
						SalesmanId = ir["SalesmanId"].ToInt(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
				ir.Close();
			}



			teams.ForEach(t => {
				t.children.AddRange(temp.Where(o => o.SalesTeamId.Equals(t.SalesTeamId)).OrderByDescending(o => o.TotalSignUp).ThenByDescending(o => o.DinWei).ThenByDescending(o => o.TotalDropIn).ToList());
			});

			db = null;
			return teams;
		}

		/// <summary>
		/// 按区域学校统计招生情况
		/// </summary>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		public List<SalesTeamSummaryReportBySchool> GetSalesTeamSummaryReportBySchool(DateTime startDate, DateTime endDate) {
			List<SalesTeamSummaryReportBySchool> teams = new List<SalesTeamSummaryReportBySchool>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT A.DistrictId, P.Name+T.Name+D.Name AS DistrictFullName,
	SUM(Total) AS Total, SUM(N) AS N,
	SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
	SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
	SUM(DinWei) AS DinWei FROM (
SELECT C.DistrictId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.LastSalesTime IS NULL
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION 
SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE C.IsDinWei = 1 AND C.DinWeiTime >= @StartTime AND C.DinWeiTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
) A 
INNER JOIN BaseInfo_District D ON A.DistrictId=D.Id
INNER JOIN BaseInfo_City T ON D.CityId=T.Id
INNER JOIN BaseInfo_Province P ON T.ProvinceId=P.Id
GROUP BY A.DistrictId, P.Name,T.Name,D.Name
ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, P.Name,T.Name,D.Name";
			sql = sql.Replace("@StartTime", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndTime", String.Format("'{0:yyyy-MM-dd}'", endDate));
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					teams.Add(new SalesTeamSummaryReportBySchool {
						children = new List<SalesTeamSummaryReportBySchool>(),
						SchoolId = 0,
						SchoolName = String.Empty,
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						DistrictId = ir["DistrictId"].ToInt(),
						DistrictFullName = ir["DistrictFullName"].ToStr(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
				ir.Close();
			}

			sql = @"SELECT A.DistrictId, P.Name+T.Name+D.Name AS DistrictFullName, A.SchoolId, S.Name AS SchoolName,
	SUM(Total) AS Total, SUM(N) AS N,
	SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
	SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
	SUM(DinWei) AS DinWei FROM (
SELECT C.DistrictId, C.SchoolId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, C.SchoolId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.LastSalesTime IS NULL
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, C.SchoolId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsDropIn = 1 AND C.DropInTime >= @StartTime AND C.DropInTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId = 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION
SELECT C.DistrictId, C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE SI.InfoSourceBigId > 1
AND C.IsSignUp = 1 AND C.SignUpTime >= @StartTime AND C.SignUpTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
UNION 
SELECT C.DistrictId, C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
WHERE C.IsDinWei = 1 AND C.DinWeiTime >= @StartTime AND C.DinWeiTime <= @EndTime
GROUP BY C.DistrictId, C.SchoolId
) A 
INNER JOIN BaseInfo_District D ON A.DistrictId=D.Id
INNER JOIN BaseInfo_City T ON D.CityId=T.Id
INNER JOIN BaseInfo_Province P ON T.ProvinceId=P.Id
INNER JOIN BaseInfo_School S ON A.SchoolId=S.Id
GROUP BY A.DistrictId, P.Name,T.Name,D.Name, A.SchoolId, S.Name
ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, P.Name,T.Name,D.Name,S.Name";
			sql = sql.Replace("@StartTime", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndTime", String.Format("'{0:yyyy-MM-dd}'", endDate));
			var temp = new List<SalesTeamSummaryReportBySchool>();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					temp.Add(new SalesTeamSummaryReportBySchool {
						children = new List<SalesTeamSummaryReportBySchool>(),
						DistrictId = ir["DistrictId"].ToInt(),
						DistrictFullName = ir["DistrictFullName"].ToStr(),
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
				ir.Close();
			}



			teams.ForEach(t => {
				t.children.AddRange(temp.Where(o => o.DistrictId.Equals(t.DistrictId)).OrderByDescending(o => o.TotalSignUp).ThenByDescending(o => o.DinWei).ThenByDescending(o => o.TotalDropIn).ToList());
			});

			db = null;
			return teams;
		}

		// 按组统计资料总量和未分配资料量
		public CustomerAssignSummary GetCustomerAssignSummaryByTeam(string teamName) {
			StringBuilder sb = new StringBuilder();
			CustomerAssignSummary m = null;
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SalesTeamName, SUM(TotalQty) AS TotalQty, SUM(UnassignQty) AS UnassignQty FROM (
					SELECT T.Name AS SalesTeamName, COUNT(*) AS TotalQty, 0 AS UnassignQty
					FROM Marketing_Customer C INNER JOIN Marketing_SalesTeam T ON C.SalesTeamId=T.Id
					WHERE T.Name = '@TeamName'
					GROUP BY T.Name
					UNION
					SELECT T.Name AS SalesTeamName, 0 AS TotalQty, COUNT(*) AS UnassignQty
					FROM Marketing_Customer C INNER JOIN Marketing_SalesTeam T ON C.SalesTeamId=T.Id
					WHERE SalesmanId IS NULL AND T.Name = '@TeamName'
					GROUP BY T.Name
				) A
				GROUP BY SalesTeamName
				ORDER BY SalesTeamName
			");
			sb.Replace("@TeamName", teamName);
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				if (ir.Read()) {
					m = new CustomerAssignSummary {
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						TotalQty = ir["TotalQty"].ToInt(),
						UnassignQty = ir["UnassignQty"].ToInt()
					};
				}
			}

			return m;
		}
		public void DeleteBySchoolId(int schoolId) {
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" DELETE FROM Marketing_Customer WHERE SchoolId = " + schoolId.ToString());
			var sql = sb.ToString();
			db.ExecuteNonQuery(CommandType.Text, sql);
			db = null;
		}
	}
}
