using System;
using System.Diagnostics;


//using CoreGraphics;
//using CoreFoundation;
//using System.Runtime.CoreGraphics;
public class RUN {

// See https://aka.ms/new-console-template for more information
public static string RunCommand(string executable, string args) {
//Console.WriteLine("Hello, World!");

Process p = new Process(); // {StartInfo=startInfo};
//ProcessStartInfo startInfo = new ProcessStartInfo();
//p.StartInfo.FileName = "bash";
//p.StartInfo.FileName = "echo";
p.StartInfo.FileName = executable;
//p.StartInfo.Arguments = "-c echo helloa sdflkajsdfladskfj ";
//p.StartInfo.Arguments = " helloa sdflkajsdfladskfj ";
//p.StartInfo.Arguments = command;
p.StartInfo.Arguments = args;
//startInfo.UseShellExecute = true; // = "-c echo hello";
p.StartInfo.RedirectStandardOutput = true;
p.StartInfo.RedirectStandardError = true;
//p.StartInfo.RedirectStandardInput = true;

p.Start();
string output = p.StandardOutput.ReadToEnd();
string error = p.StandardError.ReadToEnd();
// if error error
// bool errored = false;
if (!String.IsNullOrWhiteSpace(error)) {
    Console.WriteLine("error output");
    //errored = true;
}
Console.WriteLine(output);
Console.WriteLine(error);
p.WaitForExit();


//string line = "-c echo hello";
//Process.Start("bash", line);

return output; 
}}
