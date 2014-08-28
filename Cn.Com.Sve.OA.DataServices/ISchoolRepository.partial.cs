using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISchoolRepository  : IRepository<School,int> {
    	IEnumerable<School> FindByName(string name);
    	IEnumerable<School> FindByDistrictId(Nullable<int> districtId);
    	IEnumerable<School> FindByIsSold(bool isSold);
    	IEnumerable<School> FindByType(string type);
    	IEnumerable<School> FindByLevels(string levels);
    	IEnumerable<School> FindByDevBy(string devBy);
    	IEnumerable<School> FindByDevDate(Nullable<System.DateTime> devDate);
    	IEnumerable<School> FindByImportant(Nullable<bool> important);
    	IEnumerable<School> FindByEquipments(string equipments);
    	IEnumerable<School> FindByDaoJiShiPai(Nullable<int> daoJiShiPai);
    	IEnumerable<School> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu);
    	IEnumerable<School> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu);
    	IEnumerable<School> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu);
    	IEnumerable<School> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu);
    	IEnumerable<School> FindByBuTiao(Nullable<int> buTiao);
    	IEnumerable<School> FindByAddress(string address);
    	IEnumerable<School> FindByHighClassQty(Nullable<int> highClassQty);
    	IEnumerable<School> FindByHighStudentQty(Nullable<int> highStudentQty);
    	IEnumerable<School> FindByLowClassQty(Nullable<int> lowClassQty);
    	IEnumerable<School> FindByLowStudentQty(Nullable<int> lowStudentQty);
    	IEnumerable<School> FindByRemark(string remark);
    	IEnumerable<School> FindByOldOaHuWaiId(string oldOaHuWaiId);
    	IEnumerable<School> FindByCriteria(SchoolCriteria c);
    }
}
