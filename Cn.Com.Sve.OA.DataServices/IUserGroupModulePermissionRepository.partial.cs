using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IUserGroupModulePermissionRepository  : IRepository<UserGroupModulePermission,int> {
    	IEnumerable<UserGroupModulePermission> FindByUserGroupId(int userGroupId);
    	IEnumerable<UserGroupModulePermission> FindByModuleId(int moduleId);
    	IEnumerable<UserGroupModulePermission> FindByCriteria(UserGroupModulePermissionCriteria c);
    }
}
