using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SalesTeamMemberRepository : ISalesTeamMemberRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SalesTeamMemberRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(SalesTeamMember entity) {
    		this.DbContext.SalesTeamMembers.AddObject(entity);
    	}
    
    	public void Update(SalesTeamMember entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.SalesTeamId = entity.SalesTeamId;
    			e.UserId = entity.UserId;
    			e.IsLeader = entity.IsLeader;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.SalesTeamMembers.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(SalesTeamMember entity) {
    		this.DbContext.SalesTeamMembers.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.SalesTeamMembers.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<SalesTeamMember> FindAll() {
    		return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User");
    	}
    	public IEnumerable<SalesTeamMember> FindAll2() {
    		return this.DbContext.SalesTeamMembers;
    	}
    
    	public SalesTeamMember FindById(int id) {
    		return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<SalesTeamMember> FindBySalesTeamId(int salesTeamId){
    				return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User").Where(o => o.SalesTeamId.Equals(salesTeamId));
    			}
    	public IEnumerable<SalesTeamMember> FindByUserId(int userId){
    				return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User").Where(o => o.UserId.Equals(userId));
    			}
    	public IEnumerable<SalesTeamMember> FindByIsLeader(bool isLeader){
    				return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User").Where(o => o.IsLeader.Equals(isLeader));
    			}
    	public IEnumerable<SalesTeamMember> FindByCriteria(SalesTeamMemberCriteria c) {
    		return this.DbContext.SalesTeamMembers.Include("SalesTeam").Include("User").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.SalesTeamIdSrh.HasValue || o.SalesTeamId.Equals(c.SalesTeamIdSrh.Value))
    			&& (!c.SalesTeamIdFromSrh.HasValue || o.SalesTeamId >= c.SalesTeamIdFromSrh.Value)
    			&& (!c.SalesTeamIdToSrh.HasValue || o.SalesTeamId <= c.SalesTeamIdToSrh.Value)
    			&& (!c.UserIdSrh.HasValue || o.UserId.Equals(c.UserIdSrh.Value))
    			&& (!c.UserIdFromSrh.HasValue || o.UserId >= c.UserIdFromSrh.Value)
    			&& (!c.UserIdToSrh.HasValue || o.UserId <= c.UserIdToSrh.Value)
    			&& (!c.IsLeaderSrh.HasValue || o.IsLeader.Equals(c.IsLeaderSrh.Value))
    
    		);
    	}
    
    }
}
