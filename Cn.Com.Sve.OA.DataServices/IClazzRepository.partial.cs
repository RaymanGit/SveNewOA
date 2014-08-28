using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IClazzRepository  : IRepository<Clazz,int> {
    	IEnumerable<Clazz> FindByName(string name);
    	IEnumerable<Clazz> FindBySemester(string semester);
    	IEnumerable<Clazz> FindByStudentQty(int studentQty);
    	IEnumerable<Clazz> FindByLimitedQty(int limitedQty);
    	IEnumerable<Clazz> FindByTeacherA(string teacherA);
    	IEnumerable<Clazz> FindByTeacherB(string teacherB);
    	IEnumerable<Clazz> FindByMaster(string master);
    	IEnumerable<Clazz> FindByGovernor(string governor);
    	IEnumerable<Clazz> FindByOpenDate(Nullable<System.DateTime> openDate);
    	IEnumerable<Clazz> FindByClosedDate(Nullable<System.DateTime> closedDate);
    	IEnumerable<Clazz> FindByFinishedDate(Nullable<System.DateTime> finishedDate);
    	IEnumerable<Clazz> FindByIsOpen(bool isOpen);
    	IEnumerable<Clazz> FindByIsClosed(bool isClosed);
    	IEnumerable<Clazz> FindByIsFinished(bool isFinished);
    	IEnumerable<Clazz> FindByCreateTime(System.DateTime createTime);
    	IEnumerable<Clazz> FindByUpdateTime(System.DateTime updateTime);
    	IEnumerable<Clazz> FindByKickOffDate(Nullable<System.DateTime> kickOffDate);
    	IEnumerable<Clazz> FindByCriteria(ClazzCriteria c);
    }
}
