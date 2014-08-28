using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISupervisorRepository  : IRepository<Supervisor,int> {
    	IEnumerable<Supervisor> FindByUserId(int userId);
    	IEnumerable<Supervisor> FindByType(string type);
    	IEnumerable<Supervisor> FindByCriteria(SupervisorCriteria c);
    }
}
