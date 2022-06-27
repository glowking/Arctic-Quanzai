using System;
using UnityEngine;

namespace Arctic.Apis.Buttons
{
    public class Submenu
    {
        public static GameObject SubmenuBigui(string text, string description)
        {
            var dpg = GameObject.Find("UserInterface").transform.Find("MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab");
            var isinstbutton = GameObject.Instantiate(dpg, dpg.parent);
            isinstbutton.name = $"SubMain{text}";
            isinstbutton.transform.rotation = new Quaternion(0, 0, 0, 0);

            isinstbutton.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
            var but = isinstbutton.GetComponentInChildren<UnityEngine.UI.Button>();
            isinstbutton.GetComponent<VRCUiPageTab>().field_Public_String_1 = $"UserInterface/MenuContent/Screens/Holder_{text}";
            but.onClick.RemoveAllListeners();
            var nvm = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/Settings_Safety");
            var newholder = GameObject.Instantiate(nvm, nvm.parent).gameObject;
            newholder.name = $"Holder_{text}";
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_Buttons_SafetyLevel").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_Description_SafetyLevel").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_SafetyMatrix").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("Button_Reset").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_Buttons_UserLevel").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_UserLevel_Tooltip").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("_Notification_CloseMenu").gameObject);
            UnityEngine.GameObject.Destroy(newholder.transform.Find("TitlePanel/Button_PerformanceOptions").gameObject);
            newholder.transform.Find("TitlePanel/TitleText").GetComponent<UnityEngine.UI.Text>().text = description;
            newholder.GetComponent<MonoBehaviour1PublicImTeGaTeObBuObStBuInUnique>().enabled = true;
            newholder.SetActive(false);
            but.onClick.AddListener(new Action(() =>
            {
                Style.textdebuger.debugermsg($"Opened [{text}]");
                newholder.GetComponent<MonoBehaviour1PublicImTeGaTeObBuObStBuInUnique>().enabled = true;
            }));
            return isinstbutton.gameObject;
        }



    }
}
