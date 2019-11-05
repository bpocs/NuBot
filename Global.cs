using Discord.WebSocket;

namespace NuBot
{
    public class Global
    {
        internal static DiscordSocketClient Client { get; set; }
        internal static ulong MessageIdToTrack { get; set; }
    }
}