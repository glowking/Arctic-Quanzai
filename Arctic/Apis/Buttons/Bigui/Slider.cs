using System;
using UnityEngine;
namespace Arctic.Apis.Buttons
{
    public class Sliders
    {

#pragma warning disable IDE0060 // Remove unused parameter
        public static GameObject slider(GameObject parent, Action<float> setOutput, float? prevolume, Action? todo, string title, bool extratitleprocent = false, float mutliplier = 1f)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var abb = GameObject.Find("UserInterface").transform.Find("MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab").gameObject;
            var a = GameObject.Instantiate(abb, parent.transform);
            Component.Destroy(a.GetComponent<UnityEngine.UI.Image>());
            GameObject.DestroyImmediate(a.transform.Find("Button").gameObject);
            Component.Destroy(a.GetComponent<VRCUiPageTab>());
            a.name = "Slider_";
            Wrappers.Resettransform.reset(a);
            a.transform.localScale = new Vector3(0.7f, 0.8f, 1);
            var toinst = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/AudioDevicePanel/VolumeSlider").gameObject;
            var instanciated = GameObject.Instantiate(toinst, a.transform);
            Wrappers.Resettransform.reset(instanciated);
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
            a.transform.rotation = new Quaternion(0, 0, 0, 0);
            var toinst2 = instanciated.gameObject.transform.Find("Fill Area/Label");
            var newtitle = GameObject.Instantiate(toinst2, toinst2.transform.parent);


            newtitle.transform.localPosition = new Vector3(0, 50, 0);
            newtitle.gameObject.GetComponent<UnityEngine.UI.Text>().text = $"{title}";
            newtitle.name = $"Title_{title}";
            newtitle.gameObject.GetComponent<UnityEngine.UI.Text>().fontStyle = FontStyle.Bold;

            var sliderg = instanciated.GetComponent<UnityEngine.UI.Slider>();
            if (prevolume != null)
                sliderg.value = (float)prevolume;
            sliderg.onValueChanged.RemoveAllListeners();
            sliderg.m_OnValueChanged.RemoveAllListeners();
            var slidertext = instanciated.transform.Find("Fill Area/Label").GetComponent<UnityEngine.UI.Text>();
            slidertext.text = $"{prevolume * 100}%";
            sliderg.onValueChanged.AddListener((UnityEngine.Events.UnityAction<float>)sliderstuff);
            if (extratitleprocent)
            {
                var newtitle2 = GameObject.Instantiate(toinst2, toinst2.transform.parent).gameObject;
                newtitle2.transform.localPosition = new Vector3(0, -50, 0);
                newtitle2.gameObject.GetComponent<UnityEngine.UI.Text>().text = $"{(int)Math.Round(sliderg.value) * mutliplier} {title}";
                newtitle2.name = "Tobecomeothernumb";
            }
            void sliderstuff(float values)
            {
                if (extratitleprocent)
                {
                    instanciated.gameObject.transform.Find("Fill Area/Tobecomeothernumb").gameObject.GetComponent<UnityEngine.UI.Text>().text = $"{(int)Math.Round(values) * mutliplier} {title}";
                }
                slidertext.text = $"{values * 100}%";
                setOutput(values);
                if (todo != null)
                    todo.Invoke();
            }



            return instanciated.gameObject;
        }
    }
}
