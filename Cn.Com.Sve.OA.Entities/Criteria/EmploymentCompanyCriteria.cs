using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
	public partial class EmploymentCompanyCriteria {
		// 省市名称查询条件
		public string Zone { get; set; }
		// 负责人名称查询条件
		public string UserName { get; set; }
	}
}
