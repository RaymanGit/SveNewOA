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


namespace Cn.Com.Sve.OA.Web.Controllers.TempCode {
    public partial class SchoolControllerTemp : BaseController {
    		private object ToJson(School e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			DistrictId=e.DistrictId,
    			IsSold=e.IsSold,
    			Type=e.Type,
    			Levels=e.Levels,
    			DevBy=e.DevBy,
    			DevDate=e.DevDate,
    			Important=e.Important,
    			Equipments=e.Equipments,
    			DaoJiShiPai=e.DaoJiShiPai,
    			JiaoShiBiaoYu=e.JiaoShiBiaoYu,
    			ShuShiBiaoYu=e.ShuShiBiaoYu,
    			ShiTangBiaoYu=e.ShiTangBiaoYu,
    			LouTiBiaoYu=e.LouTiBiaoYu,
    			BuTiao=e.BuTiao,
    			Address=e.Address,
    			HighClassQty=e.HighClassQty,
    			HighStudentQty=e.HighStudentQty,
    			LowClassQty=e.LowClassQty,
    			LowStudentQty=e.LowStudentQty,
    			Remark=e.Remark,
    			OldOaHuWaiId=e.OldOaHuWaiId
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, School e);
    	partial void AfterAddData(School e, ref ActionResult ar);
    	partial void AfterUpdateData(School e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, School e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(School e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(School e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    
    	public ActionResult GetInitData() {
    		return this.Json(new {}, JsonRequestBehavior.AllowGet);
    	}
    }
}
