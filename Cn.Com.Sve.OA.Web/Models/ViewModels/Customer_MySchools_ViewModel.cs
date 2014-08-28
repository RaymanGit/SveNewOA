using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class Customer_MySchools_ViewModel {
		public Customer_MySchools_ViewModel() {
			this.Teams = new List<Item>();
		}

		public List<Item> Teams { get; set; }
		
		public class Item {
			public int Id { get; set; }
			public string Name { get; set; }
			public List<Item> Children { get; set; }
			public List<Item> Schools { get; set; }
		}
	}
}