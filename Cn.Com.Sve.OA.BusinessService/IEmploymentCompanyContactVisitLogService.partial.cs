using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IEmploymentCompanyContactVisitLogService {
    	IUnitOfWork Db { get; }
    
    	void Add(EmploymentCompanyContactVisitLog entity);
    	void Update(EmploymentCompanyContactVisitLog entity);
    	void Save(EmploymentCompanyContactVisitLog entity);
    	void Delete(EmploymentCompanyContactVisitLog entity);
    	void DeleteById(int id);
    	List<EmploymentCompanyContactVisitLog> FindAll();
    	EmploymentCompanyContactVisitLog FindById(int id);
    	List<EmploymentCompanyContactVisitLog> FindByCompanyContactId(int companyContactId);
    	List<EmploymentCompanyContactVisitLog> FindByTime(System.DateTime time);
    	List<EmploymentCompanyContactVisitLog> FindByVisitorId(int visitorId);
    	List<EmploymentCompanyContactVisitLog> FindByType(string type);
    	List<EmploymentCompanyContactVisitLog> FindByContent(string content);
    	PagedModel<EmploymentCompanyContactVisitLog> FindByCriteria(EmploymentCompanyContactVisitLogCriteria c);
    }
}
