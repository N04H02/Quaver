using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics.Menu.Border.Components;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.Borders.Footer
{
    public class IconTextButtonCompetitiveBack : IconTextButton
    {
        public IconTextButtonCompetitiveBack(CompetitiveScreen screen) : base(
            FontAwesome.Get(FontAwesomeIcon.fa_chevron_pointing_to_the_left),
            FontManager.GetWobbleFont(Fonts.LatoBlack), "Back", (sender, args) => { screen.HandleBackAction(); })
        {
        }
    }
}