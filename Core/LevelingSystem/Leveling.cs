using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuBot.Core.LevelingSystem
{
    internal static class Leveling
    {
        internal static async void UserSentMessage(SocketGuildUser user, SocketTextChannel channel)
        {
            var userAccount = UserAccounts.UserAccounts.GetAccount(user);
            uint oldLevel = userAccount.LevelNumber;
            userAccount.XP += 50;
            UserAccounts.UserAccounts.SaveAccounts();
            uint newLevel = userAccount.LevelNumber;

            if (oldLevel != newLevel)
            {
                var avatar = user.GetAvatarUrl();
                if (avatar == null)
                {
                    avatar = user.GetDefaultAvatarUrl();
                }
                var embed = new EmbedBuilder();
                embed.WithAuthor($"{user.Username} just reached Level {newLevel}!", avatar);
                embed.WithColor(new Color(114, 137, 218));
                embed.WithCurrentTimestamp();
                await channel.SendMessageAsync("", false, embed.Build());
            }
        }
    }
}