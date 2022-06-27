using System;
using UnityEngine;
using UnityEngine.UI;


namespace Arctic.Apis.Buttons.qm
{
    public class Toggles
    {
        public static GameObject toggle(string text, GameObject menu, Action vtrue, Action vfalse, bool? prevalue)
        {
            var instanciated = GameObject.Instantiate(Prefabs.TogglePrebab, menu.transform).gameObject;
            instanciated.name = $"Toggle_{text}";
            var toggle = instanciated.GetComponent<UnityEngine.UI.Toggle>();
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)Gettoggle);
            instanciated.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = text;
            var iconoff = instanciated.transform.Find("Icon_Off");
            var iconon = instanciated.transform.Find("Icon_On");
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            Component.Destroy(iconoff.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            Component.Destroy(iconon.GetComponent<VRC.UI.Core.Styles.StyleElement>());

            if (prevalue != null && prevalue == true)
            {
                toggle.isOn = true;
                iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);

            }
            else
            {
                toggle.isOn = false;
                iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
            }
            void Gettoggle(bool value)
            {
                var iconoff = instanciated.transform.Find("Icon_Off");
                var iconon = instanciated.transform.Find("Icon_On");
                if (value)
                {
                    iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                    Style.textdebuger.debugermsg($"<color=#00ff00ff>Toggled on</color> [{text}]");

                    vtrue.Invoke();
                }
                else
                {
                    Style.textdebuger.debugermsg($"<color=#ff0000ff>Toggled off</color> [{text}]");
                    iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                    iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    vfalse.Invoke();

                }

            }


            return instanciated;
        }
    }
}
