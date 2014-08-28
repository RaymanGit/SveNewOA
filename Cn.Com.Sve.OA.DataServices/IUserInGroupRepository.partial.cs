using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IUserInGroupRepository  : IRepository<UserInGroup,int> {
    	IEnumerable<UserInGroup> FindByUserGroupId(int userGroupId);
    	IEnumerable<UserInGroup> FindByUserId(int userId);
    	IEnumerable<UserInGroup> FindByCriteria(UserInGroupCriteria c);
    }
}
