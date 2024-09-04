namespace InCommPaymentWebApiCore.Model
{
    public enum ReturnType
    {
        Success = 0,
        NotFound = 1,
        InternalError = 2
    }

    public class Response<T>
    {
        public ReturnType returnType { get; set; }
        public string message { get; set; }
        public List<T> returnedValue { get; set; }
    }
}
