using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class DistrictRepository : IDistrictRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public DistrictRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(District entity) {
    		this.DbContext.Districts.AddObject(entity);
    	}
    
    	public void Update(District entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.CityId = entity.CityId;
    			e.PhonePrefix = entity.PhonePrefix;
    			e.Postcode = entity.Postcode;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Districts.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(District entity) {
    		this.DbContext.Districts.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Districts.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<District> FindAll() {
    		return this.DbContext.Districts.Include("City");
    	}
    	public IEnumerable<District> FindAll2() {
    		return this.DbContext.Districts;
    	}
    
    	public District FindById(int id) {
    		return this.DbContext.Districts.Include("City").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<District> FindByName(string name){
    				return this.DbContext.Districts.Include("City").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<District> FindByCityId(int cityId){
    				return this.DbContext.Districts.Include("City").Where(o => o.CityId.Equals(cityId));
    			}
    	public IEnumerable<District> FindByPhonePrefix(string phonePrefix){
    				return this.DbContext.Districts.Include("City").Where(o => o.PhonePrefix.Equals(phonePrefix));
    			}
    	public IEnumerable<District> FindByPostcode(string postcode){
    				return this.DbContext.Districts.Include("City").Where(o => o.Postcode.Equals(postcode));
    			}
    	public IEnumerable<District> FindByCriteria(DistrictCriteria c) {
    		return this.DbContext.Districts.Include("City").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (!c.CityIdSrh.HasValue || o.CityId.Equals(c.CityIdSrh.Value))
    			&& (!c.CityIdFromSrh.HasValue || o.CityId >= c.CityIdFromSrh.Value)
    			&& (!c.CityIdToSrh.HasValue || o.CityId <= c.CityIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.PhonePrefixSrh) || o.PhonePrefix.Contains(c.PhonePrefixSrh))
    			&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
    
    		);
    	}
    
    }
}
