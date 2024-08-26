using AstralAddon.Dusts;
using AstralAddon.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Tiles
{
    public class CharredStoneBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = ModContent.DustType<CharredStoneDust>();
            //ItemDrop = ModContent.ItemType<CharredStone>();
            AddMapEntry(new Color(48, 38, 44));
            HitSound = SoundID.Tink;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}