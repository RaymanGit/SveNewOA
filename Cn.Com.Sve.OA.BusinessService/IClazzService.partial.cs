using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IClazzService {
    	IUnitOfWork Db { get; }
    
    	void Add(Clazz entity);
    	void Update(Clazz entity);
    	void Save(Clazz entity);
    	void Delete(Clazz entity);
    	void DeleteById(int id);
    	List<Clazz> FindAll();
    	Clazz FindById(int id);
    	List<Clazz> FindByName(string name);
    	List<Clazz> FindBySemester(string semester);
    	List<Clazz> FindByStudentQty(int studentQty);
    	List<Clazz> FindByLimitedQty(int limitedQty);
    	List<Clazz> FindByTeacherA(string teacherA);
    	List<Clazz> FindByTeacherB(string teacherB);
    	List<Clazz> FindByMaster(string master);
    	List<Clazz> FindByGovernor(string governor);
    	List<Clazz> FindByOpenDate(Nullable<System.DateTime> openDate);
    	List<Clazz> FindByClosedDate(Nullable<System.DateTime> closedDate);
    	List<Clazz> FindByFinishedDate(Nullable<System.DateTime> finishedDate);
    	List<Clazz> FindByIsOpen(bool isOpen);
    	List<Clazz> FindByIsClosed(bool isClosed);
    	List<Clazz> FindByIsFinished(bool isFinished);
    	List<Clazz> FindByCreateTime(System.DateTime createTime);
    	List<Clazz> FindByUpdateTime(System.DateTime updateTime);
    	List<Clazz> FindByKickOffDate(Nullable<System.DateTime> kickOffDate);
    	PagedModel<Clazz> FindByCriteria(ClazzCriteria c);
    }
}
