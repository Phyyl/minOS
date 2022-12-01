global using static CommandLine;
global using static System.Console;

using System.Diagnostics;

public static class CommandLine
{
    public static bool Execute(string command, params string[] arguments)
    {
        string argumentString = string.Join(" ", arguments);

        Process process = new()
        {
            StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = command,
                Arguments = argumentString,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };


        process.OutputDataReceived += (_, e) => WriteLine(e.Data);
        process.ErrorDataReceived += (_, e) => WriteLine($"Error: {e.Data}");
        process.EnableRaisingEvents = true;

        if (!process.Start())
        {
            WriteLine($"Failed to start process: {command} {argumentString}");
            return false;
        }

        process.WaitForExit();
        
        if (process.ExitCode == 0)
        {
            return true;
        }

        WriteLine($"Failed to execute: {command} {argumentString}");
        return false;
    }
}
