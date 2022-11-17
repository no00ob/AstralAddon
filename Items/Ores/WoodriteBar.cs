using Terraria;
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
			Item.width = 30;
			Item.height = 24;
			Item.value = 10;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<WoodriteOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
