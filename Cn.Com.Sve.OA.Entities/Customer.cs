using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public partial class Customer {
		public string SalesmanName { get; set; }
		public string SchoolName { get; set; }
		public string InClazzName { get; set; }
		public string ConsultantName1 { get; set; }
		public string ConsultantName2 { get; set; }
		public string SalesTeamName { get; set; }
		public string DistrictName { get; set; }
		public string ProvinceName { get; set; }
		public string CityName { get; set; }

		public string FullDistrictName {
			get {
				var name = String.Empty;
				if (this.District != null) {
					name = this.District.Name;
					if (this.District.City != null) {
						name = this.District.City.Name + name;
						if (this.District.City.Province != null) {
							name = this.District.City.Province.Name + name;
						}
					}
				}
				return name;
			}
		}
	}
}
