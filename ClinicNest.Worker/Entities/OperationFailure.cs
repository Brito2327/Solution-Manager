namespace ClinicNest.Domain.Entities
{
    public class OperationFailure
    {
        /*
         * Client failures: 100 - 199
         * System failures: 200 - 299
         */
        public enum FailureType
        {
            Generic = 0,
            InvalidArgument = 100,
            InvalidOperation = 101,
            TargetResourceNotFound = 102,
            OperationNotImplemented = 103,
            DatabaseFailure = 200,
            UnexpectedFailure = 201,
            RequestFailure = 202,
            ServiceUnavailable = 203
        }

        public FailureType Type { get; }
        public int? Code { get; }
        public string Message { get; }
        public bool IsGenericFailure 
        { 
            get => Type == FailureType.Generic; 
        }
        public bool IsClientFailure 
        {
            get
            {
                int failureType = (int)Type;
                return failureType >= 100 && failureType <= 199;
            }
        }
        public bool IsSystemFailure 
        {
            get
            {
                int failureType = (int)Type;
                return failureType >= 200 && failureType <= 299;
            }
        }

        public OperationFailure(FailureType type, string message)
        {
            Type = type;
            Message = message;
        }

        public OperationFailure(FailureType type, string message, int code) : this(type, message)
        {
            Code = code;
        }
    }
}
