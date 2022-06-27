using Arctic.Apis;
using Arctic.Apis.Buttons.qm;
using Arctic.Exploits;
using Arctic.Wrappers;
using MelonLoader;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;

namespace Arctic.Main.Loaders
{
    public class Loadqm
    {

        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static GameObject vrbtn;
        public static GameObject worldhistory;
        public static GameObject Worldudon;
        public static bool readyforudon = false;
        public static GameObject serchlist;
        public static TMPro.TextMeshProUGUI chattext;
        public static int msgcount = 0;
        public static UnityEngine.UI.Image imgg;
        private static IntPtr consolehwnd;
        private static GameObject jumpimpulsebutton;
        public static GameObject Avatarfavlist;
        public static GameObject AvatarHistory;
        public static GameObject playerlistqm;
        public static GameObject favtestbutt;
        public static Vector3 playerlatestvec3;
        public static Vector3 playerlatestlocaleulor;
        public static bool playerrejoinc = false;


        public static List<string> avilist = new List<string>();
        public static List<settings.avatarfav> getavifav()
        {
            var avis = JsonConvert.DeserializeObject<List<settings.avatarfav>>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json"));
            return avis;
        }
        public static void setupqm()
        {

            consolehwnd = GetConsoleWindow();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").gameObject.SetActive(false);
            var subms = submenu.Submenu("Arctic", null);
            var pg = Page.page("Arctic", subms);

            AvatarHistory = Apis.Avatars_fav.avilist("Seen In World");
            var cloneh = Apis.Buttons.button.Createbutton("Change", AvatarHistory.transform.Find("Button").gameObject, () =>
            {
                PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                {
                    id = Apis.Avatars_fav.avataridt2,
                };
                component.ChangeToSelectedAvatar(); ;
            });
        

            cloneh.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            cloneh.transform.localPosition = new Vector3(950, -5, 0);


            MelonCoroutines.Start(Apis.image.loadspriterest(pg.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>(), "https://api.glowking.net/cl/AC-logo.jpg"));
            if (settings.nconfig.Overwritetextcolor)
                pg.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

            pg.transform.Find("Icon").gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            MelonCoroutines.Start(Apis.image.LoadSpriteBetter(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Back Window/Logo").GetComponent<UnityEngine.UI.Image>(), "https://api.glowking.net/cl/AC-logo.jpg"));


            var fv = Apis.Avatars_fav.avilist("Arctic Favorites");
            Avatarfavlist = fv;

            var toinst = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favp_Arctic Favorites/Button/TitleText");
            var instanciate = GameObject.Instantiate(toinst, toinst.transform);
            instanciate.transform.localPosition = new Vector3(instanciate.transform.localPosition.x + 200, instanciate.transform.localPosition.y, instanciate.transform.localPosition.z);
            var unfav = Apis.Buttons.button.Createbutton("UnFavorite", fv.transform.Find("Button").gameObject, () =>
            {
                try
                {
                    string avis = "[";
                    var cda = getavifav();
                    if (cda.Count() == 1)
                    {
                        foreach (var avi in fv.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                        {
                            try
                            {
                                GameObject.Destroy(avi.gameObject);
                            }
                            catch { }
                        }
                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", string.Empty);
                        instanciate.GetComponent<UnityEngine.UI.Text>().text = "0";

                        return;
                    }



                    foreach (var abs in cda)
                    {


                        if (abs.AvatarId != Apis.Avatars_fav.avataridt)
                        {
                            var ab = new settings.avatarfav()
                            {
                                AvatarName = abs.AvatarName,

                                AvatarId = abs.AvatarId,

                                ImageUrl = abs.ImageUrl,

                                Platform = abs.Platform,

                            };
                            avis += $"{JsonConvert.SerializeObject(ab)},";

                        }
                        instanciate.GetComponent<UnityEngine.UI.Text>().text = $"-{cda.Count}-";
                    }
                    var acc = avis.Remove(avis.Length - 1);

                    File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", $"{acc}]");
                    foreach (var avi in fv.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                    {
                        try
                        {
                            GameObject.Destroy(avi.gameObject);
                        }
                        catch { }
                    }
                    foreach (var abs in getavifav())
                    {
                        Apis.Avatars_fav.createavi(fv, abs.AvatarId, abs.AvatarName, abs.ImageUrl, abs.Platform, 1);
                    }
                    instanciate.GetComponent<UnityEngine.UI.Text>().text = $"-{getavifav().Count}-";


                }
                catch { }

            });
            unfav.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            unfav.transform.localPosition = new Vector3(800, -5, 0);

            var fav = Apis.Buttons.button.Createbutton("Favorite", fv.transform.Find("Button").gameObject, () =>
            {


                //  File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", "");



                var avis = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json");

                var avia = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel").transform.gameObject.GetComponent<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0;
                // avia.Fetch();
                // if (!avis.Contains(avia.id))
                {
                    string abb = "";
                    var ab = new settings.avatarfav()
                    {
                        AvatarName = avia.name,

                        AvatarId = avia.id,

                        ImageUrl = avia.imageUrl,

                        Platform = avia.supportedPlatforms.ToString(),

                    };

                    if (avis == string.Empty)
                    {
                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", $"[{JsonConvert.SerializeObject(ab)}]");
                    }
                    else
                    {
                        abb += $"[{JsonConvert.SerializeObject(ab)},";
                        instanciate.GetComponent<UnityEngine.UI.Text>().text = $"-{getavifav().Count}-";
                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", avis.Replace("[", abb));
                    }

                    foreach (var avi in fv.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                    {
                        try
                        {
                            GameObject.Destroy(avi.gameObject);
                        }
                        catch { }
                    }
                    foreach (var abs in getavifav())
                    {
                        Apis.Avatars_fav.createavi(fv, abs.AvatarId, abs.AvatarName, abs.ImageUrl, abs.Platform, 1);
                    }
                    instanciate.GetComponent<UnityEngine.UI.Text>().text = $"-{getavifav().Count}-";

                }

            });
            fav.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            fav.transform.localPosition = new Vector3(650, -5, 0);

            var btn = Apis.Buttons.button.Createbutton("Change", fv.transform.Find("Button").gameObject, () =>
            {
                PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                {
                    id = Apis.Avatars_fav.avataridt,
                };
                component.ChangeToSelectedAvatar(); ;
            });

            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json") != string.Empty)
            {
                foreach (var abs in getavifav())
                {
                    Apis.Avatars_fav.createavi(fv, abs.AvatarId, abs.AvatarName, abs.ImageUrl, abs.Platform, 1);
                    instanciate.GetComponent<UnityEngine.UI.Text>().text = $"-{getavifav().Count}-";
                }
            }
            else
            {
                instanciate.GetComponent<UnityEngine.UI.Text>().text = "0";

            }


            btn.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            btn.transform.localPosition = new Vector3(950, -5, 0);

            var fav2 = Apis.Buttons.button.Createbutton("Favorite", AvatarHistory.transform.Find("Button").gameObject, () =>
            {

                if (Apis.Avatars_fav.curentgmj != null)
                {
                    try
                    {
                        if (Apis.Avatars_fav.curentgmj.transform.Find("TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text != null)
                        {
                            var avis = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json");
                            if (!avis.Contains(Apis.Avatars_fav.avataridt2))
                            {
                                //StandaloneWindows
                                //All
                                //Android
                                string abb = "";
                                string playform = "";
                                if (Apis.Avatars_fav.curentgmj.transform.Find("RoomImageShape/OverlayIcons/MobileIcons/IconPlatformPC").gameObject.activeSelf)
                                    playform = "StandaloneWindows";
                                else if (Apis.Avatars_fav.curentgmj.transform.Find("RoomImageShape/OverlayIcons/MobileIcons/IconPlatformAny").gameObject.activeSelf)
                                    playform = "All";
                                else
                                    playform = "Android";

                                var ab = new settings.avatarfav()
                                {
                                    AvatarName = Apis.Avatars_fav.curentgmj.transform.Find("TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text,

                                    AvatarId = Apis.Avatars_fav.avataridt2,

                                    ImageUrl = Apis.Avatars_fav.Image,

                                    Platform = playform,

                                };
                                if (avis == string.Empty)
                                {
                                    File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", $"[{JsonConvert.SerializeObject(ab)}]");
                                }
                                else
                                {
                                    abb += $"[{JsonConvert.SerializeObject(ab)},";
                                    instanciate.GetComponent<UnityEngine.UI.Text>().text = getavifav().Count.ToString();
                                    File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", avis.Replace("[", abb));
                                }

                                foreach (var avi in fv.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                                {
                                    try
                                    {
                                        GameObject.Destroy(avi.gameObject);
                                    }
                                    catch { }
                                }
                                foreach (var abs in getavifav())
                                {
                                    Apis.Avatars_fav.createavi(fv, abs.AvatarId, abs.AvatarName, abs.ImageUrl, abs.Platform, 1);
                                }
                                instanciate.GetComponent<UnityEngine.UI.Text>().text = getavifav().Count.ToString();

                            }
                        }
                    }
                    catch { }

                }

            });
            fav2.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            fav2.transform.localPosition = new Vector3(800, -5, 0);

            serchlist = Apis.Avatars_fav.avilist("Avi Search");
            var notbtn = Apis.Buttons.button.Createbutton("Search avi", serchlist.transform.Find("Button").gameObject, () =>
            {
                string abc = "";
                Apis.inputpopout.run("Author or Avatar name", value => abc = value, () =>
                {
                    var sendjson = new settings.sendsinglemsg()
                    {
                        Custommsg = abc,

                        code = "10",
                    };

                    connect.sendmsg(JsonConvert.SerializeObject(sendjson));

                });



            });
            var notbtn2 = Apis.Buttons.button.Createbutton("Search", serchlist.transform.Find("Button").gameObject, () =>
            {
                MelonCoroutines.Start(serchavi());
            });
            notbtn.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            notbtn.transform.localPosition = new Vector3(950, -5, 0);
            notbtn2.transform.localScale = new Vector3(0.9f, 0.8f, 0.9f);
            notbtn2.transform.localPosition = new Vector3(800, -5, 0);

            //Submenus


            // favtestbutt = Apis.Avatars_fav.createavi(serchlist, "test", "test", "test", "test", 1);
            //  favtestbutt.gameObject.SetActive(false);


            var buttonsq = Apis.Buttons.qm.Foldout.foldout("Buttons", subms);

            HalfButton.button("ReJoin", buttonsq, () =>
            {
                playerlatestvec3 = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                playerlatestlocaleulor = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;
                try
                {
                    var roomid = RoomManager.field_Internal_Static_ApiWorldInstance_0.id;
                    if (!Networking.GoToRoom(roomid))
                    {
                        string[] array = roomid.Split(':');
                        new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
                    }

                }

                catch { }

                playerrejoinc = true;

            });


            HalfButton.button("Close Game", buttonsq, () =>
            {
                try
                {

                    Process.GetCurrentProcess().Kill();
                }
                catch { }

            });

            HalfButton.button("Restart Game", buttonsq, () =>
            {
                try
                {

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
                catch
                {

                }
            });

            var Basemenu = submenu.Submenu("Base", subms);
            var Toggles = submenu.Submenu("Toggles", subms);
            var uia = submenu.Submenu("Ui", subms);
            var anticrashs = submenu.Submenu("Anti Crash", subms);
            var VrOnly = submenu.Submenu("Vr Only", subms);

            var Worldwexp = submenu.Submenu("World exploits", subms);
            worldhistory = submenu.Submenu("World History", subms);
            var Target = submenu.Submenu("Target", subms);
            var Amongus = submenu.Submenu("Among Us", Target);
            var Murder = submenu.Submenu("Murder", Target);
            var clientchat = submenu.Submenu("Client Chat", subms);

            var Misc = submenu.Submenu("Misc", subms);
            var Collision = submenu.Submenu("Collision", subms);

            var loggers = submenu.Submenu("Loggers", subms);
            /*   var Spotifyms = Apis.Buttons.qm.Foldout.foldout("Spotify", subms);

               //

                           Button.button("<-- Prev", Spotifyms, () =>
                           {


                           });
                           Button.button("Play / Pause", Spotifyms, () =>
                           {

                                var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                               IntPtr hwnd = proc.MainWindowHandle;
                               Style.Consoles.consolelogger(proc.MainWindowTitle);
                               SetForegroundWindow(hwnd);
                               PostMessage(hwnd, 0x100, 0x20, 0);


                   });
                           Button.button("Next -->", Spotifyms, () =>
                           {


                           });
               */



            var sliders = Foldout.foldout("Sliders", Basemenu, 2);
            Apis.Buttons.Sliders.slider(sliders, value => settings.nconfig.flyspeed = value, settings.nconfig.flyspeed, null, "Fly Speed");
            Apis.Buttons.Sliders.slider(sliders, value => settings.nconfig.walkspeed = value, settings.nconfig.walkspeed, null, "Walk Speed");
            var basef = Apis.Buttons.qm.Foldout.foldout("Base", subms);

            Submenubutton.submenu("Base", basef, Basemenu, "https://nocturnal-client.xyz/cl/icons/base.png");

            var linea = Apis.Buttons.qm.Foldout.foldout("Wolrd & Avi", Basemenu);

            Button.button("Change to Avi id", linea, () =>
            {
                try
                {
                    string aviid = "";
                    Apis.inputpopout.run("Avatar id", value => aviid = value, () =>
                    {
                        PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                        component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = aviid,
                        };
                        component.ChangeToSelectedAvatar();
                    });


                }

                catch
                {
                    Style.Consoles.consolelogger("Something Failed while changing avatars");
                }
            });

            Button.button("Join by id", linea, () =>
            {
                string roomid = "";
                Apis.inputpopout.run("Room Instance Id", value => roomid = value, () =>
                {
                    if (!Networking.GoToRoom(roomid))
                    {
                        string[] array = roomid.Split(':');
                        new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
                    }
                });

            });

            Button.button("Delet portal", linea, () =>
            {
                Exploits.General.deletportal();
            });

            var mirrortoggle = Apis.Buttons.qm.Toggles.toggle("Mirror", linea, () =>
            {
                Exploits.PortableMirror.ToggleMirror(true);

            }, () =>
            {
                Exploits.PortableMirror.ToggleMirror(false);

            }, null);




            var Movment = Apis.Buttons.qm.Foldout.foldout("Movement", Basemenu);


            var flyg = Apis.Buttons.qm.Toggles.toggle("Fly", Movment, () =>
            {
                if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                {
                    Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
                    Fly.flytoggle = true;
                }
            }, () =>
            {
                if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                {
                    Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = true;
                    Fly.flytoggle = false;
                }
            }, null);



            Apis.Buttons.qm.Toggles.toggle("Speed", Movment, () =>
            {
                Arctic.settings.nconfig.walkspeedt = true;
                speed.speedruntime();
            }, () =>
            {
                Arctic.settings.nconfig.walkspeedt = false;
                speed.speedruntime();

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Freecam", Movment, () =>
            {
                Exploits.freecam.isfreecam = true;
                Exploits.freecam.runcamera();
            }, () =>
            {
                Exploits.freecam.isfreecam = true;
                Exploits.freecam.runcamera();

            }, null);

            Apis.Buttons.qm.Toggles.toggle("UpsideDown", Movment, () =>
            {

                VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.rotation = new Quaternion(90f, 0f, 0f, 0f);
                VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += new Vector3(0f, 1.5f, 0f);
            }, () =>
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.rotation = new Quaternion(0, 0f, 0f, 0f);


            }, null);



            var esps = Apis.Buttons.qm.Foldout.foldout("ESP", Basemenu);



            Apis.Buttons.qm.Toggles.toggle("Esp Capsule", esps, () =>
            {
                Arctic.settings.nconfig.ESP = true;
                Arctic.Exploits.esp.espmethod();
            }, () =>
            {
                Arctic.settings.nconfig.ESP = false;
                Arctic.Exploits.esp.espmethod();
            }, (bool)Arctic.settings.nconfig.ESP);

            Apis.Buttons.qm.Toggles.toggle("Item Esp", esps, () =>
            {
                Arctic.settings.nconfig.itemesp = true;
                MelonCoroutines.Start(Arctic.Exploits.itemesp.itemsespref());
            }, () =>
            {
                Arctic.settings.nconfig.itemesp = false;
                MelonCoroutines.Start(Arctic.Exploits.itemesp.itemsespref());
            }, (bool)Arctic.settings.nconfig.itemesp);

            Apis.Buttons.qm.Toggles.toggle("Box Esp", esps, () =>
            {
                try
                {
                    settings.nconfig.Boxesp = true;
                    foreach (VRC.Player player in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        string rank = "";
                        Color color = Color.white;
                        MelonCoroutines.Start(AssetBundles.loadbox());

                        var gameObject = GameObject.Instantiate(AssetBundles.esp, player.gameObject.transform.Find("SelectRegion").transform);
                        Wrappers.check_ranks.gettrsutrank(player.field_Private_APIUser_0, ref rank, ref color);
                        var material = gameObject.transform.Find("default").GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
                        material.color = Color.black;
                        material.EnableKeyword("_EMISSION");
                        material.color = Color.black;
                        material.SetColor("_EmissionColor", color);

                    }
                }
                catch { }
            }, () =>
            {
                settings.nconfig.Boxesp = false;

                foreach (VRC.Player player in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    foreach (var abc in player.GetComponentsInChildren<Transform>(true))
                    {
                        if (abc.name.Contains("meds") && abc.transform.Find("default") != null)
                        {
                            GameObject.Destroy(abc.gameObject);
                        }
                    }
                }
            }, settings.nconfig.Boxesp);

            Apis.Buttons.qm.Toggles.toggle("Line Esp", esps, () =>
            {
                try
                {
                    settings.nconfig.Lineesp = true;
                    foreach (VRC.Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        gameObject.gameObject.AddComponent<Arctic.settings.MonoBehaviours.linerenderer>();
                    }
                }
                catch { }
            }, () =>
            {
                try
                {
                    foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                    {
                        settings.nconfig.Lineesp = false;
                        if (gameObject.name.Contains("Line") && gameObject.GetComponent<LineRenderer>() != null)
                        {
                            GameObject.Destroy(gameObject);
                        }
                    }
                }
                catch { }

            }, settings.nconfig.Lineesp);

            var esps2 = Apis.Buttons.qm.Foldout.foldout("ESP 2", Basemenu);

            Apis.Buttons.qm.Toggles.toggle("Bone Esp", esps2, () =>
            {
                try
                {
                    settings.nconfig.boneesp = true;
                    foreach (VRC.Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        if (gameObject != Extentions.LocalPlayer)
                            gameObject.gameObject.AddComponent<Arctic.settings.MonoBehaviours.bonesp>();
                    }
                }
                catch { }
            }, () =>
            {
                try
                {
                    foreach (VRC.Player gameObjecta in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        if (gameObjecta.GetComponent<settings.MonoBehaviours.bonesp>() != null)
                            Component.DestroyImmediate(gameObjecta.GetComponent<settings.MonoBehaviours.bonesp>());
                    }
                    foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                    {
                        settings.nconfig.boneesp = false;
                        if (gameObject.name.Contains("espline") && gameObject.GetComponent<LineRenderer>() != null)
                        {
                            if (gameObject != Extentions.LocalPlayer)
                                GameObject.Destroy(gameObject);
                        }

                    }
                }
                catch { }

            }, settings.nconfig.boneesp);

            Apis.Buttons.qm.Toggles.toggle("Hand Line Renderer", esps2, () =>
            {
                settings.nconfig.pointlines = true;
            }, () =>
            {
                settings.nconfig.pointlines = false;

            }, settings.nconfig.pointlines);

            Apis.Buttons.qm.Toggles.toggle("Avatar Outlines", esps2, () =>
            {
                settings.nconfig.avataroutlines = true;
                try
                {
                    foreach (VRC.Player gameObjecta in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        MelonCoroutines.Start(patch.Patch.runoutline(gameObjecta._vrcplayer, gameObjecta.transform.Find("ForwardDirection/Avatar").gameObject, true));
                    }
                }
                catch { }
            }, () =>
            {
                settings.nconfig.avataroutlines = false;
                try
                {
                    foreach (VRC.Player gameObjecta in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        MelonCoroutines.Start(patch.Patch.runoutline(gameObjecta._vrcplayer, gameObjecta.transform.Find("ForwardDirection/Avatar").gameObject, false));
                    }
                }
                catch { }
            }, settings.nconfig.avataroutlines);



            var freez = Apis.Buttons.qm.Foldout.foldout("Freez Or Fake lag", Basemenu);

            GameObject ac = null;
            Apis.Buttons.qm.Toggles.toggle("Ghost mode", freez, () =>
            {
                var negmj = new GameObject();
                ac = negmj;
                negmj.name = "Line";
                //negmj.layer = 19;
                string emptystirng = "";
                UnityEngine.Color overallcolor = UnityEngine.Color.red;
                var islinerend = negmj.AddComponent<LineRenderer>();
                islinerend.startWidth = 0.001f;
                islinerend.endWidth = 0.001f;
                islinerend.positionCount = 19;
                islinerend.startColor = UnityEngine.Color.white;
                islinerend.endColor = UnityEngine.Color.white;
                islinerend.useWorldSpace = true;
                var materials = islinerend.material = new Material(Shader.Find("Standard"));
                materials.EnableKeyword("_EMISSION");
                materials.SetColor("_EmissionColor", overallcolor);

                Animator anima = Wrappers.Extentions.LocalPlayer._vrcplayer.field_Internal_Animator_0;

                islinerend.SetPosition(0, anima.GetBoneTransform(HumanBodyBones.Head).transform.position);
                islinerend.SetPosition(1, anima.GetBoneTransform(HumanBodyBones.Neck).transform.position);
                islinerend.SetPosition(2, anima.GetBoneTransform(HumanBodyBones.Chest).transform.position);
                islinerend.SetPosition(3, anima.GetBoneTransform(HumanBodyBones.RightShoulder).transform.position);
                islinerend.SetPosition(4, anima.GetBoneTransform(HumanBodyBones.RightUpperArm).transform.position);
                islinerend.SetPosition(5, anima.GetBoneTransform(HumanBodyBones.RightLowerArm).transform.position);
                islinerend.SetPosition(6, anima.GetBoneTransform(HumanBodyBones.RightHand).transform.position);

                islinerend.SetPosition(7, anima.GetBoneTransform(HumanBodyBones.LeftShoulder).transform.position);
                islinerend.SetPosition(8, anima.GetBoneTransform(HumanBodyBones.LeftUpperArm).transform.position);
                islinerend.SetPosition(9, anima.GetBoneTransform(HumanBodyBones.LeftLowerArm).transform.position);
                islinerend.SetPosition(10, anima.GetBoneTransform(HumanBodyBones.LeftHand).transform.position);

                islinerend.SetPosition(11, anima.GetBoneTransform(HumanBodyBones.Spine).transform.position);
                islinerend.SetPosition(12, anima.GetBoneTransform(HumanBodyBones.Hips).transform.position);
                islinerend.SetPosition(13, anima.GetBoneTransform(HumanBodyBones.LeftUpperLeg).transform.position);
                islinerend.SetPosition(14, anima.GetBoneTransform(HumanBodyBones.LeftLowerLeg).transform.position);
                islinerend.SetPosition(15, anima.GetBoneTransform(HumanBodyBones.LeftFoot).transform.position);

                islinerend.SetPosition(16, anima.GetBoneTransform(HumanBodyBones.RightUpperLeg).transform.position);
                islinerend.SetPosition(17, anima.GetBoneTransform(HumanBodyBones.RightLowerLeg).transform.position);
                islinerend.SetPosition(18, anima.GetBoneTransform(HumanBodyBones.RightFoot).transform.position);

                patch.Patch.ghostmode = true;


            }, () =>
            {
                if (ac != null)
                {
                    try
                    {
                        GameObject.Destroy(ac);
                    }
                    catch { }
                }
                patch.Patch.ghostmode = false;


            }, null);

            Apis.Buttons.qm.Toggles.toggle("Fake Lag", freez, () =>
            {
                patch.Patch.fakelag = true;

            }, () =>
            {
                patch.Patch.fakelag = false;

            }, null);

            var Pedestals = Apis.Buttons.qm.Foldout.foldout("Pedestals & Udon", Basemenu);
            var itmman = Apis.Buttons.qm.Foldout.foldout("Items manipulator", Basemenu);


            Button.button("Change Avatars Pedestals", Pedestals, () =>
            {
                General.Pedestals();
            });

            Button.button("Udon Spam", Pedestals, () =>
            {
                Exploits.Udon.calleveryudon();
            });

            Apis.Buttons.qm.Toggles.toggle("T Orbit", Pedestals, () =>
            {

                Arroworbit.vec3poz = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                Arroworbit.Rotation = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;
                Arroworbit.arrowpoz = 3;

                Arroworbit.arroworbittoggle = true;


            }, () =>
            {
                Arroworbit.arroworbittoggle = false;

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Arrow Orbit X", itmman, () =>
            {

                Arroworbit.vec3poz = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                Arroworbit.Rotation = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;
                Arroworbit.arrowpoz = 0;

                Arroworbit.arroworbittoggle = true;


            }, () =>
            {
                Arroworbit.arroworbittoggle = false;

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Arrow Orbit Z", itmman, () =>
            {

                Arroworbit.vec3poz = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                Arroworbit.Rotation = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;
                Arroworbit.arrowpoz = 1;


                Arroworbit.arroworbittoggle = true;


            }, () =>
            {
                Arroworbit.arroworbittoggle = false;

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Arrow Orbit Y", itmman, () =>
            {

                Arroworbit.vec3poz = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                Arroworbit.Rotation = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;
                Arroworbit.arrowpoz = 2;


                Arroworbit.arroworbittoggle = true;


            }, () =>
            {
                Arroworbit.arroworbittoggle = false;

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Arrow Sovastica", itmman, () =>
            {

                Arroworbit.vec3poz = Wrappers.Extentions.LocalPlayer.gameObject.transform.position;
                Arroworbit.Rotation = Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles;


                Arroworbit.sovasticabool = true;


            }, () =>
            {
                Arroworbit.sovasticabool = false;

            }, null);

            ////////////////////////////////////////////////////////////

            var transform = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions").gameObject;

            Button.buttonan("Target", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                Wrappers.Target.targetuser(id);//\n
            });

            Button.buttonan("Teleport", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == id)
                    {
                        Loadui.lastusertargeted = player1;
                    }

                }
                Extentions.LocalPlayer.transform.position = Loadui.lastusertargeted.transform.position + new Vector3(0, 0.25f, 0);
            });


            //File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp"

            Button.buttonan("Add to Favorites", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                VRC.Player userss = null;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == id)
                    {
                        userss = player1;
                    }

                }


                var managetss = userss.prop_ApiAvatar_0;
                managetss.Fetch();
                if (managetss.releaseStatus != "public") return;
                var avis = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json");
                if (!avis.Contains(managetss.id))
                {
                    string abb = "";
                    var ab = new settings.avatarfav()
                    {
                        AvatarName = managetss.name,

                        AvatarId = managetss.id,

                        ImageUrl = managetss.imageUrl,

                        Platform = managetss.supportedPlatforms.ToString(),

                    };
                    if (avis == string.Empty)
                    {
                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", $"[{JsonConvert.SerializeObject(ab)}]");
                    }
                    else
                    {
                        abb += $"[{JsonConvert.SerializeObject(ab)},";
                        instanciate.GetComponent<UnityEngine.UI.Text>().text = getavifav().Count.ToString();
                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Avatars.json", avis.Replace("[", abb));
                    }



                    foreach (var avi in fv.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                    {
                        try
                        {
                            GameObject.Destroy(avi.gameObject);
                        }
                        catch { }
                    }
                    foreach (var abs in getavifav())
                    {
                        Apis.Avatars_fav.createavi(fv, abs.AvatarId, abs.AvatarName, abs.ImageUrl, abs.Platform, 1);
                    }
                    instanciate.GetComponent<UnityEngine.UI.Text>().text = getavifav().Count.ToString();

                }
            });


            Button.buttonan("Force Clone", transform.gameObject, () =>
            {
                try
                {
                    var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                    foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        if (player1.field_Private_APIUser_0.id == id)
                        {
                            Loadui.lastusertargeted = player1;
                        }

                    }
                    var aviid = Loadui.lastusertargeted.gameObject.GetComponent<VRCPlayer>().field_Private_ApiAvatar_0.id;
                    PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                    component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                    {
                        id = aviid
                    };
                    component.ChangeToSelectedAvatar();
                }

                catch
                {
                    Style.Consoles.consolelogger("Something Failed while force cloning");
                }
            });



            Button.buttonan("Copy id", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                System.Windows.Forms.Clipboard.SetText(id);
            });


            Button.buttonan("Whitelist Anticrash", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

                if (!File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp").Contains(id))
                {
                    File.AppendAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp", $"\n{id}");
                    settings.Anticrash.Anti.whitelist = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp");
                }

            });

            Button.buttonan("Remove Whitelist Anticrash", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

                if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp").Contains(id))
                {
                    var ac = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp");
                    var splited = ac.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    string becomingback = "";
                    for (int i = 0; i < splited.Length; i++)
                    {
                        var trimduser = splited[i].Trim();
                        if (trimduser != id)
                            becomingback += $"{trimduser}\n";
                    }
                    File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp", becomingback);

                    settings.Anticrash.Anti.whitelist = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\UserWhitelist.erp");
                }

            });


            Button.buttonan("Log Shaders", transform.gameObject, () =>
            {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == id)
                    {
                        string becomelist = $"User:[{player1.field_Private_APIUser_0.displayName}],  Avi A:[{player1.prop_ApiAvatar_0.authorName}], Avi N:[{player1.prop_ApiAvatar_0.name}], Avi Id:[{player1.prop_ApiAvatar_0.id}]\n";
                        foreach (var a in player1.gameObject.transform.Find("ForwardDirection/Avatar").GetComponentsInChildren<MeshRenderer>(true))
                        {
                            foreach (var acc in a.materials)
                            {
                                becomelist += $"[{a.gameObject.name}]:[{acc.shader.name}]\n";

                            }
                        }

                        foreach (var a in player1.gameObject.transform.Find("ForwardDirection/Avatar").GetComponentsInChildren<SkinnedMeshRenderer>(true))
                        {
                            foreach (var acc in a.materials)
                            {
                                becomelist += $"[{a.gameObject.name}]:[{acc.shader.name}]\n";

                            }
                        }

                        foreach (var a in player1.gameObject.transform.Find("ForwardDirection/Avatar").GetComponentsInChildren<ParticleSystemRenderer>(true))
                        {
                            foreach (var acc in a.materials)
                            {
                                becomelist += $"[{a.gameObject.name}]:[{acc.shader.name}]\n";

                            }
                        }


                        File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Shaderslogged\\{player1.prop_ApiAvatar_0.id}.txt", becomelist);
                        System.Diagnostics.Process.Start($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Shaderslogged\\{player1.prop_ApiAvatar_0.id}.txt");
                    }

                }
                //  Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Shaderslogged"
            });






            var fpsping = Apis.Buttons.qm.Foldout.foldout("Fps & Ping", Toggles);


            Apis.Buttons.qm.Toggles.toggle("Fps Spoof", fpsping, () =>
            {
                Arctic.settings.nconfig.spooffpstoog = true;


            }, () =>
            {
                Arctic.settings.nconfig.spooffpstoog = false;


            }, Arctic.settings.nconfig.spooffpstoog);


            Apis.Buttons.qm.Toggles.toggle("Ping Spoof", fpsping, () =>
            {
                Arctic.settings.nconfig.spofpngtogg = true;


            }, () =>
            {
                Arctic.settings.nconfig.spofpngtogg = false;


            }, Arctic.settings.nconfig.spofpngtogg);

            Button.button("Change Ping", fpsping, () =>
            {
                try
                {
                    Apis.inputpopout.run("Change Ping", value => settings.nconfig.spoofpng = int.Parse(value), () => MelonPreferences.Save());
                }
                catch { }
            });


            Button.button("Change Fps", fpsping, () =>
            {
                try
                {
                    Apis.inputpopout.run("Change Fps", value => settings.nconfig.spooffps = int.Parse(value), () => MelonPreferences.Save());
                }
                catch { }
            });



            var pickups = Apis.Buttons.qm.Foldout.foldout("Pick Ups", Toggles);

            Apis.Buttons.qm.Toggles.toggle("Pickup Max Range", pickups, () =>
            {
                Arctic.settings.nconfig.Maxpickuprange = true;


            }, () =>
            {
                Arctic.settings.nconfig.Maxpickuprange = false;


            }, Arctic.settings.nconfig.Maxpickuprange);

            Apis.Buttons.qm.Toggles.toggle("Pickup Max Range", pickups, () =>
            {
                patch.Patch.deletportals = true;

            }, () =>
            {
                Arctic.settings.nconfig.Maxpickuprange = false;


            }, Arctic.settings.nconfig.Maxpickuprange);

            Apis.Buttons.qm.Toggles.toggle("Steal Pickups", pickups, () =>
            {
                Arctic.settings.nconfig.stealpickup = true;


            }, () =>
            {
                Arctic.settings.nconfig.stealpickup = false;


            }, Arctic.settings.nconfig.stealpickup);


            Apis.Buttons.qm.Toggles.toggle("Pickable Pickups", pickups, () =>
            {
                Arctic.settings.nconfig.PickableItems = true;
                MelonCoroutines.Start(items.pickupinteract());

            }, () =>
            {
                Arctic.settings.nconfig.PickableItems = false;

            }, Arctic.settings.nconfig.PickableItems);

            var World = Apis.Buttons.qm.Foldout.foldout("World Related", Toggles);



            Apis.Buttons.qm.Toggles.toggle("Anti Portal", World, () =>
            {
                patch.Patch.deletportals = true;
                MelonCoroutines.Start(General.closeportal());

            }, () =>
            {
                patch.Patch.deletportals = false;


            }, false);


            Apis.Buttons.qm.Toggles.toggle("Udon Block", World, () =>
            {
                Arctic.settings.nconfig.UdonBlock = true;


            }, () =>
            {
                Arctic.settings.nconfig.UdonBlock = false;


            }, Arctic.settings.nconfig.UdonBlock);

            Apis.Buttons.qm.Toggles.toggle("Infinite Portals", World, () =>
            {
                Arctic.settings.nconfig.Infiniteportals = true;


            }, () =>
            {
                Arctic.settings.nconfig.Infiniteportals = false;


            }, Arctic.settings.nconfig.Infiniteportals);




            var keybind = Apis.Buttons.qm.Foldout.foldout("Keybinds", Toggles);




            Apis.Buttons.qm.Toggles.toggle("Infinite Jump", keybind, () =>
            {
                Arctic.settings.nconfig.infiniteJump = true;


            }, () =>
            {
                Arctic.settings.nconfig.infiniteJump = false;


            }, Arctic.settings.nconfig.infiniteJump);


            Apis.Buttons.qm.Toggles.toggle("KeyBinds", keybind, () =>
            {
                Arctic.settings.nconfig.Keybinds = true;

            }, () =>
            {
                Arctic.settings.nconfig.Keybinds = false;


            }, Arctic.settings.nconfig.Keybinds);

            Apis.Buttons.qm.Toggles.toggle("Force Jump", keybind, () =>
            {
                Arctic.settings.nconfig.Forcejump = true;


            }, () =>
            {
                Arctic.settings.nconfig.Forcejump = false;


            }, Arctic.settings.nconfig.Forcejump);

            Apis.Buttons.qm.Toggles.toggle("Custom Fov", keybind, () =>
            {
                Arctic.settings.nconfig.customfov = true;



            }, () =>
            {
                Arctic.settings.nconfig.customfov = false;


            }, Arctic.settings.nconfig.customfov);



            var Questst = Apis.Buttons.qm.Foldout.foldout("Misc", Toggles);



            Apis.Buttons.qm.Toggles.toggle("Hide Quest", Questst, () =>
            {
                Arctic.settings.nconfig.Questhide = true;
                General.hidequesties();


            }, () =>
            {
                Arctic.settings.nconfig.Questhide = false;
                General.hidequesties();


            }, Arctic.settings.nconfig.Questhide);

            Apis.Buttons.qm.Toggles.toggle("Restart on update", Questst, () =>
            {
                Arctic.settings.nconfig.Restartu = true;

            }, () =>
            {
                Arctic.settings.nconfig.Restartu = false;


            }, Arctic.settings.nconfig.Restartu);

            Apis.Buttons.qm.Toggles.toggle("Custom Aspect Ratio", Questst, () =>
            {
                settings.nconfig.customaspectratio = true;
                GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>().aspect = settings.nconfig.aspectrationvalue;
                GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().aspect = settings.nconfig.aspectrationvalue;


            }, () =>
            {
                settings.nconfig.customaspectratio = false;
                GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>().aspect = 1.8165f;
                GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().aspect = 1.8165f;

            }, settings.nconfig.customaspectratio);

            Button.button("Aspect Ration Value", Questst, () =>
            {
                try
                {
                    Apis.inputpopout.run("Aspect Ratio value", value => settings.nconfig.aspectrationvalue = float.Parse(value), () => { GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>().aspect = settings.nconfig.aspectrationvalue; GameObject.Find("Camera (eye)").transform.Find("StackedCamera : Cam_InternalUI").gameObject.GetComponent<Camera>().aspect = settings.nconfig.aspectrationvalue; });
                }
                catch { }
            });
            var Images = Apis.Buttons.qm.Foldout.foldout("Images & Shit", uia);

            Apis.Buttons.qm.Toggles.toggle("Join Audio", Images, () =>
            {
                Arctic.settings.nconfig.JoinSound = true;

            }, () =>
            {
                Arctic.settings.nconfig.JoinSound = false;


            }, Arctic.settings.nconfig.JoinSound);

            Apis.Buttons.qm.Toggles.toggle("Nameplates info", Images, () =>
            {
                Arctic.settings.nconfig.Nameplates = true;

                try
                {
                    foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        player1.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate/Performance Text").gameObject.SetActive(true);
                    }
                }
                catch { }
            }, () =>
            {
                Arctic.settings.nconfig.Nameplates = false;

                try
                {
                    foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        player1.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate/Performance Text").gameObject.SetActive(false);
                    }
                }
                catch { }
            }, Arctic.settings.nconfig.Nameplates);





            Apis.Buttons.qm.Toggles.toggle("Qm Music", Images, () =>
            {
                settings.nconfig.Qmmusic = true;
                try
                {
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<AudioSource>().enabled = true;
                }
                catch
                {

                }

            }, () =>
            {
                settings.nconfig.Qmmusic = false;

                try
                {
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<AudioSource>().enabled = false;

                }
                catch
                {

                }

            }, settings.nconfig.Qmmusic);


            Apis.Buttons.qm.Toggles.toggle("Custom Mic Icon", Images, () =>
            {
                settings.nconfig.custommic = true;
            }, () =>
            {
                settings.nconfig.custommic = false;
            }, settings.nconfig.custommic);


            var pld = Apis.Buttons.qm.Foldout.foldout("Player List & Debugger & Gui", uia);

            Apis.Buttons.qm.Toggles.toggle("Gui pannels", pld, () =>
            {
                Arctic.settings.nconfig.playerlistgui = true;


            }, () =>
            {
                Arctic.settings.nconfig.playerlistgui = false;


            }, Arctic.settings.nconfig.playerlistgui);

            Apis.Buttons.qm.Toggles.toggle("Player List qm", pld, () =>
            {
                Arctic.settings.nconfig.Playerlist = true;
                gettgl(true);

            }, () =>
            {
                Arctic.settings.nconfig.Playerlist = false;
                gettgl(false);



            }, Arctic.settings.nconfig.Playerlist);

            Apis.Buttons.qm.Toggles.toggle("Debugger", pld, () =>
            {
                Arctic.settings.nconfig.debugger = true;
                getdebug(true);

            }, () =>
            {
                Arctic.settings.nconfig.debugger = false;
                getdebug(false);


            }, Arctic.settings.nconfig.debugger);

            Apis.Buttons.qm.Toggles.toggle("Arctic Notifcation", pld, () =>
            {
                Arctic.settings.nconfig.onscreennotification = true;
            }, () =>
            {
                Arctic.settings.nconfig.onscreennotification = false;
                try
                {
                    Style.Uichanges.notification.gameObject.SetActive(false);
                }
                catch { }

            }, Arctic.settings.nconfig.onscreennotification);

            //                

            var buttons = Apis.Buttons.qm.Foldout.foldout("Buttons", uia);

            Apis.Buttons.qm.Toggles.toggle("Qm Buttons Color", buttons, () =>
            {
                settings.StyleConfig.backgoundbuttons = true;
            }, () =>
            {
                settings.StyleConfig.backgoundbuttons = false;
            }, settings.StyleConfig.backgoundbuttons);

            Apis.Buttons.qm.Toggles.toggle("Hud Info", buttons, () =>
            {
                settings.nconfig.fpsandstuffinfo = true;
                try
                {
                    Style.Uichanges.infofps.gameObject.SetActive(true);
                }
                catch { }

            }, () =>
            {
                settings.nconfig.fpsandstuffinfo = false;
                try
                {
                    Style.Uichanges.infofps.gameObject.SetActive(false);

                }
                catch { }

            }, settings.nconfig.fpsandstuffinfo);






            Apis.Buttons.qm.Toggles.toggle("Disable Console", buttons, () =>
            {
                settings.nconfig.DisableConsole = true;
                ShowWindow(consolehwnd, 0);
            }, () =>
            {
                settings.nconfig.DisableConsole = false;
                ShowWindow(consolehwnd, 5);
            }, settings.nconfig.DisableConsole);

            Apis.Buttons.qm.Toggles.toggle("Qm Info pannel", buttons, () =>
            {
                settings.nconfig.qmextinfo = true;
                try
                {
                    Style.Image.infopanneltext.transform.parent.parent.gameObject.SetActive(true);
                }
                catch { }
            }, () =>
            {
                settings.nconfig.qmextinfo = false;
                try
                {
                    Style.Image.infopanneltext.transform.parent.parent.gameObject.SetActive(false);
                }
                catch { }
            }, settings.nconfig.qmextinfo);






            var lsv = Apis.Buttons.qm.Foldout.foldout("Loading Screen & Discord", uia);
            Apis.Buttons.qm.Toggles.toggle("Loading Screen Video", lsv, () =>
            {
                Arctic.settings.nconfig.Videoplayer = true;

            }, () =>
            {
                Arctic.settings.nconfig.Videoplayer = false;


            }, Arctic.settings.nconfig.Videoplayer);

            Apis.Buttons.qm.Toggles.toggle("Big Video", lsv, () =>
            {
                Arctic.settings.nconfig.BigVideoLoadingscreen = true;

            }, () =>
            {
                Arctic.settings.nconfig.BigVideoLoadingscreen = false;


            }, Arctic.settings.nconfig.BigVideoLoadingscreen);





            var mayneedres = Apis.Buttons.qm.Foldout.foldout("Need restart", uia);


            Apis.Buttons.qm.Toggles.toggle("Nameplates Image & Color", mayneedres, () => settings.nconfig.NamePlatesuichange = true, () => settings.nconfig.NamePlatesuichange = false, settings.nconfig.NamePlatesuichange);

            Apis.Buttons.qm.Toggles.toggle("Desktop Ui", mayneedres, () => settings.nconfig.DESKTOPUI = true, () => settings.nconfig.DESKTOPUI = false, settings.nconfig.DESKTOPUI);


            Apis.Buttons.qm.Toggles.toggle("Big Ui Rain", mayneedres, () => settings.nconfig.rainbackground = true, () => settings.nconfig.rainbackground = false, settings.nconfig.rainbackground);

            Apis.Buttons.qm.Toggles.toggle("Big Ui User info", mayneedres, () => settings.nconfig.BigUichanges = true, () => settings.nconfig.BigUichanges = false, settings.nconfig.BigUichanges);

            var needsrest = Apis.Buttons.qm.Foldout.foldout("Need restart 2", uia);

            Apis.Buttons.qm.Toggles.toggle("Qm Style", needsrest, () => settings.nconfig.Qmuitstyle = true, () => settings.nconfig.Qmuitstyle = false, settings.nconfig.Qmuitstyle);

            Apis.Buttons.qm.Toggles.toggle("Overwrite qm Colors", needsrest, () => settings.nconfig.Overwritetextcolor = true, () => settings.nconfig.Overwritetextcolor = false, settings.nconfig.Overwritetextcolor);

            Apis.Buttons.qm.Toggles.toggle("On User Qm Extra info", needsrest, () => settings.nconfig.onqmuserinfo = true, () => settings.nconfig.onqmuserinfo = false, settings.nconfig.onqmuserinfo);

            var favlist = Apis.Buttons.qm.Foldout.foldout("Favorites", uia);
            Apis.Buttons.qm.Toggles.toggle("Favortites", favlist, () => { Avatarfavlist.SetActive(true); settings.nconfig.Favortielistenabled = true; serchlist.SetActive(true); }, () => { Avatarfavlist.gameObject.SetActive(false); settings.nconfig.Favortielistenabled = false; serchlist.SetActive(false); }, settings.nconfig.Favortielistenabled);
            Apis.Buttons.qm.Toggles.toggle("Seen In World", favlist, () => { Main.Loaders.Loadqm.AvatarHistory.SetActive(true); settings.nconfig.Avatarsseeninworld = true; }, () => { Main.Loaders.Loadqm.AvatarHistory.SetActive(false); settings.nconfig.Avatarsseeninworld = false; }, settings.nconfig.Avatarsseeninworld);

            var targetusr = Apis.Buttons.qm.Foldout.foldout("Main", Target);


            Button.button("Teleport", targetusr, () =>
            {
                if (Wrappers.Target.istargetd != null)
                    General.teleport(Wrappers.Target.istargetd);
            });

            Button.button("Tp Pickups", targetusr, () =>
            {
                if (Wrappers.Target.istargetd != null)
                    items.bringpickups(Wrappers.Target.istargetd);
            });


            Button.button("Sit on Head", targetusr, () =>
            {
                MelonCoroutines.Start(Exploits.sit.sitonparts.sitonhead());
            });

            Apis.Buttons.qm.Toggles.toggle("Spam head", targetusr, () =>
            {
                items.isspamhead = true;
            }, () =>
            {
                items.isspamhead = false;

            }, false);

            var Sit = Apis.Buttons.qm.Foldout.foldout("Sit Stuff", Target);

            Button.button("Sit on Left arm", Sit, () =>
            {
                MelonCoroutines.Start(Exploits.sit.sitonparts.sitonleftarm());
            });

            Button.button("Sit on Right arm", Sit, () =>
            {
                MelonCoroutines.Start(Exploits.sit.sitonparts.rightarm());
            });

            Button.button("Sit on Chest", Sit, () =>
            {
                MelonCoroutines.Start(Exploits.sit.sitonparts.Chest());
            });

            Button.button("Sit on Hips", Sit, () =>
            {
                MelonCoroutines.Start(Exploits.sit.sitonparts.hips());
            });

            var Misca = Apis.Buttons.qm.Foldout.foldout("Misc", Target);

            Apis.Buttons.qm.Toggles.toggle("Copy Voice", Misca, () =>
            {
                patch.Patch.copyvoice = true;
            }, () =>
            {
                patch.Patch.copyvoice = false;

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Copy IK", Misca, () =>
            {
                Networking.LocalPlayer.gameObject.GetComponent<VRC.Networking.FlatBufferNetworkSerializer>().enabled = false;
                patch.Patch.IKC = true;
            }, () =>
            {
                Networking.LocalPlayer.gameObject.GetComponent<VRC.Networking.FlatBufferNetworkSerializer>().enabled = true;
                patch.Patch.IKC = false;

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Copy 3.0 Needs same avi", Misca, () =>
            {
                patch.Patch.copy3toggles = true;
            }, () =>
            {
                patch.Patch.copy3toggles = false;

            }, false);

            var Orbits = Apis.Buttons.qm.Foldout.foldout("Orbit", Target);


            Apis.Buttons.qm.Toggles.toggle("Pickup orbit", Orbits, () =>
            {
                Manager.orbits = true;
            }, () =>
            {
                Manager.orbits = false;

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Pickup orbit 2", Orbits, () =>
            {
                Manager.orbitstwo = true;
            }, () =>
            {
                Manager.orbitstwo = false;

            }, false);



            Apis.Buttons.qm.Toggles.toggle("Orbit Player", Orbits, () =>
            {
                Exploits.sit.sitonparts.Orbiting = true;
                Physics.gravity = new Vector3(0, 0, 0);
            }, () =>
            {
                Exploits.sit.sitonparts.Orbiting = false;
                Physics.gravity = new Vector3(0, -9.81f, 0);
            }, false);


            var Amongsus = Apis.Buttons.qm.Foldout.foldout("Among us", Target);
            Button.button("Make Impostor", Amongsus, () =>
            {
                MelonCoroutines.Start(ontargetgames.MakeImpostor());
            });

            Button.button("Make Bystander", Amongsus, () =>
            {
                MelonCoroutines.Start(ontargetgames.bystander());
            });

            Button.button("Eject", Amongsus, () =>
            {
                MelonCoroutines.Start(ontargetgames.Eject());
            });

            Button.button("Kill", Amongsus, () =>
            {
                MelonCoroutines.Start(ontargetgames.Kill());
            });
            var Murderpg = Apis.Buttons.qm.Foldout.foldout("Murder Buttons 1", Target);

            Button.button("Make Murder", Murderpg, () =>
            {
                MelonCoroutines.Start(ontargetgames.Murder());
            });

            Button.button("Make Bystander", Murderpg, () =>
            {
                MelonCoroutines.Start(ontargetgames.bystander());
            });

            Button.button("Make Detective", Murderpg, () =>
            {
                MelonCoroutines.Start(ontargetgames.detective());
            });

            Button.button("Kill", Murderpg, () =>
            {
                MelonCoroutines.Start(ontargetgames.Kill());
            });

            var Murderpg1 = Apis.Buttons.qm.Foldout.foldout("Murder Buttons 2", Target);

            Button.button("Flash", Murderpg1, () =>
            {
                MelonCoroutines.Start(ontargetgames.Flashb());
            });

            Apis.Buttons.qm.Toggles.toggle("Knife Shiel", Murder, () =>
            {
                ontargetgames.knifeshield = true;
                MelonCoroutines.Start(ontargetgames.KnifeShieldss());

            }, () =>
            {
                ontargetgames.knifeshield = false;
                MelonCoroutines.Start(ontargetgames.KnifeShieldss());

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Trap Shield", Murderpg1, () =>
            {
                ontargetgames.trapshield = true;
                MelonCoroutines.Start(ontargetgames.trapshields());

            }, () =>
            {
                ontargetgames.trapshield = false;
                MelonCoroutines.Start(ontargetgames.KnifeShieldss());

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Explode Head", Murderpg1, () =>
            {
                More_murder.bombspam = true;
                MelonCoroutines.Start(More_murder.bombhead());

            }, () =>
            {
                More_murder.bombspam = false;
                MelonCoroutines.Start(More_murder.bombhead());

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Explode Circle", Murderpg1, () =>
            {
                More_murder.bombspamc = true;
                MelonCoroutines.Start(More_murder.bombexplodes());

            }, () =>
            {
                More_murder.bombspamc = false;
                MelonCoroutines.Start(More_murder.bombexplodes());

            }, false);

            var submenus = Apis.Buttons.qm.Foldout.foldout("Sub Menus", Worldwexp);
            Worldudon = submenu.Submenu("Udon events", Worldwexp);
            var AmongusW = submenu.Submenu("Among Us", Worldwexp);
            var MurderW = submenu.Submenu("Murder", Worldwexp);
            Submenubutton.submenu("Among Us", submenus, AmongusW);
            Submenubutton.submenu("Murder", submenus, MurderW);
            var events = Submenubutton.submenu("Udon Events", submenus, Worldudon);
            //   events.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => MelonCoroutines.Start(patch.Patch.runudon())));

            var prisonb = submenu.Submenu("Prison Escape", Worldwexp);
            Submenubutton.submenu("Prison Escape", submenus, prisonb);


            var psb = Apis.Buttons.qm.Foldout.foldout("Row 1", prisonb);
            Button.button("Kill All", psb, () =>
            {
                Udon.udoneveryobj("Damage200");
            });

            Button.button("Shoot all gunsl", psb, () =>
            {
                Udon.udoneveryobj("StartGunEffects");
            });

            Button.button("Enable everyone patron", psb, () =>
            {
                Udon.udoneveryobj("EnablePatronEffects");
            });

            Button.button("Disable everyone patreon", psb, () =>
            {
                Udon.udoneveryobj("DisablePatronEffects");
            });

            var psb2 = Apis.Buttons.qm.Foldout.foldout("Row 2", prisonb);

            Button.button("Go back to the game", psb2, () =>
            {
                Udon.sendlocalevent(GameObject.Find("/Scripts").transform.Find("Game Manager").gameObject, "_StartGame");
            });

            Button.button("Take Keycard", psb2, () =>
            {
                Udon.sendlocalevent(GameObject.Find("/Scripts").transform.Find("Game Manager").gameObject, "_TakeKeycard");
            });
            //StartGameCountdown





            var Amonguss = Apis.Buttons.qm.Foldout.foldout("Game Related", AmongusW);
            Button.button("Skip votes", Amonguss, () =>
            {
                mogus.Skipvotes();
            });

            Button.button("Force start", Amonguss, () =>
            {
                mogus.ForceStart();
            });

            Button.button("Force Abort", Amonguss, () =>
            {
                mogus.ForceAbort();
            });
            Button.button("Finish Votes", Amonguss, () =>
            {
                mogus.FinishVotes();
            });
            var Playerss = Apis.Buttons.qm.Foldout.foldout("Players Related", AmongusW);
            Button.button("Kill All", Playerss, () =>
            {
                mogus.Killall();
            });


            Button.button("All Impostors", Playerss, () =>
            {
                mogus.amongsusallmurd();
            });
            Button.button("Finish Tasks", Playerss, () =>
            {
                mogus.Finishtasks();
            });

            var Teamwin = Apis.Buttons.qm.Foldout.foldout("Teams Related", AmongusW);
            Button.button("Eject All", Teamwin, () =>
            {
                mogus.ejecteveryone();
            });

            Button.button("Impostor Win", Teamwin, () =>
            {
                mogus.ImpostorWin();
            });

            Button.button("Cewmate Win", Teamwin, () =>
            {
                mogus.CewmateWin();
            });

            var Sabotage = Apis.Buttons.qm.Foldout.foldout("Sabotage 1", AmongusW);
            Button.button("Electric", Sabotage, () =>
            {
                mogus.Electric();
            });
            Button.button("Oxygen", Sabotage, () =>
            {
                mogus.Oxygen();
            });

            Button.button("Reactor", Sabotage, () =>
            {
                mogus.Reactor();
            });

            Button.button("Coms", Sabotage, () =>
            {
                mogus.Coms();
            });
            var sabt = Apis.Buttons.qm.Foldout.foldout("Rest", AmongusW);

            Button.button("Doors", sabt, () =>
            {
                mogus.SbDoors();
            });


            Button.button("Sabotage All", sabt, () =>
            {
                mogus.allsabotage();
            });

            Button.button("Repair All", sabt, () =>
            {
                mogus.Repall();
            });

            Apis.Buttons.qm.Toggles.toggle("God Mode", sabt, () =>
            {
                patch.Patch.Godmode = true;
            }, () =>
            {
                patch.Patch.Godmode = false;
            }, false);

            var Teams = Apis.Buttons.qm.Foldout.foldout("Teams Related", MurderW);

            Button.button("Bystander Win", Teams, () =>
            {
                Exploits.Murder.BystanderW();
            });

            Button.button("Murder Win", Teams, () =>
            {
                Exploits.Murder.Murderw();
            });

            Button.button("Murder All", Teams, () =>
            {
                Exploits.Murder.murderevry();
            });
            Button.button("FFA", Teams, () =>
            {
                Exploits.Murder.murdergame();
            });
            var plsa = Apis.Buttons.qm.Foldout.foldout("Players Related", MurderW);
            Button.button("Kill All", plsa, () =>
            {
                Exploits.Murder.Killall();
            });
            Button.button("Blind All", plsa, () =>
            {
                Exploits.Murder.blindall();
            });
            Button.button("Find Clues", plsa, () =>
            {
                Exploits.Murder.findclues();
            });
            Button.button("Unlock Mini Game", plsa, () =>
            {
                Exploits.Murder.unlockminigame();
            });
            var gam = Apis.Buttons.qm.Foldout.foldout("Game Related", MurderW);
            Button.button("Force Abort", gam, () =>
            {
                Exploits.Murder.forceabort();
            });

            Button.button("Force Start", gam, () =>
            {
                Exploits.Murder.forcestart();
            });
            Button.button("Toggle lights", gam, () =>
            {
                Exploits.Murder.closelights();
            });
            var objs = Apis.Buttons.qm.Foldout.foldout("Objects Related", MurderW);
            Button.button("Shoot Revolver", objs, () =>
            {
                Exploits.Murder.shootweapon();
            });

            Button.button("Realease Snake", objs, () =>
            {
                Exploits.Murder.realeasesnake();
            });


            Button.button("Tp To Revolver", objs, () =>
            {
                Exploits.Murder.tprev();
            });
            var Miscmurder = Apis.Buttons.qm.Foldout.foldout("Misc", MurderW);
            Button.button("D game started", Miscmurder, () =>
            {
                Exploits.Murder.fcstart();
            });

            Button.button("Open Shelfs", Miscmurder, () =>
            {
                Exploits.Murder.open();
            });

            Button.button("Close Shelfs", Miscmurder, () =>
            {
                Exploits.Murder.close();
            });

            Button.button("Trigger", Miscmurder, () =>
            {
                Exploits.Murder.trigger();
            });
            var extoggles = Apis.Buttons.qm.Foldout.foldout("Extra Toggles", MurderW);

            Apis.Buttons.qm.Toggles.toggle("God Mode", extoggles, () =>
            {
                patch.Patch.Godmode = true;

            }, () =>
            {
                patch.Patch.Godmode = false;


            }, false);

            Apis.Buttons.qm.Toggles.toggle("Murder Wallhack", extoggles, () =>
            {
                Exploits.Murder.Murderwallhack = true;
                MelonCoroutines.Start(Exploits.Murder.getimpostor());
            }, () =>
            {
                Exploits.Murder.Murderwallhack = false;
                MelonCoroutines.Start(Exploits.Murder.getimpostor());
            }, false);

            Apis.Buttons.qm.Toggles.toggle("Doors Coliders", extoggles, () =>
            {
                Exploits.Murder.doorscold = true;
                MelonCoroutines.Start(Exploits.Murder.toggledoorcolideroff());
            }, () =>
            {
                Exploits.Murder.doorscold = false;
                MelonCoroutines.Start(Exploits.Murder.toggledoorcolideroff());
            }, false);
            var buttonsworld = Apis.Buttons.qm.Foldout.foldout("Toggles", Worldwexp);
            Apis.Buttons.qm.Toggles.toggle("Respawn Loop", buttonsworld, () =>
            {
                Manager.Respawn = true;
            }, () =>
            {
                Manager.Respawn = false;

            }, false);

            Apis.Buttons.qm.Toggles.toggle("Item Owner", buttonsworld, () =>
            {
                items.ownertr = true;
            }, () =>
            {
                items.ownertr = false;

            }, null);

            Apis.Buttons.qm.Toggles.toggle("Rotate Items", buttonsworld, () =>
            {
                items.rotates = true;
            }, () =>
            {
                items.rotates = false;
            }, false);
            var buttonsnottog = Apis.Buttons.qm.Foldout.foldout("Buttons", Worldwexp);
            Button.button("Respawn Items", buttonsnottog, () =>
            {
                items.respawnpickups();
            });

            Button.button("Bring Items", buttonsnottog, () =>
            {
                items.bringpickups(Extentions.LocalPlayer);
            });
            var optzloops = Apis.Buttons.qm.Foldout.foldout("Optimized loops", Worldwexp);

            Apis.Buttons.qm.Toggles.toggle("Respawn Loop Optimize", optzloops, () =>
            {
                items.Respawnloopopt = true;
                MelonCoroutines.Start(items.respawnloop());
            }, () =>
            {
                items.Respawnloopopt = false;
            }, false);

            Apis.Buttons.qm.Toggles.toggle("Owner Loop Optimize", optzloops, () =>
            {
                items.ownererp = true;
                MelonCoroutines.Start(items.ownerloop());
            }, () =>
            {
                items.ownererp = false;
            }, false);
            var jumpinf = Apis.Buttons.qm.Foldout.foldout("Jump", Worldwexp);

            jumpimpulsebutton = Arctic.Apis.Buttons.qm.Button.buttonan("Jump Impules", jumpinf, () =>
            {
                try
                {

                    Apis.inputpopout.run("Set Jump Impules", value => settings.nconfig.JumpIMpulse = float.Parse(value), () => Networking.LocalPlayer.SetJumpImpulse(settings.nconfig.JumpIMpulse));

                }
                catch { }
            });


            //Collision
            var misc = Apis.Buttons.qm.Foldout.foldout("Misc", subms);

            Submenubutton.submenu("Collision", misc, Collision, "https://nocturnal-client.xyz/cl/icons/colider.png");

            var boombs = Apis.Buttons.qm.Foldout.foldout("Bomb", Collision);



            ////////////////////////////////////////////////////////////

            Submenubutton.submenu("Toggles", basef, Toggles, "https://nocturnal-client.xyz/cl/icons/toggles.png");
            Submenubutton.submenu("World Exploits", basef, Worldwexp, "https://nocturnal-client.xyz/cl/icons/world.png");
            Submenubutton.submenu("Target", basef, Target, "https://nocturnal-client.xyz/cl/icons/crosshair.png");
            Submenubutton.submenu("World History", misc, worldhistory, "https://nocturnal-client.xyz/cl/icons/worldh.png");
            var btnsub = Submenubutton.submenu("Chat", misc, clientchat, "https://nocturnal-client.xyz/cl/icons/whatsapp.png");
            Apis.Buttons.qm.Button.button("Save Configs", misc, () =>
            {
                settings.StyleConfig.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");
                settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json");
                Style.Consoles.consolelogger("Saved Config");
            }, "https://nocturnal-client.xyz/cl/icons/save%20config,png.png");

            btnsub.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() =>
            {
                var btn = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Nocturnal/Badge");
                btn.gameObject.SetActive(false);
                msgcount = 0;
                btn.transform.Find("Text_QM_H5").GetComponent<TMPro.TextMeshProUGUI>().text = $"{msgcount} NEW";
                Style.Uichanges.notification.gameObject.SetActive(false);

            }));



            var chatbtn = Button.button("Chat", clientchat, () =>
            {
                sendmessagetoserver();
            });
            var passdetc = HalfButton.button("Log IN", clientchat, () =>
            {
                string pass = "";
                Apis.inputpopout.run("Enter Your Password", value => pass = value, () =>
                {
                    File.WriteAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt", pass);

                });

            });
            var message = HalfButton.button("Send message", clientchat, () =>
            {
                sendmessagetoserver();

            });
            string username = string.Empty;
            string password = "";

            var Register = HalfButton.button("Register Username", clientchat, () =>
            {

                Apis.inputpopout.run("Enter The Username U want", value => username = value, () =>
                {

                });
            });
            var Register2 = HalfButton.button("Register Password", clientchat, () =>
            {
                if (username != string.Empty)
                {
                    Apis.inputpopout.run("Enter The Password U want", value => password = value, () =>
                    {

                        if (username.Length < 2)
                        {
                            Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>UserName Need at least 2c</color>");
                            return;
                        }
                        if (password.Length < 3)
                        {
                            Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>Password Need at least 3c</color>");
                            return;

                        }
                        settings.gethwid.getinfo(ref Main.load.sendauth);
                        var a = new settings.Setpassword()
                        {
                            Key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),
                            Hwid = Main.load.sendauth,
                            Password = password,
                            User = username,
                            code = "13"
                        };

                        string js = $"{Newtonsoft.Json.JsonConvert.SerializeObject(a)}";

                        connect.sendmsg(js);
                    });
                }
                else
                {
                    Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>U Need to set the name first.</color>");

                }


            });




            Component.DestroyImmediate(chatbtn.gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            GameObject.DestroyImmediate(chatbtn.transform.Find("Icon").gameObject);
            passdetc.transform.localPosition = new Vector3(240f, -845.6021f, 0);
            message.transform.localPosition = new Vector3(-240f, -845.6021f, 0);
            Register.transform.localPosition = new Vector3(0, -845.6021f, 0);
            Register2.transform.localPosition = new Vector3(0, -954, 0);
            var insteanciated = GameObject.Instantiate(chatbtn.transform.Find("Background"), chatbtn.transform.Find("Background").transform);

            chatbtn.transform.Find("Background").gameObject.AddComponent<UnityEngine.UI.Mask>();
            MelonCoroutines.Start(Apis.image.loadspriterest(chatbtn.transform.Find("Background").gameObject.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mask.png"));
            insteanciated.name = "Image";

            MelonCoroutines.Start(Apis.image.loadspriterest(chatbtn.transform.Find("Background/Image").gameObject.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.Chatmsg));

            imgg = chatbtn.transform.Find("Background/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
            chatbtn.transform.Find("Background/Image").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.3f, 0.3f, 0.3f, 0.8f);
            chatbtn.gameObject.transform.localScale = new Vector3(4.6f, 3.6f, 1f);
            chatbtn.gameObject.transform.localPosition = new Vector3(0f, -467, 0);
            chattext = chatbtn.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Component.DestroyImmediate(chattext.gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            chattext.fontSize = 50;
            chattext.text = "";
            chattext.maxVisibleLines = 18;
            chattext.m_maxVisibleLines = 18;
            chattext.enableWordWrapping = false;
            chattext.gameObject.transform.localScale = new Vector3(0.1f, 0.14f, 1);
            chattext.gameObject.transform.localPosition = new Vector3(-84.7001f, 54f, 0);
            chattext.alignment = TMPro.TextAlignmentOptions.TopLeft;
            var insttitle = GameObject.Instantiate(chattext.gameObject, chattext.transform.parent);
            insttitle.transform.localScale = new Vector3(0.2f, 0.26f, 1);
            insttitle.transform.localPosition = new Vector3(-76f, 68.1341f, 0);
            insttitle.GetComponent<TMPro.TextMeshProUGUI>().text = "<color=#ab053a>N</color><color=#7d0028>o</color><color=#5e001e>t</color><color=#400014>u</color><color=#2e000f>r</color><color=#241117>n</color><color=#292325>a</color><color=#0d0d0d>l </color><color=#660121>Chat";
            insttitle.GetComponent<TMPro.TextMeshProUGUI>().enableWordWrapping = false;
            var Discord2 = submenu.Submenu("Discord", subms);
            var Tags = submenu.Submenu("Tags", subms);

            var customize = Apis.Buttons.qm.Foldout.foldout("Customzie", subms);
            Submenubutton.submenu("Ui", customize, uia, "https://nocturnal-client.xyz/cl/icons/uiicon.png");
            Submenubutton.submenu("Loggers", customize, loggers, "https://nocturnal-client.xyz/cl/icons/Bell.png");
            Submenubutton.submenu("Discord", customize, Discord2, "https://nocturnal-client.xyz/cl/Discord.png");
            Submenubutton.submenu("Tags", customize, Tags, "https://nocturnal-client.xyz/cl/icons/Tag.png");










            var AntiCrash = Apis.Buttons.qm.Foldout.foldout("Anti Crash & Vr", subms);


            Submenubutton.submenu("Anti Crash", AntiCrash, anticrashs, "https://nocturnal-client.xyz/cl/icons/anti.png");


            var anr1 = Foldout.foldout("Row 1", anticrashs);

            Apis.Buttons.qm.Toggles.toggle("Shader", anr1, () => settings.nconfig.ShaderP = true, () => settings.nconfig.ShaderP = false, settings.nconfig.ShaderP);
            Apis.Buttons.qm.Toggles.toggle("Meshes", anr1, () => settings.nconfig.meshp = true, () => settings.nconfig.meshp = false, settings.nconfig.meshp);
            Apis.Buttons.qm.Toggles.toggle("Audio Sources", anr1, () => settings.nconfig.audiosourcep = true, () => settings.nconfig.audiosourcep = false, settings.nconfig.audiosourcep);
            Apis.Buttons.qm.Toggles.toggle("Verticies", anr1, () => settings.nconfig.verticiesp = true, () => settings.nconfig.verticiesp = false, settings.nconfig.verticiesp);

            var anr2 = Foldout.foldout("Row 2", anticrashs);

            Apis.Buttons.qm.Toggles.toggle("Particles", anr2, () => settings.nconfig.particlep = true, () => settings.nconfig.particlep = false, settings.nconfig.particlep);
            Apis.Buttons.qm.Toggles.toggle("Line Render", anr2, () => settings.nconfig.linerenderp = true, () => settings.nconfig.linerenderp = false, settings.nconfig.linerenderp);
            Apis.Buttons.qm.Toggles.toggle("Lights", anr2, () => settings.nconfig.lightsp = true, () => settings.nconfig.lightsp = false, settings.nconfig.lightsp);
            Apis.Buttons.qm.Toggles.toggle("Self Anti", anr2, () => settings.nconfig.selfanti = true, () => settings.nconfig.selfanti = false, settings.nconfig.selfanti);







            var anticrow1 = Foldout.foldout("Row 3", anticrashs);
            var anticrow2 = Foldout.foldout("Row 4", anticrashs);
            GameObject b1 = null;
            b1 = Button.button($"Max Materials\n[{settings.nconfig.maxmaterials}]", anticrow1, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Materials", value => settings.nconfig.maxmaterials = int.Parse(value), () => b1.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                    $"Max Materials\n[{settings.nconfig.maxmaterials}]");
                }
                catch { }
            });

            GameObject b2 = null;
            b2 = Button.button($"Max Particles\n[{settings.nconfig.maxparticles}]", anticrow1, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Particles", value => settings.nconfig.maxparticles = int.Parse(value), () => b2.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                    $"Max Particles\n[{settings.nconfig.maxparticles}]");
                }
                catch { }
            });

            GameObject b3 = null;
            b3 = Button.button($"Max Particles Systems\n[{settings.nconfig.particlesystem}]", anticrow1, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Particles Systems", value => settings.nconfig.particlesystem = int.Parse(value), () => b3.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                    $"Max Particles Systems\n[{settings.nconfig.particlesystem}]");
                }
                catch { }
            });

            GameObject b4 = null;
            b4 = Button.button($"Max Audio Sources\n[{settings.nconfig.maxaudiosources}]", anticrow1, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Audio Sources", value => settings.nconfig.maxaudiosources = int.Parse(value), () => b4.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                    $"Max Audio Sources\n[{settings.nconfig.maxaudiosources}]");
                }
                catch { }
            });

            GameObject b5 = null;
            b5 = Button.button($"Max Verticies\n[{settings.nconfig.maxverticies}]", anticrow2, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Verticies", value => settings.nconfig.maxverticies = int.Parse(value), () => b5.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                    $"Max Verticies\n[{settings.nconfig.maxverticies}]");
                }
                catch { }
            });

            GameObject b6 = null;
            b6 = Button.button($"Max Meshes\n[{settings.nconfig.maxmeshes}]", anticrow2, () =>
            {
                try
                {
                    Apis.inputpopout.run($"Max Meshes", value => settings.nconfig.maxmeshes = int.Parse(value), () =>
                    {
                        b6.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                      $"Max Meshes\n[{settings.nconfig.maxmeshes}]";
                    });
                }
                catch { }
            });

            vrbtn = Submenubutton.submenu("Vr Only", AntiCrash, VrOnly, "https://nocturnal-client.xyz/cl/icons/vricon.png");

            var vronly = Foldout.foldout("Row 1", VrOnly, 2);
            float value1 = 0;
            float value2 = 0;

            Apis.Buttons.Sliders.slider(vronly, value => value1 = value * 180, value1, () =>
            {

                GameObject.Find("/_Application").transform.Find("TrackingVolume/TrackingSteam(Clone)").gameObject.transform.localEulerAngles = new Vector3(value1, 0, 0);

            }, "X");
            Apis.Buttons.Sliders.slider(vronly, value => value2 = value * 180, value2, () =>
            {
                GameObject.Find("/_Application").transform.Find("TrackingVolume/TrackingSteam(Clone)").gameObject.transform.localEulerAngles = new Vector3(0, 0, value2);
            }, "Z");

            /*var anticrow1 = Foldout.foldout("Row 1", anticrashs, 2);
            var acs = Apis.Buttons.Sliders.slider(anticrow1, value => settings.nconfig.maxmaterials = (int)Math.Round(value) * 150, settings.nconfig.maxmaterials / 150, () => { }, "Max Materials",true, 150f);
            
            Apis.Buttons.Sliders.slider(anticrow1, value => settings.nconfig.maxmeshes = (int)Math.Round(value), settings.nconfig.maxmeshes, () => Style.Consoles.consolelogger("T"), "Max Meshes");

            var anticrow2 = Foldout.foldout("Row 2", anticrashs, 2);
            Apis.Buttons.Sliders.slider(anticrow2, value => settings.nconfig.maxparticles = (int)Math.Round(value), settings.nconfig.maxparticles, () => Style.Consoles.consolelogger("T"), "Max Particles");

            Apis.Buttons.Sliders.slider(anticrow2, value => settings.nconfig.particlesystem = (int)Math.Round(value), settings.nconfig.particlesystem, () => Style.Consoles.consolelogger("T"), "Max Particle Systems");

            var anticrow3 = Foldout.foldout("Row 3", anticrashs, 2);
            Apis.Buttons.Sliders.slider(anticrow2, value => settings.nconfig.maxaudiosources = (int)Math.Round(value), settings.nconfig.maxaudiosources, () => Style.Consoles.consolelogger("T"), "Max Audio Sources");

            Apis.Buttons.Sliders.slider(anticrow2, value => settings.nconfig.maxverticies = (int)Math.Round(value), settings.nconfig.maxverticies, () => Style.Consoles.consolelogger("T"), "Max Verticies");
            */





            var row1tags = Foldout.foldout("Row 1", Tags);
            Apis.Buttons.qm.Button.button("Add Tag", row1tags, () =>
            {
                string becometag = "";
                //connect.sendmsg(becometag)

                Apis.inputpopout.run("Enter a custom tag", value => becometag = value, () =>
                {

                    var tobecomestring = "";

                    if (becometag.Contains("[color=") || becometag.Contains("[i]") || becometag.Contains("[b]"))
                    {
                        var substrg = becometag.Split(new string[] { "[color=" }, System.StringSplitOptions.None);
                        foreach (var sub in substrg)
                        {

                            if (sub.Length > 0)
                            {
                                if (sub.Length > 7 && sub[7] == ']')
                                {
                                    var becmstr = sub.Remove(7, 1);
                                    tobecomestring += $"<color={becmstr.Insert(7, ">")}";
                                }
                                else
                                {
                                    tobecomestring += sub;
                                }



                            }

                        }
                        tobecomestring = tobecomestring.Replace("[/color]", "</color>");

                        if (tobecomestring.Contains("[b]"))
                            tobecomestring = tobecomestring.Replace("[b]", "<b>");

                        if (tobecomestring.Contains("[/b]"))
                            tobecomestring = tobecomestring.Replace("[/b]", "</b>");

                        if (tobecomestring.Contains("[i]"))
                            tobecomestring = tobecomestring.Replace("[i]", "<i>");

                        if (tobecomestring.Contains("[/i]"))
                            tobecomestring = tobecomestring.Replace("[/i]", "</i>");


                        var tosendtag2 = new settings.sendtag()
                        {
                            userid = APIUser.CurrentUser.id,
                            addnewtagtouser = tobecomestring,
                            key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),
                            password = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"),
                            code = "6",
                        };
                        connect.sendmsg($"{JsonConvert.SerializeObject(tosendtag2)}");
                        return;
                    }

                    var tosendtag = new settings.sendtag()
                    {
                        userid = APIUser.CurrentUser.id,
                        addnewtagtouser = becometag,
                        key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),
                        password = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"),
                        code = "6",
                    };
                    connect.sendmsg($"{JsonConvert.SerializeObject(tosendtag)}");
                });
            });

            //customnameplates
            Apis.Buttons.qm.Button.button("Remove All Tags", row1tags, () =>
            {

                if (waitformsgtime)
                {
                    MelonCoroutines.Start(waitfotime());
                    waitformsgtime = false;
                    var tosendtag = new settings.removealltags()
                    {
                        abouttoremovealltagskey = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),
                        password = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"),
                        code = "7",
                    };
                    connect.sendmsg($"{JsonConvert.SerializeObject(tosendtag)}");
                }
                else
                    Style.textdebuger.OnscreenOnly("Wait for the timer to go down", "Wait for the timer to go down");

            });
            Apis.Buttons.qm.Button.button("Move tags to curentuser", row1tags, () =>
            {
                if (waitformsgtime)
                {
                    MelonCoroutines.Start(waitfotime());
                    waitformsgtime = false;
                    var tosendtag = new settings.movetagstotuser()
                    {
                        userid = APIUser.CurrentUser.id,
                        tomovetagstouserkey = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),
                        password = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"),
                        code = "8",
                    };
                    connect.sendmsg($"{JsonConvert.SerializeObject(tosendtag)}");
                }
                else
                    Style.textdebuger.OnscreenOnly("Wait for the timer to go down", "Wait for the timer to go down");
            });
            Apis.Buttons.qm.Toggles.toggle("Toggle Tags platest", row1tags, () => settings.nconfig.customnameplates = true, () => settings.nconfig.customnameplates = false, settings.nconfig.customnameplates);


            Style.textdebuger.ChatMsg("Client", "<color=#ffffffff>Hi, Here u will see the msg's from other players.</color>");

            var Row1disc = Foldout.foldout("Row 1", Discord2);

            Apis.Buttons.qm.Toggles.toggle("Discord Rich presence", Row1disc, () =>
            {
                Arctic.settings.nconfig.DiscordRich = true;

                Arctic.Discord.DiscordManager.Init();
            }, () =>
            {
                Arctic.settings.nconfig.DiscordRich = false;


                DiscordRpc.Shutdown();
            }, Arctic.settings.nconfig.DiscordRich);


            Apis.Buttons.qm.Button.button("Custom Image", Row1disc, () =>
            {
                string becomimg = "";
                //connect.sendmsg(becometag)

                Apis.inputpopout.run("Enter The Image Url", value => becomimg = value, () =>
                {
                    settings.StyleConfig.discordrpcimg = becomimg;
                    Discord.DiscordManager.presence.largeImageKey = settings.StyleConfig.discordrpcimg;
                    DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);
                });
            });


            var disc2 = Apis.Buttons.qm.Foldout.foldout("Row 2", Discord2);


            Apis.Buttons.qm.Toggles.toggle("Custom Text Over Both", disc2, () =>
            {
                settings.nconfig.istextoverboth = true;
                Discord.DiscordManager.presence.details = settings.nconfig.putyourowntext;
                DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);
            }, () =>
            {
                settings.nconfig.istextoverboth = false;

                Discord.DiscordManager.presence.details = $"{APIUser.CurrentUser.displayName}.";
                DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            }, settings.nconfig.istextoverboth);

            Button.button("Custom Text", disc2, () =>
            {
                Apis.inputpopout.run("Custom Text", value => settings.nconfig.putyourowntext = value, () =>
                {
                    if (settings.nconfig.istextoverboth)
                    {
                        Discord.DiscordManager.presence.details = $"{settings.nconfig.putyourowntext}";
                        DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);
                    }

                });

            });





            Button.button("Bomb", boombs, () =>
            {
                Exploits.Bomb.Tpbomb();
            });

            Button.button("Player Bomb", boombs, () =>
            {
                Exploits.Bomb.createbomb();
            });

            var HandRelated = Apis.Buttons.qm.Foldout.foldout("Hand Related", Collision);

            Apis.Buttons.qm.Toggles.toggle("Sit on Objects", HandRelated, () =>
            {
                try
                {
                    var iswrist = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    iswrist.name = "ArcticTouch";
                    iswrist.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    iswrist.transform.parent = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    iswrist.transform.localPosition = new Vector3(0, 0, 0);
                    iswrist.AddComponent<settings.MonoBehaviours.sitonpickups>();
                    iswrist.AddComponent<Rigidbody>().isKinematic = true;
                    iswrist.GetComponent<MeshRenderer>().enabled = false;
                    iswrist.layer = 2;
                    settings.MonoBehaviours.sitonpickups.sitonobj = true;
                }
                catch
                {

                }

            }, () =>
            {
                try
                {
                    var iswrist = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    GameObject.Destroy(iswrist.transform.Find("ArcticTouch").gameObject);
                    settings.MonoBehaviours.sitonpickups.sitonobj = false;
                }
                catch
                {

                }
            }, false);




            Apis.Buttons.qm.Toggles.toggle("Item Gravity", HandRelated, () =>
            {
                try
                {
                    var iswrist = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    iswrist.name = "ArcticlTouch";
                    iswrist.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    iswrist.transform.parent = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;

                    iswrist.transform.localPosition = new Vector3(0, 0, 0);
                    iswrist.AddComponent<settings.MonoBehaviours.touchpickups>();
                    iswrist.AddComponent<Rigidbody>().isKinematic = true;
                    iswrist.GetComponent<MeshRenderer>().enabled = false;
                    iswrist.layer = 2;
                }
                catch
                {

                }
            }, () =>
            {
                try
                {
                    var iswrist = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    GameObject.Destroy(iswrist.transform.Find("ArcticTouch").gameObject);
                }
                catch
                {

                }
            }, false);

            Apis.Buttons.qm.Toggles.toggle("Target", HandRelated, () =>
            {
                try
                {

                    var iswrist = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    iswrist.name = "ArcticTouch";
                    iswrist.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    iswrist.transform.parent = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    iswrist.transform.localPosition = new Vector3(0, 0, 0);
                    iswrist.AddComponent<settings.MonoBehaviours.Targettouch>();
                    iswrist.AddComponent<Rigidbody>().isKinematic = true;
                    iswrist.GetComponent<MeshRenderer>().enabled = false;
                    iswrist.layer = 2;

                }
                catch
                {

                }
            }, () =>
            {
                try
                {
                    var iswrist = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    GameObject.Destroy(iswrist.transform.Find("ArcticTouch").gameObject);
                }
                catch
                {

                }
            }, false);


            Apis.Buttons.qm.Toggles.toggle("Murder <- -> touch", HandRelated, () =>
            {
                try
                {
                    var iswrist = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    iswrist.name = "ArcticTouch";
                    iswrist.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    iswrist.transform.parent = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    iswrist.transform.localPosition = new Vector3(0, 0, 0);
                    iswrist.AddComponent<Arctic.settings.MonoBehaviours.touchstuff>();
                    iswrist.AddComponent<Rigidbody>().isKinematic = true;
                    iswrist.GetComponent<MeshRenderer>().enabled = false;
                    iswrist.layer = 2;
                }
                catch
                {

                }
            }, () =>
            {
                try
                {
                    var iswrist = Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").gameObject.transform;
                    GameObject.Destroy(iswrist.transform.Find("ArcticTouch").gameObject);
                }
                catch
                {

                }
            }, false);

            var Chose = Apis.Buttons.qm.Foldout.foldout("Chose Action", Collision);

            Button.button("Bystander", Chose, () =>
            {
                Arctic.settings.MonoBehaviours.touchstuff.actionforontap = "SyncAssignB";
            });

            Button.button("Murder", Chose, () =>
            {
                Arctic.settings.MonoBehaviours.touchstuff.actionforontap = "SyncAssignM";
            });

            Button.button("Detective", Chose, () =>
            {
                Arctic.settings.MonoBehaviours.touchstuff.actionforontap = "SyncAssignD";
            });

            Button.button("Kill", Chose, () =>
            {
                Arctic.settings.MonoBehaviours.touchstuff.actionforontap = "SyncKill";
            });






            gmjlist.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_Build/Background");
            gmjlist.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_Ping/Background");
            gmjlist.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_FPS/Background");
            gmjlist.Add("Canvas_QuickMenu(Clone)/Container/Window/MicButton");
            gmjlist.Add("Canvas_QuickMenu(Clone)/Container/Window/Toggle_SafeMode");

            gmjlist2.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_NameplateControls/Background");
            gmjlist2.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Mic");
            gmjlist2.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio");
            gmjlist2.Add("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/QMCell_InstanceDetails/Panel/PanelBG");


            if (settings.StyleConfig.backgoundbuttons)
            {
                foreach (var ab in gmjlist2)
                {

                    Component.Destroy(GameObject.Find("/UserInterface").transform.Find(ab).gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                }
            }
            changeuicolors();

            var Togglesss = Apis.Buttons.qm.Foldout.foldout("Toggles", loggers);
            Apis.Buttons.qm.Toggles.toggle("Screen Logger", Togglesss, () =>
            {
                Arctic.settings.nconfig.ScreenLogger = true;


            }, () =>
            {
                Arctic.settings.nconfig.ScreenLogger = false;


            }, Arctic.settings.nconfig.ScreenLogger);

            Apis.Buttons.qm.Toggles.toggle("Join Notifications", Togglesss, () =>
            {
                settings.nconfig.joinnot = true;
            }, () =>
            {
                settings.nconfig.joinnot = false;
            }, settings.nconfig.joinnot);


            Apis.Buttons.qm.Toggles.toggle("Log Udon", Togglesss, () =>
            {
                Arctic.settings.nconfig.logudon = true;


            }, () =>
            {
                Arctic.settings.nconfig.logudon = false;


            }, Arctic.settings.nconfig.logudon);

            Apis.Buttons.qm.Toggles.toggle("Log Photon", Togglesss, () =>
            {
                Arctic.settings.nconfig.logphotonev = true;


            }, () =>
            {
                Arctic.settings.nconfig.logphotonev = false;


            }, Arctic.settings.nconfig.logphotonev);

            var Consolelog = Apis.Buttons.qm.Foldout.foldout("Console log", loggers);

            Apis.Buttons.qm.Toggles.toggle("Log In Console", Consolelog, () =>
            {
                Arctic.settings.nconfig.loginconssole = true;


            }, () =>
            {
                Arctic.settings.nconfig.loginconssole = false;


            }, Arctic.settings.nconfig.loginconssole);

            Apis.Buttons.qm.Toggles.toggle("Log Local Udon", Consolelog, () =>
            {
                patch.Patch.loglocal = true;


            }, () =>
            {
                patch.Patch.loglocal = false;


            }, patch.Patch.loglocal);

            Apis.Buttons.qm.Toggles.toggle("Log Shaders", Consolelog, () =>
            {
                settings.nconfig.logshaderstoconsole = true;


            }, () =>
            {
                settings.nconfig.logshaderstoconsole = false;


            }, settings.nconfig.logshaderstoconsole);

            var Photonevtolog = Apis.Buttons.qm.Foldout.foldout("Photon Logger Events", loggers);


            Apis.Buttons.qm.Toggles.toggle("Event 1", Photonevtolog, () =>
            {
                Arctic.settings.nconfig.ev1 = true;


            }, () =>
            {
                Arctic.settings.nconfig.ev1 = false;


            }, Arctic.settings.nconfig.ev1);

            Apis.Buttons.qm.Toggles.toggle("Event 6", Photonevtolog, () =>
            {
                Arctic.settings.nconfig.ev6 = true;


            }, () =>
            {
                Arctic.settings.nconfig.ev6 = false;


            }, Arctic.settings.nconfig.ev6);


            Apis.Buttons.qm.Toggles.toggle("Event 7", Photonevtolog, () =>
            {
                Arctic.settings.nconfig.ev7 = true;


            }, () =>
            {
                Arctic.settings.nconfig.ev7 = false;


            }, Arctic.settings.nconfig.ev7);


            Apis.Buttons.qm.Toggles.toggle("Event 9", Photonevtolog, () =>
            {
                Arctic.settings.nconfig.ev9 = true;


            }, () =>
            {
                Arctic.settings.nconfig.ev9 = false;


            }, Arctic.settings.nconfig.ev9);
            readyforudon = true;


            var gmjss = Arctic.Apis.Buttons.qm.Wings.Wingmenu.createmenu("Arcticl", Prefabs.LeftWingMenu.transform.parent.gameObject, Prefabs.LeftWingMenu);

            Arctic.Apis.Buttons.qm.Wing.button("Nocturanl 📁", GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup").gameObject,
            () =>
            {
                gmjss.SetActive(true);
                Prefabs.LeftWingMenu.gameObject.SetActive(false);
            });

            Arctic.Apis.Buttons.qm.Wing.button("Save Config", GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup").gameObject,
            () =>
            {
                settings.StyleConfig.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");
                settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json"); Style.Consoles.consolelogger("Saved Config");
            });

            var playerlist = Arctic.Apis.Buttons.qm.Wings.Wingmenu.createmenuright("Arctic", Prefabs.Rightwing.transform.parent.gameObject, Prefabs.Rightwing);
            playerlistqm = playerlist.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup").gameObject;

            Arctic.Apis.Buttons.qm.Wing.button("Player List 📁", GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup").gameObject,
            () =>
            {
                playerlist.SetActive(true);
                Prefabs.Rightwing.gameObject.SetActive(false);

            });



            var btnholder = gmjss.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup").gameObject;
            bool mirrtog = false;

            Arctic.Apis.Buttons.qm.Wing.button("Mirror", btnholder,
            () =>
            {
                mirrtog = !mirrtog;
                Exploits.PortableMirror.ToggleMirror(mirrtog);


                changetext(btnholder.transform.Find("Wingbtn_Mirror").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
    mirrtog, "Mirror");


            });
            changetext(btnholder.transform.transform.Find("Wingbtn_Mirror").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            mirrortoggle.gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn, "Mirror");
            bool switcah = false;
            Arctic.Apis.Buttons.qm.Wing.button("Fly", btnholder,
            () =>
            {
                switcah = !switcah;

                if (switcah)
                {
                    if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                    {
                        Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
                        Fly.flytoggle = true;
                    }
                }
                else
    if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
                {
                    Extentions.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = true;
                    Fly.flytoggle = false;
                }



                changetext(btnholder.transform.Find("Wingbtn_Fly").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
      switcah, "Fly");


            });
            changetext(btnholder.transform.Find("Wingbtn_Fly").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            flyg.gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn, "Fly");

            wingbtn = Arctic.Apis.Buttons.qm.Wing.button("Jump Imp", btnholder,
            () =>
            {

                try
                {

                    Apis.inputpopout.run("Set Jump Impules", value => settings.nconfig.JumpIMpulse = float.Parse(value), () => Networking.LocalPlayer.SetJumpImpulse(settings.nconfig.JumpIMpulse));

                }
                catch { }

            });



            Arctic.Apis.Buttons.qm.Wing.button("Esp", btnholder,
            () =>
            {
                settings.nconfig.ESP = !settings.nconfig.ESP;
                Arctic.Exploits.esp.espmethod();
                changetext(btnholder.transform.Find("Wingbtn_Esp").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
    settings.nconfig.ESP, "Esp");
            });
            changetext(btnholder.transform.transform.Find("Wingbtn_Esp").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            settings.nconfig.ESP, "Esp");


            Arctic.Apis.Buttons.qm.Wing.button("Hide Quest", btnholder,
            () =>
            {
                Arctic.settings.nconfig.Questhide = !Arctic.settings.nconfig.Questhide;
                General.hidequesties();

                changetext(btnholder.transform.Find("Wingbtn_Hide Quest").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
    Arctic.settings.nconfig.Questhide, "Hide Quest");
            });
            changetext(btnholder.transform.transform.Find("Wingbtn_Hide Quest").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            Arctic.settings.nconfig.Questhide, "Hide Quest");




            Arctic.Apis.Buttons.qm.Wing.button("Udon Block", btnholder,
            () =>
            {
                Arctic.settings.nconfig.UdonBlock = !Arctic.settings.nconfig.UdonBlock;


                changetext(btnholder.transform.Find("Wingbtn_Udon Block").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
    Arctic.settings.nconfig.UdonBlock, "Udon Block");
            });
            changetext(btnholder.transform.transform.Find("Wingbtn_Udon Block").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>(),
            Arctic.settings.nconfig.UdonBlock, "Udon Block");

            Arctic.Apis.Buttons.qm.Wing.button("Udon Spam", btnholder,
            () =>
            {
                Exploits.Udon.calleveryudon();

            });

            Arctic.Apis.Buttons.qm.Wing.button("Respawn Items", btnholder,
            () =>
            {
                items.respawnpickups();


            });

            Arctic.Apis.Buttons.qm.Wing.button("Bring Items", btnholder,
            () =>
            {
                items.bringpickups(Extentions.LocalPlayer);
            });

            Arctic.Apis.Buttons.qm.Wing.button("Delete Portals", btnholder,
            () =>
            {
                Exploits.General.deletportal();

            });

            Arctic.Apis.Buttons.qm.Wing.button("Save Config", btnholder,
            () =>
            {
                settings.StyleConfig.savestyleconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\StyleConfig.json");
                settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Mainconfig.json"); Style.Consoles.consolelogger("Saved Config");
            });



            bt1 = jumpimpulsebutton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            bt2 = wingbtn.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        }
        private static void changetext(TMPro.TextMeshProUGUI text, bool value, string name)
        {
            try
            {
                if (value)
                    text.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name + " On";
                else
                    text.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name + " Off";
            }
            catch { }

        }
        private static GameObject wingbtn;

        public static TMPro.TextMeshProUGUI bt1;
        public static TMPro.TextMeshProUGUI bt2;


        private static void gettgl(bool value)
        {
            try
            {
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)").gameObject.SetActive(value);
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Text(Clone)(Clone)").gameObject.SetActive(value);
            }
            catch { }

        }
        private static void getdebug(bool value)
        {
            try
            {
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").gameObject.SetActive(value);
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Text(Clone)").gameObject.SetActive(value);
            }
            catch { }
        }




        private static List<string> gmjlist = new List<string>();
        private static List<string> gmjlist2 = new List<string>();

        public static void changeuicolors()
        {

            if (settings.StyleConfig.backgoundbuttons)
            {


                foreach (var acc in GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens").GetComponentsInChildren<UnityEngine.UI.Slider>(true))
                {
                    try
                    {
                        acc.transform.Find("Fill Area/Fill").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color((float)(float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb); ;
                        acc.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color((float)(float)settings.StyleConfig.redb / 2, settings.StyleConfig.greenb / 2, settings.StyleConfig.blueb / 2, settings.StyleConfig.Transpb / 2); ;

                    }
                    catch { }
                }




                foreach (var ab in gmjlist2)
                {

                    GameObject.Find("/UserInterface").transform.Find(ab).gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color((float)(float)settings.StyleConfig.redb - 0.3f, settings.StyleConfig.greenb - 0.3f, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.3f);
                }

                foreach (var ab in gmjlist)
                {
                    GameObject.Find("/UserInterface").transform.Find(ab).gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color((float)(float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                }

                foreach (var background in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                {
                    try
                    {
                        var img = background.transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
                        img.color = new Color((float)(float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                    }
                    catch { }
                    try
                    {
                        var img = background.transform.Find("Container/Background").GetComponent<UnityEngine.UI.Image>();
                        img.color = new Color((float)(float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                    }
                    catch { }

                }
                foreach (var background in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<UnityEngine.UI.Toggle>(true))
                {
                    try
                    {
                        var img = background.transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
                        img.color = new Color((float)(float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                    }
                    catch { }

                }
            }
        }
        private static bool waitformsgtime = true;
        private static IEnumerator waitfotime()
        {
            yield return new WaitForSeconds(2f);
            waitformsgtime = true;
        }


        private static void sendmessagetoserver()
        {
            string msg = "";
            try
            {
                Apis.inputpopout.run("Send Message To The Server", value => msg = value, () =>
                {
                    if (msg.Contains("\n"))
                    {
                        Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>U Can Not Send a msg that contains multiple lines.</color>");
                        Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>Abusing the chat can lead to your key being removed!!!</color>");

                    }
                    else if (msg.Length < 2)
                    {
                        Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>U Can Not Send a msg that is smaller then 2 C.</color>");
                        Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>Abusing the chat can lead to your key being removed!!!</color>");
                    }
                    if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt") == string.Empty)
                    {
                        Style.textdebuger.ChatMsg("Client", "<color=#ff0000ff>Ur Key is empty</color>");
                    }
                    else
                    {
                        var sendmsg = new settings.sendclientmsg()
                        {
                            clientpassword = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Password.txt"),

                            clientKey = File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\Key.txt"),

                            clientmessage = msg,

                            code = "2",
                        };
                        connect.sendmsg($"{JsonConvert.SerializeObject(sendmsg)}");
                    }


                });
            }
            catch { }

        }


        private static IEnumerator serchavi()
        {
            foreach (var avi in serchlist.transform.Find("ViewPort/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
            {
                try
                {
                    GameObject.DestroyImmediate(avi.gameObject);
                }
                catch { }
            }
            var des = JsonConvert.DeserializeObject<List<settings.Logavi>>(connect.aviserchl);
            serchlist.transform.Find("Button/BTN_Search").gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = $"{des.Count}:Search";
            for (int i = 0; i < des.Count; i++)
            {
                Apis.Avatars_fav.createavi(serchlist, des[i].Avatarid, des[i].AvatarName, des[i].Image, des[i].Platform, 1);
                yield return null;

            }
        }
    }


}
