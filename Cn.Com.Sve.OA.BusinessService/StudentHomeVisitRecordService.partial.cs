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
    public partial class StudentHomeVisitRecordService : IStudentHomeVisitRecordService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IStudentHomeVisitRecordRepository Repository { get; private set; }
    	public StudentHomeVisitRecordService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new StudentHomeVisitRecordRepository(this.Db);
    	}
    	public StudentHomeVisitRecordService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new StudentHomeVisitRecordRepository(this.Db);
    	}
    	
    	
    	public void Add(StudentHomeVisitRecord entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(StudentHomeVisitRecord entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(StudentHomeVisitRecord entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(StudentHomeVisitRecord entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<StudentHomeVisitRecord> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public StudentHomeVisitRecord FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<StudentHomeVisitRecord> FindByClazzId(int clazzId){
    		return this.Repository.FindByClazzId(clazzId).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByStudentId(int studentId){
    		return this.Repository.FindByStudentId(studentId).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByTime(System.DateTime time){
    		return this.Repository.FindByTime(time).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByVisitType(string visitType){
    		return this.Repository.FindByVisitType(visitType).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByBeginTime(string beginTime){
    		return this.Repository.FindByBeginTime(beginTime).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByEndTime(string endTime){
    		return this.Repository.FindByEndTime(endTime).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByGiveContactCard(string giveContactCard){
    		return this.Repository.FindByGiveContactCard(giveContactCard).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByVisitees(string visitees){
    		return this.Repository.FindByVisitees(visitees).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByPhoneNo(string phoneNo){
    		return this.Repository.FindByPhoneNo(phoneNo).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByVisitors(string visitors){
    		return this.Repository.FindByVisitors(visitors).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByAdvice(string advice){
    		return this.Repository.FindByAdvice(advice).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindBySummary(string summary){
    		return this.Repository.FindBySummary(summary).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByReviewerId(Nullable<int> reviewerId){
    		return this.Repository.FindByReviewerId(reviewerId).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByReviewTime(Nullable<System.DateTime> reviewTime){
    		return this.Repository.FindByReviewTime(reviewTime).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByReviewComment(string reviewComment){
    		return this.Repository.FindByReviewComment(reviewComment).ToList();
    	}
    	public List<StudentHomeVisitRecord> FindByInputUserId(int inputUserId){
    		return this.Repository.FindByInputUserId(inputUserId).ToList();
    	}
    	public PagedModel<StudentHomeVisitRecord> FindByCriteria(StudentHomeVisitRecordCriteria c) {
    		PagedModel<StudentHomeVisitRecord> m = new PagedModel<StudentHomeVisitRecord>();
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
    		if(c.sortname.ToLower().Equals("visittype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.VisitType);
    			}else{
    				r = r.OrderByDescending(o=>o.VisitType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("begintime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.BeginTime);
    			}else{
    				r = r.OrderByDescending(o=>o.BeginTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("endtime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.EndTime);
    			}else{
    				r = r.OrderByDescending(o=>o.EndTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("givecontactcard")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GiveContactCard);
    			}else{
    				r = r.OrderByDescending(o=>o.GiveContactCard);
    			}
    		}
    		if(c.sortname.ToLower().Equals("visitees")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Visitees);
    			}else{
    				r = r.OrderByDescending(o=>o.Visitees);
    			}
    		}
    		if(c.sortname.ToLower().Equals("phoneno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PhoneNo);
    			}else{
    				r = r.OrderByDescending(o=>o.PhoneNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("visitors")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Visitors);
    			}else{
    				r = r.OrderByDescending(o=>o.Visitors);
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
    		if(c.sortname.ToLower().Equals("inputuserid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InputUserId);
    			}else{
    				r = r.OrderByDescending(o=>o.InputUserId);
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
