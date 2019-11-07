using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using NuBot.Core.UserAccounts;

namespace NuBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        readonly string zws = "\u200B";
        [Command("nu")]
        public async Task Nu()
        {
            await Context.Channel.SendMessageAsync("**\"All life begins with Nu and ends with Nu. This is the truth! This is my belief! ...At least for now.\"** \n        -The Mystery of Life, vol. 841, chapter 26");
        }
        [Command("level")]
        public async Task MyStats()
        {
            SocketUser user = Context.User;
            var avatar = user.GetAvatarUrl();
            if (avatar == null)
            {
                avatar = user.GetDefaultAvatarUrl();
            }
            var account = UserAccounts.GetAccount(user);
            var embed = new EmbedBuilder();
            embed.WithAuthor($"Current Stats for {user.Username}", avatar);
            embed.WithFooter($"{user.Username} is Level {account.LevelNumber} and has {account.XP} XP.");
            embed.WithColor(new Color(114, 137, 218));
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        //admin only
        [Command("rolecall")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Rolecall()
        {
            var ffxiv = Emote.Parse("<:ffxiv:640804382681726976>");
            var gtav = Emote.Parse("<:gtav:641739856631955481>");
            var mhw = Emote.Parse("<:mhw:641039265685307413>");
            var lol = Emote.Parse("<:lol:641744315525103687>");
            var fps = Emote.Parse("<:fps:641740774316310528>");
            var ffbe = Emote.Parse("<:ffbe:641741179293007913>");
            var poke = Emote.Parse("<:poke:641742044569534484>");

            var embed = new EmbedBuilder();
            embed.WithTitle("Role Selection");
            embed.WithDescription($"Please React here to unlock the desired Roles for this server: \n {zws}");
            embed.AddField("<:ffxiv:640804382681726976> @FFXIV", "Gives access to the \"FFXIV\" Category");
            embed.AddField("<:gtav:641739856631955481> @GTAV", "Gives access to the \"GTAV\" Category");
            embed.AddField("<:mhw:641039265685307413> @Monster Hunter", "Gives access to the \"Monster Hunter\" Category");
            embed.AddField("<:lol:641744315525103687> @League of Legends", "Gives access to the \"League of Legends\" Category");
            embed.AddField("<:fps:641740774316310528> @FPS Junkie", "Gives access to the \"FPS Junky\" Category");
            embed.AddField("<:ffbe:641741179293007913> @Brave Exvius", "Gives access to the \"Brave Exvius\" Category");
            embed.AddField("<:poke:641742044569534484> @Pokemon Go", "Gives access to the \"Pokemon Go\" Category");
            embed.WithFooter("Removing your reaction will also remove your Role. FFXIV FC Members and Static Raid members should ping a moderator for assigning additional roles.");
            embed.WithColor(new Color(114, 137, 218));
            var reactionmessage = await Context.Channel.SendMessageAsync("", false, embed.Build());

            await reactionmessage.AddReactionAsync(ffxiv);
            await reactionmessage.AddReactionAsync(gtav);
            await reactionmessage.AddReactionAsync(mhw);
            await reactionmessage.AddReactionAsync(lol);
            await reactionmessage.AddReactionAsync(fps);
            await reactionmessage.AddReactionAsync(ffbe);
            await reactionmessage.AddReactionAsync(poke);
        }
    }
}
