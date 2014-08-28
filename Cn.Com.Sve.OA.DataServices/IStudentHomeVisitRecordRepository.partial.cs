using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IStudentHomeVisitRecordRepository  : IRepository<StudentHomeVisitRecord,int> {
    	IEnumerable<StudentHomeVisitRecord> FindByClazzId(int clazzId);
    	IEnumerable<StudentHomeVisitRecord> FindByStudentId(int studentId);
    	IEnumerable<StudentHomeVisitRecord> FindByTime(System.DateTime time);
    	IEnumerable<StudentHomeVisitRecord> FindByVisitType(string visitType);
    	IEnumerable<StudentHomeVisitRecord> FindByBeginTime(string beginTime);
    	IEnumerable<StudentHomeVisitRecord> FindByEndTime(string endTime);
    	IEnumerable<StudentHomeVisitRecord> FindByGiveContactCard(string giveContactCard);
    	IEnumerable<StudentHomeVisitRecord> FindByVisitees(string visitees);
    	IEnumerable<StudentHomeVisitRecord> FindByPhoneNo(string phoneNo);
    	IEnumerable<StudentHomeVisitRecord> FindByVisitors(string visitors);
    	IEnumerable<StudentHomeVisitRecord> FindByAdvice(string advice);
    	IEnumerable<StudentHomeVisitRecord> FindBySummary(string summary);
    	IEnumerable<StudentHomeVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	IEnumerable<StudentHomeVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	IEnumerable<StudentHomeVisitRecord> FindByReviewComment(string reviewComment);
    	IEnumerable<StudentHomeVisitRecord> FindByInputUserId(int inputUserId);
    	IEnumerable<StudentHomeVisitRecord> FindByCriteria(StudentHomeVisitRecordCriteria c);
    }
}
