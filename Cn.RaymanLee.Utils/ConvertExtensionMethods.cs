using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cn.RaymanLee.Utils {
	public static class ConvertExtensionMethods {
		public static int? ToNullableInt(this object obj) {
			return CommonConverter.ObjectToNullableInt(obj);
		}
		public static int ToInt(this object obj) {
			return CommonConverter.ObjectToInt(obj);
		}
		public static bool? ToNullableBoolean(this object obj) {
			return CommonConverter.ObjectToNullableBoolean(obj);
		}
		public static bool ToBoolean(this object obj) {
			return CommonConverter.ObjectToBoolean(obj);
		}
		public static decimal? ToNullableDecimal(this object obj) {
			return CommonConverter.ObjectToNullableDecimal(obj);
		}
		public static decimal ToDecimal(this object obj) {
			return CommonConverter.ObjectToDecimal(obj);
		}
		public static DateTime? ToNullableDateTime(this object obj) {
			return CommonConverter.ObjectToNullableDateTime(obj);
		}
		public static DateTime ToDateTime(this object obj) {
			return CommonConverter.ObjectToDateTime(obj);
		}
		public static String ToStr(this object obj) {
			return CommonConverter.ObjectToString(obj);
		}

		public static double ToDouble(this decimal value) {
			return Convert.ToDouble(value);
		}
	}
}