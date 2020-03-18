using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class NobotetskiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
           // Tooltip.SetDefault("'DESC'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 500;
            item.rare = 7;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NobotetskiumOre", 3);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}