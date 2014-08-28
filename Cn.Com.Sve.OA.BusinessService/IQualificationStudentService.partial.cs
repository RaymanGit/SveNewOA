using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IQualificationStudentService {
    	IUnitOfWork Db { get; }
    
    	void Add(QualificationStudent entity);
    	void Update(QualificationStudent entity);
    	void Save(QualificationStudent entity);
    	void Delete(QualificationStudent entity);
    	void DeleteById(int id);
    	List<QualificationStudent> FindAll();
    	QualificationStudent FindById(int id);
    	List<QualificationStudent> FindByClazz(string clazz);
    	List<QualificationStudent> FindByTargetSchoolName(string targetSchoolName);
    	List<QualificationStudent> FindBySignUpTime(Nullable<System.DateTime> signUpTime);
    	List<QualificationStudent> FindBySeqNo(string seqNo);
    	List<QualificationStudent> FindByTargetProfession(string targetProfession);
    	List<QualificationStudent> FindByTargetLevel(string targetLevel);
    	List<QualificationStudent> FindByStudentNo(string studentNo);
    	List<QualificationStudent> FindByName(string name);
    	List<QualificationStudent> FindBySex(string sex);
    	List<QualificationStudent> FindByBirthday(Nullable<System.DateTime> birthday);
    	List<QualificationStudent> FindByJiGuang(string jiGuang);
    	List<QualificationStudent> FindByIdCardNo(string idCardNo);
    	List<QualificationStudent> FindByMinZu(string minZu);
    	List<QualificationStudent> FindByZhengZhiMianMao(string zhengZhiMianMao);
    	List<QualificationStudent> FindByIsMarried(string isMarried);
    	List<QualificationStudent> FindByHomeAddress(string homeAddress);
    	List<QualificationStudent> FindByHuKouAddress(string huKouAddress);
    	List<QualificationStudent> FindByCommAddress(string commAddress);
    	List<QualificationStudent> FindByPostcode(string postcode);
    	List<QualificationStudent> FindByHomeTelephone(string homeTelephone);
    	List<QualificationStudent> FindByMobile(string mobile);
    	List<QualificationStudent> FindByQQ(string qQ);
    	List<QualificationStudent> FindByCompany(string company);
    	List<QualificationStudent> FindByTitle(string title);
    	List<QualificationStudent> FindByCompanyTelephoneNo(string companyTelephoneNo);
    	List<QualificationStudent> FindByBeginWorkTime(Nullable<System.DateTime> beginWorkTime);
    	List<QualificationStudent> FindByWorkedYears(Nullable<int> workedYears);
    	List<QualificationStudent> FindByHighestEduLevel(string highestEduLevel);
    	List<QualificationStudent> FindByHighestQualification(string highestQualification);
    	List<QualificationStudent> FindByGraduateDate(Nullable<System.DateTime> graduateDate);
    	List<QualificationStudent> FindByGruduateSchool(string gruduateSchool);
    	List<QualificationStudent> FindByHighestQualificationNo(string highestQualificationNo);
    	List<QualificationStudent> FindByStudyDuration1(string studyDuration1);
    	List<QualificationStudent> FindByStudySchool1(string studySchool1);
    	List<QualificationStudent> FindByStudyPosition1(string studyPosition1);
    	List<QualificationStudent> FindByStudyDuration2(string studyDuration2);
    	List<QualificationStudent> FindByStudySchool2(string studySchool2);
    	List<QualificationStudent> FindByStudyPosition2(string studyPosition2);
    	List<QualificationStudent> FindByStudyDuration3(string studyDuration3);
    	List<QualificationStudent> FindByStudySchool3(string studySchool3);
    	List<QualificationStudent> FindByStudyPosition3(string studyPosition3);
    	List<QualificationStudent> FindByMemberRelType1(string memberRelType1);
    	List<QualificationStudent> FindByMemberName1(string memberName1);
    	List<QualificationStudent> FindByMemberMianMao1(string memberMianMao1);
    	List<QualificationStudent> FindByMemberCompany1(string memberCompany1);
    	List<QualificationStudent> FindByMemberPosition1(string memberPosition1);
    	List<QualificationStudent> FindByMemberMobile1(string memberMobile1);
    	List<QualificationStudent> FindByMemberRelType2(string memberRelType2);
    	List<QualificationStudent> FindByMemberName2(string memberName2);
    	List<QualificationStudent> FindByMemberMianMao2(string memberMianMao2);
    	List<QualificationStudent> FindByMemberCompany2(string memberCompany2);
    	List<QualificationStudent> FindByMemberPosition2(string memberPosition2);
    	List<QualificationStudent> FindByMemberMobile2(string memberMobile2);
    	List<QualificationStudent> FindByRemark(string remark);
    	List<QualificationStudent> FindByStatus(string status);
    	List<QualificationStudent> FindByConsultant(string consultant);
    	List<QualificationStudent> FindByReferrer(string referrer);
    	List<QualificationStudent> FindByReferrerMobile(string referrerMobile);
    	List<QualificationStudent> FindByReferrerQQ(string referrerQQ);
    	List<QualificationStudent> FindByMatriculateTime(Nullable<System.DateTime> matriculateTime);
    	List<QualificationStudent> FindByNetUserName(string netUserName);
    	List<QualificationStudent> FindByNetPassword(string netPassword);
    	List<QualificationStudent> FindByStudyType(string studyType);
    	List<QualificationStudent> FindBySubmitStatus(string submitStatus);
    	List<QualificationStudent> FindByOfferStatus(string offerStatus);
    	List<QualificationStudent> FindByPayStatus(string payStatus);
    	List<QualificationStudent> FindByPaperStatus(string paperStatus);
    	List<QualificationStudent> FindByOldOAId(string oldOAId);
    	List<QualificationStudent> FindByPhoto1(string photo1);
    	List<QualificationStudent> FindByPhoto2(string photo2);
    	List<QualificationStudent> FindByPhoto3(string photo3);
    	PagedModel<QualificationStudent> FindByCriteria(QualificationStudentCriteria c);
    }
}
