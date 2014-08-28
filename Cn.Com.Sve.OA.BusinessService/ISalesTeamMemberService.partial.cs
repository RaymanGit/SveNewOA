using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ISalesTeamMemberService {
    	IUnitOfWork Db { get; }
    
    	void Add(SalesTeamMember entity);
    	void Update(SalesTeamMember entity);
    	void Save(SalesTeamMember entity);
    	void Delete(SalesTeamMember entity);
    	void DeleteById(int id);
    	List<SalesTeamMember> FindAll();
    	SalesTeamMember FindById(int id);
    	List<SalesTeamMember> FindBySalesTeamId(int salesTeamId);
    	List<SalesTeamMember> FindByUserId(int userId);
    	List<SalesTeamMember> FindByIsLeader(bool isLeader);
    	PagedModel<SalesTeamMember> FindByCriteria(SalesTeamMemberCriteria c);
    }
}
