using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IStudentChangeClazzLogService {
    	IUnitOfWork Db { get; }
    
    	void Add(StudentChangeClazzLog entity);
    	void Update(StudentChangeClazzLog entity);
    	void Save(StudentChangeClazzLog entity);
    	void Delete(StudentChangeClazzLog entity);
    	void DeleteById(int id);
    	List<StudentChangeClazzLog> FindAll();
    	StudentChangeClazzLog FindById(int id);
    	List<StudentChangeClazzLog> FindByStudentId(int studentId);
    	List<StudentChangeClazzLog> FindByOldClazzId(Nullable<int> oldClazzId);
    	List<StudentChangeClazzLog> FindByNewClazzId(int newClazzId);
    	List<StudentChangeClazzLog> FindByChangeTime(System.DateTime changeTime);
    	List<StudentChangeClazzLog> FindByOperatorName(string operatorName);
    	PagedModel<StudentChangeClazzLog> FindByCriteria(StudentChangeClazzLogCriteria c);
    }
}
