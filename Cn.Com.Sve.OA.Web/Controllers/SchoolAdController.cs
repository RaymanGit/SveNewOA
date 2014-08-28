using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cn.Com.Sve.OA.BusinessService;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
using Cn.Com.Sve.OA.Web.Models;
using Cn.RaymanLee.Web.UI.ViewModels.LigerUI;
using Cn.RaymanLee.Data;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class SchoolAdController : BaseController {
		private object ToJson(SchoolAd e) {
			return new {
				Id = e.Id,
				SchoolId = e.SchoolId,
				Year = e.Year,
				HighClassQty = e.HighClassQty,
				HighStudentQty = e.HighStudentQty,
				LowClassQty = e.LowClassQty,
				LowStudentQty = e.LowStudentQty,
				DaoJiShiPai = e.DaoJiShiPai,
				JiaoShiBiaoYu = e.JiaoShiBiaoYu,
				ShuShiBiaoYu = e.ShuShiBiaoYu,
				ShiTangBiaoYu = e.ShiTangBiaoYu,
				LouTiBiaoYu = e.LouTiBiaoYu,
				BuTiao = e.BuTiao,
				TaiLi = e.TaiLi,
				GuaLi = e.GuaLi
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, SchoolAd e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(SchoolAd e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(SchoolAd e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}
	}
}
