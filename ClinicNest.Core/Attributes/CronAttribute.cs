using System;
using System.Linq;

namespace ClinicNest.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class CronAttribute : Attribute
    {
        public CronAttribute(string cronExpression)
        {
            CronExpression = cronExpression;
        }

        public string CronExpression { get; }

        public static string GetCronExpression(Type documentType)
        {
            return ((CronAttribute)documentType
                .GetCustomAttributes(typeof(CronAttribute), true)
                .FirstOrDefault())?.CronExpression;
        }
    }
}