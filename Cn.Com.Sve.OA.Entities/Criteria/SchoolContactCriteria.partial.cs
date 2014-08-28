using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class SchoolContactCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? SchoolIdSrh { get; set;}
    	public int? SchoolIdFromSrh { get; set;}
    	public int? SchoolIdToSrh { get; set;}
    	public Nullable<int> YearSrh { get; set;}
    	public Nullable<int> YearFromSrh { get; set;}
    	public Nullable<int> YearToSrh { get; set;}
    	public string TitleSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string TelephoneSrh { get; set;}
    	public string MobileSrh { get; set;}
    	public string QQSrh { get; set;}
    	public string AddressSrh { get; set;}
    	public string RemarkSrh { get; set;}
    	public Nullable<int> TopFlagSrh { get; set;}
    	public Nullable<int> TopFlagFromSrh { get; set;}
    	public Nullable<int> TopFlagToSrh { get; set;}
    	public Nullable<int> OldOaIdSrh { get; set;}
    	public Nullable<int> OldOaIdFromSrh { get; set;}
    	public Nullable<int> OldOaIdToSrh { get; set;}
    }
}
