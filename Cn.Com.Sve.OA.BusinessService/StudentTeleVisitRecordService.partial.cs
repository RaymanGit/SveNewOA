using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial class StudentTeleVisitRecordService : IStudentTeleVisitRecordService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IStudentTeleVisitRecordRepository Repository { get; private set; }
    	public StudentTeleVisitRecordService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new StudentTeleVisitRecordRepository(this.Db);
    	}
    	public StudentTeleVisitRecordService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new StudentTeleVisitRecordRepository(this.Db);
    	}
    	
    	
    	public void Add(StudentTeleVisitRecord entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(StudentTeleVisitRecord entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(StudentTeleVisitRecord entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(StudentTeleVisitRecord entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<StudentTeleVisitRecord> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public StudentTeleVisitRecord FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<StudentTeleVisitRecord> FindByClazzId(int clazzId){
    		return this.Repository.FindByClazzId(clazzId).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByStudentId(int studentId){
    		return this.Repository.FindByStudentId(studentId).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByTime(System.DateTime time){
    		return this.Repository.FindByTime(time).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByVisitorId(int visitorId){
    		return this.Repository.FindByVisitorId(visitorId).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByInterviewee(string interviewee){
    		return this.Repository.FindByInterviewee(interviewee).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByPhoneNo(string phoneNo){
    		return this.Repository.FindByPhoneNo(phoneNo).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByAdvice(string advice){
    		return this.Repository.FindByAdvice(advice).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindBySummary(string summary){
    		return this.Repository.FindBySummary(summary).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    		return this.Repository.FindByReviewerId(reviewerId).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    		return this.Repository.FindByReviewTime(reviewTime).ToList();
    	}
    	public List<StudentTeleVisitRecord> FindByReviewComment(string reviewComment){
    		return this.Repository.FindByReviewComment(reviewComment).ToList();
    	}
    	public PagedModel<StudentTeleVisitRecord> FindByCriteria(StudentTeleVisitRecordCriteria c) {
    		PagedModel<StudentTeleVisitRecord> m = new PagedModel<StudentTeleVisitRecord>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("clazzid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ClazzId);
    			}else{
    				r = r.OrderByDescending(o=>o.ClazzId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentId);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("time")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Time);
    			}else{
    				r = r.OrderByDescending(o=>o.Time);
    			}
    		}
    		if(c.sortname.ToLower().Equals("visitorid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.VisitorId);
    			}else{
    				r = r.OrderByDescending(o=>o.VisitorId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("interviewee")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Interviewee);
    			}else{
    				r = r.OrderByDescending(o=>o.Interviewee);
    			}
    		}
    		if(c.sortname.ToLower().Equals("phoneno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PhoneNo);
    			}else{
    				r = r.OrderByDescending(o=>o.PhoneNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("advice")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Advice);
    			}else{
    				r = r.OrderByDescending(o=>o.Advice);
    			}
    		}
    		if(c.sortname.ToLower().Equals("summary")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Summary);
    			}else{
    				r = r.OrderByDescending(o=>o.Summary);
    			}
    		}
    		if(c.sortname.ToLower().Equals("reviewerid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ReviewerId);
    			}else{
    				r = r.OrderByDescending(o=>o.ReviewerId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("reviewtime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ReviewTime);
    			}else{
    				r = r.OrderByDescending(o=>o.ReviewTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("reviewcomment")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ReviewComment);
    			}else{
    				r = r.OrderByDescending(o=>o.ReviewComment);
    			}
    		}
    		
    		}
    		
    		m.RecordCount = r.Count();
    		if (c.pagesize.HasValue) {
    			int page = c.page ?? 1;
    			int pageCount = m.RecordCount / c.pagesize.Value;
    			if (m.RecordCount % c.pagesize.Value > 0) {
    				pageCount++;
    			}
    			int skip = (page - 1) * c.pagesize.Value;
    			if (skip > 0) {
    				r = r.Skip(skip);
    			}
    			r = r.Take(c.pagesize.Value);
    		}
    		
    		m.Data = r.ToList();
    		return m;
    	}
    }
}
