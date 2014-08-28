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
	public interface IReportRepository {
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReport(DateTime startTime, DateTime endTime);
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByStudent(string clazzName, DateTime? startTime, DateTime? endTime);
		List<SignUpSummaryReportItem> GetSignUpSummaryReport();
		List<SignUpSummaryReportItem> GetSignUpSummaryReportByMonth(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeam(int year);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesman(int year, int teamId);
		List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesmanAndMonth(int year, int salesmanId);
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
		List<SignUpRankingListItem> GetSignUpRankingList(DateTime startTime, DateTime endTime, string orderBy, string rankBy);
		List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByTeacher(DateTime? startTime, DateTime? endTime);
	}
	public class ReportRepository : IReportRepository {
		// 三访统计 - 按班级
		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReport(DateTime startTime, DateTime endTime) {
			StringBuilder sb = new StringBuilder();
			var m = new List<StudentVisitSummaryReportItem>();
			var db = DatabaseFactory.CreateDatabase();
			#region 未加教员统计的旧代码
			/*
			sb.Append(@"
				SELECT ClazzId, Z.Name AS ClazzName, Z.Master, SUM(TeleQty) AS TeleQty, SUM(VisitQty) AS VisitQty, SUM(HomeQty) AS HomeQty
					, SUM(ReviewTQty) AS ReviewTQty, SUM(ReviewVQty) AS ReviewVQty, SUM(ReviewHQty) AS ReviewHQty
				FROM (  
				SELECT ClazzId, COUNT(*) AS TeleQty, 0 AS VisitQty, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_TeleVisitRecord 
				WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
				GROUP BY ClazzId
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS HomeQty, COUNT(*) AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_TeleVisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, COUNT(*) AS VisitQty, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_VisitRecord 
				WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
				GROUP BY ClazzId
				UNION ALL 
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS HomeQty, 0 AS ReviewTQty, COUNT(*) AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_VisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId 
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, COUNT(*) AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_HomeVisitRecord 
				WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
				GROUP BY ClazzId 
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, COUNT(*) AS ReviewHQty
				FROM Student_HomeVisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId
				) A INNER JOIN Student_Clazz Z ON A.ClazzId=Z.Id
				GROUP BY ClazzId, Z.Name, Z.Master
				ORDER BY Z.Name DESC
			");
			 * */
			#endregion

			sb.Append(@"
				SELECT ClazzId, Z.Name AS ClazzName, Z.Master, SUM(TeleQty) AS TeleQty, SUM(VisitQty) AS VisitQty, SUM(VisitQty2) AS VisitQty2
					, SUM(VisitQty3) AS VisitQty3, SUM(HomeQty) AS HomeQty
					, SUM(ReviewTQty) AS ReviewTQty, SUM(ReviewVQty) AS ReviewVQty, SUM(ReviewHQty) AS ReviewHQty
				FROM (  
				SELECT ClazzId, COUNT(*) AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_TeleVisitRecord 
				WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
				GROUP BY ClazzId
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, COUNT(*) AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_TeleVisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId
				UNION ALL
SELECT ClazzId, 0 AS TeleQty, COUNT(*) AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND ISNULL(Z.[Master],'') = U.Name
GROUP BY ClazzId
UNION ALL
SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, COUNT(*) AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND (ISNULL(Z.TeacherA,'') = U.Name OR ISNULL(Z.TeacherB,'')=U.Name)
GROUP BY ClazzId
UNION ALL
SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, COUNT(*) AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND (ISNULL(Z.TeacherA,'') <> U.Name AND ISNULL(Z.TeacherB,'') <> U.Name AND ISNULL(Z.[Master],'')<>U.Name)
GROUP BY ClazzId
				UNION ALL 
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, COUNT(*) AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_VisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId 
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, COUNT(*) AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
				FROM Student_HomeVisitRecord 
				WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
				GROUP BY ClazzId 
				UNION ALL
				SELECT ClazzId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, COUNT(*) AS ReviewHQty
				FROM Student_HomeVisitRecord 
				WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
				GROUP BY ClazzId
				) A INNER JOIN Student_Clazz Z ON A.ClazzId=Z.Id
				GROUP BY ClazzId, Z.Name, Z.Master
				ORDER BY Z.Name DESC
			");
			sb.Replace("@StartTime", String.Format("'{0:d}'", startTime));
			sb.Replace("@EndTime", String.Format("'{0:d}'", endTime));

			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new StudentVisitSummaryReportItem {
						ClazzId = ir["ClazzId"].ToInt(),
						ClazzName = ir["ClazzName"].ToStr(),
						MasterName = ir["Master"].ToStr(),
						HomeQty = ir["HomeQty"].ToInt(),
						TeleQty = ir["TeleQty"].ToInt(),
						VisitQty = ir["VisitQty"].ToInt(),
						VisitQty2 = ir["VisitQty2"].ToInt(),
						VisitQty3 = ir["VisitQty3"].ToInt(),
						ReviewHomeQty = ir["ReviewHQty"].ToInt(),
						ReviewTeleQty = ir["ReviewTQty"].ToInt(),
						ReviewVisitQty = ir["ReviewVQty"].ToInt()
					});
				}
			}

			return m;
		}

		// 三访统计 - 按学生
		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByStudent(string clazzName, DateTime? startTime, DateTime? endTime) {

			StringBuilder sb = new StringBuilder();
			var m = new List<StudentVisitSummaryReportItem>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
SELECT A.ClazzId, Z.Name AS ClazzName, ISNULL(Z.Master,'') + ' ' + ISNULL(Z.TeacherA,'') + ' ' + ISNULL(Z.TeacherB,'') AS Master
	, StudentId, F.Name AS StudentName
	, SUM(TeleQty) AS TeleQty, SUM(VisitQty) AS VisitQty, SUM(VisitQty2) AS VisitQty2
	, SUM(VisitQty3) AS VisitQty3, SUM(HomeQty) AS HomeQty
	, SUM(ReviewTQty) AS ReviewTQty, SUM(ReviewVQty) AS ReviewVQty, SUM(ReviewHQty) AS ReviewHQty
	FROM (  
SELECT ClazzId, StudentId, COUNT(*) AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_TeleVisitRecord 
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
GROUP BY ClazzId, StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, COUNT(*) AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_TeleVisitRecord 
WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
GROUP BY ClazzId, StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, COUNT(*) AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND ISNULL(Z.[Master],'') = U.Name
GROUP BY ClazzId, StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, COUNT(*) AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND (ISNULL(Z.TeacherA,'') = U.Name OR ISNULL(Z.TeacherB,'')=U.Name)
GROUP BY ClazzId, StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, COUNT(*) AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord V INNER JOIN Student_Clazz Z ON V.ClazzId=Z.Id
INNER JOIN Sys_User U ON V.VisitorId = U.Id
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
AND (ISNULL(Z.TeacherA,'') <> U.Name AND ISNULL(Z.TeacherB,'') <> U.Name AND ISNULL(Z.[Master],'')<>U.Name)
GROUP BY ClazzId, StudentId
UNION ALL 
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, COUNT(*) AS ReviewVQty, 0 AS ReviewHQty
FROM Student_VisitRecord 
WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
GROUP BY ClazzId , StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, COUNT(*) AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, 0 AS ReviewHQty
FROM Student_HomeVisitRecord 
WHERE 1 = 1  AND [Time] >= @StartTime  AND [Time] <= @EndTime
GROUP BY ClazzId , StudentId
UNION ALL
SELECT ClazzId, StudentId, 0 AS TeleQty, 0 AS VisitQty, 0 AS VisitQty2, 0 AS VisitQty3, 0 AS HomeQty, 0 AS ReviewTQty, 0 AS ReviewVQty, COUNT(*) AS ReviewHQty
FROM Student_HomeVisitRecord 
WHERE 1 = 1 AND ReviewerId IS NOT NULL  AND [ReviewTime] >= @StartTime  AND [ReviewTime] <= @EndTime
GROUP BY ClazzId, StudentId
) A INNER JOIN Student_Clazz Z ON A.ClazzId=Z.Id
INNER JOIN Student_File F ON A.StudentId=F.Id
GROUP BY A.ClazzId, Z.Name, Z.Master, Z.TeacherA, Z.TeacherB, StudentId, F.Name
HAVING Z.Name LIKE '%' + '@ClazzName' + '%'
ORDER BY TeleQty, VisitQty, VisitQty2, ReviewTQty, ReviewVQty, HomeQty, ReviewHQty
, Z.Name DESC, F.Name ASC
			");
			sb.Replace("@StartTime", String.Format("'{0:d}'", startTime));
			sb.Replace("@EndTime", String.Format("'{0:d}'", endTime));
			sb.Replace("@ClazzName", clazzName);

			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new StudentVisitSummaryReportItem {
						ClazzId = ir["ClazzId"].ToInt(),
						ClazzName = ir["ClazzName"].ToStr(),
						MasterName = ir["Master"].ToStr(),
						HomeQty = ir["HomeQty"].ToInt(),
						TeleQty = ir["TeleQty"].ToInt(),
						VisitQty = ir["VisitQty"].ToInt(),
						VisitQty2 = ir["VisitQty2"].ToInt(),
						VisitQty3 = ir["VisitQty3"].ToInt(),
						ReviewHomeQty = ir["ReviewHQty"].ToInt(),
						ReviewTeleQty = ir["ReviewTQty"].ToInt(),
						ReviewVisitQty = ir["ReviewVQty"].ToInt(),
						StudentId = ir["StudentId"].ToInt(),
						StudentName=ir["StudentName"].ToStr()
					});
				}
			}

			return m;
		}


		// 招生统计报表-总表
		public List<SignUpSummaryReportItem> GetSignUpSummaryReport() {
			StringBuilder sb = new StringBuilder();
			var m = new List<SignUpSummaryReportItem>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT Y, SUM(Qty1) AS Qty1, SUM(Qty2) AS Qty2 FROM (
				SELECT YEAR(SignUpTime) AS Y, COUNT(*) AS Qty1, 0 AS Qty2 
				FROM Marketing_Customer C
				WHERE C.SignUpTime IS NOT NULL
				GROUP BY YEAR(SignUpTime)
				UNION ALL
				SELECT YEAR(SignUpTime) AS Y, 0 AS Qty1, COUNT(*) AS Qty2 
				FROM Marketing_Customer C
				WHERE C.SignUpTime IS NOT NULL
				AND MONTH(SignUpTime) >= 6 AND MONTH(SignUpTime) < 9 OR (MONTH(SignUpTime)=9 AND DAY(SignUpTime) <=10)
				GROUP BY YEAR(SignUpTime)
				) A
				GROUP BY Y
				ORDER BY Y		
			");

			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SignUpSummaryReportItem {
						Year = ir["Y"].ToInt(),
						FullYearQty = ir["Qty1"].ToInt(),
						SummerQty = ir["Qty2"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按月统计
		public List<SignUpSummaryReportItem> GetSignUpSummaryReportByMonth(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SignUpSummaryReportItem>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT MONTH(SignUpTime) AS M, COUNT(*) AS Qty1
				FROM Marketing_Customer C
				WHERE C.SignUpTime IS NOT NULL AND YEAR(SignUpTime) = @Year
				GROUP BY MONTH(SignUpTime)
				ORDER BY M			
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SignUpSummaryReportItem {
						Month = ir["M"].ToInt(),
						FullYearQty = ir["Qty1"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按电话营销组统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeam(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SalesTeamId, T.Name AS SalesTeamName, SUM(SchoolQty) AS SchoolQty, SUM(TelQty) AS TelQty, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT STM.SalesTeamId, COUNT(*) AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_SalesTeamMember STM ON L.SalesmanId=STM.UserId
				--INNER JOIN Marketing_SalesTeam T ON STM.SalesTeamId=T.Id
				WHERE YEAR(L.TelTime) = @Year
				GROUP BY STM.SalesTeamId
				UNION					
				SELECT C.SalesTeamId, 0 AS TelQty, COUNT(DISTINCT C.SchoolId) AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE  C.MarketYear=@Year
				GROUP BY C.SalesTeamId 
				UNION 	
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.SalesTeamId 
				UNION  
				SELECT C.SalesTeamId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year 
				GROUP BY C.SalesTeamId 
				) A INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id 
				GROUP BY A.SalesTeamId, T.Name 
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, T.Name 
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						SchoolQty = ir["SchoolQty"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按电话营销员统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesman(int year, int teamId) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SalesmanId, U.Name AS SalesmanName,
					SUM(Total) AS Total, SUM(N) AS N, SUM(TelQty) AS TelQty,
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
					SUM(DinWei) AS DinWei FROM (
				SELECT L.SalesmanId, COUNT(*) AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_SalesTeamMember STM ON L.SalesmanId=STM.UserId
				WHERE YEAR(L.TelTime) = @Year
				AND STM.SalesTeamId=@Team
				GROUP BY L.SalesmanId
				UNION					
				SELECT C.SalesmanId, 0 AS TelQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.LastSalesTime IS NULL
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION 
				SELECT C.SalesmanId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime)=@Year  AND C.SalesTeamId=@Team 
				GROUP BY C.SalesTeamId, C.SalesmanId
				) A 
				INNER JOIN Sys_User U ON A.SalesmanId = U.Id
				GROUP BY A.SalesmanId, U.Name
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, U.Name
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Team", teamId.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						SalesmanId = ir["SalesmanId"].ToInt(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按电话营销员、按月细化统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesmanAndMonth(int year, int salesmanId) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT M,
					SUM(Total) AS Total, SUM(N) AS N,
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
					SUM(DinWei) AS DinWei FROM (
				SELECT MONTH(C.DropInTime) AS M, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesmanId=@SalesmanId 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY MONTH(C.DropInTime)
				UNION
				SELECT MONTH(C.DropInTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesmanId=@SalesmanId 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY MONTH(C.DropInTime)
				UNION
				SELECT MONTH(C.SignUpTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesmanId=@SalesmanId 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY MONTH(C.SignUpTime)
				UNION
				SELECT MONTH(C.SignUpTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesmanId=@SalesmanId 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY MONTH(C.SignUpTime)
				UNION 
				SELECT MONTH(C.DinWeiTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime)=@Year  AND C.SalesmanId=@SalesmanId 
				GROUP BY MONTH(C.DinWeiTime)
				) A 
				GROUP BY M
				ORDER BY M
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@SalesmanId", salesmanId.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						M=ir["M"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按电话营销组、按月细化统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndMonth(int year, int teamId) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT M,
					SUM(Total) AS Total, SUM(N) AS N,
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
					SUM(DinWei) AS DinWei FROM (
				SELECT MONTH(C.DropInTime) AS M, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY MONTH(C.DropInTime)
				UNION
				SELECT MONTH(C.DropInTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY MONTH(C.DropInTime)
				UNION
				SELECT MONTH(C.SignUpTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY MONTH(C.SignUpTime)
				UNION
				SELECT MONTH(C.SignUpTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY MONTH(C.SignUpTime)
				UNION 
				SELECT MONTH(C.DinWeiTime) AS M, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime)=@Year  AND C.SalesTeamId=@Team 
				GROUP BY MONTH(C.DinWeiTime)
				) A 
				GROUP BY M
				ORDER BY M
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Team", teamId.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						M=ir["M"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按组按月统计各组员的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesman(int year, int month, int teamId) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SalesmanId, U.Name AS SalesmanName,
					SUM(Total) AS Total, SUM(N) AS N,
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
					SUM(DinWei) AS DinWei FROM (
				SELECT C.SalesmanId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.LastSalesTime IS NULL
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year AND MONTH(C.DropInTime)=@Month 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year  AND MONTH(C.DropInTime)=@Month 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year  AND MONTH(C.SignUpTime)=@Month 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION
				SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year  AND MONTH(C.SignUpTime)=@Month 
				GROUP BY C.SalesTeamId, C.SalesmanId
				UNION 
				SELECT C.SalesmanId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE C.IsDinWei = 1 AND C.SalesTeamId=@Team  AND YEAR(C.DinWeiTime)=@Year  AND MONTH(C.DinWeiTime)=@Month
				GROUP BY C.SalesTeamId, C.SalesmanId
				) A 
				INNER JOIN Sys_User U ON A.SalesmanId = U.Id
				GROUP BY A.SalesmanId, U.Name
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, U.Name
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Month", month.ToString());
			sb.Replace("@Team", teamId.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						SalesmanId = ir["SalesmanId"].ToInt(),
						SalesmanName = ir["SalesmanName"].ToStr(),
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
			}

			return m;
		}
		// 招生统计报表-按月统计各组的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSalesTeam(int year, int month) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SalesTeamId, T.Name AS SalesTeamName, 
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
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month 
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year  AND MONTH(C.SignUpTime) = @Month
				GROUP BY C.SalesTeamId 
				UNION 
				SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year AND MONTH(C.SignUpTime) = @Month 
				GROUP BY C.SalesTeamId 
				UNION  
				SELECT C.SalesTeamId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year  AND MONTH(C.DinWeiTime) = @Month
				GROUP BY C.SalesTeamId 
				) A INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id 
				GROUP BY A.SalesTeamId, T.Name 
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, T.Name 
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Month", month.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
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
			}

			return m;
		}
		// 招生统计报表-按月统计各区域的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndDistrict(int year, int month) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT DistrictId, P.Name+C.Name+D.Name  AS DistrictName, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.DistrictId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year  AND MONTH(C.SignUpTime) = @Month
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year AND MONTH(C.SignUpTime) = @Month 
				GROUP BY C.DistrictId 
				UNION  
				SELECT C.DistrictId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year  AND MONTH(C.DinWeiTime) = @Month
				GROUP BY C.DistrictId 
				) A INNER JOIN BaseInfo_District D ON A.DistrictId=D.Id 
				INNER JOIN BaseInfo_City C ON D.CityId=C.Id
				INNER JOIN BaseInfo_Province P ON C.ProvinceId=P.Id
				GROUP BY A.DistrictId, P.Name+C.Name+D.Name 
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, DistrictName 
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Month", month.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						DistrictId = ir["DistrictId"].ToInt(),
						DistrictName = ir["DistrictName"].ToStr(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按月统计各学校的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndSchool(int year, int month) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SchoolId, S.Name  AS SchoolName, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.SchoolId, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year  AND MONTH(C.SignUpTime) = @Month
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year AND MONTH(C.SignUpTime) = @Month 
				GROUP BY C.SchoolId 
				UNION  
				SELECT C.SchoolId, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year  AND MONTH(C.DinWeiTime) = @Month
				GROUP BY C.SchoolId 
				) A INNER JOIN BaseInfo_School S ON A.SchoolId=S.Id 
				GROUP BY A.SchoolId, S.Name
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, SchoolName 
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Month", month.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按月统计各种学历层次的量
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByMonthAndEduLevel(int year, int month) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT EduLevel, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.EduLevel, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year AND MONTH(C.DropInTime) = @Month 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year  AND MONTH(C.SignUpTime) = @Month
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year AND MONTH(C.SignUpTime) = @Month 
				GROUP BY C.EduLevel 
				UNION  
				SELECT C.EduLevel, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year  AND MONTH(C.DinWeiTime) = @Month
				GROUP BY C.EduLevel 
				) A 
				GROUP BY A.EduLevel
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, EduLevel 
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Month", month.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						EduLevel = ir["EduLevel"].ToStr(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按组统计学校数量和资料数量
		public List<SalesTeamSchoolQtyReportItem> GetSchoolQtyReportBySalesTeam(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSchoolQtyReportItem>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT C.SalesTeamId, T.Name, COUNT(DISTINCT C.SchoolId) AS SchoolQty, COUNT(*) AS CustomerQty 
				FROM Marketing_Customer C INNER JOIN Marketing_SalesTeam T ON C.SalesTeamId=T.Id
				WHERE C.MarketYear=@Year
				GROUP BY C.SalesTeamId, T.Name
				ORDER BY SchoolQty DESC
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSchoolQtyReportItem {
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesTeamName = ir["Name"].ToStr(),
						SchoolQty = ir["SchoolQty"].ToInt(),
						CustomerQty = ir["CustomerQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按区域统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByDistrict(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT DistrictId, T.Name AS DistrictName, SUM(SchoolQty) AS SchoolQty, SUM(TelQty) AS TelQty, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.DistrictId, COUNT(*) AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				WHERE YEAR(L.TelTime) = @Year
				GROUP BY C.DistrictId
				UNION					
				SELECT C.DistrictId, 0 AS TelQty, COUNT(DISTINCT C.SchoolId) AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE  C.MarketYear=@Year
				GROUP BY C.DistrictId 
				UNION 	
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.DistrictId 
				UNION 
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.DistrictId 
				UNION  
				SELECT C.DistrictId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year 
				GROUP BY C.DistrictId 
				) A INNER JOIN BaseInfo_District T ON A.DistrictId=T.Id 
				GROUP BY A.DistrictId, T.Name 
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, T.Name 
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						DistrictId = ir["DistrictId"].ToInt(),
						DistrictName = ir["DistrictName"].ToStr(),
						SchoolQty = ir["SchoolQty"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按学校统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySchool(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SchoolId, T.Name AS SchoolName, SUM(SchoolQty) AS SchoolQty, SUM(TelQty) AS TelQty, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.SchoolId, COUNT(*) AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				WHERE YEAR(L.TelTime) = @Year
				GROUP BY C.SchoolId
				UNION					
				SELECT C.SchoolId, 0 AS TelQty, COUNT(DISTINCT C.SchoolId) AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE  C.MarketYear=@Year
				GROUP BY C.SchoolId 
				UNION 	
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.SchoolId 
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.SchoolId 
				UNION  
				SELECT C.SchoolId, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year 
				GROUP BY C.SchoolId 
				) A INNER JOIN BaseInfo_School T ON A.SchoolId=T.Id 
				GROUP BY A.SchoolId, T.Name 
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, T.Name 
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						SchoolId = ir["SchoolId"].ToInt(),
						SchoolName = ir["SchoolName"].ToStr(),
						SchoolQty = ir["SchoolQty"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按学历统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportByEduLevel(int year) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT EduLevel, SUM(SchoolQty) AS SchoolQty, SUM(TelQty) AS TelQty, 
					SUM(Total) AS Total, SUM(N) AS N,  
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn, 
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp, 
					SUM(DinWei) AS DinWei FROM ( 
				SELECT C.EduLevel, COUNT(*) AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				WHERE YEAR(L.TelTime) = @Year
				GROUP BY C.EduLevel
				UNION					
				SELECT C.EduLevel, 0 AS TelQty, COUNT(DISTINCT C.SchoolId) AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE  C.MarketYear=@Year
				GROUP BY C.EduLevel 
				UNION 	
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.LastSalesTime IS NULL 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime) = @Year 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId = 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.EduLevel 
				UNION 
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE SI.InfoSourceBigId > 1 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime) = @Year 
				GROUP BY C.EduLevel 
				UNION  
				SELECT C.EduLevel, 0 AS TelQty, 0 AS SchoolQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei 
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id 
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime) = @Year 
				GROUP BY C.EduLevel 
				) A  
				GROUP BY A.EduLevel
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, EduLevel
			");
			sb.Replace("@Year", year.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
						Total = ir["Total"].ToInt(),
						N = ir["N"].ToInt(),
						EduLevel = ir["EduLevel"].ToStr(),
						SchoolQty = ir["SchoolQty"].ToInt(),
						TelDropIn = ir["TelDropIn"].ToInt(),
						NonTelDropIn = ir["NonTelDropIn"].ToInt(),
						TotalDropIn = ir["TotalDropIn"].ToInt(),
						TelSignUp = ir["TelSignUp"].ToInt(),
						NonTelSignUp = ir["NonTelSignUp"].ToInt(),
						TotalSignUp = ir["TotalSignUp"].ToInt(),
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-按电话营销组和学校统计
		public List<SalesTeamSummaryReport> GetSignUpSummaryReportBySalesTeamAndSchool(int year, int teamId) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SalesTeamSummaryReport>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT SchoolId, U.Name AS SchoolName,
					SUM(Total) AS Total, SUM(N) AS N, SUM(TelQty) AS TelQty,
					SUM(TelDropIn) AS TelDropIn, SUM(NonTelDropIn) AS NonTelDropIn, SUM(TelDropIn) + SUM(NonTelDropIn) AS TotalDropIn,
					SUM(TelSignUp) AS TelSignUp, SUM(NonTelSignUp) AS NonTelSignUp, SUM(TelSignUp) + SUM(NonTelSignUp) AS TotalSignUp,
					SUM(DinWei) AS DinWei FROM (
				SELECT C.SchoolId, COUNT(*) AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei 
				FROM Marketing_TelSaleLog L 
				INNER JOIN Marketing_SalesTeamMember STM ON L.SalesmanId=STM.UserId
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				WHERE YEAR(L.TelTime) = @Year
				AND STM.SalesTeamId=@Team
				GROUP BY C.SchoolId
				UNION					
				SELECT C.SchoolId, 0 AS TelQty, COUNT(C.Id) AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, COUNT(C.Id) AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.LastSalesTime IS NULL
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, 0 AS N, COUNT(C.Id) AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, COUNT(C.Id) AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsDropIn = 1 AND YEAR(C.DropInTime)=@Year 
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, COUNT(C.Id) AS TelSignUp, 0 AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId = 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, COUNT(C.Id) AS NonTelSignUp, 0  AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE SI.InfoSourceBigId > 1 AND C.SalesTeamId=@Team 
				AND C.IsSignUp = 1 AND YEAR(C.SignUpTime)=@Year 
				GROUP BY C.SalesTeamId, C.SchoolId
				UNION 
				SELECT C.SchoolId, 0 AS TelQty, 0 AS Total, 0 AS N, 0 AS TelDropIn, 0 AS NonTelDropIn, 0 AS TelSignUp, 0 AS NonTelSignUp, COUNT(C.Id) AS DinWei
				FROM Marketing_Customer C INNER JOIN BaseInfo_InfoSourceSmall SI ON C.SmallInfoSourceId=SI.Id
				WHERE C.IsDinWei = 1 AND YEAR(C.DinWeiTime)=@Year  AND C.SalesTeamId=@Team 
				GROUP BY C.SalesTeamId, C.SchoolId
				) A 
				INNER JOIN BaseInfo_School U ON A.SchoolId = U.Id
				GROUP BY A.SchoolId, U.Name
				ORDER BY TotalSignUp DESC, DinWei DESC, TotalDropIn DESC, TelQty DESC, U.Name
			");
			sb.Replace("@Year", year.ToString());
			sb.Replace("@Team", teamId.ToString());
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SalesTeamSummaryReport {
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
						DinWei = ir["DinWei"].ToInt(),
						TelQty = ir["TelQty"].ToInt()
					});
				}
			}

			return m;
		}
		// 招生统计报表-招生排名
		public List<SignUpRankingListItem> GetSignUpRankingList(DateTime startTime, DateTime endTime, string orderBy, string rankBy) {
			StringBuilder sb = new StringBuilder();
			var m = new List<SignUpRankingListItem>();
			var db = DatabaseFactory.CreateDatabase();
			/*
			sb.Append(@"
				SELECT * FROM (
				SELECT A.MarketYear, A.SalesTeamId, A.SalesmanId, T.Name AS SalesTeamName, U.Name AS SalesmanName, 
				SUM(SignUpQty) AS SignUpQty, SUM(A.DropInQty) AS DropInQty, SUM(A.TelQty) AS TelQty, 
				CONVERT(DECIMAL,SUM(A.DropInQty))/(CASE SUM(TelQty) WHEN 0 THEN 1 ELSE SUM(A.TelQty) END) AS DropInRate,
				CONVERT(DECIMAL,SUM(A.SignUpQty))/(CASE SUM(DropInQty) WHEN 0 THEN 1 ELSE SUM(A.DropInQty) END) AS SignUpRate
				FROM (
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, COUNT(*) AS SignUpQty, 0 AS DropInQty, 0 AS TelQty 
				FROM Marketing_Customer C
				WHERE C.IsSignUp=1 AND C.MarketYear=@Year
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, 0 AS SignUpQty, COUNT(*) AS DropInQty, 0 AS TelQty  
				FROM Marketing_Customer C
				WHERE C.IsDropIn=1 AND C.MarketYear=@Year
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, M.SalesTeamId, L.SalesmanId, 0 AS SignUpQty, 0 AS DropInQty, COUNT(*) AS TelQty 
				FROM Marketing_TelSaleLog L
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId=M.UserId
				WHERE  C.MarketYear=@Year
				GROUP BY C.MarketYear, M.SalesTeamId, L.SalesmanId
				) A 
				INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id
				INNER JOIN Sys_User U ON A.SalesmanId=U.Id
				GROUP BY A.MarketYear, A.SalesTeamId, A.SalesmanId, T.Name, U.Name
				) B ORDER BY @orderBy DESC
			");
			*/
			sb.Append(@"
				SELECT RANK() OVER (ORDER BY @rankBy DESC) AS Rank, * FROM (
				SELECT A.MarketYear, A.SalesTeamId, A.SalesmanId, T.Name AS SalesTeamName, U.Name AS SalesmanName, 
				SUM(TelSignUpQty) AS TelSignUpQty, SUM(NonTelSignUpQty) AS NonTelSignUpQty, 
				SUM(A.TelDropInQty) AS TelDropInQty, SUM(A.NonTelDropInQty) AS NonTelDropInQty, SUM(A.TelQty) AS TelQty, 
				CONVERT(DECIMAL,SUM(A.TelDropInQty))/(CASE SUM(TelQty) WHEN 0 THEN 1 ELSE SUM(A.TelQty) END) AS DropInRate,
				CONVERT(DECIMAL,SUM(A.TelSignUpQty))/(CASE SUM(TelDropInQty) WHEN 0 THEN 1 ELSE SUM(A.TelDropInQty) END) AS SignUpRate
				, SUM(TelSignUpQty)+SUM(NonTelSignUpQty) AS SignUpQty
				, SUM(A.TelDropInQty)+SUM(A.NonTelDropInQty) AS DropInQty
				FROM (
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, COUNT(*) AS TelSignUpQty, 0 AS NonTelSignUpQty, 0 AS TelDropInQty, 0 AS NonTelDropInQty, 0 AS TelQty 
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_InfoSourceSmall S ON C.SmallInfoSourceId=S.Id
				WHERE C.IsSignUp=1 AND S.InfoSourceBigId=1
				AND C.SignUpTime BETWEEN @StartTime AND @EndTime
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, 0 AS TelSignUpQty, COUNT(*) AS NonTelSignUpQty, 0 AS TelDropInQty, 0 AS NonTelDropInQty, 0 AS TelQty 
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_InfoSourceSmall S ON C.SmallInfoSourceId=S.Id
				WHERE C.IsSignUp=1 AND S.InfoSourceBigId>1
				AND C.SignUpTime BETWEEN @StartTime AND @EndTime
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, 0 AS TelSignUpQty, 0 AS NonTelSignUpQty, COUNT(*) AS TelDropInQty, 0 AS NonTelDropInQty, 0 AS TelQty  
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_InfoSourceSmall S ON C.SmallInfoSourceId=S.Id
				WHERE C.IsDropIn=1 AND S.InfoSourceBigId=1
				AND C.DropInTime BETWEEN @StartTime AND @EndTime
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, C.SalesTeamId, C.SalesmanId, 0 AS TelSignUpQty, 0 AS NonTelSignUpQty, 0 AS TelDropInQty, COUNT(*) AS NonTelDropInQty, 0 AS TelQty  
				FROM Marketing_Customer C
				INNER JOIN BaseInfo_InfoSourceSmall S ON C.SmallInfoSourceId=S.Id
				WHERE C.IsDropIn=1  AND S.InfoSourceBigId>1
				AND C.DropInTime BETWEEN @StartTime AND @EndTime
				GROUP BY C.MarketYear, C.SalesTeamId, C.SalesmanId
				UNION ALL
				SELECT C.MarketYear, M.SalesTeamId, L.SalesmanId, 0 AS TelSignUpQty, 0 AS NonTelSignUpQty, 0 AS TelDropInQty, 0 AS NonTelDropInQty, COUNT(*) AS TelQty 
				FROM Marketing_TelSaleLog L
				INNER JOIN Marketing_Customer C ON L.CustomerId=C.Id
				INNER JOIN Marketing_SalesTeamMember M ON L.SalesmanId=M.UserId
				WHERE   L.TelTime BETWEEN @StartTime AND @EndTime
				GROUP BY C.MarketYear, M.SalesTeamId, L.SalesmanId
				) A 
				INNER JOIN Marketing_SalesTeam T ON A.SalesTeamId=T.Id
				INNER JOIN Sys_User U ON A.SalesmanId=U.Id
				GROUP BY A.MarketYear, A.SalesTeamId, A.SalesmanId, T.Name, U.Name
				) B ORDER BY @orderBy 
			"); 
			sb.Replace("@orderBy", orderBy);
			sb.Replace("@rankBy", rankBy);
			sb.Replace("@StartTime", String.Format("'{0:d}'",startTime));
			sb.Replace("@EndTime", String.Format("'{0:d}'", endTime));
			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new SignUpRankingListItem {
						Rank = ir["Rank"].ToInt(),
						TelQty = ir["TelQty"].ToInt(),
						DropInQty = ir["DropInQty"].ToInt(),
						SignUpQty = ir["SignUpQty"].ToInt(),
						TelDropInQty = ir["TelDropInQty"].ToInt(),
						TelSignUpQty = ir["TelSignUpQty"].ToInt(),
						NonTelDropInQty = ir["NonTelDropInQty"].ToInt(),
						NonTelSignUpQty = ir["NonTelSignUpQty"].ToInt(),
						SalesmanId = ir["SalesmanId"].ToInt(),
						SalesTeamId = ir["SalesTeamId"].ToInt(),
						SalesmanName = ir["SalesmanName"].ToStr(),
						SalesTeamName = ir["SalesTeamName"].ToStr(),
						DropInRate = String.Format("{0:P}",ir["DropInRate"].ToDecimal()),
						SignUpRate = String.Format("{0:P}", ir["SignUpRate"].ToDecimal())
					});
				}
			}

			return m;
		}
		
		// 三访统计，按老师
		public List<StudentVisitSummaryReportItem> GetStudentVisitSummaryReportByTeacher(DateTime? startTime, DateTime? endTime) {
			StringBuilder sb = new StringBuilder();
			var m = new List<StudentVisitSummaryReportItem>();
			var db = DatabaseFactory.CreateDatabase();

			sb.Append(@"
				SELECT Name, SUM(TQty) AS TQty, SUM(VQty) AS VQty FROM (
				SELECT U.Name, COUNT(*) AS TQty, 0 AS VQty
				FROM Student_TeleVisitRecord R 
				INNER JOIN Sys_User U ON R.VisitorId=U.Id
				WHERE Time BETWEEN '@StartTime' AND '@EndTime'
				GROUP BY U.Name
				UNION ALL
				SELECT U.Name, 0 AS TQty, COUNT(*) AS VQty
				FROM Student_VisitRecord R 
				INNER JOIN Sys_User U ON R.VisitorId=U.Id
				WHERE Time BETWEEN '@StartTime' AND '@EndTime'
				GROUP BY U.Name
				) A
				GROUP BY Name
				ORDER BY SUM(TQty)+SUM(VQty) DESC			
			");
			sb.Replace("@StartTime", (startTime == null) ? "2000-1-1" : String.Format("{0:d}", startTime));
			sb.Replace("@EndTime", (endTime == null) ? "3000-1-1" : String.Format("{0:d}", endTime));

			using (var ir = db.ExecuteReader(CommandType.Text, sb.ToString())) {
				while (ir.Read()) {
					m.Add(new StudentVisitSummaryReportItem {
						TeacherName = ir["Name"].ToStr(),
						TeleQty = ir["TQty"].ToInt(),
						VisitQty = ir["VQty"].ToInt()
					});
				}
			}

			return m;
		}
	}
}
