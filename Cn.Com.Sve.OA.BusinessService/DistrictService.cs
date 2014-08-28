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
	public partial interface IDistrictService {
		PagedModel<District> FindForSuggest(DistrictCriteria c);
	}
	public partial class DistrictService : IDistrictService {
		public PagedModel<District> FindForSuggest(DistrictCriteria c) {
			PagedModel<District> m = new PagedModel<District>();
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
				if (c.sortname.ToLower().Equals("cityid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.CityId);
					} else {
						r = r.OrderByDescending(o => o.CityId);
					}
				}
				if (c.sortname.ToLower().Equals("phoneprefix")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.PhonePrefix);
					} else {
						r = r.OrderByDescending(o => o.PhonePrefix);
					}
				}
				if (c.sortname.ToLower().Equals("postcode")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Postcode);
					} else {
						r = r.OrderByDescending(o => o.Postcode);
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
