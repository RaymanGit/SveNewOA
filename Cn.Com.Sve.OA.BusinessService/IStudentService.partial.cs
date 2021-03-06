using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IStudentService {
    	IUnitOfWork Db { get; }
    
    	void Add(Student entity);
    	void Update(Student entity);
    	void Save(Student entity);
    	void Delete(Student entity);
    	void DeleteById(int id);
    	List<Student> FindAll();
    	Student FindById(int id);
    	List<Student> FindByName(string name);
    	List<Student> FindByPinYin(string pinYin);
    	List<Student> FindByGender(string gender);
    	List<Student> FindByBirthday(Nullable<System.DateTime> birthday);
    	List<Student> FindByEduLevel(string eduLevel);
    	List<Student> FindByGraduateDate(Nullable<System.DateTime> graduateDate);
    	List<Student> FindByScore(Nullable<int> score);
    	List<Student> FindByGruduateSchoolId(Nullable<int> gruduateSchoolId);
    	List<Student> FindByProfession(string profession);
    	List<Student> FindByIdCardNo(string idCardNo);
    	List<Student> FindByHuKouType(string huKouType);
    	List<Student> FindByAddress(string address);
    	List<Student> FindByPostcode(string postcode);
    	List<Student> FindByFeeSource(string feeSource);
    	List<Student> FindBySmallInfoSourceId(Nullable<int> smallInfoSourceId);
    	List<Student> FindByQQ(string qQ);
    	List<Student> FindByEmail(string email);
    	List<Student> FindByMobile(string mobile);
    	List<Student> FindByHomeTelephone(string homeTelephone);
    	List<Student> FindByOfficeTelephone(string officeTelephone);
    	List<Student> FindByMemberRelType1(string memberRelType1);
    	List<Student> FindByMemberName1(string memberName1);
    	List<Student> FindByMemberCompany1(string memberCompany1);
    	List<Student> FindByMemberPosition1(string memberPosition1);
    	List<Student> FindByMemberMobile1(string memberMobile1);
    	List<Student> FindByMemberRelType2(string memberRelType2);
    	List<Student> FindByMemberName2(string memberName2);
    	List<Student> FindByMemberCompany2(string memberCompany2);
    	List<Student> FindByMemberPosition2(string memberPosition2);
    	List<Student> FindByMemberMobile2(string memberMobile2);
    	List<Student> FindByMemberRelType3(string memberRelType3);
    	List<Student> FindByMemberName3(string memberName3);
    	List<Student> FindByMemberCompany3(string memberCompany3);
    	List<Student> FindByMemberPosition3(string memberPosition3);
    	List<Student> FindByMemberMobile3(string memberMobile3);
    	List<Student> FindByMemberRelType4(string memberRelType4);
    	List<Student> FindByMemberName4(string memberName4);
    	List<Student> FindByMemberCompany4(string memberCompany4);
    	List<Student> FindByMemberPosition4(string memberPosition4);
    	List<Student> FindByMemberMobile4(string memberMobile4);
    	List<Student> FindByWorkState(string workState);
    	List<Student> FindByStudyDuration1(string studyDuration1);
    	List<Student> FindByStudySchool1(string studySchool1);
    	List<Student> FindByStudyPosition1(string studyPosition1);
    	List<Student> FindByStudyDuration2(string studyDuration2);
    	List<Student> FindByStudySchool2(string studySchool2);
    	List<Student> FindByStudyPosition2(string studyPosition2);
    	List<Student> FindByStudyDuration3(string studyDuration3);
    	List<Student> FindByStudySchool3(string studySchool3);
    	List<Student> FindByStudyPosition3(string studyPosition3);
    	List<Student> FindBySoftwareExp(string softwareExp);
    	List<Student> FindByProgramExp(string programExp);
    	List<Student> FindByNetworkExp(string networkExp);
    	List<Student> FindByRelCourse(string relCourse);
    	List<Student> FindByDistrictId(Nullable<int> districtId);
    	List<Student> FindByIntentCity(string intentCity);
    	List<Student> FindByClazzId(Nullable<int> clazzId);
    	List<Student> FindByStudentNo(string studentNo);
    	List<Student> FindByInSchoolDate(Nullable<System.DateTime> inSchoolDate);
    	List<Student> FindByIsDorm(string isDorm);
    	List<Student> FindByDormNo(string dormNo);
    	List<Student> FindByGiveCourseware(string giveCourseware);
    	List<Student> FindByConsultants(string consultants);
    	List<Student> FindByRemark(string remark);
    	List<Student> FindByCreateTime(System.DateTime createTime);
    	List<Student> FindByLastUpdateTime(System.DateTime lastUpdateTime);
    	List<Student> FindByIsGetQualification(string isGetQualification);
    	List<Student> FindByStatus(string status);
    	List<Student> FindByTechnicalWay(string technicalWay);
    	List<Student> FindByNeedObtainWork(string needObtainWork);
    	List<Student> FindByIntentPosition(string intentPosition);
    	List<Student> FindByTargetSalary(Nullable<decimal> targetSalary);
    	List<Student> FindByInsuranceStartDate(Nullable<System.DateTime> insuranceStartDate);
    	List<Student> FindByInsuranceEndDate(Nullable<System.DateTime> insuranceEndDate);
    	List<Student> FindByGaoKaoBatch(string gaoKaoBatch);
    	List<Student> FindByGiveNotebook(string giveNotebook);
    	List<Student> FindByMaxSalary(Nullable<decimal> maxSalary);
    	List<Student> FindByCurrentSalary(Nullable<decimal> currentSalary);
    	List<Student> FindByFirstSalary(Nullable<decimal> firstSalary);
    	List<Student> FindByBeginSchoolTime(Nullable<System.DateTime> beginSchoolTime);
    	List<Student> FindByMasterName1(string masterName1);
    	List<Student> FindByMasterName2(string masterName2);
    	List<Student> FindByMasterName3(string masterName3);
    	List<Student> FindByTeacherName1(string teacherName1);
    	List<Student> FindByTeacherName2(string teacherName2);
    	List<Student> FindByTeacherName3(string teacherName3);
    	List<Student> FindByMasterId1(Nullable<int> masterId1);
    	List<Student> FindByMasterId2(Nullable<int> masterId2);
    	List<Student> FindByMasterId3(Nullable<int> masterId3);
    	List<Student> FindByTeacherId1(Nullable<int> teacherId1);
    	List<Student> FindByTeacherId2(Nullable<int> teacherId2);
    	List<Student> FindByTeacherId3(Nullable<int> teacherId3);
    	List<Student> FindByQualificationSchool(string qualificationSchool);
    	List<Student> FindByInsuranceStatus(string insuranceStatus);
    	List<Student> FindByOldOaId(string oldOaId);
    	List<Student> FindByOldOaInfoSourceSubTypeName(string oldOaInfoSourceSubTypeName);
    	List<Student> FindByOldOaClass(string oldOaClass);
    	List<Student> FindByHasRelTeacher(string hasRelTeacher);
    	List<Student> FindByRelTeacher(string relTeacher);
    	List<Student> FindByHomeIntro(string homeIntro);
    	List<Student> FindByGive1(string give1);
    	List<Student> FindByGive2(string give2);
    	List<Student> FindByGive3(string give3);
    	List<Student> FindByReceive1(string receive1);
    	List<Student> FindByReceive2(string receive2);
    	List<Student> FindByReceive3(string receive3);
    	List<Student> FindByReceive4(string receive4);
    	List<Student> FindByReceive5(string receive5);
    	List<Student> FindByReceive6(string receive6);
    	List<Student> FindByPic1(string pic1);
    	List<Student> FindByPic2(string pic2);
    	List<Student> FindByPic3(string pic3);
    	List<Student> FindByPic4(string pic4);
    	List<Student> FindByPic5(string pic5);
    	List<Student> FindByPic6(string pic6);
    	PagedModel<Student> FindByCriteria(StudentCriteria c);
    }
}
