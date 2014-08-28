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
    public partial class DistrictService : IDistrictService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IDistrictRepository Repository { get; private set; }
    	public DistrictService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new DistrictRepository(this.Db);
    	}
    	public DistrictService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new DistrictRepository(this.Db);
    	}
    	
    	
    	public void Add(District entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(District entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(District entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(District entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<District> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public District FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<District> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<District> FindByCityId(int cityId){
    		return this.Repository.FindByCityId(cityId).ToList();
    	}
    	public List<District> FindByPhonePrefix(string phonePrefix){
    		return this.Repository.FindByPhonePrefix(phonePrefix).ToList();
    	}
    	public List<District> FindByPostcode(string postcode){
    		return this.Repository.FindByPostcode(postcode).ToList();
    	}
    	public PagedModel<District> FindByCriteria(DistrictCriteria c) {
    		PagedModel<District> m = new PagedModel<District>();
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
    		if(c.sortname.ToLower().Equals("cityid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CityId);
    			}else{
    				r = r.OrderByDescending(o=>o.CityId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("phoneprefix")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PhonePrefix);
    			}else{
    				r = r.OrderByDescending(o=>o.PhonePrefix);
    			}
    		}
    		if(c.sortname.ToLower().Equals("postcode")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Postcode);
    			}else{
    				r = r.OrderByDescending(o=>o.Postcode);
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
