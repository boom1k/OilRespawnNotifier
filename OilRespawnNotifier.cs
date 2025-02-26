using Oxide.Core;
using Oxide.Game.Rust.Cui;
using System;

namespace Oxide.Plugins
{
    [Info("OilRespawnNotifier", "boom1k", "1.2")]
    [Description("Notifies when Oil Rig and Large Oil respawn every 1 hour with color-coded time remaining.")]
    public class OilRespawnNotifier : RustPlugin
    {
        private Timer _timer;
        private DateTime _nextRespawnTime;

        void OnServerInitialized()
        {
            _nextRespawnTime = DateTime.Now.AddHours(1);

            _timer = timer.Every(60 * 60, () =>
            {
                Server.Command("spawn.fill_groups");
                SendMessageToAllPlayers("<color=#00FF00>Oil Rigs Respawned</color>");
                SendMessageToAllPlayers("<color=#00FF00>Large Oil Respawned</color>");
                _nextRespawnTime = DateTime.Now.AddHours(1);
            });

            timer.Every(1, () =>
            {
                TimeSpan timeLeft = _nextRespawnTime - DateTime.Now;

                if (timeLeft.TotalSeconds <= 3 && timeLeft.TotalSeconds > 2)
                    SendMessageToAllPlayers("<color=#FFFF00>3 seconds left</color>");
                else if (timeLeft.TotalSeconds <= 2 && timeLeft.TotalSeconds > 1)
                    SendMessageToAllPlayers("<color=#FFA500>2 seconds left</color>");
                else if (timeLeft.TotalSeconds <= 1 && timeLeft.TotalSeconds > 0)
                    SendMessageToAllPlayers("<color=#FF0000>1 second left</color>");
            });
        }

        void Unload()
        {
            if (_timer != null)
                _timer.Destroy();
        }

        private void SendMessageToAllPlayers(string message)
        {
            PrintToChat(message);
        }

        [ChatCommand("timer")]
        private void TimerCommand(BasePlayer player, string command, string[] args)
        {
            TimeSpan timeLeft = _nextRespawnTime - DateTime.Now;
            string timeLeftString = $"{timeLeft.Hours:D2}:{timeLeft.Minutes:D2}:{timeLeft.Seconds:D2}";
            SendReply(player, $"Time left until next respawn: {timeLeftString}");
        }
    }
}
