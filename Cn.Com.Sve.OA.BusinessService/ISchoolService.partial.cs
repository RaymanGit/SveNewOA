using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISchoolService {
    	IUnitOfWork Db { get; }
    
    	void Add(School entity);
    	void Update(School entity);
    	void Save(School entity);
    	void Delete(School entity);
    	void DeleteById(int id);
    	List<School> FindAll();
    	School FindById(int id);
    	List<School> FindByName(string name);
    	List<School> FindByDistrictId(Nullable<int> districtId);
    	List<School> FindByIsSold(bool isSold);
    	List<School> FindByType(string type);
    	List<School> FindByLevels(string levels);
    	List<School> FindByDevBy(string devBy);
    	List<School> FindByDevDate(Nullable<System.DateTime> devDate);
    	List<School> FindByImportant(Nullable<bool> important);
    	List<School> FindByEquipments(string equipments);
    	List<School> FindByDaoJiShiPai(Nullable<int> daoJiShiPai);
    	List<School> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu);
    	List<School> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu);
    	List<School> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu);
    	List<School> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu);
    	List<School> FindByBuTiao(Nullable<int> buTiao);
    	List<School> FindByAddress(string address);
    	List<School> FindByHighClassQty(Nullable<int> highClassQty);
    	List<School> FindByHighStudentQty(Nullable<int> highStudentQty);
    	List<School> FindByLowClassQty(Nullable<int> lowClassQty);
    	List<School> FindByLowStudentQty(Nullable<int> lowStudentQty);
    	List<School> FindByRemark(string remark);
    	List<School> FindByOldOaHuWaiId(string oldOaHuWaiId);
    	PagedModel<School> FindByCriteria(SchoolCriteria c);
    }
}
