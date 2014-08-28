using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IUserRepository  : IRepository<User,int> {
    	IEnumerable<User> FindByName(string name);
    	IEnumerable<User> FindByPassword(string password);
    	IEnumerable<User> FindByStatus(string status);
    	IEnumerable<User> FindByLastLoginTime(Nullable<System.DateTime> lastLoginTime);
    	IEnumerable<User> FindByLastLoginIP(string lastLoginIP);
    	IEnumerable<User> FindByDefaultUrl(string defaultUrl);
    	IEnumerable<User> FindByCriteria(UserCriteria c);
    }
}
