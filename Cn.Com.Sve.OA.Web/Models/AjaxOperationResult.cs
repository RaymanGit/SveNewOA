using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cn.Com.Sve.OA.Web.Models {
	[Serializable]
	public class AjaxOperationResult {
		/// <summary>
		/// 操作是否成功。
		/// </summary>
		public bool Successful { get; set; }
		/// <summary>
		/// 要在客户端显示的提示信息。
		/// </summary>
		public string Message { get; set; }
		/// <summary>
		/// 与本操作关联的对象。
		/// </summary>
		public object Data { get; set; }
	}
}