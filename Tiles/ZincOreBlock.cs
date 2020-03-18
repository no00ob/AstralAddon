using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Tiles
{
	public class ZincOreBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			drop = mod.ItemType("ZincOre");
			AddMapEntry(new Color(252, 232, 232));
		}
	}
}