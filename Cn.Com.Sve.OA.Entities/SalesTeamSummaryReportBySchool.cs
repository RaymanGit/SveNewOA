using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class SalesTeamSummaryReportBySchool {
		public int DistrictId { get; set; }
		public String DistrictFullName { get; set; }
		public int SchoolId { get; set; }
		public String SchoolName { get; set; }
		public int TelDropIn { get; set; }
		public int NonTelDropIn { get; set; }
		public int TotalDropIn { get; set; }
		public int TelSignUp { get; set; }
		public int NonTelSignUp { get; set; }
		public int TotalSignUp { get; set; }
		public int DinWei { get; set; }
		public int Total { get; set; }
		public int N { get; set; }

		public List<SalesTeamSummaryReportBySchool> children { get; set; }
	}
}
