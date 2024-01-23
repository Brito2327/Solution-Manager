using ClinicNest.Domain.Util;

namespace ClinicNest.Domain.Entities
{
    public class OperationResult
    {
        #region Campos e Propriedades

        public bool IsSuccess { get; }
        public List<OperationFailure> Failures { get; }
        public Exception Exception { get; }
        public bool HasFailures
        {
            get => Failures?.Any() ?? false;
        }
        public bool HasGenericFailures
        {
            get => Failures?.Any(failure => failure.IsGenericFailure) ?? false;
        }
        public bool HasClientFailures
        {
            get => Failures?.Any(failure => failure.IsClientFailure) ?? false;
        }
        public bool HasSystemFailures
        {
            get => Failures?.Any(failure => failure.IsSystemFailure) ?? false;
        }
        public bool HasException { get => Exception != null; }

        #endregion

        #region Métodos de instância

        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public OperationResult(List<OperationFailure> failures) : this(isSuccess: false)
        {
            Failures = failures;
        }

        public OperationResult(Exception exception) : this(isSuccess: false)
        {
            Exception = exception;
        }

        public bool ContainsAnyFailure(params OperationFailure.FailureType[] types)
        {
            if (types == null || types.Length == 0)
                throw new ArgumentNullException(nameof(types), $"O parâmetro {nameof(types)} não pode ser nulo ou vazio.");

            return HasFailures ? Failures.Any(failure => types.Contains(failure.Type)) : false;
        }

        public List<OperationFailure> GetGenericFailures()
        {
            return Failures?.Where(failure => failure.IsGenericFailure).ToList() ?? new List<OperationFailure>();
        }

        public List<OperationFailure> GetClientFailures()
        {
            return Failures?.Where(failure => failure.IsClientFailure).ToList() ?? new List<OperationFailure>();
        }

        public List<OperationFailure> GetSystemFailures()
        {
            return Failures?.Where(failure => failure.IsSystemFailure).ToList() ?? new List<OperationFailure>();
        }

        public OperationFailure GetFirstFailure() => Failures?.FirstOrDefault();

        public OperationFailure GetFirstFailure(OperationFailure.FailureType type) => Failures?.FirstOrDefault(failure => failure.Type == type);

        public OperationFailure GetFirstGenericFailure() => Failures?.FirstOrDefault(failure => failure.IsGenericFailure);

        public OperationFailure GetFirstClientFailure() => Failures?.FirstOrDefault(failure => failure.IsClientFailure);

        public OperationFailure GetFirstSystemFailure() => Failures?.FirstOrDefault(failure => failure.IsSystemFailure);

        #endregion

        #region Métodos estáticos

        public static OperationResult Success() => new OperationResult(isSuccess: true);

        public static OperationResult Failure() => new OperationResult(isSuccess: false);

        public static OperationResult Failure(OperationFailure.FailureType type, string message, int? code = null)
        {
            OperationFailure operationFailure = code != null ? new OperationFailure(type, message, code.Value) : new OperationFailure(type, message);

            var failures = new List<OperationFailure> { operationFailure };

            return new OperationResult(failures);
        }

        public static OperationResult Failure(string message, int? code = null) => Failure(OperationFailure.FailureType.Generic, message, code);

        public static OperationResult ExceptionResult(Exception exception) => new OperationResult(exception);

        public static OperationResult InvalidArgument(string message) => Failure(OperationFailure.FailureType.InvalidArgument, message);

        public static OperationResult InvalidOperation(string message, int? code = null) => Failure(OperationFailure.FailureType.InvalidOperation, message, code);

        public static OperationResult InvalidOperation(Enum e)
        {
            string message = EnumerableDescriptionMethods.GetDescription(e);
            int code = EnumerableDescriptionMethods.GetCode(e).GetValueOrDefault();

            return Failure(OperationFailure.FailureType.InvalidOperation, message, code);
        }

        public static OperationResult TargetResourceNotFound(string message) => Failure(OperationFailure.FailureType.TargetResourceNotFound, message);

        public static OperationResult DatabaseFailure(string message, int? code = null) => Failure(OperationFailure.FailureType.DatabaseFailure, message, code);

        public static OperationResult DatabaseFailure(Enum e) => Failure(OperationFailure.FailureType.DatabaseFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult OperationNotImplemented(string message) => Failure(OperationFailure.FailureType.OperationNotImplemented, message);

        public static OperationResult UnexpectedFailure(string message) => Failure(OperationFailure.FailureType.UnexpectedFailure, message);

        public static OperationResult UnexpectedFailure(Enum e) => Failure(OperationFailure.FailureType.UnexpectedFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult RequestFailure(string message, int? code = null) => Failure(OperationFailure.FailureType.RequestFailure, message, code);

        public static OperationResult RequestFailure(Enum e) => Failure(OperationFailure.FailureType.RequestFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult ServiceUnavailable(string message) => Failure(OperationFailure.FailureType.ServiceUnavailable, message);

        public static OperationResult ServiceUnavailable(Enum e) => Failure(OperationFailure.FailureType.ServiceUnavailable, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult<T> Success<T>(T response) => new OperationResult<T>(response);
        
        public static OperationResult<T> Failure<T>() => new OperationResult<T>(isSuccess: false);

        public static OperationResult<T> Failure<T>(OperationFailure.FailureType type, string message, int? code = null)
        {
            OperationFailure operationFailure = code != null ? new OperationFailure(type, message, code.Value) : new OperationFailure(type, message);

            var failures = new List<OperationFailure> { operationFailure };

            return new OperationResult<T>(failures);
        }

        public static OperationResult<T> Failure<T>(string message, int? code = null) => Failure<T>(OperationFailure.FailureType.Generic, message, code);

        public static OperationResult<T> ExceptionResult<T>(Exception exception) => new OperationResult<T>(exception);

        public static OperationResult<T> InvalidArgument<T>(string message) => Failure<T>(OperationFailure.FailureType.InvalidArgument, message);

        public static OperationResult<T> InvalidArgument<T>(Enum e)
        {
            string message = EnumerableDescriptionMethods.GetDescription(e);
            int code = EnumerableDescriptionMethods.GetCode(e).GetValueOrDefault();

            return Failure<T>(OperationFailure.FailureType.InvalidArgument, message, code);
        }

        public static OperationResult<T> InvalidOperation<T>(string message, int? code = null) => Failure<T>(OperationFailure.FailureType.InvalidOperation, message, code);

        public static OperationResult<T> InvalidOperation<T>(Enum e)
        {
            string message = EnumerableDescriptionMethods.GetDescription(e);
            int code = EnumerableDescriptionMethods.GetCode(e).GetValueOrDefault();

            return Failure<T>(OperationFailure.FailureType.InvalidOperation, message, code);
        }

        public static OperationResult<T> TargetResourceNotFound<T>(string message) => Failure<T>(OperationFailure.FailureType.TargetResourceNotFound, message);

        public static OperationResult<T> DatabaseFailure<T>(string message, int? code = null) => Failure<T>(OperationFailure.FailureType.DatabaseFailure, message, code);

        public static OperationResult<T> DatabaseFailure<T>(Enum e) => Failure<T>(OperationFailure.FailureType.DatabaseFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult<T> OperationNotImplemented<T>(string message) => Failure<T>(OperationFailure.FailureType.OperationNotImplemented, message);

        public static OperationResult<T> UnexpectedFailure<T>(string message) => Failure<T>(OperationFailure.FailureType.UnexpectedFailure, message);

        public static OperationResult<T> UnexpectedFailure<T>(Enum e) => Failure<T>(OperationFailure.FailureType.UnexpectedFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult<T> RequestFailure<T>(string message, int? code = null) => Failure<T>(OperationFailure.FailureType.RequestFailure, message, code);

        public static OperationResult<T> RequestFailure<T>(Enum e) => Failure<T>(OperationFailure.FailureType.RequestFailure, EnumerableDescriptionMethods.GetDescription(e));

        public static OperationResult<T> ServiceUnavailable<T>(string message) => Failure<T>(OperationFailure.FailureType.ServiceUnavailable, message);

        public static OperationResult<T> ServiceUnavailable<T>(Enum e) => Failure<T>(OperationFailure.FailureType.ServiceUnavailable, EnumerableDescriptionMethods.GetDescription(e));

        #endregion
    }

    public class OperationResult<T> : OperationResult
    {
        public T Response { get; }

        public OperationResult(bool isSuccess) : base(isSuccess) { }

        public OperationResult(T response) : base(isSuccess: true)
        {
            Response = response;
        }

        public OperationResult(List<OperationFailure> failures) : base(failures) { }

        public OperationResult(Exception exception) : base(exception) { }
    }
}
