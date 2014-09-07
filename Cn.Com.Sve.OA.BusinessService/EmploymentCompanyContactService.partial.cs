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
    public partial class EmploymentCompanyContactService : IEmploymentCompanyContactService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IEmploymentCompanyContactRepository Repository { get; private set; }
    	public EmploymentCompanyContactService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new EmploymentCompanyContactRepository(this.Db);
    	}
    	public EmploymentCompanyContactService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new EmploymentCompanyContactRepository(this.Db);
    	}
    	
    	
    	public void Add(EmploymentCompanyContact entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(EmploymentCompanyContact entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(EmploymentCompanyContact entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(EmploymentCompanyContact entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<EmploymentCompanyContact> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public EmploymentCompanyContact FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<EmploymentCompanyContact> FindByCompanyId(int companyId){
    		return this.Repository.FindByCompanyId(companyId).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByPosition(string position){
    		return this.Repository.FindByPosition(position).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByTelephone(string telephone){
    		return this.Repository.FindByTelephone(telephone).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByEmail(string email){
    		return this.Repository.FindByEmail(email).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByIntroduction(string introduction){
    		return this.Repository.FindByIntroduction(introduction).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByOldOaId(string oldOaId){
    		return this.Repository.FindByOldOaId(oldOaId).ToList();
    	}
    	public List<EmploymentCompanyContact> FindByOldOaCompanyId(string oldOaCompanyId){
    		return this.Repository.FindByOldOaCompanyId(oldOaCompanyId).ToList();
    	}
    	public PagedModel<EmploymentCompanyContact> FindByCriteria(EmploymentCompanyContactCriteria c) {
    		PagedModel<EmploymentCompanyContact> m = new PagedModel<EmploymentCompanyContact>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("companyid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CompanyId);
    			}else{
    				r = r.OrderByDescending(o=>o.CompanyId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("position")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Position);
    			}else{
    				r = r.OrderByDescending(o=>o.Position);
    			}
    		}
    		if(c.sortname.ToLower().Equals("telephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Telephone);
    			}else{
    				r = r.OrderByDescending(o=>o.Telephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QQ);
    			}else{
    				r = r.OrderByDescending(o=>o.QQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("email")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Email);
    			}else{
    				r = r.OrderByDescending(o=>o.Email);
    			}
    		}
    		if(c.sortname.ToLower().Equals("introduction")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Introduction);
    			}else{
    				r = r.OrderByDescending(o=>o.Introduction);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoacompanyid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaCompanyId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaCompanyId);
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
