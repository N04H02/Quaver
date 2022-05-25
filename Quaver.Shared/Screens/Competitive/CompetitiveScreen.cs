using Quaver.Server.Common.Enums;
using Quaver.Server.Common.Objects;
using Quaver.Shared.Config;
using Quaver.Shared.Graphics.Notifications;
using Quaver.Shared.Modifiers;
using Quaver.Shared.Screens.Main;
using Wobble.Screens;

namespace Quaver.Shared.Screens.Competitive
{
    public class CompetitiveScreen : QuaverScreen
    {
        public CompetitiveScreen()
        {
            View = new CompetitiveScreenView(this);
        }

        public override QuaverScreenType Type { get; } = QuaverScreenType.Competitive;

        public override UserClientStatus GetClientStatus() => new UserClientStatus(ClientStatus.InMenus, -1, "",
            (byte)ConfigManager.SelectedGameMode.Value, "", (long)ModManager.Mods);

        public void HandleBackAction()
        {
            Exit(() => new MainMenuScreen());
        }

        public void ShowTutorialModal()
        {
            NotificationManager.Show(NotificationLevel.Warning, "Not implemented yet!");
        }
    }
}