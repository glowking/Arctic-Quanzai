using System;
using UnityEngine;

namespace Arctic.Apis.Buttons
{
    public class button
    {
        public static GameObject Createbutton(string text, GameObject parent, Action action)
        {
            var toinst = GameObject.Find("UserInterface").transform.Find("MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab");
            var instanciated = GameObject.Instantiate(toinst, parent.transform);
            Wrappers.Resettransform.reset(instanciated.gameObject);
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
            instanciated.name = $"BTN_{text}";
            Component.Destroy(instanciated.GetComponent<VRCUiPageTab>());
            var button = instanciated.transform.Find("Button").GetComponent<UnityEngine.UI.Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(new Action(() => { action.Invoke(); Style.textdebuger.debugermsg($"Pressed on [{text}]"); }));
            instanciated.transform.Find("Button/Text").gameObject.GetComponent<UnityEngine.UI.Text>().text = text;
            return instanciated.gameObject;
        }

    }
}
