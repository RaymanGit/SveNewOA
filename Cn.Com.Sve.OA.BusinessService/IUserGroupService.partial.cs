using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IUserGroupService {
    	IUnitOfWork Db { get; }
    
    	void Add(UserGroup entity);
    	void Update(UserGroup entity);
    	void Save(UserGroup entity);
    	void Delete(UserGroup entity);
    	void DeleteById(int id);
    	List<UserGroup> FindAll();
    	UserGroup FindById(int id);
    	List<UserGroup> FindByName(string name);
    	PagedModel<UserGroup> FindByCriteria(UserGroupCriteria c);
    }
}
