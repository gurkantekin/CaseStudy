using CaseStudy.Exception.Models;

namespace CaseStudy.Exception.Handlers
{
    public class BusinessOperationException : BaseException
    {
        public BusinessExceptionModel BusinessException { get; }

        public BusinessOperationException(BusinessExceptionModel model, string message) : base(string.Join("-|-", model.GetMessage(), message))
        {
            BusinessException = model;
        }

        public BusinessOperationException(BusinessExceptionModel model, string message, System.Exception innerException) : base(string.Join("-|-", model.GetMessage(), message), innerException)
        {
            BusinessException = model;
        }
    }
}
