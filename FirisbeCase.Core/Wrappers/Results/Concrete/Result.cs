using FirisbeCase.Core.Wrappers.Results.Abstract;

namespace FirisbeCase.Core.Wrappers.Results.Concrete

{
    public class Result : IResult
    {
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
