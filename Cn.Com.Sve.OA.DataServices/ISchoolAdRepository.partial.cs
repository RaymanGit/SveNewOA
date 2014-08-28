using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISchoolAdRepository  : IRepository<SchoolAd,int> {
    	IEnumerable<SchoolAd> FindBySchoolId(int schoolId);
    	IEnumerable<SchoolAd> FindByYear(int year);
    	IEnumerable<SchoolAd> FindByHighClassQty(Nullable<int> highClassQty);
    	IEnumerable<SchoolAd> FindByHighStudentQty(Nullable<int> highStudentQty);
    	IEnumerable<SchoolAd> FindByLowClassQty(Nullable<int> lowClassQty);
    	IEnumerable<SchoolAd> FindByLowStudentQty(Nullable<int> lowStudentQty);
    	IEnumerable<SchoolAd> FindByDaoJiShiPai(Nullable<int> daoJiShiPai);
    	IEnumerable<SchoolAd> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu);
    	IEnumerable<SchoolAd> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu);
    	IEnumerable<SchoolAd> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu);
    	IEnumerable<SchoolAd> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu);
    	IEnumerable<SchoolAd> FindByBuTiao(Nullable<int> buTiao);
    	IEnumerable<SchoolAd> FindByTaiLi(Nullable<int> taiLi);
    	IEnumerable<SchoolAd> FindByGuaLi(Nullable<int> guaLi);
    	IEnumerable<SchoolAd> FindByCriteria(SchoolAdCriteria c);
    }
}
