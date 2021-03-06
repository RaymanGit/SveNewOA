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
    public partial class ImportDupliate
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string ImportKey
        {
            get;
            set;
        }
    
        public virtual Nullable<int> CustomerId
        {
            get { return _customerId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_customerId != value)
                    {
                        if (Customer != null && Customer.Id != value)
                        {
                            Customer = null;
                        }
                        _customerId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _customerId;
    
        public virtual Nullable<int> ImportId
        {
            get { return _importId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_importId != value)
                    {
                        if (ImportCustomer != null && ImportCustomer.Id != value)
                        {
                            ImportCustomer = null;
                        }
                        _importId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _importId;
    
        public virtual string SchoolName
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Tel
        {
            get;
            set;
        }
    
        public virtual string Mobile
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Score
        {
            get;
            set;
        }
    
        public virtual string ErrorMsg
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                }
            }
        }
        private Customer _customer;
    
        public virtual ImportCustomer ImportCustomer
        {
            get { return _importCustomer; }
            set
            {
                if (!ReferenceEquals(_importCustomer, value))
                {
                    var previousValue = _importCustomer;
                    _importCustomer = value;
                    FixupImportCustomer(previousValue);
                }
            }
        }
        private ImportCustomer _importCustomer;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupCustomer(Customer previousValue)
        {
            if (previousValue != null && previousValue.ImportDupliates.Contains(this))
            {
                previousValue.ImportDupliates.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.ImportDupliates.Contains(this))
                {
                    Customer.ImportDupliates.Add(this);
                }
                if (CustomerId != Customer.Id)
                {
                    CustomerId = Customer.Id;
                }
            }
            else if (!_settingFK)
            {
                CustomerId = null;
            }
        }
    
        private void FixupImportCustomer(ImportCustomer previousValue)
        {
            if (previousValue != null && previousValue.ImportDupliates.Contains(this))
            {
                previousValue.ImportDupliates.Remove(this);
            }
    
            if (ImportCustomer != null)
            {
                if (!ImportCustomer.ImportDupliates.Contains(this))
                {
                    ImportCustomer.ImportDupliates.Add(this);
                }
                if (ImportId != ImportCustomer.Id)
                {
                    ImportId = ImportCustomer.Id;
                }
            }
            else if (!_settingFK)
            {
                ImportId = null;
            }
        }

        #endregion

    }
}
