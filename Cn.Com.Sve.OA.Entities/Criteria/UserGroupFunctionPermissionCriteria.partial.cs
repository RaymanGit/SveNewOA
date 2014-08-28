using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class UserGroupFunctionPermissionCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? UserGroupIdSrh { get; set;}
    	public int? UserGroupIdFromSrh { get; set;}
    	public int? UserGroupIdToSrh { get; set;}
    	public int? FunctionIdSrh { get; set;}
    	public int? FunctionIdFromSrh { get; set;}
    	public int? FunctionIdToSrh { get; set;}
    }
}
