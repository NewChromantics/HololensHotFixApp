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
            client.RemoteDevice.DeleteFile(@"C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\TailoredDeploy.exe");

        }
    }
}
