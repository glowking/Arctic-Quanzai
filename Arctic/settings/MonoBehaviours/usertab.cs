using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Arctic.Wrappers;

namespace Arctic.settings.MonoBehaviours
{
     class usertab :MonoBehaviour
    {
        public usertab(IntPtr ptr) : base(ptr)
        {
        }
        private TMPro.TextMeshProUGUI texttmp;
        private bool toggle = true;
        private static VRC.DataModel.UserSelectionManager usrcmp;
        void Start()
        {

            this.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact").gameObject.GetComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 500;
            this.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/Sliders_UserVolume").transform.localPosition = new Vector3(512f, -400, 0f);
            var tobestatustext = GameObject.Instantiate(this.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_Friend").gameObject,this.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG").transform);
            texttmp = tobestatustext.GetComponent<TMPro.TextMeshProUGUI>();
            tobestatustext.name = $"Nocturanl Description";
            tobestatustext.gameObject.SetActive(true);
            tobestatustext.transform.localPosition = new Vector3(-413.7992f, 71, 0);
            texttmp.text = $"Loading";
            usrcmp = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>();
            texttmp.enableWordWrapping = false;
            texttmp.maxVisibleCharacters = 500;
            texttmp.isOrthographic = false;
            texttmp.gameObject.transform.localScale = new Vector3(8, 8, 1);
        }
        void OnEnable()
        {
            toggle = true;
            MelonLoader.MelonCoroutines.Start(courutinetimer());
            
        }

        void OnDisable()
        {
            toggle = false;
        }

        private IEnumerator courutinetimer()
        {
            while (toggle)
            {
                if (!toggle)
                    yield break;
              
               
                    try
                    {
                    foreach (var player in VRC.PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0)
                    {
                        if (player.field_Private_APIUser_0.id == usrcmp.field_Private_APIUser_1.id)
                        {
                            var user = player;
                            var rank = "";
                            var color = Color.white;
                            Wrappers.check_ranks.gettrsutrank(user.field_Private_APIUser_0, ref rank, ref color);
                            Wrappers.check_ranks.convertotcolorank(ref rank, ref rank);
                            var platform = "Loading";
                            var isvr = "Loading";
                            var isroommaster = "";
                            if (player.field_Private_APIUser_0.last_platform != "standalonewindows")
                            {
                                platform = "<color=#00ff00ff>[Quest]</color>";
                            }
                            else
                            {
                                platform = "<color=#0000a0ff>[PC]</color>";
                            }

                            if (player._vrcplayer.GetIsInVR())
                            {
                                isvr = "<color=#00ffffff>[VR]</color>";
                            }
                            else
                            {
                                isvr = "<color=#0000a0ff>[DS]</color>";
                            }

                            if (player.prop_VRCPlayerApi_0.isMaster)
                            {
                                isroommaster = "M:[<color=#800080ff>M</color>] ";
                            }

                            texttmp.text = $"Rank:[{rank}]   Platform:[{platform}]\nDateJoined:[{user.prop_APIUser_0.date_joined}]\n" +
                                $"F:[{user._vrcplayer.gefps()}]   P:[{user._vrcplayer.geping()}]   " +
                                $"VR:[{user._vrcplayer.GetIsInVR()}]   Avi N:[{user.prop_ApiAvatar_0.name}]\nAvi A:[{user.prop_ApiAvatar_0.authorName}]   Avi P:[{user._vrcplayer.field_Private_VRCAvatarManager_0.prop_EnumNPublicSealedvaUnPlSiPe5vUnique_0}]   FR:[{user.IsFriend()}]" +
                                $"\nType[{isvr}]   {isroommaster}";


                        }
                    }
                }
                    catch { };
                   
                
             
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }

    }
}
