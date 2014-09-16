using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IEmploymentCompanyContactVisitLogRepository  : IRepository<EmploymentCompanyContactVisitLog,int> {
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyContactId(int companyContactId);
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByTime(System.DateTime time);
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByVisitorId(int visitorId);
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByType(string type);
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByContent(string content);
    	IEnumerable<EmploymentCompanyContactVisitLog> FindByCriteria(EmploymentCompanyContactVisitLogCriteria c);
    }
}
