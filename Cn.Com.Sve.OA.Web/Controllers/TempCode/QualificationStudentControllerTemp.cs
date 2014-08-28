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
    public partial class QualificationStudentControllerTemp : BaseController {
    		private object ToJson(QualificationStudent e) {
    			return new {
    				Id=e.Id,
    			Clazz=e.Clazz,
    			TargetSchoolName=e.TargetSchoolName,
    			SignUpTime=e.SignUpTime,
    			SeqNo=e.SeqNo,
    			TargetProfession=e.TargetProfession,
    			TargetLevel=e.TargetLevel,
    			StudentNo=e.StudentNo,
    			Name=e.Name,
    			Sex=e.Sex,
    			Birthday=e.Birthday,
    			JiGuang=e.JiGuang,
    			IdCardNo=e.IdCardNo,
    			MinZu=e.MinZu,
    			ZhengZhiMianMao=e.ZhengZhiMianMao,
    			IsMarried=e.IsMarried,
    			HomeAddress=e.HomeAddress,
    			HuKouAddress=e.HuKouAddress,
    			CommAddress=e.CommAddress,
    			Postcode=e.Postcode,
    			HomeTelephone=e.HomeTelephone,
    			Mobile=e.Mobile,
    			QQ=e.QQ,
    			Company=e.Company,
    			Title=e.Title,
    			CompanyTelephoneNo=e.CompanyTelephoneNo,
    			BeginWorkTime=e.BeginWorkTime,
    			WorkedYears=e.WorkedYears,
    			HighestEduLevel=e.HighestEduLevel,
    			HighestQualification=e.HighestQualification,
    			GraduateDate=e.GraduateDate,
    			GruduateSchool=e.GruduateSchool,
    			HighestQualificationNo=e.HighestQualificationNo,
    			StudyDuration1=e.StudyDuration1,
    			StudySchool1=e.StudySchool1,
    			StudyPosition1=e.StudyPosition1,
    			StudyDuration2=e.StudyDuration2,
    			StudySchool2=e.StudySchool2,
    			StudyPosition2=e.StudyPosition2,
    			StudyDuration3=e.StudyDuration3,
    			StudySchool3=e.StudySchool3,
    			StudyPosition3=e.StudyPosition3,
    			MemberRelType1=e.MemberRelType1,
    			MemberName1=e.MemberName1,
    			MemberMianMao1=e.MemberMianMao1,
    			MemberCompany1=e.MemberCompany1,
    			MemberPosition1=e.MemberPosition1,
    			MemberMobile1=e.MemberMobile1,
    			MemberRelType2=e.MemberRelType2,
    			MemberName2=e.MemberName2,
    			MemberMianMao2=e.MemberMianMao2,
    			MemberCompany2=e.MemberCompany2,
    			MemberPosition2=e.MemberPosition2,
    			MemberMobile2=e.MemberMobile2,
    			Remark=e.Remark,
    			Status=e.Status,
    			Consultant=e.Consultant,
    			Referrer=e.Referrer,
    			ReferrerMobile=e.ReferrerMobile,
    			ReferrerQQ=e.ReferrerQQ,
    			MatriculateTime=e.MatriculateTime,
    			NetUserName=e.NetUserName,
    			NetPassword=e.NetPassword,
    			StudyType=e.StudyType,
    			SubmitStatus=e.SubmitStatus,
    			OfferStatus=e.OfferStatus,
    			PayStatus=e.PayStatus,
    			PaperStatus=e.PaperStatus,
    			OldOAId=e.OldOAId,
    			Photo1=e.Photo1,
    			Photo2=e.Photo2,
    			Photo3=e.Photo3
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, QualificationStudent e);
    	partial void AfterAddData(QualificationStudent e, ref ActionResult ar);
    	partial void AfterUpdateData(QualificationStudent e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, QualificationStudent e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(QualificationStudent e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(QualificationStudent e, ref ActionResult ar) {
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
