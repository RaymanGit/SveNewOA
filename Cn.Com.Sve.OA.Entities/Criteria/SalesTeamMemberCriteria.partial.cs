using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class SalesTeamMemberCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? SalesTeamIdSrh { get; set;}
    	public int? SalesTeamIdFromSrh { get; set;}
    	public int? SalesTeamIdToSrh { get; set;}
    	public int? UserIdSrh { get; set;}
    	public int? UserIdFromSrh { get; set;}
    	public int? UserIdToSrh { get; set;}
    	public bool? IsLeaderSrh { get; set;}
    }
}
