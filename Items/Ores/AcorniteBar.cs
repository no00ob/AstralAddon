using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class AcorniteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Packed food for squirrels'");  
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 5;
            item.rare = 1;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}