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
    public partial class StudentControllerTemp : BaseController {
    		private object ToJson(Student e) {
    			return new {
    				Id=e.Id,
    			Name=e.Name,
    			PinYin=e.PinYin,
    			Gender=e.Gender,
    			Birthday=e.Birthday,
    			EduLevel=e.EduLevel,
    			GraduateDate=e.GraduateDate,
    			Score=e.Score,
    			GruduateSchoolId=e.GruduateSchoolId,
    			Profession=e.Profession,
    			IdCardNo=e.IdCardNo,
    			HuKouType=e.HuKouType,
    			Address=e.Address,
    			Postcode=e.Postcode,
    			FeeSource=e.FeeSource,
    			SmallInfoSourceId=e.SmallInfoSourceId,
    			QQ=e.QQ,
    			Email=e.Email,
    			Mobile=e.Mobile,
    			HomeTelephone=e.HomeTelephone,
    			OfficeTelephone=e.OfficeTelephone,
    			MemberRelType1=e.MemberRelType1,
    			MemberName1=e.MemberName1,
    			MemberCompany1=e.MemberCompany1,
    			MemberPosition1=e.MemberPosition1,
    			MemberMobile1=e.MemberMobile1,
    			MemberRelType2=e.MemberRelType2,
    			MemberName2=e.MemberName2,
    			MemberCompany2=e.MemberCompany2,
    			MemberPosition2=e.MemberPosition2,
    			MemberMobile2=e.MemberMobile2,
    			MemberRelType3=e.MemberRelType3,
    			MemberName3=e.MemberName3,
    			MemberCompany3=e.MemberCompany3,
    			MemberPosition3=e.MemberPosition3,
    			MemberMobile3=e.MemberMobile3,
    			MemberRelType4=e.MemberRelType4,
    			MemberName4=e.MemberName4,
    			MemberCompany4=e.MemberCompany4,
    			MemberPosition4=e.MemberPosition4,
    			MemberMobile4=e.MemberMobile4,
    			WorkState=e.WorkState,
    			StudyDuration1=e.StudyDuration1,
    			StudySchool1=e.StudySchool1,
    			StudyPosition1=e.StudyPosition1,
    			StudyDuration2=e.StudyDuration2,
    			StudySchool2=e.StudySchool2,
    			StudyPosition2=e.StudyPosition2,
    			StudyDuration3=e.StudyDuration3,
    			StudySchool3=e.StudySchool3,
    			StudyPosition3=e.StudyPosition3,
    			SoftwareExp=e.SoftwareExp,
    			ProgramExp=e.ProgramExp,
    			NetworkExp=e.NetworkExp,
    			RelCourse=e.RelCourse,
    			DistrictId=e.DistrictId,
    			IntentCity=e.IntentCity,
    			ClazzId=e.ClazzId,
    			StudentNo=e.StudentNo,
    			InSchoolDate=e.InSchoolDate,
    			IsDorm=e.IsDorm,
    			DormNo=e.DormNo,
    			GiveCourseware=e.GiveCourseware,
    			Consultants=e.Consultants,
    			Remark=e.Remark,
    			CreateTime=e.CreateTime,
    			LastUpdateTime=e.LastUpdateTime,
    			IsGetQualification=e.IsGetQualification,
    			Status=e.Status,
    			TechnicalWay=e.TechnicalWay,
    			NeedObtainWork=e.NeedObtainWork,
    			IntentPosition=e.IntentPosition,
    			TargetSalary=e.TargetSalary,
    			InsuranceStartDate=e.InsuranceStartDate,
    			InsuranceEndDate=e.InsuranceEndDate,
    			GaoKaoBatch=e.GaoKaoBatch,
    			GiveNotebook=e.GiveNotebook,
    			MaxSalary=e.MaxSalary,
    			CurrentSalary=e.CurrentSalary,
    			FirstSalary=e.FirstSalary,
    			BeginSchoolTime=e.BeginSchoolTime,
    			MasterName1=e.MasterName1,
    			MasterName2=e.MasterName2,
    			MasterName3=e.MasterName3,
    			TeacherName1=e.TeacherName1,
    			TeacherName2=e.TeacherName2,
    			TeacherName3=e.TeacherName3,
    			MasterId1=e.MasterId1,
    			MasterId2=e.MasterId2,
    			MasterId3=e.MasterId3,
    			TeacherId1=e.TeacherId1,
    			TeacherId2=e.TeacherId2,
    			TeacherId3=e.TeacherId3,
    			QualificationSchool=e.QualificationSchool,
    			InsuranceStatus=e.InsuranceStatus,
    			OldOaId=e.OldOaId,
    			OldOaInfoSourceSubTypeName=e.OldOaInfoSourceSubTypeName,
    			OldOaClass=e.OldOaClass,
    			HasRelTeacher=e.HasRelTeacher,
    			RelTeacher=e.RelTeacher,
    			HomeIntro=e.HomeIntro,
    			Give1=e.Give1,
    			Give2=e.Give2,
    			Give3=e.Give3,
    			Receive1=e.Receive1,
    			Receive2=e.Receive2,
    			Receive3=e.Receive3,
    			Receive4=e.Receive4,
    			Receive5=e.Receive5,
    			Receive6=e.Receive6,
    			Pic1=e.Pic1,
    			Pic2=e.Pic2,
    			Pic3=e.Pic3,
    			Pic4=e.Pic4,
    			Pic5=e.Pic5,
    			Pic6=e.Pic6
    			};
    		}
    
    	partial void AddRowToGridModel(LigerGridModel m, Student e);
    	partial void AfterAddData(Student e, ref ActionResult ar);
    	partial void AfterUpdateData(Student e, ref ActionResult ar);
    	partial void AddRowToGridModel(LigerGridModel m, Student e) {
    		m.Rows.Add(this.ToJson(e));
    	}
    	partial void AfterAddData(Student e, ref ActionResult ar) {
    		ar = this.Json(new AjaxOperationResult {
    			Data = this.ToJson(e),
    			Successful = true
    		});
    	}
    	partial void AfterUpdateData(Student e, ref ActionResult ar) {
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
