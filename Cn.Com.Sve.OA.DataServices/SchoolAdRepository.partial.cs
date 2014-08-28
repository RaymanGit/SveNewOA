using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SchoolAdRepository : ISchoolAdRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SchoolAdRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(SchoolAd entity) {
    		this.DbContext.SchoolAds.AddObject(entity);
    	}
    
    	public void Update(SchoolAd entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.SchoolId = entity.SchoolId;
    			e.Year = entity.Year;
    			e.HighClassQty = entity.HighClassQty;
    			e.HighStudentQty = entity.HighStudentQty;
    			e.LowClassQty = entity.LowClassQty;
    			e.LowStudentQty = entity.LowStudentQty;
    			e.DaoJiShiPai = entity.DaoJiShiPai;
    			e.JiaoShiBiaoYu = entity.JiaoShiBiaoYu;
    			e.ShuShiBiaoYu = entity.ShuShiBiaoYu;
    			e.ShiTangBiaoYu = entity.ShiTangBiaoYu;
    			e.LouTiBiaoYu = entity.LouTiBiaoYu;
    			e.BuTiao = entity.BuTiao;
    			e.TaiLi = entity.TaiLi;
    			e.GuaLi = entity.GuaLi;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.SchoolAds.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(SchoolAd entity) {
    		this.DbContext.SchoolAds.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.SchoolAds.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<SchoolAd> FindAll() {
    		return this.DbContext.SchoolAds.Include("School");
    	}
    	public IEnumerable<SchoolAd> FindAll2() {
    		return this.DbContext.SchoolAds;
    	}
    
    	public SchoolAd FindById(int id) {
    		return this.DbContext.SchoolAds.Include("School").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<SchoolAd> FindBySchoolId(int schoolId){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.SchoolId.Equals(schoolId));
    			}
    	public IEnumerable<SchoolAd> FindByYear(int year){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.Year.Equals(year));
    			}
    	public IEnumerable<SchoolAd> FindByHighClassQty(Nullable<int> highClassQty){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.HighClassQty.Value.Equals(highClassQty.Value));
    			}
    	public IEnumerable<SchoolAd> FindByHighStudentQty(Nullable<int> highStudentQty){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.HighStudentQty.Value.Equals(highStudentQty.Value));
    			}
    	public IEnumerable<SchoolAd> FindByLowClassQty(Nullable<int> lowClassQty){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.LowClassQty.Value.Equals(lowClassQty.Value));
    			}
    	public IEnumerable<SchoolAd> FindByLowStudentQty(Nullable<int> lowStudentQty){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.LowStudentQty.Value.Equals(lowStudentQty.Value));
    			}
    	public IEnumerable<SchoolAd> FindByDaoJiShiPai(Nullable<int> daoJiShiPai){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.DaoJiShiPai.Value.Equals(daoJiShiPai.Value));
    			}
    	public IEnumerable<SchoolAd> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.JiaoShiBiaoYu.Value.Equals(jiaoShiBiaoYu.Value));
    			}
    	public IEnumerable<SchoolAd> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.ShuShiBiaoYu.Value.Equals(shuShiBiaoYu.Value));
    			}
    	public IEnumerable<SchoolAd> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.ShiTangBiaoYu.Value.Equals(shiTangBiaoYu.Value));
    			}
    	public IEnumerable<SchoolAd> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.LouTiBiaoYu.Value.Equals(louTiBiaoYu.Value));
    			}
    	public IEnumerable<SchoolAd> FindByBuTiao(Nullable<int> buTiao){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.BuTiao.Value.Equals(buTiao.Value));
    			}
    	public IEnumerable<SchoolAd> FindByTaiLi(Nullable<int> taiLi){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.TaiLi.Value.Equals(taiLi.Value));
    			}
    	public IEnumerable<SchoolAd> FindByGuaLi(Nullable<int> guaLi){
    				return this.DbContext.SchoolAds.Include("School").Where(o => o.GuaLi.Value.Equals(guaLi.Value));
    			}
    	public IEnumerable<SchoolAd> FindByCriteria(SchoolAdCriteria c) {
    		return this.DbContext.SchoolAds.Include("School").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.SchoolIdSrh.HasValue || o.SchoolId.Equals(c.SchoolIdSrh.Value))
    			&& (!c.SchoolIdFromSrh.HasValue || o.SchoolId >= c.SchoolIdFromSrh.Value)
    			&& (!c.SchoolIdToSrh.HasValue || o.SchoolId <= c.SchoolIdToSrh.Value)
    			&& (!c.YearSrh.HasValue || o.Year.Equals(c.YearSrh.Value))
    			&& (!c.YearFromSrh.HasValue || o.Year >= c.YearFromSrh.Value)
    			&& (!c.YearToSrh.HasValue || o.Year <= c.YearToSrh.Value)
    			&& (!c.HighClassQtySrh.HasValue || (o.HighClassQty.HasValue 			&& o.HighClassQty.Value.Equals(c.HighClassQtySrh.Value)))
    			&& (!c.HighClassQtyFromSrh.HasValue || (o.HighClassQty.HasValue 			&& o.HighClassQty.Value >= c.HighClassQtyFromSrh.Value))
    			&& (!c.HighClassQtyToSrh.HasValue || (o.HighClassQty.HasValue 			&& o.HighClassQty.Value <= c.HighClassQtyToSrh.Value))
    			&& (!c.HighStudentQtySrh.HasValue || (o.HighStudentQty.HasValue 			&& o.HighStudentQty.Value.Equals(c.HighStudentQtySrh.Value)))
    			&& (!c.HighStudentQtyFromSrh.HasValue || (o.HighStudentQty.HasValue 			&& o.HighStudentQty.Value >= c.HighStudentQtyFromSrh.Value))
    			&& (!c.HighStudentQtyToSrh.HasValue || (o.HighStudentQty.HasValue 			&& o.HighStudentQty.Value <= c.HighStudentQtyToSrh.Value))
    			&& (!c.LowClassQtySrh.HasValue || (o.LowClassQty.HasValue 			&& o.LowClassQty.Value.Equals(c.LowClassQtySrh.Value)))
    			&& (!c.LowClassQtyFromSrh.HasValue || (o.LowClassQty.HasValue 			&& o.LowClassQty.Value >= c.LowClassQtyFromSrh.Value))
    			&& (!c.LowClassQtyToSrh.HasValue || (o.LowClassQty.HasValue 			&& o.LowClassQty.Value <= c.LowClassQtyToSrh.Value))
    			&& (!c.LowStudentQtySrh.HasValue || (o.LowStudentQty.HasValue 			&& o.LowStudentQty.Value.Equals(c.LowStudentQtySrh.Value)))
    			&& (!c.LowStudentQtyFromSrh.HasValue || (o.LowStudentQty.HasValue 			&& o.LowStudentQty.Value >= c.LowStudentQtyFromSrh.Value))
    			&& (!c.LowStudentQtyToSrh.HasValue || (o.LowStudentQty.HasValue 			&& o.LowStudentQty.Value <= c.LowStudentQtyToSrh.Value))
    			&& (!c.DaoJiShiPaiSrh.HasValue || (o.DaoJiShiPai.HasValue 			&& o.DaoJiShiPai.Value.Equals(c.DaoJiShiPaiSrh.Value)))
    			&& (!c.DaoJiShiPaiFromSrh.HasValue || (o.DaoJiShiPai.HasValue 			&& o.DaoJiShiPai.Value >= c.DaoJiShiPaiFromSrh.Value))
    			&& (!c.DaoJiShiPaiToSrh.HasValue || (o.DaoJiShiPai.HasValue 			&& o.DaoJiShiPai.Value <= c.DaoJiShiPaiToSrh.Value))
    			&& (!c.JiaoShiBiaoYuSrh.HasValue || (o.JiaoShiBiaoYu.HasValue 			&& o.JiaoShiBiaoYu.Value.Equals(c.JiaoShiBiaoYuSrh.Value)))
    			&& (!c.JiaoShiBiaoYuFromSrh.HasValue || (o.JiaoShiBiaoYu.HasValue 			&& o.JiaoShiBiaoYu.Value >= c.JiaoShiBiaoYuFromSrh.Value))
    			&& (!c.JiaoShiBiaoYuToSrh.HasValue || (o.JiaoShiBiaoYu.HasValue 			&& o.JiaoShiBiaoYu.Value <= c.JiaoShiBiaoYuToSrh.Value))
    			&& (!c.ShuShiBiaoYuSrh.HasValue || (o.ShuShiBiaoYu.HasValue 			&& o.ShuShiBiaoYu.Value.Equals(c.ShuShiBiaoYuSrh.Value)))
    			&& (!c.ShuShiBiaoYuFromSrh.HasValue || (o.ShuShiBiaoYu.HasValue 			&& o.ShuShiBiaoYu.Value >= c.ShuShiBiaoYuFromSrh.Value))
    			&& (!c.ShuShiBiaoYuToSrh.HasValue || (o.ShuShiBiaoYu.HasValue 			&& o.ShuShiBiaoYu.Value <= c.ShuShiBiaoYuToSrh.Value))
    			&& (!c.ShiTangBiaoYuSrh.HasValue || (o.ShiTangBiaoYu.HasValue 			&& o.ShiTangBiaoYu.Value.Equals(c.ShiTangBiaoYuSrh.Value)))
    			&& (!c.ShiTangBiaoYuFromSrh.HasValue || (o.ShiTangBiaoYu.HasValue 			&& o.ShiTangBiaoYu.Value >= c.ShiTangBiaoYuFromSrh.Value))
    			&& (!c.ShiTangBiaoYuToSrh.HasValue || (o.ShiTangBiaoYu.HasValue 			&& o.ShiTangBiaoYu.Value <= c.ShiTangBiaoYuToSrh.Value))
    			&& (!c.LouTiBiaoYuSrh.HasValue || (o.LouTiBiaoYu.HasValue 			&& o.LouTiBiaoYu.Value.Equals(c.LouTiBiaoYuSrh.Value)))
    			&& (!c.LouTiBiaoYuFromSrh.HasValue || (o.LouTiBiaoYu.HasValue 			&& o.LouTiBiaoYu.Value >= c.LouTiBiaoYuFromSrh.Value))
    			&& (!c.LouTiBiaoYuToSrh.HasValue || (o.LouTiBiaoYu.HasValue 			&& o.LouTiBiaoYu.Value <= c.LouTiBiaoYuToSrh.Value))
    			&& (!c.BuTiaoSrh.HasValue || (o.BuTiao.HasValue 			&& o.BuTiao.Value.Equals(c.BuTiaoSrh.Value)))
    			&& (!c.BuTiaoFromSrh.HasValue || (o.BuTiao.HasValue 			&& o.BuTiao.Value >= c.BuTiaoFromSrh.Value))
    			&& (!c.BuTiaoToSrh.HasValue || (o.BuTiao.HasValue 			&& o.BuTiao.Value <= c.BuTiaoToSrh.Value))
    			&& (!c.TaiLiSrh.HasValue || (o.TaiLi.HasValue 			&& o.TaiLi.Value.Equals(c.TaiLiSrh.Value)))
    			&& (!c.TaiLiFromSrh.HasValue || (o.TaiLi.HasValue 			&& o.TaiLi.Value >= c.TaiLiFromSrh.Value))
    			&& (!c.TaiLiToSrh.HasValue || (o.TaiLi.HasValue 			&& o.TaiLi.Value <= c.TaiLiToSrh.Value))
    			&& (!c.GuaLiSrh.HasValue || (o.GuaLi.HasValue 			&& o.GuaLi.Value.Equals(c.GuaLiSrh.Value)))
    			&& (!c.GuaLiFromSrh.HasValue || (o.GuaLi.HasValue 			&& o.GuaLi.Value >= c.GuaLiFromSrh.Value))
    			&& (!c.GuaLiToSrh.HasValue || (o.GuaLi.HasValue 			&& o.GuaLi.Value <= c.GuaLiToSrh.Value))
    
    		);
    	}
    
    }
}
