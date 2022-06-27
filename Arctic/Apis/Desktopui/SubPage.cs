using System;
using UnityEngine;

namespace Arctic.Apis.Desktopui
{
    public class SubPage
    {
        public static GameObject Createsubmenu(string text, bool iscloseable, GameObject menu)
        {
            var toinst = menu.transform.Find("Background(Clone)");
            var instanciated = GameObject.Instantiate(toinst, toinst.parent);
            instanciated.name = $"Submenu_{text}";
            instanciated.gameObject.transform.localScale = new Vector3(0.2f, 0.35f, 1f);
            instanciated.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.9f);
            var instagina = GameObject.Instantiate(instanciated, instanciated.transform);
            var title = GameObject.Instantiate(instagina, instagina.transform);
            if (iscloseable)
            {
                var closebtn = GameObject.Instantiate(instagina, instagina.transform);
                var isbutton = closebtn.gameObject.AddComponent<UnityEngine.UI.Button>();
                var img = closebtn.gameObject.GetComponent<UnityEngine.UI.Image>();
                closebtn.transform.localScale = new Vector3(0.092f, 0.75f, 1);
                closebtn.transform.localPosition = new Vector3(669.58f, -1.8f, 0);
                MelonLoader.MelonCoroutines.Start(Apis.image.loadspriterest(img, "https://nocturnal-client.xyz/cl/Download/Media/Buttonx.png"));
                img.color = new Color(0.6351058f, 0, 0.304383218f, 0.8f);
                closebtn.name = "CloseButton";
                isbutton.onClick.AddListener(new Action(() => instanciated.gameObject.SetActive(false)));
            }
            instagina.gameObject.AddComponent<UnityEngine.BoxCollider2D>();
            instagina.name = "TitlePage";
            title.name = "Title";
            instagina.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.2f, 0.2f, 0.2f, 0.7f);
            instagina.gameObject.transform.localScale = new Vector3(1, 0.10f, 1);
            instagina.gameObject.transform.localPosition = new Vector3(0, 463.9554f, 0);
            title.gameObject.transform.localScale = new Vector3(3f, 15f, 3);
            title.gameObject.transform.localPosition = new Vector3(1563.52f, -7300, 0);
            instagina.gameObject.AddComponent<monobehaviours.Dragg>();
            Component.DestroyImmediate(title.GetComponent<UnityEngine.UI.Image>());
            var tittlecomp = title.gameObject.AddComponent<TMPro.TextMeshProUGUI>();
            tittlecomp.richText = true;
            tittlecomp.enableWordWrapping = false;
            tittlecomp.color = Color.white;
            tittlecomp.text = text;
            tittlecomp.alignment = TMPro.TextAlignmentOptions.TopLeft;


            return instanciated.gameObject;
        }


    }
}
