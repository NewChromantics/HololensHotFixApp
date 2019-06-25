Ok, here you go.  The following steps will have you create a simple C# console app that will remove a file from your device that Visual Studio installed.  We believe this file is corrupted or otherwise incompatible with your current software, but Visual Studio will never update that file if it is already present on the device.  Therefore, the app you're going to run will delete that file, and it will be redeployed the next time you use Visual Studio to deploy an app to your HoloLens.  In the steps, if you don't have 10.0.18362.0, use the highest version you do have (e.g., 10.0.17763.0).
1. Open Visual Studio
2. File -> New -> Project...
3. Visual C# -> Windows Desktop -> Console App (.NET Framework)
4. Give it a name (e.g., HoloLensWorkaround) and make sure the Framework is set to at least .NET Framework 4.5 then click OK.
5. Right-click on the References node in Solution Explorer and add the following references (click to the 'Browse' section and click the 'Browse...' button):

C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x86\Microsoft.Tools.Deploy.dll
C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x86\Microsoft.Tools.Connectivity.dll
C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x86\SirepInterop.dll

6. Right-click on the project in Solution Explorer and choose Add -> Existing Item.

7. Browse to C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x86 and change the filter to "All Files (*.*)

8. Select both SirepClient.dll and SshClient.dll and click "Add".

9. Locate and select both files in Solution Explorer (should be at the bottom of the list of files) and change "Copy to Output Directory" in the Properties window to "Copy always"

10. At the top of the file, add the following to the existing list of 'using' statements:

using Microsoft.Tools.Deploy;
using System.Net;

11. Inside of static void Main(...), add the following:

           RemoteDeployClient client = RemoteDeployClient.CreateRemoteDeployClient();
           client.Connect(new ConnectionOptions()
           {
               Credentials = new NetworkCredential("DevToolsUser", string.Empty),
               IPAddress = IPAddress.Parse(args[0])
           });
           client.RemoteDevice.DeleteFile(@"C:\Data\Users\DefaultAccount\AppData\Local\DevelopmentFiles\VSRemoteTools\x86\TailoredDeploy.exe");

12. Build -> Build Solution

13. Open a command prompt to the folder that contains the new .exe (e.g., C:\MyProjects\HoloLensWorkaround\bin\Debug)

14. Run the executable and pass the device's IP address.  (If connected via USB, you can use 127.0.0.1, otherwise use the WiFi IP address)

15. If all goes well, you will see no output.  If you see an error/exception, please let me know what that is.

16. Attempt to deploy and debug your HoloLens app from Visual Studio. (edited) 

Please let me know if you have any questions or problems with any of the steps.
When you run step 16 (attempting to deploy your HoloLens app), if you look at the Build log in the Ouput window, you should see a new line: "Uncompressing packages on remote device: START".  This only happens if Visual Studio determines that it needs to redeploy its files (not your app files).  This would have happened the very first time you deployed an app to your HoloLens via Visual Studio but doesn't happen in subsequent attempts, but by running through the steps I outlined, you're clearing out the key file that makes Visual Studio deploy all of its files again. (edi
