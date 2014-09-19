using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class EmploymentCompanyRepository : IEmploymentCompanyRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public EmploymentCompanyRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(EmploymentCompany entity) {
    		this.DbContext.EmploymentCompanies.AddObject(entity);
    	}
    
    	public void Update(EmploymentCompany entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.Type = entity.Type;
    			e.Important = entity.Important;
    			e.Website = entity.Website;
    			e.Telephone = entity.Telephone;
    			e.Fax = entity.Fax;
    			e.Address = entity.Address;
    			e.CityId = entity.CityId;
    			e.Introduction = entity.Introduction;
    			e.SourceType = entity.SourceType;
    			e.Referer = entity.Referer;
    			e.UserId = entity.UserId;
    			e.EmployedQty = entity.EmployedQty;
    			e.OldOaId = entity.OldOaId;
    			e.TempProvId = entity.TempProvId;
    			e.TempProvName = entity.TempProvName;
    			e.TempCityId = entity.TempCityId;
    			e.TempCityName = entity.TempCityName;
    			e.AddTime = entity.AddTime;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.EmploymentCompanies.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(EmploymentCompany entity) {
    		this.DbContext.EmploymentCompanies.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.EmploymentCompanies.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<EmploymentCompany> FindAll() {
    		return this.DbContext.EmploymentCompanies.Include("City").Include("User");
    	}
    	public IEnumerable<EmploymentCompany> FindAll2() {
    		return this.DbContext.EmploymentCompanies;
    	}
    
    	public EmploymentCompany FindById(int id) {
    		return this.DbContext.EmploymentCompanies.Include("City").Include("User").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<EmploymentCompany> FindByName(string name){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<EmploymentCompany> FindByType(string type){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Type.Equals(type));
    			}
    	public IEnumerable<EmploymentCompany> FindByImportant(string important){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Important.Equals(important));
    			}
    	public IEnumerable<EmploymentCompany> FindByWebsite(string website){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Website.Equals(website));
    			}
    	public IEnumerable<EmploymentCompany> FindByTelephone(string telephone){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Telephone.Equals(telephone));
    			}
    	public IEnumerable<EmploymentCompany> FindByFax(string fax){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Fax.Equals(fax));
    			}
    	public IEnumerable<EmploymentCompany> FindByAddress(string address){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<EmploymentCompany> FindByCityId(Nullable<int> cityId){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.CityId.Value.Equals(cityId.Value));
    			}
    	public IEnumerable<EmploymentCompany> FindByIntroduction(string introduction){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Introduction.Equals(introduction));
    			}
    	public IEnumerable<EmploymentCompany> FindBySourceType(string sourceType){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.SourceType.Equals(sourceType));
    			}
    	public IEnumerable<EmploymentCompany> FindByReferer(string referer){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.Referer.Equals(referer));
    			}
    	public IEnumerable<EmploymentCompany> FindByUserId(Nullable<int> userId){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.UserId.Value.Equals(userId.Value));
    			}
    	public IEnumerable<EmploymentCompany> FindByEmployedQty(int employedQty){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.EmployedQty.Equals(employedQty));
    			}
    	public IEnumerable<EmploymentCompany> FindByOldOaId(string oldOaId){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.OldOaId.Equals(oldOaId));
    			}
    	public IEnumerable<EmploymentCompany> FindByTempProvId(string tempProvId){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.TempProvId.Equals(tempProvId));
    			}
    	public IEnumerable<EmploymentCompany> FindByTempProvName(string tempProvName){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.TempProvName.Equals(tempProvName));
    			}
    	public IEnumerable<EmploymentCompany> FindByTempCityId(string tempCityId){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.TempCityId.Equals(tempCityId));
    			}
    	public IEnumerable<EmploymentCompany> FindByTempCityName(string tempCityName){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.TempCityName.Equals(tempCityName));
    			}
    	public IEnumerable<EmploymentCompany> FindByAddTime(Nullable<System.DateTime> addTime){
    				return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => o.AddTime.Value.Equals(addTime.Value));
    			}
    	public IEnumerable<EmploymentCompany> FindByCriteria(EmploymentCompanyCriteria c) {
    		return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.TypeSrh) || o.Type.Contains(c.TypeSrh))
    			&& (String.IsNullOrEmpty(c.ImportantSrh) || o.Important.Contains(c.ImportantSrh))
    			&& (String.IsNullOrEmpty(c.WebsiteSrh) || o.Website.Contains(c.WebsiteSrh))
    			&& (String.IsNullOrEmpty(c.TelephoneSrh) || o.Telephone.Contains(c.TelephoneSrh))
    			&& (String.IsNullOrEmpty(c.FaxSrh) || o.Fax.Contains(c.FaxSrh))
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
    			&& (!c.CityIdSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value.Equals(c.CityIdSrh.Value)))
    			&& (!c.CityIdFromSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value >= c.CityIdFromSrh.Value))
    			&& (!c.CityIdToSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value <= c.CityIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.IntroductionSrh) || o.Introduction.Contains(c.IntroductionSrh))
    			&& (String.IsNullOrEmpty(c.SourceTypeSrh) || o.SourceType.Contains(c.SourceTypeSrh))
    			&& (String.IsNullOrEmpty(c.RefererSrh) || o.Referer.Contains(c.RefererSrh))
    			&& (!c.UserIdSrh.HasValue || (o.UserId.HasValue 			&& o.UserId.Value.Equals(c.UserIdSrh.Value)))
    			&& (!c.UserIdFromSrh.HasValue || (o.UserId.HasValue 			&& o.UserId.Value >= c.UserIdFromSrh.Value))
    			&& (!c.UserIdToSrh.HasValue || (o.UserId.HasValue 			&& o.UserId.Value <= c.UserIdToSrh.Value))
    			&& (!c.EmployedQtySrh.HasValue || o.EmployedQty.Equals(c.EmployedQtySrh.Value))
    			&& (!c.EmployedQtyFromSrh.HasValue || o.EmployedQty >= c.EmployedQtyFromSrh.Value)
    			&& (!c.EmployedQtyToSrh.HasValue || o.EmployedQty <= c.EmployedQtyToSrh.Value)
    			&& (String.IsNullOrEmpty(c.OldOaIdSrh) || o.OldOaId.Contains(c.OldOaIdSrh))
    			&& (String.IsNullOrEmpty(c.TempProvIdSrh) || o.TempProvId.Contains(c.TempProvIdSrh))
    			&& (String.IsNullOrEmpty(c.TempProvNameSrh) || o.TempProvName.Contains(c.TempProvNameSrh))
    			&& (String.IsNullOrEmpty(c.TempCityIdSrh) || o.TempCityId.Contains(c.TempCityIdSrh))
    			&& (String.IsNullOrEmpty(c.TempCityNameSrh) || o.TempCityName.Contains(c.TempCityNameSrh))
    			&& (!c.AddTimeSrh.HasValue || (o.AddTime.HasValue 			&& o.AddTime.Value.Equals(c.AddTimeSrh.Value)))
    			&& (!c.AddTimeFromSrh.HasValue || (o.AddTime.HasValue 			&& o.AddTime.Value >= c.AddTimeFromSrh.Value))
    			&& (!c.AddTimeToSrh.HasValue || (o.AddTime.HasValue 			&& o.AddTime.Value <= c.AddTimeToSrh.Value))
    
    		);
    	}
    
    }
}
