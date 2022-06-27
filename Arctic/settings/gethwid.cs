using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using UnityEngine;
using System.Diagnostics;

namespace Arctic.settings
{
    public class gethwid
    {
        public static void getinfo(ref string strings)
        {

            string name = "SOFTWARE\\Microsoft\\Cryptography";
            string name2 = "MachineGuid";
            using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
                {
                    if (registryKey2 != null)
                    {
                        object value = registryKey2.GetValue(name2);
                        if (value != null)
                            strings = value.ToString();

                    }
                }
            }
        }

        public static void sendc(string key)
        {
            var today = System.DateTime.Now;
            var stringtime = today.ToString("yyyy:MM:dd:HH:mm:ss");
            var acc = new settings.Account()
            {
                User = VRC.Core.APIUser.CurrentUser.displayName,
                Joineddate = stringtime,
                Hwid = Main.load.sendauth,
                Key = key,
                uid = "Blank",
                code = "18",
            };
            string json = JsonConvert.SerializeObject(acc);
           connect.sendmsg($"{json}");
            File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt", key);
            getinfo(ref Main.load.sendauth);

            var abc = new settings.confirmauth()
            {
                key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),

                Hwida = Main.load.sendauth,

                code = "18",
            };

            string abcs = $"{JsonConvert.SerializeObject(abc)}";
           
            connect.sendmsg($"{abcs}");


            var ab = new settings.confirmauth()
            {
                key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),

                Hwida = Main.load.sendauth,

                code = "14",
            };

     



            string abs = $"{JsonConvert.SerializeObject(ab)}";
            connect.sendmsg($"{abs}");

        }
       
    }

  
}
