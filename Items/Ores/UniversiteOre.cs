using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class UniversiteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Has little bit of the power of universum'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 1000;
            item.rare = 12;
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
