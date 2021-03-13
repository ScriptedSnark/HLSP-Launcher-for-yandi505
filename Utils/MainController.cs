// Original code by InfiniteC0re (Developer of HLSR). Thanks to you!
// Adaptation for HLSP Launcher by ScriptedSnark

using System;
using DiscordRPC;

namespace HLSP_Launcher_for_yandi505
{
    public class MainController
    {   
        // Публичные переменные контроллера (доступны извне)
        public DiscordRpcClient client;

        // Приватные переменные контроллера
        private string _defaultState;
        private string _defaultDetails;
        private string _defaultSmallImage;

        public MainController()
        {
            _defaultState = String.Format("Находится в лаунчере");
            _defaultDetails = "Версия 1.1";
            _defaultSmallImage = "image_small";

            client = new DiscordRpcClient("734435821310050446");

            client.Initialize();
        }

        public void updateRPC(string details = "", string state = "", string smallImage = "")
        {
            if (details == "")
                details = _defaultDetails;
            if (state == "")
                state = _defaultState;
            if (smallImage == "")
                smallImage = _defaultSmallImage;
            
            
            client.SetPresence(new RichPresence()
            {
                Details = details, // Основное описание
                State = state, // Состояние (Что делает)
                Timestamps = Timestamps.Now,
                Buttons = new Button[]
                {
                    new Button() { Label = "Скачать сборку", Url = "https://vk.com/@grunge_isdead-speedrunpackage" },
                    new Button() { Label = "Туториалы", Url = "https://www.youtube.com/yandi505" }
                },
                Assets = new Assets()
                {
                    LargeImageKey = "image_large",
                    LargeImageText = "Авторы лаунчера - ScriptedSnark и yandi505",
                    SmallImageKey = smallImage
                }
            });
        }
    }
}
