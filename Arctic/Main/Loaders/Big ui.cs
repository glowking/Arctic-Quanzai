using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arctic.Apis;
using UnityEngine;
using MelonLoader;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using VRC;
using VRC.UI;
using VRC.Core;
using Arctic.Wrappers;

namespace Arctic.Main
{
    public class Loadui
    {
        public static VRC.Player lastusertargeted = null;
        public static void loadui()
        {
            Style.Consoles.consolelogger("Client Ui loading");
            MelonCoroutines.Start(Arctic.Style.Consoles.consolemsg());
            Apis.Buttons.Submenu.SubmenuBigui("Arctic", "Arctic Settings / Main ui page");
            GameObject gmj = new GameObject();
            GameObject ui = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Holder_Arctic").gameObject;
            gmj.transform.parent = ui.transform;
            Wrappers.Resettransform.reset(gmj);


         //Grid //////////////////////////////////////////////////////////////////////////////
         var grid = gmj.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            gmj.transform.localPosition = new Vector3(-615f, 295f, 0);
            grid.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 6;
            grid.cellSize = new Vector2(200,100);
            grid.spacing = new Vector2(50, 300);
            ////////////////////////////////////////////////////////////////////////////////////
            GameObject folderUI = Apis.Buttons.Folder.Biguifolder("Big Image", gmj);
            Apis.Buttons.button.Createbutton("Chose File", folderUI.transform.Find("Container").gameObject, () =>
            {
                 
                        string ab = "";
                        Apis.inputpopout.run("Put the Link For your image", value => ab = value, () => Style.Image.Applyui("BU", ab));

            });
            Apis.Buttons.Sliders.slider(folderUI.transform.Find("Container").gameObject, value => settings.StyleConfig.Biguitransparancy = value, settings.StyleConfig.Biguitransparancy, () => Style.Image.Sliders("BU", settings.StyleConfig.Biguitransparancy),"Transpancy");
            Apis.Buttons.Sliders.slider(folderUI.transform.Find("Container").gameObject, value => settings.StyleConfig.BigmenuDim = value, settings.StyleConfig.BigmenuDim, () => Style.Image.Sliders("BUD", settings.StyleConfig.BigmenuDim), "Dim");








            var qm = Apis.Buttons.Folder.Biguifolder("QM Image", gmj);
            Apis.Buttons.button.Createbutton("Chose File", qm.transform.Find("Container").gameObject, () =>
            {
                string ab = "";
                Apis.inputpopout.run("Put the Link For your image", value => ab = value, () => Style.Image.Applyui("Qm", ab));
            });
            Apis.Buttons.Sliders.slider(qm.transform.Find("Container").gameObject, value => settings.StyleConfig.qmtransparancy = value, settings.StyleConfig.qmtransparancy, () => Style.Image.Sliders("Qm", settings.StyleConfig.qmtransparancy), "Transpancy");
            Apis.Buttons.Sliders.slider(qm.transform.Find("Container").gameObject, value => settings.StyleConfig.QmDim = value, settings.StyleConfig.QmDim, () => Style.Image.Sliders("QmD", settings.StyleConfig.QmDim), "Dim");



            var pl = Apis.Buttons.Folder.Biguifolder("Player List", gmj);
            Apis.Buttons.button.Createbutton("Chose File", pl.transform.Find("Container").gameObject, () =>
            {
                string ab = "";
                Apis.inputpopout.run("Put the Link For your image", value => ab = value, () => Style.Image.Applyui("PL", ab));
            
            });
            Apis.Buttons.Sliders.slider(pl.transform.Find("Container").gameObject, value => settings.StyleConfig.Playerlisttransparancy = value, settings.StyleConfig.Playerlisttransparancy, () => Style.Image.Sliders("PL", settings.StyleConfig.Playerlisttransparancy), "Transpancy");
            Apis.Buttons.Sliders.slider(pl.transform.Find("Container").gameObject, value => settings.StyleConfig.PlayerlistDim = value, settings.StyleConfig.PlayerlistDim, () => Style.Image.Sliders("PLD", settings.StyleConfig.PlayerlistDim), "Dim");




            var chats = Apis.Buttons.Folder.Biguifolder("Chat", gmj);
            Apis.Buttons.button.Createbutton("Chose File", chats.transform.Find("Container").gameObject, () =>
            {
                Apis.inputpopout.run("Put the Link For your image", value => settings.StyleConfig.Chatmsg = value, () => MelonCoroutines.Start(Apis.image.loadspriterest(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Debbuger/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.Chatmsg)));
            });

            var JoyStick = Apis.Buttons.Folder.Biguifolder("JoyStick", gmj);
            Apis.Buttons.button.Createbutton("Chose File", JoyStick.transform.Find("Container").gameObject, () =>
            {
                Apis.inputpopout.run("Put the Link For your image", value => settings.StyleConfig.JoyStick = value, () =>
                {
                    foreach (var bg in GameObject.Find("UserInterface").transform.Find("ActionMenu/Container").gameObject.GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    {
                        if (bg.name == "Cursor(Clone)" && bg.transform.parent.name == "Cursor")
                        {
                            MelonCoroutines.Start(Apis.image.LoadSpriteBetter(bg.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.JoyStick));

                        }
                    }


                });
            });

          




            var deb = Apis.Buttons.Folder.Biguifolder("Debugger", gmj);
            Apis.Buttons.button.Createbutton("Chose File", deb.transform.Find("Container").gameObject, () =>
            {
                string ab = "";
                Apis.inputpopout.run("Put the Link For your image", value => ab = value, () => Style.Image.Applyui("Db", ab));

            });
            Apis.Buttons.Sliders.slider(deb.transform.Find("Container").gameObject, value => settings.StyleConfig.debuggertrasnparancy = value, settings.StyleConfig.debuggertrasnparancy, () => Style.Image.Sliders("Db", settings.StyleConfig.debuggertrasnparancy), "Transpancy");
            Apis.Buttons.Sliders.slider(deb.transform.Find("Container").gameObject, value => settings.StyleConfig.DebuggerDim = value, settings.StyleConfig.DebuggerDim, () => Style.Image.Sliders("DbD", settings.StyleConfig.DebuggerDim), "Dim");



            var dbgqm = Apis.Buttons.Folder.Biguifolder("Qm Debbuger", gmj);
            Apis.Buttons.button.Createbutton("Chose File", dbgqm.transform.Find("Container").gameObject, () =>
            {
                Apis.inputpopout.run("Put the Link For your image", value => settings.StyleConfig.Debbuggerqm = value, () => MelonCoroutines.Start(Apis.image.loadspriterest(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Debbuger/Mask(Clone)/Image").gameObject.GetComponent<UnityEngine.UI.Image>(), settings.StyleConfig.Debbuggerqm)));
            });

            var uistyle = Apis.Buttons.Folder.Biguifolder("UI", gmj);
            Apis.Buttons.Sliders.slider(uistyle.transform.Find("Container").gameObject, value => settings.StyleConfig.redb = value, (float)settings.StyleConfig.redb, () => Style.Image.Sliders("BR", (float)settings.StyleConfig.redb), "Red");
            Apis.Buttons.Sliders.slider(uistyle.transform.Find("Container").gameObject, value => settings.StyleConfig.greenb = value, settings.StyleConfig.greenb, () => Style.Image.Sliders("BG", settings.StyleConfig.greenb), "Green");
            Apis.Buttons.Sliders.slider(uistyle.transform.Find("Container").gameObject, value => settings.StyleConfig.blueb = value, settings.StyleConfig.blueb, () => Style.Image.Sliders("BB", settings.StyleConfig.blueb), "Blue");
            Apis.Buttons.Sliders.slider(uistyle.transform.Find("Container").gameObject, value => settings.StyleConfig.Transpb = value, settings.StyleConfig.Transpb, () => Style.Image.Sliders("BT", settings.StyleConfig.Transpb), "Transpancy");




            var uihud = Apis.Buttons.Folder.Biguifolder("Hud", gmj);
            Apis.Buttons.Sliders.slider(uihud.transform.Find("Container").gameObject, value => settings.StyleConfig.HRed = value, settings.StyleConfig.HRed, () => Style.Image.Sliders("HR", settings.StyleConfig.HRed), "Red");
            Apis.Buttons.Sliders.slider(uihud.transform.Find("Container").gameObject, value => settings.StyleConfig.HGreen = value, settings.StyleConfig.HGreen, () => Style.Image.Sliders("HG", settings.StyleConfig.HGreen), "Green");
            Apis.Buttons.Sliders.slider(uihud.transform.Find("Container").gameObject, value => settings.StyleConfig.HBlue = value, settings.StyleConfig.HBlue, () => Style.Image.Sliders("HB", settings.StyleConfig.HBlue), "Blue");
            Apis.Buttons.Sliders.slider(uihud.transform.Find("Container").gameObject, value => settings.StyleConfig.HTransp = value, settings.StyleConfig.HTransp, () => Style.Image.Sliders("HT", settings.StyleConfig.HTransp), "Transpancy");




            var texts = Apis.Buttons.Folder.Biguifolder("Text", gmj);
            Apis.Buttons.Sliders.slider(texts.transform.Find("Container").gameObject, value => settings.StyleConfig.TRed = value, settings.StyleConfig.TRed, () => Style.Image.Sliders("TR", settings.StyleConfig.TRed), "Red");
            Apis.Buttons.Sliders.slider(texts.transform.Find("Container").gameObject, value => settings.StyleConfig.TGreen = value, settings.StyleConfig.TGreen, () => Style.Image.Sliders("TG", settings.StyleConfig.TGreen), "Green");
            Apis.Buttons.Sliders.slider(texts.transform.Find("Container").gameObject, value => settings.StyleConfig.TBlue = value, settings.StyleConfig.TBlue, () => Style.Image.Sliders("TB", settings.StyleConfig.TBlue), "Blue");
            Apis.Buttons.Sliders.slider(texts.transform.Find("Container").gameObject, value => settings.StyleConfig.TTransp = value, settings.StyleConfig.TTransp, () => Style.Image.Sliders("TT", settings.StyleConfig.TTransp), "Transpancy");




            GameObject Fly = Apis.Buttons.Folder.Biguifolder("Fly Speed", gmj);
            Apis.Buttons.Sliders.slider(Fly.transform.Find("Container").gameObject, value => settings.nconfig.flyspeed = value, settings.nconfig.flyspeed, null, "Fly Speed");

            GameObject Walkspeed = Apis.Buttons.Folder.Biguifolder("Walk Speed", gmj);
            Apis.Buttons.Sliders.slider(Walkspeed.transform.Find("Container").gameObject, value => settings.nconfig.walkspeed = value, settings.nconfig.walkspeed, null, "Walk Speed");




            var trg = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject;
            var target = Apis.Buttons.Folder.Biguifolder("Target User", trg);
            target.transform.localPosition = new Vector3(-783.7002f, 331.3199f, 0);
            Apis.Buttons.button.Createbutton("TP", target.transform.Find("Container").gameObject, () =>
            {
                var id = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == id)
                    {
                        lastusertargeted = player1;
                    }

                }

                Extentions.LocalPlayer.transform.position = lastusertargeted.transform.position + new Vector3(0, 0.25f, 0);
            });
            Apis.Buttons.button.Createbutton("Target", target.transform.Find("Container").gameObject, () =>
            {
                var id = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                Wrappers.Target.targetuser(id);//\n
 
            });
            Apis.Buttons.button.Createbutton("Force Clone", target.transform.Find("Container").gameObject, () =>
            {
                try
                {
                    var id = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                    foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        if (player1.field_Private_APIUser_0.id == id)
                        {
                            lastusertargeted = player1;
                        }

                    }
                    var aviid = lastusertargeted.gameObject.GetComponent<VRCPlayer>().field_Private_ApiAvatar_0.id;
                    PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                    component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                    {
                        id = aviid
                    };
                    component.ChangeToSelectedAvatar();
                }

                catch
                {
                    Style.Consoles.consolelogger("Something Failed while force cloning");
                }
            });
            Apis.Buttons.button.Createbutton("Copy usr id", target.transform.Find("Container").gameObject, () =>
            {

                string id = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/UserInfo").GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                Clipboard.SetText($"{id}");
                Style.Consoles.consolelogger(id);
            });
            Apis.Buttons.button.Createbutton("Copy avi id", target.transform.Find("Container").gameObject, () =>
            {
                string ids = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/UserInfo").GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == ids)
                    {
                        player1.field_Private_APIUser_0.Fetch();
                        Clipboard.SetText($"{player1.prop_ApiAvatar_0.id}");
                        Style.Consoles.consolelogger(player1.prop_ApiAvatar_0.id);
                    }
                }
            });
            Apis.Buttons.button.Createbutton("Invite", target.transform.Find("Container").gameObject, () =>
            {
                var pguserinfo = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/UserInfo").GetComponent<VRC.UI.PageUserInfo>();
                pguserinfo.InviteFriend();
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/SendInvitePopup/SendInviteMenu/SendButton").gameObject.GetComponent<UnityEngine.UI.Button>().Press();
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/AlertPopup/Button").gameObject.GetComponent<UnityEngine.UI.Button>().Press();

            });
            Apis.Buttons.button.Createbutton("Request", target.transform.Find("Container").gameObject, () =>
            {
                var pguserinfo = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/UserInfo").GetComponent<VRC.UI.PageUserInfo>();
                pguserinfo.RequestInvitation();
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/RequestInvitePopup/RequestInviteMenu/SendButton").gameObject.GetComponent<UnityEngine.UI.Button>().Press();
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/AlertPopup/Button").gameObject.GetComponent<UnityEngine.UI.Button>().Press();
            });
            Apis.Buttons.button.Createbutton("Avatarurl", target.transform.Find("Container").gameObject, () =>
            {
                string ids = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/UserInfo").GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                foreach (VRC.Player player1 in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    if (player1.field_Private_APIUser_0.id == ids)
                    {
                        var url = player1.prop_ApiAvatar_0.assetUrl;
                        UnityEngine.Application.OpenURL(url);
                        Clipboard.SetText(url);
                    }
                }
            });
            
             var wtoinst = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject;
            var world = Apis.Buttons.Folder.Biguifolder("World", wtoinst);
            world.transform.localPosition = new Vector3(-783.7002f, 331.3199f, 0);
            Apis.Buttons.button.Createbutton("Instance id", world.transform.Find("Container").gameObject, () =>
            {
                var isid = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/WorldInfo").GetComponent<PageWorldInfo>().field_Public_ApiWorldInstance_0._id_k__BackingField;
                Clipboard.SetText($"{isid}");
                Style.Consoles.consolelogger(isid);
            });
            Apis.Buttons.button.Createbutton("World id", world.transform.Find("Container").gameObject, () =>
            {
                var isid = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/WorldInfo").GetComponent<PageWorldInfo>().field_Public_ApiWorldInstance_0.worldId;
                Clipboard.SetText($"{isid}");
                Style.Consoles.consolelogger(isid);
            });
            Apis.Buttons.button.Createbutton("Author Id", world.transform.Find("Container").gameObject, () =>
            {
                var isid = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/WorldInfo").GetComponent<PageWorldInfo>().field_Public_APIUser_0.id;
                Clipboard.SetText($"{isid}");
                Style.Consoles.consolelogger(isid);
            });

        }
    }
}
