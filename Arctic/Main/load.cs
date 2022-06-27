using Arctic.Exploits;
using Arctic.Wrappers;
using MelonLoader;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using UnhollowerRuntimeLib;
using UnityEngine;
using UniverseLib.UI;
using VRC;
using VRC.Core;
using Arctic.settings;
using Arctic.Apis;
namespace Arctic.Main
{
    public class load
    {

        public static string sendauth;
        // private static Thread difft = new Thread(connect.startwebsocketc);





        private static Texture2D img = null;
        [Obsolete]

        private static Texture2D recttext = null;


        private static IEnumerator WaitForSM()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;

            Apis.Buttons.qm.Prefabs.Getprefabs();

            Main.Loaders.Loadqm.setupqm();
            Style.Uichanges.applyui();
            Style.Image.applyall();
        }






        private static Texture2D createtexture(UnityEngine.Color color)
        {
            var text = new Texture2D(2, 2);
            var pixels = text.GetPixels();

            for (var i = 0; i < pixels.Length; ++i)
            {
                pixels[i] = color;
            }

            text.SetPixels(pixels);

            text.Apply();


            return text;
        }
        private static bool isguibig = true;
        private static bool Debugger = true;

        public static void ongui()
        {

            var pg = new GUIStyle();
            pg.normal.background = createtexture(new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 0.7f));

            var pger = new GUIStyle();
            pger.normal.background = createtexture(new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 0.3f));
            pger.normal.textColor = new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 1f);
            pger.alignment = TextAnchor.UpperCenter;
            GUIStyle myStylet = new GUIStyle();
            myStylet.fontSize = 10;
            myStylet.richText = true;
            myStylet.fontStyle = UnityEngine.FontStyle.Bold;
            myStylet.wordWrap = false;
            myStylet.normal.textColor = UnityEngine.Color.white;


            var tintableText = new GUIStyle(GUI.skin.box);
            tintableText.normal.textColor = new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 1);
            tintableText.fontSize = 15;
            tintableText.richText = true;
            tintableText.normal.background = createtexture(new UnityEngine.Color(0.07f, 0.07f, 0.07f, 0.95f));

            if (settings.nconfig.playerlistgui)
            {

                if (isguibig)
                {
                    GUI.Box(new Rect(Screen.currentResolution.width / 125f, Screen.currentResolution.height / 4.7f, Screen.currentResolution.width / 5.85f, Screen.currentResolution.height / 2.55f), "", pg);
                    GUI.Box(new Rect(Screen.currentResolution.width / 100f, Screen.currentResolution.height / 4.6f, Screen.currentResolution.width / 6, Screen.currentResolution.height / 2.60f), "[ Player List ]", tintableText);
                    // GUI.Box(new Rect(Screen.width / 125f, Screen.height / 3.85f, Screen.width / 5.85f, Screen.height / 300), "", pg);
                    //GUI.Box(new Rect(Screen.width / 125f, Screen.height / 1.65f, Screen.width / 5.85f, Screen.height / 300), "", pg);
                    GUI.Label(new Rect(Screen.currentResolution.width / 100f, Screen.currentResolution.height / 4.1f, Screen.currentResolution.width / 7, Screen.currentResolution.height / 3f), Arctic.Style.Playerlist.playlist, myStylet);

                }

                if (Debugger)
                {
                    GUI.Box(new Rect(Screen.currentResolution.width / 125f, Screen.currentResolution.height / 1.597f, Screen.currentResolution.width / 5.85f, Screen.currentResolution.height / 3.4f), "", pg);
                    GUI.Box(new Rect(Screen.currentResolution.width / 100f, Screen.currentResolution.height / 1.59f, Screen.currentResolution.width / 6, Screen.currentResolution.height / 3.5f), "[ Debugger ]", tintableText);
                    GUI.Label(new Rect(Screen.currentResolution.width / 100f, Screen.currentResolution.height / 1.53f, Screen.currentResolution.width / 7, Screen.currentResolution.height / 2f), Style.textdebuger.lastlines, myStylet);
                }



                GUILayout.BeginVertical(null);
                GUI.backgroundColor = new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 0.3f);
                GUI.color = new UnityEngine.Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue, 1f);

                if (GUILayout.Button("Show/Hide Player List", null))
                    isguibig = !isguibig;

                if (GUILayout.Button("Show/Hide Debugger", null))
                    Debugger = !Debugger;
                GUILayout.EndVertical();
            }


        }



        public static void Start()
        {
            if (Environment.CommandLine.Contains("--melonloader.debug"))
            {
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();
                MelonLogger.Msg("NICE DEBUG BUT I CANNOT LET YOU LOAD THIS CLIENT BRUV");
                Console.Beep();


                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }
            // difft.Start();
            Loaders.Install.onstartfiles();
            // MelonCoroutines.Start()
            MyModEntryPoint();
           
            //OldLoadingScreen.OldLoadingScreenMod.OLDLOAD();
            MelonCoroutines.Start(WaitForSM());

            Console.Title = "Arctic Client";
            settings.Anticrash.Anti.whitelist = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp");

            Style.Consoles.consolelogger("Loading Config");
            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json") == string.Empty)
                settings.StyleConfig.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");

            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json") == string.Empty)
                settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json");

            Style.Consoles.consolelogger("Checking Style Config");
            var acc = Newtonsoft.Json.JsonConvert.DeserializeObject<settings.styledata>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json"));
            foreach (var bbc in acc.GetType().GetProperties())
            {
                try
                {
                    var bcc = bbc.GetValue(acc);
                    bcc.ToString();
                    Style.Consoles.consolelogger($"{bbc.Name}:{bcc}");
                }
                catch
                {
                    Style.Consoles.consolelogger(bbc.Name + " FAILED");
                    var getfields = typeof(settings.StyleConfig).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    foreach (var a in getfields)
                    {
                        try
                        {
                            if (bbc.Name == a.Name)
                            {
                                bbc.SetValue(acc, a.GetValue(getfields));
                            }
                        }
                        catch { Style.Consoles.consolelogger($"BIG FAIL {bbc.Name}"); }
                    }

                }
            }

            Style.Consoles.consolelogger("Checking Main Config");
            var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<settings.configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json"));
            foreach (var bbc in mainl.GetType().GetProperties())
            {
                try
                {

                    var bcc = bbc.GetValue(mainl);
                    bcc.ToString();
                    //  Style.Consoles.consolelogger($"{bbc.Name}:{bcc}");
                }
                catch
                {
                    Style.Consoles.consolelogger(bbc.Name + " FAILED");
                    var getfields = typeof(settings.nconfig).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    foreach (var a in getfields)
                    {
                        try
                        {
                            if (bbc.Name == a.Name)
                            {
                                bbc.SetValue(mainl, a.GetValue(getfields));

                            }
                        }
                        catch { Style.Consoles.consolelogger($"BIG FAIL {bbc.Name}"); }
                    }

                }

            }





            settings.StyleConfig.applyconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json", acc);
            settings.nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json", mainl);
            Style.Consoles.consolelogger("Config Finished");
            MelonCoroutines.Start(Init());


            Style.Consoles.consolelogger("Client - Started");
            Style.Consoles.consolelogger("Loading Discord rpc");
            MelonCoroutines.Start(Waitforuser());
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.Nameplates>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.TargetedPlayer>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.explode>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.linerenderer>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.sitonpickups>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.Normalboom>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.TargetedPlayer>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.Targettouch>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.touchpickups>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.touchstuff>();
            ClassInjector.RegisterTypeInIl2Cpp<Apis.Desktopui.monobehaviours.Dragg>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.bonesp>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.Lineupdator>();
            ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.Social>();
            // ClassInjector.RegisterTypeInIl2Cpp<settings.MonoBehaviours.usertab>();
            patch.nativepatch.nativepatches();
            MelonCoroutines.Start(UiInitCoroutine());

            //APIUser.FetchUser("",);
            // Console.ReadLine();

        }


        private static IEnumerator Init()
        {
            while (GameObject.Find("UserInterface") == null)
                yield return null;

            Main.Loaders.misc.Load();
            while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)") == null)
                yield return null;

            //  Apis.Buttons.qm.Prefabs.Getprefabs();

            //  Main.Loaders.Loadqm.setupqm();
            //  Style.Uichanges.applyui();
            // Style.Image.applyall(); 
        }
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int message, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        private static IntPtr window;

        private static Thread tr = new Thread(connect.Runsocket);

        private static IEnumerator Waitforuser()
        {
            while (APIUser.CurrentUser == null)
                yield return null;
            tr.Start();




            Discord.DiscordManager.presence.largeImageText = $"By Glowking";
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            MelonCoroutines.Start(Apis.AssetBundles.startanim());
             //OldLoadingScreen.OldLoadingScreenMod.OLDLOAD();
            MelonCoroutines.Start(Apis.AssetBundles.loadparticles());

            Discord.DiscordManager.presence.details = $"{APIUser.CurrentUser.displayName}.";
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            var a = new GameObject();
            a.name = "Arctic Line Manager";
            a.transform.parent = GameObject.Find("/_Application").gameObject.transform;
            a.gameObject.AddComponent<settings.MonoBehaviours.Lineupdator>();
            userlist = desuserinfo();
            Console.Title = $"Arctic Client -  Logged in with -[{APIUser.CurrentUser.displayName}]";
            window = FindWindow(null, "VRChat");
            SetWindowText(window, "A R C T I C X_X");
            Process[] processes = Process.GetProcessesByName("Discord");


            var bytess = new WebClient().DownloadData("http://api.glowking.net/favicon.ico");
            Stream stream = new MemoryStream(bytess);
            Icon icon = new Icon(stream);
            SendMessage(window, WM_SETICON, ICON_BIG, icon.Handle);

            foreach (Process p in processes)
            {
                IntPtr windowHandle = p.MainWindowHandle;
                var bytess2 = new WebClient().DownloadData("https://nocturnal-client.xyz/cl/Discord%202.ico");
                Stream stream2 = new MemoryStream(bytess2);
                Icon icon2 = new Icon(stream2);
                SendMessage(windowHandle, WM_SETICON, ICON_BIG, icon2.Handle);
            }
            if (!connect.wss.IsAlive)
                yield return null;
            Runforms();

            //  Component.DestroyImmediate(newcolor.GetComponent<UnityEngine.Camera>());
        }
        public static List<settings.Userinfo> userlist;
        private const int WM_SETICON = 0x80;
        private const int ICON_SMALL = 0;
        private const int ICON_BIG = 1;

        public static List<settings.Userinfo> desuserinfo()
        {
            var wc = new WebClient();
            var user = JsonConvert.DeserializeObject<List<settings.Userinfo>>(wc.DownloadString("https://raw.githubusercontent.com/glowking/CLIENT/main/cl/users.json"));
            return user;
        }
        private static IEnumerator UiInitCoroutine()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return null;


            // settings.Config.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");
            // settings.Config.applyconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");
            // settings.Config.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");




            //Style.Consoles.consolelogger("Thanks Edward7 may Nocturnal live forever");

            Style.Consoles.consolelogger("Ui - Loaded");
            Loadui.loadui();
            Style.Consoles.consolelogger("Ui - Loaded2");

            Style.Consoles.consolelogger("Thanks Edward7 may Nocturnal live forever");

            patch.Patch.Patchse();
            Style.Consoles.consolelogger("Ui - Loaded3");
            MelonCoroutines.Start(style.Loading_Screen.LoadingScreen());

            MelonCoroutines.Start(Apis.AssetBundles.loadparticles());


            foreach (var bg in Resources.FindObjectsOfTypeAll<ImageThreeSlice>())
            {
                if (settings.nconfig.NamePlatesuichange)
                {
                    if (bg.name == "Background" && bg.transform.parent.name == "Main")
                    {
                        MelonCoroutines.Start(Apis.image.loadImageThreeSlice(bg, "http://nocturnal-client.xyz/cl/Download/Media/Nameplate.png"));
                    }
                }

            }

            foreach (var bg in GameObject.Find("UserInterface").transform.Find("ActionMenu/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
            {
                if (bg.name == "Cursor" && bg.transform.parent.name == "Main")
                {
                    MelonCoroutines.Start(Apis.image.loadspriterest(bg, "http://nocturnal-client.xyz/cl/Download/Media/joystick.png"));
                    var img = GameObject.Instantiate(bg.gameObject, bg.transform);
                    MelonCoroutines.Start(Apis.image.LoadSpriteBetter(img.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.JoyStick));




                }
            }


            Wrappers.Target.targetplayermain = new GameObject();
            Wrappers.Target.targetplayermain.transform.parent = GameObject.Find("_Application").transform;
            Wrappers.Target.targetplayermain.name = "ArcticPlayerHolder";
            Wrappers.Target.targetplayermain.AddComponent<settings.MonoBehaviours.TargetedPlayer>();


            while (VRC.SDKBase.Networking.LocalPlayer == null)
                yield return null;

            while (GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background") == null)
                yield return null;

            Main.desktopui.setupui();

        }



        private static bool isthirdperson = false;
        private static bool zoombooltoggle = false;
        private static float zoomvalue = 60f;
        private static float zoomvalue2 = 60f;

        public static List<settings.Userinfo> userinfo;
        public static List<settings.Userinfo> getusersinfo()
        {
            var wc = new WebClient();
            var user = JsonConvert.DeserializeObject<List<settings.Userinfo>>(wc.DownloadString("https://raw.githubusercontent.com/glowking/CLIENT/main/cl/users.json"));
            return user;
        }
        private static GameObject iscmrgmj;


        public static GameObject CachedCamBox;
        private static bool iszoomkey = true;


        //15 dreapta
        //14 stanga

        public static bool Hasuiupdate = false;

        public static void lateupdate()
        {

            if (Hasuiupdate == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        string url = settings.StyleConfig.qmimg;
                        StyleConfig.qmimg = url;
                        var Qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground").gameObject.GetComponent<UnityEngine.UI.Image>();
                        MelonCoroutines.Start(image.loadspriterest(Qm, url));
                        MelonLogger.Log("UI Fix Success");
                        Hasuiupdate = true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    MelonCoroutines.Start(Apis.AssetBundles.startanim());
                
                    MelonLogger.Msg("DEBUG KEY PRESSED");
                    Hasuiupdate = true;
                }
            }


            //MelonCoroutines.Start(Apis.AssetBundles.startanim());





            if (items.ownertr)
                items.objectowner();

            if (items.rotates)
                items.rotateobjse();
            if (Orbit.isexploding)
                Orbit.orbitexplode(settings.MonoBehaviours.explode.playervec3);

            if (Target.istargetd != null)
            {
                if (Manager.orbits)
                    Orbit.itemorbit1();

                if (items.isspamhead)
                    items.spamhead();

                if (Exploits.sit.sitonparts.Orbiting)
                {
                    Manager.speed += Time.deltaTime * 3;
                    Extentions.LocalPlayer.transform.position = new Vector3(Target.istargetd.transform.position.x + 1.5f * (float)Math.Cos(Manager.speed), Target.istargetd.GetVRCPlayer().GetAnimator().GetBoneTransform(HumanBodyBones.Hips).transform.position.y, Target.istargetd.transform.position.z + 1.5f * (float)Math.Sin(Manager.speed));
                }
                if (Manager.orbitstwo)
                    Orbit.fancyorbit();

            }

            if (Manager.Respawn)
                items.respawnpickups();

            Arroworbit.arroworbit();
            Arroworbit.sovastica();



            if (settings.nconfig.pointlines)
            {

                if (Input.GetKey(KeyCode.Joystick1Button14) || Input.GetKey(KeyCode.LeftArrow))
                {
                    foreach (VRC.Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        try
                        {
                            if (gameObject != Extentions.LocalPlayer)
                            {
                                var lr = gameObject.transform.Find("LineManager").gameObject.GetComponent<LineRenderer>();
                                lr.endWidth = 0.001f;
                                lr.startWidth = 0.001f;
                                lr.SetPosition(0, Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupJointLeftHand").gameObject.transform.position);
                                lr.SetPosition(1, gameObject.transform.position);

                            }
                        }
                        catch { }
                    }
                }
                else if (Input.GetKey(KeyCode.Joystick2Button15) || Input.GetKey(KeyCode.RightArrow))
                {
                    foreach (VRC.Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        try
                        {
                            if (gameObject != Extentions.LocalPlayer)
                            {
                                var lr = gameObject.transform.Find("LineManager").gameObject.GetComponent<LineRenderer>();
                                lr.endWidth = 0.001f;
                                lr.startWidth = 0.001f;
                                lr.SetPosition(0, Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform.position);
                                lr.SetPosition(1, gameObject.transform.position);

                            }
                        }
                        catch { }
                    }

                }
                else
                {
                    foreach (VRC.Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        try
                        {
                            if (gameObject != Extentions.LocalPlayer)
                            {
                                var lra = gameObject.transform.Find("LineManager").gameObject.GetComponent<LineRenderer>();
                                lra.startWidth = 0;
                                lra.endWidth = 0;
                            }
                        }
                        catch { }
                    }

                }


            }



            if (settings.nconfig.DESKTOPUI)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Wrappers.Extentions.LocalPlayer.gameObject.GetComponent<VRC.Animation.VRCMotionState>().enabled = false;
                    Wrappers.Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
                    if (Apis.Desktopui.Main_page.menu != null)
                    {
                        Apis.Desktopui.Main_page.menu.transform.position = GameObject.Find("Camera (eye)").gameObject.transform.position;
                        Apis.Desktopui.Main_page.menu.transform.rotation = GameObject.Find("/_Application").transform.Find("TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck").transform.rotation;
                        Apis.Desktopui.Main_page.menu.SetActive(true);
                        patch.Patch.needscursor = true;
                        UiBase.Enabled = true;

                    }
                }
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    Wrappers.Extentions.LocalPlayer.gameObject.GetComponent<VRC.Animation.VRCMotionState>().enabled = true;
                    Wrappers.Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = true;
                    Apis.Desktopui.Main_page.menu.SetActive(false);
                    patch.Patch.needscursor = false;
                    UiBase.Enabled = false;

                }
            }


            Fly.fly();
            Exploits.freecam.freecams();
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
            {

                if (Exploits.sit.sitonparts.chest || Exploits.sit.sitonparts.head || Exploits.sit.sitonparts.hipss || Exploits.sit.sitonparts.leftindex || Exploits.sit.sitonparts.rightindex || Exploits.sit.sitonparts.Orbiting || !settings.MonoBehaviours.sitonpickups.sitonobj)
                {
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    Exploits.sit.sitonparts.chest = false;
                    Exploits.sit.sitonparts.hipss = false;
                    Exploits.sit.sitonparts.head = false;
                    Exploits.sit.sitonparts.leftindex = false;
                    Exploits.sit.sitonparts.rightindex = false;
                    Exploits.sit.sitonparts.Orbiting = false;
                    var iswrist = Extentions.LocalPlayer.GetVRCPlayer().GetAnimator().GetBoneTransform(HumanBodyBones.RightHand).gameObject;
                    GameObject.Destroy(iswrist.transform.Find("ArcticTouch").gameObject);
                    settings.MonoBehaviours.sitonpickups.sitonobj = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.Space) && settings.nconfig.Forcejump || Input.GetKeyDown(KeyCode.JoystickButton1) && settings.nconfig.Forcejump)
                Exploits.General.infjump();

            if (Input.GetKey(KeyCode.Space) && settings.nconfig.infiniteJump || Input.GetKey(KeyCode.JoystickButton1) && settings.nconfig.infiniteJump)
                Exploits.General.infjump();

            if (settings.nconfig.Keybinds)
            {

                if (settings.nconfig.customfov && Input.GetKey(KeyCode.Mouse2) && Input.GetKey(KeyCode.LeftControl))
                {
                    fov.resetfov();
                }

                if (Input.GetKeyDown(KeyCode.Mouse4))
                {

                    iszoomkey = false;
                    if (iszoomkey == false)
                    {
                        if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                        {
                            var gameobjhud = GameObject.Find("/UserInterface").transform.Find("PlayerDisplay/WorldHudDisplay/MenuMesh").gameObject;
                            gameobjhud.SetActive(false);
                            zoomvalue = settings.nconfig.Fov;
                            zoombooltoggle = true;

                        }


                    }
                }
                if (zoombooltoggle == true)
                {
                    if (zoomvalue <= 6)
                    {
                        zoomvalue = 6;
                        zoombooltoggle = false;
                        Camera.main.fieldOfView = zoomvalue;
                        GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().fieldOfView = zoomvalue;
                        return;
                    }
                    zoomvalue -= Time.deltaTime * 200;
                    Camera.main.fieldOfView = zoomvalue;
                }
                if (iszoomkey == false)
                {

                    if (Input.GetKeyUp(KeyCode.Mouse4))
                    {
                        if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                        {
                            zoombooltoggle = false;
                            var gameobjhud = GameObject.Find("/UserInterface").transform.Find("PlayerDisplay/WorldHudDisplay/MenuMesh").gameObject;
                            gameobjhud.SetActive(true);
                            var isperf = settings.nconfig.Fov;
                            GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().fieldOfView = settings.nconfig.Fov; ;
                            Camera.main.fieldOfView = isperf;

                            iszoomkey = true;
                        }

                    }
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Fly.flytoggle = !Fly.flytoggle;
                        Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = !Fly.flytoggle;
                    }


                    if (Input.GetKeyDown(KeyCode.T))
                    {

                        if (CachedCamBox != null)
                        {
                            UnityEngine.Object.Destroy(CachedCamBox);
                            CachedCamBox = null;
                            GameObject.Find("Camera (eye)").GetComponent<Camera>().enabled = true;
                            isthirdperson = false;
                            return;
                        }
                        isthirdperson = true;
                        iscmrgmj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        iscmrgmj.transform.localScale = GameObject.Find("Camera (eye)").transform.localScale;
                        Rigidbody rigidbody = iscmrgmj.AddComponent<Rigidbody>();
                        rigidbody.isKinematic = true;
                        rigidbody.useGravity = false;
                        if (iscmrgmj.GetComponent<Collider>())
                        {
                            iscmrgmj.GetComponent<Collider>().enabled = false;
                        }
                        iscmrgmj.GetComponent<Renderer>().enabled = false;
                        iscmrgmj.AddComponent<Camera>();
                        GameObject iscmrgmjtwo = GameObject.Find("Camera (eye)");
                        iscmrgmj.transform.parent = iscmrgmjtwo.transform;

                        iscmrgmj.transform.position = iscmrgmjtwo.transform.position;


                        iscmrgmj.transform.rotation = iscmrgmjtwo.transform.rotation;
                        iscmrgmj.transform.position -= iscmrgmj.transform.forward * 1.2f;
                        iscmrgmjtwo.GetComponent<Camera>().enabled = false;
                        iscmrgmj.GetComponent<Camera>().fieldOfView = 60f;
                        CachedCamBox = iscmrgmj;
                    }

                    if (isthirdperson)
                    {
                        if (Input.mouseScrollDelta.y == 1)
                        {
                            iscmrgmj.transform.GetComponent<Camera>().fieldOfView -= 5f;
                        }


                        if (Input.mouseScrollDelta.y == -1)
                        {
                            iscmrgmj.transform.GetComponent<Camera>().fieldOfView += 5f;
                        }
                    }

                    if (settings.nconfig.customfov)
                    {
                        if (Input.mouseScrollDelta.y == +1)
                        {
                            GameObject.Find("Camera (eye)").GetComponent<Camera>().fieldOfView -= 5;
                            GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().fieldOfView -= 5;
                        }

                        if (Input.GetKey(KeyCode.Mouse2))
                        {
                            fov.resetfov();
                        }


                        if (Input.mouseScrollDelta.y == -1)
                        {
                            GameObject.Find("Camera (eye)").GetComponent<Camera>().fieldOfView += 5;
                            GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().fieldOfView += 5;
                        }
                    }
                }
            }
        }


        private static void Runforms()
        {
            getusersinfo();

            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt") == string.Empty)
            {
                Style.Consoles.consolelogger("↓ Enter your key ↓");
                var keymsg = Console.ReadLine();
                settings.gethwid.getinfo(ref Main.load.sendauth);
                settings.gethwid.sendc(keymsg.Trim());
            }
            else
            {
                settings.gethwid.getinfo(ref Main.load.sendauth);
                settings.gethwid.sendc(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"));
            }


        }

        public static UIBase UiBase { get; set; }

        private static void MyModEntryPoint()
        {
            UniverseLib.Universe.Init(1f, Universe_OnInitialized, null, default);
        }

        private static void Universe_OnInitialized()
        {
            UiBase = UniversalUI.RegisterUI("Glowkingexplorerui", UiUpdate);
            UiBase.Enabled = false;

        }

        private static void UiUpdate()
        {
        }

    }
}
