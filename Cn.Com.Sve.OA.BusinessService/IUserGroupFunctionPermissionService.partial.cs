using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IUserGroupFunctionPermissionService {
    	IUnitOfWork Db { get; }
    
    	void Add(UserGroupFunctionPermission entity);
    	void Update(UserGroupFunctionPermission entity);
    	void Save(UserGroupFunctionPermission entity);
    	void Delete(UserGroupFunctionPermission entity);
    	void DeleteById(int id);
    	List<UserGroupFunctionPermission> FindAll();
    	UserGroupFunctionPermission FindById(int id);
    	List<UserGroupFunctionPermission> FindByUserGroupId(int userGroupId);
    	List<UserGroupFunctionPermission> FindByFunctionId(int functionId);
    	PagedModel<UserGroupFunctionPermission> FindByCriteria(UserGroupFunctionPermissionCriteria c);
    }
}
