using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Salt : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Salt");
			Tooltip.SetDefault("'Sea salt always had the best vision.'");
		}

		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(ItemID.Bottle);
			recipe.AddIngredient(ModContent.ItemType<SodiumBar>());
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
