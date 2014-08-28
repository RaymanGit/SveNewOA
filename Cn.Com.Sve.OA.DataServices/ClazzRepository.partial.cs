using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class ClazzRepository : IClazzRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public ClazzRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Clazz entity) {
    		this.DbContext.Clazzes.AddObject(entity);
    	}
    
    	public void Update(Clazz entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.Semester = entity.Semester;
    			e.StudentQty = entity.StudentQty;
    			e.LimitedQty = entity.LimitedQty;
    			e.TeacherA = entity.TeacherA;
    			e.TeacherB = entity.TeacherB;
    			e.Master = entity.Master;
    			e.Governor = entity.Governor;
    			e.OpenDate = entity.OpenDate;
    			e.ClosedDate = entity.ClosedDate;
    			e.FinishedDate = entity.FinishedDate;
    			e.IsOpen = entity.IsOpen;
    			e.IsClosed = entity.IsClosed;
    			e.IsFinished = entity.IsFinished;
    			e.CreateTime = entity.CreateTime;
    			e.UpdateTime = entity.UpdateTime;
    			e.KickOffDate = entity.KickOffDate;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Clazzes.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Clazz entity) {
    		this.DbContext.Clazzes.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Clazzes.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Clazz> FindAll() {
    		return this.DbContext.Clazzes;
    	}
    	public IEnumerable<Clazz> FindAll2() {
    		return this.DbContext.Clazzes;
    	}
    
    	public Clazz FindById(int id) {
    		return this.DbContext.Clazzes.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Clazz> FindByName(string name){
    				return this.DbContext.Clazzes.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Clazz> FindBySemester(string semester){
    				return this.DbContext.Clazzes.Where(o => o.Semester.Equals(semester));
    			}
    	public IEnumerable<Clazz> FindByStudentQty(int studentQty){
    				return this.DbContext.Clazzes.Where(o => o.StudentQty.Equals(studentQty));
    			}
    	public IEnumerable<Clazz> FindByLimitedQty(int limitedQty){
    				return this.DbContext.Clazzes.Where(o => o.LimitedQty.Equals(limitedQty));
    			}
    	public IEnumerable<Clazz> FindByTeacherA(string teacherA){
    				return this.DbContext.Clazzes.Where(o => o.TeacherA.Equals(teacherA));
    			}
    	public IEnumerable<Clazz> FindByTeacherB(string teacherB){
    				return this.DbContext.Clazzes.Where(o => o.TeacherB.Equals(teacherB));
    			}
    	public IEnumerable<Clazz> FindByMaster(string master){
    				return this.DbContext.Clazzes.Where(o => o.Master.Equals(master));
    			}
    	public IEnumerable<Clazz> FindByGovernor(string governor){
    				return this.DbContext.Clazzes.Where(o => o.Governor.Equals(governor));
    			}
    	public IEnumerable<Clazz> FindByOpenDate(Nullable<System.DateTime> openDate){
    				return this.DbContext.Clazzes.Where(o => o.OpenDate.Value.Equals(openDate.Value));
    			}
    	public IEnumerable<Clazz> FindByClosedDate(Nullable<System.DateTime> closedDate){
    				return this.DbContext.Clazzes.Where(o => o.ClosedDate.Value.Equals(closedDate.Value));
    			}
    	public IEnumerable<Clazz> FindByFinishedDate(Nullable<System.DateTime> finishedDate){
    				return this.DbContext.Clazzes.Where(o => o.FinishedDate.Value.Equals(finishedDate.Value));
    			}
    	public IEnumerable<Clazz> FindByIsOpen(bool isOpen){
    				return this.DbContext.Clazzes.Where(o => o.IsOpen.Equals(isOpen));
    			}
    	public IEnumerable<Clazz> FindByIsClosed(bool isClosed){
    				return this.DbContext.Clazzes.Where(o => o.IsClosed.Equals(isClosed));
    			}
    	public IEnumerable<Clazz> FindByIsFinished(bool isFinished){
    				return this.DbContext.Clazzes.Where(o => o.IsFinished.Equals(isFinished));
    			}
    	public IEnumerable<Clazz> FindByCreateTime(System.DateTime createTime){
    				return this.DbContext.Clazzes.Where(o => o.CreateTime.Equals(createTime));
    			}
    	public IEnumerable<Clazz> FindByUpdateTime(System.DateTime updateTime){
    				return this.DbContext.Clazzes.Where(o => o.UpdateTime.Equals(updateTime));
    			}
    	public IEnumerable<Clazz> FindByKickOffDate(Nullable<System.DateTime> kickOffDate){
    				return this.DbContext.Clazzes.Where(o => o.KickOffDate.Value.Equals(kickOffDate.Value));
    			}
    	public IEnumerable<Clazz> FindByCriteria(ClazzCriteria c) {
    		return this.DbContext.Clazzes.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.SemesterSrh) || o.Semester.Contains(c.SemesterSrh))
    			&& (!c.StudentQtySrh.HasValue || o.StudentQty.Equals(c.StudentQtySrh.Value))
    			&& (!c.StudentQtyFromSrh.HasValue || o.StudentQty >= c.StudentQtyFromSrh.Value)
    			&& (!c.StudentQtyToSrh.HasValue || o.StudentQty <= c.StudentQtyToSrh.Value)
    			&& (!c.LimitedQtySrh.HasValue || o.LimitedQty.Equals(c.LimitedQtySrh.Value))
    			&& (!c.LimitedQtyFromSrh.HasValue || o.LimitedQty >= c.LimitedQtyFromSrh.Value)
    			&& (!c.LimitedQtyToSrh.HasValue || o.LimitedQty <= c.LimitedQtyToSrh.Value)
    			&& (String.IsNullOrEmpty(c.TeacherASrh) || o.TeacherA.Contains(c.TeacherASrh))
    			&& (String.IsNullOrEmpty(c.TeacherBSrh) || o.TeacherB.Contains(c.TeacherBSrh))
    			&& (String.IsNullOrEmpty(c.MasterSrh) || o.Master.Contains(c.MasterSrh))
    			&& (String.IsNullOrEmpty(c.GovernorSrh) || o.Governor.Contains(c.GovernorSrh))
    			&& (!c.OpenDateSrh.HasValue || (o.OpenDate.HasValue 			&& o.OpenDate.Value.Equals(c.OpenDateSrh.Value)))
    			&& (!c.OpenDateFromSrh.HasValue || (o.OpenDate.HasValue 			&& o.OpenDate.Value >= c.OpenDateFromSrh.Value))
    			&& (!c.OpenDateToSrh.HasValue || (o.OpenDate.HasValue 			&& o.OpenDate.Value <= c.OpenDateToSrh.Value))
    			&& (!c.ClosedDateSrh.HasValue || (o.ClosedDate.HasValue 			&& o.ClosedDate.Value.Equals(c.ClosedDateSrh.Value)))
    			&& (!c.ClosedDateFromSrh.HasValue || (o.ClosedDate.HasValue 			&& o.ClosedDate.Value >= c.ClosedDateFromSrh.Value))
    			&& (!c.ClosedDateToSrh.HasValue || (o.ClosedDate.HasValue 			&& o.ClosedDate.Value <= c.ClosedDateToSrh.Value))
    			&& (!c.FinishedDateSrh.HasValue || (o.FinishedDate.HasValue 			&& o.FinishedDate.Value.Equals(c.FinishedDateSrh.Value)))
    			&& (!c.FinishedDateFromSrh.HasValue || (o.FinishedDate.HasValue 			&& o.FinishedDate.Value >= c.FinishedDateFromSrh.Value))
    			&& (!c.FinishedDateToSrh.HasValue || (o.FinishedDate.HasValue 			&& o.FinishedDate.Value <= c.FinishedDateToSrh.Value))
    			&& (!c.IsOpenSrh.HasValue || o.IsOpen.Equals(c.IsOpenSrh.Value))
    			&& (!c.IsClosedSrh.HasValue || o.IsClosed.Equals(c.IsClosedSrh.Value))
    			&& (!c.IsFinishedSrh.HasValue || o.IsFinished.Equals(c.IsFinishedSrh.Value))
    			&& (!c.CreateTimeSrh.HasValue || o.CreateTime.Equals(c.CreateTimeSrh.Value))
    			&& (!c.UpdateTimeSrh.HasValue || o.UpdateTime.Equals(c.UpdateTimeSrh.Value))
    			&& (!c.KickOffDateSrh.HasValue || (o.KickOffDate.HasValue 			&& o.KickOffDate.Value.Equals(c.KickOffDateSrh.Value)))
    			&& (!c.KickOffDateFromSrh.HasValue || (o.KickOffDate.HasValue 			&& o.KickOffDate.Value >= c.KickOffDateFromSrh.Value))
    			&& (!c.KickOffDateToSrh.HasValue || (o.KickOffDate.HasValue 			&& o.KickOffDate.Value <= c.KickOffDateToSrh.Value))
    
    		);
    	}
    
    }
}
