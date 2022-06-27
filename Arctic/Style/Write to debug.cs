using MelonLoader;
using System.Collections;
using UnityEngine;

namespace Arctic.Style
{
    class textdebuger
    {
        public static string lastlines = "";
        private static bool waittime = true;
        public static TMPro.TextMeshProUGUI screenlogger;

        public static string lastlines2 = "";

        public static void ChatMsg(string User, string text)
        {
            while (Main.Loaders.Loadqm.chattext == null)
                return;

            if (lastlines2 != string.Empty)
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Main.Loaders.Loadqm.chattext.text = "";
                Main.Loaders.Loadqm.chattext.text = $"<color=#660121>{stringtime}</color><color=#ffffffff> > <color=#d90045>{User}</color>: {text}\n{lastlines2}";
                lastlines2 = Main.Loaders.Loadqm.chattext.text;
            }
            else
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Main.Loaders.Loadqm.chattext.text = $"<color=#660121>{stringtime}</color><color=#ffffffff> > <color=#d90045>{User}</color>: {text}\n";
                lastlines2 = Main.Loaders.Loadqm.chattext.text;
            }
            if (lastlines2.Split('\n').Length >= 15)
            {
                string stringi = "";
                int ab = 0;
                foreach (var line in lastlines2.Split('\n'))
                {
                    ab += 1;
                    if (ab < 25)
                    {
                        stringi += $"{line}\n";
                    }
                }
                lastlines2 = stringi;
            }
            Main.Loaders.Loadqm.chattext.text = lastlines2;



        }

        public static void debugermsg(string text)
        {
            while (Style.Uichanges.istext == null)
                return;


            if (lastlines != string.Empty)
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Style.Uichanges.istext.text = "";
                Style.Uichanges.istext.text = $"[<color=#ffff00ff>{stringtime}</color>] - {text}\n{lastlines}";
                lastlines = Style.Uichanges.istext.text;
            }
            else
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Style.Uichanges.istext.text = $"[<color=#ffff00ff>{stringtime}</color>] - {text}\n";
                lastlines = Style.Uichanges.istext.text;
            }
            if (settings.nconfig.ScreenLogger)
            {
                screenlogger.gameObject.SetActive(true);
                screenlogger.text += $"{text}\n";
                MelonCoroutines.Start(disabledebug());
            }
            while (Style.Image.text == null)
                return;


            if (lastlines != string.Empty)
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Style.Image.text.text = "";
                Style.Image.text.text = lastlines;
            }
            else
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Style.Image.text.text = $"[<color=#ffff00ff>{stringtime}</color>] - {text}\n";
            }
            if (lastlines.Split('\n').Length >= 15)
            {
                string stringi = "";
                int ab = 0;
                foreach (var line in lastlines.Split('\n'))
                {
                    ab += 1;
                    if (ab < 25)
                    {
                        stringi += $"{line}\n";
                    }
                }
                lastlines = stringi;
            }
            Style.Uichanges.istext.text = lastlines;





            if (!settings.nconfig.debugger) return;

        }
        public static void OnscreenOnly(string text, string? melonlogger)
        {
            if (settings.nconfig.ScreenLogger)
            {
                screenlogger.gameObject.SetActive(true);
                screenlogger.text += $"{text}\n";
                MelonCoroutines.Start(disabledebug());
            }
            if (melonlogger == null)
                Style.Consoles.consolelogger(text);
            else
                Style.Consoles.consolelogger(melonlogger);

        }

        private static IEnumerator disabledebug()
        {
            if (waittime)
            {
                waittime = false;
                yield return new WaitForSeconds(4.5f);
                screenlogger.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                screenlogger.gameObject.SetActive(false);
                waittime = true;
            }
            else
                yield break;


        }

    }
}
