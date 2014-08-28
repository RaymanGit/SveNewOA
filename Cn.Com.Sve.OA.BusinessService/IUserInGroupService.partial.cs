using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IUserInGroupService {
    	IUnitOfWork Db { get; }
    
    	void Add(UserInGroup entity);
    	void Update(UserInGroup entity);
    	void Save(UserInGroup entity);
    	void Delete(UserInGroup entity);
    	void DeleteById(int id);
    	List<UserInGroup> FindAll();
    	UserInGroup FindById(int id);
    	List<UserInGroup> FindByUserGroupId(int userGroupId);
    	List<UserInGroup> FindByUserId(int userId);
    	PagedModel<UserInGroup> FindByCriteria(UserInGroupCriteria c);
    }
}
