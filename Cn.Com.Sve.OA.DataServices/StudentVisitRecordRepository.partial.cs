using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class StudentVisitRecordRepository : IStudentVisitRecordRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public StudentVisitRecordRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(StudentVisitRecord entity) {
    		this.DbContext.Student_VisitRecord.AddObject(entity);
    	}
    
    	public void Update(StudentVisitRecord entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ClazzId = entity.ClazzId;
    			e.StudentId = entity.StudentId;
    			e.Time = entity.Time;
    			e.VisitorId = entity.VisitorId;
    			e.Goal = entity.Goal;
    			e.Content = entity.Content;
    			e.Question = entity.Question;
    			e.ReviewerId = entity.ReviewerId;
    			e.ReviewTime = entity.ReviewTime;
    			e.ReviewComment = entity.ReviewComment;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Student_VisitRecord.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(StudentVisitRecord entity) {
    		this.DbContext.Student_VisitRecord.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Student_VisitRecord.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<StudentVisitRecord> FindAll() {
    		return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor");
    	}
    	public IEnumerable<StudentVisitRecord> FindAll2() {
    		return this.DbContext.Student_VisitRecord;
    	}
    
    	public StudentVisitRecord FindById(int id) {
    		return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<StudentVisitRecord> FindByClazzId(int clazzId){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ClazzId.Equals(clazzId));
    			}
    	public IEnumerable<StudentVisitRecord> FindByStudentId(int studentId){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.StudentId.Equals(studentId));
    			}
    	public IEnumerable<StudentVisitRecord> FindByTime(System.DateTime time){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Time.Equals(time));
    			}
    	public IEnumerable<StudentVisitRecord> FindByVisitorId(int visitorId){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.VisitorId.Equals(visitorId));
    			}
    	public IEnumerable<StudentVisitRecord> FindByGoal(string goal){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Goal.Equals(goal));
    			}
    	public IEnumerable<StudentVisitRecord> FindByContent(string content){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Content.Equals(content));
    			}
    	public IEnumerable<StudentVisitRecord> FindByQuestion(string question){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.Question.Equals(question));
    			}
    	public IEnumerable<StudentVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewerId.Value.Equals(reviewerId.Value));
    			}
    	public IEnumerable<StudentVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewTime.Value.Equals(reviewTime.Value));
    			}
    	public IEnumerable<StudentVisitRecord> FindByReviewComment(string reviewComment){
    				return this.DbContext.Student_VisitRecord.Include("Clazz").Include("Student").Include("Reviewer").Include("Visitor").Where(o => o.ReviewComment.Equals(reviewComment));
    			}
    	public IEnumerable<StudentVisitRecord> FindByCriteria(StudentVisitRecordCriteria c) {
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
