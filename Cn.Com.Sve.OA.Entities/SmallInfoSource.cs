using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
    public partial class SmallInfoSource{
		public string FullName {
			get {
				return this.BigInfoSource.Name + this.Name;
			}
		}
	}
}
