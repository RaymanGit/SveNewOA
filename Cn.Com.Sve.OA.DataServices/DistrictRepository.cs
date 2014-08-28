using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IDistrictRepository {
		IEnumerable<District> FindForSuggest(string keyword);
	}
	public partial class DistrictRepository : IDistrictRepository {
		public IEnumerable<District> FindForSuggest(string keyword) {
			return this.DbContext.Districts.Include("City").Where(o =>
				o.Name.Contains(keyword) || o.City.Name.Contains(keyword) || o.City.Province.Name.Contains(keyword)
			);
		}

	}
}
