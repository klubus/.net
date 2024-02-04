namespace FootballApp.Common.Framework.Interface
{
    public interface IActionResult<T> : IActionResult
    {
        T Data { get; }
    }
}
