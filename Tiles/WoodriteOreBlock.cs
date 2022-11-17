using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Tiles
{
	public class WoodriteOreBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			ItemDrop = Mod.Find<ModItem>("WoodriteOre").Type;
			AddMapEntry(new Color(90, 25, 5));
		}
	}
}