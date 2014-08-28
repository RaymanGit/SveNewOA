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
    public partial class ClazzService : IClazzService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IClazzRepository Repository { get; private set; }
    	public ClazzService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new ClazzRepository(this.Db);
    	}
    	public ClazzService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new ClazzRepository(this.Db);
    	}
    	
    	
    	public void Add(Clazz entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Clazz entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Clazz entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Clazz entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Clazz> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Clazz FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Clazz> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<Clazz> FindBySemester(string semester){
    		return this.Repository.FindBySemester(semester).ToList();
    	}
    	public List<Clazz> FindByStudentQty(int studentQty){
    		return this.Repository.FindByStudentQty(studentQty).ToList();
    	}
    	public List<Clazz> FindByLimitedQty(int limitedQty){
    		return this.Repository.FindByLimitedQty(limitedQty).ToList();
    	}
    	public List<Clazz> FindByTeacherA(string teacherA){
    		return this.Repository.FindByTeacherA(teacherA).ToList();
    	}
    	public List<Clazz> FindByTeacherB(string teacherB){
    		return this.Repository.FindByTeacherB(teacherB).ToList();
    	}
    	public List<Clazz> FindByMaster(string master){
    		return this.Repository.FindByMaster(master).ToList();
    	}
    	public List<Clazz> FindByGovernor(string governor){
    		return this.Repository.FindByGovernor(governor).ToList();
    	}
    	public List<Clazz> FindByOpenDate(Nullable<System.DateTime> openDate){
    		return this.Repository.FindByOpenDate(openDate).ToList();
    	}
    	public List<Clazz> FindByClosedDate(Nullable<System.DateTime> closedDate){
    		return this.Repository.FindByClosedDate(closedDate).ToList();
    	}
    	public List<Clazz> FindByFinishedDate(Nullable<System.DateTime> finishedDate){
    		return this.Repository.FindByFinishedDate(finishedDate).ToList();
    	}
    	public List<Clazz> FindByIsOpen(bool isOpen){
    		return this.Repository.FindByIsOpen(isOpen).ToList();
    	}
    	public List<Clazz> FindByIsClosed(bool isClosed){
    		return this.Repository.FindByIsClosed(isClosed).ToList();
    	}
    	public List<Clazz> FindByIsFinished(bool isFinished){
    		return this.Repository.FindByIsFinished(isFinished).ToList();
    	}
    	public List<Clazz> FindByCreateTime(System.DateTime createTime){
    		return this.Repository.FindByCreateTime(createTime).ToList();
    	}
    	public List<Clazz> FindByUpdateTime(System.DateTime updateTime){
    		return this.Repository.FindByUpdateTime(updateTime).ToList();
    	}
    	public List<Clazz> FindByKickOffDate(Nullable<System.DateTime> kickOffDate){
    		return this.Repository.FindByKickOffDate(kickOffDate).ToList();
    	}
    	public PagedModel<Clazz> FindByCriteria(ClazzCriteria c) {
    		PagedModel<Clazz> m = new PagedModel<Clazz>();
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
    		if(c.sortname.ToLower().Equals("semester")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Semester);
    			}else{
    				r = r.OrderByDescending(o=>o.Semester);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentQty);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("limitedqty")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LimitedQty);
    			}else{
    				r = r.OrderByDescending(o=>o.LimitedQty);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teachera")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherA);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherA);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teacherb")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherB);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherB);
    			}
    		}
    		if(c.sortname.ToLower().Equals("master")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Master);
    			}else{
    				r = r.OrderByDescending(o=>o.Master);
    			}
    		}
    		if(c.sortname.ToLower().Equals("governor")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Governor);
    			}else{
    				r = r.OrderByDescending(o=>o.Governor);
    			}
    		}
    		if(c.sortname.ToLower().Equals("opendate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OpenDate);
    			}else{
    				r = r.OrderByDescending(o=>o.OpenDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("closeddate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ClosedDate);
    			}else{
    				r = r.OrderByDescending(o=>o.ClosedDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("finisheddate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.FinishedDate);
    			}else{
    				r = r.OrderByDescending(o=>o.FinishedDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isopen")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsOpen);
    			}else{
    				r = r.OrderByDescending(o=>o.IsOpen);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isclosed")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsClosed);
    			}else{
    				r = r.OrderByDescending(o=>o.IsClosed);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isfinished")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsFinished);
    			}else{
    				r = r.OrderByDescending(o=>o.IsFinished);
    			}
    		}
    		if(c.sortname.ToLower().Equals("createtime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CreateTime);
    			}else{
    				r = r.OrderByDescending(o=>o.CreateTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("updatetime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.UpdateTime);
    			}else{
    				r = r.OrderByDescending(o=>o.UpdateTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("kickoffdate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.KickOffDate);
    			}else{
    				r = r.OrderByDescending(o=>o.KickOffDate);
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
