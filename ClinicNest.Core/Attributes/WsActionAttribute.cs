using System;
using System.Linq;

namespace ClinicNest.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class WsActionAttribute : Attribute
    {
        public WsActionAttribute(string actionName, int numberOfDocumentsperRequisition)
        {
            ActionName = actionName;
            NumberOfDocumentsperRequisition = numberOfDocumentsperRequisition;
        }

        public WsActionAttribute(string actionName)
        {
            ActionName = actionName;
        }

        public string ActionName { get; }

        public int NumberOfDocumentsperRequisition { get; }

        public static string GetActionName(Type documentType)
        {
            return ((WsActionAttribute)documentType
                .GetCustomAttributes(typeof(WsActionAttribute), true)
                .FirstOrDefault())?.ActionName;
        }

        public static int GetNumberOfDocumentsperRequisition(Type documentType)
        {
            return ((WsActionAttribute)documentType
                .GetCustomAttributes(typeof(WsActionAttribute), true)
                .FirstOrDefault())?.NumberOfDocumentsperRequisition ?? 0;
        }
    }
}