using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IEmploymentCompanyRepository  : IRepository<EmploymentCompany,int> {
    	IEnumerable<EmploymentCompany> FindByName(string name);
    	IEnumerable<EmploymentCompany> FindByType(string type);
    	IEnumerable<EmploymentCompany> FindByImportant(string important);
    	IEnumerable<EmploymentCompany> FindByWebsite(string website);
    	IEnumerable<EmploymentCompany> FindByTelephone(string telephone);
    	IEnumerable<EmploymentCompany> FindByFax(string fax);
    	IEnumerable<EmploymentCompany> FindByAddress(string address);
    	IEnumerable<EmploymentCompany> FindByCityId(Nullable<int> cityId);
    	IEnumerable<EmploymentCompany> FindByIntroduction(string introduction);
    	IEnumerable<EmploymentCompany> FindBySourceType(string sourceType);
    	IEnumerable<EmploymentCompany> FindByReferer(string referer);
    	IEnumerable<EmploymentCompany> FindByUserId(Nullable<int> userId);
    	IEnumerable<EmploymentCompany> FindByEmployedQty(int employedQty);
    	IEnumerable<EmploymentCompany> FindByOldOaId(string oldOaId);
    	IEnumerable<EmploymentCompany> FindByTempProvId(string tempProvId);
    	IEnumerable<EmploymentCompany> FindByTempProvName(string tempProvName);
    	IEnumerable<EmploymentCompany> FindByTempCityId(string tempCityId);
    	IEnumerable<EmploymentCompany> FindByTempCityName(string tempCityName);
    	IEnumerable<EmploymentCompany> FindByAddTime(Nullable<System.DateTime> addTime);
    	IEnumerable<EmploymentCompany> FindByCriteria(EmploymentCompanyCriteria c);
    }
}
