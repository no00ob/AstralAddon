using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class SteelBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.value = 10;
            Item.rare = ItemRarityID.LightRed;
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
