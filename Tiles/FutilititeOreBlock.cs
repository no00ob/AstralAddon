using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ThumodRe.Items;

namespace ThumodRe.Tiles
{
	public class FutilititeOreBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			ItemDrop = ModContent.ItemType<FutilititeDust>();
			AddMapEntry(new Color(51, 30, 96));
		}
	}
}