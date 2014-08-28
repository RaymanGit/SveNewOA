using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISalesTeamService {
    	IUnitOfWork Db { get; }
    
    	void Add(SalesTeam entity);
    	void Update(SalesTeam entity);
    	void Save(SalesTeam entity);
    	void Delete(SalesTeam entity);
    	void DeleteById(int id);
    	List<SalesTeam> FindAll();
    	SalesTeam FindById(int id);
    	List<SalesTeam> FindByName(string name);
    	PagedModel<SalesTeam> FindByCriteria(SalesTeamCriteria c);
    }
}
