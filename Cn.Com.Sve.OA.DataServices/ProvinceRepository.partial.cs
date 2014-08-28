using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class ProvinceRepository : IProvinceRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public ProvinceRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Province entity) {
    		this.DbContext.Provinces.AddObject(entity);
    	}
    
    	public void Update(Province entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Provinces.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Province entity) {
    		this.DbContext.Provinces.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Provinces.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Province> FindAll() {
    		return this.DbContext.Provinces;
    	}
    	public IEnumerable<Province> FindAll2() {
    		return this.DbContext.Provinces;
    	}
    
    	public Province FindById(int id) {
    		return this.DbContext.Provinces.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Province> FindByName(string name){
    				return this.DbContext.Provinces.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Province> FindByCriteria(ProvinceCriteria c) {
    		return this.DbContext.Provinces.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    
    		);
    	}
    
    }
}
