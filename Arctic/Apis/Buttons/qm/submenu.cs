using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Arctic.Apis.Buttons.qm
{
    public class submenu
    {


        public static List<GameObject> submenuslist = new List<GameObject>();

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public static GameObject Submenu(string text, GameObject? indexer)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            GameObject gam = new GameObject();
            gam.AddComponent<UnityEngine.CanvasGroup>();
            Wrappers.Resettransform.reset(gam);
            gam.transform.rotation = new Quaternion(0, 0, 0, 0);
            gam.transform.localPosition = new Vector3(0, 512, 0);
            gam.name = $"Submenu_{text}";
            gam.transform.parent = Prefabs.Submenu.transform;
            gam.SetActive(false);
            var mask = new GameObject();
            mask.transform.parent = gam.transform;
            mask.AddComponent<UIInvisibleGraphic>();
            mask.AddComponent<UnityEngine.UI.RectMask2D>();

            mask.transform.localScale = new Vector3(10.5f, 9.2f, 1);
            mask.transform.localPosition = new Vector3(0f, -554.4909f, 0);
            mask.transform.localRotation = new Quaternion(0, 0, 0, 0);
            mask.name = "Masked";
            var instanciateds = GameObject.Instantiate(Prefabs.Submenu.transform.Find("Header_DevTools").gameObject, gam.transform);
            instanciateds.transform.Find("LeftItemContainer/Text_Title").GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciateds.transform.localPosition = new Vector3(-514, 0, 0);
            var instanciated = GameObject.Instantiate(Prefabs.Submenu.transform.Find("Scrollrect").gameObject, mask.transform);
            instanciated.transform.localPosition = new Vector3(0, 50, 0);
            instanciated.transform.localScale = new Vector3(0.095f, 0.11f, 1f);
            instanciated.gameObject.SetActive(true);
            instanciated.GetComponent<ScrollRect>().enabled = true;
            foreach (var ab in instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
            {
                GameObject.DestroyImmediate(ab.gameObject);
            }





            instanciated.transform.Find("Viewport/VerticalLayoutGroup").gameObject.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().childControlHeight = true;
            Component.DestroyImmediate(instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.GetComponent<GridLayoutGroup>());
            instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.AddComponent<GridLayoutGroup>().cellSize = new Vector2(1100, 150);
            instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.SetActive(false);
            submenuslist.Add(gam.gameObject);

            if (indexer != null)
            {

                var buttoni = instanciateds.transform.Find("LeftItemContainer/Button_Back").gameObject.GetComponent<UnityEngine.UI.Button>();

                buttoni.gameObject.SetActive(true);

                buttoni.onClick.RemoveAllListeners();

                buttoni.onClick.AddListener(new Action(() =>
                {

                    foreach (GameObject gameobject in submenuslist)
                    {

                        if (gameobject != indexer.gameObject)
                            gameobject.SetActive(false);
                        else
                        {
                            Page.lastmen = gameobject;
                            gameobject.SetActive(true);
                            Submenubutton.timedeltaspeed(gameobject.gameObject);

                        }

                    }

                }));
            }


            return gam;


        }

    }
}
