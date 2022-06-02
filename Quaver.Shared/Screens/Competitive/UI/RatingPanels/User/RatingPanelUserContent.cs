using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Server.Client;
using Quaver.Server.Common.Enums;
using Quaver.Shared.Assets;
using Quaver.Shared.Graphics;
using Quaver.Shared.Online;
using Steamworks;
using Quaver.Server.Client.Structures;
using Quaver.Shared.Helpers;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.Sprites.Text;
using Wobble.Managers;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.User
{
    public class RatingPanelUserContent : Sprite
    {
        private const int InBetweenPadding = 10;
        private Sprite Avatar { get; set; }
        private Sprite Flag { get; set; }
        private SpriteTextPlus Username { get; set; }
        private Server.Client.Structures.User User { get; set; }

        public RatingPanelUserContent()
        {
            Size = new ScalableVector2(800, 85);
            Alpha = 0f;

            CreateAvatar();
            CreateFlag();
            CreateUsername();

            UpdateState();
        }

        /// <summary>
        /// </summary>
        private void CreateAvatar()
        {
            Avatar = new Sprite()
            {
                Parent = this,
                UsePreviousSpriteBatchOptions = true,
                Alignment = Alignment.MidLeft,
                Size = new ScalableVector2(60, 60)
            };

            Avatar.AddBorder(Colors.GetUserChatColor(User?.OnlineUser?.UserGroups ?? UserGroups.Normal), 2);
        }

        /// <summary>
        /// </summary>
        private void CreateFlag()
        {
            Flag = new Sprite()
            {
                Parent = this,
                UsePreviousSpriteBatchOptions = true,
                Alignment = Alignment.MidLeft,
                Size = new ScalableVector2(29, 29),
                X = Avatar.X + Avatar.Width + InBetweenPadding,
            };
        }

        /// <summary>
        /// </summary>
        private void CreateUsername()
        {
            Username = new SpriteTextPlus(FontManager.GetWobbleFont(Fonts.LatoBlack), "Ababababababa", 28)
            {
                Parent = this,
                Alignment = Alignment.MidLeft,
                X = Flag.X + Flag.Width + InBetweenPadding,
                Tint = ColorHelper.HexToColor("#FFFFFF")
            };
        }

        /// <summary>
        /// </summary>
        private void UpdateState() => ScheduleUpdate(() =>
        {
            Avatar.Image = UserInterface.UnknownAvatar;

            if (User != null && SteamManager.UserAvatars != null &&
                SteamManager.UserAvatars.ContainsKey((ulong)User.OnlineUser.SteamId))
                Avatar.Image = SteamManager.UserAvatars[(ulong)User.OnlineUser.SteamId];

            Avatar.Border.Tint = Colors.GetUserChatColor(User?.OnlineUser?.UserGroups ?? UserGroups.Normal);

            Flag.Image = User != null ? Flags.Get(User?.OnlineUser?.CountryFlag) : Flags.Get("XX");

            Username.Text = User?.OnlineUser?.Username ?? "Player";
            Username.Tint = Avatar.Border.Tint;
            Username.TruncateWithEllipsis((int)Width - 30);
        });
    }
}