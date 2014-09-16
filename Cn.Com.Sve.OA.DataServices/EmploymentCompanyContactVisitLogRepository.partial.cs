using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class EmploymentCompanyContactVisitLogRepository : IEmploymentCompanyContactVisitLogRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public EmploymentCompanyContactVisitLogRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(EmploymentCompanyContactVisitLog entity) {
    		this.DbContext.EmploymentCompanyContactVisitLogs.AddObject(entity);
    	}
    
    	public void Update(EmploymentCompanyContactVisitLog entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.CompanyContactId = entity.CompanyContactId;
    			e.Time = entity.Time;
    			e.VisitorId = entity.VisitorId;
    			e.Type = entity.Type;
    			e.Content = entity.Content;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.EmploymentCompanyContactVisitLogs.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(EmploymentCompanyContactVisitLog entity) {
    		this.DbContext.EmploymentCompanyContactVisitLogs.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.EmploymentCompanyContactVisitLogs.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindAll() {
    		return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor");
    	}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindAll2() {
    		return this.DbContext.EmploymentCompanyContactVisitLogs;
    	}
    
    	public EmploymentCompanyContactVisitLog FindById(int id) {
    		return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByCompanyContactId(int companyContactId){
    				return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.CompanyContactId.Equals(companyContactId));
    			}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByTime(System.DateTime time){
    				return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.Time.Equals(time));
    			}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByVisitorId(int visitorId){
    				return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.VisitorId.Equals(visitorId));
    			}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByType(string type){
    				return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.Type.Equals(type));
    			}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByContent(string content){
    				return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => o.Content.Equals(content));
    			}
    	public IEnumerable<EmploymentCompanyContactVisitLog> FindByCriteria(EmploymentCompanyContactVisitLogCriteria c) {
    		return this.DbContext.EmploymentCompanyContactVisitLogs.Include("CompanyContact").Include("Visitor").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.CompanyContactIdSrh.HasValue || o.CompanyContactId.Equals(c.CompanyContactIdSrh.Value))
    			&& (!c.CompanyContactIdFromSrh.HasValue || o.CompanyContactId >= c.CompanyContactIdFromSrh.Value)
    			&& (!c.CompanyContactIdToSrh.HasValue || o.CompanyContactId <= c.CompanyContactIdToSrh.Value)
    			&& (!c.TimeSrh.HasValue || o.Time.Equals(c.TimeSrh.Value))
    			&& (!c.VisitorIdSrh.HasValue || o.VisitorId.Equals(c.VisitorIdSrh.Value))
    			&& (!c.VisitorIdFromSrh.HasValue || o.VisitorId >= c.VisitorIdFromSrh.Value)
    			&& (!c.VisitorIdToSrh.HasValue || o.VisitorId <= c.VisitorIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.TypeSrh) || o.Type.Contains(c.TypeSrh))
    			&& (String.IsNullOrEmpty(c.ContentSrh) || o.Content.Contains(c.ContentSrh))
    
    		);
    	}
    
    }
}
