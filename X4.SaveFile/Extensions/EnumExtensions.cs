using System.ComponentModel;

namespace X4.SaveFile.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDescription<T>(this T value)
            where T : struct, Enum
        {
            var match = Attribute
                .GetCustomAttribute(typeof(T), typeof(DescriptionAttribute)) as DescriptionAttribute;
            return match?.Description ?? null;
        }
    }
}