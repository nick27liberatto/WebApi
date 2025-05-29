namespace Domain.Extensions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attr = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                return attr?.Name ?? enumValue.ToString();
            }

            return enumValue.ToString(); // fallback seguro
        }
    }

}
