using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class StudentTeleVisitRecordCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? ClazzIdSrh { get; set;}
    	public int? ClazzIdFromSrh { get; set;}
    	public int? ClazzIdToSrh { get; set;}
    	public int? StudentIdSrh { get; set;}
    	public int? StudentIdFromSrh { get; set;}
    	public int? StudentIdToSrh { get; set;}
    	public System.DateTime? TimeSrh { get; set;}
    	public System.DateTime? TimeFromSrh { get; set;}
    	public System.DateTime? TimeToSrh { get; set;}
    	public int? VisitorIdSrh { get; set;}
    	public int? VisitorIdFromSrh { get; set;}
    	public int? VisitorIdToSrh { get; set;}
    	public string IntervieweeSrh { get; set;}
    	public string PhoneNoSrh { get; set;}
    	public string AdviceSrh { get; set;}
    	public string SummarySrh { get; set;}
    	public Nullable<int> ReviewerIdSrh { get; set;}
    	public Nullable<int> ReviewerIdFromSrh { get; set;}
    	public Nullable<int> ReviewerIdToSrh { get; set;}
    	public Nullable<System.DateTime> ReviewTimeSrh { get; set;}
    	public Nullable<System.DateTime> ReviewTimeFromSrh { get; set;}
    	public Nullable<System.DateTime> ReviewTimeToSrh { get; set;}
    	public string ReviewCommentSrh { get; set;}
    }
}
