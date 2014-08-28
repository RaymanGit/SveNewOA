//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Cn.Com.Sve.OA.Entities
{
    public partial class SalesTeamMember
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int SalesTeamId
        {
            get { return _salesTeamId; }
            set
            {
                if (_salesTeamId != value)
                {
                    if (SalesTeam != null && SalesTeam.Id != value)
                    {
                        SalesTeam = null;
                    }
                    _salesTeamId = value;
                }
            }
        }
        private int _salesTeamId;
    
        public virtual int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (User != null && User.Id != value)
                    {
                        User = null;
                    }
                    _userId = value;
                }
            }
        }
        private int _userId;
    
        public virtual bool IsLeader
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual SalesTeam SalesTeam
        {
            get { return _salesTeam; }
            set
            {
                if (!ReferenceEquals(_salesTeam, value))
                {
                    var previousValue = _salesTeam;
                    _salesTeam = value;
                    FixupSalesTeam(previousValue);
                }
            }
        }
        private SalesTeam _salesTeam;
    
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private User _user;

        #endregion

        #region Association Fixup
    
        private void FixupSalesTeam(SalesTeam previousValue)
        {
            if (previousValue != null && previousValue.Members.Contains(this))
            {
                previousValue.Members.Remove(this);
            }
    
            if (SalesTeam != null)
            {
                if (!SalesTeam.Members.Contains(this))
                {
                    SalesTeam.Members.Add(this);
                }
                if (SalesTeamId != SalesTeam.Id)
                {
                    SalesTeamId = SalesTeam.Id;
                }
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.SalesTeamMembers.Contains(this))
            {
                previousValue.SalesTeamMembers.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.SalesTeamMembers.Contains(this))
                {
                    User.SalesTeamMembers.Add(this);
                }
                if (UserId != User.Id)
                {
                    UserId = User.Id;
                }
            }
        }

        #endregion

    }
}
