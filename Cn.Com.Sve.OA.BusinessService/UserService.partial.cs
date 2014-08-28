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
    public partial class UserService : IUserService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IUserRepository Repository { get; private set; }
    	public UserService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new UserRepository(this.Db);
    	}
    	public UserService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new UserRepository(this.Db);
    	}
    	
    	
    	public void Add(User entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(User entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(User entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(User entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<User> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public User FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<User> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<User> FindByPassword(string password){
    		return this.Repository.FindByPassword(password).ToList();
    	}
    	public List<User> FindByStatus(string status){
    		return this.Repository.FindByStatus(status).ToList();
    	}
    	public List<User> FindByLastLoginTime(Nullable<System.DateTime> lastLoginTime){
    		return this.Repository.FindByLastLoginTime(lastLoginTime).ToList();
    	}
    	public List<User> FindByLastLoginIP(string lastLoginIP){
    		return this.Repository.FindByLastLoginIP(lastLoginIP).ToList();
    	}
    	public List<User> FindByDefaultUrl(string defaultUrl){
    		return this.Repository.FindByDefaultUrl(defaultUrl).ToList();
    	}
    	public PagedModel<User> FindByCriteria(UserCriteria c) {
    		PagedModel<User> m = new PagedModel<User>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("password")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Password);
    			}else{
    				r = r.OrderByDescending(o=>o.Password);
    			}
    		}
    		if(c.sortname.ToLower().Equals("status")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Status);
    			}else{
    				r = r.OrderByDescending(o=>o.Status);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lastlogintime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LastLoginTime);
    			}else{
    				r = r.OrderByDescending(o=>o.LastLoginTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lastloginip")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LastLoginIP);
    			}else{
    				r = r.OrderByDescending(o=>o.LastLoginIP);
    			}
    		}
    		if(c.sortname.ToLower().Equals("defaulturl")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DefaultUrl);
    			}else{
    				r = r.OrderByDescending(o=>o.DefaultUrl);
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
