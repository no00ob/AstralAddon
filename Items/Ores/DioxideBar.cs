using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class DioxideBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Stores dark energy with it'");  
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
            recipe.AddIngredient(ItemID.LihzahrdBrick, 3);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}