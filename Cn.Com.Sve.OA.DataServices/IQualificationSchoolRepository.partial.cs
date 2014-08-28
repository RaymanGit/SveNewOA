using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IQualificationSchoolRepository  : IRepository<QualificationSchool,int> {
    	IEnumerable<QualificationSchool> FindByName(string name);
    	IEnumerable<QualificationSchool> FindByCriteria(QualificationSchoolCriteria c);
    }
}
