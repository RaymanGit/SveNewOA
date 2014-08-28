using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IBigInfoSourceService {
    	IUnitOfWork Db { get; }
    
    	void Add(BigInfoSource entity);
    	void Update(BigInfoSource entity);
    	void Save(BigInfoSource entity);
    	void Delete(BigInfoSource entity);
    	void DeleteById(int id);
    	List<BigInfoSource> FindAll();
    	BigInfoSource FindById(int id);
    	List<BigInfoSource> FindByName(string name);
    	PagedModel<BigInfoSource> FindByCriteria(BigInfoSourceCriteria c);
    }
}
