
namespace JsonWebToken_API.Models
{

    public class CommonModel
    {

    }
    public class AuthModel<T>
    {
        public bool Code { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }

    public class ResultModel<T>
    {
        public bool Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class tokenValue
    {
       public string Value { get; set; }
    }


}
