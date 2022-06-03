using Quaver.Shared.Assets;
using Quaver.Shared.Helpers;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.Map
{
    public class RatingPanelMapContent : Sprite
    {

        private const int Padding = 13;

        private SpriteTextPlus Title { get; set; }

        private SpriteTextPlus CreatorAndDifficulty { get; set; }

        public RatingPanelMapContent()
        {
            Size = new ScalableVector2(800, 85);
            Alpha = 0f;

            CreateTitleText();
            CreateCreatorAndDifficultyText();

            UpdateState();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateTitleText() => Title = new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBlack), "", 24)
        {
            Parent = this,
            Alignment = Alignment.MidLeft,
            Y = -Padding,
            Tint = ColorHelper.HexToColor("#FFFFFF")
        };

        /// <summary>
        /// 
        /// </summary>
        private void CreateCreatorAndDifficultyText() => CreatorAndDifficulty = new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBlack), "", 19)
        {
            Parent = this,
            Alignment = Alignment.MidLeft,
            Y =  Padding,
            Tint = ColorHelper.HexToColor("#FFFFFF")

        };

        /// <summary>
        /// 
        /// </summary>
        private void UpdateState() => ScheduleUpdate(() =>
        {
            Title.Text = "Drop - Dancer Of Saramandora";

            CreatorAndDifficulty.Text = "By: Xeo | [Diffname] - 27.26";


        });

    }
}
