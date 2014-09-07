using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
	public partial interface ICityRepository {
		IEnumerable<City> FindForSuggest(string keyword);
	}
	public partial class CityRepository : ICityRepository {
		public IEnumerable<City> FindForSuggest(string keyword) {
			return this.DbContext.Cities.Include("Province").Where(o =>
				o.Name.Contains(keyword) || o.Province.Name.Contains(keyword) 
			);
		}

	}
}
