using System;

namespace Tes3MpPluginHelper
{
    public static class Application
    {
        public static int Main(string[] args)
        {
            try
            {
                string configPath = null;
                string outputPath;
                if (args.Length == 0)
                    throw new Exception("No output path set");
                if (args.Length == 1)
                    outputPath = args[0];
                else
                {
                    configPath = args[1];
                    outputPath = args[2];
                }
                var selectedConfigs = ConfigHandler.GetSelectedDatafiles(configPath);
                PluginJsonWriter.WritePluginJson(outputPath, selectedConfigs, true);
                return 0;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                return 1;
            }
        }
    }
}
