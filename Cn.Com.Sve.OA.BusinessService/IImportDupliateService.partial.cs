using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IImportDupliateService {
    	IUnitOfWork Db { get; }
    
    	void Add(ImportDupliate entity);
    	void Update(ImportDupliate entity);
    	void Save(ImportDupliate entity);
    	void Delete(ImportDupliate entity);
    	void DeleteById(int id);
    	List<ImportDupliate> FindAll();
    	ImportDupliate FindById(int id);
    	List<ImportDupliate> FindByImportKey(string importKey);
    	List<ImportDupliate> FindByCustomerId(Nullable<int> customerId);
    	List<ImportDupliate> FindByImportId(Nullable<int> importId);
    	List<ImportDupliate> FindBySchoolName(string schoolName);
    	List<ImportDupliate> FindByName(string name);
    	List<ImportDupliate> FindByTel(string tel);
    	List<ImportDupliate> FindByMobile(string mobile);
    	List<ImportDupliate> FindByScore(Nullable<int> score);
    	List<ImportDupliate> FindByErrorMsg(string errorMsg);
    	PagedModel<ImportDupliate> FindByCriteria(ImportDupliateCriteria c);
    }
}
