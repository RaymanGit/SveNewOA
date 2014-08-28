using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class ClazzCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string SemesterSrh { get; set;}
    	public int? StudentQtySrh { get; set;}
    	public int? StudentQtyFromSrh { get; set;}
    	public int? StudentQtyToSrh { get; set;}
    	public int? LimitedQtySrh { get; set;}
    	public int? LimitedQtyFromSrh { get; set;}
    	public int? LimitedQtyToSrh { get; set;}
    	public string TeacherASrh { get; set;}
    	public string TeacherBSrh { get; set;}
    	public string MasterSrh { get; set;}
    	public string GovernorSrh { get; set;}
    	public Nullable<System.DateTime> OpenDateSrh { get; set;}
    	public Nullable<System.DateTime> OpenDateFromSrh { get; set;}
    	public Nullable<System.DateTime> OpenDateToSrh { get; set;}
    	public Nullable<System.DateTime> ClosedDateSrh { get; set;}
    	public Nullable<System.DateTime> ClosedDateFromSrh { get; set;}
    	public Nullable<System.DateTime> ClosedDateToSrh { get; set;}
    	public Nullable<System.DateTime> FinishedDateSrh { get; set;}
    	public Nullable<System.DateTime> FinishedDateFromSrh { get; set;}
    	public Nullable<System.DateTime> FinishedDateToSrh { get; set;}
    	public bool? IsOpenSrh { get; set;}
    	public bool? IsClosedSrh { get; set;}
    	public bool? IsFinishedSrh { get; set;}
    	public System.DateTime? CreateTimeSrh { get; set;}
    	public System.DateTime? CreateTimeFromSrh { get; set;}
    	public System.DateTime? CreateTimeToSrh { get; set;}
    	public System.DateTime? UpdateTimeSrh { get; set;}
    	public System.DateTime? UpdateTimeFromSrh { get; set;}
    	public System.DateTime? UpdateTimeToSrh { get; set;}
    	public Nullable<System.DateTime> KickOffDateSrh { get; set;}
    	public Nullable<System.DateTime> KickOffDateFromSrh { get; set;}
    	public Nullable<System.DateTime> KickOffDateToSrh { get; set;}
    }
}
