﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tes3MpPluginHelper
{
    public static class PluginJsonWriter
    {
        private static Dictionary<string, ISet<string>> _defaultCrc;

        private const string HEADER = @"// This file lets you enforce a certain plugin list and order for all clients
// attempting to join this server
//
// By default, only the English and Russian editions of Morrowind are allowed,
// because the German and French editions have hardcoded translations, whereas
// the Russian edition has localization files that make it compatible with the
// English edition
//
// Generated by ServerPluginHelper";

        static PluginJsonWriter()
        {
            _defaultCrc = new Dictionary<string, ISet<string>>();
            _defaultCrc.Add("morrowind.esm", new HashSet<string>() { "0x7B6AF5B9", "0x34282D67" });
            _defaultCrc.Add("tribunal.esm", new HashSet<string>() { "0xF481F334", "0x211329EF" });
            _defaultCrc.Add("bloodmoon.esm", new HashSet<string>() { "0x43DD2132", "0x9EB62F26" });
        }
        public static void WritePluginJson(string outputFile, DataFile[] datafiles, bool includeDefaultCrc = true)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile))
            {
                file.WriteLine(HEADER);
                file.WriteLine("[");
                file.WriteLine(string.Join("," + Environment.NewLine, datafiles.Select(df => getJsonRowForPlugin(df, includeDefaultCrc))));
                file.WriteLine("]");
            }
        }

        private static string getJsonRowForPlugin(DataFile datafile, bool includeDefaultCrc)
        {
            var checksums = new HashSet<string>();
            if(includeDefaultCrc && _defaultCrc.ContainsKey(datafile.Name.ToLower())) {
                checksums.UnionWith(_defaultCrc[datafile.Name.ToLower()]);
            }
            checksums.Add(datafile.Checksum);
            return $"    {{\"{datafile.Name}\": [{string.Join(", ", checksums.Select(c => "\"" + c + "\""))}]}}";
        }
    }
}