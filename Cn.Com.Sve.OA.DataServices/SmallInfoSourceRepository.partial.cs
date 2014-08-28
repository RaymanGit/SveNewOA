using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SmallInfoSourceRepository : ISmallInfoSourceRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SmallInfoSourceRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(SmallInfoSource entity) {
    		this.DbContext.SmallInfoSources.AddObject(entity);
    	}
    
    	public void Update(SmallInfoSource entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.InfoSourceBigId = entity.InfoSourceBigId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.SmallInfoSources.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(SmallInfoSource entity) {
    		this.DbContext.SmallInfoSources.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.SmallInfoSources.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<SmallInfoSource> FindAll() {
    		return this.DbContext.SmallInfoSources.Include("BigInfoSource");
    	}
    	public IEnumerable<SmallInfoSource> FindAll2() {
    		return this.DbContext.SmallInfoSources;
    	}
    
    	public SmallInfoSource FindById(int id) {
    		return this.DbContext.SmallInfoSources.Include("BigInfoSource").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<SmallInfoSource> FindByName(string name){
    				return this.DbContext.SmallInfoSources.Include("BigInfoSource").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<SmallInfoSource> FindByInfoSourceBigId(int infoSourceBigId){
    				return this.DbContext.SmallInfoSources.Include("BigInfoSource").Where(o => o.InfoSourceBigId.Equals(infoSourceBigId));
    			}
    	public IEnumerable<SmallInfoSource> FindByCriteria(SmallInfoSourceCriteria c) {
    		return this.DbContext.SmallInfoSources.Include("BigInfoSource").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (!c.InfoSourceBigIdSrh.HasValue || o.InfoSourceBigId.Equals(c.InfoSourceBigIdSrh.Value))
    			&& (!c.InfoSourceBigIdFromSrh.HasValue || o.InfoSourceBigId >= c.InfoSourceBigIdFromSrh.Value)
    			&& (!c.InfoSourceBigIdToSrh.HasValue || o.InfoSourceBigId <= c.InfoSourceBigIdToSrh.Value)
    
    		);
    	}
    
    }
}
