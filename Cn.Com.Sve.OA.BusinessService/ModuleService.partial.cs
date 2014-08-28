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
    public partial class ModuleService : IModuleService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IModuleRepository Repository { get; private set; }
    	public ModuleService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new ModuleRepository(this.Db);
    	}
    	public ModuleService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new ModuleRepository(this.Db);
    	}
    	
    	
    	public void Add(Module entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Module entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Module entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Module entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Module> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Module FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Module> FindByCode(string code){
    		return this.Repository.FindByCode(code).ToList();
    	}
    	public List<Module> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<Module> FindByIcon(string icon){
    		return this.Repository.FindByIcon(icon).ToList();
    	}
    	public PagedModel<Module> FindByCriteria(ModuleCriteria c) {
    		PagedModel<Module> m = new PagedModel<Module>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
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
