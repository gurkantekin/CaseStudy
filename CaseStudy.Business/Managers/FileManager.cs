using CaseStudy.Exception.Handlers;
using CaseStudy.Exception.Models;
using System.IO;
using System.Reflection;
using System.Text;

namespace CaseStudy.Business.Managers
{
    public class FileManager
    {
        public static string ReadJsonFile(string filePath)
        {
            using var streamReader = new StreamReader(filePath, Encoding.UTF8);

            try
            {
                return streamReader.ReadToEnd();
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new BusinessOperationException(new BusinessExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    MethodName = methodBase?.Name,
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
    }
}
