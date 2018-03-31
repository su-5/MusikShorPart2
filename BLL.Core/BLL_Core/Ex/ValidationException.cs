namespace BLL.Core.BLL_Core.Ex
{
    public class ValidationException : System.Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
