using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SchoolContactRepository : ISchoolContactRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SchoolContactRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(SchoolContact entity) {
    		this.DbContext.SchoolContacts.AddObject(entity);
    	}
    
    	public void Update(SchoolContact entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.SchoolId = entity.SchoolId;
    			e.Year = entity.Year;
    			e.Title = entity.Title;
    			e.Name = entity.Name;
    			e.Telephone = entity.Telephone;
    			e.Mobile = entity.Mobile;
    			e.QQ = entity.QQ;
    			e.Address = entity.Address;
    			e.Remark = entity.Remark;
    			e.TopFlag = entity.TopFlag;
    			e.OldOaId = entity.OldOaId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.SchoolContacts.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(SchoolContact entity) {
    		this.DbContext.SchoolContacts.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.SchoolContacts.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<SchoolContact> FindAll() {
    		return this.DbContext.SchoolContacts.Include("School");
    	}
    	public IEnumerable<SchoolContact> FindAll2() {
    		return this.DbContext.SchoolContacts;
    	}
    
    	public SchoolContact FindById(int id) {
    		return this.DbContext.SchoolContacts.Include("School").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<SchoolContact> FindBySchoolId(int schoolId){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.SchoolId.Equals(schoolId));
    			}
    	public IEnumerable<SchoolContact> FindByYear(Nullable<int> year){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Year.Value.Equals(year.Value));
    			}
    	public IEnumerable<SchoolContact> FindByTitle(string title){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Title.Equals(title));
    			}
    	public IEnumerable<SchoolContact> FindByName(string name){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<SchoolContact> FindByTelephone(string telephone){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Telephone.Equals(telephone));
    			}
    	public IEnumerable<SchoolContact> FindByMobile(string mobile){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<SchoolContact> FindByQQ(string qQ){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<SchoolContact> FindByAddress(string address){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<SchoolContact> FindByRemark(string remark){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.Remark.Equals(remark));
    			}
    	public IEnumerable<SchoolContact> FindByTopFlag(Nullable<int> topFlag){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.TopFlag.Value.Equals(topFlag.Value));
    			}
    	public IEnumerable<SchoolContact> FindByOldOaId(Nullable<int> oldOaId){
    				return this.DbContext.SchoolContacts.Include("School").Where(o => o.OldOaId.Value.Equals(oldOaId.Value));
    			}
    	public IEnumerable<SchoolContact> FindByCriteria(SchoolContactCriteria c) {
    		return this.DbContext.SchoolContacts.Include("School").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.SchoolIdSrh.HasValue || o.SchoolId.Equals(c.SchoolIdSrh.Value))
    			&& (!c.SchoolIdFromSrh.HasValue || o.SchoolId >= c.SchoolIdFromSrh.Value)
    			&& (!c.SchoolIdToSrh.HasValue || o.SchoolId <= c.SchoolIdToSrh.Value)
    			&& (!c.YearSrh.HasValue || (o.Year.HasValue 			&& o.Year.Value.Equals(c.YearSrh.Value)))
    			&& (!c.YearFromSrh.HasValue || (o.Year.HasValue 			&& o.Year.Value >= c.YearFromSrh.Value))
    			&& (!c.YearToSrh.HasValue || (o.Year.HasValue 			&& o.Year.Value <= c.YearToSrh.Value))
    			&& (String.IsNullOrEmpty(c.TitleSrh) || o.Title.Contains(c.TitleSrh))
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.TelephoneSrh) || o.Telephone.Contains(c.TelephoneSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
    			&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
    			&& (!c.TopFlagSrh.HasValue || (o.TopFlag.HasValue 			&& o.TopFlag.Value.Equals(c.TopFlagSrh.Value)))
    			&& (!c.TopFlagFromSrh.HasValue || (o.TopFlag.HasValue 			&& o.TopFlag.Value >= c.TopFlagFromSrh.Value))
    			&& (!c.TopFlagToSrh.HasValue || (o.TopFlag.HasValue 			&& o.TopFlag.Value <= c.TopFlagToSrh.Value))
    			&& (!c.OldOaIdSrh.HasValue || (o.OldOaId.HasValue 			&& o.OldOaId.Value.Equals(c.OldOaIdSrh.Value)))
    			&& (!c.OldOaIdFromSrh.HasValue || (o.OldOaId.HasValue 			&& o.OldOaId.Value >= c.OldOaIdFromSrh.Value))
    			&& (!c.OldOaIdToSrh.HasValue || (o.OldOaId.HasValue 			&& o.OldOaId.Value <= c.OldOaIdToSrh.Value))
    
    		);
    	}
    
    }
}
