using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Rag : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000;
			item.rare = 0;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}
