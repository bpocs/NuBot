using System.Threading.Tasks;
using Discord.WebSocket;
using NuBot.Modules;
using Discord;
using System.Linq;

namespace NuBot
{
    class EventHandler
    {
        DiscordSocketClient _client;
        EventLog _event;
        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _event = new EventLog();
            _client.UserJoined += AnnounceJoinedUser;
            _client.UserLeft += AnnounceUserLeft;
            _client.ReactionAdded += AddedReactEvent;
            _client.ReactionRemoved += RemovedReactEvent;

        }
        private async Task AnnounceJoinedUser(SocketGuildUser user) //Welcomes the new user
        {
            await _event.Welcome(user);
        }
        private async Task AnnounceUserLeft(SocketGuildUser user) //Lets the channel know the user left
        {
            await _event.Farewell(user);
        }
        private async Task AddedReactEvent(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (message.Id == 641779659922472973) //must be updated after every rolecall. Update self reaction in misc.cs. Should consider changing this to channel ID
            {
                var newuser = reaction.User.Value as SocketGuildUser; //for anyone new, assign them the member status
                var user = reaction.User.Value as IGuildUser; //for assigning reaction roles 
                var newrole = ((ITextChannel)channel).Guild.GetRole(636672357649350732);
                if (!newuser.Roles.Contains(newrole))
                {
                    await user.AddRoleAsync(newrole);
                }
                if (reaction.Emote.Name == "ffxiv")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640795885344915456); //@FFXIV
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "gtav")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640797238024601601); //@GTAV
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "mhw")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808758628450324); //@Monster Hunter
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "lol")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808869152555008); //@League of Legends
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "fps")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808960848429068); //@FPS Junkie
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "ffbe")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640797372347187200); //@Brave Exvius
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
                if (reaction.Emote.Name == "poke")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640795935320047618); //@Pokemon Go
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
            }
        }
        private async Task RemovedReactEvent(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (message.Id == 641779659922472973) //must be updated after every rolecall. Update self reaction in misc.cs. Should consider changing this to channel ID
            {
                var user = reaction.User.Value as IGuildUser;
                if (reaction.Emote.Name == "ffxiv")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640795885344915456); //@FFXIV
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "gtav")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640797238024601601); //@GTAV
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "mhw")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808758628450324); //@Monster Hunter
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "lol")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808869152555008); //@League of Legends
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "fps")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808960848429068); //@FPS Junkie
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "ffbe")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640797372347187200); //@Brave Exvius
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "poke")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640795935320047618); //@Pokemon Go
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
            }
        }
    }
}
