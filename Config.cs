using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace zpo_projekt
{
    internal class Config
    {
        private static readonly object Lock = new object();
        private static Config Instance;

        private const string ConfigFileName = "config.json";
        private const string? ConfigFilePath = null;

        public string DatabasePath { get; set; }
        public int MaxProductCount { get; set; }

        [JsonConstructor]
        private Config() { }

        public static Config GetInstance()
        {
            if (Instance == null)
            {
                lock (Lock)
                {
                    if (Instance == null)
                    {
                        Instance = Load();
                    }
                }
            }
            return Instance;
        }

        private static Config Load()
        {
            string path;
            if (ConfigFilePath == null)
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
                path = Path.Combine(projectDir, ConfigFileName);
            }
            else
            {
                path = ConfigFilePath;
            }

            string json = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<Config>(json, options);
        }
    }
}
