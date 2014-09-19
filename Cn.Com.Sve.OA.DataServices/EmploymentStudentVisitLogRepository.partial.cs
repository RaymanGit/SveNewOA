using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class EmploymentStudentVisitLogRepository : IEmploymentStudentVisitLogRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public EmploymentStudentVisitLogRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(EmploymentStudentVisitLog entity) {
    		this.DbContext.EmploymentStudentVisitLogs.AddObject(entity);
    	}
    
    	public void Update(EmploymentStudentVisitLog entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.StudentId = entity.StudentId;
    			e.VisitorId = entity.VisitorId;
    			e.Time = entity.Time;
    			e.Position = entity.Position;
    			e.Objective = entity.Objective;
    			e.Content = entity.Content;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.EmploymentStudentVisitLogs.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(EmploymentStudentVisitLog entity) {
    		this.DbContext.EmploymentStudentVisitLogs.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.EmploymentStudentVisitLogs.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<EmploymentStudentVisitLog> FindAll() {
    		return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor");
    	}
    	public IEnumerable<EmploymentStudentVisitLog> FindAll2() {
    		return this.DbContext.EmploymentStudentVisitLogs;
    	}
    
    	public EmploymentStudentVisitLog FindById(int id) {
    		return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<EmploymentStudentVisitLog> FindByStudentId(int studentId){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.StudentId.Equals(studentId));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByVisitorId(int visitorId){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.VisitorId.Equals(visitorId));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByTime(System.DateTime time){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.Time.Equals(time));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByPosition(string position){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.Position.Equals(position));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByObjective(string objective){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.Objective.Equals(objective));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByContent(string content){
    				return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => o.Content.Equals(content));
    			}
    	public IEnumerable<EmploymentStudentVisitLog> FindByCriteria(EmploymentStudentVisitLogCriteria c) {
    		return this.DbContext.EmploymentStudentVisitLogs.Include("Student").Include("Visitor").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.StudentIdSrh.HasValue || o.StudentId.Equals(c.StudentIdSrh.Value))
    			&& (!c.StudentIdFromSrh.HasValue || o.StudentId >= c.StudentIdFromSrh.Value)
    			&& (!c.StudentIdToSrh.HasValue || o.StudentId <= c.StudentIdToSrh.Value)
    			&& (!c.VisitorIdSrh.HasValue || o.VisitorId.Equals(c.VisitorIdSrh.Value))
    			&& (!c.VisitorIdFromSrh.HasValue || o.VisitorId >= c.VisitorIdFromSrh.Value)
    			&& (!c.VisitorIdToSrh.HasValue || o.VisitorId <= c.VisitorIdToSrh.Value)
    			&& (!c.TimeSrh.HasValue || o.Time.Equals(c.TimeSrh.Value))
    			&& (String.IsNullOrEmpty(c.PositionSrh) || o.Position.Contains(c.PositionSrh))
    			&& (String.IsNullOrEmpty(c.ObjectiveSrh) || o.Objective.Contains(c.ObjectiveSrh))
    			&& (String.IsNullOrEmpty(c.ContentSrh) || o.Content.Contains(c.ContentSrh))
    
    		);
    	}
    
    }
}
