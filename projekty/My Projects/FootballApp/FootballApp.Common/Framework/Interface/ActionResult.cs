namespace FootballApp.Common.Framework.Interface
{
    public class ActionResult : IActionResult
    {
        public string ErrorMessage { get; }
        public bool IsFailure => !IsSuccess;

        public bool IsSuccess { get; }
        public Tuple<string, object>[] Parameters { get; }

        protected ActionResult(bool isSuccess, string message, params Tuple<string, object>[] parameters)
        {
            IsSuccess = isSuccess;
            ErrorMessage = message;
            Parameters = parameters;
        }

        public static IActionResult Failure(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult(isSuccess: false, errorMessage, parameters);
        }

        public static IActionResult Success()
        {
            return new ActionResult(isSuccess: true, (string)null, (Tuple<string, object>[])null);
        }

        public static IActionResult Ignore(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult(isSuccess: false, errorMessage, parameters);
        }

        public static IActionResult FailureFrom(IActionResult result)
        {
            return new ActionResult(isSuccess: false, result.ErrorMessage, result.Parameters);
        }
    }
}
