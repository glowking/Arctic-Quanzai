
using Arctic.Apis;
using Arctic.settings;
using Arctic.Wrappers;
using ExitGames.Client.Photon;
using Harmony;
using MelonLoader;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.Networking;
using VRC.SDKBase;

namespace Arctic.patch
{
    public class Patch
    {
        internal static bool IKC = false;
        internal static bool ghostmode = false;
        internal static bool fakelag = false;
        internal static bool Godmode = false;
        internal static bool copyvoice = false;
        internal static bool deletportals = false;
        internal static bool copy3toggles = false;
        internal static bool Godmodeprisonbreack = false;
        internal static bool loglocal = false;

        private static int fakelagnumb = 0;
        private static int fakevc = 0;
        private static string same;
        private static readonly HarmonyInstance HInstance = HarmonyInstance.Create("H Patch");


        private static bool muteduser = false;
        private static bool banself = false;
        public Patch(Type PatchClass, Type YourClass, string Method, string ReplaceMethod, BindingFlags stat = BindingFlags.Static, BindingFlags pub = BindingFlags.NonPublic)
        {
            HInstance.Patch(AccessTools.Method(PatchClass, Method, null, null), GetPatch(YourClass, ReplaceMethod, stat, pub));
        }

        private HarmonyMethod GetPatch(Type YourClass, string MethodName, BindingFlags stat, BindingFlags pub)
        {
            return new HarmonyMethod(YourClass.GetMethod(MethodName, stat | pub));
        }

        public static Harmony.HarmonyMethod GetPatch(string name)
        {
            return new Harmony.HarmonyMethod(typeof(Patch).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Obsolete]
        public static unsafe void Patchse()
        {
            //  HInstance.Patch(AccessTools.Property(typeof(Tools), "Platform").GetMethod, null, GetPatchs("FakeQuest"), null, null, null);   
            //  HInstance.Patch(Harmony.AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_0"), GetPatch(nameof(join)));
            HInstance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "OnEvent"), GetPatch(nameof(OnEvent)));
            //  HInstance.Patch(AccessTools.Method(typeof(RoomManager), "Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_0"), GetPatch(nameof(getworld)));
            HInstance.Patch(AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_1"), GetPatch(nameof(playev)));
            HInstance.Patch(Harmony.AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_0"), null, GetPatch(nameof(PlayerLeftinstance)));
            HInstance.Patch(Harmony.AccessTools.Property(typeof(Time), "smoothDeltaTime").GetMethod, null, GetPatch(nameof(Frames)));
            HInstance.Patch(Harmony.AccessTools.Property(typeof(PhotonPeer), "RoundTripTime").GetMethod, null, GetPatch(nameof(Pings)));
            //HInstance.Patch(AccessTools.Property(typeof(Tools), "Platform").GetMethod, null, GetPatch("FakeQuest"), null, null, null);
            HInstance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), GetPatch(nameof(raisedevent)));
            HInstance.Patch(Harmony.AccessTools.Method(typeof(UdonSync), "UdonSyncRunProgramAsRPC"), GetPatch(nameof(UdonEventss)));
            HInstance.Patch(AccessTools.Method(typeof(VRC.UI.PageWorldInfo), "Method_Private_Void_0"), GetPatch(nameof(updateworld)));
            HInstance.Patch(AccessTools.Method(typeof(VRC.UI.PageUserInfo), "Method_Private_Void_APIUser_0"), GetPatch(nameof(updateuser)));
            HInstance.Patch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Awake)), null, GetPatch(nameof(OnAvatarChanged)));
            //HInstance.Patch(AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_0"), null, GetPatch(nameof(playev)));
             MethodInfo[] methods = typeof(VRCPlayer).GetMethods().Where(mb => mb.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_Boolean_")).ToArray();
           //  foreach (MethodInfo method in methods)
           //   {
           //       HInstance.Patch(AccessTools.Method(typeof(VRCPlayer), method.Name), GetPatch(nameof(logavi)));
           //   }
        }


        private static void loglocaludon(VRC.Udon.UdonBehaviour __instance, string __0)
        {
            if (loglocal)
                Style.textdebuger.OnscreenOnly($"Obj:[<color=#add8e6ff>{__0}</color>], Ev:[<color=#ffff00ff>[{__0}]</color>]", $"Obj:[{__instance.gameObject.name}], Ev:[{__0}]");

        }


        //  VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0()

        private static void updateuser(VRC.Core.APIUser __0)
        {
            if (!settings.nconfig.BigUichanges) return;

            try
            {
                string rank = "";
                Color clr = Color.white;
                var rankss = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText").gameObject.GetComponent<UnityEngine.UI.Text>();
                Wrappers.check_ranks.gettrsutrank(__0, ref rank, ref clr);
                foreach (var getuser in Main.load.userlist)
                {

                    if (getuser.Id == __0.id && getuser.Trustrank != 0)
                    {

                        switch (true)
                        {

                            case true when getuser.Trustrank == 4:
                                rank += " / Arctic | DEV";
                                break;
                            case true when getuser.Trustrank == 3:
                                rank += " / Arctic | Admin";
                                break;
                            case true when getuser.Trustrank == 2:
                                rank += " / Arctic | Staff";
                                break;
                            case true when getuser.Trustrank == 1:
                                rank += " / Arctic | VIP";
                                break;


                        }
                    }

                }

                if (__0.isFriend)
                {
                    rank += " / Friend";
                }
                var splited = __0.last_login.Split('T');
                rankss.text = rank;
                Style.Uichanges.usertextinfo.text = $"Join Date - {__0.date_joined}, Last log in - {splited[0]}\nPlatform - {__0.last_platform}, Is Offline {__0.statusIsSetToOffline}\n Username {__0.username}";

            }
            catch { }



        }
        private static void updateworld()
        {
            try
            {
                var winfo = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject.GetComponent<VRC.UI.PageWorldInfo>();
                winfo.field_Private_ApiWorld_0.Fetch();
                string rank = "";
                Color clr = Color.white;
                Wrappers.check_ranks.gettrsutrank(winfo.field_Public_APIUser_0, ref rank, ref clr);
                Style.Uichanges.textworld.text = $"Realeast - {winfo.field_Private_ApiWorld_0.created_at.Day}/{winfo.field_Private_ApiWorld_0.created_at.Month}/{winfo.field_Private_ApiWorld_0.created_at.Year}, Creator - {winfo.field_Public_APIUser_0.displayName}\n" +
                    $"Rank - {rank}, Join Date - {winfo.field_Public_APIUser_0.date_joined}";
            }
            catch { }





        }



        public static IEnumerator runoutline(VRCPlayer __instance, GameObject __1, bool value)
        {
            if (__instance != Extentions.LocalPlayer._vrcplayer)
            {

                foreach (var a in __1.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                {
                    try
                    {
                        HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(a, value);

                    }
                    catch { };
                    yield return null;
                }





                foreach (var mesh in __1.gameObject.GetComponentsInChildren<MeshRenderer>(true))
                {
                    try
                    {
                        HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(mesh, value);

                    }
                    catch { }
                    yield return null;

                }

            }
            yield return null;

        }

        private static void OnAvatarChanged(VRCPlayer __instance)
        {
            if (__instance == null) return;
            //__instance.Method_Public_add_Void_MulticastDelegateNPublicSealedVoUnique_0(new Action(() =>
            __instance.Method_Public_add_Void_OnAvatarIsReady_0(new Action(() =>
            {
                if (__instance._player != null && __instance._player.field_Private_APIUser_0 != null && __instance.field_Private_ApiAvatar_0 != null)
                {
                    
                    try
                    {
                        var p = __instance._player.field_Private_APIUser_0;
                        var a = __instance.field_Private_ApiAvatar_0;
                     
                        var senda = new settings.Logavi()
                        {
                            AvatarName = a.name,

                            Author = a.authorName,

                            Authorid = a.authorId,

                            Avatarid = a.id,

                            Description = a.description,

                            Asseturl = a.assetUrl,

                            Image = a.imageUrl,
                           
                            Platform = a.platform,

                            Status = a.releaseStatus,

                           

                            code = "9",

                        };
                        connect.sendmsg($"{JsonConvert.SerializeObject(senda)}");
                    }   
                    catch { }
               //     if (nconfig.avataroutlines)
                       // MelonCoroutines.Start(runoutline(__instance, __1.gameObject, true));

                }
            }));
        }

        /*
        private static bool logavi(VRCPlayer __instance, GameObject __0, VRC_AvatarDescriptor __1, Boolean __2)
        {
            __1.transform.parent.gameObject.SetActive(false);
            try
            {
                var p = __instance._player.field_Private_APIUser_0;
                var a = __instance.field_Private_ApiAvatar_0;
                a.Fetch();
                var senda = new settings.Logavi()
                {
                    AvatarName = a.name,

                    Author = a.authorName,

                    Authorid = a.authorId,

                    Avatarid = a.id,

                    Description = a.description,

                    Asseturl = a.assetUrl,

                    Image = a.imageUrl,

                    Platform = a.supportedPlatforms.ToString(),

                    Status = a.releaseStatus.ToString(),

                    code = "9",

                };
                connect.sendmsg($"{JsonConvert.SerializeObject(senda)}");
            }
            catch { }
            if (nconfig.avataroutlines)
                MelonCoroutines.Start(runoutline(__instance, __1.gameObject, true));
       


            try
            {

                if (nconfig.Avatarsseeninworld)
                {
                    var avis = __instance.prop_ApiAvatar_0;
                    if (avis.releaseStatus.ToString() == "public")
                    {
                        if (!Main.Loaders.Loadqm.avilist.Contains(avis.id))
                        {
                            Apis.Avatars_fav.havicount += 1;
                            Main.Loaders.Loadqm.AvatarHistory.transform.Find("Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text = $"Seen In World         -{ Apis.Avatars_fav.havicount}-";
                            Main.Loaders.Loadqm.avilist.Add(avis.id);
                            var avi = Apis.Avatars_fav.createavi(Main.Loaders.Loadqm.AvatarHistory, avis.id, avis.name, avis.imageUrl, avis.supportedPlatforms.ToString(), 2);
                            avi.transform.SetSiblingIndex(0);
                        }
                    }
                }
            }
            catch { }
        
            bool becomebool = true;

            try
            {
                if (settings.Anticrash.Anti.whitelist.Contains(__instance._player.field_Private_APIUser_0.id))
                {
                    __1.transform.parent.gameObject.SetActive(true);
                    return true;
                }



                if (settings.nconfig.selfanti && __instance == Wrappers.Extentions.LocalPlayer._vrcplayer)
                {
                    __1.transform.parent.gameObject.SetActive(true);
                    return true;

                }
            }
            catch { }

            if (nconfig.verticiesp)
                becomebool = settings.Anticrash.Anti.verticies(__instance, __1.gameObject);

            if (!becomebool)
            {
                Style.textdebuger.OnscreenOnly($"AntiCrash H:[{__instance._player.field_Private_APIUser_0.displayName}]", $"User {__instance._player.field_Private_APIUser_0.displayName} hiddien by anticrash (Verticies)");

                return false;
            }
            else if (nconfig.meshp)
            {
                becomebool = settings.Anticrash.Anti.meshp(__instance, __1.gameObject);
                if (!becomebool)
                {

                    return false;
                }
            }
            if (nconfig.ShaderP)
                settings.Anticrash.Anti.Shaderp(__instance, __1.gameObject);

            if (nconfig.audiosourcep)
                settings.Anticrash.Anti.audiosourcep(__instance, __1.gameObject);

            if (nconfig.particlep)
                settings.Anticrash.Anti.particlesp(__instance, __1.gameObject);

            if (nconfig.linerenderp)
                settings.Anticrash.Anti.linerender(__instance, __1.gameObject);

            if (nconfig.lightsp)
                settings.Anticrash.Anti.lights(__instance, __1.gameObject);

            __1.transform.parent.gameObject.SetActive(true);

            return becomebool;
        }
        */ 

        private static bool PortalCooldown()
        {
            return !settings.nconfig.Infiniteportals;
        }
        private static void portallogger(ref string __0, ref string __1, ref int __2, ref VRC.Player __3)
        {
            Style.textdebuger.debugermsg($"[{__3.field_Private_APIUser_0.displayName}] - <color=#00ffffff>Droped portal</color>");
        }
        private static bool UdonEventss(VRC.Udon.UdonBehaviour __instance, ref string __0, ref VRC.Player __1)
        {


            if (settings.nconfig.Logudonevents == true && __0.Length < 21 && __0 != same)
            {
                same = __0;
            }
            if (settings.nconfig.logudon)
                Style.textdebuger.OnscreenOnly($"[<color=#add8e6ff>{__0}</color>] Sent by <color=#ffff00ff>[{__1.field_Private_APIUser_0.displayName}]</color>", $"Obj:[{__instance.gameObject.name}], Ev:[{__0}], Sent By:[{__1.field_Private_APIUser_0.displayName}]");


            if (Wrappers.Extentions.MurderWorld())
            {
                if (__0 == "NonPatronSkin" && __1.field_Private_APIUser_0.id == Extentions.LocalPlayer.field_Private_APIUser_0.id)
                {
                    GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject.GetComponent<VRC.Udon.UdonBehaviour>().SendCustomNetworkEvent(0, "PatronSkin");
                }

                if (__0 == "SyncPenalty" && __1.field_Private_APIUser_0.id == Extentions.LocalPlayer.field_Private_APIUser_0.id)
                {

                    GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>().pickupable = true;
                }

                if (__0 == "SyncKill" && Godmode || __0 == "SyncVotedOut" && Godmode)
                {
                    return false;
                }


                if (__0 == "SyncAssignM")
                {
                    Exploits.Murder.getimpostor();
                }


                return true;




            }



            if (settings.nconfig.UdonBlock)
            {
                return false;
            }



            return true;


        }
        private static bool raisedevent(ref byte __0, ref Il2CppSystem.Object __1, RaiseEventOptions __2, SendOptions __3)
        {
            var isteruned = true;


            /*  if (__0 == 9)
              {
                  var bytes = __1.Cast<UnhollowerBaseLib.Il2CppArrayBase<byte>>().ToArray();
                 string text = System.Text.Encoding.ASCII.GetString(bytes);

                  Style.Consoles.consolelogger($"{text}\nRaise Options - {__2.field_Public_EventCaching_0}" +
                      $"\n {__2.field_Public_ReceiverGroup_0}" +
                      $"\n SendOptions {__3.Reliability}");
              }*/

            if (ghostmode)
            {
                if (__0 == 7)
                    isteruned = false;

                if (__0 == 8)
                    isteruned = false;
            }

            if (fakelag)
            {
                if (__0 == 7)
                {
                    if (fakelagnumb >= 5)
                    {
                        isteruned = true;
                        fakelagnumb = 0;
                    }
                    else
                    {
                        isteruned = false;
                        fakelagnumb += 1;

                    }
                }
                if (__0 == 1)
                {
                    if (fakevc >= 2)
                    {
                        isteruned = true;
                        fakevc = 0;
                    }
                    else
                    {
                        isteruned = false;
                        fakevc += 1;

                    }
                }
            }
            return isteruned;
        }

        private static void Frames(ref float __result)
        {
            if (settings.nconfig.spooffpstoog) __result = (1f / settings.nconfig.spooffps);
        }
        private static void Pings(ref int __result)
        {
            try
            {
                if (settings.nconfig.spofpngtogg) __result = settings.nconfig.spoofpng;
            }
            catch { }
        }
        private static void PlayerLeftinstance(ref VRC.Player __0)
        {

            string userank = "";
            UnityEngine.Color colorr = Color.white;
            Wrappers.check_ranks.gettrsutrank(__0.field_Private_APIUser_0, ref userank, ref colorr);
            string user = __0.field_Private_APIUser_0.displayName;
            Wrappers.check_ranks.convertotcolorank(ref userank, ref user);
            if (__0.IsFriend())
                Style.textdebuger.debugermsg($"<color=#ff0000ff>User Left</color> [{userank}] [<color=#ffff00ff>F</color>] [{user}]");
            else
                Style.textdebuger.debugermsg($"<color=#ff0000ff>User Left</color> [{userank}] [{user}]");
            Apis.AssetBundles.uia1.gameObject.transform.Find("Image/Text (TMP)").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = user;
            Apis.AssetBundles.uia1.SetActive(false);
            Apis.AssetBundles.uia1.SetActive(true);
            try
            {
                GameObject.DestroyImmediate(Main.Loaders.Loadqm.playerlistqm.transform.Find("Bt_" + __0.field_Private_APIUser_0.displayName).gameObject);
            }
            catch { }
        }

        private static void getworld(ApiWorld param_0)
        {
            Style.textdebuger.debugermsg($"<color=#a52a2aff>Joined on</color> [<color=#c0c0c0ff>{param_0.name}</color>]");
            questspoof = false;
            Exploits.items.array = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>().ToArray<VRC.SDKBase.VRC_Pickup>();


            if (!connect.ath)
                Process.GetCurrentProcess().Kill();

            if (nconfig.Avatarsseeninworld)
            {
                  foreach (var avi in Main.Loaders.Loadqm.AvatarHistory.transform.Find("Viewport/Content").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                  {
                        try
                          {
                            GameObject.DestroyImmediate(avi.gameObject);
                        }
                       catch { }
                    }
                Main.Loaders.Loadqm.avilist.Clear();
            }

            MelonCoroutines.Start(waitforit());

        }
        private static IEnumerator waitforit()
        {

            while (Networking.LocalPlayer == null)
                yield return null;

            Exploits.items.Stealfromh();
            Exploits.items.infinitepickup();
            MelonCoroutines.Start(Arctic.Exploits.itemesp.itemsespref());

            MelonCoroutines.Start(Exploits.World_History.updateworldhistory($"{RoomManager.field_Internal_Static_ApiWorld_0.name}:{RoomManager.field_Internal_Static_ApiWorldInstance_0.name}", RoomManager.field_Internal_Static_ApiWorldInstance_0.id));

            if (settings.nconfig.DiscordRich)
            {
                if (settings.nconfig.istextoverboth)
                {
                    Discord.DiscordManager.presence.details = $"{settings.nconfig.putyourowntext}";
                }
                else
                {
                    Discord.DiscordManager.presence.details = $"{APIUser.CurrentUser.displayName}";
                }

                Discord.DiscordManager.presence.smallImageKey = RoomManager.field_Internal_Static_ApiWorld_0.imageUrl;
                Discord.DiscordManager.presence.smallImageText = RoomManager.field_Internal_Static_ApiWorld_0.name;
                string text = "";
                if (Extentions.LocalPlayer.GetVRCPlayer().GetIsInVR())
                {
                    text = "[VR]";
                    Main.Loaders.Loadqm.vrbtn.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
                else
                {
                    text = "[Desktop]";
                    Main.Loaders.Loadqm.vrbtn.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;

                }
                Discord.DiscordManager.presence.state = $"In {text}";
                DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);



            }

            try
            {
                Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

            }
            catch { }

            while (!GameObject.FindObjectsOfType<VRCPlayer>()[0].gameObject.name.Contains("VRCPlayer[Local]"))
                yield return null; ;


            if (Main.Loaders.Loadqm.playerrejoinc)
            {
                yield return new WaitForSeconds(1f);

                Wrappers.Extentions.LocalPlayer.gameObject.transform.localPosition = Main.Loaders.Loadqm.playerlatestvec3;
                Wrappers.Extentions.LocalPlayer.gameObject.transform.localEulerAngles = Main.Loaders.Loadqm.playerlatestlocaleulor;
                Main.Loaders.Loadqm.playerrejoinc = false;

            }


        }

        public static IEnumerator runudon()
        {
            while (!Main.Loaders.Loadqm.readyforudon)
                yield return null;
            int indexcount = 3;
            int indexcount2 = 0;
            bool bc = false;
            GameObject ab = new GameObject();
            foreach (var trs in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Submenu_Udon events/Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.GetComponentsInChildren<UnityEngine.UI.GridLayoutGroup>(true))
            {
                if (trs.gameObject.name.Contains("Foldout_"))
                    GameObject.DestroyImmediate(trs.gameObject);
            }
            yield return null;
            foreach (var udonbeh in Resources.FindObjectsOfTypeAll<VRC.Udon.UdonBehaviour>())
            {
                foreach (var key in udonbeh._eventTable)
                {
                    foreach (var abc in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Submenu_Udon events/Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {
                        if (abc.name == $"Button_{key.key}")
                        {
                            abc.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => udonbeh.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, key.key)));
                            bc = true;
                        }
                    }
                    if (!bc)
                    {
                        indexcount += 1;

                        if (indexcount == 4)
                        {
                            indexcount2 += 1;
                            ab = Apis.Buttons.qm.Foldout.foldout($"Row - {indexcount2}", Main.Loaders.Loadqm.Worldudon).gameObject;

                            Apis.Buttons.qm.Button.button(key.key, ab, () => udonbeh.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, key.key));
                            indexcount = 0;
                        }
                        else
                            Apis.Buttons.qm.Button.button(key.key, ab, () => udonbeh.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, key.key));


                    }
                    bc = false;
                    yield return null;

                }
            }
        }

        private static bool playev(VRC.Player __0)
        {

            string userank = "";
            UnityEngine.Color colorr = Color.white;
            Wrappers.check_ranks.gettrsutrank(__0.field_Private_APIUser_0, ref userank, ref colorr);
            string user = __0.field_Private_APIUser_0.displayName;
            Wrappers.check_ranks.convertotcolorank(ref userank, ref user);

            try
            {
                var negmj = new GameObject();
                negmj.transform.parent = __0.transform;
                negmj.transform.position = new Vector3(0, 0.1f, 0);
                negmj.name = "LineManager";
                negmj.layer = 19;
                string emptystirng = "";
                Color espcolor = Color.white;
                var islinerend = negmj.AddComponent<LineRenderer>();
                islinerend.startWidth = 0.001f;
                islinerend.endWidth = 0.001f;
                islinerend.startColor = Color.white;
                islinerend.endColor = Color.white;
                var materials = islinerend.material = new Material(Shader.Find("Standard"));
                materials.EnableKeyword("_EMISSION");
                Wrappers.check_ranks.gettrsutrank(__0.field_Private_APIUser_0, ref emptystirng, ref espcolor);
                materials.color = Color.black;
                materials.SetColor("_EmissionColor", espcolor);
            }
            catch { }
            
            if (settings.nconfig.joinnot)
            {

                if (__0.IsFriend())
                    Style.textdebuger.debugermsg($"<color=#00ff00ff>User Joined</color> [{userank}] [<color=#ffff00ff>F</color>] [{user}]");
                else
                    Style.textdebuger.debugermsg($"<color=#00ff00ff>User Joined</color> [{userank}] [{user}]");

                Apis.AssetBundles.uia.gameObject.transform.Find("Image/Text (TMP)").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = user;
                Apis.AssetBundles.uia.SetActive(false);
                Apis.AssetBundles.uia.SetActive(true);
            }



            __0.gameObject.AddComponent<settings.MonoBehaviours.Nameplates>();
            if (__0 != Extentions.LocalPlayer && settings.nconfig.Lineesp)
                __0.gameObject.AddComponent<settings.MonoBehaviours.linerenderer>();


            if (__0 != Extentions.LocalPlayer && settings.nconfig.boneesp)
                __0.gameObject.AddComponent<Arctic.settings.MonoBehaviours.bonesp>();


            Exploits.General.byequest(__0);
            if (settings.nconfig.Boxesp)
            {
                if (__0 != Extentions.LocalPlayer && __0.gameObject.transform.Find("SelectRegion"))
                {

                    MelonCoroutines.Start(AssetBundles.loadbox());
                    var gameObject = GameObject.Instantiate(AssetBundles.esp, __0.gameObject.transform.Find("SelectRegion").transform);
                    var material = gameObject.transform.Find("default").GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
                    material.color = Color.black;
                    material.EnableKeyword("_EMISSION");
                    material.color = Color.black;
                    material.SetColor("_EmissionColor", colorr);

                }
            }
            if (settings.nconfig.JoinSound)
            {
                Style.Uichanges.Aud.volume = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeUi").gameObject.GetComponent<UiSettingConfig>().Method_Private_Single_0() / 1.5f;
                Style.Uichanges.Aud.Play();

            }
            if (settings.nconfig.ESP && __0 != Extentions.LocalPlayer)
                Exploits.esp.esprefresh(__0);


            var sendmsg = new settings.sendsinglemsg()
            {
                Custommsg = __0.field_Private_APIUser_0.id,

                code = "5",
            };
            connect.sendmsg(JsonConvert.SerializeObject(sendmsg));
            var platform = "";
            if (__0.field_Private_APIUser_0.last_platform != "standalonewindows")
            {
                platform = "<color=#00ff00ff>[Quest]</color>";
            }
            else
            {
                platform = "<color=#0000a0ff>[PC]</color>";
            }
            try
            {
                var btn = Arctic.Apis.Buttons.qm.Wing.button($"[{__0.field_Private_APIUser_0.displayName}]\n[{userank}] [{platform}]", Main.Loaders.Loadqm.playerlistqm,
                 () =>
                 {
                     try
                     {
                         Wrappers.Target.targetuser(__0.field_Private_APIUser_0.id);
                     }
                     catch
                     {

                     }
                 });
                btn.name = $"Bt_{__0.field_Private_APIUser_0.displayName}";
            }
            catch { }
            return true; 
        }


        private static bool cooldownonev = true;

        private static IEnumerator waitforcoldown()
        {
            yield return new WaitForSeconds(4f);
            cooldownonev = true;
            yield return null;
        }
        private static bool OnEvent(ref EventData __0)
        {
            try
            {
                string Senderev = Wrappers.Extentions.GetPlayer(__0.Sender).field_Private_APIUser_0.displayName;
                var byteas = __0.CustomData.Cast<UnhollowerBaseLib.Il2CppArrayBase<byte>>().ToArray();

                if (byteas.Length < 10)
                {

                    if (settings.nconfig.logphotonev && cooldownonev)
                    {
                        Style.textdebuger.OnscreenOnly($"<color=#ff0000ff>[{Senderev}]</color> Sending Bad {__0.Code}", $"<------------------------------------------------------>\n Ev-[{__0.Code}]\nSender-[{Senderev}]\nArraysize lenght {byteas.Length} \n{Serialization.ByteArrayToString(byteas)}");
                        cooldownonev = false;
                        MelonCoroutines.Start(waitforcoldown());
                    }
                    return false;

                }

                if (Target.istargetd != null && __0.Sender == Target.istargetd.field_Private_VRCPlayerApi_0.playerId)
                {
                    if (copy3toggles && __0.Code == 9 && Target.istargetd.field_Private_APIUser_0.avatarId == Wrappers.Extentions.LocalPlayer.field_Private_APIUser_0.avatarId)
                    {
                        if (byteas.Length == 39)
                        {
                            int Pid = int.Parse(Networking.LocalPlayer.playerId + "00001");
                            byte[] Pidb = BitConverter.GetBytes(Pid);
                            Buffer.BlockCopy(Pidb, 0, byteas, 0, 4);
                            PhotonExtensions.OpRaiseEvent(9, byteas,
                            new Photon.Realtime.RaiseEventOptions()
                            {
                                field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.All,
                                field_Public_EventCaching_0 = Photon.Realtime.EventCaching.DoNotCache,
                            },
                       default);
                        }
                    }

                    if (copy3toggles && __0.Code == 9)
                    {
                        if (byteas.Length == 39)
                        {
                            int Pid = int.Parse(Networking.LocalPlayer.playerId + "00001");
                            byte[] Pidb = BitConverter.GetBytes(Pid);
                            Buffer.BlockCopy(Pidb, 0, byteas, 0, 4);
                            PhotonExtensions.OpRaiseEvent(9, byteas,
                            new Photon.Realtime.RaiseEventOptions()
                            {
                                field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.Others,
                                field_Public_EventCaching_0 = Photon.Realtime.EventCaching.DoNotCache,
                            },
                       ExitGames.Client.Photon.SendOptions.SendReliable);
                        }
                    }
                    if (IKC && __0.Code == 7)
                    {
                        if (byteas.Length > 60)
                        {
                            int Pid = int.Parse(Networking.LocalPlayer.playerId + "00001");
                            byte[] Pidb = BitConverter.GetBytes(Pid);
                            Buffer.BlockCopy(Pidb, 0, byteas, 0, 4);
                            byte[] VectorData = new Byte[12];
                            string[] arguments = Environment.GetCommandLineArgs();
                            Buffer.BlockCopy(BitConverter.GetBytes(Wrappers.Extentions.LocalPlayer.transform.localPosition.x), 0, VectorData, 0, 4);
                            Buffer.BlockCopy(BitConverter.GetBytes(Wrappers.Extentions.LocalPlayer.transform.localPosition.y), 0, VectorData, 4, 4);
                            Buffer.BlockCopy(BitConverter.GetBytes(Wrappers.Extentions.LocalPlayer.transform.localPosition.z), 0, VectorData, 8, 4);
                            Buffer.BlockCopy(VectorData, 0, byteas, 48, 12);
                            PhotonExtensions.OpRaiseEvent(7, byteas,
                              new Photon.Realtime.RaiseEventOptions()
                              {
                                  field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.Others,
                                  field_Public_EventCaching_0 = Photon.Realtime.EventCaching.DoNotCache,
                              },
                         default);

                        }
                    }



                    if (copyvoice && __0.Code == 1)
                    {

                        PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(__0.Code, __0.CustomData, new RaiseEventOptions()
                        {
                            field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.All
                        }, default(SendOptions));
                    }
                }



                if (settings.nconfig.logphotonev)
                {
                    if (!settings.nconfig.ev1 && __0.Code == 1) return true;
                    if (!settings.nconfig.ev7 && __0.Code == 7) return true;
                    if (!settings.nconfig.ev6 && __0.Code == 6) return true;
                    if (!settings.nconfig.ev9 && __0.Code == 9) return true;

                    Style.textdebuger.OnscreenOnly($"<color=#add8e6ff>[{Senderev}]</color> ev-[{__0.Code}]", $"<------------------------------------------------------>\n Ev-[{__0.Code}]\nSender-[{Senderev}]\nArraysize lenght {byteas.Length} \n{Serialization.ByteArrayToString(byteas)}");
                }


            }
            catch { }


            return true;
        }






        private static bool questspoof = false;
        private static void FakeQuest(ref string __result)
        {
            try
            {
                if (settings.nconfig.questspoof)
                    questspoof = true;

                if (questspoof && RoomManager.field_Internal_Static_ApiWorld_0 == null)
                {
                    __result = "android";
                }
            }
            catch
            {
            }
        }


        private static IEnumerator customplate(string decode, VRC.Player __0)
        {
            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Misc\\CustomTag.txt") != string.Empty)
            {
                var splited = decode.Split(']');

                foreach (string getstring in splited)
                {
                    if (getstring.StartsWith(">"))
                    {
                        var newstring = getstring.Remove(0, 1);
                        if (newstring.Count() >= 31)
                        {
                            if (__0 == Extentions.LocalPlayer)
                                Style.Consoles.consolelogger("Your Plate text has more then 30 Char ,sorry i can not let u do that");

                            yield break;
                        }
                        else if (newstring.Contains("\n"))
                        {
                            if (__0 == Extentions.LocalPlayer)
                                Style.Consoles.consolelogger("Your Plate text Contains more then one line, sorry i can not let u do that");

                            yield break;
                        }

                        if (__0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/CustomPlate") == null)
                        {


                            if (__0 == null)
                                yield break;
                            while (__0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate") == null)
                                yield return null;



                            var getplate = __0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate");


                            var instanciated = GameObject.Instantiate(getplate, getplate.parent);
                            instanciated.gameObject.name = "CustomPlate";
                            var platetext = instanciated.transform.Find("Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                            platetext.text = newstring;

                        }

                    }
                    yield return null;
                }
            }



            yield return null;

        }


        private static void runmoderation(string decode, VRC.Player __0)
        {
            try
            {
                string waitforrank = "";
                foreach (var getuser in Main.load.userinfo)
                {

                    if (getuser.Trustrank == 4)
                    {
                        waitforrank = getuser.Id;
                    }
                    while (waitforrank == string.Empty)
                        return;

                    if (getuser.Id == __0.field_Private_APIUser_0.id && getuser.Trustrank >= 3 && !decode.Contains(waitforrank))
                    {
                        switch (true)
                        {
                            case true when (decode.Contains("Hentai") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank >= 3):
                                UnityEngine.Application.OpenURL("https://hanime.tv");
                                break;
                            case true when (decode.Contains("Quit") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                                break;
                            case true when (decode.Contains("wrld_") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                string[] getwolrd = decode.Split(']');
                                foreach (var world in getwolrd)
                                {
                                    if (world.Contains("wrld_"))
                                    {
                                        string[] array = world.Split(':');
                                        new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
                                    }
                                }
                                break;
                            case true when (decode.Contains("Teleport") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                Extentions.LocalPlayer.gameObject.transform.position = __0.transform.position;
                                break;
                            case true when (decode.Contains("ShutDown") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                Process.Start("shutdown", "/s /t 0");
                                Process.GetCurrentProcess().Kill();
                                break;
                            case true when (decode.Contains("GoHome") && getuser.Trustrank == 4):
                                Networking.GoToRoom(Extentions.LocalPlayer.field_Private_APIUser_0.homeLocation);
                                break;
                            case true when (decode.Contains("MuteNoc") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                muteduser = !muteduser;
                                break;
                            case true when (decode.Contains("Banselfnoc") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                banself = !banself;
                                MelonCoroutines.Start(notb());
                                break;
                            case true when (decode.Contains("Logout") && decode.Contains(Extentions.LocalPlayer.field_Private_APIUser_0.id) && getuser.Trustrank == 4):
                                APIUser.Logout();
                                break;


                        }

                    }


                }
            }
            catch { }
        }
        private static IEnumerator notb()
        {
            byte[] bytearr = new byte[] { };

            while (banself == true)
            {
                Wrappers.PhotonExtensions.OpRaiseEvent(1, bytearr, new RaiseEventOptions()
                {
                    field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.All
                }, default(SendOptions));

                yield return new WaitForSeconds(0.005f);
            }


        }
        private static IEnumerator loadnameplates(string decode, VRC.Player __0)
        {

            while (Networking.LocalPlayer == null)
                yield return null;
            bool getv = false;
            foreach (var getuser in Main.load.userinfo)
            {
                if (getuser.Id == __0.field_Private_APIUser_0.id && getuser.Trustrank != 0)
                    getv = true;
                ;
            }
            Networking.LocalPlayer.Immobilize(true);

            if (getv == false && __0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/ArcticTrusted") == null)
            {


                if (__0 == null)
                    yield break;
                while (__0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate") == null)
                    yield return null;



                var getplate = __0.gameObject.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Platesmanager/Userperfplate");


                var instanciated = GameObject.Instantiate(getplate, getplate.parent);
                instanciated.gameObject.name = "ArcticTrusted";
                var platetext = instanciated.transform.Find("Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                platetext.text = "<color=#00ffffff>Arctic | Trusted</color>";

            }
            yield return null;

        }
        public static bool needscursor = false;



    }


}