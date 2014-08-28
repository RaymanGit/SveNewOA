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
    public partial class ImportCustomerService : IImportCustomerService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IImportCustomerRepository Repository { get; private set; }
    	public ImportCustomerService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new ImportCustomerRepository(this.Db);
    	}
    	public ImportCustomerService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new ImportCustomerRepository(this.Db);
    	}
    	
    	
    	public void Add(ImportCustomer entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(ImportCustomer entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(ImportCustomer entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(ImportCustomer entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<ImportCustomer> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public ImportCustomer FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<ImportCustomer> FindByImportKey(string importKey){
    		return this.Repository.FindByImportKey(importKey).ToList();
    	}
    	public List<ImportCustomer> FindBySchoolId(Nullable<int> schoolId){
    		return this.Repository.FindBySchoolId(schoolId).ToList();
    	}
    	public List<ImportCustomer> FindBySchoolName(string schoolName){
    		return this.Repository.FindBySchoolName(schoolName).ToList();
    	}
    	public List<ImportCustomer> FindByLevel(string level){
    		return this.Repository.FindByLevel(level).ToList();
    	}
    	public List<ImportCustomer> FindByMarketYear(int marketYear){
    		return this.Repository.FindByMarketYear(marketYear).ToList();
    	}
    	public List<ImportCustomer> FindByInfoSource(int infoSource){
    		return this.Repository.FindByInfoSource(infoSource).ToList();
    	}
    	public List<ImportCustomer> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<ImportCustomer> FindByGender(string gender){
    		return this.Repository.FindByGender(gender).ToList();
    	}
    	public List<ImportCustomer> FindByTel(string tel){
    		return this.Repository.FindByTel(tel).ToList();
    	}
    	public List<ImportCustomer> FindByProvinceId(Nullable<int> provinceId){
    		return this.Repository.FindByProvinceId(provinceId).ToList();
    	}
    	public List<ImportCustomer> FindByProvinceName(string provinceName){
    		return this.Repository.FindByProvinceName(provinceName).ToList();
    	}
    	public List<ImportCustomer> FindByCityId(Nullable<int> cityId){
    		return this.Repository.FindByCityId(cityId).ToList();
    	}
    	public List<ImportCustomer> FindByCityName(string cityName){
    		return this.Repository.FindByCityName(cityName).ToList();
    	}
    	public List<ImportCustomer> FindByDistrictId(Nullable<int> districtId){
    		return this.Repository.FindByDistrictId(districtId).ToList();
    	}
    	public List<ImportCustomer> FindByDistrictName(string districtName){
    		return this.Repository.FindByDistrictName(districtName).ToList();
    	}
    	public List<ImportCustomer> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<ImportCustomer> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<ImportCustomer> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<ImportCustomer> FindByClazz(string clazz){
    		return this.Repository.FindByClazz(clazz).ToList();
    	}
    	public List<ImportCustomer> FindByScore(Nullable<int> score){
    		return this.Repository.FindByScore(score).ToList();
    	}
    	public List<ImportCustomer> FindByPostcode(string postcode){
    		return this.Repository.FindByPostcode(postcode).ToList();
    	}
    	public List<ImportCustomer> FindByContact(string contact){
    		return this.Repository.FindByContact(contact).ToList();
    	}
    	public List<ImportCustomer> FindByImportType(string importType){
    		return this.Repository.FindByImportType(importType).ToList();
    	}
    	public List<ImportCustomer> FindByIsProcessed(bool isProcessed){
    		return this.Repository.FindByIsProcessed(isProcessed).ToList();
    	}
    	public List<ImportCustomer> FindByErrorMsg(string errorMsg){
    		return this.Repository.FindByErrorMsg(errorMsg).ToList();
    	}
    	public PagedModel<ImportCustomer> FindByCriteria(ImportCustomerCriteria c) {
    		PagedModel<ImportCustomer> m = new PagedModel<ImportCustomer>();
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
    		if(c.sortname.ToLower().Equals("schoolid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SchoolId);
    			}else{
    				r = r.OrderByDescending(o=>o.SchoolId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("schoolname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SchoolName);
    			}else{
    				r = r.OrderByDescending(o=>o.SchoolName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("level")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Level);
    			}else{
    				r = r.OrderByDescending(o=>o.Level);
    			}
    		}
    		if(c.sortname.ToLower().Equals("marketyear")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MarketYear);
    			}else{
    				r = r.OrderByDescending(o=>o.MarketYear);
    			}
    		}
    		if(c.sortname.ToLower().Equals("infosource")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InfoSource);
    			}else{
    				r = r.OrderByDescending(o=>o.InfoSource);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gender")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Gender);
    			}else{
    				r = r.OrderByDescending(o=>o.Gender);
    			}
    		}
    		if(c.sortname.ToLower().Equals("tel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Tel);
    			}else{
    				r = r.OrderByDescending(o=>o.Tel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("provinceid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ProvinceId);
    			}else{
    				r = r.OrderByDescending(o=>o.ProvinceId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("provincename")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ProvinceName);
    			}else{
    				r = r.OrderByDescending(o=>o.ProvinceName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("cityid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CityId);
    			}else{
    				r = r.OrderByDescending(o=>o.CityId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("cityname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CityName);
    			}else{
    				r = r.OrderByDescending(o=>o.CityName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("districtid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DistrictId);
    			}else{
    				r = r.OrderByDescending(o=>o.DistrictId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("districtname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DistrictName);
    			}else{
    				r = r.OrderByDescending(o=>o.DistrictName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
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
    		if(c.sortname.ToLower().Equals("clazz")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Clazz);
    			}else{
    				r = r.OrderByDescending(o=>o.Clazz);
    			}
    		}
    		if(c.sortname.ToLower().Equals("score")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Score);
    			}else{
    				r = r.OrderByDescending(o=>o.Score);
    			}
    		}
    		if(c.sortname.ToLower().Equals("postcode")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Postcode);
    			}else{
    				r = r.OrderByDescending(o=>o.Postcode);
    			}
    		}
    		if(c.sortname.ToLower().Equals("contact")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Contact);
    			}else{
    				r = r.OrderByDescending(o=>o.Contact);
    			}
    		}
    		if(c.sortname.ToLower().Equals("importtype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ImportType);
    			}else{
    				r = r.OrderByDescending(o=>o.ImportType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isprocessed")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsProcessed);
    			}else{
    				r = r.OrderByDescending(o=>o.IsProcessed);
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
