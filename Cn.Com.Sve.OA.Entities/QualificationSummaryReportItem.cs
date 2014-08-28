using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class QualificationSummaryReportItem {
		public int Year { get; set; }
		public int Qty { get; set; }
	}

	public class QualificationSumBySchoolReportItem {
		public string School { get; set; }
		public string Consultant { get; set; }
		public string Referrer { get; set; }
		public int Qty { get; set; }
	}
}
