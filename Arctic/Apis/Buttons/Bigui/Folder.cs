using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Arctic.Wrappers;
using Arctic.Apis;
using MelonLoader;
using System.Collections;

namespace Arctic.Apis.Buttons
{
    public class Folder
    {
        public static GameObject Biguifolder(string Text,GameObject Path)
        {
            var toinst = GameObject.Find("UserInterface").transform.Find("MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab");
            var isinstbutton = GameObject.Instantiate(toinst, Path.transform);
            isinstbutton.name = $"Folder_{Text}";
            Component.Destroy(isinstbutton.GetComponent<VRCUiPageTab>());
            var text =  isinstbutton.transform.Find("Button/Text").GetComponent<Text>();
            text.text = Text;
            text.fontSize += 2;
            text.alignment = TextAnchor.UpperLeft;
            Resettransform.reset(isinstbutton.gameObject);
            isinstbutton.transform.rotation = new Quaternion(0, 0, 0, 0);

            var childcontainer = new GameObject();
            childcontainer.transform.parent = isinstbutton.transform;
            childcontainer.name = "Container";
            var image = GameObject.Instantiate(childcontainer, childcontainer.transform.parent);
            image.name = "Image";
            image.AddComponent<Image>();
            Resettransform.reset(image.gameObject);
            Resettransform.reset(childcontainer.gameObject);

            childcontainer.transform.rotation = new Quaternion(0, 0, 0, 0);
            image.transform.rotation = new Quaternion(0, 0, 0, 0);

            childcontainer.transform.localPosition = new Vector3(-60.9902f, -39.8522f, 0);
            childcontainer.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            image.transform.GetComponent<RectTransform>().sizeDelta /= 2f;
            image.transform.localPosition = new Vector3(image.transform.localPosition.x - 120, image.transform.localPosition.y + 20, image.transform.localPosition.z);
            image.AddComponent<Button>();
            Component.Destroy(isinstbutton.GetComponent<Image>());
            isinstbutton.gameObject.AddComponent<UIInvisibleGraphic>();
            MelonLoader.MelonCoroutines.Start(Apis.image.LoadSpriteBetter(image.GetComponent<Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Arrow.png"));
            childcontainer.AddComponent<VerticalLayoutGroup>();
            Component.Destroy(isinstbutton.transform.Find("Button").gameObject.GetComponent<Button>());
            Button button = image.GetComponent<Button>();
            RectTransform rect = image.GetComponent<RectTransform>();
            rect.localEulerAngles = new Vector3(0, 0, 90);
            isinstbutton.transform.Find("Container").gameObject.SetActive(false);
            childcontainer.transform.localScale = new Vector3(0, 0, 0);
            button.onClick.AddListener(new Action(() =>
            {
                if (rect.localEulerAngles == new Vector3(0, 0, 0))
                {
                    MelonCoroutines.Start(Arrow(rect,true));
                    MelonCoroutines.Start(loadfolder(isinstbutton.transform.Find("Container").gameObject));
                }
                else
                {
                    isinstbutton.transform.Find("Container").gameObject.SetActive(true);
                    MelonCoroutines.Start(Arrow(rect, false));
                    MelonCoroutines.Start(loadfolder(isinstbutton.transform.Find("Container").gameObject));

                }
            }));

            return isinstbutton.gameObject;
        }

        private static IEnumerator Arrow(RectTransform rect,bool bools)
        {
            if (bools)
            {
                for (; ; )
                {

                    if (rect.localEulerAngles.z >= 90)
                    {
                        rect.localEulerAngles = new Vector3(0, 0, 90);
                        yield break;
                    }

                        rect.localEulerAngles = new Vector3(0, 0, rect.localEulerAngles.z + 8);
                    yield return new WaitForSeconds(0.008f);
                }
            }
            else
            {
                for (; ; )
                {

                    if (rect.localEulerAngles.z <= 17)
                    {
                        rect.localEulerAngles = new Vector3(0, 0, 0);
                        yield break;
                    }

                    rect.localEulerAngles = new Vector3(0, 0, rect.localEulerAngles.z - 8);
                    yield return new WaitForSeconds(0.008f);
                }
            }
        }
            private static IEnumerator loadfolder(GameObject gameobject)
        {
            if (gameobject.transform.localScale.x == 0.7f)
            {
                for (; ; )
                {
                    if (gameobject.transform.localScale.x <= 0)
                    {
                        gameobject.transform.localScale = new Vector3(0, 0, 0);
                        gameobject.SetActive(false);
                        yield break;
                    }

                    gameobject.transform.localScale = new Vector3(gameobject.transform.localScale.x - 0.07f, gameobject.transform.localScale.y - 0.07f, gameobject.transform.localScale.z - 0.07f);
                    yield return new WaitForSeconds(0.008f);
                }
            }
            else
            {

                for (; ; )
                {
                    if (gameobject.transform.localScale.x >= 0.7f)
                    {
                        gameobject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        gameobject.SetActive(true);
                        yield break;
                    }

                    gameobject.transform.localScale = new Vector3(gameobject.transform.localScale.x + 0.07f, gameobject.transform.localScale.y + 0.07f, gameobject.transform.localScale.z + 0.07f);
                    yield return new WaitForSeconds(0.008f);
                }
            }



        }
    }
}
