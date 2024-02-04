using FootballApp.Common.Framework.Interface;

namespace FootballApp.Common.Framework
{
    public class ActionResult<T> : ActionResult, IActionResult<T>, IActionResult
    {
        public T Data { get; }

        protected ActionResult(bool isSuccess, string errorMessage, T data, params Tuple<string, object>[] parameters)
            : base(isSuccess, errorMessage, parameters)
        {
            Data = data;
        }

        public static IActionResult<T> Failure(string errorMessage)
        {
            return new ActionResult<T>(false, errorMessage, default(T));
        }

        public static IActionResult<T> Failure(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult<T>(isSuccess: false, errorMessage, default(T), parameters);
        }

        public static IActionResult<T> FailureFrom(IActionResult result)
        {
            return new ActionResult<T>(false, result.ErrorMessage, default(T), result.Parameters);
        }

        public static IActionResult<T> Success(T data)
        {
            return new ActionResult<T>(true, null, data);
        }

        public static IActionResult<T> Ignore(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult<T>(isSuccess: false, errorMessage, default(T), parameters);
        }
    }
}
