using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities.Criteria {
	public partial class StudentVisitSummaryReportCriteria {
		public int? page { get; set; }
		public int? pagesize { get; set; }
		public string sortname { get; set; }
		public string sortorder { get; set; }

		public string ClazzNameSrh { get; set; }
		public string VisitorNameSrh { get; set; }
		public DateTime? BeginTime { get; set; }
		public DateTime? EndTime { get; set; }
	}
}
