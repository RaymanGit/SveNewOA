using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class TelSalesSummaryBySchool {
		public int DistrictId { get; set; }
		public String DistrictName { get; set; }
		public int SchoolId { get; set; }
		public String SchoolName { get; set; }
		public int Total { get; set; }
		public int N { get; set; }
		public int CustomerQty { get; set; }
		public int TelQty { get; set; }
		public int DropInQty { get; set; }
		public int SignUpQty { get; set; }
		public int DinWeiQty { get; set; }
		public string DropInRate { get; set; }
		public string SignUpRate { get; set; }

		public List<TelSalesSummaryBySchool> children { get; set; }

		public bool isextend = false;
	}
}
