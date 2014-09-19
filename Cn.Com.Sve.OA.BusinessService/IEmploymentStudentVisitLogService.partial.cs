using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IEmploymentStudentVisitLogService {
    	IUnitOfWork Db { get; }
    
    	void Add(EmploymentStudentVisitLog entity);
    	void Update(EmploymentStudentVisitLog entity);
    	void Save(EmploymentStudentVisitLog entity);
    	void Delete(EmploymentStudentVisitLog entity);
    	void DeleteById(int id);
    	List<EmploymentStudentVisitLog> FindAll();
    	EmploymentStudentVisitLog FindById(int id);
    	List<EmploymentStudentVisitLog> FindByStudentId(int studentId);
    	List<EmploymentStudentVisitLog> FindByVisitorId(int visitorId);
    	List<EmploymentStudentVisitLog> FindByTime(System.DateTime time);
    	List<EmploymentStudentVisitLog> FindByPosition(string position);
    	List<EmploymentStudentVisitLog> FindByObjective(string objective);
    	List<EmploymentStudentVisitLog> FindByContent(string content);
    	PagedModel<EmploymentStudentVisitLog> FindByCriteria(EmploymentStudentVisitLogCriteria c);
    }
}
