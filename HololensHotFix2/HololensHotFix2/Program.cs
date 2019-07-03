using System;
using Microsoft.Tools.Deploy;
using System.Net;

namespace HololensHotFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RemoteDeployClient client = RemoteDeployClient.CreateRemoteDeployClient();
            client.Connect(new ConnectionOptions()
            {
                Credentials = new NetworkCredential("DevToolsUser", string.Empty),
                IPAddress = IPAddress.Parse(args[0])
            });

			//client.RemoteDevice.DeleteFile(@"C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\TailoredDeploy.exe");

			//var Result = client.RemoteDevice.RunCommand("DevToolsLauncher.exe", @"LaunchForDeploy cmd ""/C C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\TailoredDeploy.exe /_v CheckDeveloperLicense >> C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\license.txt""");
			//Console.WriteLine(Result);
			//client.RemoteDevice.GetFile(@"C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\license.txt", "license.txt");

			//var Result = client.RemoteDevice.RunCommand("DevToolsLauncher.exe", @"LaunchForDeploy cmd ""/C dir C:\mscorlib.dll /s > c:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\corlib.txt""");
			//Console.WriteLine(Result);
			//System.Threading.Thread.Sleep(15000);
			//client.RemoteDevice.GetFile(@"c:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\corlib.txt", "corlib.txt");


			//var Result = client.RemoteDevice.RunCommand("DevToolsLauncher.exe", @"LaunchForDeploy cmd ""/C dir C:\mscorlib.dll /s > c:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\corlib.txt""");
			//Console.WriteLine(Result);
			//System.Threading.Thread.Sleep(15000);
			//client.RemoteDevice.GetFile(@"c:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\corlib.txt", "corlib.txt");

			client.RemoteDevice.DeleteFile(@"C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\CoreCLR\mscorlib.ni.dll");

		}
	}
}
