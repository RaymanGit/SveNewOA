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
    public partial class FunctionService : IFunctionService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IFunctionRepository Repository { get; private set; }
    	public FunctionService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new FunctionRepository(this.Db);
    	}
    	public FunctionService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new FunctionRepository(this.Db);
    	}
    	
    	
    	public void Add(Function entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Function entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Function entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Function entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Function> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Function FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Function> FindByModuleId(int moduleId){
    		return this.Repository.FindByModuleId(moduleId).ToList();
    	}
    	public List<Function> FindByCode(string code){
    		return this.Repository.FindByCode(code).ToList();
    	}
    	public List<Function> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<Function> FindByIcon(string icon){
    		return this.Repository.FindByIcon(icon).ToList();
    	}
    	public List<Function> FindByUrl(string url){
    		return this.Repository.FindByUrl(url).ToList();
    	}
    	public List<Function> FindByParentFunctionId(Nullable<int> parentFunctionId){
    		return this.Repository.FindByParentFunctionId(parentFunctionId).ToList();
    	}
    	public List<Function> FindBySeq(Nullable<int> seq){
    		return this.Repository.FindBySeq(seq).ToList();
    	}
    	public PagedModel<Function> FindByCriteria(FunctionCriteria c) {
    		PagedModel<Function> m = new PagedModel<Function>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("moduleid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ModuleId);
    			}else{
    				r = r.OrderByDescending(o=>o.ModuleId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("code")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Code);
    			}else{
    				r = r.OrderByDescending(o=>o.Code);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("icon")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Icon);
    			}else{
    				r = r.OrderByDescending(o=>o.Icon);
    			}
    		}
    		if(c.sortname.ToLower().Equals("url")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Url);
    			}else{
    				r = r.OrderByDescending(o=>o.Url);
    			}
    		}
    		if(c.sortname.ToLower().Equals("parentfunctionid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ParentFunctionId);
    			}else{
    				r = r.OrderByDescending(o=>o.ParentFunctionId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("seq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Seq);
    			}else{
    				r = r.OrderByDescending(o=>o.Seq);
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
