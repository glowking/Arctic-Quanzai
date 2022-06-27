using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Arctic.settings
{
    [Serializable]
    public class styledata
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Chatmsg { get; set; }
        public string? JoyStick { get; set; }
        public string? BiguiImg { get; set; }
        public string? qmimg { get; set; }

        public string? discordrpcimg { get; set; }

        public string? debuggerimg { get; set; }
        public string? Playerlistimg { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public float? redb { get; set; }
        public float? blueb { get; set; }
        public float? greenb { get; set; }
        public float? Transpb { get; set; }
        public float? HRed { get; set; }
        public float? HGreen { get; set; }
        public float? HBlue { get; set; }
        public float? HTransp { get; set; }
        public float? TRed { get; set; }
        public float? TGreen { get; set; }
        public float? TBlue { get; set; }
        public float? TTransp { get; set; }
        public bool? backgoundbuttons { get; set; }
        public  float? Playerlisttransparancy { get; set; }
        public  float? debuggertrasnparancy { get; set; }
        public  float? qmtransparancy { get; set; }
        public  float? Biguitransparancy { get; set; }
        public  float? PlayerlistDim  { get; set; }
        public  float? DebuggerDim  { get; set; }
        public  float? QmDim  { get; set; }
        public  float? BigmenuDim  { get; set; }
        public string? Debbuggerqm { get; set; }

    }
    public class configa
    {
        public bool? debugger { get; set; }
        public bool? Playerlist { get; set; }
        public bool? playerlistgui { get; set; }
        public bool? Nameplates { get; set; }
        public int? spoofpng { get; set; }
        public bool? spofpngtogg { get; set; }
        public int? spooffps { get; set; }
        public bool? spooffpstoog { get; set; }
        public bool? Questhide { get; set; }
        public bool? questspoof { get; set; }
        public bool? ESP { get; set; }
        public bool? Forcejump { get; set; }
        public bool? infiniteJump { get; set; }
        public bool? Logudonevents { get; set; }
        public float? flyspeed { get; set; }
        public bool? itemesp { get; set; }
        public bool? walkspeedt { get; set; }
        public float? walkspeed { get; set; }
        public bool? stealpickup { get; set; }
        public bool? Maxpickuprange { get; set; }
        public bool? Esplines { get; set; }
        public bool? Keybinds { get; set; }
        public bool? UdonBlock { get; set; }
        public bool? Infiniteportals { get; set; }
        public bool? ScreenLogger { get; set; }
        public bool? DiscordRich { get; set; }
        public bool? customfov { get; set; }
        public float? Fov { get; set; }
        public bool? pickupknife { get; set; }
        public bool? Boxesp { get; set; }
        public bool? Qmmusic { get; set; }
        public bool? Lineesp { get; set; }
        public bool? Videoplayer { get; set; }
        public bool? BigVideoLoadingscreen { get; set; }
        public bool? JoinSound { get; set; }
        public bool? Restartu { get; set; }
        public bool? Dsicordrpcgif { get; set; }
        public bool? joinnot { get; set; }
        public bool? custommic { get; set; }
        public bool? logudon { get; set; }
        public bool? logphotonev { get; set; }
        public bool? loginconssole { get; set; }
        public bool? ev6 { get; set; }
        public bool? ev9 { get; set; }
        public bool? ev7 { get; set; }
        public bool? ev1 { get; set; }
        public bool? onscreennotification { get; set; }
        public bool? fpsandstuffinfo { get; set; }
        public bool? DisableConsole { get; set; }
        public float? JumpIMpulse { get; set; }
        public bool? NamePlatesuichange { get; set; }
        public bool?  rainbackground { get; set; }
        public bool? BigUichanges { get; set; }
        public bool? DESKTOPUI { get; set; }
        public bool? PickableItems { get; set; }

        public bool? Qmuitstyle { get; set; }
        public bool? Overwritetextcolor { get; set; }
        public bool? qmextinfo { get; set; }
        public bool? istextoverboth { get; set; }
        public string? putyourowntext { get; set; }

        public bool? Favortielistenabled { get; set; }
        public bool? boneesp { get; set; }
        public bool? pointlines { get; set; }
        public bool? Avatarsseeninworld { get; set; }
        public bool? avataroutlines { get; set; }
        public bool? customaspectratio { get; set; }
        public float? aspectrationvalue { get; set; }
        public bool? onqmuserinfo { get; set; }
        public bool? customnameplates { get; set; }
        public int? maxverticies { get; set; }
        public int? maxaudiosources { get; set; }
        public int? maxmaterials { get; set; }
        public int? maxmeshes { get; set; }
        public int? maxparticles { get; set; }
        public int? particlesystem { get; set; }
        public bool? verticiesp { get; set; }
        public bool? meshp { get; set; }
        public bool? ShaderP { get; set; }
        public bool? audiosourcep { get; set; }
        public bool? particlep { get; set; }
        public bool? linerenderp { get; set; }
        public bool? lightsp { get; set; }
        public bool? selfanti { get; set; }
        public bool? logshaderstoconsole { get; set; }

    }

    public class nconfig
    {
        public static void saveconfig(string path)
        {
            var sv = new configa()
            {
                questspoof = questspoof,
                debugger = debugger,
                Playerlist = Playerlist,
                playerlistgui = playerlistgui,
                Nameplates = Nameplates,
                spoofpng = spoofpng,
                spofpngtogg = spofpngtogg,
                spooffps = spooffps,
                spooffpstoog = spooffpstoog,
                Questhide = Questhide,
                ESP = ESP,
                Forcejump = Forcejump,
                infiniteJump = infiniteJump,
                Logudonevents = Logudonevents,
                flyspeed = flyspeed,
                itemesp = itemesp,
                walkspeedt = walkspeedt,
                walkspeed = walkspeed,
                stealpickup = stealpickup,
                Maxpickuprange = Maxpickuprange,
                Esplines = Esplines,
                Keybinds = Keybinds,
                UdonBlock = UdonBlock,
                Infiniteportals = Infiniteportals,
                ScreenLogger = ScreenLogger,
                DiscordRich = DiscordRich,
                customfov = customfov,
                Fov = Fov,
                pickupknife = pickupknife,
                Boxesp = Boxesp,
                Qmmusic = Qmmusic,
                Lineesp = Lineesp,
                Videoplayer = Videoplayer,
                BigVideoLoadingscreen = BigVideoLoadingscreen,
                JoinSound = JoinSound,
                Restartu = Restartu,
                Dsicordrpcgif = Dsicordrpcgif,
                joinnot = joinnot,
                custommic = custommic,
                logudon = logudon,
                logphotonev = logphotonev,
                loginconssole = loginconssole,
                ev9 = ev9,
                ev7 = ev7,
                ev6 = ev6,
                ev1 = ev1,
                onscreennotification = onscreennotification,
                fpsandstuffinfo = fpsandstuffinfo,
                DisableConsole = DisableConsole,
                JumpIMpulse = JumpIMpulse,
                NamePlatesuichange = NamePlatesuichange,
                BigUichanges = BigUichanges,
                rainbackground = rainbackground,
                DESKTOPUI = DESKTOPUI,
                PickableItems = PickableItems,
                Qmuitstyle = Qmuitstyle,
                Overwritetextcolor = Overwritetextcolor,
                qmextinfo = qmextinfo,
                istextoverboth = istextoverboth,
                putyourowntext = putyourowntext,
                Favortielistenabled = Favortielistenabled,
                boneesp = boneesp,
                pointlines = pointlines,
                Avatarsseeninworld = Avatarsseeninworld,
                avataroutlines = avataroutlines,
                customaspectratio = customaspectratio,
                aspectrationvalue = aspectrationvalue,
                onqmuserinfo = onqmuserinfo,
                customnameplates = customnameplates,
                maxmeshes = maxmeshes,
                maxverticies = maxverticies,
                maxmaterials = maxmaterials,
                maxaudiosources = maxaudiosources,
                audiosourcep = audiosourcep,
                lightsp = lightsp,
                linerenderp = linerenderp,
                meshp = meshp,
                particlep = particlep,
                ShaderP = ShaderP,
                verticiesp = verticiesp,
                maxparticles = maxparticles,
                particlesystem = particlesystem,
                selfanti = selfanti,
                logshaderstoconsole = logshaderstoconsole,
            };
            File.WriteAllText(path, $"{Newtonsoft.Json.JsonConvert.SerializeObject(sv)}");

        }

        public static void applyconfig(string path, configa sta)
        {
            debugger = (bool)sta.debugger;
            Playerlist = (bool)sta.Playerlist;
            playerlistgui = (bool)sta.playerlistgui;
            Nameplates = (bool)sta.Nameplates;
            spoofpng = (int)sta.spoofpng;
            spofpngtogg = (bool)sta.spofpngtogg;
            spooffps = (int)sta.spooffps;
            spooffpstoog = (bool)sta.spooffpstoog;
            Questhide = (bool)sta.Questhide;
            questspoof = (bool)sta.questspoof;
            ESP = (bool)sta.ESP;
            Forcejump = (bool)sta.Forcejump;
            infiniteJump = (bool)sta.infiniteJump;
            Logudonevents = (bool)sta.Logudonevents;
            flyspeed = (float)sta.flyspeed;
            itemesp = (bool)sta.itemesp;
            walkspeedt = (bool)sta.walkspeedt;
            walkspeed = (float)sta.walkspeed;
            stealpickup = (bool)sta.stealpickup;
            Maxpickuprange = (bool)sta.Maxpickuprange;
            Esplines = (bool)sta.Esplines;
            Keybinds = (bool)sta.Keybinds;
            UdonBlock = (bool)sta.UdonBlock;
            Infiniteportals = (bool)sta.Infiniteportals;
            ScreenLogger = (bool)sta.ScreenLogger;
            DiscordRich = (bool)sta.DiscordRich;
            customfov = (bool)sta.customfov;
            Fov = (float)sta.Fov;
            pickupknife = (bool)sta.pickupknife;
            Boxesp = (bool)sta.Boxesp;
            Qmmusic = (bool)sta.Qmmusic;
            Lineesp = (bool)sta.Lineesp;
            Videoplayer = (bool)sta.Videoplayer;
            BigVideoLoadingscreen = (bool)sta.BigVideoLoadingscreen;
            JoinSound = (bool)sta.JoinSound;
            Restartu = (bool)sta.Restartu;
            Dsicordrpcgif = (bool)sta.Dsicordrpcgif;
            joinnot = (bool)sta.joinnot;
            custommic = (bool)sta.custommic;
            logudon = (bool)sta.logudon;
            logphotonev = (bool)sta.logphotonev;
            loginconssole = (bool)sta.loginconssole;
            ev6 = (bool)sta.ev6;
            ev9 = (bool)sta.ev9;
            ev7 = (bool)sta.ev7;
            ev1 = (bool)sta.ev1;
            onscreennotification = (bool)sta.onscreennotification;
            fpsandstuffinfo = (bool)sta.fpsandstuffinfo;
            DisableConsole = (bool)sta.DisableConsole;
            JumpIMpulse = (float)sta.JumpIMpulse;
            rainbackground = (bool)sta.rainbackground;
            NamePlatesuichange = (bool)sta.NamePlatesuichange;
            BigUichanges = (bool)sta.BigUichanges;
            DESKTOPUI = (bool)sta.DESKTOPUI;
            PickableItems = (bool)sta.PickableItems;
            Qmuitstyle = (bool)sta.Qmuitstyle;
            Overwritetextcolor = (bool)sta.Overwritetextcolor;
            qmextinfo = (bool)sta.qmextinfo;
            istextoverboth = (bool)sta.istextoverboth;
            putyourowntext = (string)sta.putyourowntext;
            Favortielistenabled = (bool)sta.Favortielistenabled;
            boneesp = (bool)sta.boneesp;
            pointlines = (bool)sta.pointlines;
            Avatarsseeninworld = (bool)sta.Avatarsseeninworld;
            avataroutlines = (bool)sta.avataroutlines;
            customaspectratio = (bool)sta.customaspectratio;
            aspectrationvalue = (float)sta.aspectrationvalue;
            onqmuserinfo = (bool)sta.onqmuserinfo;
            customnameplates = (bool)sta.customnameplates;
            maxaudiosources = (int)sta.maxaudiosources;
            maxmaterials = (int)sta.maxmaterials;
            maxverticies = (int)sta.maxverticies;
            maxmeshes = (int)sta.maxmeshes;
            verticiesp = (bool)sta.verticiesp;
            meshp = (bool)sta.meshp;
            ShaderP = (bool)sta.ShaderP;
            audiosourcep = (bool)sta.audiosourcep;
            particlep = (bool)sta.particlep;
            linerenderp = (bool)sta.linerenderp;
            lightsp = (bool)sta.lightsp;
            maxparticles = (int)sta.maxparticles;
            particlesystem = (int)sta.particlesystem;
            selfanti = (bool)sta.selfanti;
            logshaderstoconsole = (bool)sta.logshaderstoconsole;
            saveconfig(path);

        }

        public static bool debugger = true;
        public static bool Playerlist = true;
        public static bool playerlistgui = false;
        public static bool Nameplates = true;
        public static int spoofpng = 777;
        public static bool spofpngtogg = false;
        public static int spooffps = 777;
        public static bool spooffpstoog = false;
        public static bool Questhide = false;
        public static bool questspoof = false;
        public static bool ESP = true;
        public static bool Forcejump = false;
        public static bool infiniteJump = true;
        public static bool Logudonevents = false;
        public static float flyspeed = 1f;
        public static bool itemesp = false;
        public static bool walkspeedt = false;
        public static float walkspeed = 1;
        public static bool stealpickup = true;
        public static bool Maxpickuprange = true;
        public static bool Esplines = false;
        public static bool Keybinds = true;
        public static bool UdonBlock = false;
        public static bool Infiniteportals = false;
        public static bool ScreenLogger = true;
        public static bool DiscordRich = true;
        public static bool customfov = false;
        public static float Fov = 60;
        public static bool pickupknife = true;
        public static bool Boxesp = false;
        public static bool Qmmusic = true;
        public static bool Lineesp = false;
        public static bool Videoplayer = true;
        public static bool BigVideoLoadingscreen = true;
        public static bool JoinSound = true;
        public static bool Restartu = true;
        public static bool Dsicordrpcgif = true;
        public static bool joinnot = true;
        public static bool custommic = false;
        public static bool logudon = false;
        public static bool logphotonev = false;
        public static bool loginconssole = false;
        public static bool ev6 = false;
        public static bool ev9 = false;
        public static bool ev7 = false;
        public static bool ev1 = false;
        public static bool onscreennotification = true;
        public static bool fpsandstuffinfo = true;
        public static bool DisableConsole = false;
        public static float JumpIMpulse = 3;
        public static bool BigUichanges = true;
        public static bool rainbackground = true;
        public static bool NamePlatesuichange = true;
        public static bool DESKTOPUI = false;
        public static bool PickableItems = false;
        public static bool Qmuitstyle = true;
        public static bool Overwritetextcolor = true;
        public static bool qmextinfo = true;
        public static bool istextoverboth = false;
        public static string putyourowntext = "EMPTY TEXT";
        public static bool Favortielistenabled = true;
        public static bool boneesp = false;
        public static bool pointlines = false;
        public static bool Avatarsseeninworld = true;
        public static bool avataroutlines = false;
        public static bool customaspectratio = false;
        public static float aspectrationvalue = 1.2f;
        public static bool onqmuserinfo = true;
        public static bool customnameplates = true;
        public static int maxaudiosources = 15;
        public static int maxmaterials = 60;
        public static int maxmeshes = 100;
        public static int maxverticies = 200000;
        public static int maxparticles = 30000;
        public static int particlesystem = 30;

        public static bool verticiesp = true;
        public static bool meshp = true;
        public static bool ShaderP = true;
        public static bool audiosourcep = true;
        public static bool particlep = true;
        public static bool linerenderp = true;
        public static bool lightsp = true;
        public static bool selfanti = true;
        public static bool logshaderstoconsole = true;

    }

    public class StyleConfig
    {
        public static void savestyleconfig(string path)
        {

            var bc = new styledata()
            {
                Chatmsg = Chatmsg,
                JoyStick = JoyStick,
                BiguiImg = BiguiImg,
                qmimg = qmimg,
                debuggerimg = debuggerimg,
                Playerlistimg = Playerlistimg,
                redb = redb,
                greenb = greenb,
                blueb = blueb,
                Transpb = Transpb,
                HRed = HRed,
                HGreen = HGreen,
                HBlue = HBlue,
                HTransp = Transpb,
                TRed = TRed,
                TGreen = TGreen,
                TBlue = TBlue,
                TTransp = TTransp,
                backgoundbuttons = backgoundbuttons,
                Playerlisttransparancy = Playerlisttransparancy,
                debuggertrasnparancy = debuggertrasnparancy,
                Biguitransparancy = Biguitransparancy,
                qmtransparancy = qmtransparancy,
                BigmenuDim = BigmenuDim,
                DebuggerDim = DebuggerDim,
                PlayerlistDim = PlayerlistDim,
                QmDim = QmDim,
                Debbuggerqm = Debbuggerqm,
                discordrpcimg = discordrpcimg,

            };
            File.WriteAllText(path, $"{Newtonsoft.Json.JsonConvert.SerializeObject(bc)}");
        }

        public static void applyconfig(string path, styledata sta)
        {
            Chatmsg = (string)sta.Chatmsg;
            JoyStick = (string)sta.JoyStick;
            BiguiImg = (string)sta.BiguiImg;
            qmimg = (string)sta.qmimg;
            debuggerimg = (string)sta.debuggerimg;
            Playerlistimg = (string)sta.Playerlistimg;
            redb = (float)sta.redb;
            greenb = (float)sta.greenb;
            blueb = (float)sta.blueb;
            Transpb = (float)sta.Transpb;
            HRed = (float)sta.HRed;
            HGreen = (float)sta.HGreen;
            HBlue = (float)sta.HBlue;
            HTransp = (float)sta.Transpb;
            TRed = (float)sta.TRed;
            TGreen = (float)sta.TGreen;
            TBlue = (float)sta.TBlue;
            TTransp = (float)sta.TTransp;
            backgoundbuttons = (bool)sta.backgoundbuttons;
            Playerlisttransparancy = (float)sta.Playerlisttransparancy;
            debuggertrasnparancy = (float)sta.debuggertrasnparancy;
            Biguitransparancy = (float)sta.Biguitransparancy;
            qmtransparancy = (float)sta.qmtransparancy;
            PlayerlistDim = (float)sta.PlayerlistDim;
            DebuggerDim = (float)sta.DebuggerDim;
            QmDim = (float)sta.QmDim;
            BigmenuDim = (float)sta.BigmenuDim;
            debuggerimg = (string)sta.debuggerimg;
            discordrpcimg = (string)sta.discordrpcimg;
           savestyleconfig(path);

        }


        public static string Chatmsg = "https://nocturnal-client.xyz/cl/darkred/chat.jpg";
        public static string JoyStick = "https://nocturnal-client.xyz/cl/Download/Media/joystickbtn.png";
        public static string BiguiImg = "https://nocturnal-client.xyz/cl/animewallpaper.jpg";
        //public static string qmimg = "https://nocturnal-client.xyz/cl/darkred/qm.png";
        public static string qmimg = "https://api.glowking.net/cl/Earth-chan.jpg";
        public static string debuggerimg = "https://nocturnal-client.xyz/cl/darkred/roses.png";
        public static string Playerlistimg = "https://nocturnal-client.xyz/cl/darkred/wallr.jpg";
        public static string Debbuggerqm = "https://nocturnal-client.xyz/cl/darkred/chat.jpg";
        public static string discordrpcimg = "https://api.glowking.net/cl/AC-logo.jpg";

        public static float? redb = 0.5729113f;
        public static float blueb = 0.837204039f;
        public static float greenb = 0.602274656f;
        public static float Transpb = 0.86f;
        public static float HRed = 0;
        public static float HGreen = 0.438850343f;
        public static float HBlue = 0.712937f;
        public static float HTransp = 0.86f;
        public static float TRed = 0f;
        public static float TGreen = 0.843176365f;
        public static float TBlue = 1f;
        public static float TTransp = 1;
        public static bool backgoundbuttons = true;
        public static float Playerlisttransparancy = 0.7f;
        public static float debuggertrasnparancy = 0.7f;
        public static float qmtransparancy = 0.7f;
        public static float Biguitransparancy = 0.972496f;
        public static float PlayerlistDim = 0.8f;
        public static float DebuggerDim = 0.8f;
        public static float QmDim = 0.8f;
        public static float BigmenuDim = 0.231890112f;


  

        // File.WriteAllText(pat)
    }

  


}
