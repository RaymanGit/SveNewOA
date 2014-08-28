using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Data {
	[Serializable]
	public class PagedModel<TEntity> {
		#region for ligerUI grid
		public int? page { get; set; }
		public int? pagesize { get; set; }
		public string sortname { get; set; }
		public string sortorder { get; set; }
		#endregion

		public int RecordCount { get; set; }
		public List<TEntity> Data { get; set; }
	}
}
