using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface IQualificationStudentService {
		List<QualificationStudent> Search(QualificationStudentCriteria c);
		List<QualificationSummaryReportItem> GetSummaryReport();
		List<QualificationSumBySchoolReportItem> SumBySchool(int year);
		List<QualificationSumBySchoolReportItem> SumByConsultant(int year);
		List<QualificationSumBySchoolReportItem> SumByReferer(int year, string consultant);
		List<List<object>> SumByStatus();
	}
	public partial class QualificationStudentService : IQualificationStudentService {
		public List<QualificationStudent> Search(QualificationStudentCriteria c) {
			return this.Repository.Search(c);
		}
		public List<QualificationSummaryReportItem> GetSummaryReport() {
			return this.Repository.GetSummaryReport();
		}
		public List<QualificationSumBySchoolReportItem> SumBySchool(int year) {
			return this.Repository.SumBySchool(year);
		}
		public List<QualificationSumBySchoolReportItem> SumByConsultant(int year) {
			return this.Repository.SumByConsultant(year);
		}
		public List<QualificationSumBySchoolReportItem> SumByReferer(int year, string consultant) {
			return this.Repository.SumByReferer(year, consultant);
		}
		public List<List<object>> SumByStatus() {
			return this.Repository.SumByStatus();
		}
	}
}
