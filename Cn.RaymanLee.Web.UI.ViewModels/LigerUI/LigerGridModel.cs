using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Web.UI.ViewModels.LigerUI {
	[Serializable]
	public class LigerGridModel {
		public int Total { get; set; }
		public List<object> Rows { get; set; }

		public LigerGridModel() {
			this.Rows = new List<object>();
		}
	}
}
