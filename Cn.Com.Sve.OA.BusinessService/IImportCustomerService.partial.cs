using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IImportCustomerService {
    	IUnitOfWork Db { get; }
    
    	void Add(ImportCustomer entity);
    	void Update(ImportCustomer entity);
    	void Save(ImportCustomer entity);
    	void Delete(ImportCustomer entity);
    	void DeleteById(int id);
    	List<ImportCustomer> FindAll();
    	ImportCustomer FindById(int id);
    	List<ImportCustomer> FindByImportKey(string importKey);
    	List<ImportCustomer> FindBySchoolId(Nullable<int> schoolId);
    	List<ImportCustomer> FindBySchoolName(string schoolName);
    	List<ImportCustomer> FindByLevel(string level);
    	List<ImportCustomer> FindByMarketYear(int marketYear);
    	List<ImportCustomer> FindByInfoSource(int infoSource);
    	List<ImportCustomer> FindByName(string name);
    	List<ImportCustomer> FindByGender(string gender);
    	List<ImportCustomer> FindByTel(string tel);
    	List<ImportCustomer> FindByProvinceId(Nullable<int> provinceId);
    	List<ImportCustomer> FindByProvinceName(string provinceName);
    	List<ImportCustomer> FindByCityId(Nullable<int> cityId);
    	List<ImportCustomer> FindByCityName(string cityName);
    	List<ImportCustomer> FindByDistrictId(Nullable<int> districtId);
    	List<ImportCustomer> FindByDistrictName(string districtName);
    	List<ImportCustomer> FindByAddress(string address);
    	List<ImportCustomer> FindByMobile(string mobile);
    	List<ImportCustomer> FindByQQ(string qQ);
    	List<ImportCustomer> FindByClazz(string clazz);
    	List<ImportCustomer> FindByScore(Nullable<int> score);
    	List<ImportCustomer> FindByPostcode(string postcode);
    	List<ImportCustomer> FindByContact(string contact);
    	List<ImportCustomer> FindByImportType(string importType);
    	List<ImportCustomer> FindByIsProcessed(bool isProcessed);
    	List<ImportCustomer> FindByErrorMsg(string errorMsg);
    	PagedModel<ImportCustomer> FindByCriteria(ImportCustomerCriteria c);
    }
}
