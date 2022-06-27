using MelonLoader;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using VRC;
using WebSocketSharp;

namespace Arctic
{
    class connect
    {
        internal static WebSocket wss;
        internal static bool waitfortime = false;
        internal protected static bool ath = false;
        internal static string aviserchl = "";
        public static void Runsocket()
        {


           
            using (wss = new WebSocket("ws://localhost:8080"))
            {
                 wss.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                wss.Connect();
                wss.OnClose += (sender, e) =>
                {

                    tryrecconect();
                };
                wss.OnOpen += (sender, e) =>
                {
                    var sendidtosv = new settings.sendsinglemsg()
                    {
                        Custommsg = VRC.Core.APIUser.CurrentUser.id,

                        code = "1",
                    };
                    sendmsg($"{JsonConvert.SerializeObject(sendidtosv)}");
                };
                wss.OnMessage += Ws_OnMessage;
                wss.Log.Output = (_, __) => { };

            }
        }

        public static void sendmsg(string text)
        {
            if (connect.wss.IsAlive)
                connect.wss.Send(text);
              //Style.Consoles.consolelogger(text);
        }

        internal static void tryrecconect()
        {
            try
            {
                if (!connect.wss.IsAlive)
                    wss.Connect();
            }
            catch (Exception error)
            {

               Style.Consoles.consolelogger("Cloud not connect : " + error);
                 wss.Connect();
               // System.Diagnostics.Process.GetCurrentProcess().Kill();

            }

        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            var message = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(e.Data));
            // MelonLoader.Style.Consoles.consolelogger(message);
            //Style.Consoles.consolelogger(message);


            if (message.Contains("AvatarName") && message.Contains("Authorid") && message.Contains("Asseturl"))
            {
                aviserchl = message;
                return;
            }

            if (message.Contains("roleslist") && message.Contains("permision") && message.Contains("userid"))
            {
                MelonCoroutines.Start(Ac(message));
                return;
            }


            if (message.Contains("clinetmessage") && message.Contains("user"))
            {

                var abc = Newtonsoft.Json.JsonConvert.DeserializeObject<settings.Recivemessage>(message);
                Style.textdebuger.ChatMsg($"[{abc.uid}]{abc.user}", abc.clinetmessage);
                if (!GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Submenu_Client Chat").gameObject.activeSelf && settings.nconfig.onscreennotification)
                {
                    var btn = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Nocturnal/Badge");
                    btn.gameObject.SetActive(true);
                    Main.Loaders.Loadqm.msgcount += 1;
                    btn.transform.Find("Text_QM_H5").GetComponent<TMPro.TextMeshProUGUI>().text = $"{Main.Loaders.Loadqm.msgcount} NEW";
                    if (settings.nconfig.onscreennotification)
                        Style.Uichanges.notification.gameObject.SetActive(true);
                }

                return;
            }


            if (message.ToString() == "UserAuth")
            {
                ath = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Style.Consoles.consolelogger("Welcome");
            }
            else if (message.ToString() == "UserNotAuth")
            {
                Style.Consoles.consolelogger("UKNOWN HWID");
              //  System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        protected internal static IEnumerator Ac(string str)
        {
            var des = JsonConvert.DeserializeObject<settings.ReciveRoles>(str);
            var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
            for (int i = 0; i < player.Count; i++)
            {
                yield return new WaitForSeconds(0.5f);

                if (player[i].field_Private_APIUser_0.id == des.userid)
                {
                    for (int it = 0; it < des.roleslist.Count; it++)
                    {
                        yield return new WaitForSeconds(0.5f);

                        var getplate = player[i]._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext");
                        var platedup = GameObject.Instantiate(getplate, getplate.parent);
                        var platetext = platedup.transform.Find("Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                        platetext.text = des.roleslist[it];
                        platedup.transform.Find("Userperfplate").gameObject.SetActive(settings.nconfig.customnameplates);

                    }

                    if (des.permision != "0")
                    {
                        var getplate2 = player[i]._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext");
                        var platedup2 = GameObject.Instantiate(getplate2, getplate2.parent);
                        var platetext2 = platedup2.transform.Find("Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                        platetext2.text = "<color=#10001c>N</color> <color=#3e006b>T</color><color=#4f0087>r</color><color=#580096>u</color><color=#6400ab>s</color><color=#6f02bd>t</color><color=#8300e0>e</color><color=#9500ff>d";
                        platedup2.transform.Find("Userperfplate").gameObject.SetActive(settings.nconfig.customnameplates);
                    }
                }
            }
            yield return null;
        }
    }
}

