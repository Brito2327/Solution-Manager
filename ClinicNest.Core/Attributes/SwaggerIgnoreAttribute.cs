using System;

namespace ClinicNest.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}