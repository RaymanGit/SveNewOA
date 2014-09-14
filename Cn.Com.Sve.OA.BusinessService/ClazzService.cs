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
	public partial interface IClazzService {
		PagedModel<Clazz> FindByCriteria2(ClazzCriteria c);
	}

	public partial class ClazzService : IClazzService {
		public PagedModel<Clazz> FindByCriteria2(ClazzCriteria c) {
			PagedModel<Clazz> m = new PagedModel<Clazz>();
			var r = this.Repository.FindByCriteria(c);
			r = r.OrderBy(o => o.Name.PadRight(10,' ').Substring(1, 2)).ThenBy(o => o.Semester).ThenBy(o => o.OpenDate.GetValueOrDefault().Year);

			m.RecordCount = r.Count();
			if (c.pagesize.HasValue) {
				int page = c.page ?? 1;
				int pageCount = m.RecordCount / c.pagesize.Value;
				if (m.RecordCount % c.pagesize.Value > 0) {
					pageCount++;
				}
				int skip = (page - 1) * c.pagesize.Value;
				if (skip > 0) {
					r = r.Skip(skip);
				}
				r = r.Take(c.pagesize.Value);
			}

			m.Data = r.ToList();
			return m;
		}

	}
}
