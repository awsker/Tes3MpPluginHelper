using System;
using System.Collections;
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

            var c = new CRC32();

            foreach (var dataFile in configContents.DataFiles)
            {
                string completePath = null;
                foreach (var path in configContents.DataPaths.Reverse())
                {
                    if (File.Exists(Path.Combine(path, dataFile)))
                    {
                        completePath = Path.Combine(path, dataFile);
                        break;
                    }
                }
                if (completePath == null)
                    throw new Exception($"Data file {dataFile} could not be found");

                using (var stream = File.OpenRead(completePath))
                {
                    var hash = "0x" + c.GetCrc32(stream).ToString("X8").ToUpper();
                    dataFiles.Add(new DataFile() { Name = dataFile, Checksum = hash, FullPath = completePath });
                }

            }
            return dataFiles.ToArray();
        }

        private static ConfigContents getContent(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Could not find OpenMW config file at " + path);

            return getContentRecursive(path, new HashSet<string>());
        }

        private static ConfigContents getContentRecursive(string path, ISet<string> resolvedConfigs)
        {
            resolvedConfigs.Add(path);

            if (!File.Exists(path))
                return new ConfigContents();

            var dataPaths = new HashSet<string>();
            var dataFiles = new HashSet<string>();
            var configs = new HashSet<string>();

            var configDir = Path.GetDirectoryName(path);
            //First resolve this file
            foreach (var line in File.ReadAllLines(path))
            {
                if (line.StartsWith("data=") || line.StartsWith("data-local="))
                {
                    var p = resolveDataPath(line, configDir);
                    if (p != null)
                        dataPaths.Add(p);
                }
                else if (line.StartsWith("config="))
                {
                    var p = resolveDataPath(line, configDir);
                    if (p != null)
                        configs.Add(p);
                }
                else if (line.StartsWith("content="))
                {
                    var f = line.Substring(8).Replace("\"", string.Empty).Trim();
                    if (!string.IsNullOrWhiteSpace(f))
                        dataFiles.Add(f);
                }
            }
            //Then resolve any configs referenced in this file
            foreach (var p in configs)
            {
                if (File.Exists(p) && !resolvedConfigs.Contains(p))
                {
                    var innerConfigContents = getContentRecursive(p, resolvedConfigs);
                    foreach (var p2 in innerConfigContents.DataPaths)
                        dataPaths.Add(p2);
                    foreach (var f2 in innerConfigContents.DataFiles)
                        dataFiles.Add(f2);
                }
            }
            return new ConfigContents() { DataPaths = dataPaths.ToArray(), DataFiles = dataFiles.ToArray() };
        }

        private static string resolveDataPath(string path, string configDir)
        {
            var start = path.IndexOf("=");
            if (start == -1)
                return null;

            var trimmedPath = path.Substring(start + 1).Replace("\"", string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(trimmedPath))
                return null;
            
            if(trimmedPath.StartsWith("."))
            {
                trimmedPath = Path.GetFullPath(Path.Combine(configDir, trimmedPath));
            }
            trimmedPath = trimmedPath.Replace("?userdata?", OpenMwUserData).Replace("?userconfig?", OpenMwConfigPath);
            return Path.GetFullPath(trimmedPath);
        }

        public static string OpenMwUserData
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "OpenMW") + Path.DirectorySeparatorChar;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".config", "openmw") + Path.DirectorySeparatorChar;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library", "Preferences", "openmw") + Path.DirectorySeparatorChar;
                throw new Exception("Could not determine default OpenMW config path");
            }
        }

        public static string OpenMwConfigPath
        {
            get
            {
                return Path.Combine(OpenMwUserData, "openmw.cfg");
            }
        }

        private struct ConfigContents
        {
            public string[] DataPaths;
            public string[] DataFiles;
        }
    }
}
