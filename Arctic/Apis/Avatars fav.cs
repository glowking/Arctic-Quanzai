using System;
using UnityEngine;
using UnityEngine.UI;
namespace Arctic.Apis
{
    class Avatars_fav
    {

        public static string avataridt = "";
        public static string avataridt2 = "";
        public static string Image = "";

        public static int havicount = 0;
        public static GameObject curentgmj;

        public static GameObject avilist(string name)
        {
            var gmj = GameObject.Find("/UserInterface").transform.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List").gameObject;
            var instanciated = GameObject.Instantiate(gmj, gmj.transform.parent);
            Component.Destroy(instanciated.GetComponent<UiAvatarList>());
            instanciated.name = $"Favp_{name}";
            var avif = instanciated.transform.Find("ViewPort/Content");
            foreach (var a in avif.GetComponentsInChildren<LayoutElement>())
            {
                GameObject.Destroy(a.gameObject);
            }
            try
            {
                //GameObject.Destroy(instanciated.transform.Find("GetMoreFavorites").gameObject);
            }
            catch { Console.WriteLine("Failed TO destroy FavortiesButton"); }
            instanciated.transform.Find("Button/TitleText").gameObject.GetComponent<Text>().text = name;
            instanciated.gameObject.SetActive(true);
            instanciated.transform.SetSiblingIndex(0);
            try
            {
                GameObject.Destroy(instanciated.transform.Find("Button/ToggleIcon").gameObject);
            }
            catch { Console.WriteLine("Failed TO destroy Button/ToggleIcon"); }
            instanciated.transform.Find("Button/TitleText").transform.localPosition = new Vector3(63.7724f, 0, 0);
            return instanciated;
        }


        public static GameObject createavi(GameObject gmj, string avatarid, string text, string image, string platform, int selectedid)
        {

            var ab = true;
            var inst = new GameObject();
            foreach (var a in Resources.FindObjectsOfTypeAll<VRCUiContentButton>())
            {
                if (a.name == "AvatarUiPrefab2" && ab)
                {
                    ab = false;
                    inst = GameObject.Instantiate(a, gmj.transform.Find("ViewPort/Content").transform).gameObject;

                }
            }
            var inst2 = new GameObject();
            inst.name = $"AvatarUiPrefab2_{text}";
            Component.DestroyImmediate(inst.GetComponent<VRCUiContentButton>());
            Component.DestroyImmediate(inst.transform.Find("RoomImageShape/RoomImage").gameObject.GetComponent<RawImage>());
            Component.DestroyImmediate(inst.GetComponent<UiFeatureList>());
            Component.DestroyImmediate(inst.GetComponent<UiFeaturedButton>());
            Component.DestroyImmediate(inst.transform.Find("RoomImageShape").gameObject.GetComponent<UnityEngine.UI.Mask>());
            Component.DestroyImmediate(inst.transform.Find("RoomImageShape").gameObject.GetComponent<UnityEngine.UI.Image>());

            inst.transform.Find("RoomImageShape").gameObject.SetActive(true);
            //  inst.gameObject.AddComponent<UnityEngine.UI.Button>();
            // inst.AddComponent<UnityEngine.UI.Image>();
            inst.transform.Find("TitleText").GetComponent<UnityEngine.UI.Text>().text = text;
            inst.transform.Find("TitleText").localPosition = new Vector3(-18.4f, -68.45f, -1);
            var img = inst.transform.Find("RoomImageShape/RoomImage").gameObject.AddComponent<UnityEngine.UI.Image>();
            var fav = inst.transform.Find("GrayScaleMask");
            fav.gameObject.SetActive(false);
            inst.transform.Find("RoomImageShape/RoomImage/Panel").gameObject.transform.localScale = new Vector3(1.03f, 1.1f, 1);
            inst.transform.Find("RoomImageShape/RoomImage/Panel").gameObject.transform.localPosition = new Vector3(0, -79f, 0);
            inst.transform.Find("RoomImageShape/RoomImage").gameObject.transform.localScale = new Vector3(0.95f, 0.92f, 0.9f);
            inst.transform.Find("RoomImageShape/RoomImage").gameObject.transform.localPosition = new Vector3(0, 0, -0.1f);

            fav.transform.localPosition = new Vector3(116.5892f, 70.813f, -0.3f);
            inst.gameObject.SetActive(true);
            MelonLoader.MelonCoroutines.Start(Apis.image.LoadSpriteBetter(img, image));
            var gmjs = new GameObject();
            gmjs.transform.parent = inst.transform;
            Wrappers.Resettransform.reset(gmjs);
            gmjs.transform.localRotation = new Quaternion(0, 0, 0, 0);
            gmjs.gameObject.AddComponent<UnityEngine.UI.Button>();
            gmjs.gameObject.AddComponent<UIInvisibleGraphic>();
            // gmjs.transform.localScale = new Vector3(3, 0.2f, 1);
            gmjs.transform.localScale = new Vector3(3, 1.8f, 1);

            inst.transform.Find("TitleText").gameObject.SetActive(true);
            inst.transform.Find("RoomOutline").gameObject.SetActive(true);
            var lay = inst.GetComponent<UnityEngine.UI.LayoutElement>();
            lay.ignoreLayout = false;
            inst.transform.Find("RoomImageShape/OverlayIcons/MobileIcons").transform.localPosition = new Vector3(0f, -32.84f, 0);
            if (platform == "StandaloneWindows")
                inst.transform.Find("RoomImageShape/OverlayIcons/MobileIcons/IconPlatformPC").gameObject.SetActive(true);
            else if (platform == "All")
                inst.transform.Find("RoomImageShape/OverlayIcons/MobileIcons/IconPlatformAny").gameObject.SetActive(true);
            else
                inst.transform.Find("RoomImageShape/OverlayIcons/MobileIcons/IconPlatformMobile").gameObject.SetActive(true);
            gmjs.transform.localPosition = new Vector3(0, 0, 0);
            gmjs.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() =>
            {
                if (selectedid == 1)
                    avataridt = avatarid;
                else
                {
                    Image = image;
                    avataridt2 = avatarid;
                    curentgmj = inst;
                }

                foreach (var a in gmj.transform.Find("ViewPort/Content").gameObject.GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                {
                    if (a.name.Contains("AvatarUiPrefab2"))
                    {
                        a.transform.Find("RoomImageShape/OverlayIcons/iconFavoriteStar").gameObject.SetActive(false);
                    }
                }
                inst.transform.Find("RoomImageShape/OverlayIcons/iconFavoriteStar").gameObject.SetActive(true);

            }));

            return inst;
        }
    }
}
