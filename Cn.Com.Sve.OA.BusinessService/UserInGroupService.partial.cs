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
    public partial class UserInGroupService : IUserInGroupService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IUserInGroupRepository Repository { get; private set; }
    	public UserInGroupService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new UserInGroupRepository(this.Db);
    	}
    	public UserInGroupService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new UserInGroupRepository(this.Db);
    	}
    	
    	
    	public void Add(UserInGroup entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(UserInGroup entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(UserInGroup entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(UserInGroup entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<UserInGroup> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public UserInGroup FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<UserInGroup> FindByUserGroupId(int userGroupId){
    		return this.Repository.FindByUserGroupId(userGroupId).ToList();
    	}
    	public List<UserInGroup> FindByUserId(int userId){
    		return this.Repository.FindByUserId(userId).ToList();
    	}
    	public PagedModel<UserInGroup> FindByCriteria(UserInGroupCriteria c) {
    		PagedModel<UserInGroup> m = new PagedModel<UserInGroup>();
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
    		if(c.sortname.ToLower().Equals("userid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UserId);
    			}else{
    				r = r.OrderByDescending(o=>o.UserId);
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
