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
	public partial interface IStudentVisitRecordService {
		PagedModel<StudentVisitRecord> Search(StudentVisitRecordCriteria c);
	}
	public partial class StudentVisitRecordService : IStudentVisitRecordService {
		public PagedModel<StudentVisitRecord> Search(StudentVisitRecordCriteria c) {
			PagedModel<StudentVisitRecord> m = new PagedModel<StudentVisitRecord>();
			var r = this.Repository.Search(c).OrderByDescending(o => o.Time);

			m.RecordCount = r.Count();
			m.Data = r.ToList();
			return m;
		}
	}
}
