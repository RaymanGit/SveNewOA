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
    public partial class EmploymentCompanyContactVisitLogService : IEmploymentCompanyContactVisitLogService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IEmploymentCompanyContactVisitLogRepository Repository { get; private set; }
    	public EmploymentCompanyContactVisitLogService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new EmploymentCompanyContactVisitLogRepository(this.Db);
    	}
    	public EmploymentCompanyContactVisitLogService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new EmploymentCompanyContactVisitLogRepository(this.Db);
    	}
    	
    	
    	public void Add(EmploymentCompanyContactVisitLog entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(EmploymentCompanyContactVisitLog entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(EmploymentCompanyContactVisitLog entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(EmploymentCompanyContactVisitLog entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<EmploymentCompanyContactVisitLog> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public EmploymentCompanyContactVisitLog FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<EmploymentCompanyContactVisitLog> FindByCompanyContactId(int companyContactId){
    		return this.Repository.FindByCompanyContactId(companyContactId).ToList();
    	}
    	public List<EmploymentCompanyContactVisitLog> FindByTime(System.DateTime time){
    		return this.Repository.FindByTime(time).ToList();
    	}
    	public List<EmploymentCompanyContactVisitLog> FindByVisitorId(int visitorId){
    		return this.Repository.FindByVisitorId(visitorId).ToList();
    	}
    	public List<EmploymentCompanyContactVisitLog> FindByType(string type){
    		return this.Repository.FindByType(type).ToList();
    	}
    	public List<EmploymentCompanyContactVisitLog> FindByContent(string content){
    		return this.Repository.FindByContent(content).ToList();
    	}
    	public PagedModel<EmploymentCompanyContactVisitLog> FindByCriteria(EmploymentCompanyContactVisitLogCriteria c) {
    		PagedModel<EmploymentCompanyContactVisitLog> m = new PagedModel<EmploymentCompanyContactVisitLog>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("companycontactid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CompanyContactId);
    			}else{
    				r = r.OrderByDescending(o=>o.CompanyContactId);
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
    		if(c.sortname.ToLower().Equals("type")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Type);
    			}else{
    				r = r.OrderByDescending(o=>o.Type);
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
