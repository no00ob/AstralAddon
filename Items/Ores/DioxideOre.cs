using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class DioxideOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Stores little bit of dark energy'");  
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 1000;
            item.rare = 7;
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
