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
    public partial class City
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
    
        public virtual int ProvinceId
        {
            get { return _provinceId; }
            set
            {
                if (_provinceId != value)
                {
                    if (Province != null && Province.Id != value)
                    {
                        Province = null;
                    }
                    _provinceId = value;
                }
            }
        }
        private int _provinceId;

        #endregion

        #region Navigation Properties
    
        public virtual Province Province
        {
            get { return _province; }
            set
            {
                if (!ReferenceEquals(_province, value))
                {
                    var previousValue = _province;
                    _province = value;
                    FixupProvince(previousValue);
                }
            }
        }
        private Province _province;
    
        public virtual ICollection<District> Districts
        {
            get
            {
                if (_districts == null)
                {
                    var newCollection = new FixupCollection<District>();
                    newCollection.CollectionChanged += FixupDistricts;
                    _districts = newCollection;
                }
                return _districts;
            }
            set
            {
                if (!ReferenceEquals(_districts, value))
                {
                    var previousValue = _districts as FixupCollection<District>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupDistricts;
                    }
                    _districts = value;
                    var newValue = value as FixupCollection<District>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupDistricts;
                    }
                }
            }
        }
        private ICollection<District> _districts;
    
        public virtual ICollection<EmploymentCompany> Employment_Company
        {
            get
            {
                if (_employment_Company == null)
                {
                    var newCollection = new FixupCollection<EmploymentCompany>();
                    newCollection.CollectionChanged += FixupEmployment_Company;
                    _employment_Company = newCollection;
                }
                return _employment_Company;
            }
            set
            {
                if (!ReferenceEquals(_employment_Company, value))
                {
                    var previousValue = _employment_Company as FixupCollection<EmploymentCompany>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupEmployment_Company;
                    }
                    _employment_Company = value;
                    var newValue = value as FixupCollection<EmploymentCompany>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupEmployment_Company;
                    }
                }
            }
        }
        private ICollection<EmploymentCompany> _employment_Company;

        #endregion

        #region Association Fixup
    
        private void FixupProvince(Province previousValue)
        {
            if (previousValue != null && previousValue.Cities.Contains(this))
            {
                previousValue.Cities.Remove(this);
            }
    
            if (Province != null)
            {
                if (!Province.Cities.Contains(this))
                {
                    Province.Cities.Add(this);
                }
                if (ProvinceId != Province.Id)
                {
                    ProvinceId = Province.Id;
                }
            }
        }
    
        private void FixupDistricts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (District item in e.NewItems)
                {
                    item.City = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (District item in e.OldItems)
                {
                    if (ReferenceEquals(item.City, this))
                    {
                        item.City = null;
                    }
                }
            }
        }
    
        private void FixupEmployment_Company(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EmploymentCompany item in e.NewItems)
                {
                    item.City = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (EmploymentCompany item in e.OldItems)
                {
                    if (ReferenceEquals(item.City, this))
                    {
                        item.City = null;
                    }
                }
            }
        }

        #endregion

    }
}
