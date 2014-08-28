using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	/// <summary>
	/// 录入电访记录界面的视图模型
	/// </summary>
	[Serializable]
	public class TeleSaleViewModel {
		public Customer Customer { get; set; }
	}
}