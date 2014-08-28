using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class ModuleRepository : IModuleRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public ModuleRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Module entity) {
    		this.DbContext.Modules.AddObject(entity);
    	}
    
    	public void Update(Module entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Code = entity.Code;
    			e.Name = entity.Name;
    			e.Icon = entity.Icon;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Modules.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Module entity) {
    		this.DbContext.Modules.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Modules.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Module> FindAll() {
    		return this.DbContext.Modules;
    	}
    	public IEnumerable<Module> FindAll2() {
    		return this.DbContext.Modules;
    	}
    
    	public Module FindById(int id) {
    		return this.DbContext.Modules.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Module> FindByCode(string code){
    				return this.DbContext.Modules.Where(o => o.Code.Equals(code));
    			}
    	public IEnumerable<Module> FindByName(string name){
    				return this.DbContext.Modules.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Module> FindByIcon(string icon){
    				return this.DbContext.Modules.Where(o => o.Icon.Equals(icon));
    			}
    	public IEnumerable<Module> FindByCriteria(ModuleCriteria c) {
    		return this.DbContext.Modules.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.CodeSrh) || o.Code.Contains(c.CodeSrh))
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.IconSrh) || o.Icon.Contains(c.IconSrh))
    
    		);
    	}
    
    }
}
