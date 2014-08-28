using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IStudentHomeVisitRecordRepository : IRepository<StudentHomeVisitRecord, int> {
		IEnumerable<StudentHomeVisitRecord> Search(StudentHomeVisitRecordCriteria c);
	}

	public partial class StudentHomeVisitRecordRepository : IStudentHomeVisitRecordRepository {
		public IEnumerable<StudentHomeVisitRecord> Search(StudentHomeVisitRecordCriteria c) {
			return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Where(o =>
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
				&& (String.IsNullOrEmpty(c.VisitTypeSrh) || o.VisitType.Contains(c.VisitTypeSrh))
				&& (String.IsNullOrEmpty(c.BeginTimeSrh) || o.BeginTime.Contains(c.BeginTimeSrh))
				&& (String.IsNullOrEmpty(c.EndTimeSrh) || o.EndTime.Contains(c.EndTimeSrh))
				&& (String.IsNullOrEmpty(c.GiveContactCardSrh) || o.GiveContactCard.Contains(c.GiveContactCardSrh))
				&& (String.IsNullOrEmpty(c.VisiteesSrh) || o.Visitees.Contains(c.VisiteesSrh))
				&& (String.IsNullOrEmpty(c.PhoneNoSrh) || o.PhoneNo.Contains(c.PhoneNoSrh))
				&& (String.IsNullOrEmpty(c.VisitorsSrh) || o.Visitors.Contains(c.VisitorsSrh))
				&& (String.IsNullOrEmpty(c.AdviceSrh) || o.Advice.Contains(c.AdviceSrh))
				&& (String.IsNullOrEmpty(c.SummarySrh) || o.Summary.Contains(c.SummarySrh))
				&& (!c.ReviewerIdSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value.Equals(c.ReviewerIdSrh.Value)))
				&& (!c.ReviewerIdFromSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value >= c.ReviewerIdFromSrh.Value))
				&& (!c.ReviewerIdToSrh.HasValue || (o.ReviewerId.HasValue && o.ReviewerId.Value <= c.ReviewerIdToSrh.Value))
				&& (!c.ReviewTimeSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value.Equals(c.ReviewTimeSrh.Value)))
				&& (!c.ReviewTimeFromSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value >= c.ReviewTimeFromSrh.Value))
				&& (!c.ReviewTimeToSrh.HasValue || (o.ReviewTime.HasValue && o.ReviewTime.Value <= c.ReviewTimeToSrh.Value))
				&& (String.IsNullOrEmpty(c.ReviewCommentSrh) || o.ReviewComment.Contains(c.ReviewCommentSrh))
				&& (String.IsNullOrEmpty(c.ClazzNameSrh) || o.Clazz.Name.Contains(c.ClazzNameSrh))
				&& (String.IsNullOrEmpty(c.StudentNameSrh) || o.Student.Name.Contains(c.StudentNameSrh))
				&& (!c.TimeFromSrh.HasValue || (o.Time >= c.TimeFromSrh.Value))
				&& (!c.TimeToSrh.HasValue || (o.Time <= c.TimeToSrh.Value))


			);
		}
	}
}
