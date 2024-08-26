using AstralAddon.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items
{
	public class CosmosFragment : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 8;
			Item.rare = 3;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 1);
            //recipe.AddIngredient(ModContent.ItemType<CosmiteBar>());
            recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
