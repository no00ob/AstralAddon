using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class DioxideOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Stores little bit of dark energy'");  
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000;
            Item.rare = 7;
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
