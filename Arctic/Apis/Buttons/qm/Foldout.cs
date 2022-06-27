using UnityEngine;
namespace Arctic.Apis.Buttons.qm
{
    class Foldout
    {
        public static GameObject foldout(string text, GameObject menu, int rowmax4 = 4)
        {
            var toinstf = menu.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup/Buttons");
            var toinst = GameObject.Instantiate(toinstf.gameObject, toinstf.transform.parent);
            toinst.gameObject.SetActive(true);
            toinst.name = $"Foldout_{text}";
            var fold = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/QM_Foldout_WorldActions");
            var buttonmenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug");
            var foldout = GameObject.Instantiate(fold, toinst.transform);
            var submenu = GameObject.Instantiate(buttonmenu, toinst.transform);
            foreach (var a in submenu.GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
            {
                GameObject.DestroyImmediate(a.gameObject);
            }
            foldout.transform.Find("Label").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            var toggle = foldout.transform.Find("Background_Button").gameObject.GetComponent<UnityEngine.UI.Toggle>();
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)getbool);

            if (rowmax4 != 4)
            {
                if (rowmax4 == 2)
                {
                    toinst.transform.Find("Buttons_Debug(Clone)").gameObject.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>().spacing = 250;

                    toinst.gameObject.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(750, 150);
                    // toinst.transform.Find("QM_Foldout_WorldActions(Clone)/Label").gameObject.transform.localPosition = new Vector3(-449f, -75f, 0);
                    // toinst.transform.Find("QM_Foldout_WorldActions(Clone)/Arrow").gameObject.transform.localPosition = new Vector3(337.98f, -75f,0);

                    //337.98 -75 0
                }

            }

            void getbool(bool value)
            {
                if (value)
                {
                    submenu.gameObject.SetActive(true);
                }
                else
                {
                    submenu.gameObject.SetActive(false);
                }
            }
            return submenu.gameObject;
        }
    }
}
