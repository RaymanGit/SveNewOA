using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class CityRepository : ICityRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public CityRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(City entity) {
    		this.DbContext.Cities.AddObject(entity);
    	}
    
    	public void Update(City entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.ProvinceId = entity.ProvinceId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Cities.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(City entity) {
    		this.DbContext.Cities.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Cities.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<City> FindAll() {
    		return this.DbContext.Cities.Include("Province");
    	}
    	public IEnumerable<City> FindAll2() {
    		return this.DbContext.Cities;
    	}
    
    	public City FindById(int id) {
    		return this.DbContext.Cities.Include("Province").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<City> FindByName(string name){
    				return this.DbContext.Cities.Include("Province").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<City> FindByProvinceId(int provinceId){
    				return this.DbContext.Cities.Include("Province").Where(o => o.ProvinceId.Equals(provinceId));
    			}
    	public IEnumerable<City> FindByCriteria(CityCriteria c) {
    		return this.DbContext.Cities.Include("Province").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (!c.ProvinceIdSrh.HasValue || o.ProvinceId.Equals(c.ProvinceIdSrh.Value))
    			&& (!c.ProvinceIdFromSrh.HasValue || o.ProvinceId >= c.ProvinceIdFromSrh.Value)
    			&& (!c.ProvinceIdToSrh.HasValue || o.ProvinceId <= c.ProvinceIdToSrh.Value)
    
    		);
    	}
    
    }
}
