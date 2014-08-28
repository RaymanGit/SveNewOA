using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IQualificationUnrestrictedUserService {
    	IUnitOfWork Db { get; }
    
    	void Add(QualificationUnrestrictedUser entity);
    	void Update(QualificationUnrestrictedUser entity);
    	void Save(QualificationUnrestrictedUser entity);
    	void Delete(QualificationUnrestrictedUser entity);
    	void DeleteById(int id);
    	List<QualificationUnrestrictedUser> FindAll();
    	QualificationUnrestrictedUser FindById(int id);
    	List<QualificationUnrestrictedUser> FindByUserName(string userName);
    	PagedModel<QualificationUnrestrictedUser> FindByCriteria(QualificationUnrestrictedUserCriteria c);
    }
}
