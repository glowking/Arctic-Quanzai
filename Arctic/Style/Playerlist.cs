using Arctic.Wrappers;
using System;
using System.Collections;
using UnityEngine;
using VRC;

namespace Arctic.Style
{
    class Playerlist
    {
        public static string playlist = "";

        public static IEnumerator Playerlists()
        {
            while (true)
            {
                //   Application.targetFrameRate = 300;
                //  QualitySettings.vSyncCount = 0;


                playlist = "";
                try
                {
                    Uichanges.playercounter.text = $"-{PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count}-";

                }
                catch { }
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        string isvr = "";
                        string platform = "";
                        string isroommaster;

                        if (player[i].field_Private_APIUser_0.last_platform != "standalonewindows")
                        {
                            platform = "<color=#00ff00ff>[Quest]</color>";
                        }
                        else
                        {
                            platform = "<color=#0000a0ff>[PC]</color>";
                        }

                        if (player[i]._vrcplayer.GetIsInVR())
                        {
                            isvr = "<color=#00ffffff>[VR]</color>";
                        }
                        else
                        {
                            isvr = "<color=#0000a0ff>[DS]</color>";
                        }

                        if (player[i].prop_VRCPlayerApi_0.isMaster)
                        {
                            isroommaster = "[<color=#800080ff>M</color>] ";
                        }
                        else isroommaster = "";

                        string name = player[i].field_Private_APIUser_0.displayName;

                        var rank = "";
                        Color nothing = Color.white;


                        check_ranks.gettrsutrank(player[i].field_Private_APIUser_0, ref rank, ref nothing);

                        check_ranks.convertotcolorank(ref rank, ref name);





                        playlist += $"[<color=#ff0048>{i}</color>]{isroommaster}[{name}] [{rank}] [{platform}] [{isvr}] [<color=#add8e6ff>P</color> {player[i]._vrcplayer.geping()}] [<color=#0000a0ff>F</color> {player[i]._vrcplayer.gefps()}]\n";
                        Arctic.Style.Uichanges.playerlisttext.text = playlist;



                        if (settings.nconfig.NamePlatesuichange && player[i] != Wrappers.Extentions.LocalPlayer)
                        {
                            player[i]._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext/Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"{isroommaster}[{rank}] [{platform}] [{isvr}] [<color=#add8e6ff>P</color> {player[i]._vrcplayer.geping()}] [<color=#0000a0ff>F</color> {player[i]._vrcplayer.gefps()}]";

                            player[i].GetVRCPlayer().field_Public_PlayerNameplate_0.field_Public_Graphic_1.color = nothing;

                        }

                    }
                    catch { }

                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                yield return new WaitForSeconds(1.6f);
            }


        }

    }

}
