using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Cn.RaymanLee.Data;
using Cn.RaymanLee.Utils;

namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IQualificationStudentRepository {
		List<QualificationStudent> Search(QualificationStudentCriteria c);
		List<QualificationSummaryReportItem> GetSummaryReport();
		List<QualificationSumBySchoolReportItem> SumBySchool(int year);
		List<QualificationSumBySchoolReportItem> SumByConsultant(int year);
		List<QualificationSumBySchoolReportItem> SumByReferer(int year, string consultant);
		List<List<object>> SumByStatus();
	}
	public partial class QualificationStudentRepository : IQualificationStudentRepository {
		public List<QualificationStudent> Search(QualificationStudentCriteria c) {
			List<QualificationStudent> list = new List<QualificationStudent>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT [Id], [Name] FROM [Qualification_Student] WHERE ((Consultant = '"+c.CurrentUserName+"') OR ('"+c.CurrentUserName+"' IN (SELECT [UserName] FROM Qualification_UnrestrictedUser))) ";
			if (c.Year.HasValue) sql += " AND YEAR(SignUpTime) = " + c.Year.Value.ToString();
			if (!String.IsNullOrWhiteSpace(c.NameSrh)) sql += " AND ISNULL([Name],'') LIKE '%"+c.NameSrh+"%' ";
			if (!String.IsNullOrWhiteSpace(c.ConsultantSrh)) sql += " AND ISNULL([Consultant],'') LIKE '%"+c.ConsultantSrh+"%' ";
			if (!String.IsNullOrWhiteSpace(c.ReferrerSrh)) sql += " AND ISNULL([Referrer],'') LIKE '%" + c.ReferrerSrh + "%' ";
			if (!String.IsNullOrWhiteSpace(c.TargetSchoolNameSrh)) sql += " AND ISNULL([TargetSchoolName],'') LIKE '%" + c.TargetSchoolNameSrh + "%' ";
			if (!String.IsNullOrWhiteSpace(c.SubmitStatusSrh)) sql += " AND ISNULL([SubmitStatus],'') LIKE '%" + c.SubmitStatusSrh + "%' ";
			if (!String.IsNullOrWhiteSpace(c.OfferStatusSrh)) sql += " AND ISNULL([OfferStatus],'') LIKE '%" + c.OfferStatusSrh + "%' ";
			if (!String.IsNullOrWhiteSpace(c.PayStatusSrh)) sql += " AND ISNULL([PayStatus],'') LIKE '%" + c.PayStatusSrh + "%' ";
			if (!String.IsNullOrWhiteSpace(c.PaperStatusSrh)) sql += " AND ISNULL([PaperStatus],'') LIKE '%" + c.PaperStatusSrh + "%' ";
			sql += "ORDER BY YEAR(SignUpTime) DESC, [Name]";

			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					list.Add(new QualificationStudent {
						 Id = ir["Id"].ToInt(),
						 Name = ir["Name"].ToStr()
					});
					/*
					list.Add(new QualificationStudent {
						BeginWorkTime = ir["BeginWorkTime"].ToNullableDateTime(),
						Birthday = ir["Birthday"].ToNullableDateTime(),
						Clazz = ir["Clazz"].ToStr(),
						CommAddress = ir["CommAddress"].ToStr(),
						 Company = ir["Company"].ToStr(),
						 CompanyTelephoneNo = ir["CompanyTelephoneNo"].ToStr(),
						 Consultant=ir["Consultant"].ToStr(),
						 GraduateDate = ir["GraduateDate"].ToNullableDateTime(),
						 GruduateSchool = ir["GruduateSchool"].ToStr(),
						 HighestEduLevel = ir["HighestEduLevel"].ToStr(),
						 HighestQualification = ir["HighestQualification"].ToStr(),
						 HighestQualificationNo = ir["HighestQualificationNo"].ToStr(),
						 HomeAddress = ir["HomeAddress"].ToStr(),
						 HomeTelephone = ir["HomeTelephone"].ToStr(),
						 HuKouAddress = ir["HuKouAddress"].ToStr(),
						 Id = ir["Id"].ToInt(),
						 IdCardNo = ir["IdCardNo"].ToStr(),
						 IsMarried = ir["IsMarried"].ToStr(),
						 JiGuang = ir["JiGuang"].ToStr(),
						 MatriculateTime = ir["MatriculateTime"].ToNullableDateTime(),
						 MemberCompany1 = ir["MemberCompany1"].ToStr(),
						 MemberCompany2 = ir["MemberCompany2"].ToStr(),
						 MemberMianMao1 = ir["MemberMianMao1"].ToStr(),
						 MemberMianMao2 = ir["MemberMianMao2"].ToStr(),
						 MemberMobile1 = ir["MemberMobile1"].ToStr(),
						 MemberMobile2 = ir["MemberMobile2"].ToStr(),
						 MemberName1 = ir["MemberName1"].ToStr(),
						 MemberName2 = ir["MemberName2"].ToStr(),
						 MemberPosition1 = ir["MemberPosition1"].ToStr(),
						 MemberPosition2 = ir["MemberPosition2"].ToStr(),
						 MemberRelType1 = ir["MemberRelType1"].ToStr(),
						 MemberRelType2 = ir["MemberRelType2"].ToStr(),
						 MinZu = ir["MinZu"].ToStr(),
						 Mobile = ir["Mobile"].ToStr(),
						 Name = ir["Name"].ToStr(),
						 NetPassword = ir["NetPassword"].ToStr(),
						 NetUserName = ir["NetUserName"].ToStr(),
						 OfferStatus = ir["OfferStatus"].ToStr(),
						 OldOAId = ir["OldOAId"].ToStr(),
						 PaperStatus = ir["PaperStatus"].ToStr(),
						 PayStatus = ir["PayStatus"].ToStr(),
						 Photo1 = ir["Photo1"].ToStr(),
						 Photo2 = ir["Photo2"].ToStr(),
						 Photo3 = ir["Photo3"].ToStr(),
						 Postcode = ir["Postcode"].ToStr(),
						 QQ = ir["QQ"].ToStr(),
						 Referrer = ir["Referrer"].ToStr(),
						 ReferrerMobile = ir["ReferrerMobile"].ToStr(),
						 ReferrerQQ = ir["ReferrerQQ"].ToStr(),
						 Remark = ir["Remark"].ToStr(),
						 SeqNo = ir["SeqNo"].ToStr(),
						 Sex = ir["Sex"].ToStr(),
						 SignUpTime = ir["SignUpTime"].ToNullableDateTime(),
						 Status = ir["Status"].ToStr(),
						 StudentNo = ir["StudentNo"].ToStr(),
						 StudyDuration1 = ir["StudyDuration1"].ToStr(),
						 StudyDuration2 = ir["StudyDuration2"].ToStr(),
						 StudyDuration3 = ir["StudyDuration3"].ToStr(),
						 StudyPosition1 = ir["StudyPosition1"].ToStr(),
						 StudyPosition2 = ir["StudyPosition2"].ToStr(),
						 StudyPosition3 = ir["StudyPosition3"].ToStr(),
						 StudySchool1 = ir["StudySchool1"].ToStr(),
						 StudySchool2 = ir["StudySchool2"].ToStr(),
						 StudySchool3 = ir["StudySchool3"].ToStr(),
						 StudyType = ir["StudyType"].ToStr(),
						 SubmitStatus = ir["SubmitStatus"].ToStr(),
						 TargetLevel = ir["TargetLevel"].ToStr(),
						 TargetProfession = ir["TargetProfession"].ToStr(),
						 TargetSchoolName = ir["TargetSchoolName"].ToStr(),
						 Title = ir["Title"].ToStr(),
						 WorkedYears = ir["WorkedYears"].ToNullableInt(),
						 ZhengZhiMianMao = ir["ZhengZhiMianMao"].ToStr()
					});					 
					 */
				}
				ir.Close();
			}


			return list;			
		}
	
		public List<QualificationSummaryReportItem> GetSummaryReport() {
			List<QualificationSummaryReportItem> list = new List<QualificationSummaryReportItem>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT YEAR(SignUpTime) AS Year, COUNT(*) AS Qty FROM Qualification_Student 
				GROUP BY YEAR(SignUpTime)
				ORDER BY Year DESC";

			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					list.Add(new QualificationSummaryReportItem {
						Year = ir["Year"].ToInt(),
						Qty = ir["Qty"].ToInt()
					});

				}
				ir.Close();
			}


			return list;			
		}

		public List<QualificationSumBySchoolReportItem> SumBySchool(int year) {
			List<QualificationSumBySchoolReportItem> list = new List<QualificationSumBySchoolReportItem>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT YEAR(SignUpTime) AS Year, ISNULL(TargetSchoolName,'(未填写)') AS TargetSchoolName, COUNT(*) AS Qty FROM Qualification_Student "+
				" WHERE YEAR(SignUpTime) = "+year+
				" GROUP BY TargetSchoolName,YEAR(SignUpTime)"+
				" ORDER BY TargetSchoolName";

			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					list.Add(new QualificationSumBySchoolReportItem {
						School = ir["TargetSchoolName"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});

				}
				ir.Close();
			}


			return list;			
		}
		public List<QualificationSumBySchoolReportItem> SumByConsultant(int year) {
			List<QualificationSumBySchoolReportItem> list = new List<QualificationSumBySchoolReportItem>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT YEAR(SignUpTime) AS Year, ISNULL(Consultant,'(未填写)') AS Consultant, COUNT(*) AS Qty FROM Qualification_Student " +
				" WHERE YEAR(SignUpTime) = "+year+
				" GROUP BY Consultant,YEAR(SignUpTime)" +
				" ORDER BY Consultant";

			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					list.Add(new QualificationSumBySchoolReportItem {
						Consultant = ir["Consultant"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});

				}
				ir.Close();
			}


			return list;			
		}
		public List<QualificationSumBySchoolReportItem> SumByReferer(int year, string consultant) {
			List<QualificationSumBySchoolReportItem> list = new List<QualificationSumBySchoolReportItem>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT YEAR(SignUpTime) AS Year, ISNULL(Referrer,'(未填写)') AS Referrer, COUNT(*) AS Qty FROM Qualification_Student " +
				"WHERE YEAR(SignUpTime) = " + year + " AND ISNULL(Consultant,'') = '" + consultant + "' " +
				"GROUP BY Referrer,YEAR(SignUpTime)" +
				"ORDER BY Referrer";

			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					list.Add(new QualificationSumBySchoolReportItem {
						Referrer = ir["Referrer"].ToStr(),
						Qty = ir["Qty"].ToInt()
					});

				}
				ir.Close();
			}


			return list;			
		}
		public List<List<object>> SumByStatus() {
			List<List<object>> list = new List<List<object>>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			var sql = @"SELECT Year, TargetSchoolName, SUM(Qty) AS Qty
	, SUM(UnSubmitQty) AS UnSubmitQty, SUM(SubmitQty) AS SubmitQty, SUM(UnOfferQty) AS UnOfferQty, SUM(OfferQty) AS OfferQty
	, SUM(NoOfferQty) AS NoOfferQty, SUM(UnPayQty) AS UnPayQty, SUM(PayQty) AS PayQty , SUM(PartialPayQty) AS PartialPayQty
	, SUM(NoPaperQty) AS NoPaperQty, SUM(HavePaperQty) AS HavePaperQty
FROM (
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, COUNT(*) AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, COUNT(*) AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE SubmitStatus = '未上报'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, COUNT(*) AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE SubmitStatus = '已上报'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, COUNT(*) AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE OfferStatus = '未录取'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, COUNT(*) AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE OfferStatus = '已录取'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, COUNT(*) AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE OfferStatus = '录取不成功'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, COUNT(*) AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE PayStatus = '未缴费'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, COUNT(*) AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE PayStatus = '已缴费'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, COUNT(*) AS PartialPayQty
	, 0 AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE PayStatus = '分期付款'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, COUNT(*) AS NoPaperQty, 0 AS HavePaperQty 
FROM Qualification_Student
WHERE PaperStatus = '未持证'
GROUP BY YEAR(SignUpTime), TargetSchoolName
UNION ALL
SELECT YEAR(SignUpTime) AS Year, TargetSchoolName, 0 AS Qty
	, 0 AS UnSubmitQty, 0 AS SubmitQty, 0 AS UnOfferQty, 0 AS OfferQty
	, 0 AS NoOfferQty, 0 AS UnPayQty, 0 AS PayQty, 0 AS PartialPayQty
	, 0 AS NoPaperQty, COUNT(*) AS HavePaperQty 
FROM Qualification_Student
WHERE PaperStatus = '已持证'
GROUP BY YEAR(SignUpTime), TargetSchoolName

) A 
GROUP BY Year,TargetSchoolName
ORDER BY Year DESC,TargetSchoolName  
";
			/*
			 Year, TargetSchoolName, SUM(Qty) AS Qty
				, SUM(UnSubmitQty) AS UnSubmitQty, SUM(SubmitQty) AS SubmitQty, SUM(UnOfferQty) AS UnOfferQty, SUM(OfferQty) AS OfferQty
				, SUM(NoOfferQty) AS NoOfferQty, SUM(UnPayQty) AS UnPayQty, SUM(PayQty) AS PayQty , SUM(PartialPayQty) AS PartialPayQty
				, SUM(NoPaperQty) AS NoPaperQty, SUM(HavePaperQty) AS HavePaperQty
			 */
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					var o = new List<object>();
					for (int i = 0; i < 13; i++) {
						o.Add(ir[i]);
					}
					list.Add(o);
				}
				ir.Close();
			}


			return list;			
		}
	}
}
