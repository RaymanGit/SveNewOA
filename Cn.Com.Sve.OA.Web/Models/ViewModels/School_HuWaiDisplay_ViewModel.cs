using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class School_HuWaiDisplay_ViewModel {
		public School School { get; set; }
		public List<SchoolAd> SchoolAds { get; set; }
	}
}