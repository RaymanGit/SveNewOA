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
	public partial interface ICityService {
		PagedModel<City> FindForSuggest(CityCriteria c);
	}

	public partial class CityService : ICityService {
		public PagedModel<City> FindForSuggest(CityCriteria c) {
			PagedModel<City> m = new PagedModel<City>();
			var r = this.Repository.FindForSuggest(c.NameSrh);
			if (!String.IsNullOrEmpty(c.sortname)) {
				if (c.sortname.ToLower().Equals("id")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Id);
					} else {
						r = r.OrderByDescending(o => o.Id);
					}
				}
				if (c.sortname.ToLower().Equals("name")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Name);
					} else {
						r = r.OrderByDescending(o => o.Name);
					}
				}
				if (c.sortname.ToLower().Equals("provinceid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.ProvinceId);
					} else {
						r = r.OrderByDescending(o => o.ProvinceId);
					}
				}

			}

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
