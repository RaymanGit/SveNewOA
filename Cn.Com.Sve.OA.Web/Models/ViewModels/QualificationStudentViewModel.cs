using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class QualificationStudentViewModel {
		public QualificationStudent Student { get; set; }
		public List<QualificationSchool> Schools { get; set; }

	}
}