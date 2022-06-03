using Quaver.Shared.Screens.Competitive.UI.RatingPanels.User;
using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Graphics;

namespace Quaver.Shared.Screens.Competitive.UI.RatingPanels.Map
{
    public class RatingPanelMap : RatingPanel
    {
        public RatingPanelMap() : base() => new RatingPanelMapContent()
        {
            Parent = this,
            Alignment = Alignment.MidLeft,
            X = Padding,
        };
    }
}
