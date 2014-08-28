using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class BigInfoSourceRepository : IBigInfoSourceRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public BigInfoSourceRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(BigInfoSource entity) {
    		this.DbContext.BigInfoSources.AddObject(entity);
    	}
    
    	public void Update(BigInfoSource entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.BigInfoSources.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(BigInfoSource entity) {
    		this.DbContext.BigInfoSources.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.BigInfoSources.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<BigInfoSource> FindAll() {
    		return this.DbContext.BigInfoSources;
    	}
    	public IEnumerable<BigInfoSource> FindAll2() {
    		return this.DbContext.BigInfoSources;
    	}
    
    	public BigInfoSource FindById(int id) {
    		return this.DbContext.BigInfoSources.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<BigInfoSource> FindByName(string name){
    				return this.DbContext.BigInfoSources.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<BigInfoSource> FindByCriteria(BigInfoSourceCriteria c) {
    		return this.DbContext.BigInfoSources.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    
    		);
    	}
    
    }
}
