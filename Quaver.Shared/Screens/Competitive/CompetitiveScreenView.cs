using Microsoft.Xna.Framework;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics.Menu.Border;
using Quaver.Shared.Helpers;
using Wobble;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.Sprites.Text;
using Wobble.Graphics.UI;
using Wobble.Managers;
using Wobble.Screens;

namespace Quaver.Shared.Screens.Competitive
{
    public class CompetitiveScreenView : ScreenView
    {
        private CompetitiveScreen CompetitiveScreen => (CompetitiveScreen)Screen;

        /// <summary>
        ///     The background image for the screen
        /// </summary>
        private BackgroundImage Background { get; set; }

        public CompetitiveScreenView(QuaverScreen screen) : base(screen)
        {
            CreateBackground();
            new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBold), "Competitive Screen", 24)
            {
                Parent = Container,
                Alignment = Alignment.MidCenter,
            };
        }

        public void CreateBackground() => Background = new BackgroundImage(UserInterface.Triangles, 0, false)
        {
            Parent = Container
        };

        public override void Update(GameTime gameTime) => Container?.Update(gameTime);

        public override void Draw(GameTime gameTime)
        {
            GameBase.Game.GraphicsDevice.Clear(ColorHelper.HexToColor("#2F2F2F"));
            Container?.Draw(gameTime);
        }

        public override void Destroy() => Container?.Destroy();
    }
}