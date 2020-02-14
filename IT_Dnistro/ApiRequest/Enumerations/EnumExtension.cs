using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ApiRequest.Enumerations
{
    public static class EnumExtension
    {
        public static string GetDisplayText(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>().Name;
        }
    }
}