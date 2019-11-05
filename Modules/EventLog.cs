using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace NuBot.Modules
{
    public class EventLog
    {
        public async Task Welcome(SocketGuildUser user)
        {
            var client = Global.Client;
            ulong channelID = Convert.ToUInt64(Config.bot.publicChannel);
            var welcomeChannel = client.GetChannel(channelID) as SocketTextChannel;
            var avatar = user.GetAvatarUrl();
            if (avatar == null)
            {
                avatar = user.GetDefaultAvatarUrl();
            }
            var embed = new EmbedBuilder();
            embed.WithAuthor($"{user.Username} has Joined the Server.", avatar);
            embed.WithColor(new Color(114, 137, 218));
            embed.WithCurrentTimestamp();
            await welcomeChannel.SendMessageAsync("", false, embed.Build());
        }
        public async Task Farewell(SocketGuildUser user)
        {
            var client = Global.Client;
            ulong channelID = Convert.ToUInt64(Config.bot.publicChannel);
            var welcomeChannel = client.GetChannel(channelID) as SocketTextChannel;
            var avatar = user.GetAvatarUrl();
            if (avatar == null)
            {
                avatar = user.GetDefaultAvatarUrl();
            }
            var embed = new EmbedBuilder();
            embed.WithAuthor($"{user.Username} has Left the Server.", avatar);
            embed.WithColor(new Color(114, 137, 218));
            embed.WithCurrentTimestamp();
            await welcomeChannel.SendMessageAsync("", false, embed.Build());
        }
        public async Task RoleAddedMessage(IGuildUser user, IRole role)
        {
            var client = Global.Client;
            ulong channelID = Convert.ToUInt64(Config.bot.modChannel);
            var welcomeChannel = client.GetChannel(channelID) as SocketTextChannel;
            var avatar = user.GetAvatarUrl();
            if (avatar == null)
            {
                avatar = user.GetDefaultAvatarUrl();
            }
            var embed = new EmbedBuilder();
            embed.WithAuthor($"{user.Username} assigned themselves the \"{role}\" role. (ReactionRoles)", avatar);
            embed.WithColor(new Color(114, 137, 218));
            embed.WithCurrentTimestamp();
            await welcomeChannel.SendMessageAsync("", false, embed.Build());
        }
        public async Task RoleRemovedMessage(IGuildUser user, IRole role)
        {
            var client = Global.Client;
            ulong channelID = Convert.ToUInt64(Config.bot.modChannel);
            var welcomeChannel = client.GetChannel(channelID) as SocketTextChannel;
            var avatar = user.GetAvatarUrl();
            if (avatar == null)
            {
                avatar = user.GetDefaultAvatarUrl();
            }
            var embed = new EmbedBuilder();
            embed.WithAuthor($"{user.Username} retired from the \"{role}\" role. (ReactionRoles)", avatar);
            embed.WithColor(new Color(114, 137, 218));
            embed.WithCurrentTimestamp();
            await welcomeChannel.SendMessageAsync("", false, embed.Build());
        }
    }
}