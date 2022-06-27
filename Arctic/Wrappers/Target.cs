using UnityEngine;
using VRC;
namespace Arctic.Wrappers
{
    class Target
    {
        public static VRC.Player istargetd;
        private static GameObject istg;
        private const uint INDICES_PER_TRIANGLE = 3U;
        private static bool runit = false;
        public static GameObject targetplayermain;

        public static void targetuser(string userid)
        {
            if (istg != null)
                GameObject.Destroy(istg);
            foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
            {
                if (player1.field_Private_APIUser_0.id == userid)
                {

                    istargetd = player1;

                    targetplayermain.GetComponent<settings.MonoBehaviours.TargetedPlayer>().targetuser = player1;
                    var getplate = player1.gameObject.GetComponent<VRCPlayer>().field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext");

                    var platedup = GameObject.Instantiate(getplate, getplate.parent);
                    platedup.name = "Targetplate";
                    var platetext = platedup.transform.Find("Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                    platetext.color = Color.red;
                    platetext.text = "Targeted User";
                    istg = platedup.gameObject;
                    string user = "";
                    string username = player1.field_Private_APIUser_0.displayName;
                    Color userc = Color.white;

                    Wrappers.check_ranks.gettrsutrank(player1.field_Private_APIUser_0, ref user, ref userc);
                    Wrappers.check_ranks.convertotcolorank(ref user, ref user);
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Submenu_Target/Header_DevTools(Clone)/LeftItemContainer/Text_Title").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"Target [{username}]";
                    Style.textdebuger.debugermsg($"<color=#ff00ffff>Targeted</color> [{username}]");

                    //    APIN.NDebuger($"User {player1.field_Private_APIUser_0.displayName} <color=#ffff00ff>Targeted</color>", Utilities.ismelonlogger, Color.white);
                       Arctic.Style.textdebuger.debugermsg($"User {player1.field_Private_APIUser_0.displayName} <color=#ffff00ff>Targeted</color>");
                }
            }
        }
    }

}
