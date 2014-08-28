using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IUserGroupFunctionPermissionRepository  : IRepository<UserGroupFunctionPermission,int> {
    	IEnumerable<UserGroupFunctionPermission> FindByUserGroupId(int userGroupId);
    	IEnumerable<UserGroupFunctionPermission> FindByFunctionId(int functionId);
    	IEnumerable<UserGroupFunctionPermission> FindByCriteria(UserGroupFunctionPermissionCriteria c);
    }
}
