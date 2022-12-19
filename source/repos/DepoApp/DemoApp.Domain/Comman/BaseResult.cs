namespace DemoApp.Domain.Comman
{
    public class BaseResult<T>
    {
        public bool isSuccesful { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
#pragma warning disable
        public T Data { get; set; }
# pragma warning restore
    }
}
