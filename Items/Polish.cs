using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
	public class Polish : ModItem
	{
        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 2000;
			Item.rare = 1;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.BeeWax, 2);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}
