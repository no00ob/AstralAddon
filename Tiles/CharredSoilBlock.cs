using AstralVoyage.Dusts;
using AstralVoyage.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Tiles
{
    public class CharredSoilBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = ModContent.DustType<CharredSoilDust>();
            drop = ModContent.ItemType<CharredSoil>();
            AddMapEntry(new Color(67, 66, 61));
            //SetModTree(new Trees.ExampleTree());
        }
    }
}