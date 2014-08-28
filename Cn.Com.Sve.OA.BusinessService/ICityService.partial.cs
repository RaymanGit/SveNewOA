using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ICityService {
    	IUnitOfWork Db { get; }
    
    	void Add(City entity);
    	void Update(City entity);
    	void Save(City entity);
    	void Delete(City entity);
    	void DeleteById(int id);
    	List<City> FindAll();
    	City FindById(int id);
    	List<City> FindByName(string name);
    	List<City> FindByProvinceId(int provinceId);
    	PagedModel<City> FindByCriteria(CityCriteria c);
    }
}
