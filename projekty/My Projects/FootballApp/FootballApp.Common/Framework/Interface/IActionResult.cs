namespace FootballApp.Common.Framework.Interface
{
    public interface IActionResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        Tuple<string, object>[] Parameters { get; }
    }
}
