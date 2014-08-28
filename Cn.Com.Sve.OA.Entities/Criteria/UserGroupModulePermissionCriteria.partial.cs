using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class UserGroupModulePermissionCriteria {
    	
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
    	public int? ModuleIdSrh { get; set;}
    	public int? ModuleIdFromSrh { get; set;}
    	public int? ModuleIdToSrh { get; set;}
    }
}
