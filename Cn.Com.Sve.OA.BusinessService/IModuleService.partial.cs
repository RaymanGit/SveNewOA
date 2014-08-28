using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IModuleService {
    	IUnitOfWork Db { get; }
    
    	void Add(Module entity);
    	void Update(Module entity);
    	void Save(Module entity);
    	void Delete(Module entity);
    	void DeleteById(int id);
    	List<Module> FindAll();
    	Module FindById(int id);
    	List<Module> FindByCode(string code);
    	List<Module> FindByName(string name);
    	List<Module> FindByIcon(string icon);
    	PagedModel<Module> FindByCriteria(ModuleCriteria c);
    }
}
