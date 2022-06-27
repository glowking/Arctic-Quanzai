using Arctic.Wrappers;
using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;

namespace Arctic.Style
{
    class Uichanges
    {
        public static TMPro.TextMeshProUGUI istext;
        public static TMPro.TextMeshProUGUI playerlisttext;
        public static TMPro.TextMeshProUGUI textforinfo;
        public static UnityEngine.UI.Text textworld;
        public static UnityEngine.UI.Text usertextinfo;
        public static TMPro.TextMeshProUGUI playercounter;

        public static AudioSource Aud;
        public static GameObject notification;
        public static GameObject infofps;

        public static void applyui()
        {
            var backroundimage = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<UnityEngine.UI.Image>();
            Component.Destroy(backroundimage.gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            MelonCoroutines.Start(Apis.image.loadspriterest(backroundimage, "http://nocturnal-client.xyz/cl/Download/Media/Mask.png"));
            var backroundtwo = GameObject.Instantiate(backroundimage, backroundimage.transform);
            backroundtwo.name = "QMBackground";
            backroundtwo.gameObject.transform.localPosition = new Vector3(0, 26f, 0);
            backroundtwo.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            backroundimage.gameObject.AddComponent<Mask>();


            var leftbutton = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").gameObject;
            var gmj = new GameObject();
            gmj.AddComponent<UnityEngine.UI.Image>().color = Color.black;
            gmj.name = "Mask";
            gmj.transform.parent = leftbutton.transform;
            Wrappers.Resettransform.reset(gmj);
            gmj.transform.localScale = new Vector3(7.5f, 10.5f, 1);
            gmj.transform.localPosition = new Vector3(-466.7f, 0, 0);
            MelonCoroutines.Start(Apis.image.loadspriterest(gmj.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mask.png"));
            var image = GameObject.Instantiate(gmj.gameObject, gmj.transform);

            Wrappers.Resettransform.reset(image.gameObject);
            image.name = "Image";
            var imageborder = GameObject.Instantiate(image.gameObject, image.transform.parent);
            imageborder.name = "BORDERXMP";
            imageborder.transform.localPosition = new Vector3(0, 0, 0);
            var imgg = imageborder.gameObject.GetComponent<UnityEngine.UI.Image>();
            MelonCoroutines.Start(Apis.image.loadspriterest(imgg, "https://nocturnal-client.xyz/cl/Download/Boder7.png"));
            imgg.color = new Color(1, 1, 1, 0.9f);
            imageborder.transform.localScale = new Vector3(1.05f, 1.1f, 1);

            gmj.AddComponent<Mask>();
            var text = new GameObject();
            istext = text.AddComponent<TMPro.TextMeshProUGUI>();
            text.name = "Text";
            text.transform.parent = image.transform;
            Wrappers.Resettransform.reset(text);
            istext.text = "";
            istext.alignment = TMPro.TextAlignmentOptions.TopLeft;
            istext.enableWordWrapping = false;
            istext.fontSize = 25f;
            istext.m_isUsingBold = true;
            istext.lineSpacing += 7f;
            istext.maxVisibleLines = 24;
            text.transform.localScale = new Vector3(0.12f, 0.09f, 1);
            text.transform.localPosition = new Vector3(-31.9576f, 36.3132f, 1);
            var title = GameObject.Instantiate(text, leftbutton.transform);
            Wrappers.Resettransform.reset(title);
            title.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            var titletext = title.GetComponent<TMPro.TextMeshProUGUI>();
            titletext.text = "D E B U G G E R";
            titletext.alignment = TMPro.TextAlignmentOptions.Center;
            titletext.enableVertexGradient = true;
            titletext.colorGradient = new TMPro.VertexGradient(new Color(0.9f, 0.1f, 0.3f), new Color(0.3f, 0, 0.15f), new Color(0.21f, 0.21f, 0.21f), new Color(0.1f, 0.1f, 0.1f));
            titletext.transform.localPosition = new Vector3(-483.4815f, 483.6618f, 0);
            var maskimg = gmj.GetComponent<UnityEngine.UI.Image>();
            var img = image.GetComponent<UnityEngine.UI.Image>();
            MelonCoroutines.Start(Apis.image.loadspriterest(img, settings.StyleConfig.debuggerimg));
            img.color = new Color(1, 1, 1, settings.StyleConfig.debuggertrasnparancy);
            maskimg.color = new Color(1, 1, 1, settings.StyleConfig.debuggertrasnparancy);
            var rightwing = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform;
            var playerlist = GameObject.Instantiate(gmj, rightwing);
            MelonCoroutines.Start(Apis.image.loadspriterest(playerlist.transform.Find("BORDERXMP").gameObject.GetComponent<UnityEngine.UI.Image>(), "https://nocturnal-client.xyz/cl/Download/Boder7.png"));

            playerlist.transform.Find("Image/Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = Playerlist.playlist;
            playerlist.transform.Find("Image/Text").gameObject.transform.localPosition = new Vector3(-35.5902f, 43.74f, 0);
            playerlisttext = playerlist.transform.Find("Image/Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            playerlist.transform.localPosition = new Vector3(467.0424f, 0, 0);
            MelonCoroutines.Start(Apis.image.loadspriterest(playerlist.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mask.png"));
            playerlist.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().color = Color.black;
            var titleplayer = GameObject.Instantiate(title, rightwing);
            titleplayer.GetComponent<TMPro.TextMeshProUGUI>().text = "P L A Y E R  L I S T";
            titleplayer.transform.localPosition = new Vector3(467.688f, 480.1205f, 0);
            var playerlistimg = playerlist.transform.Find("Image").GetComponent<UnityEngine.UI.Image>();
            MelonCoroutines.Start(Apis.image.loadspriterest(playerlistimg, settings.StyleConfig.Playerlistimg));
            playerlistimg.color = new Color(1, 1, 1, settings.StyleConfig.Playerlisttransparancy);
            playerlisttext.transform.localPosition = new Vector3(-32.3186f, 36.6408f, 0);
            MelonCoroutines.Start(Style.Playerlist.Playerlists());

            var a = GameObject.Instantiate(titleplayer, titleplayer.transform);
            a.name = "Playercounter";
            a.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            a.transform.localPosition = new Vector3(191.1156f, 1.3331f, 0);
            playercounter = a.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            playercounter.text = "Loading";
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)/Image/Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().maxVisibleLines = 24;

            //-32.1701 36.8201 0
            MelonCoroutines.Start(audios());
            var JoinUser = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/PushToTalkKeybd");
            var listgmj = GameObject.Instantiate(JoinUser, JoinUser.parent).gameObject;
            listgmj.name = "ArcticAPI";
            listgmj.transform.parent = GameObject.Find("/UserInterface/UnscaledUI/HudContent_Old/Hud").transform;
            listgmj.SetActive(true);
            listgmj.GetComponent<UnityEngine.UI.Image>().enabled = false;
            listgmj.GetComponent<RectTransform>().anchoredPosition += new Vector2(600, 0);
            var istext3 = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ArcticAPI/KeyText").GetComponent<TMPro.TextMeshProUGUI>();
            istext3.fontSize = 18;
            istext3.alignment = TMPro.TextAlignmentOptions.TopLeft;
            istext3.richText = true;
            istext3.enableWordWrapping = false;
            istext3.overflowMode = TMPro.TextOverflowModes.Overflow;
            istext3.GetComponent<RectTransform>().anchoredPosition += new Vector2(-215, 10);
            istext3.color = Color.white;
            istext3.text = "";
            istext3.gameObject.SetActive(false);
            istext3.gameObject.transform.localPosition = new Vector3(2f, 340f, 0);
            Style.textdebuger.screenlogger = istext3;
            notification = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/AFK/Icon").gameObject, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud").transform);
            notification.name = "Arctic Not";
            notification.gameObject.SetActive(false);
            notification.gameObject.transform.localPosition = new Vector3(-354.7598f, -312.019f, 0);
            infofps = GameObject.Instantiate(notification, notification.transform.parent);
            infofps.name = "Arcticfpsandstuff";
            infofps.GetComponent<UnityEngine.UI.Image>().sprite = null;
            MelonCoroutines.Start(Apis.image.LoadSpriteBetter(notification.gameObject.GetComponent<UnityEngine.UI.Image>(), "https://nocturnal-client.xyz/Nocturnal%20Circle.png"));
            infofps.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.6f);
            var bc = new GameObject();
            infofps.transform.localScale = new Vector3(1.2f, 1.5241f, 1f);
            infofps.transform.localPosition = new Vector3(-239.2204f, -389.8208f, 0);
            textforinfo = bc.AddComponent<TMPro.TextMeshProUGUI>();
            textforinfo.fontSize += 8;
            textforinfo.text = "Loading";
            textforinfo.enableWordWrapping = false;
            textforinfo.alignment = TMPro.TextAlignmentOptions.Midline;
            bc.transform.parent = infofps.transform;
            bc.transform.localScale = new Vector3(0.34f, 0.27f, 1);
            bc.transform.localPosition = new Vector3(0, 0, 0);
            bc.transform.localRotation = new Quaternion(0, 0, 0, 0);
            infofps.gameObject.SetActive(settings.nconfig.fpsandstuffinfo);
            gsss = GameObject.Find("/_Application/FriendsListManager").gameObject.GetComponent<VRC.UI.FriendsListManager>();
            MelonCoroutines.Start(fpsandstuffinfo());

        }
        public static string playerinlobby;
        public static string friendsonline;
        private static VRC.UI.FriendsListManager gsss;



        public static IEnumerator fpsandstuffinfo()
        {

            while (true)
            {
                if (!settings.nconfig.fpsandstuffinfo && !settings.nconfig.qmextinfo)
                    yield return new WaitForSeconds(5f);

                else
                {
                    try
                    {
                        var today = System.DateTime.Now;
                        textforinfo.text = $"P - [{Wrappers.Extentions.LocalPlayer._vrcplayer.GetPing()}]\nF - [{(int)(1.0f / Time.smoothDeltaTime)}]\nT - [{today.ToString("HH:mm:ss")}]\nPlayers - [{playerinlobby}]\nF - [{friendsonline}]";

                        Image.infopanneltext.text = $"P - [{Wrappers.Extentions.LocalPlayer._vrcplayer.GetPing()}]    F - [{(int)(1.0f / Time.smoothDeltaTime)}]   T - [{today.ToString("HH:mm:ss")}]   Players - [{playerinlobby}]   F - [{friendsonline}]";

                    }
                    catch { }
                    yield return new WaitForSeconds(1f);

                    friendsonline = $"{gsss.field_Private_List_1_IUser_1.Count} / {gsss.field_Private_List_1_IUser_0.Count}";
                    yield return new WaitForSeconds(1f);


                    playerinlobby = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count.ToString();

                    yield return new WaitForSeconds(1f);

                    try
                    {
                        Main.Loaders.Loadqm.bt1.text = $"Curent Jump impules {Networking.LocalPlayer.GetJumpImpulse()}";


                        Main.Loaders.Loadqm.bt2.text = $"Jump Impulse {Networking.LocalPlayer.GetJumpImpulse()}";

                        if (Networking.LocalPlayer.GetJumpImpulse() != settings.nconfig.JumpIMpulse)
                            Networking.LocalPlayer.SetJumpImpulse(settings.nconfig.JumpIMpulse);
                    }
                    catch { }
                }
                yield return new WaitForSeconds(1f);
            }
        }

        private static IEnumerator audios()
        {

            var qmm = GameObject.Find("/UserInterface").gameObject.AddComponent<AudioSource>();
            qmm.loop = false;
            qmm.playOnAwake = false;
            qmm.volume = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeUi").gameObject.GetComponent<UiSettingConfig>().Method_Private_Single_0() / 1.5f;

            Aud = qmm;
            var wwws = UnityWebRequest.Get("File://" + $"{ MelonUtils.GameDirectory}\\Arctic\\JoinSound.mp3");
            wwws.SendWebRequest();

            while (!wwws.isDone)
                yield return null;
            if (wwws.isHttpError)
                yield break;
            var ts = WebRequestWWW.InternalCreateAudioClipUsingDH(wwws.downloadHandler, wwws.url, false, false,
                AudioType.MPEG);
            ts.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            qmm.clip = ts;

            var qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject;
            var aud = qm.AddComponent<AudioSource>();
            aud.playOnAwake = true;
            aud.loop = true;
            aud.clip = null;
            var www = UnityWebRequest.Get("File://" + $"{ MelonUtils.GameDirectory}\\Arctic\\Qmmusic.mp3");
            www.SendWebRequest();

            while (!www.isDone)
                yield return null;
            if (www.isHttpError)
                yield break;
            var t = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false,
                AudioType.MPEG);
            t.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            aud.clip = t;

            var slider = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeUi").gameObject.GetComponent<UnityEngine.UI.Slider>();
            aud.volume = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/LoadingSound").gameObject.GetComponent<AudioSource>().volume = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeUi").gameObject.GetComponent<UiSettingConfig>().Method_Private_Single_0() / 1.5f;
            void Sldvalue(float values)
            {
                aud.volume = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeUi").gameObject.GetComponent<UiSettingConfig>().Method_Private_Single_0() / 1.5f;
            }
            if (!settings.nconfig.Qmmusic)
                aud.enabled = false;

            yield return null;
        }
    }
}
