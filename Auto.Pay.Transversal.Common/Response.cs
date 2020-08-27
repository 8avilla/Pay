
namespace Auto.Pay.Transversal.Common
{
    public class Response
    {
        public object Data {get; set;}
        public bool Success { get; set; } = true;
        public ErrorDetails ErrorDetails { get; set; }

        public Response() {}
    }
}


