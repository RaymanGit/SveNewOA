using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class DistrictCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public int? CityIdSrh { get; set;}
    	public int? CityIdFromSrh { get; set;}
    	public int? CityIdToSrh { get; set;}
    	public string PhonePrefixSrh { get; set;}
    	public string PostcodeSrh { get; set;}
    }
}
