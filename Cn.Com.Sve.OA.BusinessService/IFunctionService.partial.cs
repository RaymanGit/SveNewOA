using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IFunctionService {
    	IUnitOfWork Db { get; }
    
    	void Add(Function entity);
    	void Update(Function entity);
    	void Save(Function entity);
    	void Delete(Function entity);
    	void DeleteById(int id);
    	List<Function> FindAll();
    	Function FindById(int id);
    	List<Function> FindByModuleId(int moduleId);
    	List<Function> FindByCode(string code);
    	List<Function> FindByName(string name);
    	List<Function> FindByIcon(string icon);
    	List<Function> FindByUrl(string url);
    	List<Function> FindByParentFunctionId(Nullable<int> parentFunctionId);
    	List<Function> FindBySeq(Nullable<int> seq);
    	PagedModel<Function> FindByCriteria(FunctionCriteria c);
    }
}
