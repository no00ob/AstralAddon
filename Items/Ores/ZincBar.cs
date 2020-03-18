using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class ZincBar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 100;
            item.rare = 0;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ZincOre", 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
