using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Quaver.Shared.Graphics.Menu;
using Quaver.Shared.Graphics.Menu.Border;
using Quaver.Shared.Graphics.Menu.Border.Components.Buttons;
using Wobble.Graphics;

namespace Quaver.Shared.Screens.Competitive.UI.Borders.Footer
{
    public class CompetitiveMenuFooter : MenuBorder
    {
        public CompetitiveMenuFooter(CompetitiveScreen screen) : base(MenuBorderType.Footer, new List<Drawable>()
            {
                new IconTextButtonCompetitiveBack(screen),
                new IconTextButtonOptions(),
                new IconTextButtonCompetitiveLeaderboard(),
            },
            new List<Drawable>()
            {
                new IconTextButtonTutorial(screen)
            })
        {
        }
    }
}