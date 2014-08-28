using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities.Criteria;
using Cn.Com.Sve.OA.Entities;
using Cn.RaymanLee.Data;

namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class InsuranceSearchViewModel {
		public StudentCriteria Criteria { get; set; }
		public PagedModel<Student> Data { get; set; }
	}
}