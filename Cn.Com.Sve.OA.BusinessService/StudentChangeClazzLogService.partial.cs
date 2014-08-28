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
    public partial class StudentChangeClazzLogService : IStudentChangeClazzLogService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IStudentChangeClazzLogRepository Repository { get; private set; }
    	public StudentChangeClazzLogService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new StudentChangeClazzLogRepository(this.Db);
    	}
    	public StudentChangeClazzLogService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new StudentChangeClazzLogRepository(this.Db);
    	}
    	
    	
    	public void Add(StudentChangeClazzLog entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(StudentChangeClazzLog entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(StudentChangeClazzLog entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(StudentChangeClazzLog entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<StudentChangeClazzLog> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public StudentChangeClazzLog FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<StudentChangeClazzLog> FindByStudentId(int studentId){
    		return this.Repository.FindByStudentId(studentId).ToList();
    	}
    	public List<StudentChangeClazzLog> FindByOldClazzId(Nullable<int> oldClazzId){
    		return this.Repository.FindByOldClazzId(oldClazzId).ToList();
    	}
    	public List<StudentChangeClazzLog> FindByNewClazzId(int newClazzId){
    		return this.Repository.FindByNewClazzId(newClazzId).ToList();
    	}
    	public List<StudentChangeClazzLog> FindByChangeTime(System.DateTime changeTime){
    		return this.Repository.FindByChangeTime(changeTime).ToList();
    	}
    	public List<StudentChangeClazzLog> FindByOperatorName(string operatorName){
    		return this.Repository.FindByOperatorName(operatorName).ToList();
    	}
    	public PagedModel<StudentChangeClazzLog> FindByCriteria(StudentChangeClazzLogCriteria c) {
    		PagedModel<StudentChangeClazzLog> m = new PagedModel<StudentChangeClazzLog>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentId);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldclazzid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldClazzId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldClazzId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("newclazzid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NewClazzId);
    			}else{
    				r = r.OrderByDescending(o=>o.NewClazzId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("changetime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ChangeTime);
    			}else{
    				r = r.OrderByDescending(o=>o.ChangeTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("operatorname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OperatorName);
    			}else{
    				r = r.OrderByDescending(o=>o.OperatorName);
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
