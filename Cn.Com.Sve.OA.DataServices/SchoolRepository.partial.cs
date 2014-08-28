using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class SchoolRepository : ISchoolRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public SchoolRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(School entity) {
    		this.DbContext.Schools.AddObject(entity);
    	}
    
    	public void Update(School entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    			e.DistrictId = entity.DistrictId;
    			e.IsSold = entity.IsSold;
    			e.Type = entity.Type;
    			e.Levels = entity.Levels;
    			e.DevBy = entity.DevBy;
    			e.DevDate = entity.DevDate;
    			e.Important = entity.Important;
    			e.Equipments = entity.Equipments;
    			e.DaoJiShiPai = entity.DaoJiShiPai;
    			e.JiaoShiBiaoYu = entity.JiaoShiBiaoYu;
    			e.ShuShiBiaoYu = entity.ShuShiBiaoYu;
    			e.ShiTangBiaoYu = entity.ShiTangBiaoYu;
    			e.LouTiBiaoYu = entity.LouTiBiaoYu;
    			e.BuTiao = entity.BuTiao;
    			e.Address = entity.Address;
    			e.HighClassQty = entity.HighClassQty;
    			e.HighStudentQty = entity.HighStudentQty;
    			e.LowClassQty = entity.LowClassQty;
    			e.LowStudentQty = entity.LowStudentQty;
    			e.Remark = entity.Remark;
    			e.OldOaHuWaiId = entity.OldOaHuWaiId;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Schools.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(School entity) {
    		this.DbContext.Schools.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Schools.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<School> FindAll() {
    		return this.DbContext.Schools.Include("District");
    	}
    	public IEnumerable<School> FindAll2() {
    		return this.DbContext.Schools;
    	}
    
    	public School FindById(int id) {
    		return this.DbContext.Schools.Include("District").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<School> FindByName(string name){
    				return this.DbContext.Schools.Include("District").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<School> FindByDistrictId(Nullable<int> districtId){
    				return this.DbContext.Schools.Include("District").Where(o => o.DistrictId.Value.Equals(districtId.Value));
    			}
    	public IEnumerable<School> FindByIsSold(bool isSold){
    				return this.DbContext.Schools.Include("District").Where(o => o.IsSold.Equals(isSold));
    			}
    	public IEnumerable<School> FindByType(string type){
    				return this.DbContext.Schools.Include("District").Where(o => o.Type.Equals(type));
    			}
    	public IEnumerable<School> FindByLevels(string levels){
    				return this.DbContext.Schools.Include("District").Where(o => o.Levels.Equals(levels));
    			}
    	public IEnumerable<School> FindByDevBy(string devBy){
    				return this.DbContext.Schools.Include("District").Where(o => o.DevBy.Equals(devBy));
    			}
    	public IEnumerable<School> FindByDevDate(Nullable<System.DateTime> devDate){
    				return this.DbContext.Schools.Include("District").Where(o => o.DevDate.Value.Equals(devDate.Value));
    			}
    	public IEnumerable<School> FindByImportant(Nullable<bool> important){
    				return this.DbContext.Schools.Include("District").Where(o => o.Important.Value.Equals(important.Value));
    			}
    	public IEnumerable<School> FindByEquipments(string equipments){
    				return this.DbContext.Schools.Include("District").Where(o => o.Equipments.Equals(equipments));
    			}
    	public IEnumerable<School> FindByDaoJiShiPai(Nullable<int> daoJiShiPai){
    				return this.DbContext.Schools.Include("District").Where(o => o.DaoJiShiPai.Value.Equals(daoJiShiPai.Value));
    			}
    	public IEnumerable<School> FindByJiaoShiBiaoYu(Nullable<int> jiaoShiBiaoYu){
    				return this.DbContext.Schools.Include("District").Where(o => o.JiaoShiBiaoYu.Value.Equals(jiaoShiBiaoYu.Value));
    			}
    	public IEnumerable<School> FindByShuShiBiaoYu(Nullable<int> shuShiBiaoYu){
    				return this.DbContext.Schools.Include("District").Where(o => o.ShuShiBiaoYu.Value.Equals(shuShiBiaoYu.Value));
    			}
    	public IEnumerable<School> FindByShiTangBiaoYu(Nullable<int> shiTangBiaoYu){
    				return this.DbContext.Schools.Include("District").Where(o => o.ShiTangBiaoYu.Value.Equals(shiTangBiaoYu.Value));
    			}
    	public IEnumerable<School> FindByLouTiBiaoYu(Nullable<int> louTiBiaoYu){
    				return this.DbContext.Schools.Include("District").Where(o => o.LouTiBiaoYu.Value.Equals(louTiBiaoYu.Value));
    			}
    	public IEnumerable<School> FindByBuTiao(Nullable<int> buTiao){
    				return this.DbContext.Schools.Include("District").Where(o => o.BuTiao.Value.Equals(buTiao.Value));
    			}
    	public IEnumerable<School> FindByAddress(string address){
    				return this.DbContext.Schools.Include("District").Where(o => o.Address.Equals(address));
    			}
    	public IEnumerable<School> FindByHighClassQty(Nullable<int> highClassQty){
    				return this.DbContext.Schools.Include("District").Where(o => o.HighClassQty.Value.Equals(highClassQty.Value));
    			}
    	public IEnumerable<School> FindByHighStudentQty(Nullable<int> highStudentQty){
    				return this.DbContext.Schools.Include("District").Where(o => o.HighStudentQty.Value.Equals(highStudentQty.Value));
    			}
    	public IEnumerable<School> FindByLowClassQty(Nullable<int> lowClassQty){
    				return this.DbContext.Schools.Include("District").Where(o => o.LowClassQty.Value.Equals(lowClassQty.Value));
    			}
    	public IEnumerable<School> FindByLowStudentQty(Nullable<int> lowStudentQty){
    				return this.DbContext.Schools.Include("District").Where(o => o.LowStudentQty.Value.Equals(lowStudentQty.Value));
    			}
    	public IEnumerable<School> FindByRemark(string remark){
    				return this.DbContext.Schools.Include("District").Where(o => o.Remark.Equals(remark));
    			}
    	public IEnumerable<School> FindByOldOaHuWaiId(string oldOaHuWaiId){
    				return this.DbContext.Schools.Include("District").Where(o => o.OldOaHuWaiId.Equals(oldOaHuWaiId));
    			}
    	public IEnumerable<School> FindByCriteria(SchoolCriteria c) {
    		return this.DbContext.Schools.Include("District").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (!c.DistrictIdSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value.Equals(c.DistrictIdSrh.Value)))
    			&& (!c.DistrictIdFromSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value >= c.DistrictIdFromSrh.Value))
    			&& (!c.DistrictIdToSrh.HasValue || (o.DistrictId.HasValue 			&& o.DistrictId.Value <= c.DistrictIdToSrh.Value))
    			&& (!c.IsSoldSrh.HasValue || o.IsSold.Equals(c.IsSoldSrh.Value))
    			&& (String.IsNullOrEmpty(c.TypeSrh) || o.Type.Contains(c.TypeSrh))
    			&& (String.IsNullOrEmpty(c.LevelsSrh) || o.Levels.Contains(c.LevelsSrh))
    			&& (String.IsNullOrEmpty(c.DevBySrh) || o.DevBy.Contains(c.DevBySrh))
    			&& (!c.DevDateSrh.HasValue || (o.DevDate.HasValue 			&& o.DevDate.Value.Equals(c.DevDateSrh.Value)))
    			&& (!c.DevDateFromSrh.HasValue || (o.DevDate.HasValue 			&& o.DevDate.Value >= c.DevDateFromSrh.Value))
    			&& (!c.DevDateToSrh.HasValue || (o.DevDate.HasValue 			&& o.DevDate.Value <= c.DevDateToSrh.Value))
    			&& (!c.ImportantSrh.HasValue || (o.Important.HasValue 			&& o.Important.Value.Equals(c.ImportantSrh.Value)))
    			&& (String.IsNullOrEmpty(c.EquipmentsSrh) || o.Equipments.Contains(c.EquipmentsSrh))
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
    			&& (String.IsNullOrEmpty(c.AddressSrh) || o.Address.Contains(c.AddressSrh))
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
    			&& (String.IsNullOrEmpty(c.RemarkSrh) || o.Remark.Contains(c.RemarkSrh))
    			&& (String.IsNullOrEmpty(c.OldOaHuWaiIdSrh) || o.OldOaHuWaiId.Contains(c.OldOaHuWaiIdSrh))
    
    		);
    	}
    
    }
}
