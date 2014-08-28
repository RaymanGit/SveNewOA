using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class ImportCustomerRepository : IImportCustomerRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public ImportCustomerRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(ImportCustomer entity) {
    		this.DbContext.Marketing_ImportCustomer.AddObject(entity);
    	}
    
    	public void Update(ImportCustomer entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ImportKey = entity.ImportKey;
    			e.SchoolId = entity.SchoolId;
    			e.SchoolName = entity.SchoolName;
    			e.Level = entity.Level;
    			e.MarketYear = entity.MarketYear;
    			e.InfoSource = entity.InfoSource;
    			e.Name = entity.Name;
    			e.Gender = entity.Gender;
    			e.Tel = entity.Tel;
    			e.ProvinceId = entity.ProvinceId;
    			e.ProvinceName = entity.ProvinceName;
    			e.CityId = entity.CityId;
    			e.CityName = entity.CityName;
    			e.DistrictId = entity.DistrictId;
    			e.DistrictName = entity.DistrictName;
    			e.Address = entity.Address;
    			e.Mobile = entity.Mobile;
    			e.QQ = entity.QQ;
    			e.Clazz = entity.Clazz;
    			e.Score = entity.Score;
    			e.Postcode = entity.Postcode;
    			e.Contact = entity.Contact;
    			e.ImportType = entity.ImportType;
    			e.IsProcessed = entity.IsProcessed;
    			e.ErrorMsg = entity.ErrorMsg;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Marketing_ImportCustomer.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(ImportCustomer entity) {
    		this.DbContext.Marketing_ImportCustomer.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Marketing_ImportCustomer.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<ImportCustomer> FindAll() {
    		return this.DbContext.Marketing_ImportCustomer;
    	}
    	public IEnumerable<ImportCustomer> FindAll2() {
    		return this.DbContext.Marketing_ImportCustomer;
    	}
    
    	public ImportCustomer FindById(int id) {
    		return this.DbContext.Marketing_ImportCustomer.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<ImportCustomer> FindByImportKey(string importKey){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.ImportKey.Equals(importKey));
    			}
    	public IEnumerable<ImportCustomer> FindBySchoolId(Nullable<int> schoolId){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.SchoolId.Value.Equals(schoolId.Value));
    			}
    	public IEnumerable<ImportCustomer> FindBySchoolName(string schoolName){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.SchoolName.Equals(schoolName));
    			}
    	public IEnumerable<ImportCustomer> FindByLevel(string level){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Level.Equals(level));
    			}
    	public IEnumerable<ImportCustomer> FindByMarketYear(int marketYear){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.MarketYear.Equals(marketYear));
    			}
    	public IEnumerable<ImportCustomer> FindByInfoSource(int infoSource){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.InfoSource.Equals(infoSource));
    			}
    	public IEnumerable<ImportCustomer> FindByName(string name){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<ImportCustomer> FindByGender(string gender){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Gender.Equals(gender));
    			}
    	public IEnumerable<ImportCustomer> FindByTel(string tel){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Tel.Equals(tel));
    			}
    	public IEnumerable<ImportCustomer> FindByProvinceId(Nullable<int> provinceId){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.ProvinceId.Value.Equals(provinceId.Value));
    			}
    	public IEnumerable<ImportCustomer> FindByProvinceName(string provinceName){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.ProvinceName.Equals(provinceName));
    			}
    	public IEnumerable<ImportCustomer> FindByCityId(Nullable<int> cityId){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.CityId.Value.Equals(cityId.Value));
    			}
    	public IEnumerable<ImportCustomer> FindByCityName(string cityName){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.CityName.Equals(cityName));
    			}
    	public IEnumerable<ImportCustomer> FindByDistrictId(Nullable<int> districtId){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.DistrictId.Value.Equals(districtId.Value));
    			}
    	public IEnumerable<ImportCustomer> FindByDistrictName(string districtName){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.DistrictName.Equals(districtName));
    			}
    	public IEnumerable<ImportCustomer> FindByAddress(string address){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<ImportCustomer> FindByMobile(string mobile){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<ImportCustomer> FindByQQ(string qQ){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<ImportCustomer> FindByClazz(string clazz){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Clazz.Equals(clazz));
    			}
    	public IEnumerable<ImportCustomer> FindByScore(Nullable<int> score){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Score.Value.Equals(score.Value));
    			}
    	public IEnumerable<ImportCustomer> FindByPostcode(string postcode){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Postcode.Equals(postcode));
    			}
    	public IEnumerable<ImportCustomer> FindByContact(string contact){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.Contact.Equals(contact));
    			}
    	public IEnumerable<ImportCustomer> FindByImportType(string importType){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.ImportType.Equals(importType));
    			}
    	public IEnumerable<ImportCustomer> FindByIsProcessed(bool isProcessed){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.IsProcessed.Equals(isProcessed));
    			}
    	public IEnumerable<ImportCustomer> FindByErrorMsg(string errorMsg){
    				return this.DbContext.Marketing_ImportCustomer.Where(o => o.ErrorMsg.Equals(errorMsg));
    			}
    	public IEnumerable<ImportCustomer> FindByCriteria(ImportCustomerCriteria c) {
    		return this.DbContext.Marketing_ImportCustomer.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.ImportKeySrh) || o.ImportKey.Contains(c.ImportKeySrh))
    			&& (!c.SchoolIdSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value.Equals(c.SchoolIdSrh.Value)))
    			&& (!c.SchoolIdFromSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value >= c.SchoolIdFromSrh.Value))
    			&& (!c.SchoolIdToSrh.HasValue || (o.SchoolId.HasValue 			&& o.SchoolId.Value <= c.SchoolIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.SchoolNameSrh) || o.SchoolName.Contains(c.SchoolNameSrh))
    			&& (String.IsNullOrEmpty(c.LevelSrh) || o.Level.Contains(c.LevelSrh))
    			&& (!c.MarketYearSrh.HasValue || o.MarketYear.Equals(c.MarketYearSrh.Value))
    			&& (!c.MarketYearFromSrh.HasValue || o.MarketYear >= c.MarketYearFromSrh.Value)
    			&& (!c.MarketYearToSrh.HasValue || o.MarketYear <= c.MarketYearToSrh.Value)
    			&& (!c.InfoSourceSrh.HasValue || o.InfoSource.Equals(c.InfoSourceSrh.Value))
    			&& (!c.InfoSourceFromSrh.HasValue || o.InfoSource >= c.InfoSourceFromSrh.Value)
    			&& (!c.InfoSourceToSrh.HasValue || o.InfoSource <= c.InfoSourceToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.GenderSrh) || o.Gender.Contains(c.GenderSrh))
    			&& (String.IsNullOrEmpty(c.TelSrh) || o.Tel.Contains(c.TelSrh))
    			&& (!c.ProvinceIdSrh.HasValue || (o.ProvinceId.HasValue 			&& o.ProvinceId.Value.Equals(c.ProvinceIdSrh.Value)))
    			&& (!c.ProvinceIdFromSrh.HasValue || (o.ProvinceId.HasValue 			&& o.ProvinceId.Value >= c.ProvinceIdFromSrh.Value))
    			&& (!c.ProvinceIdToSrh.HasValue || (o.ProvinceId.HasValue 			&& o.ProvinceId.Value <= c.ProvinceIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.ProvinceNameSrh) || o.ProvinceName.Contains(c.ProvinceNameSrh))
    			&& (!c.CityIdSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value.Equals(c.CityIdSrh.Value)))
    			&& (!c.CityIdFromSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value >= c.CityIdFromSrh.Value))
    			&& (!c.CityIdToSrh.HasValue || (o.CityId.HasValue 			&& o.CityId.Value <= c.CityIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.CityNameSrh) || o.CityName.Contains(c.CityNameSrh))
    			&& (!c.DistrictIdSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value.Equals(c.DistrictIdSrh.Value)))
    			&& (!c.DistrictIdFromSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value >= c.DistrictIdFromSrh.Value))
    			&& (!c.DistrictIdToSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value <= c.DistrictIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.DistrictNameSrh) || o.DistrictName.Contains(c.DistrictNameSrh))
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
    			&& (String.IsNullOrEmpty(c.ClazzSrh) || o.Clazz.Contains(c.ClazzSrh))
    			&& (!c.ScoreSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value.Equals(c.ScoreSrh.Value)))
    			&& (!c.ScoreFromSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value >= c.ScoreFromSrh.Value))
    			&& (!c.ScoreToSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value <= c.ScoreToSrh.Value))
    			&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
    			&& (String.IsNullOrEmpty(c.ContactSrh) || o.Contact.Contains(c.ContactSrh))
    			&& (String.IsNullOrEmpty(c.ImportTypeSrh) || o.ImportType.Contains(c.ImportTypeSrh))
    			&& (!c.IsProcessedSrh.HasValue || o.IsProcessed.Equals(c.IsProcessedSrh.Value))
    			&& (String.IsNullOrEmpty(c.ErrorMsgSrh) || o.ErrorMsg.Contains(c.ErrorMsgSrh))
    
    		);
    	}
    
    }
}
