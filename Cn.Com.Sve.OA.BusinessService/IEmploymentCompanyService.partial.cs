using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IEmploymentCompanyService {
    	IUnitOfWork Db { get; }
    
    	void Add(EmploymentCompany entity);
    	void Update(EmploymentCompany entity);
    	void Save(EmploymentCompany entity);
    	void Delete(EmploymentCompany entity);
    	void DeleteById(int id);
    	List<EmploymentCompany> FindAll();
    	EmploymentCompany FindById(int id);
    	List<EmploymentCompany> FindByName(string name);
    	List<EmploymentCompany> FindByType(string type);
    	List<EmploymentCompany> FindByImportant(string important);
    	List<EmploymentCompany> FindByWebsite(string website);
    	List<EmploymentCompany> FindByTelephone(string telephone);
    	List<EmploymentCompany> FindByFax(string fax);
    	List<EmploymentCompany> FindByAddress(string address);
    	List<EmploymentCompany> FindByCityId(Nullable<int> cityId);
    	List<EmploymentCompany> FindByIntroduction(string introduction);
    	List<EmploymentCompany> FindBySourceType(string sourceType);
    	List<EmploymentCompany> FindByReferer(string referer);
    	List<EmploymentCompany> FindByUserId(Nullable<int> userId);
    	List<EmploymentCompany> FindByEmployedQty(int employedQty);
    	List<EmploymentCompany> FindByOldOaId(string oldOaId);
    	List<EmploymentCompany> FindByTempProvId(string tempProvId);
    	List<EmploymentCompany> FindByTempProvName(string tempProvName);
    	List<EmploymentCompany> FindByTempCityId(string tempCityId);
    	List<EmploymentCompany> FindByTempCityName(string tempCityName);
    	List<EmploymentCompany> FindByAddTime(Nullable<System.DateTime> addTime);
    	PagedModel<EmploymentCompany> FindByCriteria(EmploymentCompanyCriteria c);
    }
}
