using System;
using UnityEngine;
namespace Arctic.Apis.Buttons.qm
{
    public class Button
    {
        public static GameObject button(string text, GameObject menu, Action action, string image = null)
        {
            var instanciated = GameObject.Instantiate(Prefabs.ButtonPrefab, menu.transform);
            instanciated.name = $"Button_{text}";
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() => { action.Invoke(); Style.textdebuger.debugermsg($"<color=#ff00ffff>Pressed on</color> [<color=#00ffffff>{text}]</color>"); }));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);

            if (image != null)
            {
                MelonLoader.MelonCoroutines.Start(Apis.image.loadspriterest(instanciated.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>(), image));
            }

            return instanciated;
        }
        public static GameObject buttonan(string text, GameObject menu, Action action)
        {
            var instanciated = GameObject.Instantiate(Prefabs.ButtonPrefab, menu.transform).gameObject;
            instanciated.name = $"Button_{text}";
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() => { action.Invoke(); Style.textdebuger.debugermsg($"<color=#ff00ffff>Pressed on</color> [<color=#00ffffff>{text}]</color>"); }));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);

            return instanciated;
        }
    }
}
