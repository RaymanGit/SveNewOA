using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISchoolAdService {
    	IUnitOfWork Db { get; }
    
    	void Add(SchoolAd entity);
    	void Update(SchoolAd entity);
    	void Save(SchoolAd entity);
    	void Delete(SchoolAd entity);
    	void DeleteById(int id);
    	List<SchoolAd> FindAll();
    	SchoolAd FindById(int id);
    	List<SchoolAd> FindBySchoolId(int schoolId);
    	List<SchoolAd> FindByYear(int year);
    	List<SchoolAd> FindByHighClassQty(Nullable<int> highClassQty);
    	List<SchoolAd> FindByHighStudentQty(Nullable<int> highStudentQty);
    	List<SchoolAd> FindByLowClassQty(Nullable<int> lowClassQty);
    	List<SchoolAd> FindByLowStudentQty(Nullable<int> lowStudentQty);
    	List<SchoolAd> FindByDaoJiShiPai(Nullable<int> daoJiShiPai);
    	List<SchoolAd> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu);
    	List<SchoolAd> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu);
    	List<SchoolAd> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu);
    	List<SchoolAd> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu);
    	List<SchoolAd> FindByBuTiao(Nullable<int> buTiao);
    	List<SchoolAd> FindByTaiLi(Nullable<int> taiLi);
    	List<SchoolAd> FindByGuaLi(Nullable<int> guaLi);
    	PagedModel<SchoolAd> FindByCriteria(SchoolAdCriteria c);
    }
}
