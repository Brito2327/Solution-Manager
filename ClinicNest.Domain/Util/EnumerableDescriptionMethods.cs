using System;
using System.Globalization;
using System.Linq;

namespace ClinicNest.Domain.Util
{
    public static class EnumerableDescriptionMethods
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(EnumerableDescriptionAttribute), false)
                            .FirstOrDefault() as EnumerableDescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }

        public static string GetType<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(EnumerableDescriptionAttribute), false)
                            .FirstOrDefault() as EnumerableDescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Type;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }

        public static int? GetCode<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
                return e.ToInt32(CultureInfo.InvariantCulture);

            return null; // could also return a null
        }
    }
}
