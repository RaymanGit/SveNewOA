using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class School_Contact_ViewModel {
		public School School { get; set; }
		public List<SchoolContact> Contacts { get; set; }
	}
}