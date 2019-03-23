using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.ApplicationLib.Extensions
{
    public static class EnumExentsions
    {
        public static string Name(this Enum en)
        {
            return Enum.GetName(en.GetType(), en);
        }

        public static int ToInt(this Enum en)
        {
            return Convert.ToInt32(en);
        }

        public static List<EnumList> ToList(this Type enumType)
        {
            if (enumType.IsEnum)
            {
                var values = (from Enum e in Enum.GetValues(enumType)
                              select new EnumList { Key = e.ToInt(), Value = e.ToString() }).ToList();
                return values;
            }
            return null;
        }
    }

    public struct EnumList
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
