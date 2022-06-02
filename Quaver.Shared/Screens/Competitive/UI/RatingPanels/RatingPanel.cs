using System.Drawing;
using Quaver.Shared.Assets;
using Quaver.Shared.Helpers;
using Quaver.Shared.Screens.Competitive.UI.RankDivisions;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.User
{
    public abstract class RatingPanel : Sprite
    {
        public const int Padding = 20;

        private RatingPanelStatsContainer Stats;

        public RatingPanel()
        {
            Size = new ScalableVector2(1000, 85);
            Image = UserInterface.SelectedMapset;

            new RatingPanelStatsContainer(1500, 100, 95, RankDivision.S)
            {
                Parent = this,
                Alignment = Alignment.MidRight,
                X = -Padding,
            };
        }
    }
}