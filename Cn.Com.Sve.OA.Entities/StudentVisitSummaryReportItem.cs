using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class StudentVisitSummaryReportItem {
		public int ClazzId { get; set; }
		public string ClazzName { get; set; }
		public int TeleQty { get; set; }
		public int VisitQty { get; set; }
		public int VisitQty2 { get; set; }
		public int VisitQty3 { get; set; }
		public int HomeQty { get; set; }
		public int ReviewTeleQty { get; set; }
		public int ReviewVisitQty { get; set; }
		public int ReviewHomeQty { get; set; }

		public string TeacherName { get; set; }
		public string MasterName { get; set; }

		public int StudentId { get; set; }
		public string StudentName { get; set; }
	}
}
