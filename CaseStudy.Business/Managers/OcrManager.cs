using CaseStudy.Exception.Handlers;
using CaseStudy.Exception.Models;
using CaseStudy.Model.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CaseStudy.Business.Managers
{
    public class OcrManager
    {
        public static Dictionary<int, string> ConvertJsonToText(string jsonModel)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<List<OcrResponseModel>>(jsonModel);

                var textResult = new Dictionary<int, string>();

                if (model == null) return textResult;

                model = model.Where(x => string.IsNullOrEmpty(x.Locale))
                        .OrderBy(x => x.BoundingPoly.Vertices
                        .OrderBy(y => y.Y)
                        .ThenBy(y => y.X)
                        .Select(z => z.Y)
                        .FirstOrDefault()).ToList();

                var currentIndex = 1;

                OcrResponseModel ocrResponseModel = null;

                for (var i = 0; i < model.Count;)
                {
                    var currentLine = model[i];

                    if (!textResult.ContainsKey(currentIndex))
                    {
                        textResult.Add(currentIndex, currentLine.Description);
                        ocrResponseModel = currentLine;
                        i++;
                        continue;
                    }

                    if (ocrResponseModel != null)
                    {
                        var minHeight = ocrResponseModel.BoundingPoly.Vertices.OrderBy(x => x.Y).First().Y;
                        var maxHeight = ocrResponseModel.BoundingPoly.Vertices.OrderByDescending(x => x.Y).First().Y;

                        var heightAverage = (minHeight + maxHeight) / 2;

                        var currentMinHeight = currentLine.BoundingPoly.Vertices.OrderBy(x => x.Y).First().Y;

                        if (heightAverage > currentMinHeight)
                        {
                            textResult[currentIndex] += string.Empty + currentLine.Description;
                            ocrResponseModel = currentLine;
                            i++;
                            continue;
                        }
                    }

                    currentIndex++;
                }

                return textResult;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var businessOperationException = new BusinessOperationException(new BusinessExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    MethodName = methodBase?.Name,
                }, exception.Message, exception.InnerException);

                throw businessOperationException;
            }
        }
    }
}
