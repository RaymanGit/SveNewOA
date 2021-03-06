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
    public partial class Module
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string Code
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Icon
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<Function> Functions
        {
            get
            {
                if (_functions == null)
                {
                    var newCollection = new FixupCollection<Function>();
                    newCollection.CollectionChanged += FixupFunctions;
                    _functions = newCollection;
                }
                return _functions;
            }
            set
            {
                if (!ReferenceEquals(_functions, value))
                {
                    var previousValue = _functions as FixupCollection<Function>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupFunctions;
                    }
                    _functions = value;
                    var newValue = value as FixupCollection<Function>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupFunctions;
                    }
                }
            }
        }
        private ICollection<Function> _functions;
    
        public virtual ICollection<UserGroupModulePermission> UserGroupModulePermissions
        {
            get
            {
                if (_userGroupModulePermissions == null)
                {
                    var newCollection = new FixupCollection<UserGroupModulePermission>();
                    newCollection.CollectionChanged += FixupUserGroupModulePermissions;
                    _userGroupModulePermissions = newCollection;
                }
                return _userGroupModulePermissions;
            }
            set
            {
                if (!ReferenceEquals(_userGroupModulePermissions, value))
                {
                    var previousValue = _userGroupModulePermissions as FixupCollection<UserGroupModulePermission>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUserGroupModulePermissions;
                    }
                    _userGroupModulePermissions = value;
                    var newValue = value as FixupCollection<UserGroupModulePermission>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUserGroupModulePermissions;
                    }
                }
            }
        }
        private ICollection<UserGroupModulePermission> _userGroupModulePermissions;

        #endregion

        #region Association Fixup
    
        private void FixupFunctions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Function item in e.NewItems)
                {
                    item.Module = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Function item in e.OldItems)
                {
                    if (ReferenceEquals(item.Module, this))
                    {
                        item.Module = null;
                    }
                }
            }
        }
    
        private void FixupUserGroupModulePermissions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserGroupModulePermission item in e.NewItems)
                {
                    item.Module = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserGroupModulePermission item in e.OldItems)
                {
                    if (ReferenceEquals(item.Module, this))
                    {
                        item.Module = null;
                    }
                }
            }
        }

        #endregion

    }
}
