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
	public partial interface IEmploymentCompanyService {
		PagedModel<EmploymentCompany> Search(EmploymentCompanyCriteria c);
	}
	public partial class EmploymentCompanyService : IEmploymentCompanyService {
		public PagedModel<EmploymentCompany> Search(EmploymentCompanyCriteria c) {
			PagedModel<EmploymentCompany> m = new PagedModel<EmploymentCompany>();
			var r = this.Repository.Search(c);
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
				if (c.sortname.ToLower().Equals("type")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Type);
					} else {
						r = r.OrderByDescending(o => o.Type);
					}
				}
				if (c.sortname.ToLower().Equals("important")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Important);
					} else {
						r = r.OrderByDescending(o => o.Important);
					}
				}
				if (c.sortname.ToLower().Equals("website")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Website);
					} else {
						r = r.OrderByDescending(o => o.Website);
					}
				}
				if (c.sortname.ToLower().Equals("telephone")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Telephone);
					} else {
						r = r.OrderByDescending(o => o.Telephone);
					}
				}
				if (c.sortname.ToLower().Equals("fax")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Fax);
					} else {
						r = r.OrderByDescending(o => o.Fax);
					}
				}
				if (c.sortname.ToLower().Equals("address")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Address);
					} else {
						r = r.OrderByDescending(o => o.Address);
					}
				}
				if (c.sortname.ToLower().Equals("cityid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.CityId);
					} else {
						r = r.OrderByDescending(o => o.CityId);
					}
				}
				if (c.sortname.ToLower().Equals("introduction")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Introduction);
					} else {
						r = r.OrderByDescending(o => o.Introduction);
					}
				}
				if (c.sortname.ToLower().Equals("sourcetype")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.SourceType);
					} else {
						r = r.OrderByDescending(o => o.SourceType);
					}
				}
				if (c.sortname.ToLower().Equals("referer")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Referer);
					} else {
						r = r.OrderByDescending(o => o.Referer);
					}
				}
				if (c.sortname.ToLower().Equals("userid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.UserId);
					} else {
						r = r.OrderByDescending(o => o.UserId);
					}
				}
				if (c.sortname.ToLower().Equals("employedqty")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.EmployedQty);
					} else {
						r = r.OrderByDescending(o => o.EmployedQty);
					}
				}
				if (c.sortname.ToLower().Equals("oldoaid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.OldOaId);
					} else {
						r = r.OrderByDescending(o => o.OldOaId);
					}
				}
				if (c.sortname.ToLower().Equals("tempprovid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TempProvId);
					} else {
						r = r.OrderByDescending(o => o.TempProvId);
					}
				}
				if (c.sortname.ToLower().Equals("tempprovname")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TempProvName);
					} else {
						r = r.OrderByDescending(o => o.TempProvName);
					}
				}
				if (c.sortname.ToLower().Equals("tempcityid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TempCityId);
					} else {
						r = r.OrderByDescending(o => o.TempCityId);
					}
				}
				if (c.sortname.ToLower().Equals("tempcityname")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TempCityName);
					} else {
						r = r.OrderByDescending(o => o.TempCityName);
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
