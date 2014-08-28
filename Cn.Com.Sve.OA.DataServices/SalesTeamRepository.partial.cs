using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SalesTeamRepository : ISalesTeamRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SalesTeamRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(SalesTeam entity) {
    		this.DbContext.SalesTeams.AddObject(entity);
    	}
    
    	public void Update(SalesTeam entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.SalesTeams.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(SalesTeam entity) {
    		this.DbContext.SalesTeams.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.SalesTeams.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<SalesTeam> FindAll() {
    		return this.DbContext.SalesTeams;
    	}
    	public IEnumerable<SalesTeam> FindAll2() {
    		return this.DbContext.SalesTeams;
    	}
    
    	public SalesTeam FindById(int id) {
    		return this.DbContext.SalesTeams.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<SalesTeam> FindByName(string name){
    				return this.DbContext.SalesTeams.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<SalesTeam> FindByCriteria(SalesTeamCriteria c) {
    		return this.DbContext.SalesTeams.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    
    		);
    	}
    
    }
}
