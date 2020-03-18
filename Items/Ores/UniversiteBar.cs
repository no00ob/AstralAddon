using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class UniversiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Has the power of entire universum'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 10000;
            item.rare = 12;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "UniversiteOre", 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
