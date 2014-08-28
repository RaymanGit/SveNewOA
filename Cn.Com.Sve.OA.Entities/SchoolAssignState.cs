using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class SchoolAssignState {
		public int SchoolId { get; set; }
		public string SchoolName { get; set; }
		public int? SalesTeamId { get; set; }
		public string SalesTeamName { get; set; }
		public int? SalesmanId { get; set; }
		public string SalesmanName { get; set; }

		public int Qty { get; set; }
		public List<SchoolAssignState> children { get; set; }

	}
}
