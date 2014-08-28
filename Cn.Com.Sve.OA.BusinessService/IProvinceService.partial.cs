using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IProvinceService {
    	IUnitOfWork Db { get; }
    
    	void Add(Province entity);
    	void Update(Province entity);
    	void Save(Province entity);
    	void Delete(Province entity);
    	void DeleteById(int id);
    	List<Province> FindAll();
    	Province FindById(int id);
    	List<Province> FindByName(string name);
    	PagedModel<Province> FindByCriteria(ProvinceCriteria c);
    }
}
