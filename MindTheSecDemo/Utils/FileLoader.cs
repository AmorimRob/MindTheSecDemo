using System;
using System.IO;
using System.Reflection;

namespace MindTheSecDemo.Utils
{
    public static class FileLoader
    {
        public static string GetJsonFromSolutionRoot()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var result = "";

            using (var stream = assembly.GetManifestResourceStream($"MindTheSecDemo.Config.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}
