using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Utils {
	public static class CommonConverter {
		public static int? ObjectToNullableInt(object obj) {
			int result;
			if (obj != null && !obj.Equals(DBNull.Value) && Int32.TryParse(obj.ToString(), out result)) {
				return result;
			} else {
				return null;
			}
		}
		public static int ObjectToInt(object obj) {
			return ObjectToNullableInt(obj).GetValueOrDefault();
		}
		public static bool? ObjectToNullableBoolean(object obj) {
			bool result;
			if (obj != null && !obj.Equals(DBNull.Value) && Boolean.TryParse(obj.ToString(), out result)) {
				return result;
			} else {
				return null;
			}
		}
		public static bool ObjectToBoolean(object obj) {
			return ObjectToNullableBoolean(obj).GetValueOrDefault();
		}
		public static decimal? ObjectToNullableDecimal(object obj) {
			decimal result;
			if (obj != null && !obj.Equals(DBNull.Value) && Decimal.TryParse(obj.ToString(), out result)) {
				return result;
			} else {
				return null;
			}
		}
		public static decimal ObjectToDecimal(object obj) {
			return ObjectToNullableDecimal(obj).GetValueOrDefault();
		}
		public static DateTime? ObjectToNullableDateTime(object obj) {
			DateTime result;
			if (obj != null && !obj.Equals(DBNull.Value) && DateTime.TryParse(obj.ToString(), out result)) {
				return result;
			} else {
				return null;
			}
		}
		public static DateTime ObjectToDateTime(object obj) {
			return ObjectToNullableDateTime(obj).GetValueOrDefault();
		}
		public static String ObjectToString(object obj) {
			if (obj != null && !obj.Equals(DBNull.Value)) {
				return obj.ToString();
			} else {
				return null;
			}
		}

		#region 转换函数

		///// <summary>
		///// object 转换为 decimal
		///// </summary>
		///// <param name="obj"></param>
		///// <returns></returns>
		//public static decimal ObjToDecimal(object obj) {
		//    if(obj == null)
		//        return 0;
		//    if(obj.Equals(DBNull.Value))
		//        return 0;

		//    try {
		//        return Convert.ToDecimal(obj);
		//    } catch {
		//        return 0;
		//    }
		//}

		///// <summary>
		///// 转换为日期
		///// </summary>
		///// <param name="obj"></param>
		///// <returns></returns>
		//public static DateTime? ObjToDateNull(object obj) {
		//    if(obj == null) {
		//        return null;
		//    }
		//    try {
		//        return Convert.ToDateTime(obj);
		//    } catch {
		//        return null;
		//    }
		//}
		#endregion
	}
}