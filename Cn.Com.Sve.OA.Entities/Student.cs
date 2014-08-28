using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public partial class Student{
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
