using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ICustomerService {
    	IUnitOfWork Db { get; }
    
    	void Add(Customer entity);
    	void Update(Customer entity);
    	void Save(Customer entity);
    	void Delete(Customer entity);
    	void DeleteById(int id);
    	List<Customer> FindAll();
    	Customer FindById(int id);
    	List<Customer> FindByName(string name);
    	List<Customer> FindBySchoolId(Nullable<int> schoolId);
    	List<Customer> FindByMarketYear(int marketYear);
    	List<Customer> FindByTelephone(string telephone);
    	List<Customer> FindByMobile(string mobile);
    	List<Customer> FindByGender(string gender);
    	List<Customer> FindByQQ(string qQ);
    	List<Customer> FindByEmail(string email);
    	List<Customer> FindByEduLevel(string eduLevel);
    	List<Customer> FindByIsGaoKao(bool isGaoKao);
    	List<Customer> FindByGaoKaoScore(Nullable<int> gaoKaoScore);
    	List<Customer> FindByGaoKaoBatch(string gaoKaoBatch);
    	List<Customer> FindByDistrictId(Nullable<int> districtId);
    	List<Customer> FindByAddress(string address);
    	List<Customer> FindByPostcode(string postcode);
    	List<Customer> FindBySmallInfoSourceId(int smallInfoSourceId);
    	List<Customer> FindByConsultType(string consultType);
    	List<Customer> FindByRemark(string remark);
    	List<Customer> FindByConsultantId1(Nullable<int> consultantId1);
    	List<Customer> FindByConsultantId2(Nullable<int> consultantId2);
    	List<Customer> FindByNetConsultantId(Nullable<int> netConsultantId);
    	List<Customer> FindByCreateTeacherId(Nullable<int> createTeacherId);
    	List<Customer> FindByConsultTime(Nullable<System.DateTime> consultTime);
    	List<Customer> FindBySalesTeamId(Nullable<int> salesTeamId);
    	List<Customer> FindBySalesmanId(Nullable<int> salesmanId);
    	List<Customer> FindByIsImport(bool isImport);
    	List<Customer> FindByTeleSalesTimes(int teleSalesTimes);
    	List<Customer> FindByNextTeleSalesTime(Nullable<System.DateTime> nextTeleSalesTime);
    	List<Customer> FindByAppointmentTime(Nullable<System.DateTime> appointmentTime);
    	List<Customer> FindByDropInTime(Nullable<System.DateTime> dropInTime);
    	List<Customer> FindByDinWeiTime(Nullable<System.DateTime> dinWeiTime);
    	List<Customer> FindBySignUpTime(Nullable<System.DateTime> signUpTime);
    	List<Customer> FindByIsDinWei(bool isDinWei);
    	List<Customer> FindByIsClosed(bool isClosed);
    	List<Customer> FindByLastSalesTime(Nullable<System.DateTime> lastSalesTime);
    	List<Customer> FindByImportant(bool important);
    	List<Customer> FindByConsultantRemark(string consultantRemark);
    	List<Customer> FindByKeywords(string keywords);
    	List<Customer> FindByClazz(string clazz);
    	List<Customer> FindByIsLeaderFollow(bool isLeaderFollow);
    	List<Customer> FindByStatus(string status);
    	List<Customer> FindByLastSaleLog(string lastSaleLog);
    	List<Customer> FindByIsDorm(Nullable<bool> isDorm);
    	List<Customer> FindByInClazzId(Nullable<int> inClazzId);
    	List<Customer> FindByIsPay(bool isPay);
    	List<Customer> FindByPayTime(Nullable<System.DateTime> payTime);
    	List<Customer> FindByIsRefund(bool isRefund);
    	List<Customer> FindByRefundTime(Nullable<System.DateTime> refundTime);
    	List<Customer> FindByIsDropIn(bool isDropIn);
    	List<Customer> FindByIsSignUp(bool isSignUp);
    	PagedModel<Customer> FindByCriteria(CustomerCriteria c);
    }
}
