using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial class CustomerService : ICustomerService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ICustomerRepository Repository { get; private set; }
    	public CustomerService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new CustomerRepository(this.Db);
    	}
    	public CustomerService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new CustomerRepository(this.Db);
    	}
    	
    	
    	public void Add(Customer entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Customer entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Customer entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Customer entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Customer> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Customer FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Customer> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<Customer> FindBySchoolId(Nullable<int> schoolId){
    		return this.Repository.FindBySchoolId(schoolId).ToList();
    	}
    	public List<Customer> FindByMarketYear(int marketYear){
    		return this.Repository.FindByMarketYear(marketYear).ToList();
    	}
    	public List<Customer> FindByTelephone(string telephone){
    		return this.Repository.FindByTelephone(telephone).ToList();
    	}
    	public List<Customer> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<Customer> FindByGender(string gender){
    		return this.Repository.FindByGender(gender).ToList();
    	}
    	public List<Customer> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<Customer> FindByEmail(string email){
    		return this.Repository.FindByEmail(email).ToList();
    	}
    	public List<Customer> FindByEduLevel(string eduLevel){
    		return this.Repository.FindByEduLevel(eduLevel).ToList();
    	}
    	public List<Customer> FindByIsGaoKao(bool isGaoKao){
    		return this.Repository.FindByIsGaoKao(isGaoKao).ToList();
    	}
    	public List<Customer> FindByGaoKaoScore(Nullable<int> gaoKaoScore){
    		return this.Repository.FindByGaoKaoScore(gaoKaoScore).ToList();
    	}
    	public List<Customer> FindByGaoKaoBatch(string gaoKaoBatch){
    		return this.Repository.FindByGaoKaoBatch(gaoKaoBatch).ToList();
    	}
    	public List<Customer> FindByDistrictId(Nullable<int> districtId){
    		return this.Repository.FindByDistrictId(districtId).ToList();
    	}
    	public List<Customer> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<Customer> FindByPostcode(string postcode){
    		return this.Repository.FindByPostcode(postcode).ToList();
    	}
    	public List<Customer> FindBySmallInfoSourceId(int smallInfoSourceId){
    		return this.Repository.FindBySmallInfoSourceId(smallInfoSourceId).ToList();
    	}
    	public List<Customer> FindByConsultType(string consultType){
    		return this.Repository.FindByConsultType(consultType).ToList();
    	}
    	public List<Customer> FindByRemark(string remark){
    		return this.Repository.FindByRemark(remark).ToList();
    	}
    	public List<Customer> FindByConsultantId1(Nullable<int> consultantId1){
    		return this.Repository.FindByConsultantId1(consultantId1).ToList();
    	}
    	public List<Customer> FindByConsultantId2(Nullable<int> consultantId2){
    		return this.Repository.FindByConsultantId2(consultantId2).ToList();
    	}
    	public List<Customer> FindByNetConsultantId(Nullable<int> netConsultantId){
    		return this.Repository.FindByNetConsultantId(netConsultantId).ToList();
    	}
    	public List<Customer> FindByCreateTeacherId(Nullable<int> createTeacherId){
    		return this.Repository.FindByCreateTeacherId(createTeacherId).ToList();
    	}
    	public List<Customer> FindByConsultTime(Nullable<System.DateTime> consultTime){
    		return this.Repository.FindByConsultTime(consultTime).ToList();
    	}
    	public List<Customer> FindBySalesTeamId(Nullable<int> salesTeamId){
    		return this.Repository.FindBySalesTeamId(salesTeamId).ToList();
    	}
    	public List<Customer> FindBySalesmanId(Nullable<int> salesmanId){
    		return this.Repository.FindBySalesmanId(salesmanId).ToList();
    	}
    	public List<Customer> FindByIsImport(bool isImport){
    		return this.Repository.FindByIsImport(isImport).ToList();
    	}
    	public List<Customer> FindByTeleSalesTimes(int teleSalesTimes){
    		return this.Repository.FindByTeleSalesTimes(teleSalesTimes).ToList();
    	}
    	public List<Customer> FindByNextTeleSalesTime(Nullable<System.DateTime> nextTeleSalesTime){
    		return this.Repository.FindByNextTeleSalesTime(nextTeleSalesTime).ToList();
    	}
    	public List<Customer> FindByAppointmentTime(Nullable<System.DateTime> appointmentTime){
    		return this.Repository.FindByAppointmentTime(appointmentTime).ToList();
    	}
    	public List<Customer> FindByDropInTime(Nullable<System.DateTime> dropInTime){
    		return this.Repository.FindByDropInTime(dropInTime).ToList();
    	}
    	public List<Customer> FindByDinWeiTime(Nullable<System.DateTime> dinWeiTime){
    		return this.Repository.FindByDinWeiTime(dinWeiTime).ToList();
    	}
    	public List<Customer> FindBySignUpTime(Nullable<System.DateTime> signUpTime){
    		return this.Repository.FindBySignUpTime(signUpTime).ToList();
    	}
    	public List<Customer> FindByIsDinWei(bool isDinWei){
    		return this.Repository.FindByIsDinWei(isDinWei).ToList();
    	}
    	public List<Customer> FindByIsClosed(bool isClosed){
    		return this.Repository.FindByIsClosed(isClosed).ToList();
    	}
    	public List<Customer> FindByLastSalesTime(Nullable<System.DateTime> lastSalesTime){
    		return this.Repository.FindByLastSalesTime(lastSalesTime).ToList();
    	}
    	public List<Customer> FindByImportant(bool important){
    		return this.Repository.FindByImportant(important).ToList();
    	}
    	public List<Customer> FindByConsultantRemark(string consultantRemark){
    		return this.Repository.FindByConsultantRemark(consultantRemark).ToList();
    	}
    	public List<Customer> FindByKeywords(string keywords){
    		return this.Repository.FindByKeywords(keywords).ToList();
    	}
    	public List<Customer> FindByClazz(string clazz){
    		return this.Repository.FindByClazz(clazz).ToList();
    	}
    	public List<Customer> FindByIsLeaderFollow(bool isLeaderFollow){
    		return this.Repository.FindByIsLeaderFollow(isLeaderFollow).ToList();
    	}
    	public List<Customer> FindByStatus(string status){
    		return this.Repository.FindByStatus(status).ToList();
    	}
    	public List<Customer> FindByLastSaleLog(string lastSaleLog){
    		return this.Repository.FindByLastSaleLog(lastSaleLog).ToList();
    	}
    	public List<Customer> FindByIsDorm(Nullable<bool> isDorm){
    		return this.Repository.FindByIsDorm(isDorm).ToList();
    	}
    	public List<Customer> FindByInClazzId(Nullable<int> inClazzId){
    		return this.Repository.FindByInClazzId(inClazzId).ToList();
    	}
    	public List<Customer> FindByIsPay(bool isPay){
    		return this.Repository.FindByIsPay(isPay).ToList();
    	}
    	public List<Customer> FindByPayTime(Nullable<System.DateTime> payTime){
    		return this.Repository.FindByPayTime(payTime).ToList();
    	}
    	public List<Customer> FindByIsRefund(bool isRefund){
    		return this.Repository.FindByIsRefund(isRefund).ToList();
    	}
    	public List<Customer> FindByRefundTime(Nullable<System.DateTime> refundTime){
    		return this.Repository.FindByRefundTime(refundTime).ToList();
    	}
    	public List<Customer> FindByIsDropIn(bool isDropIn){
    		return this.Repository.FindByIsDropIn(isDropIn).ToList();
    	}
    	public List<Customer> FindByIsSignUp(bool isSignUp){
    		return this.Repository.FindByIsSignUp(isSignUp).ToList();
    	}
    	public PagedModel<Customer> FindByCriteria(CustomerCriteria c) {
    		PagedModel<Customer> m = new PagedModel<Customer>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("schoolid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SchoolId);
    			}else{
    				r = r.OrderByDescending(o=>o.SchoolId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("marketyear")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MarketYear);
    			}else{
    				r = r.OrderByDescending(o=>o.MarketYear);
    			}
    		}
    		if(c.sortname.ToLower().Equals("telephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Telephone);
    			}else{
    				r = r.OrderByDescending(o=>o.Telephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gender")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Gender);
    			}else{
    				r = r.OrderByDescending(o=>o.Gender);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QQ);
    			}else{
    				r = r.OrderByDescending(o=>o.QQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("email")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Email);
    			}else{
    				r = r.OrderByDescending(o=>o.Email);
    			}
    		}
    		if(c.sortname.ToLower().Equals("edulevel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.EduLevel);
    			}else{
    				r = r.OrderByDescending(o=>o.EduLevel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isgaokao")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsGaoKao);
    			}else{
    				r = r.OrderByDescending(o=>o.IsGaoKao);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gaokaoscore")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GaoKaoScore);
    			}else{
    				r = r.OrderByDescending(o=>o.GaoKaoScore);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gaokaobatch")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GaoKaoBatch);
    			}else{
    				r = r.OrderByDescending(o=>o.GaoKaoBatch);
    			}
    		}
    		if(c.sortname.ToLower().Equals("districtid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DistrictId);
    			}else{
    				r = r.OrderByDescending(o=>o.DistrictId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
    			}
    		}
    		if(c.sortname.ToLower().Equals("postcode")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Postcode);
    			}else{
    				r = r.OrderByDescending(o=>o.Postcode);
    			}
    		}
    		if(c.sortname.ToLower().Equals("smallinfosourceid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SmallInfoSourceId);
    			}else{
    				r = r.OrderByDescending(o=>o.SmallInfoSourceId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consulttype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultType);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("remark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Remark);
    			}else{
    				r = r.OrderByDescending(o=>o.Remark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consultantid1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultantId1);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultantId1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consultantid2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultantId2);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultantId2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("netconsultantid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NetConsultantId);
    			}else{
    				r = r.OrderByDescending(o=>o.NetConsultantId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("createteacherid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CreateTeacherId);
    			}else{
    				r = r.OrderByDescending(o=>o.CreateTeacherId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consulttime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultTime);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("salesteamid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SalesTeamId);
    			}else{
    				r = r.OrderByDescending(o=>o.SalesTeamId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("salesmanid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SalesmanId);
    			}else{
    				r = r.OrderByDescending(o=>o.SalesmanId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isimport")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsImport);
    			}else{
    				r = r.OrderByDescending(o=>o.IsImport);
    			}
    		}
    		if(c.sortname.ToLower().Equals("telesalestimes")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeleSalesTimes);
    			}else{
    				r = r.OrderByDescending(o=>o.TeleSalesTimes);
    			}
    		}
    		if(c.sortname.ToLower().Equals("nexttelesalestime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NextTeleSalesTime);
    			}else{
    				r = r.OrderByDescending(o=>o.NextTeleSalesTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("appointmenttime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.AppointmentTime);
    			}else{
    				r = r.OrderByDescending(o=>o.AppointmentTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("dropintime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DropInTime);
    			}else{
    				r = r.OrderByDescending(o=>o.DropInTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("dinweitime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DinWeiTime);
    			}else{
    				r = r.OrderByDescending(o=>o.DinWeiTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("signuptime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SignUpTime);
    			}else{
    				r = r.OrderByDescending(o=>o.SignUpTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isdinwei")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsDinWei);
    			}else{
    				r = r.OrderByDescending(o=>o.IsDinWei);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isclosed")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsClosed);
    			}else{
    				r = r.OrderByDescending(o=>o.IsClosed);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lastsalestime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LastSalesTime);
    			}else{
    				r = r.OrderByDescending(o=>o.LastSalesTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("important")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Important);
    			}else{
    				r = r.OrderByDescending(o=>o.Important);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consultantremark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultantRemark);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultantRemark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("keywords")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Keywords);
    			}else{
    				r = r.OrderByDescending(o=>o.Keywords);
    			}
    		}
    		if(c.sortname.ToLower().Equals("clazz")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Clazz);
    			}else{
    				r = r.OrderByDescending(o=>o.Clazz);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isleaderfollow")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsLeaderFollow);
    			}else{
    				r = r.OrderByDescending(o=>o.IsLeaderFollow);
    			}
    		}
    		if(c.sortname.ToLower().Equals("status")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Status);
    			}else{
    				r = r.OrderByDescending(o=>o.Status);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lastsalelog")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LastSaleLog);
    			}else{
    				r = r.OrderByDescending(o=>o.LastSaleLog);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isdorm")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsDorm);
    			}else{
    				r = r.OrderByDescending(o=>o.IsDorm);
    			}
    		}
    		if(c.sortname.ToLower().Equals("inclazzid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InClazzId);
    			}else{
    				r = r.OrderByDescending(o=>o.InClazzId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("ispay")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsPay);
    			}else{
    				r = r.OrderByDescending(o=>o.IsPay);
    			}
    		}
    		if(c.sortname.ToLower().Equals("paytime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PayTime);
    			}else{
    				r = r.OrderByDescending(o=>o.PayTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isrefund")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsRefund);
    			}else{
    				r = r.OrderByDescending(o=>o.IsRefund);
    			}
    		}
    		if(c.sortname.ToLower().Equals("refundtime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.RefundTime);
    			}else{
    				r = r.OrderByDescending(o=>o.RefundTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isdropin")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsDropIn);
    			}else{
    				r = r.OrderByDescending(o=>o.IsDropIn);
    			}
    		}
    		if(c.sortname.ToLower().Equals("issignup")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsSignUp);
    			}else{
    				r = r.OrderByDescending(o=>o.IsSignUp);
    			}
    		}
    		
    		}
    		
    		m.RecordCount = r.Count();
    		if (c.pagesize.HasValue) {
    			int page = c.page ?? 1;
    			int pageCount = m.RecordCount / c.pagesize.Value;
    			if (m.RecordCount % c.pagesize.Value > 0) {
    				pageCount++;
    			}
    			int skip = (page - 1) * c.pagesize.Value;
    			if (skip > 0) {
    				r = r.Skip(skip);
    			}
    			r = r.Take(c.pagesize.Value);
    		}
    		
    		m.Data = r.ToList();
    		return m;
    	}
    }
}
