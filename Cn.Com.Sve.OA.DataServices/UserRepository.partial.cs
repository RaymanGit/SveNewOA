using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class UserRepository : IUserRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public UserRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(User entity) {
    		this.DbContext.Users.AddObject(entity);
    	}
    
    	public void Update(User entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.Password = entity.Password;
    			e.Status = entity.Status;
    			e.LastLoginTime = entity.LastLoginTime;
    			e.LastLoginIP = entity.LastLoginIP;
    			e.DefaultUrl = entity.DefaultUrl;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Users.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(User entity) {
    		this.DbContext.Users.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Users.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<User> FindAll() {
    		return this.DbContext.Users;
    	}
    	public IEnumerable<User> FindAll2() {
    		return this.DbContext.Users;
    	}
    
    	public User FindById(int id) {
    		return this.DbContext.Users.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<User> FindByName(string name){
    				return this.DbContext.Users.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<User> FindByPassword(string password){
    				return this.DbContext.Users.Where(o => o.Password.Equals(password));
    			}
    	public IEnumerable<User> FindByStatus(string status){
    				return this.DbContext.Users.Where(o => o.Status.Equals(status));
    			}
    	public IEnumerable<User> FindByLastLoginTime(Nullable<System.DateTime> lastLoginTime){
    				return this.DbContext.Users.Where(o => o.LastLoginTime.Value.Equals(lastLoginTime.Value));
    			}
    	public IEnumerable<User> FindByLastLoginIP(string lastLoginIP){
    				return this.DbContext.Users.Where(o => o.LastLoginIP.Equals(lastLoginIP));
    			}
    	public IEnumerable<User> FindByDefaultUrl(string defaultUrl){
    				return this.DbContext.Users.Where(o => o.DefaultUrl.Equals(defaultUrl));
    			}
    	public IEnumerable<User> FindByCriteria(UserCriteria c) {
    		return this.DbContext.Users.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.PasswordSrh) || o.Password.Contains(c.PasswordSrh))
    			&& (String.IsNullOrEmpty(c.StatusSrh) || o.Status.Contains(c.StatusSrh))
    			&& (!c.LastLoginTimeSrh.HasValue || (o.LastLoginTime.HasValue 			&& o.LastLoginTime.Value.Equals(c.LastLoginTimeSrh.Value)))
    			&& (!c.LastLoginTimeFromSrh.HasValue || (o.LastLoginTime.HasValue 			&& o.LastLoginTime.Value >= c.LastLoginTimeFromSrh.Value))
    			&& (!c.LastLoginTimeToSrh.HasValue || (o.LastLoginTime.HasValue 			&& o.LastLoginTime.Value <= c.LastLoginTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.LastLoginIPSrh) || o.LastLoginIP.Contains(c.LastLoginIPSrh))
    			&& (String.IsNullOrEmpty(c.DefaultUrlSrh) || o.DefaultUrl.Contains(c.DefaultUrlSrh))
    
    		);
    	}
    
    }
}
