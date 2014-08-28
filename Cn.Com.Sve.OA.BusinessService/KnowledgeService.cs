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
	public partial interface IKnowledgeService {
		PagedModel<Knowledge> Search(KnowledgeCriteria c);
	}
	public partial class KnowledgeService : IKnowledgeService {
		public PagedModel<Knowledge> Search(KnowledgeCriteria c) {
			PagedModel<Knowledge> m = new PagedModel<Knowledge>();
			var r = this.Repository.FindByCriteria(c);
			if (!String.IsNullOrEmpty(c.KeywordSrh)) {
				r = r.Where(o => (!String.IsNullOrEmpty(o.Subject) && o.Subject.Contains(c.KeywordSrh)) ||
					(!String.IsNullOrEmpty(o.Content) && o.Content.Contains(c.KeywordSrh))
				);
			}

			if (!String.IsNullOrEmpty(c.sortname)) {
				if (c.sortname.ToLower().Equals("id")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Id);
					} else {
						r = r.OrderByDescending(o => o.Id);
					}
				}
				if (c.sortname.ToLower().Equals("subject")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Subject);
					} else {
						r = r.OrderByDescending(o => o.Subject);
					}
				}
				if (c.sortname.ToLower().Equals("content")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Content);
					} else {
						r = r.OrderByDescending(o => o.Content);
					}
				}
				if (c.sortname.ToLower().Equals("knowledgetype")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.KnowledgeType);
					} else {
						r = r.OrderByDescending(o => o.KnowledgeType);
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
