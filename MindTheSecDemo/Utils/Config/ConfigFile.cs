using System;
using Newtonsoft.Json;

namespace MindTheSecDemo.Utils.Config
{
    public class ConfigFile
    {
        private static readonly object padlock = new object();

        private static ConfigFile _instance = null;

        public static ConfigFile Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = JsonConvert.DeserializeObject<ConfigFile>(FileLoader.GetJsonFromSolutionRoot());
                        }
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        public MinhasConfiguracoesConfig MinhasConfiguracoes { get; set; }
    }
}
