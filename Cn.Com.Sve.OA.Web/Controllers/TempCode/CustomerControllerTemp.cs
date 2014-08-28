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
    public partial class CustomerControllerTemp : BaseController {
    		private object ToJson(Customer e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			SchoolId=e.SchoolId,
    			MarketYear=e.MarketYear,
    			Telephone=e.Telephone,
    			Mobile=e.Mobile,
    			Gender=e.Gender,
    			QQ=e.QQ,
    			Email=e.Email,
    			EduLevel=e.EduLevel,
    			IsGaoKao=e.IsGaoKao,
    			GaoKaoScore=e.GaoKaoScore,
    			GaoKaoBatch=e.GaoKaoBatch,
    			DistrictId=e.DistrictId,
    			Address=e.Address,
    			Postcode=e.Postcode,
    			SmallInfoSourceId=e.SmallInfoSourceId,
    			ConsultType=e.ConsultType,
    			Remark=e.Remark,
    			ConsultantId1=e.ConsultantId1,
    			ConsultantId2=e.ConsultantId2,
    			NetConsultantId=e.NetConsultantId,
    			CreateTeacherId=e.CreateTeacherId,
    			ConsultTime=e.ConsultTime,
    			SalesTeamId=e.SalesTeamId,
    			SalesmanId=e.SalesmanId,
    			IsImport=e.IsImport,
    			TeleSalesTimes=e.TeleSalesTimes,
    			NextTeleSalesTime=e.NextTeleSalesTime,
    			AppointmentTime=e.AppointmentTime,
    			DropInTime=e.DropInTime,
    			DinWeiTime=e.DinWeiTime,
    			SignUpTime=e.SignUpTime,
    			IsDinWei=e.IsDinWei,
    			IsClosed=e.IsClosed,
    			LastSalesTime=e.LastSalesTime,
    			Important=e.Important,
    			ConsultantRemark=e.ConsultantRemark,
    			Keywords=e.Keywords,
    			Clazz=e.Clazz,
    			IsLeaderFollow=e.IsLeaderFollow,
    			Status=e.Status,
    			LastSaleLog=e.LastSaleLog,
    			IsDorm=e.IsDorm,
    			InClazzId=e.InClazzId,
    			IsPay=e.IsPay,
    			PayTime=e.PayTime,
    			IsRefund=e.IsRefund,
    			RefundTime=e.RefundTime,
    			IsDropIn=e.IsDropIn,
    			IsSignUp=e.IsSignUp
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, Customer e);
    	partial void AfterAddData(Customer e, ref ActionResult ar);
    	partial void AfterUpdateData(Customer e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, Customer e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(Customer e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(Customer e, ref ActionResult ar) {
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
