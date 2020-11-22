using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using BepInEx.IL2CPP;

namespace AmongUs.BootStrap
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            var oldRuntimeDirectory = Directory.GetCurrentDirectory();
            var amongUsPath = Environment.GetEnvironmentVariable("AMONG_US_PATH");

            if (amongUsPath == null)
            {
                Console.Error.WriteLine("Environment variable AMONG_US_PATH is not set.");
                return 1;
            }

            Directory.SetCurrentDirectory(amongUsPath);

            var mainMethod = typeof(Preloader).Assembly
                .GetType("BepInEx.IL2CPP.DoorstopEntrypoint")
                ?.GetMethod("Main", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof(string[])}, null);

            if (mainMethod == null)
            {
                Console.Error.WriteLine("Failed to locate BepInEx entry point");
                return 1;
            }

            Environment.SetEnvironmentVariable("DOORSTOP_INVOKE_DLL_PATH",
                amongUsPath + "/BepInEx/core/BepInEx.IL2CPP.dll");
            Environment.SetEnvironmentVariable("DOORSTOP_MANAGED_FOLDER_DIR", amongUsPath + "/Among Us_Data/");
            Environment.SetEnvironmentVariable("DOORSTOP_PROCESS_PATH", amongUsPath + "/Among Us.exe");
            mainMethod.Invoke(null, new object[] {args});

            var executable = $"\"{amongUsPath}/Among Us.exe\"";

            var gameProcess = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                ? Process.Start(new ProcessStartInfo("/usr/bin/wine", $"{executable} {string.Join(" ", args)}")
                {
                    UseShellExecute = false,
                    EnvironmentVariables =
                    {
                        ["WINEARCH"] = "win32",
                        ["WINEPREFIX"] = $"{oldRuntimeDirectory}/among_us_prefix"
                    }
                })
                : Process.Start(executable, string.Join(" ", args));
            
            if (gameProcess != null)
            {
                while (!gameProcess.HasExited)
                {
                }

                return gameProcess.ExitCode;
            }

            Console.Error.WriteLine("Failed to start game.");
            return 1;
        }
    }
}
