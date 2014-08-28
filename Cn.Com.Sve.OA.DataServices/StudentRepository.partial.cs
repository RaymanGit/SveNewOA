using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class StudentRepository : IStudentRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public StudentRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Student entity) {
    		this.DbContext.Students.AddObject(entity);
    	}
    
    	public void Update(Student entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.PinYin = entity.PinYin;
    			e.Gender = entity.Gender;
    			e.Birthday = entity.Birthday;
    			e.EduLevel = entity.EduLevel;
    			e.GraduateDate = entity.GraduateDate;
    			e.Score = entity.Score;
    			e.GruduateSchoolId = entity.GruduateSchoolId;
    			e.Profession = entity.Profession;
    			e.IdCardNo = entity.IdCardNo;
    			e.HuKouType = entity.HuKouType;
    			e.Address = entity.Address;
    			e.Postcode = entity.Postcode;
    			e.FeeSource = entity.FeeSource;
    			e.SmallInfoSourceId = entity.SmallInfoSourceId;
    			e.QQ = entity.QQ;
    			e.Email = entity.Email;
    			e.Mobile = entity.Mobile;
    			e.HomeTelephone = entity.HomeTelephone;
    			e.OfficeTelephone = entity.OfficeTelephone;
    			e.MemberRelType1 = entity.MemberRelType1;
    			e.MemberName1 = entity.MemberName1;
    			e.MemberCompany1 = entity.MemberCompany1;
    			e.MemberPosition1 = entity.MemberPosition1;
    			e.MemberMobile1 = entity.MemberMobile1;
    			e.MemberRelType2 = entity.MemberRelType2;
    			e.MemberName2 = entity.MemberName2;
    			e.MemberCompany2 = entity.MemberCompany2;
    			e.MemberPosition2 = entity.MemberPosition2;
    			e.MemberMobile2 = entity.MemberMobile2;
    			e.MemberRelType3 = entity.MemberRelType3;
    			e.MemberName3 = entity.MemberName3;
    			e.MemberCompany3 = entity.MemberCompany3;
    			e.MemberPosition3 = entity.MemberPosition3;
    			e.MemberMobile3 = entity.MemberMobile3;
    			e.MemberRelType4 = entity.MemberRelType4;
    			e.MemberName4 = entity.MemberName4;
    			e.MemberCompany4 = entity.MemberCompany4;
    			e.MemberPosition4 = entity.MemberPosition4;
    			e.MemberMobile4 = entity.MemberMobile4;
    			e.WorkState = entity.WorkState;
    			e.StudyDuration1 = entity.StudyDuration1;
    			e.StudySchool1 = entity.StudySchool1;
    			e.StudyPosition1 = entity.StudyPosition1;
    			e.StudyDuration2 = entity.StudyDuration2;
    			e.StudySchool2 = entity.StudySchool2;
    			e.StudyPosition2 = entity.StudyPosition2;
    			e.StudyDuration3 = entity.StudyDuration3;
    			e.StudySchool3 = entity.StudySchool3;
    			e.StudyPosition3 = entity.StudyPosition3;
    			e.SoftwareExp = entity.SoftwareExp;
    			e.ProgramExp = entity.ProgramExp;
    			e.NetworkExp = entity.NetworkExp;
    			e.RelCourse = entity.RelCourse;
    			e.DistrictId = entity.DistrictId;
    			e.IntentCity = entity.IntentCity;
    			e.ClazzId = entity.ClazzId;
    			e.StudentNo = entity.StudentNo;
    			e.InSchoolDate = entity.InSchoolDate;
    			e.IsDorm = entity.IsDorm;
    			e.DormNo = entity.DormNo;
    			e.GiveCourseware = entity.GiveCourseware;
    			e.Consultants = entity.Consultants;
    			e.Remark = entity.Remark;
    			e.CreateTime = entity.CreateTime;
    			e.LastUpdateTime = entity.LastUpdateTime;
    			e.IsGetQualification = entity.IsGetQualification;
    			e.Status = entity.Status;
    			e.TechnicalWay = entity.TechnicalWay;
    			e.NeedObtainWork = entity.NeedObtainWork;
    			e.IntentPosition = entity.IntentPosition;
    			e.TargetSalary = entity.TargetSalary;
    			e.InsuranceStartDate = entity.InsuranceStartDate;
    			e.InsuranceEndDate = entity.InsuranceEndDate;
    			e.GaoKaoBatch = entity.GaoKaoBatch;
    			e.GiveNotebook = entity.GiveNotebook;
    			e.MaxSalary = entity.MaxSalary;
    			e.CurrentSalary = entity.CurrentSalary;
    			e.FirstSalary = entity.FirstSalary;
    			e.BeginSchoolTime = entity.BeginSchoolTime;
    			e.MasterName1 = entity.MasterName1;
    			e.MasterName2 = entity.MasterName2;
    			e.MasterName3 = entity.MasterName3;
    			e.TeacherName1 = entity.TeacherName1;
    			e.TeacherName2 = entity.TeacherName2;
    			e.TeacherName3 = entity.TeacherName3;
    			e.MasterId1 = entity.MasterId1;
    			e.MasterId2 = entity.MasterId2;
    			e.MasterId3 = entity.MasterId3;
    			e.TeacherId1 = entity.TeacherId1;
    			e.TeacherId2 = entity.TeacherId2;
    			e.TeacherId3 = entity.TeacherId3;
    			e.QualificationSchool = entity.QualificationSchool;
    			e.InsuranceStatus = entity.InsuranceStatus;
    			e.OldOaId = entity.OldOaId;
    			e.OldOaInfoSourceSubTypeName = entity.OldOaInfoSourceSubTypeName;
    			e.OldOaClass = entity.OldOaClass;
    			e.HasRelTeacher = entity.HasRelTeacher;
    			e.RelTeacher = entity.RelTeacher;
    			e.HomeIntro = entity.HomeIntro;
    			e.Give1 = entity.Give1;
    			e.Give2 = entity.Give2;
    			e.Give3 = entity.Give3;
    			e.Receive1 = entity.Receive1;
    			e.Receive2 = entity.Receive2;
    			e.Receive3 = entity.Receive3;
    			e.Receive4 = entity.Receive4;
    			e.Receive5 = entity.Receive5;
    			e.Receive6 = entity.Receive6;
    			e.Pic1 = entity.Pic1;
    			e.Pic2 = entity.Pic2;
    			e.Pic3 = entity.Pic3;
    			e.Pic4 = entity.Pic4;
    			e.Pic5 = entity.Pic5;
    			e.Pic6 = entity.Pic6;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Students.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Student entity) {
    		this.DbContext.Students.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Students.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Student> FindAll() {
    		return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3");
    	}
    	public IEnumerable<Student> FindAll2() {
    		return this.DbContext.Students;
    	}
    
    	public Student FindById(int id) {
    		return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Student> FindByName(string name){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Student> FindByPinYin(string pinYin){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.PinYin.Equals(pinYin));
    			}
    	public IEnumerable<Student> FindByGender(string gender){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Gender.Equals(gender));
    			}
    	public IEnumerable<Student> FindByBirthday(Nullable<System.DateTime> birthday){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Birthday.Value.Equals(birthday.Value));
    			}
    	public IEnumerable<Student> FindByEduLevel(string eduLevel){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.EduLevel.Equals(eduLevel));
    			}
    	public IEnumerable<Student> FindByGraduateDate(Nullable<System.DateTime> graduateDate){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.GraduateDate.Value.Equals(graduateDate.Value));
    			}
    	public IEnumerable<Student> FindByScore(Nullable<int> score){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Score.Value.Equals(score.Value));
    			}
    	public IEnumerable<Student> FindByGruduateSchoolId(Nullable<int> gruduateSchoolId){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.GruduateSchoolId.Value.Equals(gruduateSchoolId.Value));
    			}
    	public IEnumerable<Student> FindByProfession(string profession){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Profession.Equals(profession));
    			}
    	public IEnumerable<Student> FindByIdCardNo(string idCardNo){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.IdCardNo.Equals(idCardNo));
    			}
    	public IEnumerable<Student> FindByHuKouType(string huKouType){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.HuKouType.Equals(huKouType));
    			}
    	public IEnumerable<Student> FindByAddress(string address){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<Student> FindByPostcode(string postcode){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Postcode.Equals(postcode));
    			}
    	public IEnumerable<Student> FindByFeeSource(string feeSource){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.FeeSource.Equals(feeSource));
    			}
    	public IEnumerable<Student> FindBySmallInfoSourceId(Nullable<int> smallInfoSourceId){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.SmallInfoSourceId.Value.Equals(smallInfoSourceId.Value));
    			}
    	public IEnumerable<Student> FindByQQ(string qQ){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<Student> FindByEmail(string email){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Email.Equals(email));
    			}
    	public IEnumerable<Student> FindByMobile(string mobile){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<Student> FindByHomeTelephone(string homeTelephone){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.HomeTelephone.Equals(homeTelephone));
    			}
    	public IEnumerable<Student> FindByOfficeTelephone(string officeTelephone){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.OfficeTelephone.Equals(officeTelephone));
    			}
    	public IEnumerable<Student> FindByMemberRelType1(string memberRelType1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberRelType1.Equals(memberRelType1));
    			}
    	public IEnumerable<Student> FindByMemberName1(string memberName1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberName1.Equals(memberName1));
    			}
    	public IEnumerable<Student> FindByMemberCompany1(string memberCompany1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberCompany1.Equals(memberCompany1));
    			}
    	public IEnumerable<Student> FindByMemberPosition1(string memberPosition1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberPosition1.Equals(memberPosition1));
    			}
    	public IEnumerable<Student> FindByMemberMobile1(string memberMobile1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberMobile1.Equals(memberMobile1));
    			}
    	public IEnumerable<Student> FindByMemberRelType2(string memberRelType2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberRelType2.Equals(memberRelType2));
    			}
    	public IEnumerable<Student> FindByMemberName2(string memberName2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberName2.Equals(memberName2));
    			}
    	public IEnumerable<Student> FindByMemberCompany2(string memberCompany2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberCompany2.Equals(memberCompany2));
    			}
    	public IEnumerable<Student> FindByMemberPosition2(string memberPosition2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberPosition2.Equals(memberPosition2));
    			}
    	public IEnumerable<Student> FindByMemberMobile2(string memberMobile2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberMobile2.Equals(memberMobile2));
    			}
    	public IEnumerable<Student> FindByMemberRelType3(string memberRelType3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberRelType3.Equals(memberRelType3));
    			}
    	public IEnumerable<Student> FindByMemberName3(string memberName3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberName3.Equals(memberName3));
    			}
    	public IEnumerable<Student> FindByMemberCompany3(string memberCompany3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberCompany3.Equals(memberCompany3));
    			}
    	public IEnumerable<Student> FindByMemberPosition3(string memberPosition3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberPosition3.Equals(memberPosition3));
    			}
    	public IEnumerable<Student> FindByMemberMobile3(string memberMobile3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberMobile3.Equals(memberMobile3));
    			}
    	public IEnumerable<Student> FindByMemberRelType4(string memberRelType4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberRelType4.Equals(memberRelType4));
    			}
    	public IEnumerable<Student> FindByMemberName4(string memberName4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberName4.Equals(memberName4));
    			}
    	public IEnumerable<Student> FindByMemberCompany4(string memberCompany4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberCompany4.Equals(memberCompany4));
    			}
    	public IEnumerable<Student> FindByMemberPosition4(string memberPosition4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberPosition4.Equals(memberPosition4));
    			}
    	public IEnumerable<Student> FindByMemberMobile4(string memberMobile4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MemberMobile4.Equals(memberMobile4));
    			}
    	public IEnumerable<Student> FindByWorkState(string workState){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.WorkState.Equals(workState));
    			}
    	public IEnumerable<Student> FindByStudyDuration1(string studyDuration1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyDuration1.Equals(studyDuration1));
    			}
    	public IEnumerable<Student> FindByStudySchool1(string studySchool1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudySchool1.Equals(studySchool1));
    			}
    	public IEnumerable<Student> FindByStudyPosition1(string studyPosition1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyPosition1.Equals(studyPosition1));
    			}
    	public IEnumerable<Student> FindByStudyDuration2(string studyDuration2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyDuration2.Equals(studyDuration2));
    			}
    	public IEnumerable<Student> FindByStudySchool2(string studySchool2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudySchool2.Equals(studySchool2));
    			}
    	public IEnumerable<Student> FindByStudyPosition2(string studyPosition2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyPosition2.Equals(studyPosition2));
    			}
    	public IEnumerable<Student> FindByStudyDuration3(string studyDuration3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyDuration3.Equals(studyDuration3));
    			}
    	public IEnumerable<Student> FindByStudySchool3(string studySchool3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudySchool3.Equals(studySchool3));
    			}
    	public IEnumerable<Student> FindByStudyPosition3(string studyPosition3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudyPosition3.Equals(studyPosition3));
    			}
    	public IEnumerable<Student> FindBySoftwareExp(string softwareExp){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.SoftwareExp.Equals(softwareExp));
    			}
    	public IEnumerable<Student> FindByProgramExp(string programExp){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.ProgramExp.Equals(programExp));
    			}
    	public IEnumerable<Student> FindByNetworkExp(string networkExp){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.NetworkExp.Equals(networkExp));
    			}
    	public IEnumerable<Student> FindByRelCourse(string relCourse){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.RelCourse.Equals(relCourse));
    			}
    	public IEnumerable<Student> FindByDistrictId(Nullable<int> districtId){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.DistrictId.Value.Equals(districtId.Value));
    			}
    	public IEnumerable<Student> FindByIntentCity(string intentCity){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.IntentCity.Equals(intentCity));
    			}
    	public IEnumerable<Student> FindByClazzId(Nullable<int> clazzId){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.ClazzId.Value.Equals(clazzId.Value));
    			}
    	public IEnumerable<Student> FindByStudentNo(string studentNo){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.StudentNo.Equals(studentNo));
    			}
    	public IEnumerable<Student> FindByInSchoolDate(Nullable<System.DateTime> inSchoolDate){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.InSchoolDate.Value.Equals(inSchoolDate.Value));
    			}
    	public IEnumerable<Student> FindByIsDorm(string isDorm){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.IsDorm.Equals(isDorm));
    			}
    	public IEnumerable<Student> FindByDormNo(string dormNo){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.DormNo.Equals(dormNo));
    			}
    	public IEnumerable<Student> FindByGiveCourseware(string giveCourseware){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.GiveCourseware.Equals(giveCourseware));
    			}
    	public IEnumerable<Student> FindByConsultants(string consultants){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Consultants.Equals(consultants));
    			}
    	public IEnumerable<Student> FindByRemark(string remark){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Remark.Equals(remark));
    			}
    	public IEnumerable<Student> FindByCreateTime(System.DateTime createTime){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.CreateTime.Equals(createTime));
    			}
    	public IEnumerable<Student> FindByLastUpdateTime(System.DateTime lastUpdateTime){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.LastUpdateTime.Equals(lastUpdateTime));
    			}
    	public IEnumerable<Student> FindByIsGetQualification(string isGetQualification){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.IsGetQualification.Equals(isGetQualification));
    			}
    	public IEnumerable<Student> FindByStatus(string status){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Status.Equals(status));
    			}
    	public IEnumerable<Student> FindByTechnicalWay(string technicalWay){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TechnicalWay.Equals(technicalWay));
    			}
    	public IEnumerable<Student> FindByNeedObtainWork(string needObtainWork){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.NeedObtainWork.Equals(needObtainWork));
    			}
    	public IEnumerable<Student> FindByIntentPosition(string intentPosition){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.IntentPosition.Equals(intentPosition));
    			}
    	public IEnumerable<Student> FindByTargetSalary(Nullable<decimal> targetSalary){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TargetSalary.Value.Equals(targetSalary.Value));
    			}
    	public IEnumerable<Student> FindByInsuranceStartDate(Nullable<System.DateTime> insuranceStartDate){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.InsuranceStartDate.Value.Equals(insuranceStartDate.Value));
    			}
    	public IEnumerable<Student> FindByInsuranceEndDate(Nullable<System.DateTime> insuranceEndDate){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.InsuranceEndDate.Value.Equals(insuranceEndDate.Value));
    			}
    	public IEnumerable<Student> FindByGaoKaoBatch(string gaoKaoBatch){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.GaoKaoBatch.Equals(gaoKaoBatch));
    			}
    	public IEnumerable<Student> FindByGiveNotebook(string giveNotebook){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.GiveNotebook.Equals(giveNotebook));
    			}
    	public IEnumerable<Student> FindByMaxSalary(Nullable<decimal> maxSalary){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MaxSalary.Value.Equals(maxSalary.Value));
    			}
    	public IEnumerable<Student> FindByCurrentSalary(Nullable<decimal> currentSalary){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.CurrentSalary.Value.Equals(currentSalary.Value));
    			}
    	public IEnumerable<Student> FindByFirstSalary(Nullable<decimal> firstSalary){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.FirstSalary.Value.Equals(firstSalary.Value));
    			}
    	public IEnumerable<Student> FindByBeginSchoolTime(Nullable<System.DateTime> beginSchoolTime){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.BeginSchoolTime.Value.Equals(beginSchoolTime.Value));
    			}
    	public IEnumerable<Student> FindByMasterName1(string masterName1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterName1.Equals(masterName1));
    			}
    	public IEnumerable<Student> FindByMasterName2(string masterName2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterName2.Equals(masterName2));
    			}
    	public IEnumerable<Student> FindByMasterName3(string masterName3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterName3.Equals(masterName3));
    			}
    	public IEnumerable<Student> FindByTeacherName1(string teacherName1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherName1.Equals(teacherName1));
    			}
    	public IEnumerable<Student> FindByTeacherName2(string teacherName2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherName2.Equals(teacherName2));
    			}
    	public IEnumerable<Student> FindByTeacherName3(string teacherName3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherName3.Equals(teacherName3));
    			}
    	public IEnumerable<Student> FindByMasterId1(Nullable<int> masterId1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterId1.Value.Equals(masterId1.Value));
    			}
    	public IEnumerable<Student> FindByMasterId2(Nullable<int> masterId2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterId2.Value.Equals(masterId2.Value));
    			}
    	public IEnumerable<Student> FindByMasterId3(Nullable<int> masterId3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.MasterId3.Value.Equals(masterId3.Value));
    			}
    	public IEnumerable<Student> FindByTeacherId1(Nullable<int> teacherId1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherId1.Value.Equals(teacherId1.Value));
    			}
    	public IEnumerable<Student> FindByTeacherId2(Nullable<int> teacherId2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherId2.Value.Equals(teacherId2.Value));
    			}
    	public IEnumerable<Student> FindByTeacherId3(Nullable<int> teacherId3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.TeacherId3.Value.Equals(teacherId3.Value));
    			}
    	public IEnumerable<Student> FindByQualificationSchool(string qualificationSchool){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.QualificationSchool.Equals(qualificationSchool));
    			}
    	public IEnumerable<Student> FindByInsuranceStatus(string insuranceStatus){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.InsuranceStatus.Equals(insuranceStatus));
    			}
    	public IEnumerable<Student> FindByOldOaId(string oldOaId){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.OldOaId.Equals(oldOaId));
    			}
    	public IEnumerable<Student> FindByOldOaInfoSourceSubTypeName(string oldOaInfoSourceSubTypeName){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.OldOaInfoSourceSubTypeName.Equals(oldOaInfoSourceSubTypeName));
    			}
    	public IEnumerable<Student> FindByOldOaClass(string oldOaClass){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.OldOaClass.Equals(oldOaClass));
    			}
    	public IEnumerable<Student> FindByHasRelTeacher(string hasRelTeacher){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.HasRelTeacher.Equals(hasRelTeacher));
    			}
    	public IEnumerable<Student> FindByRelTeacher(string relTeacher){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.RelTeacher.Equals(relTeacher));
    			}
    	public IEnumerable<Student> FindByHomeIntro(string homeIntro){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.HomeIntro.Equals(homeIntro));
    			}
    	public IEnumerable<Student> FindByGive1(string give1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Give1.Equals(give1));
    			}
    	public IEnumerable<Student> FindByGive2(string give2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Give2.Equals(give2));
    			}
    	public IEnumerable<Student> FindByGive3(string give3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Give3.Equals(give3));
    			}
    	public IEnumerable<Student> FindByReceive1(string receive1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive1.Equals(receive1));
    			}
    	public IEnumerable<Student> FindByReceive2(string receive2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive2.Equals(receive2));
    			}
    	public IEnumerable<Student> FindByReceive3(string receive3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive3.Equals(receive3));
    			}
    	public IEnumerable<Student> FindByReceive4(string receive4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive4.Equals(receive4));
    			}
    	public IEnumerable<Student> FindByReceive5(string receive5){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive5.Equals(receive5));
    			}
    	public IEnumerable<Student> FindByReceive6(string receive6){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Receive6.Equals(receive6));
    			}
    	public IEnumerable<Student> FindByPic1(string pic1){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic1.Equals(pic1));
    			}
    	public IEnumerable<Student> FindByPic2(string pic2){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic2.Equals(pic2));
    			}
    	public IEnumerable<Student> FindByPic3(string pic3){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic3.Equals(pic3));
    			}
    	public IEnumerable<Student> FindByPic4(string pic4){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic4.Equals(pic4));
    			}
    	public IEnumerable<Student> FindByPic5(string pic5){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic5.Equals(pic5));
    			}
    	public IEnumerable<Student> FindByPic6(string pic6){
    				return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => o.Pic6.Equals(pic6));
    			}
    	public IEnumerable<Student> FindByCriteria(StudentCriteria c) {
    		return this.DbContext.Students.Include("District").Include("InfoSourceSmall").Include("GruduateSchool").Include("Clazz").Include("Master1").Include("Master2").Include("Master3").Include("Teacher1").Include("Teacher2").Include("Teacher3").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.PinYinSrh) || o.PinYin.Contains(c.PinYinSrh))
    			&& (String.IsNullOrEmpty(c.GenderSrh) || o.Gender.Contains(c.GenderSrh))
    			&& (!c.BirthdaySrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value.Equals(c.BirthdaySrh.Value)))
    			&& (!c.BirthdayFromSrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value >= c.BirthdayFromSrh.Value))
    			&& (!c.BirthdayToSrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value <= c.BirthdayToSrh.Value))
    			&& (String.IsNullOrEmpty(c.EduLevelSrh) || o.EduLevel.Contains(c.EduLevelSrh))
    			&& (!c.GraduateDateSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value.Equals(c.GraduateDateSrh.Value)))
    			&& (!c.GraduateDateFromSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value >= c.GraduateDateFromSrh.Value))
    			&& (!c.GraduateDateToSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value <= c.GraduateDateToSrh.Value))
    			&& (!c.ScoreSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value.Equals(c.ScoreSrh.Value)))
    			&& (!c.ScoreFromSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value >= c.ScoreFromSrh.Value))
    			&& (!c.ScoreToSrh.HasValue || (o.Score.HasValue 			&& o.Score.Value <= c.ScoreToSrh.Value))
    			&& (!c.GruduateSchoolIdSrh.HasValue || (o.GruduateSchoolId.HasValue 			&& o.GruduateSchoolId.Value.Equals(c.GruduateSchoolIdSrh.Value)))
    			&& (!c.GruduateSchoolIdFromSrh.HasValue || (o.GruduateSchoolId.HasValue 			&& o.GruduateSchoolId.Value >= c.GruduateSchoolIdFromSrh.Value))
    			&& (!c.GruduateSchoolIdToSrh.HasValue || (o.GruduateSchoolId.HasValue 			&& o.GruduateSchoolId.Value <= c.GruduateSchoolIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.ProfessionSrh) || o.Profession.Contains(c.ProfessionSrh))
    			&& (String.IsNullOrEmpty(c.IdCardNoSrh) || o.IdCardNo.Contains(c.IdCardNoSrh))
    			&& (String.IsNullOrEmpty(c.HuKouTypeSrh) || o.HuKouType.Contains(c.HuKouTypeSrh))
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
    			&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
    			&& (String.IsNullOrEmpty(c.FeeSourceSrh) || o.FeeSource.Contains(c.FeeSourceSrh))
    			&& (!c.SmallInfoSourceIdSrh.HasValue || (o.SmallInfoSourceId.HasValue 			&& o.SmallInfoSourceId.Value.Equals(c.SmallInfoSourceIdSrh.Value)))
    			&& (!c.SmallInfoSourceIdFromSrh.HasValue || (o.SmallInfoSourceId.HasValue 			&& o.SmallInfoSourceId.Value >= c.SmallInfoSourceIdFromSrh.Value))
    			&& (!c.SmallInfoSourceIdToSrh.HasValue || (o.SmallInfoSourceId.HasValue 			&& o.SmallInfoSourceId.Value <= c.SmallInfoSourceIdToSrh.Value))
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
    			&& (!c.DistrictIdSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value.Equals(c.DistrictIdSrh.Value)))
    			&& (!c.DistrictIdFromSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value >= c.DistrictIdFromSrh.Value))
    			&& (!c.DistrictIdToSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value <= c.DistrictIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.IntentCitySrh) || o.IntentCity.Contains(c.IntentCitySrh))
    			&& (!c.ClazzIdSrh.HasValue || (o.ClazzId.HasValue 			&& o.ClazzId.Value.Equals(c.ClazzIdSrh.Value)))
    			&& (!c.ClazzIdFromSrh.HasValue || (o.ClazzId.HasValue 			&& o.ClazzId.Value >= c.ClazzIdFromSrh.Value))
    			&& (!c.ClazzIdToSrh.HasValue || (o.ClazzId.HasValue 			&& o.ClazzId.Value <= c.ClazzIdToSrh.Value))
    			&& (String.IsNullOrEmpty(c.StudentNoSrh) || o.StudentNo.Contains(c.StudentNoSrh))
    			&& (!c.InSchoolDateSrh.HasValue || (o.InSchoolDate.HasValue 			&& o.InSchoolDate.Value.Equals(c.InSchoolDateSrh.Value)))
    			&& (!c.InSchoolDateFromSrh.HasValue || (o.InSchoolDate.HasValue 			&& o.InSchoolDate.Value >= c.InSchoolDateFromSrh.Value))
    			&& (!c.InSchoolDateToSrh.HasValue || (o.InSchoolDate.HasValue 			&& o.InSchoolDate.Value <= c.InSchoolDateToSrh.Value))
    			&& (String.IsNullOrEmpty(c.IsDormSrh) || o.IsDorm.Contains(c.IsDormSrh))
    			&& (String.IsNullOrEmpty(c.DormNoSrh) || o.DormNo.Contains(c.DormNoSrh))
    			&& (String.IsNullOrEmpty(c.GiveCoursewareSrh) || o.GiveCourseware.Contains(c.GiveCoursewareSrh))
    			&& (String.IsNullOrEmpty(c.ConsultantsSrh) || o.Consultants.Contains(c.ConsultantsSrh))
    			&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
    			&& (!c.CreateTimeSrh.HasValue || o.CreateTime.Equals(c.CreateTimeSrh.Value))
    			&& (!c.LastUpdateTimeSrh.HasValue || o.LastUpdateTime.Equals(c.LastUpdateTimeSrh.Value))
    			&& (String.IsNullOrEmpty(c.IsGetQualificationSrh) || o.IsGetQualification.Contains(c.IsGetQualificationSrh))
    			&& (String.IsNullOrEmpty(c.StatusSrh) || o.Status.Contains(c.StatusSrh))
    			&& (String.IsNullOrEmpty(c.TechnicalWaySrh) || o.TechnicalWay.Contains(c.TechnicalWaySrh))
    			&& (String.IsNullOrEmpty(c.NeedObtainWorkSrh) || o.NeedObtainWork.Contains(c.NeedObtainWorkSrh))
    			&& (String.IsNullOrEmpty(c.IntentPositionSrh) || o.IntentPosition.Contains(c.IntentPositionSrh))
    			&& (!c.TargetSalarySrh.HasValue || (o.TargetSalary.HasValue 			&& o.TargetSalary.Value.Equals(c.TargetSalarySrh.Value)))
    			&& (!c.TargetSalaryFromSrh.HasValue || (o.TargetSalary.HasValue 			&& o.TargetSalary.Value >= c.TargetSalaryFromSrh.Value))
    			&& (!c.TargetSalaryToSrh.HasValue || (o.TargetSalary.HasValue 			&& o.TargetSalary.Value <= c.TargetSalaryToSrh.Value))
    			&& (!c.InsuranceStartDateSrh.HasValue || (o.InsuranceStartDate.HasValue 			&& o.InsuranceStartDate.Value.Equals(c.InsuranceStartDateSrh.Value)))
    			&& (!c.InsuranceStartDateFromSrh.HasValue || (o.InsuranceStartDate.HasValue 			&& o.InsuranceStartDate.Value >= c.InsuranceStartDateFromSrh.Value))
    			&& (!c.InsuranceStartDateToSrh.HasValue || (o.InsuranceStartDate.HasValue 			&& o.InsuranceStartDate.Value <= c.InsuranceStartDateToSrh.Value))
    			&& (!c.InsuranceEndDateSrh.HasValue || (o.InsuranceEndDate.HasValue 			&& o.InsuranceEndDate.Value.Equals(c.InsuranceEndDateSrh.Value)))
    			&& (!c.InsuranceEndDateFromSrh.HasValue || (o.InsuranceEndDate.HasValue 			&& o.InsuranceEndDate.Value >= c.InsuranceEndDateFromSrh.Value))
    			&& (!c.InsuranceEndDateToSrh.HasValue || (o.InsuranceEndDate.HasValue 			&& o.InsuranceEndDate.Value <= c.InsuranceEndDateToSrh.Value))
    			&& (String.IsNullOrEmpty(c.GaoKaoBatchSrh) || o.GaoKaoBatch.Contains(c.GaoKaoBatchSrh))
    			&& (String.IsNullOrEmpty(c.GiveNotebookSrh) || o.GiveNotebook.Contains(c.GiveNotebookSrh))
    			&& (!c.MaxSalarySrh.HasValue || (o.MaxSalary.HasValue 			&& o.MaxSalary.Value.Equals(c.MaxSalarySrh.Value)))
    			&& (!c.MaxSalaryFromSrh.HasValue || (o.MaxSalary.HasValue 			&& o.MaxSalary.Value >= c.MaxSalaryFromSrh.Value))
    			&& (!c.MaxSalaryToSrh.HasValue || (o.MaxSalary.HasValue 			&& o.MaxSalary.Value <= c.MaxSalaryToSrh.Value))
    			&& (!c.CurrentSalarySrh.HasValue || (o.CurrentSalary.HasValue 			&& o.CurrentSalary.Value.Equals(c.CurrentSalarySrh.Value)))
    			&& (!c.CurrentSalaryFromSrh.HasValue || (o.CurrentSalary.HasValue 			&& o.CurrentSalary.Value >= c.CurrentSalaryFromSrh.Value))
    			&& (!c.CurrentSalaryToSrh.HasValue || (o.CurrentSalary.HasValue 			&& o.CurrentSalary.Value <= c.CurrentSalaryToSrh.Value))
    			&& (!c.FirstSalarySrh.HasValue || (o.FirstSalary.HasValue 			&& o.FirstSalary.Value.Equals(c.FirstSalarySrh.Value)))
    			&& (!c.FirstSalaryFromSrh.HasValue || (o.FirstSalary.HasValue 			&& o.FirstSalary.Value >= c.FirstSalaryFromSrh.Value))
    			&& (!c.FirstSalaryToSrh.HasValue || (o.FirstSalary.HasValue 			&& o.FirstSalary.Value <= c.FirstSalaryToSrh.Value))
    			&& (!c.BeginSchoolTimeSrh.HasValue || (o.BeginSchoolTime.HasValue 			&& o.BeginSchoolTime.Value.Equals(c.BeginSchoolTimeSrh.Value)))
    			&& (!c.BeginSchoolTimeFromSrh.HasValue || (o.BeginSchoolTime.HasValue 			&& o.BeginSchoolTime.Value >= c.BeginSchoolTimeFromSrh.Value))
    			&& (!c.BeginSchoolTimeToSrh.HasValue || (o.BeginSchoolTime.HasValue 			&& o.BeginSchoolTime.Value <= c.BeginSchoolTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.MasterName1Srh) || o.MasterName1.Contains(c.MasterName1Srh))
    			&& (String.IsNullOrEmpty(c.MasterName2Srh) || o.MasterName2.Contains(c.MasterName2Srh))
    			&& (String.IsNullOrEmpty(c.MasterName3Srh) || o.MasterName3.Contains(c.MasterName3Srh))
    			&& (String.IsNullOrEmpty(c.TeacherName1Srh) || o.TeacherName1.Contains(c.TeacherName1Srh))
    			&& (String.IsNullOrEmpty(c.TeacherName2Srh) || o.TeacherName2.Contains(c.TeacherName2Srh))
    			&& (String.IsNullOrEmpty(c.TeacherName3Srh) || o.TeacherName3.Contains(c.TeacherName3Srh))
    			&& (!c.MasterId1Srh.HasValue || (o.MasterId1.HasValue 			&& o.MasterId1.Value.Equals(c.MasterId1Srh.Value)))
    			&& (!c.MasterId1FromSrh.HasValue || (o.MasterId1.HasValue 			&& o.MasterId1.Value >= c.MasterId1FromSrh.Value))
    			&& (!c.MasterId1ToSrh.HasValue || (o.MasterId1.HasValue 			&& o.MasterId1.Value <= c.MasterId1ToSrh.Value))
    			&& (!c.MasterId2Srh.HasValue || (o.MasterId2.HasValue 			&& o.MasterId2.Value.Equals(c.MasterId2Srh.Value)))
    			&& (!c.MasterId2FromSrh.HasValue || (o.MasterId2.HasValue 			&& o.MasterId2.Value >= c.MasterId2FromSrh.Value))
    			&& (!c.MasterId2ToSrh.HasValue || (o.MasterId2.HasValue 			&& o.MasterId2.Value <= c.MasterId2ToSrh.Value))
    			&& (!c.MasterId3Srh.HasValue || (o.MasterId3.HasValue 			&& o.MasterId3.Value.Equals(c.MasterId3Srh.Value)))
    			&& (!c.MasterId3FromSrh.HasValue || (o.MasterId3.HasValue 			&& o.MasterId3.Value >= c.MasterId3FromSrh.Value))
    			&& (!c.MasterId3ToSrh.HasValue || (o.MasterId3.HasValue 			&& o.MasterId3.Value <= c.MasterId3ToSrh.Value))
    			&& (!c.TeacherId1Srh.HasValue || (o.TeacherId1.HasValue 			&& o.TeacherId1.Value.Equals(c.TeacherId1Srh.Value)))
    			&& (!c.TeacherId1FromSrh.HasValue || (o.TeacherId1.HasValue 			&& o.TeacherId1.Value >= c.TeacherId1FromSrh.Value))
    			&& (!c.TeacherId1ToSrh.HasValue || (o.TeacherId1.HasValue 			&& o.TeacherId1.Value <= c.TeacherId1ToSrh.Value))
    			&& (!c.TeacherId2Srh.HasValue || (o.TeacherId2.HasValue 			&& o.TeacherId2.Value.Equals(c.TeacherId2Srh.Value)))
    			&& (!c.TeacherId2FromSrh.HasValue || (o.TeacherId2.HasValue 			&& o.TeacherId2.Value >= c.TeacherId2FromSrh.Value))
    			&& (!c.TeacherId2ToSrh.HasValue || (o.TeacherId2.HasValue 			&& o.TeacherId2.Value <= c.TeacherId2ToSrh.Value))
    			&& (!c.TeacherId3Srh.HasValue || (o.TeacherId3.HasValue 			&& o.TeacherId3.Value.Equals(c.TeacherId3Srh.Value)))
    			&& (!c.TeacherId3FromSrh.HasValue || (o.TeacherId3.HasValue 			&& o.TeacherId3.Value >= c.TeacherId3FromSrh.Value))
    			&& (!c.TeacherId3ToSrh.HasValue || (o.TeacherId3.HasValue 			&& o.TeacherId3.Value <= c.TeacherId3ToSrh.Value))
    			&& (String.IsNullOrEmpty(c.QualificationSchoolSrh) || o.QualificationSchool.Contains(c.QualificationSchoolSrh))
    			&& (String.IsNullOrEmpty(c.InsuranceStatusSrh) || o.InsuranceStatus.Contains(c.InsuranceStatusSrh))
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
    
    		);
    	}
    
    }
}
