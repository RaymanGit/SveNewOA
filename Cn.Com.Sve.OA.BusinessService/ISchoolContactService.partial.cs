using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISchoolContactService {
    	IUnitOfWork Db { get; }
    
    	void Add(SchoolContact entity);
    	void Update(SchoolContact entity);
    	void Save(SchoolContact entity);
    	void Delete(SchoolContact entity);
    	void DeleteById(int id);
    	List<SchoolContact> FindAll();
    	SchoolContact FindById(int id);
    	List<SchoolContact> FindBySchoolId(int schoolId);
    	List<SchoolContact> FindByYear(Nullable<int> year);
    	List<SchoolContact> FindByTitle(string title);
    	List<SchoolContact> FindByName(string name);
    	List<SchoolContact> FindByTelephone(string telephone);
    	List<SchoolContact> FindByMobile(string mobile);
    	List<SchoolContact> FindByQQ(string qQ);
    	List<SchoolContact> FindByAddress(string address);
    	List<SchoolContact> FindByRemark(string remark);
    	List<SchoolContact> FindByTopFlag(Nullable<int> topFlag);
    	List<SchoolContact> FindByOldOaId(Nullable<int> oldOaId);
    	PagedModel<SchoolContact> FindByCriteria(SchoolContactCriteria c);
    }
}
