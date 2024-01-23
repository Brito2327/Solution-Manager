using System;

namespace ClinicNest.Domain.Util
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EnumerableDescriptionAttribute : Attribute
    {
        public virtual string Description { get; }
        public virtual string Type { get; }

        public EnumerableDescriptionAttribute(string description, string type)
        {
            Description = description;
            Type = type;
        }

        public EnumerableDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
