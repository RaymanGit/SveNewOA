using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class UserGroupModulePermissionRepository : IUserGroupModulePermissionRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public UserGroupModulePermissionRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(UserGroupModulePermission entity) {
    		this.DbContext.UserGroupModulePermissions.AddObject(entity);
    	}
    
    	public void Update(UserGroupModulePermission entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.UserGroupId = entity.UserGroupId;
    			e.ModuleId = entity.ModuleId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.UserGroupModulePermissions.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(UserGroupModulePermission entity) {
    		this.DbContext.UserGroupModulePermissions.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.UserGroupModulePermissions.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<UserGroupModulePermission> FindAll() {
    		return this.DbContext.UserGroupModulePermissions.Include("Module").Include("UserGroup");
    	}
    	public IEnumerable<UserGroupModulePermission> FindAll2() {
    		return this.DbContext.UserGroupModulePermissions;
    	}
    
    	public UserGroupModulePermission FindById(int id) {
    		return this.DbContext.UserGroupModulePermissions.Include("Module").Include("UserGroup").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<UserGroupModulePermission> FindByUserGroupId(int userGroupId){
    				return this.DbContext.UserGroupModulePermissions.Include("Module").Include("UserGroup").Where(o => o.UserGroupId.Equals(userGroupId));
    			}
    	public IEnumerable<UserGroupModulePermission> FindByModuleId(int moduleId){
    				return this.DbContext.UserGroupModulePermissions.Include("Module").Include("UserGroup").Where(o => o.ModuleId.Equals(moduleId));
    			}
    	public IEnumerable<UserGroupModulePermission> FindByCriteria(UserGroupModulePermissionCriteria c) {
    		return this.DbContext.UserGroupModulePermissions.Include("Module").Include("UserGroup").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.UserGroupIdSrh.HasValue || o.UserGroupId.Equals(c.UserGroupIdSrh.Value))
    			&& (!c.UserGroupIdFromSrh.HasValue || o.UserGroupId >= c.UserGroupIdFromSrh.Value)
    			&& (!c.UserGroupIdToSrh.HasValue || o.UserGroupId <= c.UserGroupIdToSrh.Value)
    			&& (!c.ModuleIdSrh.HasValue || o.ModuleId.Equals(c.ModuleIdSrh.Value))
    			&& (!c.ModuleIdFromSrh.HasValue || o.ModuleId >= c.ModuleIdFromSrh.Value)
    			&& (!c.ModuleIdToSrh.HasValue || o.ModuleId <= c.ModuleIdToSrh.Value)
    
    		);
    	}
    
    }
}
