using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISmallInfoSourceService {
    	IUnitOfWork Db { get; }
    
    	void Add(SmallInfoSource entity);
    	void Update(SmallInfoSource entity);
    	void Save(SmallInfoSource entity);
    	void Delete(SmallInfoSource entity);
    	void DeleteById(int id);
    	List<SmallInfoSource> FindAll();
    	SmallInfoSource FindById(int id);
    	List<SmallInfoSource> FindByName(string name);
    	List<SmallInfoSource> FindByInfoSourceBigId(int infoSourceBigId);
    	PagedModel<SmallInfoSource> FindByCriteria(SmallInfoSourceCriteria c);
    }
}
