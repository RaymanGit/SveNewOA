using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class StudentChangeClazzLogRepository : IStudentChangeClazzLogRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public StudentChangeClazzLogRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(StudentChangeClazzLog entity) {
    		this.DbContext.StudentChangeClazzLogs.AddObject(entity);
    	}
    
    	public void Update(StudentChangeClazzLog entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.StudentId = entity.StudentId;
    			e.OldClazzId = entity.OldClazzId;
    			e.NewClazzId = entity.NewClazzId;
    			e.ChangeTime = entity.ChangeTime;
    			e.OperatorName = entity.OperatorName;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.StudentChangeClazzLogs.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(StudentChangeClazzLog entity) {
    		this.DbContext.StudentChangeClazzLogs.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.StudentChangeClazzLogs.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<StudentChangeClazzLog> FindAll() {
    		return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student");
    	}
    	public IEnumerable<StudentChangeClazzLog> FindAll2() {
    		return this.DbContext.StudentChangeClazzLogs;
    	}
    
    	public StudentChangeClazzLog FindById(int id) {
    		return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<StudentChangeClazzLog> FindByStudentId(int studentId){
    				return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => o.StudentId.Equals(studentId));
    			}
    	public IEnumerable<StudentChangeClazzLog> FindByOldClazzId(Nullable<int> oldClazzId){
    				return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => o.OldClazzId.Value.Equals(oldClazzId.Value));
    			}
    	public IEnumerable<StudentChangeClazzLog> FindByNewClazzId(int newClazzId){
    				return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => o.NewClazzId.Equals(newClazzId));
    			}
    	public IEnumerable<StudentChangeClazzLog> FindByChangeTime(System.DateTime changeTime){
    				return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => o.ChangeTime.Equals(changeTime));
    			}
    	public IEnumerable<StudentChangeClazzLog> FindByOperatorName(string operatorName){
    				return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => o.OperatorName.Equals(operatorName));
    			}
    	public IEnumerable<StudentChangeClazzLog> FindByCriteria(StudentChangeClazzLogCriteria c) {
    		return this.DbContext.StudentChangeClazzLogs.Include("OldClazz").Include("NewClazz").Include("Student").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.StudentIdSrh.HasValue || o.StudentId.Equals(c.StudentIdSrh.Value))
    			&& (!c.StudentIdFromSrh.HasValue || o.StudentId >= c.StudentIdFromSrh.Value)
    			&& (!c.StudentIdToSrh.HasValue || o.StudentId <= c.StudentIdToSrh.Value)
    			&& (!c.OldClazzIdSrh.HasValue || (o.OldClazzId.HasValue 			&& o.OldClazzId.Value.Equals(c.OldClazzIdSrh.Value)))
    			&& (!c.OldClazzIdFromSrh.HasValue || (o.OldClazzId.HasValue 			&& o.OldClazzId.Value >= c.OldClazzIdFromSrh.Value))
    			&& (!c.OldClazzIdToSrh.HasValue || (o.OldClazzId.HasValue 			&& o.OldClazzId.Value <= c.OldClazzIdToSrh.Value))
    			&& (!c.NewClazzIdSrh.HasValue || o.NewClazzId.Equals(c.NewClazzIdSrh.Value))
    			&& (!c.NewClazzIdFromSrh.HasValue || o.NewClazzId >= c.NewClazzIdFromSrh.Value)
    			&& (!c.NewClazzIdToSrh.HasValue || o.NewClazzId <= c.NewClazzIdToSrh.Value)
    			&& (!c.ChangeTimeSrh.HasValue || o.ChangeTime.Equals(c.ChangeTimeSrh.Value))
    			&& (String.IsNullOrEmpty(c.OperatorNameSrh) || o.OperatorName.Contains(c.OperatorNameSrh))
    
    		);
    	}
    
    }
}
