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
			item.width = 30;
			item.height = 24;
			item.value = 3500;
			item.rare = 0;
            item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Rag>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Polish>(), 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
