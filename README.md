# Tes3MpPluginHelper
Windows based Graphical user interface for building a requiredDataFiles.json for a Tes3Mp server based on the currently selected plugins in OpenMW. I made this because I found it too cumbersome to update the plugin list with checksums manually when I added/changed plugins to use. 

The repository contains two projects. Tes3MpPluginHelper is a .NET Standard library for building a requiredDataFiles.json from the selected plugins found in a OpenMW config file. It could be used to build an application that can run under Linux and OSX (both not tested).

Tes3MpPluginHelperGui is a Windows based .NET Framework graphical interface that uses the binary from Tes3MpPluginHelper.

# Download and install
Check under [Releases](https://github.com/awsker/Tes3MpPluginHelper/releases/tag/v0.1). Just unzip the files anywhere.

# Usage
Locate the OpenMW config (openmw.cfg) in the first box. Then specify where you want the resulting json to be saved in the second box. Note that it should be named **requiredDataFiles.json** and placed in **\<Tes3Mp>\\server\\data** on the server. Check the box if you want the program to automatically include the checksums for both the English and the Russian Morrowind ESMs (including both expansions, if present). Don't check this box if you're running the German or French translations of Morrowind.
