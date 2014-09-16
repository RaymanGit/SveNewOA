using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IEmploymentCompanyContactVisitLogRepository {
		IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyId(int companyId);
	}
	public partial class EmploymentCompanyContactVisitLogRepository : IEmploymentCompanyContactVisitLogRepository {
		public IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyId(int companyId) {
			return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.CompanyContact.CompanyId.Equals(companyId));
		}

	}
}
