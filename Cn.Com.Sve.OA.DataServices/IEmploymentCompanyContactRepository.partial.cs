using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IEmploymentCompanyContactRepository  : IRepository<EmploymentCompanyContact,int> {
    	IEnumerable<EmploymentCompanyContact> FindByCompanyId(int companyId);
    	IEnumerable<EmploymentCompanyContact> FindByName(string name);
    	IEnumerable<EmploymentCompanyContact> FindByMobile(string mobile);
    	IEnumerable<EmploymentCompanyContact> FindByPosition(string position);
    	IEnumerable<EmploymentCompanyContact> FindByTelephone(string telephone);
    	IEnumerable<EmploymentCompanyContact> FindByQQ(string qQ);
    	IEnumerable<EmploymentCompanyContact> FindByEmail(string email);
    	IEnumerable<EmploymentCompanyContact> FindByIntroduction(string introduction);
    	IEnumerable<EmploymentCompanyContact> FindByOldOaId(string oldOaId);
    	IEnumerable<EmploymentCompanyContact> FindByOldOaCompanyId(string oldOaCompanyId);
    	IEnumerable<EmploymentCompanyContact> FindByCriteria(EmploymentCompanyContactCriteria c);
    }
}
