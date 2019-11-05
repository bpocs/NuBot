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
            if (message.Id == 641061488563322881) //must be updated after every rolecall. Update self reaction in 
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
                if (reaction.Emote.Name == "mhw")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808758628450324); //@Monster Hunter
                    await user.AddRoleAsync(role);
                    await _event.RoleAddedMessage(user, role);
                }
            }
        }
        private async Task RemovedReactEvent(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (message.Id == 641061488563322881) //must be updated after every rolecall. Update self reaction in
            {
                var user = reaction.User.Value as IGuildUser;
                if (reaction.Emote.Name == "ffxiv")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640795885344915456); //@FFXIV
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
                if (reaction.Emote.Name == "mhw")
                {
                    var role = ((ITextChannel)channel).Guild.GetRole(640808758628450324); //@Monster Hunter
                    await user.RemoveRoleAsync(role);
                    await _event.RoleRemovedMessage(user, role);
                }
            }
        }
    }
}