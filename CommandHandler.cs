using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using NuBot.Core.LevelingSystem;

namespace NuBot
{
    class CommandHandler
    {
        CommandService _service;
        DiscordSocketClient _client;
        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            _client.MessageReceived += HandleCommandAsync;
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), null);
        }
        private async Task HandleCommandAsync(SocketMessage s) //Handles commands
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;

            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos, System.StringComparison.OrdinalIgnoreCase) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                await _service.ExecuteAsync(context, argPos, services: null);
            }
            //Leveling.UserSentMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel); //Gives EXP per channel message
        }
    }
}