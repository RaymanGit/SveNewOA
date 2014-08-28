using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class QualificationStudentSearchViewModel {
		public Cn.Com.Sve.OA.Entities.Criteria.QualificationStudentCriteria Criteria { get; set; }
		public List<Cn.Com.Sve.OA.Entities.QualificationStudent> Students { get; set; }
		public List<Cn.Com.Sve.OA.Entities.QualificationSchool> Schools { get; set; }
	}
}