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
    public partial class StudentService : IStudentService {
    	public IUnitOfWork Db { get; private set; }
    	protected SysContext SysContext{get; private set;}
    	protected IStudentRepository Repository { get; private set; }
    	public StudentService(SysContext ctx) {
    		this.SysContext = ctx;
    		this.Db = DbContextFactory.Create();
    		this.Repository = new StudentRepository(this.Db);
    	}
    	public StudentService(SysContext ctx, IUnitOfWork db) {
    		this.SysContext = ctx;
    		if(db!=null){
    			this.Db = db;
    		}else{
    			this.Db = DbContextFactory.Create();
    		}
    		this.Repository = new StudentRepository(this.Db);
    	}
    	
    	
    	public void Add(Student entity) {
    		this.Repository.Add(entity);
    		this.Db.Save();		
    	}
    
    	public void Update(Student entity) {
    		this.Repository.Update(entity);
    		this.Db.Save();		
    	}
    
    	public void Save(Student entity){
    		if(entity.Id==0){
    			this.Add(entity);
    		}else{
    			this.Db.Save();	
    		}
    	}
    
    	public void Delete(Student entity) {
    		this.Repository.Delete(entity);
    		this.Db.Save();
    	}
    
    	public void DeleteById(int id) {
    		this.Repository.DeleteById(id);
    		this.Db.Save();
    	}
    
    	public List<Student> FindAll() {
    		return this.Repository.FindAll().ToList();
    	}
    
    	public Student FindById(int id) {
    		return this.Repository.FindById(id);
    	}
    	public List<Student> FindByName(string name){
    		return this.Repository.FindByName(name).ToList();
    	}
    	public List<Student> FindByPinYin(string pinYin){
    		return this.Repository.FindByPinYin(pinYin).ToList();
    	}
    	public List<Student> FindByGender(string gender){
    		return this.Repository.FindByGender(gender).ToList();
    	}
    	public List<Student> FindByBirthday(Nullable<System.DateTime> birthday){
    		return this.Repository.FindByBirthday(birthday).ToList();
    	}
    	public List<Student> FindByEduLevel(string eduLevel){
    		return this.Repository.FindByEduLevel(eduLevel).ToList();
    	}
    	public List<Student> FindByGraduateDate(Nullable<System.DateTime> graduateDate){
    		return this.Repository.FindByGraduateDate(graduateDate).ToList();
    	}
    	public List<Student> FindByScore(Nullable<int> score){
    		return this.Repository.FindByScore(score).ToList();
    	}
    	public List<Student> FindByGruduateSchoolId(Nullable<int> gruduateSchoolId){
    		return this.Repository.FindByGruduateSchoolId(gruduateSchoolId).ToList();
    	}
    	public List<Student> FindByProfession(string profession){
    		return this.Repository.FindByProfession(profession).ToList();
    	}
    	public List<Student> FindByIdCardNo(string idCardNo){
    		return this.Repository.FindByIdCardNo(idCardNo).ToList();
    	}
    	public List<Student> FindByHuKouType(string huKouType){
    		return this.Repository.FindByHuKouType(huKouType).ToList();
    	}
    	public List<Student> FindByAddress(string address){
    		return this.Repository.FindByAddress(address).ToList();
    	}
    	public List<Student> FindByPostcode(string postcode){
    		return this.Repository.FindByPostcode(postcode).ToList();
    	}
    	public List<Student> FindByFeeSource(string feeSource){
    		return this.Repository.FindByFeeSource(feeSource).ToList();
    	}
    	public List<Student> FindBySmallInfoSourceId(Nullable<int> smallInfoSourceId){
    		return this.Repository.FindBySmallInfoSourceId(smallInfoSourceId).ToList();
    	}
    	public List<Student> FindByQQ(string qQ){
    		return this.Repository.FindByQQ(qQ).ToList();
    	}
    	public List<Student> FindByEmail(string email){
    		return this.Repository.FindByEmail(email).ToList();
    	}
    	public List<Student> FindByMobile(string mobile){
    		return this.Repository.FindByMobile(mobile).ToList();
    	}
    	public List<Student> FindByHomeTelephone(string homeTelephone){
    		return this.Repository.FindByHomeTelephone(homeTelephone).ToList();
    	}
    	public List<Student> FindByOfficeTelephone(string officeTelephone){
    		return this.Repository.FindByOfficeTelephone(officeTelephone).ToList();
    	}
    	public List<Student> FindByMemberRelType1(string memberRelType1){
    		return this.Repository.FindByMemberRelType1(memberRelType1).ToList();
    	}
    	public List<Student> FindByMemberName1(string memberName1){
    		return this.Repository.FindByMemberName1(memberName1).ToList();
    	}
    	public List<Student> FindByMemberCompany1(string memberCompany1){
    		return this.Repository.FindByMemberCompany1(memberCompany1).ToList();
    	}
    	public List<Student> FindByMemberPosition1(string memberPosition1){
    		return this.Repository.FindByMemberPosition1(memberPosition1).ToList();
    	}
    	public List<Student> FindByMemberMobile1(string memberMobile1){
    		return this.Repository.FindByMemberMobile1(memberMobile1).ToList();
    	}
    	public List<Student> FindByMemberRelType2(string memberRelType2){
    		return this.Repository.FindByMemberRelType2(memberRelType2).ToList();
    	}
    	public List<Student> FindByMemberName2(string memberName2){
    		return this.Repository.FindByMemberName2(memberName2).ToList();
    	}
    	public List<Student> FindByMemberCompany2(string memberCompany2){
    		return this.Repository.FindByMemberCompany2(memberCompany2).ToList();
    	}
    	public List<Student> FindByMemberPosition2(string memberPosition2){
    		return this.Repository.FindByMemberPosition2(memberPosition2).ToList();
    	}
    	public List<Student> FindByMemberMobile2(string memberMobile2){
    		return this.Repository.FindByMemberMobile2(memberMobile2).ToList();
    	}
    	public List<Student> FindByMemberRelType3(string memberRelType3){
    		return this.Repository.FindByMemberRelType3(memberRelType3).ToList();
    	}
    	public List<Student> FindByMemberName3(string memberName3){
    		return this.Repository.FindByMemberName3(memberName3).ToList();
    	}
    	public List<Student> FindByMemberCompany3(string memberCompany3){
    		return this.Repository.FindByMemberCompany3(memberCompany3).ToList();
    	}
    	public List<Student> FindByMemberPosition3(string memberPosition3){
    		return this.Repository.FindByMemberPosition3(memberPosition3).ToList();
    	}
    	public List<Student> FindByMemberMobile3(string memberMobile3){
    		return this.Repository.FindByMemberMobile3(memberMobile3).ToList();
    	}
    	public List<Student> FindByMemberRelType4(string memberRelType4){
    		return this.Repository.FindByMemberRelType4(memberRelType4).ToList();
    	}
    	public List<Student> FindByMemberName4(string memberName4){
    		return this.Repository.FindByMemberName4(memberName4).ToList();
    	}
    	public List<Student> FindByMemberCompany4(string memberCompany4){
    		return this.Repository.FindByMemberCompany4(memberCompany4).ToList();
    	}
    	public List<Student> FindByMemberPosition4(string memberPosition4){
    		return this.Repository.FindByMemberPosition4(memberPosition4).ToList();
    	}
    	public List<Student> FindByMemberMobile4(string memberMobile4){
    		return this.Repository.FindByMemberMobile4(memberMobile4).ToList();
    	}
    	public List<Student> FindByWorkState(string workState){
    		return this.Repository.FindByWorkState(workState).ToList();
    	}
    	public List<Student> FindByStudyDuration1(string studyDuration1){
    		return this.Repository.FindByStudyDuration1(studyDuration1).ToList();
    	}
    	public List<Student> FindByStudySchool1(string studySchool1){
    		return this.Repository.FindByStudySchool1(studySchool1).ToList();
    	}
    	public List<Student> FindByStudyPosition1(string studyPosition1){
    		return this.Repository.FindByStudyPosition1(studyPosition1).ToList();
    	}
    	public List<Student> FindByStudyDuration2(string studyDuration2){
    		return this.Repository.FindByStudyDuration2(studyDuration2).ToList();
    	}
    	public List<Student> FindByStudySchool2(string studySchool2){
    		return this.Repository.FindByStudySchool2(studySchool2).ToList();
    	}
    	public List<Student> FindByStudyPosition2(string studyPosition2){
    		return this.Repository.FindByStudyPosition2(studyPosition2).ToList();
    	}
    	public List<Student> FindByStudyDuration3(string studyDuration3){
    		return this.Repository.FindByStudyDuration3(studyDuration3).ToList();
    	}
    	public List<Student> FindByStudySchool3(string studySchool3){
    		return this.Repository.FindByStudySchool3(studySchool3).ToList();
    	}
    	public List<Student> FindByStudyPosition3(string studyPosition3){
    		return this.Repository.FindByStudyPosition3(studyPosition3).ToList();
    	}
    	public List<Student> FindBySoftwareExp(string softwareExp){
    		return this.Repository.FindBySoftwareExp(softwareExp).ToList();
    	}
    	public List<Student> FindByProgramExp(string programExp){
    		return this.Repository.FindByProgramExp(programExp).ToList();
    	}
    	public List<Student> FindByNetworkExp(string networkExp){
    		return this.Repository.FindByNetworkExp(networkExp).ToList();
    	}
    	public List<Student> FindByRelCourse(string relCourse){
    		return this.Repository.FindByRelCourse(relCourse).ToList();
    	}
    	public List<Student> FindByDistrictId(Nullable<int> districtId){
    		return this.Repository.FindByDistrictId(districtId).ToList();
    	}
    	public List<Student> FindByIntentCity(string intentCity){
    		return this.Repository.FindByIntentCity(intentCity).ToList();
    	}
    	public List<Student> FindByClazzId(Nullable<int> clazzId){
    		return this.Repository.FindByClazzId(clazzId).ToList();
    	}
    	public List<Student> FindByStudentNo(string studentNo){
    		return this.Repository.FindByStudentNo(studentNo).ToList();
    	}
    	public List<Student> FindByInSchoolDate(Nullable<System.DateTime> inSchoolDate){
    		return this.Repository.FindByInSchoolDate(inSchoolDate).ToList();
    	}
    	public List<Student> FindByIsDorm(string isDorm){
    		return this.Repository.FindByIsDorm(isDorm).ToList();
    	}
    	public List<Student> FindByDormNo(string dormNo){
    		return this.Repository.FindByDormNo(dormNo).ToList();
    	}
    	public List<Student> FindByGiveCourseware(string giveCourseware){
    		return this.Repository.FindByGiveCourseware(giveCourseware).ToList();
    	}
    	public List<Student> FindByConsultants(string consultants){
    		return this.Repository.FindByConsultants(consultants).ToList();
    	}
    	public List<Student> FindByRemark(string remark){
    		return this.Repository.FindByRemark(remark).ToList();
    	}
    	public List<Student> FindByCreateTime(System.DateTime createTime){
    		return this.Repository.FindByCreateTime(createTime).ToList();
    	}
    	public List<Student> FindByLastUpdateTime(System.DateTime lastUpdateTime){
    		return this.Repository.FindByLastUpdateTime(lastUpdateTime).ToList();
    	}
    	public List<Student> FindByIsGetQualification(string isGetQualification){
    		return this.Repository.FindByIsGetQualification(isGetQualification).ToList();
    	}
    	public List<Student> FindByStatus(string status){
    		return this.Repository.FindByStatus(status).ToList();
    	}
    	public List<Student> FindByTechnicalWay(string technicalWay){
    		return this.Repository.FindByTechnicalWay(technicalWay).ToList();
    	}
    	public List<Student> FindByNeedObtainWork(string needObtainWork){
    		return this.Repository.FindByNeedObtainWork(needObtainWork).ToList();
    	}
    	public List<Student> FindByIntentPosition(string intentPosition){
    		return this.Repository.FindByIntentPosition(intentPosition).ToList();
    	}
    	public List<Student> FindByTargetSalary(Nullable<decimal> targetSalary){
    		return this.Repository.FindByTargetSalary(targetSalary).ToList();
    	}
    	public List<Student> FindByInsuranceStartDate(Nullable<System.DateTime> insuranceStartDate){
    		return this.Repository.FindByInsuranceStartDate(insuranceStartDate).ToList();
    	}
    	public List<Student> FindByInsuranceEndDate(Nullable<System.DateTime> insuranceEndDate){
    		return this.Repository.FindByInsuranceEndDate(insuranceEndDate).ToList();
    	}
    	public List<Student> FindByGaoKaoBatch(string gaoKaoBatch){
    		return this.Repository.FindByGaoKaoBatch(gaoKaoBatch).ToList();
    	}
    	public List<Student> FindByGiveNotebook(string giveNotebook){
    		return this.Repository.FindByGiveNotebook(giveNotebook).ToList();
    	}
    	public List<Student> FindByMaxSalary(Nullable<decimal> maxSalary){
    		return this.Repository.FindByMaxSalary(maxSalary).ToList();
    	}
    	public List<Student> FindByCurrentSalary(Nullable<decimal> currentSalary){
    		return this.Repository.FindByCurrentSalary(currentSalary).ToList();
    	}
    	public List<Student> FindByFirstSalary(Nullable<decimal> firstSalary){
    		return this.Repository.FindByFirstSalary(firstSalary).ToList();
    	}
    	public List<Student> FindByBeginSchoolTime(Nullable<System.DateTime> beginSchoolTime){
    		return this.Repository.FindByBeginSchoolTime(beginSchoolTime).ToList();
    	}
    	public List<Student> FindByMasterName1(string masterName1){
    		return this.Repository.FindByMasterName1(masterName1).ToList();
    	}
    	public List<Student> FindByMasterName2(string masterName2){
    		return this.Repository.FindByMasterName2(masterName2).ToList();
    	}
    	public List<Student> FindByMasterName3(string masterName3){
    		return this.Repository.FindByMasterName3(masterName3).ToList();
    	}
    	public List<Student> FindByTeacherName1(string teacherName1){
    		return this.Repository.FindByTeacherName1(teacherName1).ToList();
    	}
    	public List<Student> FindByTeacherName2(string teacherName2){
    		return this.Repository.FindByTeacherName2(teacherName2).ToList();
    	}
    	public List<Student> FindByTeacherName3(string teacherName3){
    		return this.Repository.FindByTeacherName3(teacherName3).ToList();
    	}
    	public List<Student> FindByMasterId1(Nullable<int> masterId1){
    		return this.Repository.FindByMasterId1(masterId1).ToList();
    	}
    	public List<Student> FindByMasterId2(Nullable<int> masterId2){
    		return this.Repository.FindByMasterId2(masterId2).ToList();
    	}
    	public List<Student> FindByMasterId3(Nullable<int> masterId3){
    		return this.Repository.FindByMasterId3(masterId3).ToList();
    	}
    	public List<Student> FindByTeacherId1(Nullable<int> teacherId1){
    		return this.Repository.FindByTeacherId1(teacherId1).ToList();
    	}
    	public List<Student> FindByTeacherId2(Nullable<int> teacherId2){
    		return this.Repository.FindByTeacherId2(teacherId2).ToList();
    	}
    	public List<Student> FindByTeacherId3(Nullable<int> teacherId3){
    		return this.Repository.FindByTeacherId3(teacherId3).ToList();
    	}
    	public List<Student> FindByQualificationSchool(string qualificationSchool){
    		return this.Repository.FindByQualificationSchool(qualificationSchool).ToList();
    	}
    	public List<Student> FindByInsuranceStatus(string insuranceStatus){
    		return this.Repository.FindByInsuranceStatus(insuranceStatus).ToList();
    	}
    	public List<Student> FindByOldOaId(string oldOaId){
    		return this.Repository.FindByOldOaId(oldOaId).ToList();
    	}
    	public List<Student> FindByOldOaInfoSourceSubTypeName(string oldOaInfoSourceSubTypeName){
    		return this.Repository.FindByOldOaInfoSourceSubTypeName(oldOaInfoSourceSubTypeName).ToList();
    	}
    	public List<Student> FindByOldOaClass(string oldOaClass){
    		return this.Repository.FindByOldOaClass(oldOaClass).ToList();
    	}
    	public List<Student> FindByHasRelTeacher(string hasRelTeacher){
    		return this.Repository.FindByHasRelTeacher(hasRelTeacher).ToList();
    	}
    	public List<Student> FindByRelTeacher(string relTeacher){
    		return this.Repository.FindByRelTeacher(relTeacher).ToList();
    	}
    	public List<Student> FindByHomeIntro(string homeIntro){
    		return this.Repository.FindByHomeIntro(homeIntro).ToList();
    	}
    	public List<Student> FindByGive1(string give1){
    		return this.Repository.FindByGive1(give1).ToList();
    	}
    	public List<Student> FindByGive2(string give2){
    		return this.Repository.FindByGive2(give2).ToList();
    	}
    	public List<Student> FindByGive3(string give3){
    		return this.Repository.FindByGive3(give3).ToList();
    	}
    	public List<Student> FindByReceive1(string receive1){
    		return this.Repository.FindByReceive1(receive1).ToList();
    	}
    	public List<Student> FindByReceive2(string receive2){
    		return this.Repository.FindByReceive2(receive2).ToList();
    	}
    	public List<Student> FindByReceive3(string receive3){
    		return this.Repository.FindByReceive3(receive3).ToList();
    	}
    	public List<Student> FindByReceive4(string receive4){
    		return this.Repository.FindByReceive4(receive4).ToList();
    	}
    	public List<Student> FindByReceive5(string receive5){
    		return this.Repository.FindByReceive5(receive5).ToList();
    	}
    	public List<Student> FindByReceive6(string receive6){
    		return this.Repository.FindByReceive6(receive6).ToList();
    	}
    	public List<Student> FindByPic1(string pic1){
    		return this.Repository.FindByPic1(pic1).ToList();
    	}
    	public List<Student> FindByPic2(string pic2){
    		return this.Repository.FindByPic2(pic2).ToList();
    	}
    	public List<Student> FindByPic3(string pic3){
    		return this.Repository.FindByPic3(pic3).ToList();
    	}
    	public List<Student> FindByPic4(string pic4){
    		return this.Repository.FindByPic4(pic4).ToList();
    	}
    	public List<Student> FindByPic5(string pic5){
    		return this.Repository.FindByPic5(pic5).ToList();
    	}
    	public List<Student> FindByPic6(string pic6){
    		return this.Repository.FindByPic6(pic6).ToList();
    	}
    	public PagedModel<Student> FindByCriteria(StudentCriteria c) {
    		PagedModel<Student> m = new PagedModel<Student>();
    		var r = this.Repository.FindByCriteria(c);
    		if(!String.IsNullOrEmpty(c.sortname)){
    		if(c.sortname.ToLower().Equals("id")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Id);
    			}else{
    				r = r.OrderByDescending(o=>o.Id);
    			}
    		}
    		if(c.sortname.ToLower().Equals("name")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Name);
    			}else{
    				r = r.OrderByDescending(o=>o.Name);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pinyin")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.PinYin);
    			}else{
    				r = r.OrderByDescending(o=>o.PinYin);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gender")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Gender);
    			}else{
    				r = r.OrderByDescending(o=>o.Gender);
    			}
    		}
    		if(c.sortname.ToLower().Equals("birthday")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Birthday);
    			}else{
    				r = r.OrderByDescending(o=>o.Birthday);
    			}
    		}
    		if(c.sortname.ToLower().Equals("edulevel")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.EduLevel);
    			}else{
    				r = r.OrderByDescending(o=>o.EduLevel);
    			}
    		}
    		if(c.sortname.ToLower().Equals("graduatedate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GraduateDate);
    			}else{
    				r = r.OrderByDescending(o=>o.GraduateDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("score")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Score);
    			}else{
    				r = r.OrderByDescending(o=>o.Score);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gruduateschoolid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GruduateSchoolId);
    			}else{
    				r = r.OrderByDescending(o=>o.GruduateSchoolId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("profession")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Profession);
    			}else{
    				r = r.OrderByDescending(o=>o.Profession);
    			}
    		}
    		if(c.sortname.ToLower().Equals("idcardno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IdCardNo);
    			}else{
    				r = r.OrderByDescending(o=>o.IdCardNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("hukoutype")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HuKouType);
    			}else{
    				r = r.OrderByDescending(o=>o.HuKouType);
    			}
    		}
    		if(c.sortname.ToLower().Equals("address")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Address);
    			}else{
    				r = r.OrderByDescending(o=>o.Address);
    			}
    		}
    		if(c.sortname.ToLower().Equals("postcode")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Postcode);
    			}else{
    				r = r.OrderByDescending(o=>o.Postcode);
    			}
    		}
    		if(c.sortname.ToLower().Equals("feesource")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.FeeSource);
    			}else{
    				r = r.OrderByDescending(o=>o.FeeSource);
    			}
    		}
    		if(c.sortname.ToLower().Equals("smallinfosourceid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SmallInfoSourceId);
    			}else{
    				r = r.OrderByDescending(o=>o.SmallInfoSourceId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qq")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QQ);
    			}else{
    				r = r.OrderByDescending(o=>o.QQ);
    			}
    		}
    		if(c.sortname.ToLower().Equals("email")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Email);
    			}else{
    				r = r.OrderByDescending(o=>o.Email);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mobile")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Mobile);
    			}else{
    				r = r.OrderByDescending(o=>o.Mobile);
    			}
    		}
    		if(c.sortname.ToLower().Equals("hometelephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HomeTelephone);
    			}else{
    				r = r.OrderByDescending(o=>o.HomeTelephone);
    			}
    		}
    		if(c.sortname.ToLower().Equals("officetelephone")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OfficeTelephone);
    			}else{
    				r = r.OrderByDescending(o=>o.OfficeTelephone);
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
    		if(c.sortname.ToLower().Equals("memberreltype3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberRelType3);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberRelType3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membername3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberName3);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberName3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membercompany3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberCompany3);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberCompany3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberposition3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberPosition3);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberPosition3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermobile3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMobile3);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMobile3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberreltype4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberRelType4);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberRelType4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membername4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberName4);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberName4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membercompany4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberCompany4);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberCompany4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("memberposition4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberPosition4);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberPosition4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("membermobile4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MemberMobile4);
    			}else{
    				r = r.OrderByDescending(o=>o.MemberMobile4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("workstate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.WorkState);
    			}else{
    				r = r.OrderByDescending(o=>o.WorkState);
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
    		if(c.sortname.ToLower().Equals("softwareexp")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.SoftwareExp);
    			}else{
    				r = r.OrderByDescending(o=>o.SoftwareExp);
    			}
    		}
    		if(c.sortname.ToLower().Equals("programexp")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ProgramExp);
    			}else{
    				r = r.OrderByDescending(o=>o.ProgramExp);
    			}
    		}
    		if(c.sortname.ToLower().Equals("networkexp")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NetworkExp);
    			}else{
    				r = r.OrderByDescending(o=>o.NetworkExp);
    			}
    		}
    		if(c.sortname.ToLower().Equals("relcourse")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.RelCourse);
    			}else{
    				r = r.OrderByDescending(o=>o.RelCourse);
    			}
    		}
    		if(c.sortname.ToLower().Equals("districtid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DistrictId);
    			}else{
    				r = r.OrderByDescending(o=>o.DistrictId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("intentcity")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IntentCity);
    			}else{
    				r = r.OrderByDescending(o=>o.IntentCity);
    			}
    		}
    		if(c.sortname.ToLower().Equals("clazzid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.ClazzId);
    			}else{
    				r = r.OrderByDescending(o=>o.ClazzId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("studentno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.StudentNo);
    			}else{
    				r = r.OrderByDescending(o=>o.StudentNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("inschooldate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InSchoolDate);
    			}else{
    				r = r.OrderByDescending(o=>o.InSchoolDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isdorm")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsDorm);
    			}else{
    				r = r.OrderByDescending(o=>o.IsDorm);
    			}
    		}
    		if(c.sortname.ToLower().Equals("dormno")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.DormNo);
    			}else{
    				r = r.OrderByDescending(o=>o.DormNo);
    			}
    		}
    		if(c.sortname.ToLower().Equals("givecourseware")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GiveCourseware);
    			}else{
    				r = r.OrderByDescending(o=>o.GiveCourseware);
    			}
    		}
    		if(c.sortname.ToLower().Equals("consultants")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Consultants);
    			}else{
    				r = r.OrderByDescending(o=>o.Consultants);
    			}
    		}
    		if(c.sortname.ToLower().Equals("remark")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Remark);
    			}else{
    				r = r.OrderByDescending(o=>o.Remark);
    			}
    		}
    		if(c.sortname.ToLower().Equals("createtime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CreateTime);
    			}else{
    				r = r.OrderByDescending(o=>o.CreateTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("lastupdatetime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.LastUpdateTime);
    			}else{
    				r = r.OrderByDescending(o=>o.LastUpdateTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("isgetqualification")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IsGetQualification);
    			}else{
    				r = r.OrderByDescending(o=>o.IsGetQualification);
    			}
    		}
    		if(c.sortname.ToLower().Equals("status")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Status);
    			}else{
    				r = r.OrderByDescending(o=>o.Status);
    			}
    		}
    		if(c.sortname.ToLower().Equals("technicalway")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TechnicalWay);
    			}else{
    				r = r.OrderByDescending(o=>o.TechnicalWay);
    			}
    		}
    		if(c.sortname.ToLower().Equals("needobtainwork")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.NeedObtainWork);
    			}else{
    				r = r.OrderByDescending(o=>o.NeedObtainWork);
    			}
    		}
    		if(c.sortname.ToLower().Equals("intentposition")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.IntentPosition);
    			}else{
    				r = r.OrderByDescending(o=>o.IntentPosition);
    			}
    		}
    		if(c.sortname.ToLower().Equals("targetsalary")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TargetSalary);
    			}else{
    				r = r.OrderByDescending(o=>o.TargetSalary);
    			}
    		}
    		if(c.sortname.ToLower().Equals("insurancestartdate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InsuranceStartDate);
    			}else{
    				r = r.OrderByDescending(o=>o.InsuranceStartDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("insuranceenddate")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InsuranceEndDate);
    			}else{
    				r = r.OrderByDescending(o=>o.InsuranceEndDate);
    			}
    		}
    		if(c.sortname.ToLower().Equals("gaokaobatch")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GaoKaoBatch);
    			}else{
    				r = r.OrderByDescending(o=>o.GaoKaoBatch);
    			}
    		}
    		if(c.sortname.ToLower().Equals("givenotebook")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.GiveNotebook);
    			}else{
    				r = r.OrderByDescending(o=>o.GiveNotebook);
    			}
    		}
    		if(c.sortname.ToLower().Equals("maxsalary")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MaxSalary);
    			}else{
    				r = r.OrderByDescending(o=>o.MaxSalary);
    			}
    		}
    		if(c.sortname.ToLower().Equals("currentsalary")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.CurrentSalary);
    			}else{
    				r = r.OrderByDescending(o=>o.CurrentSalary);
    			}
    		}
    		if(c.sortname.ToLower().Equals("firstsalary")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.FirstSalary);
    			}else{
    				r = r.OrderByDescending(o=>o.FirstSalary);
    			}
    		}
    		if(c.sortname.ToLower().Equals("beginschooltime")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.BeginSchoolTime);
    			}else{
    				r = r.OrderByDescending(o=>o.BeginSchoolTime);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mastername1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterName1);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterName1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mastername2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterName2);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterName2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("mastername3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterName3);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterName3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teachername1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherName1);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherName1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teachername2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherName2);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherName2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teachername3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherName3);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherName3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("masterid1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterId1);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterId1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("masterid2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterId2);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterId2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("masterid3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.MasterId3);
    			}else{
    				r = r.OrderByDescending(o=>o.MasterId3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teacherid1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherId1);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherId1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teacherid2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherId2);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherId2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("teacherid3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.TeacherId3);
    			}else{
    				r = r.OrderByDescending(o=>o.TeacherId3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("qualificationschool")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.QualificationSchool);
    			}else{
    				r = r.OrderByDescending(o=>o.QualificationSchool);
    			}
    		}
    		if(c.sortname.ToLower().Equals("insurancestatus")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.InsuranceStatus);
    			}else{
    				r = r.OrderByDescending(o=>o.InsuranceStatus);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaid")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaId);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaId);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoainfosourcesubtypename")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaInfoSourceSubTypeName);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaInfoSourceSubTypeName);
    			}
    		}
    		if(c.sortname.ToLower().Equals("oldoaclass")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.OldOaClass);
    			}else{
    				r = r.OrderByDescending(o=>o.OldOaClass);
    			}
    		}
    		if(c.sortname.ToLower().Equals("hasrelteacher")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HasRelTeacher);
    			}else{
    				r = r.OrderByDescending(o=>o.HasRelTeacher);
    			}
    		}
    		if(c.sortname.ToLower().Equals("relteacher")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.RelTeacher);
    			}else{
    				r = r.OrderByDescending(o=>o.RelTeacher);
    			}
    		}
    		if(c.sortname.ToLower().Equals("homeintro")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.HomeIntro);
    			}else{
    				r = r.OrderByDescending(o=>o.HomeIntro);
    			}
    		}
    		if(c.sortname.ToLower().Equals("give1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Give1);
    			}else{
    				r = r.OrderByDescending(o=>o.Give1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("give2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Give2);
    			}else{
    				r = r.OrderByDescending(o=>o.Give2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("give3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Give3);
    			}else{
    				r = r.OrderByDescending(o=>o.Give3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive1);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive2);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive3);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive4);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive5")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive5);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive5);
    			}
    		}
    		if(c.sortname.ToLower().Equals("receive6")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Receive6);
    			}else{
    				r = r.OrderByDescending(o=>o.Receive6);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic1")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic1);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic1);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic2")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic2);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic2);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic3")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic3);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic3);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic4")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic4);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic4);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic5")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic5);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic5);
    			}
    		}
    		if(c.sortname.ToLower().Equals("pic6")){
    			if(c.sortorder.ToLower().Equals("asc")){
    				r = r.OrderBy(o=>o.Pic6);
    			}else{
    				r = r.OrderByDescending(o=>o.Pic6);
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
