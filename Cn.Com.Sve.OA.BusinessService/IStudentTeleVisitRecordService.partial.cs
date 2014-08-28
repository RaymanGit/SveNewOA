using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IStudentTeleVisitRecordService {
    	IUnitOfWork Db { get; }
    
    	void Add(StudentTeleVisitRecord entity);
    	void Update(StudentTeleVisitRecord entity);
    	void Save(StudentTeleVisitRecord entity);
    	void Delete(StudentTeleVisitRecord entity);
    	void DeleteById(int id);
    	List<StudentTeleVisitRecord> FindAll();
    	StudentTeleVisitRecord FindById(int id);
    	List<StudentTeleVisitRecord> FindByClazzId(int clazzId);
    	List<StudentTeleVisitRecord> FindByStudentId(int studentId);
    	List<StudentTeleVisitRecord> FindByTime(System.DateTime time);
    	List<StudentTeleVisitRecord> FindByVisitorId(int visitorId);
    	List<StudentTeleVisitRecord> FindByInterviewee(string interviewee);
    	List<StudentTeleVisitRecord> FindByPhoneNo(string phoneNo);
    	List<StudentTeleVisitRecord> FindByAdvice(string advice);
    	List<StudentTeleVisitRecord> FindBySummary(string summary);
    	List<StudentTeleVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	List<StudentTeleVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	List<StudentTeleVisitRecord> FindByReviewComment(string reviewComment);
    	PagedModel<StudentTeleVisitRecord> FindByCriteria(StudentTeleVisitRecordCriteria c);
    }
}
