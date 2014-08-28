using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISalesTeamRepository  : IRepository<SalesTeam,int> {
    	IEnumerable<SalesTeam> FindByName(string name);
    	IEnumerable<SalesTeam> FindByCriteria(SalesTeamCriteria c);
    }
}
