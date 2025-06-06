using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.IO;

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

        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(getConfigPath(), json);
        }

        private static Config Load()
        {
            string json = File.ReadAllText(getConfigPath());

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<Config>(json, options);
        }

        private static string getConfigPath()
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

            return path;

        }
    }
}
