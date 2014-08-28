using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IUserService {
    	IUnitOfWork Db { get; }
    
    	void Add(User entity);
    	void Update(User entity);
    	void Save(User entity);
    	void Delete(User entity);
    	void DeleteById(int id);
    	List<User> FindAll();
    	User FindById(int id);
    	List<User> FindByName(string name);
    	List<User> FindByPassword(string password);
    	List<User> FindByStatus(string status);
    	List<User> FindByLastLoginTime(Nullable<System.DateTime> lastLoginTime);
    	List<User> FindByLastLoginIP(string lastLoginIP);
    	List<User> FindByDefaultUrl(string defaultUrl);
    	PagedModel<User> FindByCriteria(UserCriteria c);
    }
}
