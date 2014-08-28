using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class Student_Visit_ViewModel {
		public StudentVisitRecordCriteria Criteria { get; set; }
		public Student Student { get; set; }
		public List<StudentVisitRecord> Records { get; set; }

		public bool ShowInput { get; set; }
		public bool ShowDelete { get; set; }
		public bool ShowConfirmEdit { get; set; }
		public User CurrentUser { get; set; }

		public Student_Visit_ViewModel() {
			this.ShowConfirmEdit = true;
		}

	}
}