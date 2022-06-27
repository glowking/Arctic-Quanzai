using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
namespace Arctic.Apis.Buttons.qm
{
    public class Submenubutton
    {
        private static float speed = 1f;

        public static GameObject submenu(string text, GameObject menu, GameObject menutoopen, string image = null)
        {


            var instanciated = GameObject.Instantiate(Prefabs.ButtonPrefab, menu.transform).gameObject;
            Component.DestroyImmediate(instanciated.transform.Find("Icon").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            instanciated.name = $"SubBtn_{text}";
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() =>
            {
                foreach (GameObject gmj in qm.submenu.submenuslist)
                    if (gmj != menutoopen)
                    {

                        gmj.SetActive(false);
                    }
                    else
                    {
                        Page.lastmen = gmj;
                        gmj.SetActive(true);
                        MelonCoroutines.Start(timedeltaspeed(gmj));
                    }

                Style.textdebuger.debugermsg($"<color=#add8e6ff>Opened</color> [<color=#0000ffff>{text}</color>]");

            }));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            if (image != null)
            {
                MelonCoroutines.Start(Apis.image.loadspriterest(instanciated.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>(), image));
            }
            if (!settings.nconfig.Overwritetextcolor)
                instanciated.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            return instanciated;
        }
        public static IEnumerator timedeltaspeed(GameObject gmj)
        {
            for (; ; )
            {
                speed += Time.deltaTime * 7000;
                if (gmj.name != "Main menu")
                    gmj.transform.localPosition = new Vector3(1000 - speed, gmj.transform.localPosition.y, 0);

                else
                    gmj.transform.localPosition = new Vector3(1000 - speed, gmj.transform.localPosition.y, 0);
                if (gmj.transform.localPosition.x <= 0)
                {
                    if (gmj.name != "Main menu")
                        gmj.transform.localPosition = new Vector3(0, gmj.transform.localPosition.y, 0);
                    else
                        gmj.transform.localPosition = new Vector3(0, gmj.transform.localPosition.y, 0);
                    speed = 1;
                    yield break;
                }


                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
