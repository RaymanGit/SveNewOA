﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IStudentRepository {
		IEnumerable<Student> Search(StudentCriteria c);
	}
	public partial class StudentRepository : IStudentRepository {
		public IEnumerable<Student> Search(StudentCriteria c) {
			return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool")
				.Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1")
				.Include("Teacher2").Include("Teacher3")
				.Where(o =>
				(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
				&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
				&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
				&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
				&& (String.IsNullOrEmpty(c.PinYinSrh) || o.PinYin.Contains(c.PinYinSrh))
				&& (String.IsNullOrEmpty(c.GenderSrh) || o.Gender.Contains(c.GenderSrh))
				&& (!c.BirthdaySrh.HasValue || (o.Birthday.HasValue && o.Birthday.Value.Equals(c.BirthdaySrh.Value)))
				&& (!c.BirthdayFromSrh.HasValue || (o.Birthday.HasValue && o.Birthday.Value >= c.BirthdayFromSrh.Value))
				&& (!c.BirthdayToSrh.HasValue || (o.Birthday.HasValue && o.Birthday.Value <= c.BirthdayToSrh.Value))
				&& (String.IsNullOrEmpty(c.EduLevelSrh) || o.EduLevel.Contains(c.EduLevelSrh))
				&& (!c.GraduateDateSrh.HasValue || (o.GraduateDate.HasValue && o.GraduateDate.Value.Equals(c.GraduateDateSrh.Value)))
				&& (!c.GraduateDateFromSrh.HasValue || (o.GraduateDate.HasValue && o.GraduateDate.Value >= c.GraduateDateFromSrh.Value))
				&& (!c.GraduateDateToSrh.HasValue || (o.GraduateDate.HasValue && o.GraduateDate.Value <= c.GraduateDateToSrh.Value))
				&& (!c.ScoreSrh.HasValue || (o.Score.HasValue && o.Score.Value.Equals(c.ScoreSrh.Value)))
				&& (!c.ScoreFromSrh.HasValue || (o.Score.HasValue && o.Score.Value >= c.ScoreFromSrh.Value))
				&& (!c.ScoreToSrh.HasValue || (o.Score.HasValue && o.Score.Value <= c.ScoreToSrh.Value))
				&& (!c.GruduateSchoolIdSrh.HasValue || (o.GruduateSchoolId.HasValue && o.GruduateSchoolId.Value.Equals(c.GruduateSchoolIdSrh.Value)))
				&& (!c.GruduateSchoolIdFromSrh.HasValue || (o.GruduateSchoolId.HasValue && o.GruduateSchoolId.Value >= c.GruduateSchoolIdFromSrh.Value))
				&& (!c.GruduateSchoolIdToSrh.HasValue || (o.GruduateSchoolId.HasValue && o.GruduateSchoolId.Value <= c.GruduateSchoolIdToSrh.Value))
				&& (String.IsNullOrEmpty(c.ProfessionSrh) || o.Profession.Contains(c.ProfessionSrh))
				&& (String.IsNullOrEmpty(c.IdCardNoSrh) || o.IdCardNo.Contains(c.IdCardNoSrh))
				&& (String.IsNullOrEmpty(c.HuKouTypeSrh) || o.HuKouType.Contains(c.HuKouTypeSrh))
				&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
				&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
				&& (String.IsNullOrEmpty(c.FeeSourceSrh) || o.FeeSource.Contains(c.FeeSourceSrh))
				&& (!c.SmallInfoSourceIdSrh.HasValue || (o.SmallInfoSourceId.HasValue && o.SmallInfoSourceId.Value.Equals(c.SmallInfoSourceIdSrh.Value)))
				&& (!c.SmallInfoSourceIdFromSrh.HasValue || (o.SmallInfoSourceId.HasValue && o.SmallInfoSourceId.Value >= c.SmallInfoSourceIdFromSrh.Value))
				&& (!c.SmallInfoSourceIdToSrh.HasValue || (o.SmallInfoSourceId.HasValue && o.SmallInfoSourceId.Value <= c.SmallInfoSourceIdToSrh.Value))
				&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
				&& (String.IsNullOrEmpty(c.EmailSrh) || o.Email.Contains(c.EmailSrh))
				&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
				&& (String.IsNullOrEmpty(c.HomeTelephoneSrh) || o.HomeTelephone.Contains(c.HomeTelephoneSrh))
				&& (String.IsNullOrEmpty(c.OfficeTelephoneSrh) || o.OfficeTelephone.Contains(c.OfficeTelephoneSrh))
				&& (String.IsNullOrEmpty(c.MemberRelType1Srh) || o.MemberRelType1.Contains(c.MemberRelType1Srh))
				&& (String.IsNullOrEmpty(c.MemberName1Srh) || o.MemberName1.Contains(c.MemberName1Srh))
				&& (String.IsNullOrEmpty(c.MemberCompany1Srh) || o.MemberCompany1.Contains(c.MemberCompany1Srh))
				&& (String.IsNullOrEmpty(c.MemberPosition1Srh) || o.MemberPosition1.Contains(c.MemberPosition1Srh))
				&& (String.IsNullOrEmpty(c.MemberMobile1Srh) || o.MemberMobile1.Contains(c.MemberMobile1Srh))
				&& (String.IsNullOrEmpty(c.MemberRelType2Srh) || o.MemberRelType2.Contains(c.MemberRelType2Srh))
				&& (String.IsNullOrEmpty(c.MemberName2Srh) || o.MemberName2.Contains(c.MemberName2Srh))
				&& (String.IsNullOrEmpty(c.MemberCompany2Srh) || o.MemberCompany2.Contains(c.MemberCompany2Srh))
				&& (String.IsNullOrEmpty(c.MemberPosition2Srh) || o.MemberPosition2.Contains(c.MemberPosition2Srh))
				&& (String.IsNullOrEmpty(c.MemberMobile2Srh) || o.MemberMobile2.Contains(c.MemberMobile2Srh))
				&& (String.IsNullOrEmpty(c.MemberRelType3Srh) || o.MemberRelType3.Contains(c.MemberRelType3Srh))
				&& (String.IsNullOrEmpty(c.MemberName3Srh) || o.MemberName3.Contains(c.MemberName3Srh))
				&& (String.IsNullOrEmpty(c.MemberCompany3Srh) || o.MemberCompany3.Contains(c.MemberCompany3Srh))
				&& (String.IsNullOrEmpty(c.MemberPosition3Srh) || o.MemberPosition3.Contains(c.MemberPosition3Srh))
				&& (String.IsNullOrEmpty(c.MemberMobile3Srh) || o.MemberMobile3.Contains(c.MemberMobile3Srh))
				&& (String.IsNullOrEmpty(c.MemberRelType4Srh) || o.MemberRelType4.Contains(c.MemberRelType4Srh))
				&& (String.IsNullOrEmpty(c.MemberName4Srh) || o.MemberName4.Contains(c.MemberName4Srh))
				&& (String.IsNullOrEmpty(c.MemberCompany4Srh) || o.MemberCompany4.Contains(c.MemberCompany4Srh))
				&& (String.IsNullOrEmpty(c.MemberPosition4Srh) || o.MemberPosition4.Contains(c.MemberPosition4Srh))
				&& (String.IsNullOrEmpty(c.MemberMobile4Srh) || o.MemberMobile4.Contains(c.MemberMobile4Srh))
				&& (String.IsNullOrEmpty(c.WorkStateSrh) || o.WorkState.Contains(c.WorkStateSrh))
				&& (String.IsNullOrEmpty(c.StudyDuration1Srh) || o.StudyDuration1.Contains(c.StudyDuration1Srh))
				&& (String.IsNullOrEmpty(c.StudySchool1Srh) || o.StudySchool1.Contains(c.StudySchool1Srh))
				&& (String.IsNullOrEmpty(c.StudyPosition1Srh) || o.StudyPosition1.Contains(c.StudyPosition1Srh))
				&& (String.IsNullOrEmpty(c.StudyDuration2Srh) || o.StudyDuration2.Contains(c.StudyDuration2Srh))
				&& (String.IsNullOrEmpty(c.StudySchool2Srh) || o.StudySchool2.Contains(c.StudySchool2Srh))
				&& (String.IsNullOrEmpty(c.StudyPosition2Srh) || o.StudyPosition2.Contains(c.StudyPosition2Srh))
				&& (String.IsNullOrEmpty(c.StudyDuration3Srh) || o.StudyDuration3.Contains(c.StudyDuration3Srh))
				&& (String.IsNullOrEmpty(c.StudySchool3Srh) || o.StudySchool3.Contains(c.StudySchool3Srh))
				&& (String.IsNullOrEmpty(c.StudyPosition3Srh) || o.StudyPosition3.Contains(c.StudyPosition3Srh))
				&& (String.IsNullOrEmpty(c.SoftwareExpSrh) || o.SoftwareExp.Contains(c.SoftwareExpSrh))
				&& (String.IsNullOrEmpty(c.ProgramExpSrh) || o.ProgramExp.Contains(c.ProgramExpSrh))
				&& (String.IsNullOrEmpty(c.NetworkExpSrh) || o.NetworkExp.Contains(c.NetworkExpSrh))
				&& (String.IsNullOrEmpty(c.RelCourseSrh) || o.RelCourse.Contains(c.RelCourseSrh))
				&& (!c.DistrictIdSrh.HasValue || (o.DistrictId.HasValue && o.DistrictId.Value.Equals(c.DistrictIdSrh.Value)))
				&& (!c.DistrictIdFromSrh.HasValue || (o.DistrictId.HasValue && o.DistrictId.Value >= c.DistrictIdFromSrh.Value))
				&& (!c.DistrictIdToSrh.HasValue || (o.DistrictId.HasValue && o.DistrictId.Value <= c.DistrictIdToSrh.Value))
				&& (String.IsNullOrEmpty(c.IntentCitySrh) || o.IntentCity.Contains(c.IntentCitySrh))
				&& (!c.ClazzIdSrh.HasValue || (o.ClazzId.HasValue && o.ClazzId.Value.Equals(c.ClazzIdSrh.Value)))
				&& (!c.ClazzIdFromSrh.HasValue || (o.ClazzId.HasValue && o.ClazzId.Value >= c.ClazzIdFromSrh.Value))
				&& (!c.ClazzIdToSrh.HasValue || (o.ClazzId.HasValue && o.ClazzId.Value <= c.ClazzIdToSrh.Value))
				&& (String.IsNullOrEmpty(c.StudentNoSrh) || o.StudentNo.Contains(c.StudentNoSrh))
				&& (!c.InSchoolDateSrh.HasValue || (o.InSchoolDate.HasValue && o.InSchoolDate.Value.Equals(c.InSchoolDateSrh.Value)))
				&& (!c.InSchoolDateFromSrh.HasValue || (o.InSchoolDate.HasValue && o.InSchoolDate.Value >= c.InSchoolDateFromSrh.Value))
				&& (!c.InSchoolDateToSrh.HasValue || (o.InSchoolDate.HasValue && o.InSchoolDate.Value <= c.InSchoolDateToSrh.Value))
				&& (String.IsNullOrEmpty(c.IsDormSrh) || o.IsDorm.Contains(c.IsDormSrh))
				&& (String.IsNullOrEmpty(c.DormNoSrh) || o.DormNo.Contains(c.DormNoSrh))
				&& (String.IsNullOrEmpty(c.GiveCoursewareSrh) || o.GiveCourseware.Contains(c.GiveCoursewareSrh))
				&& (String.IsNullOrEmpty(c.ConsultantsSrh) || o.Consultants.Contains(c.ConsultantsSrh))
				&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
				&& (!c.CreateTimeSrh.HasValue || o.CreateTime.Equals(c.CreateTimeSrh.Value))
				&& (!c.LastUpdateTimeSrh.HasValue || o.LastUpdateTime.Equals(c.LastUpdateTimeSrh.Value))
				&& (String.IsNullOrEmpty(c.IsGetQualificationSrh) || (!String.IsNullOrEmpty(o.IsGetQualification) && o.IsGetQualification.Contains(c.IsGetQualificationSrh)))
				&& (String.IsNullOrEmpty(c.StatusSrh) || o.Status.Contains(c.StatusSrh))
				&& (String.IsNullOrEmpty(c.TechnicalWaySrh) || o.TechnicalWay.Contains(c.TechnicalWaySrh))
				&& (String.IsNullOrEmpty(c.NeedObtainWorkSrh) || o.NeedObtainWork.Contains(c.NeedObtainWorkSrh))
				&& (String.IsNullOrEmpty(c.IntentPositionSrh) || o.IntentPosition.Contains(c.IntentPositionSrh))
				&& (!c.TargetSalarySrh.HasValue || (o.TargetSalary.HasValue && o.TargetSalary.Value.Equals(c.TargetSalarySrh.Value)))
				&& (!c.TargetSalaryFromSrh.HasValue || (o.TargetSalary.HasValue && o.TargetSalary.Value >= c.TargetSalaryFromSrh.Value))
				&& (!c.TargetSalaryToSrh.HasValue || (o.TargetSalary.HasValue && o.TargetSalary.Value <= c.TargetSalaryToSrh.Value))
				&& (!c.InsuranceStartDateSrh.HasValue || (o.InsuranceStartDate.HasValue && o.InsuranceStartDate.Value.Equals(c.InsuranceStartDateSrh.Value)))
				&& (!c.InsuranceStartDateFromSrh.HasValue || (o.InsuranceStartDate.HasValue && o.InsuranceStartDate.Value >= c.InsuranceStartDateFromSrh.Value))
				&& (!c.InsuranceStartDateToSrh.HasValue || (o.InsuranceStartDate.HasValue && o.InsuranceStartDate.Value <= c.InsuranceStartDateToSrh.Value))
				&& (!c.InsuranceEndDateSrh.HasValue || (o.InsuranceEndDate.HasValue && o.InsuranceEndDate.Value.Equals(c.InsuranceEndDateSrh.Value)))
				&& (!c.InsuranceEndDateFromSrh.HasValue || (o.InsuranceEndDate.HasValue && o.InsuranceEndDate.Value >= c.InsuranceEndDateFromSrh.Value))
				&& (!c.InsuranceEndDateToSrh.HasValue || (o.InsuranceEndDate.HasValue && o.InsuranceEndDate.Value <= c.InsuranceEndDateToSrh.Value))
				&& (String.IsNullOrEmpty(c.GaoKaoBatchSrh) || o.GaoKaoBatch.Contains(c.GaoKaoBatchSrh))
				&& (String.IsNullOrEmpty(c.GiveNotebookSrh) || o.GiveNotebook.Contains(c.GiveNotebookSrh))
				&& (!c.MaxSalarySrh.HasValue || (o.MaxSalary.HasValue && o.MaxSalary.Value.Equals(c.MaxSalarySrh.Value)))
				&& (!c.MaxSalaryFromSrh.HasValue || (o.MaxSalary.HasValue && o.MaxSalary.Value >= c.MaxSalaryFromSrh.Value))
				&& (!c.MaxSalaryToSrh.HasValue || (o.MaxSalary.HasValue && o.MaxSalary.Value <= c.MaxSalaryToSrh.Value))
				&& (!c.CurrentSalarySrh.HasValue || (o.CurrentSalary.HasValue && o.CurrentSalary.Value.Equals(c.CurrentSalarySrh.Value)))
				&& (!c.CurrentSalaryFromSrh.HasValue || (o.CurrentSalary.HasValue && o.CurrentSalary.Value >= c.CurrentSalaryFromSrh.Value))
				&& (!c.CurrentSalaryToSrh.HasValue || (o.CurrentSalary.HasValue && o.CurrentSalary.Value <= c.CurrentSalaryToSrh.Value))
				&& (!c.FirstSalarySrh.HasValue || (o.FirstSalary.HasValue && o.FirstSalary.Value.Equals(c.FirstSalarySrh.Value)))
				&& (!c.FirstSalaryFromSrh.HasValue || (o.FirstSalary.HasValue && o.FirstSalary.Value >= c.FirstSalaryFromSrh.Value))
				&& (!c.FirstSalaryToSrh.HasValue || (o.FirstSalary.HasValue && o.FirstSalary.Value <= c.FirstSalaryToSrh.Value))
				&& (!c.BeginSchoolTimeSrh.HasValue || (o.BeginSchoolTime.HasValue && o.BeginSchoolTime.Value.Equals(c.BeginSchoolTimeSrh.Value)))
				&& (!c.BeginSchoolTimeFromSrh.HasValue || (o.BeginSchoolTime.HasValue && o.BeginSchoolTime.Value >= c.BeginSchoolTimeFromSrh.Value))
				&& (!c.BeginSchoolTimeToSrh.HasValue || (o.BeginSchoolTime.HasValue && o.BeginSchoolTime.Value <= c.BeginSchoolTimeToSrh.Value))
				&& (String.IsNullOrEmpty(c.MasterName1Srh) || o.MasterName1.Contains(c.MasterName1Srh))
				&& (String.IsNullOrEmpty(c.MasterName2Srh) || o.MasterName2.Contains(c.MasterName2Srh))
				&& (String.IsNullOrEmpty(c.MasterName3Srh) || o.MasterName3.Contains(c.MasterName3Srh))
				&& (String.IsNullOrEmpty(c.TeacherName1Srh) || o.TeacherName1.Contains(c.TeacherName1Srh))
				&& (String.IsNullOrEmpty(c.TeacherName2Srh) || o.TeacherName2.Contains(c.TeacherName2Srh))
				&& (String.IsNullOrEmpty(c.TeacherName3Srh) || o.TeacherName3.Contains(c.TeacherName3Srh))
				&& (!c.MasterId1Srh.HasValue || (o.MasterId1.HasValue && o.MasterId1.Value.Equals(c.MasterId1Srh.Value)))
				&& (!c.MasterId1FromSrh.HasValue || (o.MasterId1.HasValue && o.MasterId1.Value >= c.MasterId1FromSrh.Value))
				&& (!c.MasterId1ToSrh.HasValue || (o.MasterId1.HasValue && o.MasterId1.Value <= c.MasterId1ToSrh.Value))
				&& (!c.MasterId2Srh.HasValue || (o.MasterId2.HasValue && o.MasterId2.Value.Equals(c.MasterId2Srh.Value)))
				&& (!c.MasterId2FromSrh.HasValue || (o.MasterId2.HasValue && o.MasterId2.Value >= c.MasterId2FromSrh.Value))
				&& (!c.MasterId2ToSrh.HasValue || (o.MasterId2.HasValue && o.MasterId2.Value <= c.MasterId2ToSrh.Value))
				&& (!c.MasterId3Srh.HasValue || (o.MasterId3.HasValue && o.MasterId3.Value.Equals(c.MasterId3Srh.Value)))
				&& (!c.MasterId3FromSrh.HasValue || (o.MasterId3.HasValue && o.MasterId3.Value >= c.MasterId3FromSrh.Value))
				&& (!c.MasterId3ToSrh.HasValue || (o.MasterId3.HasValue && o.MasterId3.Value <= c.MasterId3ToSrh.Value))
				&& (!c.TeacherId1Srh.HasValue || (o.TeacherId1.HasValue && o.TeacherId1.Value.Equals(c.TeacherId1Srh.Value)))
				&& (!c.TeacherId1FromSrh.HasValue || (o.TeacherId1.HasValue && o.TeacherId1.Value >= c.TeacherId1FromSrh.Value))
				&& (!c.TeacherId1ToSrh.HasValue || (o.TeacherId1.HasValue && o.TeacherId1.Value <= c.TeacherId1ToSrh.Value))
				&& (!c.TeacherId2Srh.HasValue || (o.TeacherId2.HasValue && o.TeacherId2.Value.Equals(c.TeacherId2Srh.Value)))
				&& (!c.TeacherId2FromSrh.HasValue || (o.TeacherId2.HasValue && o.TeacherId2.Value >= c.TeacherId2FromSrh.Value))
				&& (!c.TeacherId2ToSrh.HasValue || (o.TeacherId2.HasValue && o.TeacherId2.Value <= c.TeacherId2ToSrh.Value))
				&& (!c.TeacherId3Srh.HasValue || (o.TeacherId3.HasValue && o.TeacherId3.Value.Equals(c.TeacherId3Srh.Value)))
				&& (!c.TeacherId3FromSrh.HasValue || (o.TeacherId3.HasValue && o.TeacherId3.Value >= c.TeacherId3FromSrh.Value))
				&& (!c.TeacherId3ToSrh.HasValue || (o.TeacherId3.HasValue && o.TeacherId3.Value <= c.TeacherId3ToSrh.Value))
				&& (String.IsNullOrEmpty(c.QualificationSchoolSrh) || o.QualificationSchool.Contains(c.QualificationSchoolSrh))
				//&& (String.IsNullOrEmpty(c.InsuranceStatusSrh) || o.InsuranceStatus.Contains(c.InsuranceStatusSrh))
				&& (String.IsNullOrEmpty(c.OldOaIdSrh) || o.OldOaId.Contains(c.OldOaIdSrh))
				&& (String.IsNullOrEmpty(c.OldOaInfoSourceSubTypeNameSrh) || o.OldOaInfoSourceSubTypeName.Contains(c.OldOaInfoSourceSubTypeNameSrh))
				&& (String.IsNullOrEmpty(c.OldOaClassSrh) || o.OldOaClass.Contains(c.OldOaClassSrh))
				&& (String.IsNullOrEmpty(c.HasRelTeacherSrh) || o.HasRelTeacher.Contains(c.HasRelTeacherSrh))
				&& (String.IsNullOrEmpty(c.RelTeacherSrh) || o.RelTeacher.Contains(c.RelTeacherSrh))
				&& (String.IsNullOrEmpty(c.HomeIntroSrh) || o.HomeIntro.Contains(c.HomeIntroSrh))
				&& (String.IsNullOrEmpty(c.Give1Srh) || o.Give1.Contains(c.Give1Srh))
				&& (String.IsNullOrEmpty(c.Give2Srh) || o.Give2.Contains(c.Give2Srh))
				&& (String.IsNullOrEmpty(c.Give3Srh) || o.Give3.Contains(c.Give3Srh))
				&& (String.IsNullOrEmpty(c.Receive1Srh) || o.Receive1.Contains(c.Receive1Srh))
				&& (String.IsNullOrEmpty(c.Receive2Srh) || o.Receive2.Contains(c.Receive2Srh))
				&& (String.IsNullOrEmpty(c.Receive3Srh) || o.Receive3.Contains(c.Receive3Srh))
				&& (String.IsNullOrEmpty(c.Receive4Srh) || o.Receive4.Contains(c.Receive4Srh))
				&& (String.IsNullOrEmpty(c.Receive5Srh) || o.Receive5.Contains(c.Receive5Srh))
				&& (String.IsNullOrEmpty(c.Receive6Srh) || o.Receive6.Contains(c.Receive6Srh))
				&& (String.IsNullOrEmpty(c.Pic1Srh) || o.Pic1.Contains(c.Pic1Srh))
				&& (String.IsNullOrEmpty(c.Pic2Srh) || o.Pic2.Contains(c.Pic2Srh))
				&& (String.IsNullOrEmpty(c.Pic3Srh) || o.Pic3.Contains(c.Pic3Srh))
				&& (String.IsNullOrEmpty(c.Pic4Srh) || o.Pic4.Contains(c.Pic4Srh))
				&& (String.IsNullOrEmpty(c.Pic5Srh) || o.Pic5.Contains(c.Pic5Srh))
				&& (String.IsNullOrEmpty(c.Pic6Srh) || o.Pic6.Contains(c.Pic6Srh))
				&& (String.IsNullOrEmpty(c.SemesterSrh) || o.Clazz.Semester.Contains(c.SemesterSrh))
				&& (String.IsNullOrEmpty(c.ClazzNameSrh) || o.Clazz.Name.Contains(c.ClazzNameSrh))
				&& (String.IsNullOrEmpty(c.GruduateSchoolNameSrh) || (o.GruduateSchoolId.HasValue && o.GruduateSchool.Name.Contains(c.GruduateSchoolNameSrh)))
				&& (String.IsNullOrEmpty(c.AddrZoneSrh) || o.District.Name.Contains(c.AddrZoneSrh)
					|| o.District.City.Name.Contains(c.AddrZoneSrh) || o.District.City.Province.Name.Contains(c.AddrZoneSrh))
				&& (String.IsNullOrEmpty(c.ContactWay) || o.Email.Contains(c.ContactWay)
					 || (o.HomeTelephone!=null && o.HomeTelephone.Contains(c.ContactWay))
					 || (o.Mobile != null && o.Mobile.Contains(c.ContactWay))
					  || (o.OfficeTelephone != null && o.OfficeTelephone.Contains(c.ContactWay))
					  || (o.QQ != null && o.QQ.Contains(c.ContactWay))
				)
				//&& (String.IsNullOrEmpty(c.InsuranceStatusSrh) || o.InsuranceStatus.Contains(c.InsuranceStatusSrh))
				&& (String.IsNullOrEmpty(c.InsuranceStatusSrh) || c.InsuranceStatusSrh.Equals("全部")
					|| (c.InsuranceStatusSrh.Equals("已买保险") && (!String.IsNullOrEmpty(o.InsuranceStatus) && o.InsuranceStatus.Equals("已购买")))
					|| (c.InsuranceStatusSrh.Equals("未买保险") && (String.IsNullOrEmpty(o.InsuranceStatus) || o.InsuranceStatus.Equals("未购买")))
				)
			);
		}
	}
}
