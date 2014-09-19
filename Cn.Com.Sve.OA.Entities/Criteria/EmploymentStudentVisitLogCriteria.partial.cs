using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class EmploymentStudentVisitLogCriteria {
    	
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
    	public int? VisitorIdSrh { get; set;}
    	public int? VisitorIdFromSrh { get; set;}
    	public int? VisitorIdToSrh { get; set;}
    	public System.DateTime? TimeSrh { get; set;}
    	public System.DateTime? TimeFromSrh { get; set;}
    	public System.DateTime? TimeToSrh { get; set;}
    	public string PositionSrh { get; set;}
    	public string ObjectiveSrh { get; set;}
    	public string ContentSrh { get; set;}
    }
}
