using System;
using System.Linq;

namespace ClinicNest.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class QueueAttribute : Attribute
    {
        internal const int DefaultConcurrentMessageLimit = 1;

        public QueueAttribute(string queue, int concurrentMessageLimit = DefaultConcurrentMessageLimit)
        {
            Queue = queue;
            ConcurrentMessageLimit = concurrentMessageLimit;
        }

        public string Queue { get; }
        public int ConcurrentMessageLimit { get; }

        public static string GetQueueName(Type documentType)
        {
            return ((QueueAttribute)documentType
                .GetCustomAttributes(typeof(QueueAttribute), true)
                .FirstOrDefault())?.Queue;
        }

        public static int GetConcurrentMessageLimit(Type documentType)
        {
            return ((QueueAttribute)documentType
                .GetCustomAttributes(typeof(QueueAttribute), true)
                .FirstOrDefault())?.ConcurrentMessageLimit ?? DefaultConcurrentMessageLimit;
        }
    }
}