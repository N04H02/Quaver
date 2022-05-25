using System;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Shared.Assets;
using Quaver.Shared.Helpers;
using Quaver.Shared.Screens.Competitive.UI.RankDivisions;
using Quaver.Shared.Skinning;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.User
{
    public class RatingPanelStatsContainer : Sprite
    {
        private Sprite StatsContainer;

        public RatingPanelStatsContainer(float rating, int wins, int losses, RankDivision rankDivision)
        {
            Size = new ScalableVector2(210, 45);
            Alpha = 0f;

            StatsContainer = new Sprite()
            {
                Parent = this,
                Alignment = Alignment.MidLeft,
                Alpha = 0f,
                Size = new ScalableVector2(125, 45)
            };

            new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBlack), Math.Round(rating).ToString(), 26)
            {
                Parent = StatsContainer,
                Alignment = Alignment.TopRight,
                Tint = ColorHelper.HexToColor("#E9B736")
            };

            new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBlack), $"{wins}W / {losses}L", 18)
            {
                Parent = StatsContainer,
                Alignment = Alignment.BotRight,
                Tint = ColorHelper.HexToColor("#FFFFFF")
            };

            new Sprite()
            {
                Parent = this,
                Alignment = Alignment.MidRight,
                Size = new ScalableVector2(60, 36),
                Image = SkinManager.Skin?.RankDivisions[rankDivision] ?? UserInterface.Logo
            };
        }
    }
}