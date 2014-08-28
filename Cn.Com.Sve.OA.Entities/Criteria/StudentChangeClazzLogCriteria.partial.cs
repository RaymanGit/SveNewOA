using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class StudentChangeClazzLogCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? StudentIdSrh { get; set;}
    	public int? StudentIdFromSrh { get; set;}
    	public int? StudentIdToSrh { get; set;}
    	public Nullable<int> OldClazzIdSrh { get; set;}
    	public Nullable<int> OldClazzIdFromSrh { get; set;}
    	public Nullable<int> OldClazzIdToSrh { get; set;}
    	public int? NewClazzIdSrh { get; set;}
    	public int? NewClazzIdFromSrh { get; set;}
    	public int? NewClazzIdToSrh { get; set;}
    	public System.DateTime? ChangeTimeSrh { get; set;}
    	public System.DateTime? ChangeTimeFromSrh { get; set;}
    	public System.DateTime? ChangeTimeToSrh { get; set;}
    	public string OperatorNameSrh { get; set;}
    }
}
