using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IImportDupliateRepository  : IRepository<ImportDupliate,int> {
    	IEnumerable<ImportDupliate> FindByImportKey(string importKey);
    	IEnumerable<ImportDupliate> FindByCustomerId(Nullable<int> customerId);
    	IEnumerable<ImportDupliate> FindByImportId(Nullable<int> importId);
    	IEnumerable<ImportDupliate> FindBySchoolName(string schoolName);
    	IEnumerable<ImportDupliate> FindByName(string name);
    	IEnumerable<ImportDupliate> FindByTel(string tel);
    	IEnumerable<ImportDupliate> FindByMobile(string mobile);
    	IEnumerable<ImportDupliate> FindByScore(Nullable<int> score);
    	IEnumerable<ImportDupliate> FindByErrorMsg(string errorMsg);
    	IEnumerable<ImportDupliate> FindByCriteria(ImportDupliateCriteria c);
    }
}
