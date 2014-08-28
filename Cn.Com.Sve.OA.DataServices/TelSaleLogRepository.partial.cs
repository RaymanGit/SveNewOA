using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class TelSaleLogRepository : ITelSaleLogRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public TelSaleLogRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(TelSaleLog entity) {
    		this.DbContext.TelSaleLogs.AddObject(entity);
    	}
    
    	public void Update(TelSaleLog entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.CustomerId = entity.CustomerId;
    			e.Content = entity.Content;
    			e.NextTelTime = entity.NextTelTime;
    			e.SalesmanId = entity.SalesmanId;
    			e.TelTime = entity.TelTime;
    			e.IsConvert = entity.IsConvert;
    			e.IsSignUp = entity.IsSignUp;
    			e.ConsultType = entity.ConsultType;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.TelSaleLogs.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(TelSaleLog entity) {
    		this.DbContext.TelSaleLogs.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.TelSaleLogs.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<TelSaleLog> FindAll() {
    		return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman");
    	}
    	public IEnumerable<TelSaleLog> FindAll2() {
    		return this.DbContext.TelSaleLogs;
    	}
    
    	public TelSaleLog FindById(int id) {
    		return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<TelSaleLog> FindByCustomerId(int customerId){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.CustomerId.Equals(customerId));
    			}
    	public IEnumerable<TelSaleLog> FindByContent(string content){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.Content.Equals(content));
    			}
    	public IEnumerable<TelSaleLog> FindByNextTelTime(Nullable<System.DateTime> nextTelTime){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.NextTelTime.Value.Equals(nextTelTime.Value));
    			}
    	public IEnumerable<TelSaleLog> FindBySalesmanId(int salesmanId){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.SalesmanId.Equals(salesmanId));
    			}
    	public IEnumerable<TelSaleLog> FindByTelTime(System.DateTime telTime){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.TelTime.Equals(telTime));
    			}
    	public IEnumerable<TelSaleLog> FindByIsConvert(bool isConvert){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.IsConvert.Equals(isConvert));
    			}
    	public IEnumerable<TelSaleLog> FindByIsSignUp(bool isSignUp){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.IsSignUp.Equals(isSignUp));
    			}
    	public IEnumerable<TelSaleLog> FindByConsultType(string consultType){
    				return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => o.ConsultType.Equals(consultType));
    			}
    	public IEnumerable<TelSaleLog> FindByCriteria(TelSaleLogCriteria c) {
    		return this.DbContext.TelSaleLogs.Include("Customer").Include("Salesman").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.CustomerIdSrh.HasValue || o.CustomerId.Equals(c.CustomerIdSrh.Value))
    			&& (!c.CustomerIdFromSrh.HasValue || o.CustomerId >= c.CustomerIdFromSrh.Value)
    			&& (!c.CustomerIdToSrh.HasValue || o.CustomerId <= c.CustomerIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.ContentSrh) || o.Content.Contains(c.ContentSrh))
    			&& (!c.NextTelTimeSrh.HasValue || (o.NextTelTime.HasValue 			&& o.NextTelTime.Value.Equals(c.NextTelTimeSrh.Value)))
    			&& (!c.NextTelTimeFromSrh.HasValue || (o.NextTelTime.HasValue 			&& o.NextTelTime.Value >= c.NextTelTimeFromSrh.Value))
    			&& (!c.NextTelTimeToSrh.HasValue || (o.NextTelTime.HasValue 			&& o.NextTelTime.Value <= c.NextTelTimeToSrh.Value))
    			&& (!c.SalesmanIdSrh.HasValue || o.SalesmanId.Equals(c.SalesmanIdSrh.Value))
    			&& (!c.SalesmanIdFromSrh.HasValue || o.SalesmanId >= c.SalesmanIdFromSrh.Value)
    			&& (!c.SalesmanIdToSrh.HasValue || o.SalesmanId <= c.SalesmanIdToSrh.Value)
    			&& (!c.TelTimeSrh.HasValue || o.TelTime.Equals(c.TelTimeSrh.Value))
    			&& (!c.IsConvertSrh.HasValue || o.IsConvert.Equals(c.IsConvertSrh.Value))
    			&& (!c.IsSignUpSrh.HasValue || o.IsSignUp.Equals(c.IsSignUpSrh.Value))
    			&& (String.IsNullOrEmpty(c.ConsultTypeSrh) || o.ConsultType.Contains(c.ConsultTypeSrh))
    
    		);
    	}
    
    }
}
