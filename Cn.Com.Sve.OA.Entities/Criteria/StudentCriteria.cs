using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
	public partial class StudentCriteria {
		public string ClazzNameSrh { get; set; }
		public string AddrZoneSrh { get; set; }
		public string GruduateSchoolNameSrh { get; set; }
		public string SemesterSrh { get; set; }
		public string ContactWay { get; set; }
		// 是否导出
		public bool Export { get; set; }

	}
}
