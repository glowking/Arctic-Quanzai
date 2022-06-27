using System;
using UnityEngine;

namespace Arctic.Apis.Buttons.qm
{
    public class Page
    {
        public static GameObject lastmen;
        public static GameObject page(string text, GameObject opengmj)
        {
            lastmen = opengmj;
            var instanciate = GameObject.Instantiate(Prefabs.Page, Prefabs.Page.transform.parent);

            instanciate.name = $"Page_{text}";
            instanciate.transform.rotation = new Quaternion(0, 0, 0, 0);
            instanciate.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            instanciate.SetActive(true);

            Component.Destroy(instanciate.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
            instanciate.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            instanciate.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() =>
            {
                foreach (GameObject gameobject in submenu.submenuslist)
                {

                    if (gameobject != lastmen.gameObject)
                        gameobject.SetActive(false);
                    else
                        gameobject.SetActive(true);

                }

                Style.textdebuger.debugermsg($"<color=#0000ffff>Opened page</color> [<color=#add8e6ff>{text}</color>]");
                Prefabs.Submenu.transform.Find("Header_DevTools").gameObject.SetActive(false);
                Prefabs.Submenu.transform.Find("Scrollrect").gameObject.SetActive(false);
                opengmj.SetActive(true);


                for (int i = 0; i < Prefabs.Submenu.transform.childCount; ++i)
                {
                    Transform child = Prefabs.Submenu.transform.GetChild(i);
                    if (child.gameObject.name.Contains("Submenu_") && opengmj.name != child.gameObject.name)
                        child.gameObject.SetActive(false);

                }
            }));

            foreach (var btn in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup").GetComponentsInChildren<VRC.UI.Elements.Controls.MenuTab>(true))
            {
                if (btn.name != "Page_Arctic")
                {
                    foreach (var btnn in submenu.submenuslist)
                    {
                        btnn.SetActive(false);
                    }
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Header_DevTools").gameObject.SetActive(true);
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect").gameObject.SetActive(true);

                }
            }

            return instanciate;
        }

    }
}
