namespace CaseStudy.Exception.Models
{
    public class BusinessExceptionModel : BaseExceptionModel
    {
        public override string Message { get; set; }

        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public string NameSpace { get; set; }

        public string GetMessage()
        {
            return $"NameSpace:{string.Join(".", NameSpace, ClassName, MethodName)} Message:{Message}";
        }
    }
}
