using System;
using System.Linq;

namespace ClinicNest.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class CollectionAttribute : Attribute
    {
        public CollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }

        public static string GetCollectionName(Type documentType)
        {
            return ((CollectionAttribute)documentType
                .GetCustomAttributes(typeof(CollectionAttribute), true)
                .FirstOrDefault())?.CollectionName ?? string.Empty;
        }
    }
}