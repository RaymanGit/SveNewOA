using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities.Criteria {
	public partial class CustomerCriteria {
		public bool? IsTodaySrh { get; set; }
		public string SchoolNameSrh { get; set; }
		public string SalesmanNameSrh { get; set; }

		public DateTime? ChangeStatusTimeStartSrh { get; set; }
		public DateTime? ChangeStatusTimeEndSrh { get; set; }

		public bool? HasTelSaleLogs { get; set; }

		public bool? NoTelSalesSrh { get; set; }

		public string SourceTypeSrh { get; set; }
		public string InClazzNameSrh { get; set; }
		//public int? pageSize { get; set; }
	}
}
