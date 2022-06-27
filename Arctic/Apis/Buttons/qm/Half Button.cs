using System;
using UnityEngine;
namespace Arctic.Apis.Buttons.qm
{
    public class HalfButton
    {
        public static GameObject button(string text, GameObject menu, Action action)
        {
            var instanciated = GameObject.Instantiate(Prefabs.ButtonPrefab, menu.transform).gameObject;
            instanciated.name = $"Button_{text}";
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() => { action.Invoke(); Style.textdebuger.debugermsg($"<color=#ff00ffff>Pressed on</color> [<color=#00ffffff>{text}]</color>"); }));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
            instanciated.transform.Find("Icon").gameObject.SetActive(true);
            instanciated.transform.Find("Text_H4").transform.localPosition = new Vector3(0, -22, 0);
            instanciated.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -80);

            return instanciated;
        }

    }
}
