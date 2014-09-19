using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IEmploymentStudentVisitLogRepository  : IRepository<EmploymentStudentVisitLog,int> {
    	IEnumerable<EmploymentStudentVisitLog> FindByStudentId(int studentId);
    	IEnumerable<EmploymentStudentVisitLog> FindByVisitorId(int visitorId);
    	IEnumerable<EmploymentStudentVisitLog> FindByTime(System.DateTime time);
    	IEnumerable<EmploymentStudentVisitLog> FindByPosition(string position);
    	IEnumerable<EmploymentStudentVisitLog> FindByObjective(string objective);
    	IEnumerable<EmploymentStudentVisitLog> FindByContent(string content);
    	IEnumerable<EmploymentStudentVisitLog> FindByCriteria(EmploymentStudentVisitLogCriteria c);
    }
}
