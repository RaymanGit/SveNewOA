using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public class SignUpRankingListItem {
		public int MarketYear { get; set; }
		public int SalesTeamId { get; set; }
		public int SalesmanId { get; set; }
		public string SalesTeamName { get; set; }
		public string SalesmanName { get; set; }
		public int SignUpQty { get; set; }
		public int DropInQty { get; set; }
		public int TelSignUpQty { get; set; }
		public int TelDropInQty { get; set; }
		public int NonTelSignUpQty { get; set; }
		public int NonTelDropInQty { get; set; }
		public int TelQty { get; set; }
		public string DropInRate { get; set; }
		public string SignUpRate { get; set; }
		public int Rank { get; set; }
	}
}