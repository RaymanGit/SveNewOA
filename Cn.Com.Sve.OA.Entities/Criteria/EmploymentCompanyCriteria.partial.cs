using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class EmploymentCompanyCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string TypeSrh { get; set;}
    	public string ImportantSrh { get; set;}
    	public string WebsiteSrh { get; set;}
    	public string TelephoneSrh { get; set;}
    	public string FaxSrh { get; set;}
    	public string AddressSrh { get; set;}
    	public Nullable<int> CityIdSrh { get; set;}
    	public Nullable<int> CityIdFromSrh { get; set;}
    	public Nullable<int> CityIdToSrh { get; set;}
    	public string IntroductionSrh { get; set;}
    	public string SourceTypeSrh { get; set;}
    	public string RefererSrh { get; set;}
    	public Nullable<int> UserIdSrh { get; set;}
    	public Nullable<int> UserIdFromSrh { get; set;}
    	public Nullable<int> UserIdToSrh { get; set;}
    	public int? EmployedQtySrh { get; set;}
    	public int? EmployedQtyFromSrh { get; set;}
    	public int? EmployedQtyToSrh { get; set;}
    	public string OldOaIdSrh { get; set;}
    	public string TempProvIdSrh { get; set;}
    	public string TempProvNameSrh { get; set;}
    	public string TempCityIdSrh { get; set;}
    	public string TempCityNameSrh { get; set;}
    	public Nullable<System.DateTime> AddTimeSrh { get; set;}
    	public Nullable<System.DateTime> AddTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> AddTimeToSrh { get; set;}
    }
}
