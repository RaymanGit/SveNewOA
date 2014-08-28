using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class QualificationUnrestrictedUserRepository : IQualificationUnrestrictedUserRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public QualificationUnrestrictedUserRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(QualificationUnrestrictedUser entity) {
    		this.DbContext.QualificationUnrestrictedUsers.AddObject(entity);
    	}
    
    	public void Update(QualificationUnrestrictedUser entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.UserName = entity.UserName;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.QualificationUnrestrictedUsers.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(QualificationUnrestrictedUser entity) {
    		this.DbContext.QualificationUnrestrictedUsers.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.QualificationUnrestrictedUsers.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<QualificationUnrestrictedUser> FindAll() {
    		return this.DbContext.QualificationUnrestrictedUsers;
    	}
    	public IEnumerable<QualificationUnrestrictedUser> FindAll2() {
    		return this.DbContext.QualificationUnrestrictedUsers;
    	}
    
    	public QualificationUnrestrictedUser FindById(int id) {
    		return this.DbContext.QualificationUnrestrictedUsers.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<QualificationUnrestrictedUser> FindByUserName(string userName){
    				return this.DbContext.QualificationUnrestrictedUsers.Where(o => o.UserName.Equals(userName));
    			}
    	public IEnumerable<QualificationUnrestrictedUser> FindByCriteria(QualificationUnrestrictedUserCriteria c) {
    		return this.DbContext.QualificationUnrestrictedUsers.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.UserNameSrh) || o.UserName.Contains(c.UserNameSrh))
    
    		);
    	}
    
    }
}
