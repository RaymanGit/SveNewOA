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
    public partial class QualificationUnrestrictedUserService : IQualificationUnrestrictedUserService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IQualificationUnrestrictedUserRepository Repository { get; private set; }
    	public QualificationUnrestrictedUserService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new QualificationUnrestrictedUserRepository(this.Db);
    	}
    	public QualificationUnrestrictedUserService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new QualificationUnrestrictedUserRepository(this.Db);
    	}
    	
    	
    	public void Add(QualificationUnrestrictedUser entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(QualificationUnrestrictedUser entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(QualificationUnrestrictedUser entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(QualificationUnrestrictedUser entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<QualificationUnrestrictedUser> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public QualificationUnrestrictedUser FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<QualificationUnrestrictedUser> FindByUserName(string userName){
    		return this.Repository.FindByUserName(userName).ToList();
    	}
    	public PagedModel<QualificationUnrestrictedUser> FindByCriteria(QualificationUnrestrictedUserCriteria c) {
    		PagedModel<QualificationUnrestrictedUser> m = new PagedModel<QualificationUnrestrictedUser>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("username")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UserName);
    			}else{
    				r = r.OrderByDescending(o=>o.UserName);
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
