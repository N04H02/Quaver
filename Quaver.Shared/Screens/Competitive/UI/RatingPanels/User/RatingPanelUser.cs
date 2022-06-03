using System.Drawing;
using Quaver.Shared.Assets;
using Quaver.Shared.Helpers;
using Quaver.Shared.Screens.Competitive.UI.RankDivisions;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.User
{
    public class RatingPanelUser : RatingPanel
    {
        public RatingPanelUser() : base() => new RatingPanelUserContent()
        {
            Parent = this,
            Alignment = Alignment.MidLeft,
            X = Padding,
        };
    }
}