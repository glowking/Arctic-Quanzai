using System;
using UnityEngine;
namespace Arctic.Apis.Buttons.qm.Wings
{
    class Wingmenu
    {
        public static GameObject createmenu(string name, GameObject parent, GameObject tosetoff)
        {
            var instanciated = GameObject.Instantiate(Prefabs.LeftWingMenu.gameObject, parent.transform).gameObject;
            Component.DestroyImmediate(instanciated.GetComponent<VRC.UI.Elements.UIPage>());
            instanciated.name = $"NC_{name}";
            instanciated.transform.Find("WngHeader_H1/LeftItemContainer/Text_Title").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            var btnm = instanciated.transform.Find("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
            btnm.GetComponent<UnityEngine.UI.Button>().enabled = true;
            btnm.GetComponent<UIInvisibleGraphic>().enabled = true;
            btnm.GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;

            var btn = btnm.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(new Action(() => { tosetoff.gameObject.SetActive(true); instanciated.gameObject.SetActive(false); }));

            btnm.SetActive(true);
            btnm.transform.Find("Icon").gameObject.SetActive(true);
            var verticall = instanciated.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");

            foreach (var a in verticall.GetComponentsInChildren<UnityEngine.UI.Button>(true))
            {
                GameObject.DestroyImmediate(a.gameObject);
            }

            instanciated.SetActive(false);
            return instanciated;
        }

        public static GameObject createmenuright(string name, GameObject parent, GameObject tosetoff)
        {
            var instanciated = GameObject.Instantiate(Prefabs.Rightwing.gameObject, parent.transform).gameObject;
            Component.DestroyImmediate(instanciated.GetComponent<VRC.UI.Elements.UIPage>());
            instanciated.name = $"NC_{name}";
            instanciated.transform.Find("WngHeader_H1/LeftItemContainer/Text_Title").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            var btnm = instanciated.transform.Find("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
            btnm.GetComponent<UnityEngine.UI.Button>().enabled = true;
            btnm.GetComponent<UIInvisibleGraphic>().enabled = true;
            btnm.GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;

            var btn = btnm.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(new Action(() => { tosetoff.gameObject.SetActive(true); instanciated.gameObject.SetActive(false); }));

            btnm.SetActive(true);
            btnm.transform.Find("Icon").gameObject.SetActive(true);
            var verticall = instanciated.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");

            foreach (var a in verticall.GetComponentsInChildren<UnityEngine.UI.Button>(true))
            {
                GameObject.DestroyImmediate(a.gameObject);
            }

            instanciated.SetActive(false);
            return instanciated;
        }

    }
}
