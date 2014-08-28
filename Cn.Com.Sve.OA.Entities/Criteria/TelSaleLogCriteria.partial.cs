using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class TelSaleLogCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? CustomerIdSrh { get; set;}
    	public int? CustomerIdFromSrh { get; set;}
    	public int? CustomerIdToSrh { get; set;}
    	public string ContentSrh { get; set;}
    	public Nullable<System.DateTime> NextTelTimeSrh { get; set;}
    	public Nullable<System.DateTime> NextTelTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> NextTelTimeToSrh { get; set;}
    	public int? SalesmanIdSrh { get; set;}
    	public int? SalesmanIdFromSrh { get; set;}
    	public int? SalesmanIdToSrh { get; set;}
    	public System.DateTime? TelTimeSrh { get; set;}
    	public System.DateTime? TelTimeFromSrh { get; set;}
    	public System.DateTime? TelTimeToSrh { get; set;}
    	public bool? IsConvertSrh { get; set;}
    	public bool? IsSignUpSrh { get; set;}
    	public string ConsultTypeSrh { get; set;}
    }
}
