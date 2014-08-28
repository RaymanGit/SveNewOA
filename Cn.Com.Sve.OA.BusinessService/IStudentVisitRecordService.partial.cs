using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IStudentVisitRecordService {
    	IUnitOfWork Db { get; }
    
    	void Add(StudentVisitRecord entity);
    	void Update(StudentVisitRecord entity);
    	void Save(StudentVisitRecord entity);
    	void Delete(StudentVisitRecord entity);
    	void DeleteById(int id);
    	List<StudentVisitRecord> FindAll();
    	StudentVisitRecord FindById(int id);
    	List<StudentVisitRecord> FindByClazzId(int clazzId);
    	List<StudentVisitRecord> FindByStudentId(int studentId);
    	List<StudentVisitRecord> FindByTime(System.DateTime time);
    	List<StudentVisitRecord> FindByVisitorId(int visitorId);
    	List<StudentVisitRecord> FindByGoal(string goal);
    	List<StudentVisitRecord> FindByContent(string content);
    	List<StudentVisitRecord> FindByQuestion(string question);
    	List<StudentVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	List<StudentVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	List<StudentVisitRecord> FindByReviewComment(string reviewComment);
    	PagedModel<StudentVisitRecord> FindByCriteria(StudentVisitRecordCriteria c);
    }
}
