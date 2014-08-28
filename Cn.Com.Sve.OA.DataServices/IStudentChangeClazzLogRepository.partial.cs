using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IStudentChangeClazzLogRepository  : IRepository<StudentChangeClazzLog,int> {
    	IEnumerable<StudentChangeClazzLog> FindByStudentId(int studentId);
    	IEnumerable<StudentChangeClazzLog> FindByOldClazzId(Nullable<int> oldClazzId);
    	IEnumerable<StudentChangeClazzLog> FindByNewClazzId(int newClazzId);
    	IEnumerable<StudentChangeClazzLog> FindByChangeTime(System.DateTime changeTime);
    	IEnumerable<StudentChangeClazzLog> FindByOperatorName(string operatorName);
    	IEnumerable<StudentChangeClazzLog> FindByCriteria(StudentChangeClazzLogCriteria c);
    }
}
