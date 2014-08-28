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
    public partial class QualificationStudentService : IQualificationStudentService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IQualificationStudentRepository Repository { get; private set; }
    	public QualificationStudentService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new QualificationStudentRepository(this.Db);
    	}
    	public QualificationStudentService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new QualificationStudentRepository(this.Db);
    	}
    	
    	
    	public void Add(QualificationStudent entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(QualificationStudent entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(QualificationStudent entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(QualificationStudent entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<QualificationStudent> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public QualificationStudent FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<QualificationStudent> FindByClazz(string clazz){
    		return this.Repository.FindByClazz(clazz).ToList();
    	}
    	public List<QualificationStudent> FindByTargetSchoolName(string targetSchoolName){
    		return this.Repository.FindByTargetSchoolName(targetSchoolName).ToList();
    	}
    	public List<QualificationStudent> FindBySignUpTime(Nullable<System.DateTime> signUpTime){
    		return this.Repository.FindBySignUpTime(signUpTime).ToList();
    	}
    	public List<QualificationStudent> FindBySeqNo(string seqNo){
    		return this.Repository.FindBySeqNo(seqNo).ToList();
    	}
    	public List<QualificationStudent> FindByTargetProfession(string targetProfession){
    		return this.Repository.FindByTargetProfession(targetProfession).ToList();
    	}
    	public List<QualificationStudent> FindByTargetLevel(string targetLevel){
    		return this.Repository.FindByTargetLevel(targetLevel).ToList();
    	}
    	public List<QualificationStudent> FindByStudentNo(string studentNo){
    		return this.Repository.FindByStudentNo(studentNo).ToList();
    	}
    	public List<QualificationStudent> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<QualificationStudent> FindBySex(string sex){
    		return this.Repository.FindBySex(sex).ToList();
    	}
    	public List<QualificationStudent> FindByBirthday(Nullable<System.DateTime> birthday){
    		return this.Repository.FindByBirthday(birthday).ToList();
    	}
    	public List<QualificationStudent> FindByJiGuang(string jiGuang){
    		return this.Repository.FindByJiGuang(jiGuang).ToList();
    	}
    	public List<QualificationStudent> FindByIdCardNo(string idCardNo){
    		return this.Repository.FindByIdCardNo(idCardNo).ToList();
    	}
    	public List<QualificationStudent> FindByMinZu(string minZu){
    		return this.Repository.FindByMinZu(minZu).ToList();
    	}
    	public List<QualificationStudent> FindByZhengZhiMianMao(string zhengZhiMianMao){
    		return this.Repository.FindByZhengZhiMianMao(zhengZhiMianMao).ToList();
    	}
    	public List<QualificationStudent> FindByIsMarried(string isMarried){
    		return this.Repository.FindByIsMarried(isMarried).ToList();
    	}
    	public List<QualificationStudent> FindByHomeAddress(string homeAddress){
    		return this.Repository.FindByHomeAddress(homeAddress).ToList();
    	}
    	public List<QualificationStudent> FindByHuKouAddress(string huKouAddress){
    		return this.Repository.FindByHuKouAddress(huKouAddress).ToList();
    	}
    	public List<QualificationStudent> FindByCommAddress(string commAddress){
    		return this.Repository.FindByCommAddress(commAddress).ToList();
    	}
    	public List<QualificationStudent> FindByPostcode(string postcode){
    		return this.Repository.FindByPostcode(postcode).ToList();
    	}
    	public List<QualificationStudent> FindByHomeTelephone(string homeTelephone){
    		return this.Repository.FindByHomeTelephone(homeTelephone).ToList();
    	}
    	public List<QualificationStudent> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<QualificationStudent> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<QualificationStudent> FindByCompany(string company){
    		return this.Repository.FindByCompany(company).ToList();
    	}
    	public List<QualificationStudent> FindByTitle(string title){
    		return this.Repository.FindByTitle(title).ToList();
    	}
    	public List<QualificationStudent> FindByCompanyTelephoneNo(string companyTelephoneNo){
    		return this.Repository.FindByCompanyTelephoneNo(companyTelephoneNo).ToList();
    	}
    	public List<QualificationStudent> FindByBeginWorkTime(Nullable<System.DateTime> beginWorkTime){
    		return this.Repository.FindByBeginWorkTime(beginWorkTime).ToList();
    	}
    	public List<QualificationStudent> FindByWorkedYears(Nullable<int> workedYears){
    		return this.Repository.FindByWorkedYears(workedYears).ToList();
    	}
    	public List<QualificationStudent> FindByHighestEduLevel(string highestEduLevel){
    		return this.Repository.FindByHighestEduLevel(highestEduLevel).ToList();
    	}
    	public List<QualificationStudent> FindByHighestQualification(string highestQualification){
    		return this.Repository.FindByHighestQualification(highestQualification).ToList();
    	}
    	public List<QualificationStudent> FindByGraduateDate(Nullable<System.DateTime> graduateDate){
    		return this.Repository.FindByGraduateDate(graduateDate).ToList();
    	}
    	public List<QualificationStudent> FindByGruduateSchool(string gruduateSchool){
    		return this.Repository.FindByGruduateSchool(gruduateSchool).ToList();
    	}
    	public List<QualificationStudent> FindByHighestQualificationNo(string highestQualificationNo){
    		return this.Repository.FindByHighestQualificationNo(highestQualificationNo).ToList();
    	}
    	public List<QualificationStudent> FindByStudyDuration1(string studyDuration1){
    		return this.Repository.FindByStudyDuration1(studyDuration1).ToList();
    	}
    	public List<QualificationStudent> FindByStudySchool1(string studySchool1){
    		return this.Repository.FindByStudySchool1(studySchool1).ToList();
    	}
    	public List<QualificationStudent> FindByStudyPosition1(string studyPosition1){
    		return this.Repository.FindByStudyPosition1(studyPosition1).ToList();
    	}
    	public List<QualificationStudent> FindByStudyDuration2(string studyDuration2){
    		return this.Repository.FindByStudyDuration2(studyDuration2).ToList();
    	}
    	public List<QualificationStudent> FindByStudySchool2(string studySchool2){
    		return this.Repository.FindByStudySchool2(studySchool2).ToList();
    	}
    	public List<QualificationStudent> FindByStudyPosition2(string studyPosition2){
    		return this.Repository.FindByStudyPosition2(studyPosition2).ToList();
    	}
    	public List<QualificationStudent> FindByStudyDuration3(string studyDuration3){
    		return this.Repository.FindByStudyDuration3(studyDuration3).ToList();
    	}
    	public List<QualificationStudent> FindByStudySchool3(string studySchool3){
    		return this.Repository.FindByStudySchool3(studySchool3).ToList();
    	}
    	public List<QualificationStudent> FindByStudyPosition3(string studyPosition3){
    		return this.Repository.FindByStudyPosition3(studyPosition3).ToList();
    	}
    	public List<QualificationStudent> FindByMemberRelType1(string memberRelType1){
    		return this.Repository.FindByMemberRelType1(memberRelType1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberName1(string memberName1){
    		return this.Repository.FindByMemberName1(memberName1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberMianMao1(string memberMianMao1){
    		return this.Repository.FindByMemberMianMao1(memberMianMao1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberCompany1(string memberCompany1){
    		return this.Repository.FindByMemberCompany1(memberCompany1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberPosition1(string memberPosition1){
    		return this.Repository.FindByMemberPosition1(memberPosition1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberMobile1(string memberMobile1){
    		return this.Repository.FindByMemberMobile1(memberMobile1).ToList();
    	}
    	public List<QualificationStudent> FindByMemberRelType2(string memberRelType2){
    		return this.Repository.FindByMemberRelType2(memberRelType2).ToList();
    	}
    	public List<QualificationStudent> FindByMemberName2(string memberName2){
    		return this.Repository.FindByMemberName2(memberName2).ToList();
    	}
    	public List<QualificationStudent> FindByMemberMianMao2(string memberMianMao2){
    		return this.Repository.FindByMemberMianMao2(memberMianMao2).ToList();
    	}
    	public List<QualificationStudent> FindByMemberCompany2(string memberCompany2){
    		return this.Repository.FindByMemberCompany2(memberCompany2).ToList();
    	}
    	public List<QualificationStudent> FindByMemberPosition2(string memberPosition2){
    		return this.Repository.FindByMemberPosition2(memberPosition2).ToList();
    	}
    	public List<QualificationStudent> FindByMemberMobile2(string memberMobile2){
    		return this.Repository.FindByMemberMobile2(memberMobile2).ToList();
    	}
    	public List<QualificationStudent> FindByRemark(string remark){
    		return this.Repository.FindByRemark(remark).ToList();
    	}
    	public List<QualificationStudent> FindByStatus(string status){
    		return this.Repository.FindByStatus(status).ToList();
    	}
    	public List<QualificationStudent> FindByConsultant(string consultant){
    		return this.Repository.FindByConsultant(consultant).ToList();
    	}
    	public List<QualificationStudent> FindByReferrer(string referrer){
    		return this.Repository.FindByReferrer(referrer).ToList();
    	}
    	public List<QualificationStudent> FindByReferrerMobile(string referrerMobile){
    		return this.Repository.FindByReferrerMobile(referrerMobile).ToList();
    	}
    	public List<QualificationStudent> FindByReferrerQQ(string referrerQQ){
    		return this.Repository.FindByReferrerQQ(referrerQQ).ToList();
    	}
    	public List<QualificationStudent> FindByMatriculateTime(Nullable<System.DateTime> matriculateTime){
    		return this.Repository.FindByMatriculateTime(matriculateTime).ToList();
    	}
    	public List<QualificationStudent> FindByNetUserName(string netUserName){
    		return this.Repository.FindByNetUserName(netUserName).ToList();
    	}
    	public List<QualificationStudent> FindByNetPassword(string netPassword){
    		return this.Repository.FindByNetPassword(netPassword).ToList();
    	}
    	public List<QualificationStudent> FindByStudyType(string studyType){
    		return this.Repository.FindByStudyType(studyType).ToList();
    	}
    	public List<QualificationStudent> FindBySubmitStatus(string submitStatus){
    		return this.Repository.FindBySubmitStatus(submitStatus).ToList();
    	}
    	public List<QualificationStudent> FindByOfferStatus(string offerStatus){
    		return this.Repository.FindByOfferStatus(offerStatus).ToList();
    	}
    	public List<QualificationStudent> FindByPayStatus(string payStatus){
    		return this.Repository.FindByPayStatus(payStatus).ToList();
    	}
    	public List<QualificationStudent> FindByPaperStatus(string paperStatus){
    		return this.Repository.FindByPaperStatus(paperStatus).ToList();
    	}
    	public List<QualificationStudent> FindByOldOAId(string oldOAId){
    		return this.Repository.FindByOldOAId(oldOAId).ToList();
    	}
    	public List<QualificationStudent> FindByPhoto1(string photo1){
    		return this.Repository.FindByPhoto1(photo1).ToList();
    	}
    	public List<QualificationStudent> FindByPhoto2(string photo2){
    		return this.Repository.FindByPhoto2(photo2).ToList();
    	}
    	public List<QualificationStudent> FindByPhoto3(string photo3){
    		return this.Repository.FindByPhoto3(photo3).ToList();
    	}
    	public PagedModel<QualificationStudent> FindByCriteria(QualificationStudentCriteria c) {
    		PagedModel<QualificationStudent> m = new PagedModel<QualificationStudent>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("clazz")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Clazz);
    			}else{
    				r = r.OrderByDescending(o=>o.Clazz);
    			}
    		}
    		if(c.sortname.ToLower().Equals("targetschoolname")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TargetSchoolName);
    			}else{
    				r = r.OrderByDescending(o=>o.TargetSchoolName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("signuptime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SignUpTime);
    			}else{
    				r = r.OrderByDescending(o=>o.SignUpTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("seqno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SeqNo);
    			}else{
    				r = r.OrderByDescending(o=>o.SeqNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("targetprofession")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TargetProfession);
    			}else{
    				r = r.OrderByDescending(o=>o.TargetProfession);
    			}
    		}
    		if(c.sortname.ToLower().Equals("targetlevel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TargetLevel);
    			}else{
    				r = r.OrderByDescending(o=>o.TargetLevel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentNo);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("sex")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Sex);
    			}else{
    				r = r.OrderByDescending(o=>o.Sex);
    			}
    		}
    		if(c.sortname.ToLower().Equals("birthday")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Birthday);
    			}else{
    				r = r.OrderByDescending(o=>o.Birthday);
    			}
    		}
    		if(c.sortname.ToLower().Equals("jiguang")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.JiGuang);
    			}else{
    				r = r.OrderByDescending(o=>o.JiGuang);
    			}
    		}
    		if(c.sortname.ToLower().Equals("idcardno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IdCardNo);
    			}else{
    				r = r.OrderByDescending(o=>o.IdCardNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("minzu")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MinZu);
    			}else{
    				r = r.OrderByDescending(o=>o.MinZu);
    			}
    		}
    		if(c.sortname.ToLower().Equals("zhengzhimianmao")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ZhengZhiMianMao);
    			}else{
    				r = r.OrderByDescending(o=>o.ZhengZhiMianMao);
    			}
    		}
    		if(c.sortname.ToLower().Equals("ismarried")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsMarried);
    			}else{
    				r = r.OrderByDescending(o=>o.IsMarried);
    			}
    		}
    		if(c.sortname.ToLower().Equals("homeaddress")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HomeAddress);
    			}else{
    				r = r.OrderByDescending(o=>o.HomeAddress);
    			}
    		}
    		if(c.sortname.ToLower().Equals("hukouaddress")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HuKouAddress);
    			}else{
    				r = r.OrderByDescending(o=>o.HuKouAddress);
    			}
    		}
    		if(c.sortname.ToLower().Equals("commaddress")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CommAddress);
    			}else{
    				r = r.OrderByDescending(o=>o.CommAddress);
    			}
    		}
    		if(c.sortname.ToLower().Equals("postcode")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Postcode);
    			}else{
    				r = r.OrderByDescending(o=>o.Postcode);
    			}
    		}
    		if(c.sortname.ToLower().Equals("hometelephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HomeTelephone);
    			}else{
    				r = r.OrderByDescending(o=>o.HomeTelephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QQ);
    			}else{
    				r = r.OrderByDescending(o=>o.QQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("company")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Company);
    			}else{
    				r = r.OrderByDescending(o=>o.Company);
    			}
    		}
    		if(c.sortname.ToLower().Equals("title")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Title);
    			}else{
    				r = r.OrderByDescending(o=>o.Title);
    			}
    		}
    		if(c.sortname.ToLower().Equals("companytelephoneno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CompanyTelephoneNo);
    			}else{
    				r = r.OrderByDescending(o=>o.CompanyTelephoneNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("beginworktime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.BeginWorkTime);
    			}else{
    				r = r.OrderByDescending(o=>o.BeginWorkTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("workedyears")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.WorkedYears);
    			}else{
    				r = r.OrderByDescending(o=>o.WorkedYears);
    			}
    		}
    		if(c.sortname.ToLower().Equals("highestedulevel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HighestEduLevel);
    			}else{
    				r = r.OrderByDescending(o=>o.HighestEduLevel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("highestqualification")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HighestQualification);
    			}else{
    				r = r.OrderByDescending(o=>o.HighestQualification);
    			}
    		}
    		if(c.sortname.ToLower().Equals("graduatedate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GraduateDate);
    			}else{
    				r = r.OrderByDescending(o=>o.GraduateDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gruduateschool")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GruduateSchool);
    			}else{
    				r = r.OrderByDescending(o=>o.GruduateSchool);
    			}
    		}
    		if(c.sortname.ToLower().Equals("highestqualificationno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HighestQualificationNo);
    			}else{
    				r = r.OrderByDescending(o=>o.HighestQualificationNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyduration1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyDuration1);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyDuration1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyschool1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudySchool1);
    			}else{
    				r = r.OrderByDescending(o=>o.StudySchool1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyposition1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyPosition1);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyPosition1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyduration2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyDuration2);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyDuration2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyschool2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudySchool2);
    			}else{
    				r = r.OrderByDescending(o=>o.StudySchool2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyposition2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyPosition2);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyPosition2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyduration3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyDuration3);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyDuration3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyschool3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudySchool3);
    			}else{
    				r = r.OrderByDescending(o=>o.StudySchool3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studyposition3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyPosition3);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyPosition3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberreltype1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberRelType1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberRelType1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membername1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberName1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberName1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermianmao1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMianMao1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMianMao1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membercompany1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberCompany1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberCompany1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberposition1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberPosition1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberPosition1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermobile1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMobile1);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMobile1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberreltype2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberRelType2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberRelType2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membername2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberName2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberName2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermianmao2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMianMao2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMianMao2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membercompany2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberCompany2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberCompany2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberposition2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberPosition2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberPosition2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermobile2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMobile2);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMobile2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("remark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Remark);
    			}else{
    				r = r.OrderByDescending(o=>o.Remark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("status")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Status);
    			}else{
    				r = r.OrderByDescending(o=>o.Status);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consultant")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Consultant);
    			}else{
    				r = r.OrderByDescending(o=>o.Consultant);
    			}
    		}
    		if(c.sortname.ToLower().Equals("referrer")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Referrer);
    			}else{
    				r = r.OrderByDescending(o=>o.Referrer);
    			}
    		}
    		if(c.sortname.ToLower().Equals("referrermobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ReferrerMobile);
    			}else{
    				r = r.OrderByDescending(o=>o.ReferrerMobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("referrerqq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ReferrerQQ);
    			}else{
    				r = r.OrderByDescending(o=>o.ReferrerQQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("matriculatetime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MatriculateTime);
    			}else{
    				r = r.OrderByDescending(o=>o.MatriculateTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("netusername")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NetUserName);
    			}else{
    				r = r.OrderByDescending(o=>o.NetUserName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("netpassword")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NetPassword);
    			}else{
    				r = r.OrderByDescending(o=>o.NetPassword);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studytype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudyType);
    			}else{
    				r = r.OrderByDescending(o=>o.StudyType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("submitstatus")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SubmitStatus);
    			}else{
    				r = r.OrderByDescending(o=>o.SubmitStatus);
    			}
    		}
    		if(c.sortname.ToLower().Equals("offerstatus")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OfferStatus);
    			}else{
    				r = r.OrderByDescending(o=>o.OfferStatus);
    			}
    		}
    		if(c.sortname.ToLower().Equals("paystatus")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PayStatus);
    			}else{
    				r = r.OrderByDescending(o=>o.PayStatus);
    			}
    		}
    		if(c.sortname.ToLower().Equals("paperstatus")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PaperStatus);
    			}else{
    				r = r.OrderByDescending(o=>o.PaperStatus);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOAId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOAId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("photo1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Photo1);
    			}else{
    				r = r.OrderByDescending(o=>o.Photo1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("photo2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Photo2);
    			}else{
    				r = r.OrderByDescending(o=>o.Photo2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("photo3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Photo3);
    			}else{
    				r = r.OrderByDescending(o=>o.Photo3);
    			}
    		}
    		
    		}
    		
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
    }
}
