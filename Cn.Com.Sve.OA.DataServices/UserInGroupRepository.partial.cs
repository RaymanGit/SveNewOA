using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class UserInGroupRepository : IUserInGroupRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public UserInGroupRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(UserInGroup entity) {
    		this.DbContext.UserInGroups.AddObject(entity);
    	}
    
    	public void Update(UserInGroup entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.UserGroupId = entity.UserGroupId;
    			e.UserId = entity.UserId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.UserInGroups.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(UserInGroup entity) {
    		this.DbContext.UserInGroups.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.UserInGroups.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<UserInGroup> FindAll() {
    		return this.DbContext.UserInGroups.Include("User").Include("UserGroup");
    	}
    	public IEnumerable<UserInGroup> FindAll2() {
    		return this.DbContext.UserInGroups;
    	}
    
    	public UserInGroup FindById(int id) {
    		return this.DbContext.UserInGroups.Include("User").Include("UserGroup").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<UserInGroup> FindByUserGroupId(int userGroupId){
    				return this.DbContext.UserInGroups.Include("User").Include("UserGroup").Where(o => o.UserGroupId.Equals(userGroupId));
    			}
    	public IEnumerable<UserInGroup> FindByUserId(int userId){
    				return this.DbContext.UserInGroups.Include("User").Include("UserGroup").Where(o => o.UserId.Equals(userId));
    			}
    	public IEnumerable<UserInGroup> FindByCriteria(UserInGroupCriteria c) {
    		return this.DbContext.UserInGroups.Include("User").Include("UserGroup").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.UserGroupIdSrh.HasValue || o.UserGroupId.Equals(c.UserGroupIdSrh.Value))
    			&& (!c.UserGroupIdFromSrh.HasValue || o.UserGroupId >= c.UserGroupIdFromSrh.Value)
    			&& (!c.UserGroupIdToSrh.HasValue || o.UserGroupId <= c.UserGroupIdToSrh.Value)
    			&& (!c.UserIdSrh.HasValue || o.UserId.Equals(c.UserIdSrh.Value))
    			&& (!c.UserIdFromSrh.HasValue || o.UserId >= c.UserIdFromSrh.Value)
    			&& (!c.UserIdToSrh.HasValue || o.UserId <= c.UserIdToSrh.Value)
    
    		);
    	}
    
    }
}
