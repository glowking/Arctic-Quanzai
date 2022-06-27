using System;

namespace Arctic.Discord
{
    internal static class DiscordManager
    {
        internal static DiscordRpc.RichPresence presence;
        internal static DiscordRpc.EventHandlers eventHandlers;



        internal static void Init()
        {
            eventHandlers = default(DiscordRpc.EventHandlers);
            eventHandlers.errorCallback = delegate (int code, string message) { };
            presence.state = $"#1";
            presence.details = "User Loading";
            presence.largeImageKey = $"{settings.StyleConfig.discordrpcimg}";
            presence.largeImageText = "Arctic Client";
            presence.smallImageKey = "v4";
            presence.smallImageText = "Hi";
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            presence.partyId = "";
            presence.spectateSecret = "IDK";
            try
            {
                DiscordRpc.Initialize("969602306473603132", ref eventHandlers, true, "");
                DiscordRpc.UpdatePresence(ref presence);

            }
            catch { }


        }


    }
}