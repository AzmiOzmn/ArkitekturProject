namespace Arkitektur.Business.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public IEnumerable<object> Errors { get; set; }
        public bool IsSuccessful => Errors == null || !Errors.Any();
        public bool IsFailure => !IsSuccessful;


        public static BaseResult<T> Success(T data)
        {
            return new BaseResult<T> { Data = data, Errors = null };
        }

        public static BaseResult<T> Failure(string errorMessage)
        {
            return new BaseResult<T> {Errors = new[] { new { ErrorMessage = errorMessage } } };
        }

    }
}
