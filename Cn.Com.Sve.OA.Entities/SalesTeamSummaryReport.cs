using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class SalesTeamSummaryReport {
		public int M { get; set; }
		public int SalesTeamId { get; set; }
		public String SalesTeamName { get; set; }
		public int SalesmanId { get; set; }
		public String SalesmanName { get; set; }
		public int SchoolQty { get; set; }
		public int TelDropIn { get; set; }
		public int NonTelDropIn { get; set; }
		public int TotalDropIn { get; set; }
		public int TelSignUp { get; set; }
		public int NonTelSignUp { get; set; }
		public int TotalSignUp { get; set; }
		public int DinWei { get; set; }
		public int Total { get; set; }
		public int N { get; set; }
		public int DistrictId { get; set; }
		public string DistrictName { get; set; }
		public int SchoolId { get; set; }
		public string SchoolName { get; set; }
		public string EduLevel { get; set; }
		public int TelQty { get; set; }

		public List<SalesTeamSummaryReport> children { get; set; }

	}
}
