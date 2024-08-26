using AstralAddon.Dusts;
using AstralAddon.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AstralAddon.Tiles
{
    public class CharredSoilBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = ModContent.DustType<CharredSoilDust>();
            //ItemDrop = ModContent.ItemType<CharredSoil>();
            AddMapEntry(new Color(67, 66, 61));
        }
    }
}