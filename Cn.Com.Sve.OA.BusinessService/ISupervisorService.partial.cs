using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISupervisorService {
    	IUnitOfWork Db { get; }
    
    	void Add(Supervisor entity);
    	void Update(Supervisor entity);
    	void Save(Supervisor entity);
    	void Delete(Supervisor entity);
    	void DeleteById(int id);
    	List<Supervisor> FindAll();
    	Supervisor FindById(int id);
    	List<Supervisor> FindByUserId(int userId);
    	List<Supervisor> FindByType(string type);
    	PagedModel<Supervisor> FindByCriteria(SupervisorCriteria c);
    }
}
