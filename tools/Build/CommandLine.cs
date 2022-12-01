global using static CommandLine;
global using static System.Console;

using System.Diagnostics;

public static class CommandLine
{
    public static bool Execute(string command, params string[] arguments)
    {
        string argumentString = string.Join(" ", arguments);

        Process? process = Process.Start(new ProcessStartInfo()
        {
            UseShellExecute=false,
            CreateNoWindow = true,
            FileName = command,
            Arguments = argumentString,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        });

        if (process is null)
        {
            Console.WriteLine($"Failed to exeucte command: {command} {argumentString}");
            return false;
        }

        process.WaitForExit();

        return process.ExitCode == 0;
    }
}
