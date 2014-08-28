using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class TelSalesSummary {
		public int SalesTeamId { get; set; }
		public String SalesTeamName { get; set; }
		public int SalesmanId { get; set; }
		public String SalesmanName { get; set; }
		public int Total { get; set; }
		public int N { get; set; }
		public int CustomerQty { get; set; }
		public int TelQty { get; set; }
		public int DropInQty { get; set; }
		public int SignUpQty { get; set; }
		public int DinWeiQty { get; set; }
		public string DropInRate { get; set; }
		public string SignUpRate { get; set; }

		public List<TelSalesSummary> children { get; set; }

		public bool isextend = false;
	}
}
