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
    public partial class KnowledgeService : IKnowledgeService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IKnowledgeRepository Repository { get; private set; }
    	public KnowledgeService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new KnowledgeRepository(this.Db);
    	}
    	public KnowledgeService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new KnowledgeRepository(this.Db);
    	}
    	
    	
    	public void Add(Knowledge entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Knowledge entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Knowledge entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Knowledge entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Knowledge> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Knowledge FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Knowledge> FindBySubject(string subject){
    		return this.Repository.FindBySubject(subject).ToList();
    	}
    	public List<Knowledge> FindByContent(string content){
    		return this.Repository.FindByContent(content).ToList();
    	}
    	public List<Knowledge> FindByKnowledgeType(string knowledgeType){
    		return this.Repository.FindByKnowledgeType(knowledgeType).ToList();
    	}
    	public PagedModel<Knowledge> FindByCriteria(KnowledgeCriteria c) {
    		PagedModel<Knowledge> m = new PagedModel<Knowledge>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("subject")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Subject);
    			}else{
    				r = r.OrderByDescending(o=>o.Subject);
    			}
    		}
    		if(c.sortname.ToLower().Equals("content")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Content);
    			}else{
    				r = r.OrderByDescending(o=>o.Content);
    			}
    		}
    		if(c.sortname.ToLower().Equals("knowledgetype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.KnowledgeType);
    			}else{
    				r = r.OrderByDescending(o=>o.KnowledgeType);
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
