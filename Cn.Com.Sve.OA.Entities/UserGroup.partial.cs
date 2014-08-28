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
    public partial class UserGroup
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<UserGroupFunctionPermission> FunctionPermissions
        {
            get
            {
                if (_functionPermissions == null)
                {
                    var newCollection = new FixupCollection<UserGroupFunctionPermission>();
                    newCollection.CollectionChanged += FixupFunctionPermissions;
                    _functionPermissions = newCollection;
                }
                return _functionPermissions;
            }
            set
            {
                if (!ReferenceEquals(_functionPermissions, value))
                {
                    var previousValue = _functionPermissions as FixupCollection<UserGroupFunctionPermission>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupFunctionPermissions;
                    }
                    _functionPermissions = value;
                    var newValue = value as FixupCollection<UserGroupFunctionPermission>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupFunctionPermissions;
                    }
                }
            }
        }
        private ICollection<UserGroupFunctionPermission> _functionPermissions;
    
        public virtual ICollection<UserGroupModulePermission> ModulePermissions
        {
            get
            {
                if (_modulePermissions == null)
                {
                    var newCollection = new FixupCollection<UserGroupModulePermission>();
                    newCollection.CollectionChanged += FixupModulePermissions;
                    _modulePermissions = newCollection;
                }
                return _modulePermissions;
            }
            set
            {
                if (!ReferenceEquals(_modulePermissions, value))
                {
                    var previousValue = _modulePermissions as FixupCollection<UserGroupModulePermission>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupModulePermissions;
                    }
                    _modulePermissions = value;
                    var newValue = value as FixupCollection<UserGroupModulePermission>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupModulePermissions;
                    }
                }
            }
        }
        private ICollection<UserGroupModulePermission> _modulePermissions;
    
        public virtual ICollection<UserInGroup> Users
        {
            get
            {
                if (_users == null)
                {
                    var newCollection = new FixupCollection<UserInGroup>();
                    newCollection.CollectionChanged += FixupUsers;
                    _users = newCollection;
                }
                return _users;
            }
            set
            {
                if (!ReferenceEquals(_users, value))
                {
                    var previousValue = _users as FixupCollection<UserInGroup>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUsers;
                    }
                    _users = value;
                    var newValue = value as FixupCollection<UserInGroup>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUsers;
                    }
                }
            }
        }
        private ICollection<UserInGroup> _users;

        #endregion

        #region Association Fixup
    
        private void FixupFunctionPermissions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserGroupFunctionPermission item in e.NewItems)
                {
                    item.UserGroup = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserGroupFunctionPermission item in e.OldItems)
                {
                    if (ReferenceEquals(item.UserGroup, this))
                    {
                        item.UserGroup = null;
                    }
                }
            }
        }
    
        private void FixupModulePermissions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserGroupModulePermission item in e.NewItems)
                {
                    item.UserGroup = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserGroupModulePermission item in e.OldItems)
                {
                    if (ReferenceEquals(item.UserGroup, this))
                    {
                        item.UserGroup = null;
                    }
                }
            }
        }
    
        private void FixupUsers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserInGroup item in e.NewItems)
                {
                    item.UserGroup = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserInGroup item in e.OldItems)
                {
                    if (ReferenceEquals(item.UserGroup, this))
                    {
                        item.UserGroup = null;
                    }
                }
            }
        }

        #endregion

    }
}
