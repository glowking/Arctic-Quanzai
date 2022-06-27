using MelonLoader;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Arctic.Main.Loaders
{
    class Install
    {
        public static UnityEngine.Texture2D image;
        public static void onstartfiles()
        {
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Shaderslogged"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Shaderslogged");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}Arctic"))
            {
                Directory.CreateDirectory($"{Path.GetTempPath()}Arctic");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic\\aseetbundles"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic\\aseetbundles");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic\\Misc");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\dontouchme"))
            {
                var wc = new WebClient();
                wc.DownloadFile("https://api.glowking.net/cl/Obliterate.mp4", $"{MelonUtils.GameDirectory}\\Arctic\\LoadingVid.mp4");
                wc.DownloadFile("https://api.glowking.net/cl/old.json", $"{MelonUtils.GameDirectory}\\Arctic\\dontouchme");
                MelonLogger.Log("new vid?");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\ArcticLoaderupdate"))
            {
                var wc = new WebClient();
                wc.DownloadFile("https://api.glowking.net/antiauto/ARCTICLoader.dll", $"{MelonUtils.GameDirectory}\\Mods\\ARCTICLoader.dll");
                wc.DownloadFile("https://api.glowking.net/cl/old.json", $"{MelonUtils.GameDirectory}\\Arctic\\ArcticLoaderupdate");
                MelonLogger.Log("Updated Arctic");
                string arguments = "";
                foreach (string stringi in Environment.GetCommandLineArgs())
                {
                    arguments += $"{stringi} ";
                }
                System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                vrc.StartInfo.Arguments = arguments;
                vrc.Start();
                Process.GetCurrentProcess().Kill();

            }




            if (!File.Exists($"{MelonUtils.GameDirectory}\\mods\\ArcticHWIDBypass.dll"))
            {
                if (Environment.CommandLine.Contains("--SPOOFER"))
                //if (!File.Exists($"{MelonUtils.GameDirectory}\\mods\\ArcticHWIDBypass.dll"))
                {
                    var wc = new WebClient();
                    wc.DownloadFile("http://api.glowking.net/cl/HWIDBypass", $"{MelonUtils.GameDirectory}\\mods\\ArcticHWIDbypass.dll");
                    string arguments = "";
                    foreach (string stringi in Environment.GetCommandLineArgs())
                    {
                        arguments += $"{stringi} ";
                    }
                    System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                    vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                    vrc.StartInfo.Arguments = arguments;
                    vrc.Start();
                    Process.GetCurrentProcess().Kill();

                }
            }
            /*
                        if (!File.Exists($"{MelonUtils.GameDirectory}\\mods\\ARCTIC SAFE.dll"))
                        {

                            //if (!File.Exists($"{MelonUtils.GameDirectory}\\mods\\ArcticHWIDBypass.dll"))
                            {
                                var wc = new WebClient();
                                wc.DownloadFile("http://api.glowking.net/cl/anti/Sentry", $"{MelonUtils.GameDirectory}\\mods\\ARCTIC SAFE.dll");


                                if (!File.Exists($"{MelonUtils.GameDirectory}\\mods\\UIExpansionKit.dll"))
                                {       wc.DownloadFile("http://api.glowking.net/cl/anti/UIExpansionKit", $"{MelonUtils.GameDirectory}\\mods\\UIExpansionKit.dll");
                            }

                                string arguments = "";
                                foreach (string stringi in Environment.GetCommandLineArgs())
                                {
                                    arguments += $"{stringi} ";
                                }
                                System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                                vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                                vrc.StartInfo.Arguments = arguments;
                                vrc.Start();
                                Process.GetCurrentProcess().Kill();

                            }
                        }
            */


            if (!File.Exists($"{Path.GetTempPath()}Arctic\\dev.mp4"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Obliterate.mp4", $"{Path.GetTempPath()}Arctic\\dev.mp4");

            }
            if (!File.Exists($"{Path.GetTempPath()}Arctic\\devF.mp4"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Dark%20Aesthetics.mp4", $"{Path.GetTempPath()}Arctic\\devF.mp4");

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\aseetbundles\\box"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/box", $"{MelonUtils.GameDirectory}\\Arctic\\aseetbundles\\box");

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\CustomTag.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\CustomTag.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Loading screen music.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Loading%20screen%20music.mp3", $"{MelonUtils.GameDirectory}\\Arctic\\Loading screen music.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Qmmusic.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Qmmusic.mp3", $"{MelonUtils.GameDirectory}\\Arctic\\Qmmusic.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\JoinSound.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/JoinSound.mp3", $"{MelonUtils.GameDirectory}\\Arctic\\JoinSound.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\WorldHistory.json"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Assets/WorldHistory.json", $"{MelonUtils.GameDirectory}\\Arctic\\Misc\\WorldHistory.json");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
                fs.Close();
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json").Close();
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json").Close();

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\discord-rpc.dll"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/discord-rpc.dll", $"{MelonUtils.GameDirectory}\\Arctic\\Misc\\discord-rpc.dll");


            }
            var wcs = new WebClient();
            settings.Anticrash.Anti.shaderlistst = wcs.DownloadString("https://nocturnal-client.xyz/cl/anticrashshader.txt");

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp").Close();

            }
        }




    }
}
