using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IStudentVisitRecordRepository  : IRepository<StudentVisitRecord,int> {
    	IEnumerable<StudentVisitRecord> FindByClazzId(int clazzId);
    	IEnumerable<StudentVisitRecord> FindByStudentId(int studentId);
    	IEnumerable<StudentVisitRecord> FindByTime(System.DateTime time);
    	IEnumerable<StudentVisitRecord> FindByVisitorId(int visitorId);
    	IEnumerable<StudentVisitRecord> FindByGoal(string goal);
    	IEnumerable<StudentVisitRecord> FindByContent(string content);
    	IEnumerable<StudentVisitRecord> FindByQuestion(string question);
    	IEnumerable<StudentVisitRecord> FindByReviewerId(Nullable<int> reviewerId);
    	IEnumerable<StudentVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime);
    	IEnumerable<StudentVisitRecord> FindByReviewComment(string reviewComment);
    	IEnumerable<StudentVisitRecord> FindByCriteria(StudentVisitRecordCriteria c);
    }
}
