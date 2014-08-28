using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISalesTeamMemberRepository  : IRepository<SalesTeamMember,int> {
    	IEnumerable<SalesTeamMember> FindBySalesTeamId(int salesTeamId);
    	IEnumerable<SalesTeamMember> FindByUserId(int userId);
    	IEnumerable<SalesTeamMember> FindByIsLeader(bool isLeader);
    	IEnumerable<SalesTeamMember> FindByCriteria(SalesTeamMemberCriteria c);
    }
}
