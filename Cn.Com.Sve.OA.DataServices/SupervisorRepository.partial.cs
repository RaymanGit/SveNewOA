using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SupervisorRepository : ISupervisorRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SupervisorRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Supervisor entity) {
    		this.DbContext.Supervisors.AddObject(entity);
    	}
    
    	public void Update(Supervisor entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.UserId = entity.UserId;
    			e.Type = entity.Type;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Supervisors.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Supervisor entity) {
    		this.DbContext.Supervisors.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Supervisors.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Supervisor> FindAll() {
    		return this.DbContext.Supervisors.Include("User");
    	}
    	public IEnumerable<Supervisor> FindAll2() {
    		return this.DbContext.Supervisors;
    	}
    
    	public Supervisor FindById(int id) {
    		return this.DbContext.Supervisors.Include("User").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Supervisor> FindByUserId(int userId){
    				return this.DbContext.Supervisors.Include("User").Where(o => o.UserId.Equals(userId));
    			}
    	public IEnumerable<Supervisor> FindByType(string type){
    				return this.DbContext.Supervisors.Include("User").Where(o => o.Type.Equals(type));
    			}
    	public IEnumerable<Supervisor> FindByCriteria(SupervisorCriteria c) {
    		return this.DbContext.Supervisors.Include("User").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.UserIdSrh.HasValue || o.UserId.Equals(c.UserIdSrh.Value))
    			&& (!c.UserIdFromSrh.HasValue || o.UserId >= c.UserIdFromSrh.Value)
    			&& (!c.UserIdToSrh.HasValue || o.UserId <= c.UserIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.TypeSrh) || o.Type.Contains(c.TypeSrh))
    
    		);
    	}
    
    }
}
