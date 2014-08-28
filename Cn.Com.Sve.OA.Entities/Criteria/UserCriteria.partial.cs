using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class UserCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string PasswordSrh { get; set;}
    	public string StatusSrh { get; set;}
    	public Nullable<System.DateTime> LastLoginTimeSrh { get; set;}
    	public Nullable<System.DateTime> LastLoginTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> LastLoginTimeToSrh { get; set;}
    	public string LastLoginIPSrh { get; set;}
    	public string DefaultUrlSrh { get; set;}
    }
}
