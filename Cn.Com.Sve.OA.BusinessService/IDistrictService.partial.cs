using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IDistrictService {
    	IUnitOfWork Db { get; }
    
    	void Add(District entity);
    	void Update(District entity);
    	void Save(District entity);
    	void Delete(District entity);
    	void DeleteById(int id);
    	List<District> FindAll();
    	District FindById(int id);
    	List<District> FindByName(string name);
    	List<District> FindByCityId(int cityId);
    	List<District> FindByPhonePrefix(string phonePrefix);
    	List<District> FindByPostcode(string postcode);
    	PagedModel<District> FindByCriteria(DistrictCriteria c);
    }
}
