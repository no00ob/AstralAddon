using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class BrassBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Mix of two metals'");  
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 100;
            item.rare = 1;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ZincBar", 3);
            recipe.AddIngredient(ItemID.CopperBar, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}
