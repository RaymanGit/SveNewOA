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
    public partial class ImportDupliateService : IImportDupliateService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IImportDupliateRepository Repository { get; private set; }
    	public ImportDupliateService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new ImportDupliateRepository(this.Db);
    	}
    	public ImportDupliateService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new ImportDupliateRepository(this.Db);
    	}
    	
    	
    	public void Add(ImportDupliate entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(ImportDupliate entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(ImportDupliate entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(ImportDupliate entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<ImportDupliate> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public ImportDupliate FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<ImportDupliate> FindByImportKey(string importKey){
    		return this.Repository.FindByImportKey(importKey).ToList();
    	}
    	public List<ImportDupliate> FindByCustomerId(Nullable<int> customerId){
    		return this.Repository.FindByCustomerId(customerId).ToList();
    	}
    	public List<ImportDupliate> FindByImportId(Nullable<int> importId){
    		return this.Repository.FindByImportId(importId).ToList();
    	}
    	public List<ImportDupliate> FindBySchoolName(string schoolName){
    		return this.Repository.FindBySchoolName(schoolName).ToList();
    	}
    	public List<ImportDupliate> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<ImportDupliate> FindByTel(string tel){
    		return this.Repository.FindByTel(tel).ToList();
    	}
    	public List<ImportDupliate> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<ImportDupliate> FindByScore(Nullable<int> score){
    		return this.Repository.FindByScore(score).ToList();
    	}
    	public List<ImportDupliate> FindByErrorMsg(string errorMsg){
    		return this.Repository.FindByErrorMsg(errorMsg).ToList();
    	}
    	public PagedModel<ImportDupliate> FindByCriteria(ImportDupliateCriteria c) {
    		PagedModel<ImportDupliate> m = new PagedModel<ImportDupliate>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("importkey")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ImportKey);
    			}else{
    				r = r.OrderByDescending(o=>o.ImportKey);
    			}
    		}
    		if(c.sortname.ToLower().Equals("customerid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CustomerId);
    			}else{
    				r = r.OrderByDescending(o=>o.CustomerId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("importid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ImportId);
    			}else{
    				r = r.OrderByDescending(o=>o.ImportId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("schoolname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SchoolName);
    			}else{
    				r = r.OrderByDescending(o=>o.SchoolName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Tel);
    			}else{
    				r = r.OrderByDescending(o=>o.Tel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("score")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Score);
    			}else{
    				r = r.OrderByDescending(o=>o.Score);
    			}
    		}
    		if(c.sortname.ToLower().Equals("errormsg")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ErrorMsg);
    			}else{
    				r = r.OrderByDescending(o=>o.ErrorMsg);
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
