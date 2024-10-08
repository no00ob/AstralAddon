using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
	public class ShinyIronBar : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polished Iron Bar");
            Tooltip.SetDefault("'Looks Clean'");  
        }
        public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = 3500;
			Item.rare = 0;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Rag>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Polish>(), 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
