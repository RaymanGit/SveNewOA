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
    public partial class StudentVisitRecordService : IStudentVisitRecordService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IStudentVisitRecordRepository Repository { get; private set; }
    	public StudentVisitRecordService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new StudentVisitRecordRepository(this.Db);
    	}
    	public StudentVisitRecordService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new StudentVisitRecordRepository(this.Db);
    	}
    	
    	
    	public void Add(StudentVisitRecord entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(StudentVisitRecord entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(StudentVisitRecord entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(StudentVisitRecord entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<StudentVisitRecord> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public StudentVisitRecord FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<StudentVisitRecord> FindByClazzId(int clazzId){
    		return this.Repository.FindByClazzId(clazzId).ToList();
    	}
    	public List<StudentVisitRecord> FindByStudentId(int studentId){
    		return this.Repository.FindByStudentId(studentId).ToList();
    	}
    	public List<StudentVisitRecord> FindByTime(System.DateTime time){
    		return this.Repository.FindByTime(time).ToList();
    	}
    	public List<StudentVisitRecord> FindByVisitorId(int visitorId){
    		return this.Repository.FindByVisitorId(visitorId).ToList();
    	}
    	public List<StudentVisitRecord> FindByGoal(string goal){
    		return this.Repository.FindByGoal(goal).ToList();
    	}
    	public List<StudentVisitRecord> FindByContent(string content){
    		return this.Repository.FindByContent(content).ToList();
    	}
    	public List<StudentVisitRecord> FindByQuestion(string question){
    		return this.Repository.FindByQuestion(question).ToList();
    	}
    	public List<StudentVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    		return this.Repository.FindByReviewerId(reviewerId).ToList();
    	}
    	public List<StudentVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    		return this.Repository.FindByReviewTime(reviewTime).ToList();
    	}
    	public List<StudentVisitRecord> FindByReviewComment(string reviewComment){
    		return this.Repository.FindByReviewComment(reviewComment).ToList();
    	}
    	public PagedModel<StudentVisitRecord> FindByCriteria(StudentVisitRecordCriteria c) {
    		PagedModel<StudentVisitRecord> m = new PagedModel<StudentVisitRecord>();
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
    		if(c.sortname.ToLower().Equals("goal")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Goal);
    			}else{
    				r = r.OrderByDescending(o=>o.Goal);
    			}
    		}
    		if(c.sortname.ToLower().Equals("content")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Content);
    			}else{
    				r = r.OrderByDescending(o=>o.Content);
    			}
    		}
    		if(c.sortname.ToLower().Equals("question")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Question);
    			}else{
    				r = r.OrderByDescending(o=>o.Question);
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
