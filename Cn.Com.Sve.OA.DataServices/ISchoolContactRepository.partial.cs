using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISchoolContactRepository  : IRepository<SchoolContact,int> {
    	IEnumerable<SchoolContact> FindBySchoolId(int schoolId);
    	IEnumerable<SchoolContact> FindByYear(Nullable<int> year);
    	IEnumerable<SchoolContact> FindByTitle(string title);
    	IEnumerable<SchoolContact> FindByName(string name);
    	IEnumerable<SchoolContact> FindByTelephone(string telephone);
    	IEnumerable<SchoolContact> FindByMobile(string mobile);
    	IEnumerable<SchoolContact> FindByQQ(string qQ);
    	IEnumerable<SchoolContact> FindByAddress(string address);
    	IEnumerable<SchoolContact> FindByRemark(string remark);
    	IEnumerable<SchoolContact> FindByTopFlag(Nullable<int> topFlag);
    	IEnumerable<SchoolContact> FindByOldOaId(Nullable<int> oldOaId);
    	IEnumerable<SchoolContact> FindByCriteria(SchoolContactCriteria c);
    }
}
