using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Sapling : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 8;
			item.rare = 1;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddIngredient(null, "AcorniteBar");
            recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
