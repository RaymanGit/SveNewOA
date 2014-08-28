using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class StudentHomeVisitRecordRepository : IStudentHomeVisitRecordRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public StudentHomeVisitRecordRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(StudentHomeVisitRecord entity) {
    		this.DbContext.Student_HomeVisitRecord.AddObject(entity);
    	}
    
    	public void Update(StudentHomeVisitRecord entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ClazzId = entity.ClazzId;
    			e.StudentId = entity.StudentId;
    			e.Time = entity.Time;
    			e.VisitType = entity.VisitType;
    			e.BeginTime = entity.BeginTime;
    			e.EndTime = entity.EndTime;
    			e.GiveContactCard = entity.GiveContactCard;
    			e.Visitees = entity.Visitees;
    			e.PhoneNo = entity.PhoneNo;
    			e.Visitors = entity.Visitors;
    			e.Advice = entity.Advice;
    			e.Summary = entity.Summary;
    			e.ReviewerId = entity.ReviewerId;
    			e.ReviewTime = entity.ReviewTime;
    			e.ReviewComment = entity.ReviewComment;
    			e.InputUserId = entity.InputUserId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Student_HomeVisitRecord.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(StudentHomeVisitRecord entity) {
    		this.DbContext.Student_HomeVisitRecord.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Student_HomeVisitRecord.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<StudentHomeVisitRecord> FindAll() {
    		return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser");
    	}
    	public IEnumerable<StudentHomeVisitRecord> FindAll2() {
    		return this.DbContext.Student_HomeVisitRecord;
    	}
    
    	public StudentHomeVisitRecord FindById(int id) {
    		return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<StudentHomeVisitRecord> FindByClazzId(int clazzId){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.ClazzId.Equals(clazzId));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByStudentId(int studentId){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.StudentId.Equals(studentId));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByTime(System.DateTime time){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.Time.Equals(time));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByVisitType(string visitType){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.VisitType.Equals(visitType));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByBeginTime(string beginTime){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.BeginTime.Equals(beginTime));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByEndTime(string endTime){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.EndTime.Equals(endTime));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByGiveContactCard(string giveContactCard){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.GiveContactCard.Equals(giveContactCard));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByVisitees(string visitees){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.Visitees.Equals(visitees));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByPhoneNo(string phoneNo){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.PhoneNo.Equals(phoneNo));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByVisitors(string visitors){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.Visitors.Equals(visitors));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByAdvice(string advice){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.Advice.Equals(advice));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindBySummary(string summary){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.Summary.Equals(summary));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.ReviewerId.Value.Equals(reviewerId.Value));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.ReviewTime.Value.Equals(reviewTime.Value));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByReviewComment(string reviewComment){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.ReviewComment.Equals(reviewComment));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByInputUserId(int inputUserId){
    				return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => o.InputUserId.Equals(inputUserId));
    			}
    	public IEnumerable<StudentHomeVisitRecord> FindByCriteria(StudentHomeVisitRecordCriteria c) {
    		return this.DbContext.Student_HomeVisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("InputUser").Where(o => 
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
    			&& (!c.ReviewerIdSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value.Equals(c.ReviewerIdSrh.Value)))
    			&& (!c.ReviewerIdFromSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value >= c.ReviewerIdFromSrh.Value))
    			&& (!c.ReviewerIdToSrh.HasValue || (o.ReviewerId.HasValue 			&& o.ReviewerId.Value <= c.ReviewerIdToSrh.Value))
    			&& (!c.ReviewTimeSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value.Equals(c.ReviewTimeSrh.Value)))
    			&& (!c.ReviewTimeFromSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value >= c.ReviewTimeFromSrh.Value))
    			&& (!c.ReviewTimeToSrh.HasValue || (o.ReviewTime.HasValue 			&& o.ReviewTime.Value <= c.ReviewTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.ReviewCommentSrh) || o.ReviewComment.Contains(c.ReviewCommentSrh))
    			&& (!c.InputUserIdSrh.HasValue || o.InputUserId.Equals(c.InputUserIdSrh.Value))
    			&& (!c.InputUserIdFromSrh.HasValue || o.InputUserId >= c.InputUserIdFromSrh.Value)
    			&& (!c.InputUserIdToSrh.HasValue || o.InputUserId <= c.InputUserIdToSrh.Value)
    
    		);
    	}
    
    }
}
