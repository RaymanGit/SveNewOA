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
    public partial class SchoolAdService : ISchoolAdService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ISchoolAdRepository Repository { get; private set; }
    	public SchoolAdService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new SchoolAdRepository(this.Db);
    	}
    	public SchoolAdService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new SchoolAdRepository(this.Db);
    	}
    	
    	
    	public void Add(SchoolAd entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(SchoolAd entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(SchoolAd entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(SchoolAd entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<SchoolAd> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public SchoolAd FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<SchoolAd> FindBySchoolId(int schoolId){
    		return this.Repository.FindBySchoolId(schoolId).ToList();
    	}
    	public List<SchoolAd> FindByYear(int year){
    		return this.Repository.FindByYear(year).ToList();
    	}
    	public List<SchoolAd> FindByHighClassQty(Nullable<int> highClassQty){
    		return this.Repository.FindByHighClassQty(highClassQty).ToList();
    	}
    	public List<SchoolAd> FindByHighStudentQty(Nullable<int> highStudentQty){
    		return this.Repository.FindByHighStudentQty(highStudentQty).ToList();
    	}
    	public List<SchoolAd> FindByLowClassQty(Nullable<int> lowClassQty){
    		return this.Repository.FindByLowClassQty(lowClassQty).ToList();
    	}
    	public List<SchoolAd> FindByLowStudentQty(Nullable<int> lowStudentQty){
    		return this.Repository.FindByLowStudentQty(lowStudentQty).ToList();
    	}
    	public List<SchoolAd> FindByDaoJiShiPai(Nullable<int> daoJiShiPai){
    		return this.Repository.FindByDaoJiShiPai(daoJiShiPai).ToList();
    	}
    	public List<SchoolAd> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu){
    		return this.Repository.FindByJiaoShiBiaoYu(jiaoShiBiaoYu).ToList();
    	}
    	public List<SchoolAd> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu){
    		return this.Repository.FindByShuShiBiaoYu(shuShiBiaoYu).ToList();
    	}
    	public List<SchoolAd> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu){
    		return this.Repository.FindByShiTangBiaoYu(shiTangBiaoYu).ToList();
    	}
    	public List<SchoolAd> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu){
    		return this.Repository.FindByLouTiBiaoYu(louTiBiaoYu).ToList();
    	}
    	public List<SchoolAd> FindByBuTiao(Nullable<int> buTiao){
    		return this.Repository.FindByBuTiao(buTiao).ToList();
    	}
    	public List<SchoolAd> FindByTaiLi(Nullable<int> taiLi){
    		return this.Repository.FindByTaiLi(taiLi).ToList();
    	}
    	public List<SchoolAd> FindByGuaLi(Nullable<int> guaLi){
    		return this.Repository.FindByGuaLi(guaLi).ToList();
    	}
    	public PagedModel<SchoolAd> FindByCriteria(SchoolAdCriteria c) {
    		PagedModel<SchoolAd> m = new PagedModel<SchoolAd>();
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
    		if(c.sortname.ToLower().Equals("highclassqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HighClassQty);
    			}else{
    				r = r.OrderByDescending(o=>o.HighClassQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("highstudentqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HighStudentQty);
    			}else{
    				r = r.OrderByDescending(o=>o.HighStudentQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lowclassqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LowClassQty);
    			}else{
    				r = r.OrderByDescending(o=>o.LowClassQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lowstudentqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LowStudentQty);
    			}else{
    				r = r.OrderByDescending(o=>o.LowStudentQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("daojishipai")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DaoJiShiPai);
    			}else{
    				r = r.OrderByDescending(o=>o.DaoJiShiPai);
    			}
    		}
    		if(c.sortname.ToLower().Equals("jiaoshibiaoyu")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.JiaoShiBiaoYu);
    			}else{
    				r = r.OrderByDescending(o=>o.JiaoShiBiaoYu);
    			}
    		}
    		if(c.sortname.ToLower().Equals("shushibiaoyu")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ShuShiBiaoYu);
    			}else{
    				r = r.OrderByDescending(o=>o.ShuShiBiaoYu);
    			}
    		}
    		if(c.sortname.ToLower().Equals("shitangbiaoyu")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ShiTangBiaoYu);
    			}else{
    				r = r.OrderByDescending(o=>o.ShiTangBiaoYu);
    			}
    		}
    		if(c.sortname.ToLower().Equals("loutibiaoyu")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LouTiBiaoYu);
    			}else{
    				r = r.OrderByDescending(o=>o.LouTiBiaoYu);
    			}
    		}
    		if(c.sortname.ToLower().Equals("butiao")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.BuTiao);
    			}else{
    				r = r.OrderByDescending(o=>o.BuTiao);
    			}
    		}
    		if(c.sortname.ToLower().Equals("taili")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TaiLi);
    			}else{
    				r = r.OrderByDescending(o=>o.TaiLi);
    			}
    		}
    		if(c.sortname.ToLower().Equals("guali")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GuaLi);
    			}else{
    				r = r.OrderByDescending(o=>o.GuaLi);
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
