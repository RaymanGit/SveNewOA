using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IUserGroupModulePermissionService {
    	IUnitOfWork Db { get; }
    
    	void Add(UserGroupModulePermission entity);
    	void Update(UserGroupModulePermission entity);
    	void Save(UserGroupModulePermission entity);
    	void Delete(UserGroupModulePermission entity);
    	void DeleteById(int id);
    	List<UserGroupModulePermission> FindAll();
    	UserGroupModulePermission FindById(int id);
    	List<UserGroupModulePermission> FindByUserGroupId(int userGroupId);
    	List<UserGroupModulePermission> FindByModuleId(int moduleId);
    	PagedModel<UserGroupModulePermission> FindByCriteria(UserGroupModulePermissionCriteria c);
    }
}
