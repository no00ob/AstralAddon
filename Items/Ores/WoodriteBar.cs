using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
	public class WoodriteBar : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Root Bar");
            Tooltip.SetDefault("'Feels organic'");  
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 10;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WoodriteOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
