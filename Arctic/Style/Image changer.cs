using Arctic.Apis;
using Arctic.settings;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Arctic.Style
{
    public class Image
    {
        public static TMPro.TextMeshProUGUI text;
        public static TMPro.TextMeshProUGUI infopanneltext;

        public static void Applyui(string ui, string url)
        {

            switch (true)
            {
                case true when ui == "BU":
                    StyleConfig.BiguiImg = url;

                    var biguiimg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").gameObject.GetComponent<UnityEngine.UI.Image>();
                    MelonCoroutines.Start(image.loadspriterest(biguiimg, url));
                    break;

                case true when ui == "Qm":
                    StyleConfig.qmimg = url;

                    var Qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground").gameObject.GetComponent<UnityEngine.UI.Image>();
                    MelonCoroutines.Start(image.loadspriterest(Qm, url));
                    break;
                case true when ui == "Db":
                    StyleConfig.debuggerimg = url;


                    var Debuger = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    MelonCoroutines.Start(image.loadspriterest(Debuger, url));
                    break;
                case true when ui == "PL":
                    settings.StyleConfig.Playerlistimg = url;

                    var playlist = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    MelonCoroutines.Start(image.loadspriterest(playlist, url));
                    break;

            }

        }



        public static void Sliders(string Slider, float value)
        {
            switch (true)
            {
                case true when Slider == "BU":
                    var biguiimg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").gameObject.GetComponent<UnityEngine.UI.Image>();
                    biguiimg.color = new Color(settings.StyleConfig.BigmenuDim, settings.StyleConfig.BigmenuDim, settings.StyleConfig.BigmenuDim, value);

                    break;
                case true when Slider == "Qm":
                    var Qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var mask = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<UnityEngine.UI.Image>();
                    mask.color = new Color(1, 1, 1, value);
                    Qm.color = new Color(settings.StyleConfig.QmDim, settings.StyleConfig.QmDim, settings.StyleConfig.QmDim, value);

                    break;
                case true when Slider == "Db":
                    var debugger = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var Maskd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").GetComponent<UnityEngine.UI.Image>();
                    Maskd.color = new Color(1, 1, 1, value);
                    debugger.color = new Color(settings.StyleConfig.DebuggerDim, settings.StyleConfig.DebuggerDim, settings.StyleConfig.DebuggerDim, value);

                    break;
                case true when Slider == "PL":
                    var playerlist = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var plmask = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)").GetComponent<UnityEngine.UI.Image>();
                    plmask.color = new Color(1, 1, 1, value);
                    playerlist.color = new Color(settings.StyleConfig.PlayerlistDim, settings.StyleConfig.PlayerlistDim, settings.StyleConfig.PlayerlistDim, value);

                    break;

                case true when Slider == "BUD":
                    var biguiimgD = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").gameObject.GetComponent<UnityEngine.UI.Image>();
                    biguiimgD.color = new Color(value, value, value, StyleConfig.Biguitransparancy);

                    break;

                case true when Slider == "QmD":
                    var Qmd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var maskd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<UnityEngine.UI.Image>();
                    maskd.color = new Color(1, 1, 1, settings.StyleConfig.qmtransparancy);
                    Qmd.color = new Color(value, value, value, settings.StyleConfig.qmtransparancy);

                    break;

                case true when Slider == "DbD":
                    var debuggerd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var Maskdd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").GetComponent<UnityEngine.UI.Image>();
                    Maskdd.color = new Color(1, 1, 1, settings.StyleConfig.DebuggerDim);
                    debuggerd.color = new Color(value, value, value, settings.StyleConfig.DebuggerDim);

                    break;
                case true when Slider == "PLD":
                    var playerlistd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
                    var plmaskd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)").GetComponent<UnityEngine.UI.Image>();
                    plmaskd.color = new Color(1, 1, 1, settings.StyleConfig.PlayerlistDim);
                    playerlistd.color = new Color(value, value, value, settings.StyleConfig.PlayerlistDim);

                    break;

                case true when Slider == "BR":
                    var btn = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;
                    foreach (var aa in btn.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {
                        ColorBlock cb = aa.colors;
                        cb.normalColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.4f);
                        cb.highlightedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.1f);
                        cb.pressedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                        cb.disabledColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.7f);
                        cb.selectedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.2f);
                        aa.colors = cb;
                    }
                    Main.Loaders.Loadqm.changeuicolors();

                    break;
                case true when Slider == "BG":
                    var btn1 = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;
                    foreach (var aa in btn1.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {
                        ColorBlock cb = aa.colors;
                        cb.normalColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.4f);
                        cb.highlightedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.1f);
                        cb.pressedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                        cb.disabledColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.7f);
                        cb.selectedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.2f);
                        aa.colors = cb;
                    }
                    Main.Loaders.Loadqm.changeuicolors();

                    break;
                case true when Slider == "BB":
                    var btns = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;
                    foreach (var aa in btns.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {
                        ColorBlock cb = aa.colors;
                        cb.normalColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.4f);
                        cb.highlightedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.1f);
                        cb.pressedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                        cb.disabledColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.7f);
                        cb.selectedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.2f);
                        aa.colors = cb;
                    }

                    Main.Loaders.Loadqm.changeuicolors();

                    break;
                case true when Slider == "BT":
                    var btnss = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;
                    foreach (var aa in btnss.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {
                        ColorBlock cb = aa.colors;
                        cb.normalColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.4f);
                        cb.highlightedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.1f);
                        cb.pressedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                        cb.disabledColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.7f);
                        cb.selectedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.2f);
                        aa.colors = cb;
                    }
                    Main.Loaders.Loadqm.changeuicolors();

                    break;
                case true when Slider == "HR":
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/_Application/CursorManager/MouseArrow/VRCUICursorIcon").GetComponent<SpriteRenderer>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("Camera (eye)").GetComponent<HighlightsFXStandalone>().highlightColor = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuR/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuL/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    foreach (var gmjs in GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").GetComponentsInChildren<ParticleSystem>(true))
                    {
                        gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                        gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                    }
                    try
                    {
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

                    }
                    catch { }
                    break;
                case true when Slider == "HG":
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/_Application/CursorManager/MouseArrow/VRCUICursorIcon").GetComponent<SpriteRenderer>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("Camera (eye)").GetComponent<HighlightsFXStandalone>().highlightColor = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuR/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuL/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    foreach (var gmjs in GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").GetComponentsInChildren<ParticleSystem>(true))
                    {
                        gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                        gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                    }
                    Uichanges.textforinfo.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, 1);
                    try
                    {
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

                    }
                    catch { }
                    break;
                case true when Slider == "HB":
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/_Application/CursorManager/MouseArrow/VRCUICursorIcon").GetComponent<SpriteRenderer>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("Camera (eye)").GetComponent<HighlightsFXStandalone>().highlightColor = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuR/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuL/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    foreach (var gmjs in GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").GetComponentsInChildren<ParticleSystem>(true))
                    {
                        gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                        gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                    }
                    Uichanges.textforinfo.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, 1);
                    try
                    {
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

                    }
                    catch { }
                    break;
                case true when Slider == "HT":
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/_Application/CursorManager/MouseArrow/VRCUICursorIcon").GetComponent<SpriteRenderer>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("Camera (eye)").GetComponent<HighlightsFXStandalone>().highlightColor = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuR/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuL/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                    foreach (var gmjs in GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").GetComponentsInChildren<ParticleSystem>(true))
                    {
                        gmjs.startColor = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                        gmjs.trails.colorOverTrail = new Color(settings.StyleConfig.HRed, settings.StyleConfig.HGreen, settings.StyleConfig.HBlue);
                    }
                    Uichanges.textforinfo.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, 1);
                    try
                    {
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/LeftEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
                        Wrappers.Extentions.LocalPlayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupTether(Clone)/Tether/Quad").gameObject.GetComponent<UnityEngine.MeshRenderer>().material.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

                    }
                    catch { }
                    break;

                case true when Slider == "TR":
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        try
                        {

                            if (gameobject.name == "Text_Title")
                            {
                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp / 1.5f);

                            }
                            else if (gameobject.name.Contains("Text_"))
                            {

                                gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                            }
                        }
                        catch { }


                    }
                    break;
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    {
                        try
                        {
                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("Button_") || gameobject.transform.parent.name.Contains("Page_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Badge_MMJump")
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("SubBtn_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);


                        }
                        catch { }


                    }
                case true when Slider == "TG":
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        try
                        {

                            if (gameobject.name == "Text_Title")
                            {

                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }
                            else if (gameobject.name.Contains("Text_"))
                            {

                                gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                            }
                            else if (gameobject.name == "Label" && gameobject.transform.parent.name.Contains("QM_Foldout_"))
                            {
                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }
                        }
                        catch { }


                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    {
                        try
                        {
                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("Button_") || gameobject.transform.parent.name.Contains("Page_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Badge_MMJump")
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("SubBtn_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);


                        }
                        catch { }


                    }
                    break;
                case true when Slider == "TB":
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        try
                        {


                            if (gameobject.name == "Text_Title")
                            {

                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }
                            else if (gameobject.name.Contains("Text_"))
                            {

                                gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                            }
                            else if (gameobject.name == "Label" && gameobject.transform.parent.name.Contains("QM_Foldout_"))
                            {
                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }
                        }
                        catch { }


                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    {
                        try
                        {
                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("Button_") || gameobject.transform.parent.name.Contains("Page_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Badge_MMJump")
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("SubBtn_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);


                        }
                        catch { }


                    }
                    break;
                case true when Slider == "TT":
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                    {
                        try
                        {


                            if (gameobject.name == "Text_Title")
                            {

                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }
                            else if (gameobject.name.Contains("Text_"))
                            {

                                gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                            }
                            else if (gameobject.name == "Label" && gameobject.transform.parent.name.Contains("QM_Foldout_"))
                            {
                                gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                            }

                        }
                        catch { }


                    }
                    foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    {
                        try
                        {
                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("Button_") || gameobject.transform.parent.name.Contains("Page_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Badge_MMJump")
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                            if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("SubBtn_"))
                                gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);


                        }
                        catch { }


                    }
                    break;



            }

        }







        public static void applyall()
        {

            if (Arctic.settings.nconfig.DiscordRich == false)
                DiscordRpc.Shutdown();

            var biguiimg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").gameObject.GetComponent<UnityEngine.UI.Image>();
            MelonCoroutines.Start(image.loadspriterest(biguiimg, StyleConfig.BiguiImg));
            var rankss = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel").gameObject.GetComponent<UnityEngine.UI.Text>();

            if (nconfig.custommic)
            {
                var vcon = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDot").gameObject;
                var vcoff = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled").gameObject;
                vcon.GetComponent<RectTransform>().sizeDelta /= 1.2f;
                vcoff.GetComponent<RectTransform>().sizeDelta /= 1.2f;

                MelonCoroutines.Start(Apis.image.loadspriterest(vcon.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mic%20On.png"));
                MelonCoroutines.Start(Apis.image.loadspriterest(vcoff.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mic%20off.png"));

            }
            if (!nconfig.Avatarsseeninworld) Main.Loaders.Loadqm.AvatarHistory.gameObject.SetActive(false);

            var Qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground").gameObject.GetComponent<UnityEngine.UI.Image>();
            Qm.color = new Color(settings.StyleConfig.QmDim, settings.StyleConfig.QmDim, settings.StyleConfig.QmDim, (float)settings.StyleConfig.qmtransparancy);


            var mask = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<UnityEngine.UI.Image>();
            mask.color = new Color(1, 1, 1, (float)settings.StyleConfig.qmtransparancy);

            var btnss = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;
            foreach (var aa in btnss.GetComponentsInChildren<UnityEngine.UI.Button>(true))
            {
                ColorBlock cb = aa.colors;
                cb.normalColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.4f);
                cb.highlightedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.1f);
                cb.pressedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb);
                cb.disabledColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.7f);
                cb.selectedColor = new Color((float)settings.StyleConfig.redb, settings.StyleConfig.greenb, settings.StyleConfig.blueb, settings.StyleConfig.Transpb - 0.2f);
                aa.colors = cb;
            }

            GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
            GameObject.Find("/_Application/CursorManager/MouseArrow/VRCUICursorIcon").GetComponent<SpriteRenderer>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
            GameObject.Find("Camera (eye)").GetComponent<HighlightsFXStandalone>().highlightColor = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
            GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuR/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);
            GameObject.Find("/UserInterface").transform.Find("ActionMenu/Container/MenuL/ActionMenu/Main/Cursor").GetComponent<UnityEngine.UI.Image>().color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

            foreach (var bg in GameObject.Find("UserInterface").transform.Find("ActionMenu/Container").gameObject.GetComponentsInChildren<PedalGraphic>(true))
            {
                if (bg.name == "Background" && bg.transform.parent.name == "Main")
                {
                    bg.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, StyleConfig.HTransp);

                }
            }
            MelonCoroutines.Start(image.loadspriterest(Qm, StyleConfig.qmimg));

            try
            {
                biguiimg.color = new Color(settings.StyleConfig.BigmenuDim, settings.StyleConfig.BigmenuDim, settings.StyleConfig.BigmenuDim, StyleConfig.Biguitransparancy);

            }
            catch { Style.Consoles.consolelogger("Failed Big Ui DIM"); };

            foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
            {
                try
                {
                    gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                }
                catch { Style.Consoles.consolelogger("Failed Unityengine Text Color"); }
            }
            foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
            {
                try
                {
                    gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                }
                catch { Style.Consoles.consolelogger("Failed TMPRO Color"); }
            }
            var debuggerd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask/Image").gameObject.GetComponent<UnityEngine.UI.Image>();

            var Maskdd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").GetComponent<UnityEngine.UI.Image>();

            Maskdd.color = new Color(1, 1, 1, settings.StyleConfig.DebuggerDim);

            debuggerd.color = new Color(settings.StyleConfig.DebuggerDim, settings.StyleConfig.DebuggerDim, settings.StyleConfig.DebuggerDim, settings.StyleConfig.DebuggerDim);


            var playerlistd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>();
            var plmaskd = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)").GetComponent<UnityEngine.UI.Image>();
            plmaskd.color = new Color(1, 1, 1, settings.StyleConfig.PlayerlistDim);
            playerlistd.color = new Color(settings.StyleConfig.PlayerlistDim, settings.StyleConfig.PlayerlistDim, settings.StyleConfig.PlayerlistDim, settings.StyleConfig.PlayerlistDim);

            if (!settings.nconfig.debugger)
            {
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").gameObject.SetActive(false);
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Text(Clone)").gameObject.SetActive(false);
            }
            if (!settings.nconfig.Playerlist)
            {
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Mask(Clone)").gameObject.SetActive(false);
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Text(Clone)(Clone)").gameObject.SetActive(false);
            }

            foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
            {
                if (gameobject.name == "Text_H4")
                {
                    //Component.DestroyImmediate(gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                    gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                }

            }

            Uichanges.textforinfo.color = new Color(StyleConfig.HRed, StyleConfig.HGreen, StyleConfig.HBlue, 1);

            MelonCoroutines.Start(Apis.AssetBundles.loadshit());


            if (nconfig.BigUichanges)
            {
                var infop = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel").transform;

                GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/AvatarImage/AvatarBorder").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1);


                var bgnimg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/PanelHeaderBackground").gameObject.GetComponent<UnityEngine.UI.Image>();

                var pnl = infop.transform.Find("Panel");

                pnl.transform.localScale = new Vector3(1, 1.15f, 1);
                pnl.transform.localPosition = new Vector3(400f, -359.3152f, 0);
                infop.localScale = new Vector3(0.8f, 0.8f, 1);
                infop.localPosition = new Vector3(-218.0966f, 364f, 0);
                var insta = GameObject.Instantiate(infop.Find("NameText"), infop.parent);
                Style.Uichanges.usertextinfo = insta.GetComponent<UnityEngine.UI.Text>();

                insta.transform.localScale = new Vector3(1, 1, 1);
                insta.transform.localPosition = new Vector3(73.3948f, -175.2704f, 0);
                Style.Uichanges.usertextinfo.horizontalOverflow = HorizontalWrapMode.Overflow;
                Style.Uichanges.usertextinfo.fontSize += -4;
                Style.Uichanges.usertextinfo.supportRichText = true;
                Style.Uichanges.usertextinfo.resizeTextForBestFit = true;

                MelonCoroutines.Start(Apis.image.loadspriterest(bgnimg, "https://nocturnal-client.xyz/cl/Download/Media/offwhite.png"));

                bgnimg.color = new Color(1, 1, 1, 0.6f);
            }



            Uichanges.textforinfo.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo/WorldImage/RoomBorder").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1);

            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/TitlePanel (1)").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.65f);

            GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").gameObject.transform.localScale = new Vector3(1.23f, 1.07f, 1);


            var toinst = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo/WorldImage/Panel/NameText");

            var insttext = GameObject.Instantiate(toinst, GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo/Panels").transform);
            insttext.gameObject.name = "Info";

            Style.Uichanges.textworld = insttext.gameObject.GetComponent<UnityEngine.UI.Text>();
            Style.Uichanges.textworld.text = "Loading";

            Style.Uichanges.textworld.horizontalOverflow = HorizontalWrapMode.Overflow;
            insttext.gameObject.transform.localScale = new Vector3(0.65f, 0.65f, 1);

            insttext.gameObject.transform.localPosition = new Vector3(104.8003f, -111.9925f, 0);

            var blackbg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo/Panels/PanelBackground");

            blackbg.localScale = new Vector3(1f, 1.14f, 1);

            blackbg.localPosition = new Vector3(195f, 107.5788f, 0);

            if (!settings.nconfig.Favortielistenabled)
                Main.Loaders.Loadqm.Avatarfavlist.gameObject.SetActive(false);

            if (settings.nconfig.Qmuitstyle)
            {
                foreach (var item in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup").GetComponentsInChildren<UnityEngine.UI.LayoutElement>(true))
                {

                    if (item.name.Contains("Header_"))
                    {
                        item.gameObject.SetActive(false);
                    }
                    else if (item.name.Contains("Button_"))
                    {
                        item.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -80);

                        try
                        {
                            item.transform.Find("Text_H4").transform.localPosition = new Vector3(0, 0, 0);

                            item.transform.Find("Badge_MMJump").transform.localPosition = new Vector3(0, 0, 0);
                            item.transform.Find("Badge_MMJump").GetComponent<RectTransform>().anchoredPosition = new Vector2(-10, -50);

                            item.transform.Find("Text_H4").GetComponent<RectTransform>().anchoredPosition = new Vector2(20, 65);

                            var icon = item.transform.Find("Icon").transform;

                            icon.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                            icon.localPosition = new Vector3(0, 0, 0);

                            icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-75, -62.5599f);
                        }
                        catch { }




                    }
                }



                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners").gameObject.SetActive(false);
                var debbuger2 = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners").gameObject, GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup").transform);
                GameObject.DestroyImmediate(debbuger2.transform.Find("Image_MASK").gameObject);
                Component.DestroyImmediate(debbuger2.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                debbuger2.name = "Debbuger";
                debbuger2.transform.SetSiblingIndex(0);
                debbuger2.gameObject.SetActive(true);
                debbuger2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(950, 550);
                var debgimgtxt = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Mask").gameObject, debbuger2.transform);
                debgimgtxt.transform.localScale = new Vector3(1, 1, 1);
                debgimgtxt.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 600);
                debgimgtxt.transform.localPosition = new Vector3(0, 0, 0);
                debbuger2.gameObject.SetActive(true);
                MelonCoroutines.Start(Apis.image.loadspriterest(debgimgtxt.GetComponent<UnityEngine.UI.Image>(), "http://nocturnal-client.xyz/cl/Download/Media/Mask.png"));


                debgimgtxt.transform.Find("Image").gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.black;
                MelonCoroutines.Start(Apis.image.loadspriterest(debgimgtxt.transform.Find("Image").gameObject.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.Chatmsg));
                debgimgtxt.transform.Find("Image").gameObject.transform.localScale = new Vector3(9.8f, 6f, 1);
                debgimgtxt.transform.Find("Image/Text").gameObject.transform.localScale = new Vector3(0.09f, 0.16f, 1);
                text = debgimgtxt.transform.Find("Image/Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                debgimgtxt.transform.Find("Image").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.7f);
                debgimgtxt.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.7f);
                var borrder = GameObject.Instantiate(debgimgtxt.transform.Find("Image").gameObject, debgimgtxt.transform);
                GameObject.DestroyImmediate(borrder.transform.Find("Text").gameObject);
                MelonCoroutines.Start(Apis.image.LoadSpriteBetter(borrder.GetComponent<UnityEngine.UI.Image>(), "https://nocturnal-client.xyz/cl/Download/border3.png"));
                borrder.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.9f);
                borrder.transform.localScale = new Vector3(9.48f, 7, 1);

                var background = GameObject.Instantiate(debgimgtxt.transform.Find("Image(Clone)").gameObject, debgimgtxt.transform);
                background.transform.SetSiblingIndex(1);
                background.transform.localScale = new Vector3(10, 7, 1);
                var imgg = background.gameObject.GetComponent<UnityEngine.UI.Image>();
                imgg.sprite = null;
                imgg.color = new Color(0, 0, 0, 0.8f);
                text.fontSize = 24;
                text.transform.parent = background.transform;
                text.maxVisibleLines = 13;
                text.gameObject.transform.localPosition = new Vector3(-36.0697f, 27.3797f, 1);
                GameObject.DestroyImmediate(debgimgtxt.transform.Find("BORDERXMP").gameObject);

                debbuger2.gameObject.SetActive(true);
                debbuger2.transform.Find("Mask(Clone)").gameObject.SetActive(true);

                GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social").gameObject.AddComponent<Arctic.settings.MonoBehaviours.Social>();
                if (nconfig.onqmuserinfo)
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.AddComponent<settings.MonoBehaviours.usertab>();
            }



            //Text
            //-39.8377 41.3529 1
            var qmimg = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01/QMBackground");
            var qmborder = GameObject.Instantiate(qmimg, qmimg.transform.parent);
            qmborder.transform.localPosition = new Vector3(0, 0, 0);
            qmborder.transform.localScale = new Vector3(1.05f, 1.05f, 1);
            // qmborder.transform.SetSiblingIndex(0);
            MelonCoroutines.Start(Apis.image.loadspriterest(qmborder.GetComponent<UnityEngine.UI.Image>(), "https://nocturnal-client.xyz/cl/Download/border4.png"));
            qmborder.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.8f);

            var cba = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel");
            var infopanel = GameObject.Instantiate(cba, cba.transform.parent);
            infopanel.name = "Debugger2";
            Component.DestroyImmediate(infopanel.gameObject.GetComponent<VRC.UI.Elements.DebugInfoPanel>());
            Component.DestroyImmediate(infopanel.gameObject.GetComponent<VRC.DataModel.Core.BindingComponent>());
            Component.DestroyImmediate(infopanel.transform.Find("Panel/Text_FPS").gameObject.GetComponent<ListCountBinding>());
            GameObject.DestroyImmediate(infopanel.transform.Find("Panel/Text_Ping").gameObject);
            infopanel.gameObject.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
            infopanneltext = infopanel.transform.Find("Panel/Text_FPS").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            infopanneltext.enableWordWrapping = false;
            infopanneltext.text = "Loading";
            infopanneltext.alignment = TMPro.TextAlignmentOptions.TopLeft;
            var rect = infopanel.transform.Find("Panel/Background").gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(600, 0);
            rect.anchoredPosition = new Vector2(300, 0);
            infopanneltext.gameObject.transform.localPosition = new Vector3(25, -16.5f, 0);

            if (!settings.nconfig.qmextinfo)
                infopanneltext.transform.parent.parent.gameObject.SetActive(false);
            else
                infopanneltext.transform.parent.parent.gameObject.SetActive(true);


            if (nconfig.Overwritetextcolor)
            {
                foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                {
                    gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);
                }
                foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                {
                    gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                }
                foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                {
                    try
                    {
                        if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("Button_") || gameobject.transform.parent.name.Contains("Page_"))
                        {
                            if (gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>() != null)
                                Component.DestroyImmediate(gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>());

                            gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                        }
                        if (gameobject.name == "Badge_MMJump")
                        {
                            if (gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>() != null)
                                Component.DestroyImmediate(gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>());

                            gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);

                        }

                        if (gameobject.name == "Icon" && gameobject.transform.parent.name.Contains("SubBtn_"))
                        {
                            gameobject.color = new Color(settings.StyleConfig.TRed / 2, settings.StyleConfig.TGreen / 2, settings.StyleConfig.TBlue / 2, settings.StyleConfig.HTransp);
                        }

                    }
                    catch { }


                }

                foreach (var gameobject in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container").gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>(true))
                {
                    try
                    {
                        if (gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>() != null)
                            Component.DestroyImmediate(gameobject.GetComponent<VRC.UI.Core.Styles.StyleElement>());


                        if (gameobject.name == "Text_Title")
                        {

                            gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                        }
                        else if (gameobject.name.Contains("Text_"))
                        {

                            gameobject.color = new Color(StyleConfig.TRed, StyleConfig.TGreen, StyleConfig.TBlue, StyleConfig.TTransp);

                        }
                        else if (gameobject.name == "Label" && gameobject.transform.parent.name.Contains("QM_Foldout_"))
                        {
                            gameobject.color = new Color(StyleConfig.TRed / 1.5f, StyleConfig.TGreen / 1.5f, StyleConfig.TBlue / 1.5f, StyleConfig.TTransp);

                        }
                    }
                    catch { }


                }

            }


            //   var texture = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile/Container/Background").gameObject.GetComponent<UnityEngine.UI.Image>().sprite.texture;

            /*  for (int y = 0; y < texture.height; y++)
              {
                  for (int x = 0; x < texture.width; x++)
                  {
                      Color color = Color.red;
                      texture.SetPixel(x, y, color);
                  }
              }
              texture.Apply(); */
        }
    }


}


