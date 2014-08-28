﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Cn.Com.Sve.OA.Entities
{
    public partial class OaDbContext : ObjectContext
    {
        public const string ConnectionString = "name=OaDbContext";
        public const string ContainerName = "OaDbContext";
    
        #region Constructors
    
        public OaDbContext()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OaDbContext(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public OaDbContext(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<City> Cities
        {
            get { return _cities  ?? (_cities = CreateObjectSet<City>("Cities")); }
        }
        private ObjectSet<City> _cities;
    
        public ObjectSet<District> Districts
        {
            get { return _districts  ?? (_districts = CreateObjectSet<District>("Districts")); }
        }
        private ObjectSet<District> _districts;
    
        public ObjectSet<Province> Provinces
        {
            get { return _provinces  ?? (_provinces = CreateObjectSet<Province>("Provinces")); }
        }
        private ObjectSet<Province> _provinces;
    
        public ObjectSet<School> Schools
        {
            get { return _schools  ?? (_schools = CreateObjectSet<School>("Schools")); }
        }
        private ObjectSet<School> _schools;
    
        public ObjectSet<User> Users
        {
            get { return _users  ?? (_users = CreateObjectSet<User>("Users")); }
        }
        private ObjectSet<User> _users;
    
        public ObjectSet<Module> Modules
        {
            get { return _modules  ?? (_modules = CreateObjectSet<Module>("Modules")); }
        }
        private ObjectSet<Module> _modules;
    
        public ObjectSet<Function> Functions
        {
            get { return _functions  ?? (_functions = CreateObjectSet<Function>("Functions")); }
        }
        private ObjectSet<Function> _functions;
    
        public ObjectSet<BigInfoSource> BigInfoSources
        {
            get { return _bigInfoSources  ?? (_bigInfoSources = CreateObjectSet<BigInfoSource>("BigInfoSources")); }
        }
        private ObjectSet<BigInfoSource> _bigInfoSources;
    
        public ObjectSet<SmallInfoSource> SmallInfoSources
        {
            get { return _smallInfoSources  ?? (_smallInfoSources = CreateObjectSet<SmallInfoSource>("SmallInfoSources")); }
        }
        private ObjectSet<SmallInfoSource> _smallInfoSources;
    
        public ObjectSet<SalesTeam> SalesTeams
        {
            get { return _salesTeams  ?? (_salesTeams = CreateObjectSet<SalesTeam>("SalesTeams")); }
        }
        private ObjectSet<SalesTeam> _salesTeams;
    
        public ObjectSet<SalesTeamMember> SalesTeamMembers
        {
            get { return _salesTeamMembers  ?? (_salesTeamMembers = CreateObjectSet<SalesTeamMember>("SalesTeamMembers")); }
        }
        private ObjectSet<SalesTeamMember> _salesTeamMembers;
    
        public ObjectSet<Customer> Customers
        {
            get { return _customers  ?? (_customers = CreateObjectSet<Customer>("Customers")); }
        }
        private ObjectSet<Customer> _customers;
    
        public ObjectSet<ImportCustomer> Marketing_ImportCustomer
        {
            get { return _marketing_ImportCustomer  ?? (_marketing_ImportCustomer = CreateObjectSet<ImportCustomer>("Marketing_ImportCustomer")); }
        }
        private ObjectSet<ImportCustomer> _marketing_ImportCustomer;
    
        public ObjectSet<ImportDupliate> ImportDupliates
        {
            get { return _importDupliates  ?? (_importDupliates = CreateObjectSet<ImportDupliate>("ImportDupliates")); }
        }
        private ObjectSet<ImportDupliate> _importDupliates;
    
        public ObjectSet<Knowledge> Knowledges
        {
            get { return _knowledges  ?? (_knowledges = CreateObjectSet<Knowledge>("Knowledges")); }
        }
        private ObjectSet<Knowledge> _knowledges;
    
        public ObjectSet<TelSaleLog> TelSaleLogs
        {
            get { return _telSaleLogs  ?? (_telSaleLogs = CreateObjectSet<TelSaleLog>("TelSaleLogs")); }
        }
        private ObjectSet<TelSaleLog> _telSaleLogs;
    
        public ObjectSet<Clazz> Clazzes
        {
            get { return _clazzes  ?? (_clazzes = CreateObjectSet<Clazz>("Clazzes")); }
        }
        private ObjectSet<Clazz> _clazzes;
    
        public ObjectSet<Student> Students
        {
            get { return _students  ?? (_students = CreateObjectSet<Student>("Students")); }
        }
        private ObjectSet<Student> _students;
    
        public ObjectSet<Supervisor> Supervisors
        {
            get { return _supervisors  ?? (_supervisors = CreateObjectSet<Supervisor>("Supervisors")); }
        }
        private ObjectSet<Supervisor> _supervisors;
    
        public ObjectSet<UserGroup> UserGroups
        {
            get { return _userGroups  ?? (_userGroups = CreateObjectSet<UserGroup>("UserGroups")); }
        }
        private ObjectSet<UserGroup> _userGroups;
    
        public ObjectSet<UserGroupFunctionPermission> UserGroupFunctionPermissions
        {
            get { return _userGroupFunctionPermissions  ?? (_userGroupFunctionPermissions = CreateObjectSet<UserGroupFunctionPermission>("UserGroupFunctionPermissions")); }
        }
        private ObjectSet<UserGroupFunctionPermission> _userGroupFunctionPermissions;
    
        public ObjectSet<UserGroupModulePermission> UserGroupModulePermissions
        {
            get { return _userGroupModulePermissions  ?? (_userGroupModulePermissions = CreateObjectSet<UserGroupModulePermission>("UserGroupModulePermissions")); }
        }
        private ObjectSet<UserGroupModulePermission> _userGroupModulePermissions;
    
        public ObjectSet<UserInGroup> UserInGroups
        {
            get { return _userInGroups  ?? (_userInGroups = CreateObjectSet<UserInGroup>("UserInGroups")); }
        }
        private ObjectSet<UserInGroup> _userInGroups;
    
        public ObjectSet<StudentTeleVisitRecord> Student_TeleVisitRecord
        {
            get { return _student_TeleVisitRecord  ?? (_student_TeleVisitRecord = CreateObjectSet<StudentTeleVisitRecord>("Student_TeleVisitRecord")); }
        }
        private ObjectSet<StudentTeleVisitRecord> _student_TeleVisitRecord;
    
        public ObjectSet<StudentVisitRecord> Student_VisitRecord
        {
            get { return _student_VisitRecord  ?? (_student_VisitRecord = CreateObjectSet<StudentVisitRecord>("Student_VisitRecord")); }
        }
        private ObjectSet<StudentVisitRecord> _student_VisitRecord;
    
        public ObjectSet<StudentHomeVisitRecord> Student_HomeVisitRecord
        {
            get { return _student_HomeVisitRecord  ?? (_student_HomeVisitRecord = CreateObjectSet<StudentHomeVisitRecord>("Student_HomeVisitRecord")); }
        }
        private ObjectSet<StudentHomeVisitRecord> _student_HomeVisitRecord;
    
        public ObjectSet<QualificationSchool> QualificationSchools
        {
            get { return _qualificationSchools  ?? (_qualificationSchools = CreateObjectSet<QualificationSchool>("QualificationSchools")); }
        }
        private ObjectSet<QualificationSchool> _qualificationSchools;
    
        public ObjectSet<QualificationUnrestrictedUser> QualificationUnrestrictedUsers
        {
            get { return _qualificationUnrestrictedUsers  ?? (_qualificationUnrestrictedUsers = CreateObjectSet<QualificationUnrestrictedUser>("QualificationUnrestrictedUsers")); }
        }
        private ObjectSet<QualificationUnrestrictedUser> _qualificationUnrestrictedUsers;
    
        public ObjectSet<SchoolAd> SchoolAds
        {
            get { return _schoolAds  ?? (_schoolAds = CreateObjectSet<SchoolAd>("SchoolAds")); }
        }
        private ObjectSet<SchoolAd> _schoolAds;
    
        public ObjectSet<SchoolContact> SchoolContacts
        {
            get { return _schoolContacts  ?? (_schoolContacts = CreateObjectSet<SchoolContact>("SchoolContacts")); }
        }
        private ObjectSet<SchoolContact> _schoolContacts;
    
        public ObjectSet<QualificationStudent> QualificationStudents
        {
            get { return _qualificationStudents  ?? (_qualificationStudents = CreateObjectSet<QualificationStudent>("QualificationStudents")); }
        }
        private ObjectSet<QualificationStudent> _qualificationStudents;
    
        public ObjectSet<StudentChangeClazzLog> StudentChangeClazzLogs
        {
            get { return _studentChangeClazzLogs  ?? (_studentChangeClazzLogs = CreateObjectSet<StudentChangeClazzLog>("StudentChangeClazzLogs")); }
        }
        private ObjectSet<StudentChangeClazzLog> _studentChangeClazzLogs;

        #endregion

    }
}
