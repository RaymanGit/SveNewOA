using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Web.UI.ViewModels.LigerUI {
	[Serializable]
	public class LigerTreeModel {
		public string id { get; set; }
		public string text { get; set; }
		public string icon { get; set; }
		public int treelevel { get; set; }
		public int isleaf { get; set; }
		public string tabid { get { return String.Format("tab-{0}", this.id); } }
		public string url { get; set; }
		public string pid { get; set; }

	}
}
