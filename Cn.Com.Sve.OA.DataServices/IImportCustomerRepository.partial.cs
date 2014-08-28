using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IImportCustomerRepository  : IRepository<ImportCustomer,int> {
    	IEnumerable<ImportCustomer> FindByImportKey(string importKey);
    	IEnumerable<ImportCustomer> FindBySchoolId(Nullable<int> schoolId);
    	IEnumerable<ImportCustomer> FindBySchoolName(string schoolName);
    	IEnumerable<ImportCustomer> FindByLevel(string level);
    	IEnumerable<ImportCustomer> FindByMarketYear(int marketYear);
    	IEnumerable<ImportCustomer> FindByInfoSource(int infoSource);
    	IEnumerable<ImportCustomer> FindByName(string name);
    	IEnumerable<ImportCustomer> FindByGender(string gender);
    	IEnumerable<ImportCustomer> FindByTel(string tel);
    	IEnumerable<ImportCustomer> FindByProvinceId(Nullable<int> provinceId);
    	IEnumerable<ImportCustomer> FindByProvinceName(string provinceName);
    	IEnumerable<ImportCustomer> FindByCityId(Nullable<int> cityId);
    	IEnumerable<ImportCustomer> FindByCityName(string cityName);
    	IEnumerable<ImportCustomer> FindByDistrictId(Nullable<int> districtId);
    	IEnumerable<ImportCustomer> FindByDistrictName(string districtName);
    	IEnumerable<ImportCustomer> FindByAddress(string address);
    	IEnumerable<ImportCustomer> FindByMobile(string mobile);
    	IEnumerable<ImportCustomer> FindByQQ(string qQ);
    	IEnumerable<ImportCustomer> FindByClazz(string clazz);
    	IEnumerable<ImportCustomer> FindByScore(Nullable<int> score);
    	IEnumerable<ImportCustomer> FindByPostcode(string postcode);
    	IEnumerable<ImportCustomer> FindByContact(string contact);
    	IEnumerable<ImportCustomer> FindByImportType(string importType);
    	IEnumerable<ImportCustomer> FindByIsProcessed(bool isProcessed);
    	IEnumerable<ImportCustomer> FindByErrorMsg(string errorMsg);
    	IEnumerable<ImportCustomer> FindByCriteria(ImportCustomerCriteria c);
    }
}
