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
    public partial class EmploymentStudentVisitLogService : IEmploymentStudentVisitLogService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IEmploymentStudentVisitLogRepository Repository { get; private set; }
    	public EmploymentStudentVisitLogService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new EmploymentStudentVisitLogRepository(this.Db);
    	}
    	public EmploymentStudentVisitLogService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new EmploymentStudentVisitLogRepository(this.Db);
    	}
    	
    	
    	public void Add(EmploymentStudentVisitLog entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(EmploymentStudentVisitLog entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(EmploymentStudentVisitLog entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(EmploymentStudentVisitLog entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<EmploymentStudentVisitLog> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public EmploymentStudentVisitLog FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<EmploymentStudentVisitLog> FindByStudentId(int studentId){
    		return this.Repository.FindByStudentId(studentId).ToList();
    	}
    	public List<EmploymentStudentVisitLog> FindByVisitorId(int visitorId){
    		return this.Repository.FindByVisitorId(visitorId).ToList();
    	}
    	public List<EmploymentStudentVisitLog> FindByTime(System.DateTime time){
    		return this.Repository.FindByTime(time).ToList();
    	}
    	public List<EmploymentStudentVisitLog> FindByPosition(string position){
    		return this.Repository.FindByPosition(position).ToList();
    	}
    	public List<EmploymentStudentVisitLog> FindByObjective(string objective){
    		return this.Repository.FindByObjective(objective).ToList();
    	}
    	public List<EmploymentStudentVisitLog> FindByContent(string content){
    		return this.Repository.FindByContent(content).ToList();
    	}
    	public PagedModel<EmploymentStudentVisitLog> FindByCriteria(EmploymentStudentVisitLogCriteria c) {
    		PagedModel<EmploymentStudentVisitLog> m = new PagedModel<EmploymentStudentVisitLog>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentId);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("visitorid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.VisitorId);
    			}else{
    				r = r.OrderByDescending(o=>o.VisitorId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("time")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Time);
    			}else{
    				r = r.OrderByDescending(o=>o.Time);
    			}
    		}
    		if(c.sortname.ToLower().Equals("position")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Position);
    			}else{
    				r = r.OrderByDescending(o=>o.Position);
    			}
    		}
    		if(c.sortname.ToLower().Equals("objective")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Objective);
    			}else{
    				r = r.OrderByDescending(o=>o.Objective);
    			}
    		}
    		if(c.sortname.ToLower().Equals("content")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Content);
    			}else{
    				r = r.OrderByDescending(o=>o.Content);
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
