using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class CustomerCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public Nullable<int> SchoolIdSrh { get; set;}
    	public Nullable<int> SchoolIdFromSrh { get; set;}
    	public Nullable<int> SchoolIdToSrh { get; set;}
    	public int? MarketYearSrh { get; set;}
    	public int? MarketYearFromSrh { get; set;}
    	public int? MarketYearToSrh { get; set;}
    	public string TelephoneSrh { get; set;}
    	public string MobileSrh { get; set;}
    	public string GenderSrh { get; set;}
    	public string QQSrh { get; set;}
    	public string EmailSrh { get; set;}
    	public string EduLevelSrh { get; set;}
    	public bool? IsGaoKaoSrh { get; set;}
    	public Nullable<int> GaoKaoScoreSrh { get; set;}
    	public Nullable<int> GaoKaoScoreFromSrh { get; set;}
    	public Nullable<int> GaoKaoScoreToSrh { get; set;}
    	public string GaoKaoBatchSrh { get; set;}
    	public Nullable<int> DistrictIdSrh { get; set;}
    	public Nullable<int> DistrictIdFromSrh { get; set;}
    	public Nullable<int> DistrictIdToSrh { get; set;}
    	public string AddressSrh { get; set;}
    	public string PostcodeSrh { get; set;}
    	public int? SmallInfoSourceIdSrh { get; set;}
    	public int? SmallInfoSourceIdFromSrh { get; set;}
    	public int? SmallInfoSourceIdToSrh { get; set;}
    	public string ConsultTypeSrh { get; set;}
    	public string RemarkSrh { get; set;}
    	public Nullable<int> ConsultantId1Srh { get; set;}
    	public Nullable<int> ConsultantId1FromSrh { get; set;}
    	public Nullable<int> ConsultantId1ToSrh { get; set;}
    	public Nullable<int> ConsultantId2Srh { get; set;}
    	public Nullable<int> ConsultantId2FromSrh { get; set;}
    	public Nullable<int> ConsultantId2ToSrh { get; set;}
    	public Nullable<int> NetConsultantIdSrh { get; set;}
    	public Nullable<int> NetConsultantIdFromSrh { get; set;}
    	public Nullable<int> NetConsultantIdToSrh { get; set;}
    	public Nullable<int> CreateTeacherIdSrh { get; set;}
    	public Nullable<int> CreateTeacherIdFromSrh { get; set;}
    	public Nullable<int> CreateTeacherIdToSrh { get; set;}
    	public Nullable<System.DateTime> ConsultTimeSrh { get; set;}
    	public Nullable<System.DateTime> ConsultTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> ConsultTimeToSrh { get; set;}
    	public Nullable<int> SalesTeamIdSrh { get; set;}
    	public Nullable<int> SalesTeamIdFromSrh { get; set;}
    	public Nullable<int> SalesTeamIdToSrh { get; set;}
    	public Nullable<int> SalesmanIdSrh { get; set;}
    	public Nullable<int> SalesmanIdFromSrh { get; set;}
    	public Nullable<int> SalesmanIdToSrh { get; set;}
    	public bool? IsImportSrh { get; set;}
    	public int? TeleSalesTimesSrh { get; set;}
    	public int? TeleSalesTimesFromSrh { get; set;}
    	public int? TeleSalesTimesToSrh { get; set;}
    	public Nullable<System.DateTime> NextTeleSalesTimeSrh { get; set;}
    	public Nullable<System.DateTime> NextTeleSalesTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> NextTeleSalesTimeToSrh { get; set;}
    	public Nullable<System.DateTime> AppointmentTimeSrh { get; set;}
    	public Nullable<System.DateTime> AppointmentTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> AppointmentTimeToSrh { get; set;}
    	public Nullable<System.DateTime> DropInTimeSrh { get; set;}
    	public Nullable<System.DateTime> DropInTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> DropInTimeToSrh { get; set;}
    	public Nullable<System.DateTime> DinWeiTimeSrh { get; set;}
    	public Nullable<System.DateTime> DinWeiTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> DinWeiTimeToSrh { get; set;}
    	public Nullable<System.DateTime> SignUpTimeSrh { get; set;}
    	public Nullable<System.DateTime> SignUpTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> SignUpTimeToSrh { get; set;}
    	public bool? IsDinWeiSrh { get; set;}
    	public bool? IsClosedSrh { get; set;}
    	public Nullable<System.DateTime> LastSalesTimeSrh { get; set;}
    	public Nullable<System.DateTime> LastSalesTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> LastSalesTimeToSrh { get; set;}
    	public bool? ImportantSrh { get; set;}
    	public string ConsultantRemarkSrh { get; set;}
    	public string KeywordsSrh { get; set;}
    	public string ClazzSrh { get; set;}
    	public bool? IsLeaderFollowSrh { get; set;}
    	public string StatusSrh { get; set;}
    	public string LastSaleLogSrh { get; set;}
    	public Nullable<bool> IsDormSrh { get; set;}
    	public Nullable<int> InClazzIdSrh { get; set;}
    	public Nullable<int> InClazzIdFromSrh { get; set;}
    	public Nullable<int> InClazzIdToSrh { get; set;}
    	public bool? IsPaySrh { get; set;}
    	public Nullable<System.DateTime> PayTimeSrh { get; set;}
    	public Nullable<System.DateTime> PayTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> PayTimeToSrh { get; set;}
    	public bool? IsRefundSrh { get; set;}
    	public Nullable<System.DateTime> RefundTimeSrh { get; set;}
    	public Nullable<System.DateTime> RefundTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> RefundTimeToSrh { get; set;}
    	public bool? IsDropInSrh { get; set;}
    	public bool? IsSignUpSrh { get; set;}
    }
}
