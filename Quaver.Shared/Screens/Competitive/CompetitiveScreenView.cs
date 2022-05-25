﻿using Microsoft.Xna.Framework;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics.Menu.Border;
using Quaver.Shared.Helpers;
using Quaver.Shared.Screens.Competitive.UI.Borders.Footer;
using Quaver.Shared.Screens.Competitive.UI.RankDivisions;
using Quaver.Shared.Screens.Competitive.UI.RatingPanels.User;
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

        private MenuBorder Header { get; set; }

        private MenuBorder Footer { get; set; }

        public CompetitiveScreenView(QuaverScreen screen) : base(screen)
        {
            CreateBackground();
            CreateHeader();
            CreateFooter();

            new RatingPanelStatsContainer(1500, 100, 95, RankDivision.S)
            {
                Parent = Container,
                Alignment = Alignment.MidCenter
            };
        }

        public void CreateBackground() => Background = new BackgroundImage(UserInterface.Triangles, 0, false)
        {
            Parent = Container
        };

        public void CreateHeader() => Header = new MenuHeaderMain() { Parent = Container };

        public void CreateFooter() => Footer = new CompetitiveMenuFooter(CompetitiveScreen)
            { Parent = Container, Alignment = Alignment.BotLeft };

        public override void Update(GameTime gameTime) => Container?.Update(gameTime);

        public override void Draw(GameTime gameTime)
        {
            GameBase.Game.GraphicsDevice.Clear(ColorHelper.HexToColor("#2F2F2F"));
            Container?.Draw(gameTime);
        }

        public override void Destroy() => Container?.Destroy();
    }
}