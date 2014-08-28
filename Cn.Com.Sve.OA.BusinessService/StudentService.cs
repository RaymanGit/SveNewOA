using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface IStudentService {
		PagedModel<Student> Search(StudentCriteria c);
		void BuyInsurance(DateTime start, DateTime end, List<int> idList);
	}
	public partial class StudentService : IStudentService {
		public PagedModel<Student> Search(StudentCriteria c) {
			PagedModel<Student> m = new PagedModel<Student>();
			var r = this.Repository.Search(c);
			#region 处理排序
			if (!String.IsNullOrEmpty(c.sortname)) {
				if (c.sortname.ToLower().Equals("clazz-name")) {
					r = r.OrderBy(o => o.ClazzId.HasValue ? o.Clazz.Name : "(未指定班级)").ThenBy(o => o.Name);
				}
				if (c.sortname.ToLower().Equals("id")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Id);
					} else {
						r = r.OrderByDescending(o => o.Id);
					}
				}
				if (c.sortname.ToLower().Equals("name")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Name);
					} else {
						r = r.OrderByDescending(o => o.Name);
					}
				}
				if (c.sortname.ToLower().Equals("pinyin")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.PinYin);
					} else {
						r = r.OrderByDescending(o => o.PinYin);
					}
				}
				if (c.sortname.ToLower().Equals("gender")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Gender);
					} else {
						r = r.OrderByDescending(o => o.Gender);
					}
				}
				if (c.sortname.ToLower().Equals("birthday")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Birthday);
					} else {
						r = r.OrderByDescending(o => o.Birthday);
					}
				}
				if (c.sortname.ToLower().Equals("edulevel")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.EduLevel);
					} else {
						r = r.OrderByDescending(o => o.EduLevel);
					}
				}
				if (c.sortname.ToLower().Equals("graduatedate")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.GraduateDate);
					} else {
						r = r.OrderByDescending(o => o.GraduateDate);
					}
				}
				if (c.sortname.ToLower().Equals("score")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Score);
					} else {
						r = r.OrderByDescending(o => o.Score);
					}
				}
				if (c.sortname.ToLower().Equals("gruduateschoolid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.GruduateSchoolId);
					} else {
						r = r.OrderByDescending(o => o.GruduateSchoolId);
					}
				}
				if (c.sortname.ToLower().Equals("profession")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Profession);
					} else {
						r = r.OrderByDescending(o => o.Profession);
					}
				}
				if (c.sortname.ToLower().Equals("idcardno")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.IdCardNo);
					} else {
						r = r.OrderByDescending(o => o.IdCardNo);
					}
				}
				if (c.sortname.ToLower().Equals("hukoutype")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.HuKouType);
					} else {
						r = r.OrderByDescending(o => o.HuKouType);
					}
				}
				if (c.sortname.ToLower().Equals("address")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Address);
					} else {
						r = r.OrderByDescending(o => o.Address);
					}
				}
				if (c.sortname.ToLower().Equals("postcode")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Postcode);
					} else {
						r = r.OrderByDescending(o => o.Postcode);
					}
				}
				if (c.sortname.ToLower().Equals("feesource")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.FeeSource);
					} else {
						r = r.OrderByDescending(o => o.FeeSource);
					}
				}
				if (c.sortname.ToLower().Equals("smallinfosourceid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.SmallInfoSourceId);
					} else {
						r = r.OrderByDescending(o => o.SmallInfoSourceId);
					}
				}
				if (c.sortname.ToLower().Equals("qq")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.QQ);
					} else {
						r = r.OrderByDescending(o => o.QQ);
					}
				}
				if (c.sortname.ToLower().Equals("email")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Email);
					} else {
						r = r.OrderByDescending(o => o.Email);
					}
				}
				if (c.sortname.ToLower().Equals("mobile")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Mobile);
					} else {
						r = r.OrderByDescending(o => o.Mobile);
					}
				}
				if (c.sortname.ToLower().Equals("hometelephone")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.HomeTelephone);
					} else {
						r = r.OrderByDescending(o => o.HomeTelephone);
					}
				}
				if (c.sortname.ToLower().Equals("officetelephone")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.OfficeTelephone);
					} else {
						r = r.OrderByDescending(o => o.OfficeTelephone);
					}
				}
				if (c.sortname.ToLower().Equals("memberreltype1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberRelType1);
					} else {
						r = r.OrderByDescending(o => o.MemberRelType1);
					}
				}
				if (c.sortname.ToLower().Equals("membername1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberName1);
					} else {
						r = r.OrderByDescending(o => o.MemberName1);
					}
				}
				if (c.sortname.ToLower().Equals("membercompany1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberCompany1);
					} else {
						r = r.OrderByDescending(o => o.MemberCompany1);
					}
				}
				if (c.sortname.ToLower().Equals("memberposition1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberPosition1);
					} else {
						r = r.OrderByDescending(o => o.MemberPosition1);
					}
				}
				if (c.sortname.ToLower().Equals("membermobile1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberMobile1);
					} else {
						r = r.OrderByDescending(o => o.MemberMobile1);
					}
				}
				if (c.sortname.ToLower().Equals("memberreltype2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberRelType2);
					} else {
						r = r.OrderByDescending(o => o.MemberRelType2);
					}
				}
				if (c.sortname.ToLower().Equals("membername2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberName2);
					} else {
						r = r.OrderByDescending(o => o.MemberName2);
					}
				}
				if (c.sortname.ToLower().Equals("membercompany2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberCompany2);
					} else {
						r = r.OrderByDescending(o => o.MemberCompany2);
					}
				}
				if (c.sortname.ToLower().Equals("memberposition2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberPosition2);
					} else {
						r = r.OrderByDescending(o => o.MemberPosition2);
					}
				}
				if (c.sortname.ToLower().Equals("membermobile2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberMobile2);
					} else {
						r = r.OrderByDescending(o => o.MemberMobile2);
					}
				}
				if (c.sortname.ToLower().Equals("memberreltype3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberRelType3);
					} else {
						r = r.OrderByDescending(o => o.MemberRelType3);
					}
				}
				if (c.sortname.ToLower().Equals("membername3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberName3);
					} else {
						r = r.OrderByDescending(o => o.MemberName3);
					}
				}
				if (c.sortname.ToLower().Equals("membercompany3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberCompany3);
					} else {
						r = r.OrderByDescending(o => o.MemberCompany3);
					}
				}
				if (c.sortname.ToLower().Equals("memberposition3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberPosition3);
					} else {
						r = r.OrderByDescending(o => o.MemberPosition3);
					}
				}
				if (c.sortname.ToLower().Equals("membermobile3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberMobile3);
					} else {
						r = r.OrderByDescending(o => o.MemberMobile3);
					}
				}
				if (c.sortname.ToLower().Equals("memberreltype4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberRelType4);
					} else {
						r = r.OrderByDescending(o => o.MemberRelType4);
					}
				}
				if (c.sortname.ToLower().Equals("membername4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberName4);
					} else {
						r = r.OrderByDescending(o => o.MemberName4);
					}
				}
				if (c.sortname.ToLower().Equals("membercompany4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberCompany4);
					} else {
						r = r.OrderByDescending(o => o.MemberCompany4);
					}
				}
				if (c.sortname.ToLower().Equals("memberposition4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberPosition4);
					} else {
						r = r.OrderByDescending(o => o.MemberPosition4);
					}
				}
				if (c.sortname.ToLower().Equals("membermobile4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MemberMobile4);
					} else {
						r = r.OrderByDescending(o => o.MemberMobile4);
					}
				}
				if (c.sortname.ToLower().Equals("workstate")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.WorkState);
					} else {
						r = r.OrderByDescending(o => o.WorkState);
					}
				}
				if (c.sortname.ToLower().Equals("studyduration1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyDuration1);
					} else {
						r = r.OrderByDescending(o => o.StudyDuration1);
					}
				}
				if (c.sortname.ToLower().Equals("studyschool1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudySchool1);
					} else {
						r = r.OrderByDescending(o => o.StudySchool1);
					}
				}
				if (c.sortname.ToLower().Equals("studyposition1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyPosition1);
					} else {
						r = r.OrderByDescending(o => o.StudyPosition1);
					}
				}
				if (c.sortname.ToLower().Equals("studyduration2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyDuration2);
					} else {
						r = r.OrderByDescending(o => o.StudyDuration2);
					}
				}
				if (c.sortname.ToLower().Equals("studyschool2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudySchool2);
					} else {
						r = r.OrderByDescending(o => o.StudySchool2);
					}
				}
				if (c.sortname.ToLower().Equals("studyposition2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyPosition2);
					} else {
						r = r.OrderByDescending(o => o.StudyPosition2);
					}
				}
				if (c.sortname.ToLower().Equals("studyduration3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyDuration3);
					} else {
						r = r.OrderByDescending(o => o.StudyDuration3);
					}
				}
				if (c.sortname.ToLower().Equals("studyschool3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudySchool3);
					} else {
						r = r.OrderByDescending(o => o.StudySchool3);
					}
				}
				if (c.sortname.ToLower().Equals("studyposition3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudyPosition3);
					} else {
						r = r.OrderByDescending(o => o.StudyPosition3);
					}
				}
				if (c.sortname.ToLower().Equals("softwareexp")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.SoftwareExp);
					} else {
						r = r.OrderByDescending(o => o.SoftwareExp);
					}
				}
				if (c.sortname.ToLower().Equals("programexp")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.ProgramExp);
					} else {
						r = r.OrderByDescending(o => o.ProgramExp);
					}
				}
				if (c.sortname.ToLower().Equals("networkexp")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.NetworkExp);
					} else {
						r = r.OrderByDescending(o => o.NetworkExp);
					}
				}
				if (c.sortname.ToLower().Equals("relcourse")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.RelCourse);
					} else {
						r = r.OrderByDescending(o => o.RelCourse);
					}
				}
				if (c.sortname.ToLower().Equals("districtid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.DistrictId);
					} else {
						r = r.OrderByDescending(o => o.DistrictId);
					}
				}
				if (c.sortname.ToLower().Equals("intentcity")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.IntentCity);
					} else {
						r = r.OrderByDescending(o => o.IntentCity);
					}
				}
				if (c.sortname.ToLower().Equals("clazzid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.ClazzId);
					} else {
						r = r.OrderByDescending(o => o.ClazzId);
					}
				}
				if (c.sortname.ToLower().Equals("studentno")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.StudentNo);
					} else {
						r = r.OrderByDescending(o => o.StudentNo);
					}
				}
				if (c.sortname.ToLower().Equals("inschooldate")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.InSchoolDate);
					} else {
						r = r.OrderByDescending(o => o.InSchoolDate);
					}
				}
				if (c.sortname.ToLower().Equals("isdorm")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.IsDorm);
					} else {
						r = r.OrderByDescending(o => o.IsDorm);
					}
				}
				if (c.sortname.ToLower().Equals("dormno")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.DormNo);
					} else {
						r = r.OrderByDescending(o => o.DormNo);
					}
				}
				if (c.sortname.ToLower().Equals("givecourseware")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.GiveCourseware);
					} else {
						r = r.OrderByDescending(o => o.GiveCourseware);
					}
				}
				if (c.sortname.ToLower().Equals("consultants")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Consultants);
					} else {
						r = r.OrderByDescending(o => o.Consultants);
					}
				}
				if (c.sortname.ToLower().Equals("remark")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Remark);
					} else {
						r = r.OrderByDescending(o => o.Remark);
					}
				}
				if (c.sortname.ToLower().Equals("createtime")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.CreateTime);
					} else {
						r = r.OrderByDescending(o => o.CreateTime);
					}
				}
				if (c.sortname.ToLower().Equals("lastupdatetime")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.LastUpdateTime);
					} else {
						r = r.OrderByDescending(o => o.LastUpdateTime);
					}
				}
				if (c.sortname.ToLower().Equals("isgetqualification")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.IsGetQualification);
					} else {
						r = r.OrderByDescending(o => o.IsGetQualification);
					}
				}
				if (c.sortname.ToLower().Equals("status")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Status);
					} else {
						r = r.OrderByDescending(o => o.Status);
					}
				}
				if (c.sortname.ToLower().Equals("technicalway")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TechnicalWay);
					} else {
						r = r.OrderByDescending(o => o.TechnicalWay);
					}
				}
				if (c.sortname.ToLower().Equals("needobtainwork")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.NeedObtainWork);
					} else {
						r = r.OrderByDescending(o => o.NeedObtainWork);
					}
				}
				if (c.sortname.ToLower().Equals("intentposition")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.IntentPosition);
					} else {
						r = r.OrderByDescending(o => o.IntentPosition);
					}
				}
				if (c.sortname.ToLower().Equals("targetsalary")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TargetSalary);
					} else {
						r = r.OrderByDescending(o => o.TargetSalary);
					}
				}
				if (c.sortname.ToLower().Equals("insurancestartdate")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.InsuranceStartDate);
					} else {
						r = r.OrderByDescending(o => o.InsuranceStartDate);
					}
				}
				if (c.sortname.ToLower().Equals("insuranceenddate")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.InsuranceEndDate);
					} else {
						r = r.OrderByDescending(o => o.InsuranceEndDate);
					}
				}
				if (c.sortname.ToLower().Equals("gaokaobatch")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.GaoKaoBatch);
					} else {
						r = r.OrderByDescending(o => o.GaoKaoBatch);
					}
				}
				if (c.sortname.ToLower().Equals("givenotebook")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.GiveNotebook);
					} else {
						r = r.OrderByDescending(o => o.GiveNotebook);
					}
				}
				if (c.sortname.ToLower().Equals("maxsalary")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MaxSalary);
					} else {
						r = r.OrderByDescending(o => o.MaxSalary);
					}
				}
				if (c.sortname.ToLower().Equals("currentsalary")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.CurrentSalary);
					} else {
						r = r.OrderByDescending(o => o.CurrentSalary);
					}
				}
				if (c.sortname.ToLower().Equals("firstsalary")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.FirstSalary);
					} else {
						r = r.OrderByDescending(o => o.FirstSalary);
					}
				}
				if (c.sortname.ToLower().Equals("beginschooltime")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.BeginSchoolTime);
					} else {
						r = r.OrderByDescending(o => o.BeginSchoolTime);
					}
				}
				if (c.sortname.ToLower().Equals("mastername1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterName1);
					} else {
						r = r.OrderByDescending(o => o.MasterName1);
					}
				}
				if (c.sortname.ToLower().Equals("mastername2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterName2);
					} else {
						r = r.OrderByDescending(o => o.MasterName2);
					}
				}
				if (c.sortname.ToLower().Equals("mastername3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterName3);
					} else {
						r = r.OrderByDescending(o => o.MasterName3);
					}
				}
				if (c.sortname.ToLower().Equals("teachername1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherName1);
					} else {
						r = r.OrderByDescending(o => o.TeacherName1);
					}
				}
				if (c.sortname.ToLower().Equals("teachername2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherName2);
					} else {
						r = r.OrderByDescending(o => o.TeacherName2);
					}
				}
				if (c.sortname.ToLower().Equals("teachername3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherName3);
					} else {
						r = r.OrderByDescending(o => o.TeacherName3);
					}
				}
				if (c.sortname.ToLower().Equals("masterid1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterId1);
					} else {
						r = r.OrderByDescending(o => o.MasterId1);
					}
				}
				if (c.sortname.ToLower().Equals("masterid2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterId2);
					} else {
						r = r.OrderByDescending(o => o.MasterId2);
					}
				}
				if (c.sortname.ToLower().Equals("masterid3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.MasterId3);
					} else {
						r = r.OrderByDescending(o => o.MasterId3);
					}
				}
				if (c.sortname.ToLower().Equals("teacherid1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherId1);
					} else {
						r = r.OrderByDescending(o => o.TeacherId1);
					}
				}
				if (c.sortname.ToLower().Equals("teacherid2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherId2);
					} else {
						r = r.OrderByDescending(o => o.TeacherId2);
					}
				}
				if (c.sortname.ToLower().Equals("teacherid3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.TeacherId3);
					} else {
						r = r.OrderByDescending(o => o.TeacherId3);
					}
				}
				if (c.sortname.ToLower().Equals("qualificationschool")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.QualificationSchool);
					} else {
						r = r.OrderByDescending(o => o.QualificationSchool);
					}
				}
				if (c.sortname.ToLower().Equals("insurancestatus")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.InsuranceStatus);
					} else {
						r = r.OrderByDescending(o => o.InsuranceStatus);
					}
				}
				if (c.sortname.ToLower().Equals("oldoaid")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.OldOaId);
					} else {
						r = r.OrderByDescending(o => o.OldOaId);
					}
				}
				if (c.sortname.ToLower().Equals("oldoainfosourcesubtypename")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.OldOaInfoSourceSubTypeName);
					} else {
						r = r.OrderByDescending(o => o.OldOaInfoSourceSubTypeName);
					}
				}
				if (c.sortname.ToLower().Equals("oldoaclass")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.OldOaClass);
					} else {
						r = r.OrderByDescending(o => o.OldOaClass);
					}
				}
				if (c.sortname.ToLower().Equals("hasrelteacher")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.HasRelTeacher);
					} else {
						r = r.OrderByDescending(o => o.HasRelTeacher);
					}
				}
				if (c.sortname.ToLower().Equals("relteacher")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.RelTeacher);
					} else {
						r = r.OrderByDescending(o => o.RelTeacher);
					}
				}
				if (c.sortname.ToLower().Equals("homeintro")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.HomeIntro);
					} else {
						r = r.OrderByDescending(o => o.HomeIntro);
					}
				}
				if (c.sortname.ToLower().Equals("give1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Give1);
					} else {
						r = r.OrderByDescending(o => o.Give1);
					}
				}
				if (c.sortname.ToLower().Equals("give2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Give2);
					} else {
						r = r.OrderByDescending(o => o.Give2);
					}
				}
				if (c.sortname.ToLower().Equals("give3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Give3);
					} else {
						r = r.OrderByDescending(o => o.Give3);
					}
				}
				if (c.sortname.ToLower().Equals("receive1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive1);
					} else {
						r = r.OrderByDescending(o => o.Receive1);
					}
				}
				if (c.sortname.ToLower().Equals("receive2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive2);
					} else {
						r = r.OrderByDescending(o => o.Receive2);
					}
				}
				if (c.sortname.ToLower().Equals("receive3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive3);
					} else {
						r = r.OrderByDescending(o => o.Receive3);
					}
				}
				if (c.sortname.ToLower().Equals("receive4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive4);
					} else {
						r = r.OrderByDescending(o => o.Receive4);
					}
				}
				if (c.sortname.ToLower().Equals("receive5")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive5);
					} else {
						r = r.OrderByDescending(o => o.Receive5);
					}
				}
				if (c.sortname.ToLower().Equals("receive6")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Receive6);
					} else {
						r = r.OrderByDescending(o => o.Receive6);
					}
				}
				if (c.sortname.ToLower().Equals("pic1")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic1);
					} else {
						r = r.OrderByDescending(o => o.Pic1);
					}
				}
				if (c.sortname.ToLower().Equals("pic2")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic2);
					} else {
						r = r.OrderByDescending(o => o.Pic2);
					}
				}
				if (c.sortname.ToLower().Equals("pic3")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic3);
					} else {
						r = r.OrderByDescending(o => o.Pic3);
					}
				}
				if (c.sortname.ToLower().Equals("pic4")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic4);
					} else {
						r = r.OrderByDescending(o => o.Pic4);
					}
				}
				if (c.sortname.ToLower().Equals("pic5")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic5);
					} else {
						r = r.OrderByDescending(o => o.Pic5);
					}
				}
				if (c.sortname.ToLower().Equals("pic6")) {
					if (c.sortorder.ToLower().Equals("asc")) {
						r = r.OrderBy(o => o.Pic6);
					} else {
						r = r.OrderByDescending(o => o.Pic6);
					}
				}

			}
			#endregion

			m.RecordCount = r.Count();
			if (c.pagesize.HasValue) {
				int page = c.page ?? 1;
				int pageCount = m.RecordCount / c.pagesize.Value;
				if (m.RecordCount % c.pagesize.Value > 0) {
					pageCount++;
				}
				int skip = (page - 1) * c.pagesize.Value;
				if (skip > 0) {
					r = r.Skip(skip);
				}
				r = r.Take(c.pagesize.Value);
			}

			m.Data = r.ToList();
			return m;
		}

		public void BuyInsurance(DateTime start, DateTime end, List<int> idList) {
			idList.ForEach(id => {
				var o = this.Repository.FindById(id);
				o.InsuranceStatus = "已购买";
				o.InsuranceStartDate = start;
				o.InsuranceEndDate = end;
				this.Repository.Update(o);
			});
			this.Db.Save();
		}
	}
}
