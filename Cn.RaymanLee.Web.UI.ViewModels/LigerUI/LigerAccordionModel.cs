using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Web.UI.ViewModels.LigerUI {
	[Serializable]
	public class LigerAccordionModel {
		public string id { get; set; }
		public string text { get; set; }
		public string icon { get; set; }
		public string MenuId { get; set; }
		public string MenuName { get; set; }
		public string MenuUrl { get; set; }
		public string MenuIcon { get; set; }
		public string MenuNo { get; set; }
		public string MenuParentNo { get; set; }
		public List<LigerAccordionModel> children { get; set; }

		public LigerAccordionModel() {
		}
		public LigerAccordionModel(string id, string text, string icon, string code, string pno, string url) {
			this.id = id;
			this.text = text;
			this.icon = icon;
			this.MenuId = id;
			this.MenuName = text;
			this.MenuIcon = icon;
			this.MenuNo = code;
			this.MenuParentNo = pno;
			this.MenuUrl = url;
		}
	}
}
