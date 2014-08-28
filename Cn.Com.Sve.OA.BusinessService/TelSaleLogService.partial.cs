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
    public partial class TelSaleLogService : ITelSaleLogService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ITelSaleLogRepository Repository { get; private set; }
    	public TelSaleLogService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new TelSaleLogRepository(this.Db);
    	}
    	public TelSaleLogService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new TelSaleLogRepository(this.Db);
    	}
    	
    	
    	public void Add(TelSaleLog entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(TelSaleLog entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(TelSaleLog entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(TelSaleLog entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<TelSaleLog> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public TelSaleLog FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<TelSaleLog> FindByCustomerId(int customerId){
    		return this.Repository.FindByCustomerId(customerId).ToList();
    	}
    	public List<TelSaleLog> FindByContent(string content){
    		return this.Repository.FindByContent(content).ToList();
    	}
    	public List<TelSaleLog> FindByNextTelTime(Nullable<System.DateTime> nextTelTime){
    		return this.Repository.FindByNextTelTime(nextTelTime).ToList();
    	}
    	public List<TelSaleLog> FindBySalesmanId(int salesmanId){
    		return this.Repository.FindBySalesmanId(salesmanId).ToList();
    	}
    	public List<TelSaleLog> FindByTelTime(System.DateTime telTime){
    		return this.Repository.FindByTelTime(telTime).ToList();
    	}
    	public List<TelSaleLog> FindByIsConvert(bool isConvert){
    		return this.Repository.FindByIsConvert(isConvert).ToList();
    	}
    	public List<TelSaleLog> FindByIsSignUp(bool isSignUp){
    		return this.Repository.FindByIsSignUp(isSignUp).ToList();
    	}
    	public List<TelSaleLog> FindByConsultType(string consultType){
    		return this.Repository.FindByConsultType(consultType).ToList();
    	}
    	public PagedModel<TelSaleLog> FindByCriteria(TelSaleLogCriteria c) {
    		PagedModel<TelSaleLog> m = new PagedModel<TelSaleLog>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("customerid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CustomerId);
    			}else{
    				r = r.OrderByDescending(o=>o.CustomerId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("content")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Content);
    			}else{
    				r = r.OrderByDescending(o=>o.Content);
    			}
    		}
    		if(c.sortname.ToLower().Equals("nextteltime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NextTelTime);
    			}else{
    				r = r.OrderByDescending(o=>o.NextTelTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("salesmanid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SalesmanId);
    			}else{
    				r = r.OrderByDescending(o=>o.SalesmanId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teltime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TelTime);
    			}else{
    				r = r.OrderByDescending(o=>o.TelTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isconvert")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsConvert);
    			}else{
    				r = r.OrderByDescending(o=>o.IsConvert);
    			}
    		}
    		if(c.sortname.ToLower().Equals("issignup")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsSignUp);
    			}else{
    				r = r.OrderByDescending(o=>o.IsSignUp);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consulttype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ConsultType);
    			}else{
    				r = r.OrderByDescending(o=>o.ConsultType);
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
