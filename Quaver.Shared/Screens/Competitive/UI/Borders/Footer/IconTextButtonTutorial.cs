using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics.Menu.Border.Components;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.Borders.Footer
{
    public class IconTextButtonTutorial : IconTextButton
    {
        public IconTextButtonTutorial(CompetitiveScreen screen) : base(
            FontAwesome.Get(FontAwesomeIcon.fa_information_symbol),
            FontManager.GetWobbleFont(Fonts.LatoBlack), "Tutorial", (sender, args) => { screen.ShowTutorialModal(); })
        {
        }
    }
}