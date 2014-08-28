using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class ImportCustomerCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string ImportKeySrh { get; set;}
    	public Nullable<int> SchoolIdSrh { get; set;}
    	public Nullable<int> SchoolIdFromSrh { get; set;}
    	public Nullable<int> SchoolIdToSrh { get; set;}
    	public string SchoolNameSrh { get; set;}
    	public string LevelSrh { get; set;}
    	public int? MarketYearSrh { get; set;}
    	public int? MarketYearFromSrh { get; set;}
    	public int? MarketYearToSrh { get; set;}
    	public int? InfoSourceSrh { get; set;}
    	public int? InfoSourceFromSrh { get; set;}
    	public int? InfoSourceToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string GenderSrh { get; set;}
    	public string TelSrh { get; set;}
    	public Nullable<int> ProvinceIdSrh { get; set;}
    	public Nullable<int> ProvinceIdFromSrh { get; set;}
    	public Nullable<int> ProvinceIdToSrh { get; set;}
    	public string ProvinceNameSrh { get; set;}
    	public Nullable<int> CityIdSrh { get; set;}
    	public Nullable<int> CityIdFromSrh { get; set;}
    	public Nullable<int> CityIdToSrh { get; set;}
    	public string CityNameSrh { get; set;}
    	public Nullable<int> DistrictIdSrh { get; set;}
    	public Nullable<int> DistrictIdFromSrh { get; set;}
    	public Nullable<int> DistrictIdToSrh { get; set;}
    	public string DistrictNameSrh { get; set;}
    	public string AddressSrh { get; set;}
    	public string MobileSrh { get; set;}
    	public string QQSrh { get; set;}
    	public string ClazzSrh { get; set;}
    	public Nullable<int> ScoreSrh { get; set;}
    	public Nullable<int> ScoreFromSrh { get; set;}
    	public Nullable<int> ScoreToSrh { get; set;}
    	public string PostcodeSrh { get; set;}
    	public string ContactSrh { get; set;}
    	public string ImportTypeSrh { get; set;}
    	public bool? IsProcessedSrh { get; set;}
    	public string ErrorMsgSrh { get; set;}
    }
}
