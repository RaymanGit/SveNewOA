using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface ITelSaleLogService {
		List<TelSalesSummary> GetTelSalesSummaryReport(DateTime? startDate, DateTime? endDate);
		List<TelSalesSummaryBySchool> GetTelSalesSummaryReportBySchool(DateTime? startDate, DateTime? endDate);
	}
	public partial class TelSaleLogService : ITelSaleLogService {
		public List<TelSalesSummary> GetTelSalesSummaryReport(DateTime? startDate, DateTime? endDate) {
			if (!startDate.HasValue) {
				startDate = new DateTime(DateTime.Today.Year, 6, 1);
			}
			if (!endDate.HasValue) {
				endDate = new DateTime(DateTime.Today.Year, 9, 10);
			}
			return this.Repository.GetTelSalesSummaryReport(startDate.Value, endDate.Value);
		}
		public List<TelSalesSummaryBySchool> GetTelSalesSummaryReportBySchool(DateTime? startDate, DateTime? endDate) {
			if (!startDate.HasValue) {
				startDate = new DateTime(DateTime.Today.Year, 6, 1);
			}
			if (!endDate.HasValue) {
				endDate = new DateTime(DateTime.Today.Year, 9, 10);
			}
			return this.Repository.GetTelSalesSummaryReportBySchool(startDate.Value, endDate.Value);
		}
	}
}
