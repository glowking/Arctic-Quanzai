using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Arctic.style
{
    class Loading_Screen
    {

        public static IEnumerator LoadingScreen()
        {
            try
            {
                var ovcolor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/Rectangle").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/MidRing").GetComponent<Image>().color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/InnerDashRing").GetComponent<Image>().color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/ButtonMiddle").GetComponent<Button>().image.color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/RingGlow").GetComponent<Image>().color = ovcolor;
                GameObject.Find("/UserInterface/LoadingBackground_TealGradient_Music/SkyCube_Baked").SetActive(false);
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/ArrowRight").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/ArrowLeft").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/TitleText").GetComponent<Text>().color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/ProgressLine").GetComponent<Image>().color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/StandardPopup/TitleText").GetComponent<UnityEngine.UI.Outline>().enabled = false;
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingInfoPanel").SetActive(false);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").SetActive(false);
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Panel_Backdrop").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Right").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>().color = Color.clear;
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/GoButton").GetComponent<Button>().image.color = ovcolor;
                GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>().color = Color.clear;
                MelonCoroutines.Start(loadingscreen());
                if (GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ButtonMiddle") == null)
                {
                    Style.Consoles.consolelogger("Home Button failed");
                }
                else
                {
                    GameObject.Find("/UserInterface/MenuContent/Popups/LoadingPopup/ButtonMiddle").GetComponent<Button>().image.color = ovcolor;
                }
                Style.Consoles.consolelogger("Step 1 Finished");
            }
            catch
            {
                Style.Consoles.consolelogger("The custom loading screen failed to load");
            }

            yield return null;
        }

        private static bool isvideo = true;
        private static RenderTexture rendert;

        public static IEnumerator loadingscreen()
        {
            if (settings.nconfig.Videoplayer)
            {
                var isbackround = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ButtonMiddle").GetComponent<Image>();
                var isbackround1 = GameObject.Instantiate(isbackround, isbackround.transform.parent);
                isbackround1.gameObject.name = "Video";
                var delettext = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/Video/Text");

                GameObject.Destroy(delettext);
                if (!settings.nconfig.BigVideoLoadingscreen)
                {
                    isbackround1.GetComponent<RectTransform>().anchoredPosition += new Vector2(1370, 1200);
                    isbackround1.GetComponent<RectTransform>().sizeDelta /= new Vector2(0.9f, 0.3f);
                    isbackround1.GetComponent<UnityEngine.UI.Button>().enabled = false;
                    isbackround1.GetComponent<RectTransform>().sizeDelta /= new Vector2(0.9f, 0.9f);

                    var isbackround2 = GameObject.Instantiate(isbackround1, isbackround1.transform);
                    isbackround2.name = "Backround";
                    isbackround2.transform.localPosition = new Vector3(0, 0, 0);
                    isbackround2.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
                    var bg2img = isbackround2.GetComponent<Image>();
                    MelonCoroutines.Start(Apis.image.loadspriterest(bg2img, "http://nocturnal-client.xyz/cl/Download/Media/just%20border.png"));
                }
                else
                {
                    isbackround1.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0);
                    isbackround1.transform.localPosition = new Vector3(0, 220.4001f, 0);
                    isbackround1.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                    var isbackround2 = GameObject.Instantiate(isbackround1, isbackround1.transform);
                    isbackround2.name = "Backround";
                    isbackround2.transform.localPosition = new Vector3(0, 0, 0);
                    isbackround2.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
                    var bg2img = isbackround2.GetComponent<Image>();
                    MelonCoroutines.Start(Apis.image.loadspriterest(bg2img, "http://nocturnal-client.xyz/cl/Download/Media/just%20border.png"));
                }

                if (isvideo == true)
                {
                    var objb = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/Video");
                    Component.Destroy(objb.GetComponent<Button>());
                    Component.Destroy(objb.transform.Find("Backround").gameObject.GetComponent<Button>());

                    objb.GetComponent<Image>().sprite = null;
                    objb.AddComponent<UnityEngine.Video.VideoPlayer>();
                    var vidcomp = objb.GetComponent<UnityEngine.Video.VideoPlayer>();
                    vidcomp.isLooping = true;
                    rendert = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);
                    rendert.Create();
                    Material mat = new Material(Shader.Find("Standard"));
                    mat.color = default;
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.white);

                    mat.SetTexture("_EmissionMap", rendert);
                    objb.GetComponent<Image>().material = mat;
                    vidcomp.targetTexture = rendert;
                    vidcomp.url = $"{MelonUtils.GameDirectory}\\Arctic\\LoadingVid.mp4";
                    while (GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/LoadingSound").GetComponent<AudioSource>() == null)
                        yield return null;

                    var getauds = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/LoadingSound").GetComponent<AudioSource>();
                    getauds.clip = null;

                    vidcomp.audioOutputMode = VideoAudioOutputMode.AudioSource;
                    vidcomp.EnableAudioTrack(0, true);
                    vidcomp.SetTargetAudioSource(0, getauds);
                    vidcomp.Stop();
                    getauds.Stop();
                    vidcomp.Play();
                    getauds.Play();
                    isvideo = false;
                }
            }
            else
            {

                var www = UnityWebRequest.Get("File://" + $"{ MelonUtils.GameDirectory}\\Arctic\\Loading screen music.mp3");
                www.SendWebRequest();

                while (!www.isDone)
                    yield return null;
                if (www.isHttpError)
                    yield break;
                var t = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false,
                    AudioType.MPEG);
                t.hideFlags |= HideFlags.DontUnloadUnusedAsset;

                GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/LoadingSound").gameObject.GetComponent<AudioSource>().clip = t;

            }
            yield return null;
             
        } 



    }

}
