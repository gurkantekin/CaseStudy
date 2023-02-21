using CaseStudy.Business.Managers;
using CaseStudy.Model.Constants;
using System;

namespace Case2.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var output = OcrManager.ConvertJsonToText(FileManager.ReadJsonFile(AppConstants.FilePath));

            foreach (var (key, value) in output)
            {
                Console.WriteLine($"{key} {value}");
            }

            Console.ReadKey();
        }
    }
}
