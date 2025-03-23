using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tes3MpPluginHelper
{
    public static class ConfigHandler
    {
        public static DataFile[] GetSelectedDatafiles(string configPath = null)
        {
            var dataFiles = new List<DataFile>();
            var configContents = getContent(configPath ?? OpenMwConfigPath);

            foreach (var dataFile in configContents.DataFiles.Reverse())
            {
                string completePath = null;
                foreach (var path in configContents.DataPaths)
                {
                    if (File.Exists(Path.Combine(path, dataFile)))
                    {
                        completePath = Path.Combine(path, dataFile);
                        break;
                    }
                }
                if (completePath == null)
                    throw new Exception($"Data file {dataFile} could not be found");

                var c = new CRC32();

                using (var stream = File.OpenRead(completePath))
                {
                    var hash = "0x" + c.GetCrc32(stream).ToString("X8").ToUpper();
                    dataFiles.Add(new DataFile() { Name = dataFile, Checksum = hash });
                }

            }
            return dataFiles.ToArray();
        }

        private static ConfigContents getContent(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Could not find OpenMW config file at " + path);

            var dataPaths = new List<string>();
            var dataFiles = new List<string>();
            foreach (var line in File.ReadAllLines(path))
            {
                if (line.StartsWith("data="))
                    dataPaths.Add(line.Substring(5).Replace("\"", string.Empty));
                else if (line.StartsWith("content="))
                    dataFiles.Add(line.Substring(8).Replace("\"", string.Empty));
            }
            return new ConfigContents() { DataPaths = dataPaths.ToArray(), DataFiles = dataFiles.ToArray() };
        }

        public static string OpenMwConfigPath
        {
            get
            {
                if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "OpenMW", "openmw.cfg");
                else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".config", "openmw", "openmw.cfg");
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library", "Preferences", "openmw", "openmw.cfg");
                throw new Exception("Could not determine default OpenMW config path");
            }
        }

        private struct ConfigContents
        {
            public string[] DataPaths;
            public string[] DataFiles;
        }
    }
}
