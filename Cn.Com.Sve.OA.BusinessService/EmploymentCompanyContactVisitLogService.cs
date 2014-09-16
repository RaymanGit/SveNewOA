using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface IEmploymentCompanyContactVisitLogService {
		IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyId(int companyId);
	}
	public partial class EmploymentCompanyContactVisitLogService : IEmploymentCompanyContactVisitLogService {
		public IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyId(int companyId) {
			return this.Repository.FindByCompanyId(companyId);
		}

	}
}
