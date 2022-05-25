using Quaver.Server.Common.Enums;
using Quaver.Server.Common.Objects;
using Quaver.Shared.Config;
using Quaver.Shared.Modifiers;
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
    }
}