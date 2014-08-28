using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Patterns {
	/// <summary>
	/// Repository 模式的基础接口
	/// </summary>
	/// <typeparam name="TEntity">实体对象类型</typeparam>
	/// <remarks>
	/// 封装数据服务的基础操作规范。
	/// </remarks>
	public interface IRepository<TEntity, TKey> where TEntity : class {
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		void DeleteById(TKey id);
		IEnumerable<TEntity> FindAll();
		IEnumerable<TEntity> FindAll2();
		TEntity FindById(TKey id);
	}
}
