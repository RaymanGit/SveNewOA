using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class ImportDupliateRepository : IImportDupliateRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public ImportDupliateRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(ImportDupliate entity) {
    		this.DbContext.ImportDupliates.AddObject(entity);
    	}
    
    	public void Update(ImportDupliate entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ImportKey = entity.ImportKey;
    			e.CustomerId = entity.CustomerId;
    			e.ImportId = entity.ImportId;
    			e.SchoolName = entity.SchoolName;
    			e.Name = entity.Name;
    			e.Tel = entity.Tel;
    			e.Mobile = entity.Mobile;
    			e.Score = entity.Score;
    			e.ErrorMsg = entity.ErrorMsg;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.ImportDupliates.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(ImportDupliate entity) {
    		this.DbContext.ImportDupliates.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.ImportDupliates.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<ImportDupliate> FindAll() {
    		return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer");
    	}
    	public IEnumerable<ImportDupliate> FindAll2() {
    		return this.DbContext.ImportDupliates;
    	}
    
    	public ImportDupliate FindById(int id) {
    		return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<ImportDupliate> FindByImportKey(string importKey){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.ImportKey.Equals(importKey));
    			}
    	public IEnumerable<ImportDupliate> FindByCustomerId(Nullable<int> customerId){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.CustomerId.Value.Equals(customerId.Value));
    			}
    	public IEnumerable<ImportDupliate> FindByImportId(Nullable<int> importId){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.ImportId.Value.Equals(importId.Value));
    			}
    	public IEnumerable<ImportDupliate> FindBySchoolName(string schoolName){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.SchoolName.Equals(schoolName));
    			}
    	public IEnumerable<ImportDupliate> FindByName(string name){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<ImportDupliate> FindByTel(string tel){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.Tel.Equals(tel));
    			}
    	public IEnumerable<ImportDupliate> FindByMobile(string mobile){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<ImportDupliate> FindByScore(Nullable<int> score){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.Score.Value.Equals(score.Value));
    			}
    	public IEnumerable<ImportDupliate> FindByErrorMsg(string errorMsg){
    				return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => o.ErrorMsg.Equals(errorMsg));
    			}
    	public IEnumerable<ImportDupliate> FindByCriteria(ImportDupliateCriteria c) {
    		return this.DbContext.ImportDupliates.Include("Customer").Include("ImportCustomer").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.ImportKeySrh) || o.ImportKey.Contains(c.ImportKeySrh))
    			&& (!c.CustomerIdSrh.HasValue || (o.CustomerId.HasValue 			&& o.CustomerId.Value.Equals(c.CustomerIdSrh.Value)))
    			&& (!c.CustomerIdFromSrh.HasValue || (o.CustomerId.HasValue 			&& o.CustomerId.Value >= c.CustomerIdFromSrh.Value))
    			&& (!c.CustomerIdToSrh.HasValue || (o.CustomerId.HasValue 			&& o.CustomerId.Value <= c.CustomerIdToSrh.Value))
    			&& (!c.ImportIdSrh.HasValue || (o.ImportId.HasValue 			&& o.ImportId.Value.Equals(c.ImportIdSrh.Value)))
    			&& (!c.ImportIdFromSrh.HasValue || (o.ImportId.HasValue 			&& o.ImportId.Value >= c.ImportIdFromSrh.Value))
    			&& (!c.ImportIdToSrh.HasValue || (o.ImportId.HasValue 			&& o.ImportId.Value <= c.ImportIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.SchoolNameSrh) || o.SchoolName.Contains(c.SchoolNameSrh))
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.TelSrh) || o.Tel.Contains(c.TelSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (!c.ScoreSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value.Equals(c.ScoreSrh.Value)))
    			&& (!c.ScoreFromSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value >= c.ScoreFromSrh.Value))
    			&& (!c.ScoreToSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value <= c.ScoreToSrh.Value))
    			&& (String.IsNullOrEmpty(c.ErrorMsgSrh) || o.ErrorMsg.Contains(c.ErrorMsgSrh))
    
    		);
    	}
    
    }
}
