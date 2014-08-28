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
    public partial class SalesTeamMemberService : ISalesTeamMemberService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ISalesTeamMemberRepository Repository { get; private set; }
    	public SalesTeamMemberService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new SalesTeamMemberRepository(this.Db);
    	}
    	public SalesTeamMemberService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new SalesTeamMemberRepository(this.Db);
    	}
    	
    	
    	public void Add(SalesTeamMember entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(SalesTeamMember entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(SalesTeamMember entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(SalesTeamMember entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<SalesTeamMember> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public SalesTeamMember FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<SalesTeamMember> FindBySalesTeamId(int salesTeamId){
    		return this.Repository.FindBySalesTeamId(salesTeamId).ToList();
    	}
    	public List<SalesTeamMember> FindByUserId(int userId){
    		return this.Repository.FindByUserId(userId).ToList();
    	}
    	public List<SalesTeamMember> FindByIsLeader(bool isLeader){
    		return this.Repository.FindByIsLeader(isLeader).ToList();
    	}
    	public PagedModel<SalesTeamMember> FindByCriteria(SalesTeamMemberCriteria c) {
    		PagedModel<SalesTeamMember> m = new PagedModel<SalesTeamMember>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("salesteamid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SalesTeamId);
    			}else{
    				r = r.OrderByDescending(o=>o.SalesTeamId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("userid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UserId);
    			}else{
    				r = r.OrderByDescending(o=>o.UserId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isleader")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsLeader);
    			}else{
    				r = r.OrderByDescending(o=>o.IsLeader);
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
