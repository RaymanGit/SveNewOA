using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class EmploymentCompanyContactRepository : IEmploymentCompanyContactRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public EmploymentCompanyContactRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(EmploymentCompanyContact entity) {
    		this.DbContext.EmploymentCompanyContacts.AddObject(entity);
    	}
    
    	public void Update(EmploymentCompanyContact entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.CompanyId = entity.CompanyId;
    			e.Name = entity.Name;
    			e.Mobile = entity.Mobile;
    			e.Position = entity.Position;
    			e.Telephone = entity.Telephone;
    			e.QQ = entity.QQ;
    			e.Email = entity.Email;
    			e.Introduction = entity.Introduction;
    			e.OldOaId = entity.OldOaId;
    			e.OldOaCompanyId = entity.OldOaCompanyId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.EmploymentCompanyContacts.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(EmploymentCompanyContact entity) {
    		this.DbContext.EmploymentCompanyContacts.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.EmploymentCompanyContacts.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<EmploymentCompanyContact> FindAll() {
    		return this.DbContext.EmploymentCompanyContacts.Include("Company");
    	}
    	public IEnumerable<EmploymentCompanyContact> FindAll2() {
    		return this.DbContext.EmploymentCompanyContacts;
    	}
    
    	public EmploymentCompanyContact FindById(int id) {
    		return this.DbContext.EmploymentCompanyContacts.Include("Company").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<EmploymentCompanyContact> FindByCompanyId(int companyId){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.CompanyId.Equals(companyId));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByName(string name){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByMobile(string mobile){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByPosition(string position){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Position.Equals(position));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByTelephone(string telephone){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Telephone.Equals(telephone));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByQQ(string qQ){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByEmail(string email){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Email.Equals(email));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByIntroduction(string introduction){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.Introduction.Equals(introduction));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByOldOaId(string oldOaId){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.OldOaId.Equals(oldOaId));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByOldOaCompanyId(string oldOaCompanyId){
    				return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => o.OldOaCompanyId.Equals(oldOaCompanyId));
    			}
    	public IEnumerable<EmploymentCompanyContact> FindByCriteria(EmploymentCompanyContactCriteria c) {
    		return this.DbContext.EmploymentCompanyContacts.Include("Company").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.CompanyIdSrh.HasValue || o.CompanyId.Equals(c.CompanyIdSrh.Value))
    			&& (!c.CompanyIdFromSrh.HasValue || o.CompanyId >= c.CompanyIdFromSrh.Value)
    			&& (!c.CompanyIdToSrh.HasValue || o.CompanyId <= c.CompanyIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (String.IsNullOrEmpty(c.PositionSrh) || o.Position.Contains(c.PositionSrh))
    			&& (String.IsNullOrEmpty(c.TelephoneSrh) || o.Telephone.Contains(c.TelephoneSrh))
    			&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
    			&& (String.IsNullOrEmpty(c.EmailSrh) || o.Email.Contains(c.EmailSrh))
    			&& (String.IsNullOrEmpty(c.IntroductionSrh) || o.Introduction.Contains(c.IntroductionSrh))
    			&& (String.IsNullOrEmpty(c.OldOaIdSrh) || o.OldOaId.Contains(c.OldOaIdSrh))
    			&& (String.IsNullOrEmpty(c.OldOaCompanyIdSrh) || o.OldOaCompanyId.Contains(c.OldOaCompanyIdSrh))
    
    		);
    	}
    
    }
}
