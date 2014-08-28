using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class QualificationStudentRepository : IQualificationStudentRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public QualificationStudentRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(QualificationStudent entity) {
    		this.DbContext.QualificationStudents.AddObject(entity);
    	}
    
    	public void Update(QualificationStudent entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Clazz = entity.Clazz;
    			e.TargetSchoolName = entity.TargetSchoolName;
    			e.SignUpTime = entity.SignUpTime;
    			e.SeqNo = entity.SeqNo;
    			e.TargetProfession = entity.TargetProfession;
    			e.TargetLevel = entity.TargetLevel;
    			e.StudentNo = entity.StudentNo;
    			e.Name = entity.Name;
    			e.Sex = entity.Sex;
    			e.Birthday = entity.Birthday;
    			e.JiGuang = entity.JiGuang;
    			e.IdCardNo = entity.IdCardNo;
    			e.MinZu = entity.MinZu;
    			e.ZhengZhiMianMao = entity.ZhengZhiMianMao;
    			e.IsMarried = entity.IsMarried;
    			e.HomeAddress = entity.HomeAddress;
    			e.HuKouAddress = entity.HuKouAddress;
    			e.CommAddress = entity.CommAddress;
    			e.Postcode = entity.Postcode;
    			e.HomeTelephone = entity.HomeTelephone;
    			e.Mobile = entity.Mobile;
    			e.QQ = entity.QQ;
    			e.Company = entity.Company;
    			e.Title = entity.Title;
    			e.CompanyTelephoneNo = entity.CompanyTelephoneNo;
    			e.BeginWorkTime = entity.BeginWorkTime;
    			e.WorkedYears = entity.WorkedYears;
    			e.HighestEduLevel = entity.HighestEduLevel;
    			e.HighestQualification = entity.HighestQualification;
    			e.GraduateDate = entity.GraduateDate;
    			e.GruduateSchool = entity.GruduateSchool;
    			e.HighestQualificationNo = entity.HighestQualificationNo;
    			e.StudyDuration1 = entity.StudyDuration1;
    			e.StudySchool1 = entity.StudySchool1;
    			e.StudyPosition1 = entity.StudyPosition1;
    			e.StudyDuration2 = entity.StudyDuration2;
    			e.StudySchool2 = entity.StudySchool2;
    			e.StudyPosition2 = entity.StudyPosition2;
    			e.StudyDuration3 = entity.StudyDuration3;
    			e.StudySchool3 = entity.StudySchool3;
    			e.StudyPosition3 = entity.StudyPosition3;
    			e.MemberRelType1 = entity.MemberRelType1;
    			e.MemberName1 = entity.MemberName1;
    			e.MemberMianMao1 = entity.MemberMianMao1;
    			e.MemberCompany1 = entity.MemberCompany1;
    			e.MemberPosition1 = entity.MemberPosition1;
    			e.MemberMobile1 = entity.MemberMobile1;
    			e.MemberRelType2 = entity.MemberRelType2;
    			e.MemberName2 = entity.MemberName2;
    			e.MemberMianMao2 = entity.MemberMianMao2;
    			e.MemberCompany2 = entity.MemberCompany2;
    			e.MemberPosition2 = entity.MemberPosition2;
    			e.MemberMobile2 = entity.MemberMobile2;
    			e.Remark = entity.Remark;
    			e.Status = entity.Status;
    			e.Consultant = entity.Consultant;
    			e.Referrer = entity.Referrer;
    			e.ReferrerMobile = entity.ReferrerMobile;
    			e.ReferrerQQ = entity.ReferrerQQ;
    			e.MatriculateTime = entity.MatriculateTime;
    			e.NetUserName = entity.NetUserName;
    			e.NetPassword = entity.NetPassword;
    			e.StudyType = entity.StudyType;
    			e.SubmitStatus = entity.SubmitStatus;
    			e.OfferStatus = entity.OfferStatus;
    			e.PayStatus = entity.PayStatus;
    			e.PaperStatus = entity.PaperStatus;
    			e.OldOAId = entity.OldOAId;
    			e.Photo1 = entity.Photo1;
    			e.Photo2 = entity.Photo2;
    			e.Photo3 = entity.Photo3;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.QualificationStudents.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(QualificationStudent entity) {
    		this.DbContext.QualificationStudents.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.QualificationStudents.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<QualificationStudent> FindAll() {
    		return this.DbContext.QualificationStudents;
    	}
    	public IEnumerable<QualificationStudent> FindAll2() {
    		return this.DbContext.QualificationStudents;
    	}
    
    	public QualificationStudent FindById(int id) {
    		return this.DbContext.QualificationStudents.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<QualificationStudent> FindByClazz(string clazz){
    				return this.DbContext.QualificationStudents.Where(o => o.Clazz.Equals(clazz));
    			}
    	public IEnumerable<QualificationStudent> FindByTargetSchoolName(string targetSchoolName){
    				return this.DbContext.QualificationStudents.Where(o => o.TargetSchoolName.Equals(targetSchoolName));
    			}
    	public IEnumerable<QualificationStudent> FindBySignUpTime(Nullable<System.DateTime> signUpTime){
    				return this.DbContext.QualificationStudents.Where(o => o.SignUpTime.Value.Equals(signUpTime.Value));
    			}
    	public IEnumerable<QualificationStudent> FindBySeqNo(string seqNo){
    				return this.DbContext.QualificationStudents.Where(o => o.SeqNo.Equals(seqNo));
    			}
    	public IEnumerable<QualificationStudent> FindByTargetProfession(string targetProfession){
    				return this.DbContext.QualificationStudents.Where(o => o.TargetProfession.Equals(targetProfession));
    			}
    	public IEnumerable<QualificationStudent> FindByTargetLevel(string targetLevel){
    				return this.DbContext.QualificationStudents.Where(o => o.TargetLevel.Equals(targetLevel));
    			}
    	public IEnumerable<QualificationStudent> FindByStudentNo(string studentNo){
    				return this.DbContext.QualificationStudents.Where(o => o.StudentNo.Equals(studentNo));
    			}
    	public IEnumerable<QualificationStudent> FindByName(string name){
    				return this.DbContext.QualificationStudents.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<QualificationStudent> FindBySex(string sex){
    				return this.DbContext.QualificationStudents.Where(o => o.Sex.Equals(sex));
    			}
    	public IEnumerable<QualificationStudent> FindByBirthday(Nullable<System.DateTime> birthday){
    				return this.DbContext.QualificationStudents.Where(o => o.Birthday.Value.Equals(birthday.Value));
    			}
    	public IEnumerable<QualificationStudent> FindByJiGuang(string jiGuang){
    				return this.DbContext.QualificationStudents.Where(o => o.JiGuang.Equals(jiGuang));
    			}
    	public IEnumerable<QualificationStudent> FindByIdCardNo(string idCardNo){
    				return this.DbContext.QualificationStudents.Where(o => o.IdCardNo.Equals(idCardNo));
    			}
    	public IEnumerable<QualificationStudent> FindByMinZu(string minZu){
    				return this.DbContext.QualificationStudents.Where(o => o.MinZu.Equals(minZu));
    			}
    	public IEnumerable<QualificationStudent> FindByZhengZhiMianMao(string zhengZhiMianMao){
    				return this.DbContext.QualificationStudents.Where(o => o.ZhengZhiMianMao.Equals(zhengZhiMianMao));
    			}
    	public IEnumerable<QualificationStudent> FindByIsMarried(string isMarried){
    				return this.DbContext.QualificationStudents.Where(o => o.IsMarried.Equals(isMarried));
    			}
    	public IEnumerable<QualificationStudent> FindByHomeAddress(string homeAddress){
    				return this.DbContext.QualificationStudents.Where(o => o.HomeAddress.Equals(homeAddress));
    			}
    	public IEnumerable<QualificationStudent> FindByHuKouAddress(string huKouAddress){
    				return this.DbContext.QualificationStudents.Where(o => o.HuKouAddress.Equals(huKouAddress));
    			}
    	public IEnumerable<QualificationStudent> FindByCommAddress(string commAddress){
    				return this.DbContext.QualificationStudents.Where(o => o.CommAddress.Equals(commAddress));
    			}
    	public IEnumerable<QualificationStudent> FindByPostcode(string postcode){
    				return this.DbContext.QualificationStudents.Where(o => o.Postcode.Equals(postcode));
    			}
    	public IEnumerable<QualificationStudent> FindByHomeTelephone(string homeTelephone){
    				return this.DbContext.QualificationStudents.Where(o => o.HomeTelephone.Equals(homeTelephone));
    			}
    	public IEnumerable<QualificationStudent> FindByMobile(string mobile){
    				return this.DbContext.QualificationStudents.Where(o => o.Mobile.Equals(mobile));
    			}
    	public IEnumerable<QualificationStudent> FindByQQ(string qQ){
    				return this.DbContext.QualificationStudents.Where(o => o.QQ.Equals(qQ));
    			}
    	public IEnumerable<QualificationStudent> FindByCompany(string company){
    				return this.DbContext.QualificationStudents.Where(o => o.Company.Equals(company));
    			}
    	public IEnumerable<QualificationStudent> FindByTitle(string title){
    				return this.DbContext.QualificationStudents.Where(o => o.Title.Equals(title));
    			}
    	public IEnumerable<QualificationStudent> FindByCompanyTelephoneNo(string companyTelephoneNo){
    				return this.DbContext.QualificationStudents.Where(o => o.CompanyTelephoneNo.Equals(companyTelephoneNo));
    			}
    	public IEnumerable<QualificationStudent> FindByBeginWorkTime(Nullable<System.DateTime> beginWorkTime){
    				return this.DbContext.QualificationStudents.Where(o => o.BeginWorkTime.Value.Equals(beginWorkTime.Value));
    			}
    	public IEnumerable<QualificationStudent> FindByWorkedYears(Nullable<int> workedYears){
    				return this.DbContext.QualificationStudents.Where(o => o.WorkedYears.Value.Equals(workedYears.Value));
    			}
    	public IEnumerable<QualificationStudent> FindByHighestEduLevel(string highestEduLevel){
    				return this.DbContext.QualificationStudents.Where(o => o.HighestEduLevel.Equals(highestEduLevel));
    			}
    	public IEnumerable<QualificationStudent> FindByHighestQualification(string highestQualification){
    				return this.DbContext.QualificationStudents.Where(o => o.HighestQualification.Equals(highestQualification));
    			}
    	public IEnumerable<QualificationStudent> FindByGraduateDate(Nullable<System.DateTime> graduateDate){
    				return this.DbContext.QualificationStudents.Where(o => o.GraduateDate.Value.Equals(graduateDate.Value));
    			}
    	public IEnumerable<QualificationStudent> FindByGruduateSchool(string gruduateSchool){
    				return this.DbContext.QualificationStudents.Where(o => o.GruduateSchool.Equals(gruduateSchool));
    			}
    	public IEnumerable<QualificationStudent> FindByHighestQualificationNo(string highestQualificationNo){
    				return this.DbContext.QualificationStudents.Where(o => o.HighestQualificationNo.Equals(highestQualificationNo));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyDuration1(string studyDuration1){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyDuration1.Equals(studyDuration1));
    			}
    	public IEnumerable<QualificationStudent> FindByStudySchool1(string studySchool1){
    				return this.DbContext.QualificationStudents.Where(o => o.StudySchool1.Equals(studySchool1));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyPosition1(string studyPosition1){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyPosition1.Equals(studyPosition1));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyDuration2(string studyDuration2){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyDuration2.Equals(studyDuration2));
    			}
    	public IEnumerable<QualificationStudent> FindByStudySchool2(string studySchool2){
    				return this.DbContext.QualificationStudents.Where(o => o.StudySchool2.Equals(studySchool2));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyPosition2(string studyPosition2){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyPosition2.Equals(studyPosition2));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyDuration3(string studyDuration3){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyDuration3.Equals(studyDuration3));
    			}
    	public IEnumerable<QualificationStudent> FindByStudySchool3(string studySchool3){
    				return this.DbContext.QualificationStudents.Where(o => o.StudySchool3.Equals(studySchool3));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyPosition3(string studyPosition3){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyPosition3.Equals(studyPosition3));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberRelType1(string memberRelType1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberRelType1.Equals(memberRelType1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberName1(string memberName1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberName1.Equals(memberName1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberMianMao1(string memberMianMao1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberMianMao1.Equals(memberMianMao1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberCompany1(string memberCompany1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberCompany1.Equals(memberCompany1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberPosition1(string memberPosition1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberPosition1.Equals(memberPosition1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberMobile1(string memberMobile1){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberMobile1.Equals(memberMobile1));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberRelType2(string memberRelType2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberRelType2.Equals(memberRelType2));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberName2(string memberName2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberName2.Equals(memberName2));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberMianMao2(string memberMianMao2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberMianMao2.Equals(memberMianMao2));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberCompany2(string memberCompany2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberCompany2.Equals(memberCompany2));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberPosition2(string memberPosition2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberPosition2.Equals(memberPosition2));
    			}
    	public IEnumerable<QualificationStudent> FindByMemberMobile2(string memberMobile2){
    				return this.DbContext.QualificationStudents.Where(o => o.MemberMobile2.Equals(memberMobile2));
    			}
    	public IEnumerable<QualificationStudent> FindByRemark(string remark){
    				return this.DbContext.QualificationStudents.Where(o => o.Remark.Equals(remark));
    			}
    	public IEnumerable<QualificationStudent> FindByStatus(string status){
    				return this.DbContext.QualificationStudents.Where(o => o.Status.Equals(status));
    			}
    	public IEnumerable<QualificationStudent> FindByConsultant(string consultant){
    				return this.DbContext.QualificationStudents.Where(o => o.Consultant.Equals(consultant));
    			}
    	public IEnumerable<QualificationStudent> FindByReferrer(string referrer){
    				return this.DbContext.QualificationStudents.Where(o => o.Referrer.Equals(referrer));
    			}
    	public IEnumerable<QualificationStudent> FindByReferrerMobile(string referrerMobile){
    				return this.DbContext.QualificationStudents.Where(o => o.ReferrerMobile.Equals(referrerMobile));
    			}
    	public IEnumerable<QualificationStudent> FindByReferrerQQ(string referrerQQ){
    				return this.DbContext.QualificationStudents.Where(o => o.ReferrerQQ.Equals(referrerQQ));
    			}
    	public IEnumerable<QualificationStudent> FindByMatriculateTime(Nullable<System.DateTime> matriculateTime){
    				return this.DbContext.QualificationStudents.Where(o => o.MatriculateTime.Value.Equals(matriculateTime.Value));
    			}
    	public IEnumerable<QualificationStudent> FindByNetUserName(string netUserName){
    				return this.DbContext.QualificationStudents.Where(o => o.NetUserName.Equals(netUserName));
    			}
    	public IEnumerable<QualificationStudent> FindByNetPassword(string netPassword){
    				return this.DbContext.QualificationStudents.Where(o => o.NetPassword.Equals(netPassword));
    			}
    	public IEnumerable<QualificationStudent> FindByStudyType(string studyType){
    				return this.DbContext.QualificationStudents.Where(o => o.StudyType.Equals(studyType));
    			}
    	public IEnumerable<QualificationStudent> FindBySubmitStatus(string submitStatus){
    				return this.DbContext.QualificationStudents.Where(o => o.SubmitStatus.Equals(submitStatus));
    			}
    	public IEnumerable<QualificationStudent> FindByOfferStatus(string offerStatus){
    				return this.DbContext.QualificationStudents.Where(o => o.OfferStatus.Equals(offerStatus));
    			}
    	public IEnumerable<QualificationStudent> FindByPayStatus(string payStatus){
    				return this.DbContext.QualificationStudents.Where(o => o.PayStatus.Equals(payStatus));
    			}
    	public IEnumerable<QualificationStudent> FindByPaperStatus(string paperStatus){
    				return this.DbContext.QualificationStudents.Where(o => o.PaperStatus.Equals(paperStatus));
    			}
    	public IEnumerable<QualificationStudent> FindByOldOAId(string oldOAId){
    				return this.DbContext.QualificationStudents.Where(o => o.OldOAId.Equals(oldOAId));
    			}
    	public IEnumerable<QualificationStudent> FindByPhoto1(string photo1){
    				return this.DbContext.QualificationStudents.Where(o => o.Photo1.Equals(photo1));
    			}
    	public IEnumerable<QualificationStudent> FindByPhoto2(string photo2){
    				return this.DbContext.QualificationStudents.Where(o => o.Photo2.Equals(photo2));
    			}
    	public IEnumerable<QualificationStudent> FindByPhoto3(string photo3){
    				return this.DbContext.QualificationStudents.Where(o => o.Photo3.Equals(photo3));
    			}
    	public IEnumerable<QualificationStudent> FindByCriteria(QualificationStudentCriteria c) {
    		return this.DbContext.QualificationStudents.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.ClazzSrh) || o.Clazz.Contains(c.ClazzSrh))
    			&& (String.IsNullOrEmpty(c.TargetSchoolNameSrh) || o.TargetSchoolName.Contains(c.TargetSchoolNameSrh))
    			&& (!c.SignUpTimeSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value.Equals(c.SignUpTimeSrh.Value)))
    			&& (!c.SignUpTimeFromSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value >= c.SignUpTimeFromSrh.Value))
    			&& (!c.SignUpTimeToSrh.HasValue || (o.SignUpTime.HasValue 			&& o.SignUpTime.Value <= c.SignUpTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.SeqNoSrh) || o.SeqNo.Contains(c.SeqNoSrh))
    			&& (String.IsNullOrEmpty(c.TargetProfessionSrh) || o.TargetProfession.Contains(c.TargetProfessionSrh))
    			&& (String.IsNullOrEmpty(c.TargetLevelSrh) || o.TargetLevel.Contains(c.TargetLevelSrh))
    			&& (String.IsNullOrEmpty(c.StudentNoSrh) || o.StudentNo.Contains(c.StudentNoSrh))
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.SexSrh) || o.Sex.Contains(c.SexSrh))
    			&& (!c.BirthdaySrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value.Equals(c.BirthdaySrh.Value)))
    			&& (!c.BirthdayFromSrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value >= c.BirthdayFromSrh.Value))
    			&& (!c.BirthdayToSrh.HasValue || (o.Birthday.HasValue 			&& o.Birthday.Value <= c.BirthdayToSrh.Value))
    			&& (String.IsNullOrEmpty(c.JiGuangSrh) || o.JiGuang.Contains(c.JiGuangSrh))
    			&& (String.IsNullOrEmpty(c.IdCardNoSrh) || o.IdCardNo.Contains(c.IdCardNoSrh))
    			&& (String.IsNullOrEmpty(c.MinZuSrh) || o.MinZu.Contains(c.MinZuSrh))
    			&& (String.IsNullOrEmpty(c.ZhengZhiMianMaoSrh) || o.ZhengZhiMianMao.Contains(c.ZhengZhiMianMaoSrh))
    			&& (String.IsNullOrEmpty(c.IsMarriedSrh) || o.IsMarried.Contains(c.IsMarriedSrh))
    			&& (String.IsNullOrEmpty(c.HomeAddressSrh) || o.HomeAddress.Contains(c.HomeAddressSrh))
    			&& (String.IsNullOrEmpty(c.HuKouAddressSrh) || o.HuKouAddress.Contains(c.HuKouAddressSrh))
    			&& (String.IsNullOrEmpty(c.CommAddressSrh) || o.CommAddress.Contains(c.CommAddressSrh))
    			&& (String.IsNullOrEmpty(c.PostcodeSrh) || o.Postcode.Contains(c.PostcodeSrh))
    			&& (String.IsNullOrEmpty(c.HomeTelephoneSrh) || o.HomeTelephone.Contains(c.HomeTelephoneSrh))
    			&& (String.IsNullOrEmpty(c.MobileSrh) || o.Mobile.Contains(c.MobileSrh))
    			&& (String.IsNullOrEmpty(c.QQSrh) || o.QQ.Contains(c.QQSrh))
    			&& (String.IsNullOrEmpty(c.CompanySrh) || o.Company.Contains(c.CompanySrh))
    			&& (String.IsNullOrEmpty(c.TitleSrh) || o.Title.Contains(c.TitleSrh))
    			&& (String.IsNullOrEmpty(c.CompanyTelephoneNoSrh) || o.CompanyTelephoneNo.Contains(c.CompanyTelephoneNoSrh))
    			&& (!c.BeginWorkTimeSrh.HasValue || (o.BeginWorkTime.HasValue 			&& o.BeginWorkTime.Value.Equals(c.BeginWorkTimeSrh.Value)))
    			&& (!c.BeginWorkTimeFromSrh.HasValue || (o.BeginWorkTime.HasValue 			&& o.BeginWorkTime.Value >= c.BeginWorkTimeFromSrh.Value))
    			&& (!c.BeginWorkTimeToSrh.HasValue || (o.BeginWorkTime.HasValue 			&& o.BeginWorkTime.Value <= c.BeginWorkTimeToSrh.Value))
    			&& (!c.WorkedYearsSrh.HasValue || (o.WorkedYears.HasValue 			&& o.WorkedYears.Value.Equals(c.WorkedYearsSrh.Value)))
    			&& (!c.WorkedYearsFromSrh.HasValue || (o.WorkedYears.HasValue 			&& o.WorkedYears.Value >= c.WorkedYearsFromSrh.Value))
    			&& (!c.WorkedYearsToSrh.HasValue || (o.WorkedYears.HasValue 			&& o.WorkedYears.Value <= c.WorkedYearsToSrh.Value))
    			&& (String.IsNullOrEmpty(c.HighestEduLevelSrh) || o.HighestEduLevel.Contains(c.HighestEduLevelSrh))
    			&& (String.IsNullOrEmpty(c.HighestQualificationSrh) || o.HighestQualification.Contains(c.HighestQualificationSrh))
    			&& (!c.GraduateDateSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value.Equals(c.GraduateDateSrh.Value)))
    			&& (!c.GraduateDateFromSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value >= c.GraduateDateFromSrh.Value))
    			&& (!c.GraduateDateToSrh.HasValue || (o.GraduateDate.HasValue 			&& o.GraduateDate.Value <= c.GraduateDateToSrh.Value))
    			&& (String.IsNullOrEmpty(c.GruduateSchoolSrh) || o.GruduateSchool.Contains(c.GruduateSchoolSrh))
    			&& (String.IsNullOrEmpty(c.HighestQualificationNoSrh) || o.HighestQualificationNo.Contains(c.HighestQualificationNoSrh))
    			&& (String.IsNullOrEmpty(c.StudyDuration1Srh) || o.StudyDuration1.Contains(c.StudyDuration1Srh))
    			&& (String.IsNullOrEmpty(c.StudySchool1Srh) || o.StudySchool1.Contains(c.StudySchool1Srh))
    			&& (String.IsNullOrEmpty(c.StudyPosition1Srh) || o.StudyPosition1.Contains(c.StudyPosition1Srh))
    			&& (String.IsNullOrEmpty(c.StudyDuration2Srh) || o.StudyDuration2.Contains(c.StudyDuration2Srh))
    			&& (String.IsNullOrEmpty(c.StudySchool2Srh) || o.StudySchool2.Contains(c.StudySchool2Srh))
    			&& (String.IsNullOrEmpty(c.StudyPosition2Srh) || o.StudyPosition2.Contains(c.StudyPosition2Srh))
    			&& (String.IsNullOrEmpty(c.StudyDuration3Srh) || o.StudyDuration3.Contains(c.StudyDuration3Srh))
    			&& (String.IsNullOrEmpty(c.StudySchool3Srh) || o.StudySchool3.Contains(c.StudySchool3Srh))
    			&& (String.IsNullOrEmpty(c.StudyPosition3Srh) || o.StudyPosition3.Contains(c.StudyPosition3Srh))
    			&& (String.IsNullOrEmpty(c.MemberRelType1Srh) || o.MemberRelType1.Contains(c.MemberRelType1Srh))
    			&& (String.IsNullOrEmpty(c.MemberName1Srh) || o.MemberName1.Contains(c.MemberName1Srh))
    			&& (String.IsNullOrEmpty(c.MemberMianMao1Srh) || o.MemberMianMao1.Contains(c.MemberMianMao1Srh))
    			&& (String.IsNullOrEmpty(c.MemberCompany1Srh) || o.MemberCompany1.Contains(c.MemberCompany1Srh))
    			&& (String.IsNullOrEmpty(c.MemberPosition1Srh) || o.MemberPosition1.Contains(c.MemberPosition1Srh))
    			&& (String.IsNullOrEmpty(c.MemberMobile1Srh) || o.MemberMobile1.Contains(c.MemberMobile1Srh))
    			&& (String.IsNullOrEmpty(c.MemberRelType2Srh) || o.MemberRelType2.Contains(c.MemberRelType2Srh))
    			&& (String.IsNullOrEmpty(c.MemberName2Srh) || o.MemberName2.Contains(c.MemberName2Srh))
    			&& (String.IsNullOrEmpty(c.MemberMianMao2Srh) || o.MemberMianMao2.Contains(c.MemberMianMao2Srh))
    			&& (String.IsNullOrEmpty(c.MemberCompany2Srh) || o.MemberCompany2.Contains(c.MemberCompany2Srh))
    			&& (String.IsNullOrEmpty(c.MemberPosition2Srh) || o.MemberPosition2.Contains(c.MemberPosition2Srh))
    			&& (String.IsNullOrEmpty(c.MemberMobile2Srh) || o.MemberMobile2.Contains(c.MemberMobile2Srh))
    			&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
    			&& (String.IsNullOrEmpty(c.StatusSrh) || o.Status.Contains(c.StatusSrh))
    			&& (String.IsNullOrEmpty(c.ConsultantSrh) || o.Consultant.Contains(c.ConsultantSrh))
    			&& (String.IsNullOrEmpty(c.ReferrerSrh) || o.Referrer.Contains(c.ReferrerSrh))
    			&& (String.IsNullOrEmpty(c.ReferrerMobileSrh) || o.ReferrerMobile.Contains(c.ReferrerMobileSrh))
    			&& (String.IsNullOrEmpty(c.ReferrerQQSrh) || o.ReferrerQQ.Contains(c.ReferrerQQSrh))
    			&& (!c.MatriculateTimeSrh.HasValue || (o.MatriculateTime.HasValue 			&& o.MatriculateTime.Value.Equals(c.MatriculateTimeSrh.Value)))
    			&& (!c.MatriculateTimeFromSrh.HasValue || (o.MatriculateTime.HasValue 			&& o.MatriculateTime.Value >= c.MatriculateTimeFromSrh.Value))
    			&& (!c.MatriculateTimeToSrh.HasValue || (o.MatriculateTime.HasValue 			&& o.MatriculateTime.Value <= c.MatriculateTimeToSrh.Value))
    			&& (String.IsNullOrEmpty(c.NetUserNameSrh) || o.NetUserName.Contains(c.NetUserNameSrh))
    			&& (String.IsNullOrEmpty(c.NetPasswordSrh) || o.NetPassword.Contains(c.NetPasswordSrh))
    			&& (String.IsNullOrEmpty(c.StudyTypeSrh) || o.StudyType.Contains(c.StudyTypeSrh))
    			&& (String.IsNullOrEmpty(c.SubmitStatusSrh) || o.SubmitStatus.Contains(c.SubmitStatusSrh))
    			&& (String.IsNullOrEmpty(c.OfferStatusSrh) || o.OfferStatus.Contains(c.OfferStatusSrh))
    			&& (String.IsNullOrEmpty(c.PayStatusSrh) || o.PayStatus.Contains(c.PayStatusSrh))
    			&& (String.IsNullOrEmpty(c.PaperStatusSrh) || o.PaperStatus.Contains(c.PaperStatusSrh))
    			&& (String.IsNullOrEmpty(c.OldOAIdSrh) || o.OldOAId.Contains(c.OldOAIdSrh))
    			&& (String.IsNullOrEmpty(c.Photo1Srh) || o.Photo1.Contains(c.Photo1Srh))
    			&& (String.IsNullOrEmpty(c.Photo2Srh) || o.Photo2.Contains(c.Photo2Srh))
    			&& (String.IsNullOrEmpty(c.Photo3Srh) || o.Photo3.Contains(c.Photo3Srh))
    
    		);
    	}
    
    }
}
