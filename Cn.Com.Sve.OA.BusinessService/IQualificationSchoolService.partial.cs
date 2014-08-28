using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IQualificationSchoolService {
    	IUnitOfWork Db { get; }
    
    	void Add(QualificationSchool entity);
    	void Update(QualificationSchool entity);
    	void Save(QualificationSchool entity);
    	void Delete(QualificationSchool entity);
    	void DeleteById(int id);
    	List<QualificationSchool> FindAll();
    	QualificationSchool FindById(int id);
    	List<QualificationSchool> FindByName(string name);
    	PagedModel<QualificationSchool> FindByCriteria(QualificationSchoolCriteria c);
    }
}
