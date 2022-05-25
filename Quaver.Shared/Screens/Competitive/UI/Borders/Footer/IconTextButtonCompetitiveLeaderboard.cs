using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics.Menu.Border.Components;
using Quaver.Shared.Helpers;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.Borders.Footer
{
    public class IconTextButtonCompetitiveLeaderboard : IconTextButton
    {
        public IconTextButtonCompetitiveLeaderboard() : base(
            FontAwesome.Get(FontAwesomeIcon.fa_numbered_list),
            FontManager.GetWobbleFont(Fonts.LatoBlack), "Leaderboards", (sender, args) =>
            {
                // TODO: Update URL
                BrowserHelper.OpenURL($"https://quavergame.com");
            })
        {
        }
    }
}