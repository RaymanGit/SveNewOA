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
    public partial class SchoolContactService : ISchoolContactService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ISchoolContactRepository Repository { get; private set; }
    	public SchoolContactService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new SchoolContactRepository(this.Db);
    	}
    	public SchoolContactService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new SchoolContactRepository(this.Db);
    	}
    	
    	
    	public void Add(SchoolContact entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(SchoolContact entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(SchoolContact entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(SchoolContact entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<SchoolContact> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public SchoolContact FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<SchoolContact> FindBySchoolId(int schoolId){
    		return this.Repository.FindBySchoolId(schoolId).ToList();
    	}
    	public List<SchoolContact> FindByYear(Nullable<int> year){
    		return this.Repository.FindByYear(year).ToList();
    	}
    	public List<SchoolContact> FindByTitle(string title){
    		return this.Repository.FindByTitle(title).ToList();
    	}
    	public List<SchoolContact> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<SchoolContact> FindByTelephone(string telephone){
    		return this.Repository.FindByTelephone(telephone).ToList();
    	}
    	public List<SchoolContact> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<SchoolContact> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<SchoolContact> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<SchoolContact> FindByRemark(string remark){
    		return this.Repository.FindByRemark(remark).ToList();
    	}
    	public List<SchoolContact> FindByTopFlag(Nullable<int> topFlag){
    		return this.Repository.FindByTopFlag(topFlag).ToList();
    	}
    	public List<SchoolContact> FindByOldOaId(Nullable<int> oldOaId){
    		return this.Repository.FindByOldOaId(oldOaId).ToList();
    	}
    	public PagedModel<SchoolContact> FindByCriteria(SchoolContactCriteria c) {
    		PagedModel<SchoolContact> m = new PagedModel<SchoolContact>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("schoolid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SchoolId);
    			}else{
    				r = r.OrderByDescending(o=>o.SchoolId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("year")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Year);
    			}else{
    				r = r.OrderByDescending(o=>o.Year);
    			}
    		}
    		if(c.sortname.ToLower().Equals("title")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Title);
    			}else{
    				r = r.OrderByDescending(o=>o.Title);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("telephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Telephone);
    			}else{
    				r = r.OrderByDescending(o=>o.Telephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QQ);
    			}else{
    				r = r.OrderByDescending(o=>o.QQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
    			}
    		}
    		if(c.sortname.ToLower().Equals("remark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Remark);
    			}else{
    				r = r.OrderByDescending(o=>o.Remark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("topflag")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TopFlag);
    			}else{
    				r = r.OrderByDescending(o=>o.TopFlag);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaId);
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
