using System;
using UnityEngine;
namespace Arctic.Apis.Buttons.qm
{
    class Wing
    {

        public static GameObject button(string buttontext, GameObject parent, Action action)
        {

            var wingbuttonl = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emotes").gameObject;
            var instanciated = GameObject.Instantiate(wingbuttonl, parent.transform);



            instanciated.name = $"Wingbtn_{buttontext}";
            var buttons = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttons.onClick.RemoveAllListeners();
            buttons.onClick.AddListener(action);
            instanciated.transform.Find("Container/Icon").gameObject.SetActive(false);
            instanciated.transform.Find("Container/Text_QM_H3").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = buttontext;
            instanciated.transform.Find("Container/Text_QM_H3").gameObject.transform.localPosition = new Vector3(-140, 0, 0);


            return instanciated;
        }

    }
}
