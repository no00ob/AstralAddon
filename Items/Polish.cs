using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Polish : ModItem
	{
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 2000;
			item.rare = 1;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeWax, 2);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}
