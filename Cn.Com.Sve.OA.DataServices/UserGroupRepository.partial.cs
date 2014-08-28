using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class UserGroupRepository : IUserGroupRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public UserGroupRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(UserGroup entity) {
    		this.DbContext.UserGroups.AddObject(entity);
    	}
    
    	public void Update(UserGroup entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.UserGroups.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(UserGroup entity) {
    		this.DbContext.UserGroups.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.UserGroups.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<UserGroup> FindAll() {
    		return this.DbContext.UserGroups;
    	}
    	public IEnumerable<UserGroup> FindAll2() {
    		return this.DbContext.UserGroups;
    	}
    
    	public UserGroup FindById(int id) {
    		return this.DbContext.UserGroups.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<UserGroup> FindByName(string name){
    				return this.DbContext.UserGroups.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<UserGroup> FindByCriteria(UserGroupCriteria c) {
    		return this.DbContext.UserGroups.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    
    		);
    	}
    
    }
}
