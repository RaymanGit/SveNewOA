using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IEmploymentCompanyRepository {
		IEnumerable<EmploymentCompany> Search(EmploymentCompanyCriteria c);
	}

	public partial class EmploymentCompanyRepository : IEmploymentCompanyRepository {
		public IEnumerable<EmploymentCompany> Search(EmploymentCompanyCriteria c) {
			return this.DbContext.EmploymentCompanies.Include("City").Include("User").Where(o =>
				(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
				&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
				&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
				&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
				&& (String.IsNullOrEmpty(c.TypeSrh) || o.Type.Contains(c.TypeSrh))
				&& (String.IsNullOrEmpty(c.ImportantSrh) || o.Important.Contains(c.ImportantSrh))
				&& (String.IsNullOrEmpty(c.WebsiteSrh) || o.Website.Contains(c.WebsiteSrh))
				&& (String.IsNullOrEmpty(c.TelephoneSrh) || o.Telephone.Contains(c.TelephoneSrh))
				&& (String.IsNullOrEmpty(c.FaxSrh) || o.Fax.Contains(c.FaxSrh))
				&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
				&& (!c.CityIdSrh.HasValue || (o.CityId.HasValue && o.CityId.Value.Equals(c.CityIdSrh.Value)))
				&& (!c.CityIdFromSrh.HasValue || (o.CityId.HasValue && o.CityId.Value >= c.CityIdFromSrh.Value))
				&& (!c.CityIdToSrh.HasValue || (o.CityId.HasValue && o.CityId.Value <= c.CityIdToSrh.Value))
				&& (String.IsNullOrEmpty(c.IntroductionSrh) || o.Introduction.Contains(c.IntroductionSrh))
				&& (String.IsNullOrEmpty(c.SourceTypeSrh) || o.SourceType.Contains(c.SourceTypeSrh))
				&& (String.IsNullOrEmpty(c.RefererSrh) || o.Referer.Contains(c.RefererSrh))
				&& (!c.UserIdSrh.HasValue || (o.UserId.HasValue && o.UserId.Value.Equals(c.UserIdSrh.Value)))
				&& (!c.UserIdFromSrh.HasValue || (o.UserId.HasValue && o.UserId.Value >= c.UserIdFromSrh.Value))
				&& (!c.UserIdToSrh.HasValue || (o.UserId.HasValue && o.UserId.Value <= c.UserIdToSrh.Value))
				&& (!c.EmployedQtySrh.HasValue || o.EmployedQty.Equals(c.EmployedQtySrh.Value))
				&& (!c.EmployedQtyFromSrh.HasValue || o.EmployedQty >= c.EmployedQtyFromSrh.Value)
				&& (!c.EmployedQtyToSrh.HasValue || o.EmployedQty <= c.EmployedQtyToSrh.Value)
				&& (String.IsNullOrEmpty(c.OldOaIdSrh) || o.OldOaId.Contains(c.OldOaIdSrh))
				&& (String.IsNullOrEmpty(c.TempProvIdSrh) || o.TempProvId.Contains(c.TempProvIdSrh))
				&& (String.IsNullOrEmpty(c.TempProvNameSrh) || o.TempProvName.Contains(c.TempProvNameSrh))
				&& (String.IsNullOrEmpty(c.TempCityIdSrh) || o.TempCityId.Contains(c.TempCityIdSrh))
				&& (String.IsNullOrEmpty(c.TempCityNameSrh) || o.TempCityName.Contains(c.TempCityNameSrh))
				&& (String.IsNullOrEmpty(c.UserName) || (o.User != null && o.User.Name.Contains(c.UserName)))
				&& (String.IsNullOrEmpty(c.Zone) || (o.City != null && (o.City.Name.Contains(c.Zone) || o.City.Province.Name.Contains(c.Zone))))

			);
		}

	}
}
