using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
	public class WoodriteBar : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Feels organic'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 10;
			item.rare = 0;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WoodriteOre", 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
