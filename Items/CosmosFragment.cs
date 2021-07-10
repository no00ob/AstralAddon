using AstralVoyage.Items.Ores;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class CosmosFragment : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 8;
			item.rare = 3;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 1);
            recipe.AddIngredient(ModContent.ItemType<CosmiteBar>());
            recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
