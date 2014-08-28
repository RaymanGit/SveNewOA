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
    public partial class UserGroupModulePermissionService : IUserGroupModulePermissionService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IUserGroupModulePermissionRepository Repository { get; private set; }
    	public UserGroupModulePermissionService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new UserGroupModulePermissionRepository(this.Db);
    	}
    	public UserGroupModulePermissionService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new UserGroupModulePermissionRepository(this.Db);
    	}
    	
    	
    	public void Add(UserGroupModulePermission entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(UserGroupModulePermission entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(UserGroupModulePermission entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(UserGroupModulePermission entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<UserGroupModulePermission> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public UserGroupModulePermission FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<UserGroupModulePermission> FindByUserGroupId(int userGroupId){
    		return this.Repository.FindByUserGroupId(userGroupId).ToList();
    	}
    	public List<UserGroupModulePermission> FindByModuleId(int moduleId){
    		return this.Repository.FindByModuleId(moduleId).ToList();
    	}
    	public PagedModel<UserGroupModulePermission> FindByCriteria(UserGroupModulePermissionCriteria c) {
    		PagedModel<UserGroupModulePermission> m = new PagedModel<UserGroupModulePermission>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("usergroupid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UserGroupId);
    			}else{
    				r = r.OrderByDescending(o=>o.UserGroupId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("moduleid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ModuleId);
    			}else{
    				r = r.OrderByDescending(o=>o.ModuleId);
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
