using System;
using System.Linq;

namespace ClinicNest.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class JobNameAttribute : Attribute
    {
        public JobNameAttribute(string jobName)
        {
            JobName = jobName;
        }

        public string JobName { get; }

        public static string GetJobName(Type documentType)
        {
            return ((JobNameAttribute)documentType
                .GetCustomAttributes(typeof(JobNameAttribute), true)
                .FirstOrDefault())?.JobName;
        }
    }
}