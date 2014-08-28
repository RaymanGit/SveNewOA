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
    public partial class SchoolService : ISchoolService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected ISchoolRepository Repository { get; private set; }
    	public SchoolService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new SchoolRepository(this.Db);
    	}
    	public SchoolService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new SchoolRepository(this.Db);
    	}
    	
    	
    	public void Add(School entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(School entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(School entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(School entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<School> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public School FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<School> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<School> FindByDistrictId(Nullable<int> districtId){
    		return this.Repository.FindByDistrictId(districtId).ToList();
    	}
    	public List<School> FindByIsSold(bool isSold){
    		return this.Repository.FindByIsSold(isSold).ToList();
    	}
    	public List<School> FindByType(string type){
    		return this.Repository.FindByType(type).ToList();
    	}
    	public List<School> FindByLevels(string levels){
    		return this.Repository.FindByLevels(levels).ToList();
    	}
    	public List<School> FindByDevBy(string devBy){
    		return this.Repository.FindByDevBy(devBy).ToList();
    	}
    	public List<School> FindByDevDate(Nullable<System.DateTime> devDate){
    		return this.Repository.FindByDevDate(devDate).ToList();
    	}
    	public List<School> FindByImportant(Nullable<bool> important){
    		return this.Repository.FindByImportant(important).ToList();
    	}
    	public List<School> FindByEquipments(string equipments){
    		return this.Repository.FindByEquipments(equipments).ToList();
    	}
    	public List<School> FindByDaoJiShiPai(Nullable<int> daoJiShiPai){
    		return this.Repository.FindByDaoJiShiPai(daoJiShiPai).ToList();
    	}
    	public List<School> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu){
    		return this.Repository.FindByJiaoShiBiaoYu(jiaoShiBiaoYu).ToList();
    	}
    	public List<School> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu){
    		return this.Repository.FindByShuShiBiaoYu(shuShiBiaoYu).ToList();
    	}
    	public List<School> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu){
    		return this.Repository.FindByShiTangBiaoYu(shiTangBiaoYu).ToList();
    	}
    	public List<School> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu){
    		return this.Repository.FindByLouTiBiaoYu(louTiBiaoYu).ToList();
    	}
    	public List<School> FindByBuTiao(Nullable<int> buTiao){
    		return this.Repository.FindByBuTiao(buTiao).ToList();
    	}
    	public List<School> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<School> FindByHighClassQty(Nullable<int> highClassQty){
    		return this.Repository.FindByHighClassQty(highClassQty).ToList();
    	}
    	public List<School> FindByHighStudentQty(Nullable<int> highStudentQty){
    		return this.Repository.FindByHighStudentQty(highStudentQty).ToList();
    	}
    	public List<School> FindByLowClassQty(Nullable<int> lowClassQty){
    		return this.Repository.FindByLowClassQty(lowClassQty).ToList();
    	}
    	public List<School> FindByLowStudentQty(Nullable<int> lowStudentQty){
    		return this.Repository.FindByLowStudentQty(lowStudentQty).ToList();
    	}
    	public List<School> FindByRemark(string remark){
    		return this.Repository.FindByRemark(remark).ToList();
    	}
    	public List<School> FindByOldOaHuWaiId(string oldOaHuWaiId){
    		return this.Repository.FindByOldOaHuWaiId(oldOaHuWaiId).ToList();
    	}
    	public PagedModel<School> FindByCriteria(SchoolCriteria c) {
    		PagedModel<School> m = new PagedModel<School>();
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
    		if(c.sortname.ToLower().Equals("districtid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DistrictId);
    			}else{
    				r = r.OrderByDescending(o=>o.DistrictId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("issold")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsSold);
    			}else{
    				r = r.OrderByDescending(o=>o.IsSold);
    			}
    		}
    		if(c.sortname.ToLower().Equals("type")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Type);
    			}else{
    				r = r.OrderByDescending(o=>o.Type);
    			}
    		}
    		if(c.sortname.ToLower().Equals("levels")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Levels);
    			}else{
    				r = r.OrderByDescending(o=>o.Levels);
    			}
    		}
    		if(c.sortname.ToLower().Equals("devby")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DevBy);
    			}else{
    				r = r.OrderByDescending(o=>o.DevBy);
    			}
    		}
    		if(c.sortname.ToLower().Equals("devdate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DevDate);
    			}else{
    				r = r.OrderByDescending(o=>o.DevDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("important")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Important);
    			}else{
    				r = r.OrderByDescending(o=>o.Important);
    			}
    		}
    		if(c.sortname.ToLower().Equals("equipments")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Equipments);
    			}else{
    				r = r.OrderByDescending(o=>o.Equipments);
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
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
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
    		if(c.sortname.ToLower().Equals("remark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Remark);
    			}else{
    				r = r.OrderByDescending(o=>o.Remark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoahuwaiid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaHuWaiId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaHuWaiId);
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
