using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class CustomerRepository : ICustomerRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public CustomerRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Customer entity) {
    		this.DbContext.Customers.AddObject(entity);
    	}
    
    	public void Update(Customer entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.SchoolId = entity.SchoolId;
    			e.MarketYear = entity.MarketYear;
    			e.Telephone = entity.Telephone;
    			e.Mobile = entity.Mobile;
    			e.Gender = entity.Gender;
    			e.QQ = entity.QQ;
    			e.Email = entity.Email;
    			e.EduLevel = entity.EduLevel;
    			e.IsGaoKao = entity.IsGaoKao;
    			e.GaoKaoScore = entity.GaoKaoScore;
    			e.GaoKaoBatch = entity.GaoKaoBatch;
    			e.DistrictId = entity.DistrictId;
    			e.Address = entity.Address;
    			e.Postcode = entity.Postcode;
    			e.SmallInfoSourceId = entity.SmallInfoSourceId;
    			e.ConsultType = entity.ConsultType;
    			e.Remark = entity.Remark;
    			e.ConsultantId1 = entity.ConsultantId1;
    			e.ConsultantId2 = entity.ConsultantId2;
    			e.NetConsultantId = entity.NetConsultantId;
    			e.CreateTeacherId = entity.CreateTeacherId;
    			e.ConsultTime = entity.ConsultTime;
    			e.SalesTeamId = entity.SalesTeamId;
    			e.SalesmanId = entity.SalesmanId;
    			e.IsImport = entity.IsImport;
    			e.TeleSalesTimes = entity.TeleSalesTimes;
    			e.NextTeleSalesTime = entity.NextTeleSalesTime;
    			e.AppointmentTime = entity.AppointmentTime;
    			e.DropInTime = entity.DropInTime;
    			e.DinWeiTime = entity.DinWeiTime;
    			e.SignUpTime = entity.SignUpTime;
    			e.IsDinWei = entity.IsDinWei;
    			e.IsClosed = entity.IsClosed;
    			e.LastSalesTime = entity.LastSalesTime;
    			e.Important = entity.Important;
    			e.ConsultantRemark = entity.ConsultantRemark;
    			e.Keywords = entity.Keywords;
    			e.Clazz = entity.Clazz;
    			e.IsLeaderFollow = entity.IsLeaderFollow;
    			e.Status = entity.Status;
    			e.LastSaleLog = entity.LastSaleLog;
    			e.IsDorm = entity.IsDorm;
    			e.InClazzId = entity.InClazzId;
    			e.IsPay = entity.IsPay;
    			e.PayTime = entity.PayTime;
    			e.IsRefund = entity.IsRefund;
    			e.RefundTime = entity.RefundTime;
    			e.IsDropIn = entity.IsDropIn;
    			e.IsSignUp = entity.IsSignUp;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Customers.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Customer entity) {
    		this.DbContext.Customers.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Customers.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Customer> FindAll() {
    		return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz");
    	}
    	public IEnumerable<Customer> FindAll2() {
    		return this.DbContext.Customers;
    	}
    
    	public Customer FindById(int id) {
    		return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Customer> FindByName(string name){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Customer> FindBySchoolId(Nullable<int> schoolId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.SchoolId.Value.Equals(schoolId.Value));
    			}
    	public IEnumerable<Customer> FindByMarketYear(int marketYear){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.MarketYear.Equals(marketYear));
    			}
    	public IEnumerable<Customer> FindByTelephone(string telephone){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Telephone.Equals(telephone));
    			}
    	public IEnumerable<Customer> FindByMobile(string mobile){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<Customer> FindByGender(string gender){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Gender.Equals(gender));
    			}
    	public IEnumerable<Customer> FindByQQ(string qQ){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<Customer> FindByEmail(string email){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Email.Equals(email));
    			}
    	public IEnumerable<Customer> FindByEduLevel(string eduLevel){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.EduLevel.Equals(eduLevel));
    			}
    	public IEnumerable<Customer> FindByIsGaoKao(bool isGaoKao){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsGaoKao.Equals(isGaoKao));
    			}
    	public IEnumerable<Customer> FindByGaoKaoScore(Nullable<int> gaoKaoScore){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.GaoKaoScore.Value.Equals(gaoKaoScore.Value));
    			}
    	public IEnumerable<Customer> FindByGaoKaoBatch(string gaoKaoBatch){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.GaoKaoBatch.Equals(gaoKaoBatch));
    			}
    	public IEnumerable<Customer> FindByDistrictId(Nullable<int> districtId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.DistrictId.Value.Equals(districtId.Value));
    			}
    	public IEnumerable<Customer> FindByAddress(string address){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<Customer> FindByPostcode(string postcode){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Postcode.Equals(postcode));
    			}
    	public IEnumerable<Customer> FindBySmallInfoSourceId(int smallInfoSourceId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.SmallInfoSourceId.Equals(smallInfoSourceId));
    			}
    	public IEnumerable<Customer> FindByConsultType(string consultType){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.ConsultType.Equals(consultType));
    			}
    	public IEnumerable<Customer> FindByRemark(string remark){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Remark.Equals(remark));
    			}
    	public IEnumerable<Customer> FindByConsultantId1(Nullable<int> consultantId1){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.ConsultantId1.Value.Equals(consultantId1.Value));
    			}
    	public IEnumerable<Customer> FindByConsultantId2(Nullable<int> consultantId2){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.ConsultantId2.Value.Equals(consultantId2.Value));
    			}
    	public IEnumerable<Customer> FindByNetConsultantId(Nullable<int> netConsultantId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.NetConsultantId.Value.Equals(netConsultantId.Value));
    			}
    	public IEnumerable<Customer> FindByCreateTeacherId(Nullable<int> createTeacherId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.CreateTeacherId.Value.Equals(createTeacherId.Value));
    			}
    	public IEnumerable<Customer> FindByConsultTime(Nullable<System.DateTime> consultTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.ConsultTime.Value.Equals(consultTime.Value));
    			}
    	public IEnumerable<Customer> FindBySalesTeamId(Nullable<int> salesTeamId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.SalesTeamId.Value.Equals(salesTeamId.Value));
    			}
    	public IEnumerable<Customer> FindBySalesmanId(Nullable<int> salesmanId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.SalesmanId.Value.Equals(salesmanId.Value));
    			}
    	public IEnumerable<Customer> FindByIsImport(bool isImport){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsImport.Equals(isImport));
    			}
    	public IEnumerable<Customer> FindByTeleSalesTimes(int teleSalesTimes){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.TeleSalesTimes.Equals(teleSalesTimes));
    			}
    	public IEnumerable<Customer> FindByNextTeleSalesTime(Nullable<System.DateTime> nextTeleSalesTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.NextTeleSalesTime.Value.Equals(nextTeleSalesTime.Value));
    			}
    	public IEnumerable<Customer> FindByAppointmentTime(Nullable<System.DateTime> appointmentTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.AppointmentTime.Value.Equals(appointmentTime.Value));
    			}
    	public IEnumerable<Customer> FindByDropInTime(Nullable<System.DateTime> dropInTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.DropInTime.Value.Equals(dropInTime.Value));
    			}
    	public IEnumerable<Customer> FindByDinWeiTime(Nullable<System.DateTime> dinWeiTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.DinWeiTime.Value.Equals(dinWeiTime.Value));
    			}
    	public IEnumerable<Customer> FindBySignUpTime(Nullable<System.DateTime> signUpTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.SignUpTime.Value.Equals(signUpTime.Value));
    			}
    	public IEnumerable<Customer> FindByIsDinWei(bool isDinWei){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsDinWei.Equals(isDinWei));
    			}
    	public IEnumerable<Customer> FindByIsClosed(bool isClosed){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsClosed.Equals(isClosed));
    			}
    	public IEnumerable<Customer> FindByLastSalesTime(Nullable<System.DateTime> lastSalesTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.LastSalesTime.Value.Equals(lastSalesTime.Value));
    			}
    	public IEnumerable<Customer> FindByImportant(bool important){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Important.Equals(important));
    			}
    	public IEnumerable<Customer> FindByConsultantRemark(string consultantRemark){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.ConsultantRemark.Equals(consultantRemark));
    			}
    	public IEnumerable<Customer> FindByKeywords(string keywords){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Keywords.Equals(keywords));
    			}
    	public IEnumerable<Customer> FindByClazz(string clazz){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Clazz.Equals(clazz));
    			}
    	public IEnumerable<Customer> FindByIsLeaderFollow(bool isLeaderFollow){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsLeaderFollow.Equals(isLeaderFollow));
    			}
    	public IEnumerable<Customer> FindByStatus(string status){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.Status.Equals(status));
    			}
    	public IEnumerable<Customer> FindByLastSaleLog(string lastSaleLog){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.LastSaleLog.Equals(lastSaleLog));
    			}
    	public IEnumerable<Customer> FindByIsDorm(Nullable<bool> isDorm){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsDorm.Value.Equals(isDorm.Value));
    			}
    	public IEnumerable<Customer> FindByInClazzId(Nullable<int> inClazzId){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.InClazzId.Value.Equals(inClazzId.Value));
    			}
    	public IEnumerable<Customer> FindByIsPay(bool isPay){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsPay.Equals(isPay));
    			}
    	public IEnumerable<Customer> FindByPayTime(Nullable<System.DateTime> payTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.PayTime.Value.Equals(payTime.Value));
    			}
    	public IEnumerable<Customer> FindByIsRefund(bool isRefund){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsRefund.Equals(isRefund));
    			}
    	public IEnumerable<Customer> FindByRefundTime(Nullable<System.DateTime> refundTime){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.RefundTime.Value.Equals(refundTime.Value));
    			}
    	public IEnumerable<Customer> FindByIsDropIn(bool isDropIn){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsDropIn.Equals(isDropIn));
    			}
    	public IEnumerable<Customer> FindByIsSignUp(bool isSignUp){
    				return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => o.IsSignUp.Equals(isSignUp));
    			}
    	public IEnumerable<Customer> FindByCriteria(CustomerCriteria c) {
    		return this.DbContext.Customers.Include("District").Include("InfoSource").Include("School").Include("Consultant1").Include("Consultant2").Include("CreateTeacher").Include("NetConsultant").Include("Salesman").Include("SalesTeam").Include("InClazz").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (!c.SchoolIdSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value.Equals(c.SchoolIdSrh.Value)))
    			&& (!c.SchoolIdFromSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value >= c.SchoolIdFromSrh.Value))
    			&& (!c.SchoolIdToSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value <= c.SchoolIdToSrh.Value))
    			&& (!c.MarketYearSrh.HasValue || o.MarketYear.Equals(c.MarketYearSrh.Value))
    			&& (!c.MarketYearFromSrh.HasValue || o.MarketYear >= c.MarketYearFromSrh.Value)
    			&& (!c.MarketYearToSrh.HasValue || o.MarketYear <= c.MarketYearToSrh.Value)
    			&& (String.IsNullOrEmpty(c.TelephoneSrh) || o.Telephone.Contains(c.TelephoneSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (String.IsNullOrEmpty(c.GenderSrh) || o.Gender.Contains(c.GenderSrh))
    			&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
    			&& (String.IsNullOrEmpty(c.EmailSrh) || o.Email.Contains(c.EmailSrh))
    			&& (String.IsNullOrEmpty(c.EduLevelSrh) || o.EduLevel.Contains(c.EduLevelSrh))
    			&& (!c.IsGaoKaoSrh.HasValue || o.IsGaoKao.Equals(c.IsGaoKaoSrh.Value))
    			&& (!c.GaoKaoScoreSrh.HasValue || (o.GaoKaoScore.HasValue 			&& o.GaoKaoScore.Value.Equals(c.GaoKaoScoreSrh.Value)))
    			&& (!c.GaoKaoScoreFromSrh.HasValue || (o.GaoKaoScore.HasValue 			&& o.GaoKaoScore.Value >= c.GaoKaoScoreFromSrh.Value))
    			&& (!c.GaoKaoScoreToSrh.HasValue || (o.GaoKaoScore.HasValue 			&& o.GaoKaoScore.Value <= c.GaoKaoScoreToSrh.Value))
    			&& (String.IsNullOrEmpty(c.GaoKaoBatchSrh) || o.GaoKaoBatch.Contains(c.GaoKaoBatchSrh))
    			&& (!c.DistrictIdSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value.Equals(c.DistrictIdSrh.Value)))
    			&& (!c.DistrictIdFromSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value >= c.DistrictIdFromSrh.Value))
    			&& (!c.DistrictIdToSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value <= c.DistrictIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
    			&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
    			&& (!c.SmallInfoSourceIdSrh.HasValue || o.SmallInfoSourceId.Equals(c.SmallInfoSourceIdSrh.Value))
    			&& (!c.SmallInfoSourceIdFromSrh.HasValue || o.SmallInfoSourceId >= c.SmallInfoSourceIdFromSrh.Value)
    			&& (!c.SmallInfoSourceIdToSrh.HasValue || o.SmallInfoSourceId <= c.SmallInfoSourceIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.ConsultTypeSrh) || o.ConsultType.Contains(c.ConsultTypeSrh))
    			&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
    			&& (!c.ConsultantId1Srh.HasValue || (o.ConsultantId1.HasValue 			&& o.ConsultantId1.Value.Equals(c.ConsultantId1Srh.Value)))
    			&& (!c.ConsultantId1FromSrh.HasValue || (o.ConsultantId1.HasValue 			&& o.ConsultantId1.Value >= c.ConsultantId1FromSrh.Value))
    			&& (!c.ConsultantId1ToSrh.HasValue || (o.ConsultantId1.HasValue 			&& o.ConsultantId1.Value <= c.ConsultantId1ToSrh.Value))
    			&& (!c.ConsultantId2Srh.HasValue || (o.ConsultantId2.HasValue 			&& o.ConsultantId2.Value.Equals(c.ConsultantId2Srh.Value)))
    			&& (!c.ConsultantId2FromSrh.HasValue || (o.ConsultantId2.HasValue 			&& o.ConsultantId2.Value >= c.ConsultantId2FromSrh.Value))
    			&& (!c.ConsultantId2ToSrh.HasValue || (o.ConsultantId2.HasValue 			&& o.ConsultantId2.Value <= c.ConsultantId2ToSrh.Value))
    			&& (!c.NetConsultantIdSrh.HasValue || (o.NetConsultantId.HasValue 			&& o.NetConsultantId.Value.Equals(c.NetConsultantIdSrh.Value)))
    			&& (!c.NetConsultantIdFromSrh.HasValue || (o.NetConsultantId.HasValue 			&& o.NetConsultantId.Value >= c.NetConsultantIdFromSrh.Value))
    			&& (!c.NetConsultantIdToSrh.HasValue || (o.NetConsultantId.HasValue 			&& o.NetConsultantId.Value <= c.NetConsultantIdToSrh.Value))
    			&& (!c.CreateTeacherIdSrh.HasValue || (o.CreateTeacherId.HasValue 			&& o.CreateTeacherId.Value.Equals(c.CreateTeacherIdSrh.Value)))
    			&& (!c.CreateTeacherIdFromSrh.HasValue || (o.CreateTeacherId.HasValue 			&& o.CreateTeacherId.Value >= c.CreateTeacherIdFromSrh.Value))
    			&& (!c.CreateTeacherIdToSrh.HasValue || (o.CreateTeacherId.HasValue 			&& o.CreateTeacherId.Value <= c.CreateTeacherIdToSrh.Value))
    			&& (!c.ConsultTimeSrh.HasValue || (o.ConsultTime.HasValue 			&& o.ConsultTime.Value.Equals(c.ConsultTimeSrh.Value)))
    			&& (!c.ConsultTimeFromSrh.HasValue || (o.ConsultTime.HasValue 			&& o.ConsultTime.Value >= c.ConsultTimeFromSrh.Value))
    			&& (!c.ConsultTimeToSrh.HasValue || (o.ConsultTime.HasValue 			&& o.ConsultTime.Value <= c.ConsultTimeToSrh.Value))
    			&& (!c.SalesTeamIdSrh.HasValue || (o.SalesTeamId.HasValue 			&& o.SalesTeamId.Value.Equals(c.SalesTeamIdSrh.Value)))
    			&& (!c.SalesTeamIdFromSrh.HasValue || (o.SalesTeamId.HasValue 			&& o.SalesTeamId.Value >= c.SalesTeamIdFromSrh.Value))
    			&& (!c.SalesTeamIdToSrh.HasValue || (o.SalesTeamId.HasValue 			&& o.SalesTeamId.Value <= c.SalesTeamIdToSrh.Value))
    			&& (!c.SalesmanIdSrh.HasValue || (o.SalesmanId.HasValue 			&& o.SalesmanId.Value.Equals(c.SalesmanIdSrh.Value)))
    			&& (!c.SalesmanIdFromSrh.HasValue || (o.SalesmanId.HasValue 			&& o.SalesmanId.Value >= c.SalesmanIdFromSrh.Value))
    			&& (!c.SalesmanIdToSrh.HasValue || (o.SalesmanId.HasValue 			&& o.SalesmanId.Value <= c.SalesmanIdToSrh.Value))
    			&& (!c.IsImportSrh.HasValue || o.IsImport.Equals(c.IsImportSrh.Value))
    			&& (!c.TeleSalesTimesSrh.HasValue || o.TeleSalesTimes.Equals(c.TeleSalesTimesSrh.Value))
    			&& (!c.TeleSalesTimesFromSrh.HasValue || o.TeleSalesTimes >= c.TeleSalesTimesFromSrh.Value)
    			&& (!c.TeleSalesTimesToSrh.HasValue || o.TeleSalesTimes <= c.TeleSalesTimesToSrh.Value)
    			&& (!c.NextTeleSalesTimeSrh.HasValue || (o.NextTeleSalesTime.HasValue 			&& o.NextTeleSalesTime.Value.Equals(c.NextTeleSalesTimeSrh.Value)))
    			&& (!c.NextTeleSalesTimeFromSrh.HasValue || (o.NextTeleSalesTime.HasValue 			&& o.NextTeleSalesTime.Value >= c.NextTeleSalesTimeFromSrh.Value))
    			&& (!c.NextTeleSalesTimeToSrh.HasValue || (o.NextTeleSalesTime.HasValue 			&& o.NextTeleSalesTime.Value <= c.NextTeleSalesTimeToSrh.Value))
    			&& (!c.AppointmentTimeSrh.HasValue || (o.AppointmentTime.HasValue 			&& o.AppointmentTime.Value.Equals(c.AppointmentTimeSrh.Value)))
    			&& (!c.AppointmentTimeFromSrh.HasValue || (o.AppointmentTime.HasValue 			&& o.AppointmentTime.Value >= c.AppointmentTimeFromSrh.Value))
    			&& (!c.AppointmentTimeToSrh.HasValue || (o.AppointmentTime.HasValue 			&& o.AppointmentTime.Value <= c.AppointmentTimeToSrh.Value))
    			&& (!c.DropInTimeSrh.HasValue || (o.DropInTime.HasValue 			&& o.DropInTime.Value.Equals(c.DropInTimeSrh.Value)))
    			&& (!c.DropInTimeFromSrh.HasValue || (o.DropInTime.HasValue 			&& o.DropInTime.Value >= c.DropInTimeFromSrh.Value))
    			&& (!c.DropInTimeToSrh.HasValue || (o.DropInTime.HasValue 			&& o.DropInTime.Value <= c.DropInTimeToSrh.Value))
    			&& (!c.DinWeiTimeSrh.HasValue || (o.DinWeiTime.HasValue 			&& o.DinWeiTime.Value.Equals(c.DinWeiTimeSrh.Value)))
    			&& (!c.DinWeiTimeFromSrh.HasValue || (o.DinWeiTime.HasValue 			&& o.DinWeiTime.Value >= c.DinWeiTimeFromSrh.Value))
    			&& (!c.DinWeiTimeToSrh.HasValue || (o.DinWeiTime.HasValue 			&& o.DinWeiTime.Value <= c.DinWeiTimeToSrh.Value))
    			&& (!c.SignUpTimeSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value.Equals(c.SignUpTimeSrh.Value)))
    			&& (!c.SignUpTimeFromSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value >= c.SignUpTimeFromSrh.Value))
    			&& (!c.SignUpTimeToSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value <= c.SignUpTimeToSrh.Value))
    			&& (!c.IsDinWeiSrh.HasValue || o.IsDinWei.Equals(c.IsDinWeiSrh.Value))
    			&& (!c.IsClosedSrh.HasValue || o.IsClosed.Equals(c.IsClosedSrh.Value))
    			&& (!c.LastSalesTimeSrh.HasValue || (o.LastSalesTime.HasValue 			&& o.LastSalesTime.Value.Equals(c.LastSalesTimeSrh.Value)))
    			&& (!c.LastSalesTimeFromSrh.HasValue || (o.LastSalesTime.HasValue 			&& o.LastSalesTime.Value >= c.LastSalesTimeFromSrh.Value))
    			&& (!c.LastSalesTimeToSrh.HasValue || (o.LastSalesTime.HasValue 			&& o.LastSalesTime.Value <= c.LastSalesTimeToSrh.Value))
    			&& (!c.ImportantSrh.HasValue || o.Important.Equals(c.ImportantSrh.Value))
    			&& (String.IsNullOrEmpty(c.ConsultantRemarkSrh) || o.ConsultantRemark.Contains(c.ConsultantRemarkSrh))
    			&& (String.IsNullOrEmpty(c.KeywordsSrh) || o.Keywords.Contains(c.KeywordsSrh))
    			&& (String.IsNullOrEmpty(c.ClazzSrh) || o.Clazz.Contains(c.ClazzSrh))
    			&& (!c.IsLeaderFollowSrh.HasValue || o.IsLeaderFollow.Equals(c.IsLeaderFollowSrh.Value))
    			&& (String.IsNullOrEmpty(c.StatusSrh) || o.Status.Contains(c.StatusSrh))
    			&& (String.IsNullOrEmpty(c.LastSaleLogSrh) || o.LastSaleLog.Contains(c.LastSaleLogSrh))
    			&& (!c.IsDormSrh.HasValue || (o.IsDorm.HasValue 			&& o.IsDorm.Value.Equals(c.IsDormSrh.Value)))
    			&& (!c.InClazzIdSrh.HasValue || (o.InClazzId.HasValue 			&& o.InClazzId.Value.Equals(c.InClazzIdSrh.Value)))
    			&& (!c.InClazzIdFromSrh.HasValue || (o.InClazzId.HasValue 			&& o.InClazzId.Value >= c.InClazzIdFromSrh.Value))
    			&& (!c.InClazzIdToSrh.HasValue || (o.InClazzId.HasValue 			&& o.InClazzId.Value <= c.InClazzIdToSrh.Value))
    			&& (!c.IsPaySrh.HasValue || o.IsPay.Equals(c.IsPaySrh.Value))
    			&& (!c.PayTimeSrh.HasValue || (o.PayTime.HasValue 			&& o.PayTime.Value.Equals(c.PayTimeSrh.Value)))
    			&& (!c.PayTimeFromSrh.HasValue || (o.PayTime.HasValue 			&& o.PayTime.Value >= c.PayTimeFromSrh.Value))
    			&& (!c.PayTimeToSrh.HasValue || (o.PayTime.HasValue 			&& o.PayTime.Value <= c.PayTimeToSrh.Value))
    			&& (!c.IsRefundSrh.HasValue || o.IsRefund.Equals(c.IsRefundSrh.Value))
    			&& (!c.RefundTimeSrh.HasValue || (o.RefundTime.HasValue 			&& o.RefundTime.Value.Equals(c.RefundTimeSrh.Value)))
    			&& (!c.RefundTimeFromSrh.HasValue || (o.RefundTime.HasValue 			&& o.RefundTime.Value >= c.RefundTimeFromSrh.Value))
    			&& (!c.RefundTimeToSrh.HasValue || (o.RefundTime.HasValue 			&& o.RefundTime.Value <= c.RefundTimeToSrh.Value))
    			&& (!c.IsDropInSrh.HasValue || o.IsDropIn.Equals(c.IsDropInSrh.Value))
    			&& (!c.IsSignUpSrh.HasValue || o.IsSignUp.Equals(c.IsSignUpSrh.Value))
    
    		);
    	}
    
    }
}
