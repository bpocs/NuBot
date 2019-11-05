using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace NuBot
{
    class Bot
    {
        EventHandler _event;
        CommandHandler _command;
        DiscordSocketClient _client;
        static void Main()
        => new Bot().StartAsync().GetAwaiter().GetResult();
        public async Task StartAsync()
        {
            _event = new EventHandler();
            _command = new CommandHandler();
            if (Config.bot.token == "" || Config.bot.token == null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Bot Token is missing! \n \nPlease edit the key values in /resources/config.JSON and relaunch the bot!");
                Console.ReadKey();
                Console.ResetColor();
                return;
            }
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            Global.Client = _client;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            await _event.InitializeAsync(_client);
            await _command.InitializeAsync(_client);
            await _client.SetGameAsync("Poyozo Dolls");
            await Task.Delay(-1);
        }
        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}