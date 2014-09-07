using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class EmploymentCompanyContactCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? CompanyIdSrh { get; set;}
    	public int? CompanyIdFromSrh { get; set;}
    	public int? CompanyIdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string MobileSrh { get; set;}
    	public string PositionSrh { get; set;}
    	public string TelephoneSrh { get; set;}
    	public string QQSrh { get; set;}
    	public string EmailSrh { get; set;}
    	public string IntroductionSrh { get; set;}
    	public string OldOaIdSrh { get; set;}
    	public string OldOaCompanyIdSrh { get; set;}
    }
}
