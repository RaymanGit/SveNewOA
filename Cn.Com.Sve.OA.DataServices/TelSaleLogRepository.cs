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
	public partial interface ITelSaleLogRepository : IRepository<TelSaleLog, int> {
		List<TelSalesSummary> GetTelSalesSummaryReport(DateTime startDate, DateTime endDate);
		List<TelSalesSummaryBySchool> GetTelSalesSummaryReportBySchool(DateTime startDate, DateTime endDate);
	}
	public partial class TelSaleLogRepository : ITelSaleLogRepository {
		/// <summary>
		/// 电话回访统计报表
		/// </summary>
		/// <param name="startDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <returns></returns>
		public List<TelSalesSummary> GetTelSalesSummaryReport(DateTime startDate, DateTime endDate) {
			List<TelSalesSummary> teams = new List<TelSalesSummary>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT SalesTeamId, T.Name AS SalesTeamName
	, SUM(Total) AS Total, SUM(N) AS N
	, SUM(CustomerQty) AS CustomerQty, SUM(TelQty) AS TelQty
	, SUM(DropInQty) AS DropInQty, SUM(SignUpQty) AS SignUpQty, SUM(DinWeiQty) AS DinWeiQty
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(DropInQty) * 1.0 / SUM(CustomerQty) ) END AS DropInRate
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(SignUpQty) * 1.0 / SUM(CustomerQty) ) END AS SignUpRate
FROM (
SELECT T.Id AS SalesTeamId, COUNT(C.Id) AS Total, 0 AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_SalesTeam T
LEFT JOIN Marketing_Customer C ON T.Id=C.SalesTeamId
GROUP BY T.Id
UNION
SELECT T.Id AS SalesTeamId, 0 AS Total, COUNT(C.Id) AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_SalesTeam T
LEFT JOIN Marketing_Customer C ON T.Id=C.SalesTeamId
WHERE C.LastSalesTime IS NULL
GROUP BY T.Id
UNION
SELECT M.SalesTeamId, 0 AS Total, 0 AS N, COUNT(DISTINCT CustomerId) AS CustomerQty, COUNT(L.Id) AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_TelSaleLog L INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId = M.UserId
INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId=1
WHERE L.TelTime BETWEEN @StartDate AND @EndDate
GROUP BY M.SalesTeamId
UNION ALL
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, COUNT(C.Id) AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsDropIn = 1
AND C.DropInTime BETWEEN @StartDate AND @EndDate
GROUP BY SalesTeamId
UNION ALL
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, COUNT(C.Id) AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsSignUp = 1
AND C.SignUpTime BETWEEN @StartDate AND @EndDate
GROUP BY SalesTeamId
UNION ALL
SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, 0 AS SignUpQty, COUNT(C.Id) AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsDinWei = 1
AND C.DinWeiTime BETWEEN @StartDate AND @EndDate
GROUP BY SalesTeamId
) A INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId = T.Id
GROUP BY SalesTeamId, T.Name
ORDER BY SignUpQty DESC, DinWeiQty DESC, DropInQty DESC, CustomerQty DESC, TelQty DESC, SignUpRate DESC, DropInRate DESC";
			sql = sql.Replace("@StartDate", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndDate", String.Format("'{0:yyyy-MM-dd}'", endDate));
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					teams.Add(new TelSalesSummary {
						children = new List<TelSalesSummary>(),
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						CustomerQty = ir["CustomerQty"].ToInt(),
						DinWeiQty = ir["DinWeiQty"].ToInt(),
						DropInQty = ir["DropInQty"].ToInt(),
						DropInRate = ir["DropInRate"].ToDecimal().ToString("P"),
						SalesmanId = 0,
						SalesmanName = String.Empty,
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						SignUpQty = ir["SignUpQty"].ToInt(),
						SignUpRate = ir["SignUpRate"].ToDecimal().ToString("P"),
						TelQty = ir["TelQty"].ToInt()
					});
				}
				ir.Close();
			}
			teams.ForEach(t => {
				sql = @"SELECT SalesmanId, U.Name AS SalesmanName
	, SUM(Total) AS Total, SUM(N) AS N
	, SUM(CustomerQty) AS CustomerQty, SUM(TelQty) AS TelQty
	, SUM(DropInQty) AS DropInQty, SUM(SignUpQty) AS SignUpQty, SUM(DinWeiQty) AS DinWeiQty
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(DropInQty) * 1.0 / SUM(CustomerQty) ) END AS DropInRate
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(SignUpQty) * 1.0 / SUM(CustomerQty) ) END AS SignUpRate
FROM (
SELECT T.UserId AS SalesmanId, COUNT(C.Id) AS Total, 0 AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_SalesTeamMember T
LEFT JOIN Marketing_Customer C ON T.UserId=C.SalesmanId
WHERE T.SalesTeamId=@TeamId
GROUP BY T.UserId
UNION
SELECT T.UserId AS SalesmanId, 0 AS Total, COUNT(C.Id) AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_SalesTeamMember T
LEFT JOIN Marketing_Customer C ON T.UserId=C.SalesmanId
WHERE T.SalesTeamId=@TeamId AND C.LastSalesTime IS NULL
GROUP BY T.UserId
UNION
SELECT L.SalesmanId, 0 AS Total, 0 AS N, COUNT(DISTINCT CustomerId) AS CustomerQty, COUNT(L.Id) AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_TelSaleLog L INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId = M.UserId
INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id
WHERE L.TelTime BETWEEN @StartDate AND @EndDate AND M.SalesTeamId = @TeamId
AND I.InfoSourceBigId=1
GROUP BY L.SalesmanId
UNION ALL
SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, COUNT(C.Id) AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsDropIn = 1
AND C.DropInTime BETWEEN @StartDate AND @EndDate AND C.SalesTeamId = @TeamId
GROUP BY SalesmanId
UNION ALL
SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, COUNT(C.Id) AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsSignUp = 1
AND C.SignUpTime BETWEEN @StartDate AND @EndDate AND C.SalesTeamId = @TeamId
GROUP BY SalesmanId
UNION ALL
SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, 0 AS SignUpQty, COUNT(C.Id) AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
WHERE C.IsDinWei = 1
AND C.DinWeiTime BETWEEN @StartDate AND @EndDate AND C.SalesTeamId = @TeamId
GROUP BY SalesmanId
) A INNER JOIN Sys_User U ON A.SalesmanId = U.Id
GROUP BY SalesmanId, U.Name
ORDER BY SignUpQty DESC, DinWeiQty DESC, DropInQty DESC, CustomerQty DESC, TelQty DESC, SignUpRate DESC, DropInRate DESC";
				sql = sql.Replace("@StartDate", String.Format("'{0:yyyy-MM-dd}'", startDate));
				sql = sql.Replace("@EndDate", String.Format("'{0:yyyy-MM-dd}'", endDate));
				sql = sql.Replace("@TeamId", t.SalesTeamId.ToString());
				using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
					while (ir.Read()) {
						t.children.Add(new TelSalesSummary {
							children = new List<TelSalesSummary>(),
							Total = ir["Total"].ToInt(),
							N = ir["N"].ToInt(),
							CustomerQty = ir["CustomerQty"].ToInt(),
							DinWeiQty = ir["DinWeiQty"].ToInt(),
							DropInQty = ir["DropInQty"].ToInt(),
							DropInRate = ir["DropInRate"].ToDecimal().ToString("P"),
							SalesmanId = ir["SalesmanId"].ToInt(),
							SalesmanName = ir["SalesmanName"].ToStr(),
							SalesTeamId = t.SalesTeamId,
							SalesTeamName = t.SalesTeamName,
							SignUpQty = ir["SignUpQty"].ToInt(),
							SignUpRate = ir["SignUpRate"].ToDecimal().ToString("P"),
							TelQty = ir["TelQty"].ToInt()
						});
					}
					ir.Close();
				}
			});

			db = null;
			return teams;
		}

		/// <summary>
		/// 电话回访统计报表(按区域、学校)
		/// </summary>
		/// <param name="startDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <returns></returns>
		public List<TelSalesSummaryBySchool> GetTelSalesSummaryReportBySchool(DateTime startDate, DateTime endDate) {
			List<TelSalesSummaryBySchool> teams = new List<TelSalesSummaryBySchool>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT A.DistrictId, P.Name+C.Name+D.Name AS DistrictName
	, SUM(Total) AS Total, SUM(N) AS N
	, SUM(CustomerQty) AS CustomerQty, SUM(TelQty) AS TelQty
	, SUM(DropInQty) AS DropInQty, SUM(SignUpQty) AS SignUpQty, SUM(DinWeiQty) AS DinWeiQty
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(DropInQty) * 1.0 / SUM(CustomerQty) ) END AS DropInRate
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(SignUpQty) * 1.0 / SUM(CustomerQty) ) END AS SignUpRate
FROM (
SELECT S.DistrictId, COUNT(*) AS Total, 0 AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
GROUP BY S.DistrictId
UNION
SELECT S.DistrictId, 0 AS Total, COUNT(*) AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.LastSalesTime IS NULL
GROUP BY S.DistrictId
UNION
SELECT S.DistrictId, 0 AS Total, 0 AS N, COUNT(DISTINCT CustomerId) AS CustomerQty, COUNT(L.Id) AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_TelSaleLog L INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId = M.UserId
INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId=1
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE L.TelTime BETWEEN @StartDate AND @EndDate
GROUP BY S.DistrictId
UNION ALL
SELECT S.DistrictId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, COUNT(C.Id) AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsDropIn = 1
AND C.DropInTime BETWEEN @StartDate AND @EndDate
GROUP BY S.DistrictId
UNION ALL
SELECT S.DistrictId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, COUNT(C.Id) AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsSignUp = 1
AND C.SignUpTime BETWEEN @StartDate AND @EndDate
GROUP BY S.DistrictId
UNION ALL
SELECT S.DistrictId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, 0 AS SignUpQty, COUNT(C.Id) AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsDinWei = 1
AND C.DinWeiTime BETWEEN @StartDate AND @EndDate
GROUP BY S.DistrictId
) A 
INNER JOIN BaseInfo_District D ON A.DistrictId = D.Id
INNER JOIN BaseInfo_City C ON D.CityId=C.Id
INNER JOIN BaseInfo_Province P ON C.ProvinceId=P.Id
GROUP BY A.DistrictId, P.Name,C.Name,D.Name
ORDER BY SignUpQty DESC, DinWeiQty DESC, DropInQty DESC, CustomerQty DESC, TelQty DESC, SignUpRate DESC, DropInRate DESC";
			sql = sql.Replace("@StartDate", String.Format("'{0:yyyy-MM-dd}'", startDate));
			sql = sql.Replace("@EndDate", String.Format("'{0:yyyy-MM-dd}'", endDate));
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					teams.Add(new TelSalesSummaryBySchool {
						children = new List<TelSalesSummaryBySchool>(),
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						CustomerQty = ir["CustomerQty"].ToInt(),
						DinWeiQty = ir["DinWeiQty"].ToInt(),
						DropInQty = ir["DropInQty"].ToInt(),
						DropInRate = ir["DropInRate"].ToDecimal().ToString("P"),
						SchoolId = 0,
						SchoolName = String.Empty,
						DistrictId = ir["DistrictId"].ToInt(),
						DistrictName = ir["DistrictName"].ToStr(),
						SignUpQty = ir["SignUpQty"].ToInt(),
						SignUpRate = ir["SignUpRate"].ToDecimal().ToString("P"),
						TelQty = ir["TelQty"].ToInt()
					});
				}
				ir.Close();
			}
			teams.ForEach(t => {
				sql = @"SELECT SchoolId, S.Name AS SchoolName
	, SUM(Total) AS Total, SUM(N) AS N
	, SUM(CustomerQty) AS CustomerQty, SUM(TelQty) AS TelQty
	, SUM(DropInQty) AS DropInQty, SUM(SignUpQty) AS SignUpQty, SUM(DinWeiQty) AS DinWeiQty
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(DropInQty) * 1.0 / SUM(CustomerQty) ) END AS DropInRate
	, CASE SUM(CustomerQty) WHEN 0 THEN 0 ELSE (SUM(SignUpQty) * 1.0 / SUM(CustomerQty) ) END AS SignUpRate
FROM (
SELECT T.Id AS SchoolId, COUNT(C.Id) AS Total, 0 AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM BaseInfo_School T
LEFT JOIN Marketing_Customer C ON T.Id=C.SchoolId
WHERE T.DistrictId=@DistrictId
GROUP BY T.Id
UNION
SELECT T.Id AS SchoolId, 0 AS Total, COUNT(C.Id) AS N, 0 AS CustomerQty, 0 AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM BaseInfo_School T
LEFT JOIN Marketing_Customer C ON T.Id=C.SchoolId
WHERE T.DistrictId=@DistrictId AND C.LastSalesTime IS NULL
GROUP BY T.Id
UNION
SELECT S.Id AS SchoolId, 0 AS Total, 0 AS N, COUNT(DISTINCT CustomerId) AS CustomerQty, COUNT(L.Id) AS TelQty, 0 AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_TelSaleLog L INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId = M.UserId
INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE L.TelTime BETWEEN @StartDate AND @EndDate AND S.DistrictId=@DistrictId
AND I.InfoSourceBigId=1
GROUP BY S.Id
UNION ALL
SELECT S.Id AS SchoolId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, COUNT(C.Id) AS DropInQty, 0 AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsDropIn = 1
AND C.DropInTime BETWEEN @StartDate AND @EndDate AND S.DistrictId=@DistrictId
GROUP BY S.Id
UNION ALL
SELECT S.Id AS SchoolId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, COUNT(C.Id) AS SignUpQty, 0 AS DinWeiQty
FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsSignUp = 1
AND C.SignUpTime BETWEEN @StartDate AND @EndDate AND S.DistrictId=@DistrictId
GROUP BY S.Id
UNION ALL
SELECT S.Id AS SchoolId, 0 AS Total, 0 AS N, 0 AS TelQty, 0 AS CustomerQty, 0 AS DropInQty, 0 AS SignUpQty, COUNT(C.Id) AS DinWeiQty
FROM Marketing_Customer C  INNER JOIN BaseInfo_InfoSourceSmall I ON C.SmallInfoSourceId=I.Id AND I.InfoSourceBigId = 1 
INNER JOIN BaseInfo_School S ON C.SchoolId=S.Id
WHERE C.IsDinWei = 1
AND C.DinWeiTime BETWEEN @StartDate AND @EndDate AND S.DistrictId=@DistrictId
GROUP BY S.Id
) A INNER JOIN BaseInfo_School S ON A.SchoolId = S.Id
GROUP BY SchoolId, S.Name
ORDER BY SignUpQty DESC, DinWeiQty DESC, DropInQty DESC, CustomerQty DESC, TelQty DESC, SignUpRate DESC, DropInRate DESC";
				sql = sql.Replace("@StartDate", String.Format("'{0:yyyy-MM-dd}'", startDate));
				sql = sql.Replace("@EndDate", String.Format("'{0:yyyy-MM-dd}'", endDate));
				sql = sql.Replace("@DistrictId", t.DistrictId.ToString());
				using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
					while (ir.Read()) {
						t.children.Add(new TelSalesSummaryBySchool {
							children = new List<TelSalesSummaryBySchool>(),
							Total = ir["Total"].ToInt(),
							N = ir["N"].ToInt(),
							CustomerQty = ir["CustomerQty"].ToInt(),
							DinWeiQty = ir["DinWeiQty"].ToInt(),
							DropInQty = ir["DropInQty"].ToInt(),
							DropInRate = ir["DropInRate"].ToDecimal().ToString("P"),
							SchoolId = ir["SchoolId"].ToInt(),
							SchoolName = ir["SchoolName"].ToStr(),
							DistrictId = t.DistrictId,
							DistrictName = t.DistrictName,
							SignUpQty = ir["SignUpQty"].ToInt(),
							SignUpRate = ir["SignUpRate"].ToDecimal().ToString("P"),
							TelQty = ir["TelQty"].ToInt()
						});
					}
					ir.Close();
				}
			});

			db = null;
			return teams;
		}


	}
}
