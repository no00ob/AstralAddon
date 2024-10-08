using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Sapling : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 8;
			Item.rare = 1;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddIngredient(null, "AcorniteBar");
            recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
