using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.Entities.Criteria {
    public partial class SchoolAdCriteria {
    	
    	public int? page{ get; set; }
    	public int? pagesize{ get; set; }
    	public string sortname{ get; set; }
    	public string sortorder{ get; set; }
    	
    	public int? IdSrh { get; set;}
    	public int? IdFromSrh { get; set;}
    	public int? IdToSrh { get; set;}
    	public int? SchoolIdSrh { get; set;}
    	public int? SchoolIdFromSrh { get; set;}
    	public int? SchoolIdToSrh { get; set;}
    	public int? YearSrh { get; set;}
    	public int? YearFromSrh { get; set;}
    	public int? YearToSrh { get; set;}
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
    	public Nullable<int> TaiLiSrh { get; set;}
    	public Nullable<int> TaiLiFromSrh { get; set;}
    	public Nullable<int> TaiLiToSrh { get; set;}
    	public Nullable<int> GuaLiSrh { get; set;}
    	public Nullable<int> GuaLiFromSrh { get; set;}
    	public Nullable<int> GuaLiToSrh { get; set;}
    }
}
