using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class ImportDupliateCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string ImportKeySrh { get; set;}
    	public Nullable<int> CustomerIdSrh { get; set;}
    	public Nullable<int> CustomerIdFromSrh { get; set;}
    	public Nullable<int> CustomerIdToSrh { get; set;}
    	public Nullable<int> ImportIdSrh { get; set;}
    	public Nullable<int> ImportIdFromSrh { get; set;}
    	public Nullable<int> ImportIdToSrh { get; set;}
    	public string SchoolNameSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string TelSrh { get; set;}
    	public string MobileSrh { get; set;}
    	public Nullable<int> ScoreSrh { get; set;}
    	public Nullable<int> ScoreFromSrh { get; set;}
    	public Nullable<int> ScoreToSrh { get; set;}
    	public string ErrorMsgSrh { get; set;}
    }
}
