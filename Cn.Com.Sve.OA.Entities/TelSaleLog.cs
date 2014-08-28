using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.Com.Sve.OA.Entities {
	public partial class TelSaleLog {
		//public string ConsultType { get; set; }
		public int? GaoKaoScore { get; set; }
		public string GaoKaoBatch { get; set; }
		public bool Important { get; set; }
		public bool IsLeaderFollow { get; set; }
		public DateTime? NextTeleSalesTime { get; set; }
		public string Keywords { get; set; }
	}
}
