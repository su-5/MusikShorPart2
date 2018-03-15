namespace BLL.Core.Exception
{
    public class ValidatorException : System.Exception
    {
        public string Property { get; protected set; }

        public ValidatorException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
