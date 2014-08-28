using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class StudentTeleVisitRecordRepository : IStudentTeleVisitRecordRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public StudentTeleVisitRecordRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(StudentTeleVisitRecord entity) {
    		this.DbContext.Student_TeleVisitRecord.AddObject(entity);
    	}
    
    	public void Update(StudentTeleVisitRecord entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ClazzId = entity.ClazzId;
    			e.StudentId = entity.StudentId;
    			e.Time = entity.Time;
    			e.VisitorId = entity.VisitorId;
    			e.Interviewee = entity.Interviewee;
    			e.PhoneNo = entity.PhoneNo;
    			e.Advice = entity.Advice;
    			e.Summary = entity.Summary;
    			e.ReviewerId = entity.ReviewerId;
    			e.ReviewTime = entity.ReviewTime;
    			e.ReviewComment = entity.ReviewComment;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Student_TeleVisitRecord.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(StudentTeleVisitRecord entity) {
    		this.DbContext.Student_TeleVisitRecord.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Student_TeleVisitRecord.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<StudentTeleVisitRecord> FindAll() {
    		return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor");
    	}
    	public IEnumerable<StudentTeleVisitRecord> FindAll2() {
    		return this.DbContext.Student_TeleVisitRecord;
    	}
    
    	public StudentTeleVisitRecord FindById(int id) {
    		return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<StudentTeleVisitRecord> FindByClazzId(int clazzId){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ClazzId.Equals(clazzId));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByStudentId(int studentId){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.StudentId.Equals(studentId));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByTime(System.DateTime time){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Time.Equals(time));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByVisitorId(int visitorId){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.VisitorId.Equals(visitorId));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByInterviewee(string interviewee){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Interviewee.Equals(interviewee));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByPhoneNo(string phoneNo){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.PhoneNo.Equals(phoneNo));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByAdvice(string advice){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Advice.Equals(advice));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindBySummary(string summary){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Summary.Equals(summary));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewerId.Value.Equals(reviewerId.Value));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewTime.Value.Equals(reviewTime.Value));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByReviewComment(string reviewComment){
    				return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewComment.Equals(reviewComment));
    			}
    	public IEnumerable<StudentTeleVisitRecord> FindByCriteria(StudentTeleVisitRecordCriteria c) {
    		return this.DbContext.Student_TeleVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => 
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
    			&& (String.IsNullOrEmpty(c.IntervieweeSrh) || o.Interviewee.Contains(c.IntervieweeSrh))
    			&& (String.IsNullOrEmpty(c.PhoneNoSrh) || o.PhoneNo.Contains(c.PhoneNoSrh))
    			&& (String.IsNullOrEmpty(c.AdviceSrh) || o.Advice.Contains(c.AdviceSrh))
    			&& (String.IsNullOrEmpty(c.SummarySrh) || o.Summary.Contains(c.SummarySrh))
    			&& (!c.ReviewerIdSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value.Equals(c.ReviewerIdSrh.Value)))
    			&& (!c.ReviewerIdFromSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value >= c.ReviewerIdFromSrh.Value))
    			&& (!c.ReviewerIdToSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value <= c.ReviewerIdToSrh.Value))
    			&& (!c.ReviewTimeSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value.Equals(c.ReviewTimeSrh.Value)))
    			&& (!c.ReviewTimeFromSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value >= c.ReviewTimeFromSrh.Value))
    			&& (!c.ReviewTimeToSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value <= c.ReviewTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.ReviewCommentSrh) || o.ReviewComment.Contains(c.ReviewCommentSrh))
    
    		);
    	}
    
    }
}
