using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public partial class District{
		public string FullName {
			get {
				var n = "";
				if (this.City != null) {
					if (this.City.Province != null) {
						n += this.City.Province.Name;
					}
					n += this.City.Name;
				}
				if (!String.IsNullOrEmpty(this.Name)) {
					n += this.Name;
				}
				return n;
			}
		}
	}
}
