using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IStudentHomeVisitRecordService {
    	IUnitOfWork Db { get; }
    
    	void Add(StudentHomeVisitRecord entity);
    	void Update(StudentHomeVisitRecord entity);
    	void Save(StudentHomeVisitRecord entity);
    	void Delete(StudentHomeVisitRecord entity);
    	void DeleteById(int id);
    	List<StudentHomeVisitRecord> FindAll();
    	StudentHomeVisitRecord FindById(int id);
    	List<StudentHomeVisitRecord> FindByClazzId(int clazzId);
    	List<StudentHomeVisitRecord> FindByStudentId(int studentId);
    	List<StudentHomeVisitRecord> FindByTime(System.DateTime time);
    	List<StudentHomeVisitRecord> FindByVisitType(string visitType);
    	List<StudentHomeVisitRecord> FindByBeginTime(string beginTime);
    	List<StudentHomeVisitRecord> FindByEndTime(string endTime);
    	List<StudentHomeVisitRecord> FindByGiveContactCard(string giveContactCard);
    	List<StudentHomeVisitRecord> FindByVisitees(string visitees);
    	List<StudentHomeVisitRecord> FindByPhoneNo(string phoneNo);
    	List<StudentHomeVisitRecord> FindByVisitors(string visitors);
    	List<StudentHomeVisitRecord> FindByAdvice(string advice);
    	List<StudentHomeVisitRecord> FindBySummary(string summary);
    	List<StudentHomeVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	List<StudentHomeVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	List<StudentHomeVisitRecord> FindByReviewComment(string reviewComment);
    	List<StudentHomeVisitRecord> FindByInputUserId(int inputUserId);
    	PagedModel<StudentHomeVisitRecord> FindByCriteria(StudentHomeVisitRecordCriteria c);
    }
}
