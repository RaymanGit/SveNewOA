using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IStudentTeleVisitRecordRepository  : IRepository<StudentTeleVisitRecord,int> {
    	IEnumerable<StudentTeleVisitRecord> FindByClazzId(int clazzId);
    	IEnumerable<StudentTeleVisitRecord> FindByStudentId(int studentId);
    	IEnumerable<StudentTeleVisitRecord> FindByTime(System.DateTime time);
    	IEnumerable<StudentTeleVisitRecord> FindByVisitorId(int visitorId);
    	IEnumerable<StudentTeleVisitRecord> FindByInterviewee(string interviewee);
    	IEnumerable<StudentTeleVisitRecord> FindByPhoneNo(string phoneNo);
    	IEnumerable<StudentTeleVisitRecord> FindByAdvice(string advice);
    	IEnumerable<StudentTeleVisitRecord> FindBySummary(string summary);
    	IEnumerable<StudentTeleVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	IEnumerable<StudentTeleVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	IEnumerable<StudentTeleVisitRecord> FindByReviewComment(string reviewComment);
    	IEnumerable<StudentTeleVisitRecord> FindByCriteria(StudentTeleVisitRecordCriteria c);
    }
}
