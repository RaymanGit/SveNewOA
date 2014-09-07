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
    public partial class EmploymentCompanyService : IEmploymentCompanyService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IEmploymentCompanyRepository Repository { get; private set; }
    	public EmploymentCompanyService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new EmploymentCompanyRepository(this.Db);
    	}
    	public EmploymentCompanyService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new EmploymentCompanyRepository(this.Db);
    	}
    	
    	
    	public void Add(EmploymentCompany entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(EmploymentCompany entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(EmploymentCompany entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(EmploymentCompany entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<EmploymentCompany> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public EmploymentCompany FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<EmploymentCompany> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<EmploymentCompany> FindByType(string type){
    		return this.Repository.FindByType(type).ToList();
    	}
    	public List<EmploymentCompany> FindByImportant(string important){
    		return this.Repository.FindByImportant(important).ToList();
    	}
    	public List<EmploymentCompany> FindByWebsite(string website){
    		return this.Repository.FindByWebsite(website).ToList();
    	}
    	public List<EmploymentCompany> FindByTelephone(string telephone){
    		return this.Repository.FindByTelephone(telephone).ToList();
    	}
    	public List<EmploymentCompany> FindByFax(string fax){
    		return this.Repository.FindByFax(fax).ToList();
    	}
    	public List<EmploymentCompany> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<EmploymentCompany> FindByCityId(Nullable<int> cityId){
    		return this.Repository.FindByCityId(cityId).ToList();
    	}
    	public List<EmploymentCompany> FindByIntroduction(string introduction){
    		return this.Repository.FindByIntroduction(introduction).ToList();
    	}
    	public List<EmploymentCompany> FindBySourceType(string sourceType){
    		return this.Repository.FindBySourceType(sourceType).ToList();
    	}
    	public List<EmploymentCompany> FindByReferer(string referer){
    		return this.Repository.FindByReferer(referer).ToList();
    	}
    	public List<EmploymentCompany> FindByUserId(Nullable<int> userId){
    		return this.Repository.FindByUserId(userId).ToList();
    	}
    	public List<EmploymentCompany> FindByEmployedQty(int employedQty){
    		return this.Repository.FindByEmployedQty(employedQty).ToList();
    	}
    	public List<EmploymentCompany> FindByOldOaId(string oldOaId){
    		return this.Repository.FindByOldOaId(oldOaId).ToList();
    	}
    	public List<EmploymentCompany> FindByTempProvId(string tempProvId){
    		return this.Repository.FindByTempProvId(tempProvId).ToList();
    	}
    	public List<EmploymentCompany> FindByTempProvName(string tempProvName){
    		return this.Repository.FindByTempProvName(tempProvName).ToList();
    	}
    	public List<EmploymentCompany> FindByTempCityId(string tempCityId){
    		return this.Repository.FindByTempCityId(tempCityId).ToList();
    	}
    	public List<EmploymentCompany> FindByTempCityName(string tempCityName){
    		return this.Repository.FindByTempCityName(tempCityName).ToList();
    	}
    	public PagedModel<EmploymentCompany> FindByCriteria(EmploymentCompanyCriteria c) {
    		PagedModel<EmploymentCompany> m = new PagedModel<EmploymentCompany>();
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
    		if(c.sortname.ToLower().Equals("type")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Type);
    			}else{
    				r = r.OrderByDescending(o=>o.Type);
    			}
    		}
    		if(c.sortname.ToLower().Equals("important")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Important);
    			}else{
    				r = r.OrderByDescending(o=>o.Important);
    			}
    		}
    		if(c.sortname.ToLower().Equals("website")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Website);
    			}else{
    				r = r.OrderByDescending(o=>o.Website);
    			}
    		}
    		if(c.sortname.ToLower().Equals("telephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Telephone);
    			}else{
    				r = r.OrderByDescending(o=>o.Telephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("fax")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Fax);
    			}else{
    				r = r.OrderByDescending(o=>o.Fax);
    			}
    		}
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
    			}
    		}
    		if(c.sortname.ToLower().Equals("cityid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CityId);
    			}else{
    				r = r.OrderByDescending(o=>o.CityId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("introduction")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Introduction);
    			}else{
    				r = r.OrderByDescending(o=>o.Introduction);
    			}
    		}
    		if(c.sortname.ToLower().Equals("sourcetype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SourceType);
    			}else{
    				r = r.OrderByDescending(o=>o.SourceType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("referer")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Referer);
    			}else{
    				r = r.OrderByDescending(o=>o.Referer);
    			}
    		}
    		if(c.sortname.ToLower().Equals("userid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UserId);
    			}else{
    				r = r.OrderByDescending(o=>o.UserId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("employedqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.EmployedQty);
    			}else{
    				r = r.OrderByDescending(o=>o.EmployedQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tempprovid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TempProvId);
    			}else{
    				r = r.OrderByDescending(o=>o.TempProvId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tempprovname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TempProvName);
    			}else{
    				r = r.OrderByDescending(o=>o.TempProvName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tempcityid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TempCityId);
    			}else{
    				r = r.OrderByDescending(o=>o.TempCityId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tempcityname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TempCityName);
    			}else{
    				r = r.OrderByDescending(o=>o.TempCityName);
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
