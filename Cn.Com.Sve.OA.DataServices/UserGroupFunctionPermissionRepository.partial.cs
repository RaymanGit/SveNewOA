using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class UserGroupFunctionPermissionRepository : IUserGroupFunctionPermissionRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public UserGroupFunctionPermissionRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(UserGroupFunctionPermission entity) {
    		this.DbContext.UserGroupFunctionPermissions.AddObject(entity);
    	}
    
    	public void Update(UserGroupFunctionPermission entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.UserGroupId = entity.UserGroupId;
    			e.FunctionId = entity.FunctionId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.UserGroupFunctionPermissions.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(UserGroupFunctionPermission entity) {
    		this.DbContext.UserGroupFunctionPermissions.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.UserGroupFunctionPermissions.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<UserGroupFunctionPermission> FindAll() {
    		return this.DbContext.UserGroupFunctionPermissions.Include("Function").Include("UserGroup");
    	}
    	public IEnumerable<UserGroupFunctionPermission> FindAll2() {
    		return this.DbContext.UserGroupFunctionPermissions;
    	}
    
    	public UserGroupFunctionPermission FindById(int id) {
    		return this.DbContext.UserGroupFunctionPermissions.Include("Function").Include("UserGroup").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<UserGroupFunctionPermission> FindByUserGroupId(int userGroupId){
    				return this.DbContext.UserGroupFunctionPermissions.Include("Function").Include("UserGroup").Where(o => o.UserGroupId.Equals(userGroupId));
    			}
    	public IEnumerable<UserGroupFunctionPermission> FindByFunctionId(int functionId){
    				return this.DbContext.UserGroupFunctionPermissions.Include("Function").Include("UserGroup").Where(o => o.FunctionId.Equals(functionId));
    			}
    	public IEnumerable<UserGroupFunctionPermission> FindByCriteria(UserGroupFunctionPermissionCriteria c) {
    		return this.DbContext.UserGroupFunctionPermissions.Include("Function").Include("UserGroup").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.UserGroupIdSrh.HasValue || o.UserGroupId.Equals(c.UserGroupIdSrh.Value))
    			&& (!c.UserGroupIdFromSrh.HasValue || o.UserGroupId >= c.UserGroupIdFromSrh.Value)
    			&& (!c.UserGroupIdToSrh.HasValue || o.UserGroupId <= c.UserGroupIdToSrh.Value)
    			&& (!c.FunctionIdSrh.HasValue || o.FunctionId.Equals(c.FunctionIdSrh.Value))
    			&& (!c.FunctionIdFromSrh.HasValue || o.FunctionId >= c.FunctionIdFromSrh.Value)
    			&& (!c.FunctionIdToSrh.HasValue || o.FunctionId <= c.FunctionIdToSrh.Value)
    
    		);
    	}
    
    }
}
