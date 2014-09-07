using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IEmploymentCompanyContactService {
    	IUnitOfWork Db { get; }
    
    	void Add(EmploymentCompanyContact entity);
    	void Update(EmploymentCompanyContact entity);
    	void Save(EmploymentCompanyContact entity);
    	void Delete(EmploymentCompanyContact entity);
    	void DeleteById(int id);
    	List<EmploymentCompanyContact> FindAll();
    	EmploymentCompanyContact FindById(int id);
    	List<EmploymentCompanyContact> FindByCompanyId(int companyId);
    	List<EmploymentCompanyContact> FindByName(string name);
    	List<EmploymentCompanyContact> FindByMobile(string mobile);
    	List<EmploymentCompanyContact> FindByPosition(string position);
    	List<EmploymentCompanyContact> FindByTelephone(string telephone);
    	List<EmploymentCompanyContact> FindByQQ(string qQ);
    	List<EmploymentCompanyContact> FindByEmail(string email);
    	List<EmploymentCompanyContact> FindByIntroduction(string introduction);
    	List<EmploymentCompanyContact> FindByOldOaId(string oldOaId);
    	List<EmploymentCompanyContact> FindByOldOaCompanyId(string oldOaCompanyId);
    	PagedModel<EmploymentCompanyContact> FindByCriteria(EmploymentCompanyContactCriteria c);
    }
}
