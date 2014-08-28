using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IStudentVisitRecordRepository : IRepository<StudentVisitRecord, int> {
		IEnumerable<StudentVisitRecord> Search(StudentVisitRecordCriteria c);
	}

	public partial class StudentVisitRecordRepository : IStudentVisitRecordRepository {
		public IEnumerable<StudentVisitRecord> Search(StudentVisitRecordCriteria c) {
			return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o =>
				(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
				&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
				&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
				&& (!c.ClazzIdSrh.HasValue || o.ClazzId.Equals(c.ClazzIdSrh.Value))
				&& (!c.ClazzIdFromSrh.HasValue || o.ClazzId >= c.ClazzIdFromSrh.Value)
				&& (!c.ClazzIdToSrh.HasValue || o.ClazzId <= c.ClazzIdToSrh.Value)
				&& (!c.StudentIdSrh.HasValue || o.StudentId.Equals(c.StudentIdSrh.Value))
				&& (!c.StudentIdFromSrh.HasValue || o.StudentId >= c.StudentIdFromSrh.Value)
				&& (!c.StudentIdToSrh.HasValue || o.StudentId <= c.StudentIdToSrh.Value)
				&& (!c.TimeSrh.HasValue || o.Time.Equals(c.TimeSrh.Value))
				&& (!c.VisitorIdSrh.HasValue || o.VisitorId.Equals(c.VisitorIdSrh.Value))
				&& (!c.VisitorIdFromSrh.HasValue || o.VisitorId >= c.VisitorIdFromSrh.Value)
				&& (!c.VisitorIdToSrh.HasValue || o.VisitorId <= c.VisitorIdToSrh.Value)
				&& (String.IsNullOrEmpty(c.GoalSrh) || o.Goal.Contains(c.GoalSrh))
				&& (String.IsNullOrEmpty(c.ContentSrh) || o.Content.Contains(c.ContentSrh))
				&& (String.IsNullOrEmpty(c.QuestionSrh) || o.Question.Contains(c.QuestionSrh))
				&& (!c.ReviewerIdSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value.Equals(c.ReviewerIdSrh.Value)))
				&& (!c.ReviewerIdFromSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value >= c.ReviewerIdFromSrh.Value))
				&& (!c.ReviewerIdToSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value <= c.ReviewerIdToSrh.Value))
				&& (!c.ReviewTimeSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value.Equals(c.ReviewTimeSrh.Value)))
				&& (!c.ReviewTimeFromSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value >= c.ReviewTimeFromSrh.Value))
				&& (!c.ReviewTimeToSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value <= c.ReviewTimeToSrh.Value))
				&& (String.IsNullOrEmpty(c.ReviewCommentSrh) || o.ReviewComment.Contains(c.ReviewCommentSrh))
				&& (String.IsNullOrEmpty(c.ClazzNameSrh) || o.Clazz.Name.Contains(c.ClazzNameSrh))
				&& (String.IsNullOrEmpty(c.StudentNameSrh) || o.Student.Name.Contains(c.StudentNameSrh))
				&& (!c.TimeFromSrh.HasValue || o.Time >= c.TimeFromSrh.Value)
				&& (!c.TimeToSrh.HasValue || o.Time <= c.TimeToSrh.Value)

			);
		}
	}
}
