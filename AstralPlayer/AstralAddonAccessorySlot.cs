using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstralAddon.Utilities;
using Terraria.ModLoader;

namespace AstralAddon.AstralPlayer
{
    public class AstralAddonAccessorySlot : ModAccessorySlot
    {
        public override bool IsEnabled()
        {
            AstralAddonPlayer modPlayer = Player.GetAstralPlayer();

            if (modPlayer.extraSlot)
                return true;
            else
                return false;
        }
    }
}
