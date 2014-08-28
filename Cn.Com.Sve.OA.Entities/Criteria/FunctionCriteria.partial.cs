using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class FunctionCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? ModuleIdSrh { get; set;}
    	public int? ModuleIdFromSrh { get; set;}
    	public int? ModuleIdToSrh { get; set;}
    	public string CodeSrh { get; set;}
    	public string NameSrh { get; set;}
    	public string IconSrh { get; set;}
    	public string UrlSrh { get; set;}
    	public Nullable<int> ParentFunctionIdSrh { get; set;}
    	public Nullable<int> ParentFunctionIdFromSrh { get; set;}
    	public Nullable<int> ParentFunctionIdToSrh { get; set;}
    	public Nullable<int> SeqSrh { get; set;}
    	public Nullable<int> SeqFromSrh { get; set;}
    	public Nullable<int> SeqToSrh { get; set;}
    }
}
