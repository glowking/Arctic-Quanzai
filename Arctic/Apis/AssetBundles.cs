using MelonLoader;
using System.Collections;
using UnityEngine;

namespace Arctic.Apis
{
    public class AssetBundles
    {
        public static GameObject uia;
        public static GameObject uia1;
        public static GameObject esp;
        public static GameObject partsystem;

        public static IEnumerator loadbox()
        {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile($"{MelonUtils.GameDirectory}\\Arctic\\aseetbundles\\box");
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            esp = myLoadedAssetBundle.LoadAsset<GameObject>("meds");
            esp.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
            esp.transform.position -= new Vector3(0, 1f, 0);
            esp.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            esp.transform.Find("default").gameObject.layer = 19;
            myLoadedAssetBundle.Unload(false);
            yield return null;
        }
        public static IEnumerator loadbundle()
        {
            //nocturnal-client.xyz/cl/Download/Assets/join

            var wc = new System.Net.WebClient();
            var bytes = wc.DownloadData("http://nocturnal-client.xyz/cl/Download/Assets/join");
            var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytes);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            var toinst = myLoadedAssetBundle.LoadAsset<GameObject>("JoinNot");
            myLoadedAssetBundle.Unload(false);
            var instanciate = GameObject.Instantiate(toinst, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent").transform);
            instanciate.name = "Join Logger";
            Component.Destroy(instanciate.GetComponent<Canvas>());
            Component.Destroy(instanciate.GetComponent<UnityEngine.UI.CanvasScaler>());
            Component.Destroy(instanciate.GetComponent<UnityEngine.UI.GraphicRaycaster>());
            Wrappers.Resettransform.reset(instanciate);
            instanciate.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            uia = instanciate.transform.Find("JoinElement").gameObject;
            instanciate.transform.Find("JoinElement/Image").gameObject.transform.localPosition = new Vector3(0, -330, 0);

            var bytess = wc.DownloadData("http://nocturnal-client.xyz/cl/Download/Assets/join2");
            // var bytess = wc.DownloadData("https://api.glowking.net/cl/assets/Join");
            var myLoadedAssetBundle2 = AssetBundle.LoadFromMemory(bytess);
            if (myLoadedAssetBundle2 == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            var toinsts = myLoadedAssetBundle2.LoadAsset<GameObject>("JoinNot2");
            myLoadedAssetBundle2.Unload(false);
            var instanciates = GameObject.Instantiate(toinsts, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent").transform);
            instanciates.name = "Leave Logger";
            Component.Destroy(instanciates.GetComponent<Canvas>());
            Component.Destroy(instanciates.GetComponent<UnityEngine.UI.CanvasScaler>());
            Component.Destroy(instanciates.GetComponent<UnityEngine.UI.GraphicRaycaster>());
            Wrappers.Resettransform.reset(instanciates);
            instanciates.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            uia1 = instanciates.transform.Find("JoinElement").gameObject;
            instanciates.transform.Find("JoinElement/Image").gameObject.transform.localPosition = new Vector3(0, -330, 0);
            //http://nocturnal-client.xyz/cl/Download/Nameplate-red.png
            yield return null;
        }

        //particles
        public static IEnumerator loadparticles()
        {

            var wc = new System.Net.WebClient();

            var bytesa = wc.DownloadData("http://nocturnal-client.xyz/cl/Download/Assets/loadingscreen");
            var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytesa);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            partsystem = myLoadedAssetBundle.LoadAsset<GameObject>("ParticleLoader");
            var gmj = GameObject.Instantiate(partsystem, GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").transform);
            gmj.transform.localPosition = new Vector3(0, 0, 8000);
            gmj.transform.Find("finished").gameObject.transform.localPosition = new Vector3(0, 0, 10000);
            gmj.transform.Find("finished/Other").gameObject.transform.localPosition = new Vector3(0, 0, 3000);
            gmj.transform.Find("middle").gameObject.transform.localPosition = new Vector3(-50, 0f, 10000);
            gmj.transform.Find("cirlce mid").gameObject.transform.localPosition = new Vector3(-673.8608f, 0, 4000);
            gmj.transform.Find("spawn").gameObject.transform.localPosition = new Vector3(800, 0, -8500f);

            foreach (var gmjs in gmj.GetComponentsInChildren<ParticleSystem>(true))
            {
                gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
            }
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements").gameObject.SetActive(false);

            while (GameObject.Find("/UserInterface").transform.Find("DesktopUImanager") == null)
                yield return null;


            var toload = myLoadedAssetBundle.LoadAsset<GameObject>("Holder");

            myLoadedAssetBundle.Unload(false);
            var gmjsa = GameObject.Instantiate(toload, GameObject.Find("/UserInterface").transform.Find("DesktopUImanager").transform);
            gmjsa.transform.localPosition = new Vector3(0, 360.621f, 700);
            gmjsa.transform.localRotation = new Quaternion(0, 0, 0, 0);
            gmjsa.transform.localScale = new Vector3(1, 1, 1);
            var p1 = gmjsa.transform.Find("Particle System").transform;
            p1.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            p1.localPosition = new Vector3(0, 64.16f, 7.2f);
            var p2 = gmjsa.transform.Find("Particle System (1)").transform;
            p2.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            p2.localPosition = new Vector3(-30.78f, -321.5403f, 8.54f);
            yield return null;


        }

        public static IEnumerator loadparticles2()
        {

            var wc = new System.Net.WebClient();

            var bytesa = wc.DownloadData("https://api.glowking.net/cl/assets/loadingscreen2");
            var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytesa);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            partsystem = myLoadedAssetBundle.LoadAsset<GameObject>("ParticleLoader");
            var gmj = GameObject.Instantiate(partsystem, GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").transform);
            gmj.transform.localPosition = new Vector3(0, 0, 8000);
            gmj.transform.Find("finished").gameObject.transform.localPosition = new Vector3(0, 0, 10000);
            gmj.transform.Find("finished/Other").gameObject.transform.localPosition = new Vector3(0, 0, 3000);
            gmj.transform.Find("middle").gameObject.transform.localPosition = new Vector3(-50, 0f, 10000);
            gmj.transform.Find("cirlce mid").gameObject.transform.localPosition = new Vector3(-673.8608f, 0, 4000);
            gmj.transform.Find("spawn").gameObject.transform.localPosition = new Vector3(800, 0, -8500f);

            foreach (var gmjs in gmj.GetComponentsInChildren<ParticleSystem>(true))
            {
                gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
            }
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements").gameObject.SetActive(false);

            while (GameObject.Find("/UserInterface").transform.Find("DesktopUImanager") == null)
                yield return null;


            var toload = myLoadedAssetBundle.LoadAsset<GameObject>("Holder");

            myLoadedAssetBundle.Unload(false);
            var gmjsa = GameObject.Instantiate(toload, GameObject.Find("/UserInterface").transform.Find("DesktopUImanager").transform);
            gmjsa.transform.localPosition = new Vector3(0, 360.621f, 700);
            gmjsa.transform.localRotation = new Quaternion(0, 0, 0, 0);
            gmjsa.transform.localScale = new Vector3(1, 1, 1);
            var p1 = gmjsa.transform.Find("Particle System").transform;
            p1.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            p1.localPosition = new Vector3(0, 64.16f, 7.2f);
            var p2 = gmjsa.transform.Find("Particle System (1)").transform;
            p2.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            p2.localPosition = new Vector3(-30.78f, -321.5403f, 8.54f);
            loadparticles2();
            yield return null;


        }





        public static IEnumerator loadshit()
        {
            //nocturnal-client.xyz/cl/rain
            if (settings.nconfig.rainbackground)
            {
                var wc = new System.Net.WebClient();
                var bytesa = wc.DownloadData("http://nocturnal-client.xyz/cl/rain");
                var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytesa);
                if (myLoadedAssetBundle == null)
                {
                    Debug.Log("Failed to load AssetBundle!");
                    yield break;
                }
                partsystem = myLoadedAssetBundle.LoadAsset<GameObject>("Rain");
                myLoadedAssetBundle.Unload(false);

                var gmj = GameObject.Instantiate(partsystem, GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").transform);
                gmj.transform.localPosition = new Vector3(0, 0, 0);
                gmj.transform.rotation = new Quaternion(0, 0, 0, 0);
                gmj.transform.localScale = new Vector3(1, 1, 1);

                gmj.transform.Find("Canvas/Image").gameObject.name = "Raini";
                gmj.transform.Find("Canvas/Raini").transform.parent = gmj.transform.parent;
                var img = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Raini");

                img.transform.SetSiblingIndex(0);
                img.transform.localScale = new Vector3(15.3f, 10.31f, 1);
                img.transform.localPosition = new Vector3(0, 0, -0.1f);
                var matts = img.GetComponent<UnityEngine.UI.Image>().material;
                img.gameObject.layer = 19;
                matts.EnableKeyword("_y");
                matts.EnableKeyword("_x");
                matts.SetFloat("_y", 2f);
                matts.SetFloat("_x", 4f);

                try
                {
                    GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").GetComponent<UnityEngine.UI.Image>().materialForRendering.renderQueue = 2999;
                    //19
                }
                catch { Style.Consoles.consolelogger("FAILED CHANGING BACKGROUND RENDER QUE"); };

            }
            yield return null;

            //Rain

        }


        public static IEnumerator startanim()
        {

            var wc = new System.Net.WebClient();

             var bytesa = wc.DownloadData("https://api.glowking.net/cl/assets/onstart2");
            //var bytesa = wc.DownloadData("https://nocturnal-client.xyz/cl/Download/onstartanim");
           
            var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytesa);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            var gmj = myLoadedAssetBundle.LoadAsset<GameObject>("toload");
            myLoadedAssetBundle.Unload(false);
            var ssystem = GameObject.Instantiate(gmj, GameObject.Find("/UserInterface").transform.Find("MenuContent").transform);


            //ssystem.transform.parent = GameObject.Find("/UserInterface").transform.Find("LoadingBackground_TealGradient_Music").transform;
            ssystem.transform.localScale = new Vector3(1, 1, 1);
            ssystem.transform.localPosition = new Vector3(0, 0, 0);
            ssystem.transform.localRotation = new Quaternion(0, 0, 0, 0);

            ssystem.transform.Find("Anim").transform.localScale = new Vector3(50, 50, 50);
            ssystem.transform.Find("Anim").transform.localPosition = new Vector3(8, -42.1199f, -1001);
            ssystem.transform.Find("Anim/Plane").gameObject.layer = 19;
            ssystem.name = "Animation";
            ssystem.transform.Find("Anim").gameObject.GetComponent<AudioSource>().volume = 0.2f;
            //GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup").gameObject.SetActive(false);
            // GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Authentication/LoginUserPass").gameObject.SetActive(false);


            //Style.Consoles.consolelogger(ssystem.transform.ToString() + "  " + ssystem.name);
            yield return null;

        }
    }
}
