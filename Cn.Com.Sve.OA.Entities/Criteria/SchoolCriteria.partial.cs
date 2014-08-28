using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class SchoolCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public string NameSrh { get; set;}
    	public Nullable<int> DistrictIdSrh { get; set;}
    	public Nullable<int> DistrictIdFromSrh { get; set;}
    	public Nullable<int> DistrictIdToSrh { get; set;}
    	public bool? IsSoldSrh { get; set;}
    	public string TypeSrh { get; set;}
    	public string LevelsSrh { get; set;}
    	public string DevBySrh { get; set;}
    	public Nullable<System.DateTime> DevDateSrh { get; set;}
    	public Nullable<System.DateTime> DevDateFromSrh { get; set;}
    	public Nullable<System.DateTime> DevDateToSrh { get; set;}
    	public Nullable<bool> ImportantSrh { get; set;}
    	public string EquipmentsSrh { get; set;}
    	public Nullable<int> DaoJiShiPaiSrh { get; set;}
    	public Nullable<int> DaoJiShiPaiFromSrh { get; set;}
    	public Nullable<int> DaoJiShiPaiToSrh { get; set;}
    	public Nullable<int> JiaoShiBiaoYuSrh { get; set;}
    	public Nullable<int> JiaoShiBiaoYuFromSrh { get; set;}
    	public Nullable<int> JiaoShiBiaoYuToSrh { get; set;}
    	public Nullable<int> ShuShiBiaoYuSrh { get; set;}
    	public Nullable<int> ShuShiBiaoYuFromSrh { get; set;}
    	public Nullable<int> ShuShiBiaoYuToSrh { get; set;}
    	public Nullable<int> ShiTangBiaoYuSrh { get; set;}
    	public Nullable<int> ShiTangBiaoYuFromSrh { get; set;}
    	public Nullable<int> ShiTangBiaoYuToSrh { get; set;}
    	public Nullable<int> LouTiBiaoYuSrh { get; set;}
    	public Nullable<int> LouTiBiaoYuFromSrh { get; set;}
    	public Nullable<int> LouTiBiaoYuToSrh { get; set;}
    	public Nullable<int> BuTiaoSrh { get; set;}
    	public Nullable<int> BuTiaoFromSrh { get; set;}
    	public Nullable<int> BuTiaoToSrh { get; set;}
    	public string AddressSrh { get; set;}
    	public Nullable<int> HighClassQtySrh { get; set;}
    	public Nullable<int> HighClassQtyFromSrh { get; set;}
    	public Nullable<int> HighClassQtyToSrh { get; set;}
    	public Nullable<int> HighStudentQtySrh { get; set;}
    	public Nullable<int> HighStudentQtyFromSrh { get; set;}
    	public Nullable<int> HighStudentQtyToSrh { get; set;}
    	public Nullable<int> LowClassQtySrh { get; set;}
    	public Nullable<int> LowClassQtyFromSrh { get; set;}
    	public Nullable<int> LowClassQtyToSrh { get; set;}
    	public Nullable<int> LowStudentQtySrh { get; set;}
    	public Nullable<int> LowStudentQtyFromSrh { get; set;}
    	public Nullable<int> LowStudentQtyToSrh { get; set;}
    	public string RemarkSrh { get; set;}
    	public string OldOaHuWaiIdSrh { get; set;}
    }
}
