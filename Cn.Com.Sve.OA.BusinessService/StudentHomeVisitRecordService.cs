using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface IStudentHomeVisitRecordService {
		PagedModel<StudentHomeVisitRecord> Search(StudentHomeVisitRecordCriteria c);
	}
	public partial class StudentHomeVisitRecordService : IStudentHomeVisitRecordService {
		public PagedModel<StudentHomeVisitRecord> Search(StudentHomeVisitRecordCriteria c) {
			PagedModel<StudentHomeVisitRecord> m = new PagedModel<StudentHomeVisitRecord>();
			var r = this.Repository.Search(c).OrderByDescending(o => o.Time);

			m.RecordCount = r.Count();
			m.Data = r.ToList();
			return m;
		}
	}
}
