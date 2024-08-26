using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items.Ores;

namespace AstralAddon.Items.Ores
{
	public class FutilititeBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Futilitite Bar"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("'I guess it wasn't futile afterall!'");  //The (English) text shown below your weapon's name
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
            Item.value = 250;
			Item.rare = ItemRarityID.LightRed;
            Item.maxStack = 99;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FutilititeOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
