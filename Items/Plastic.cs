using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
    public class Plastic : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 1;
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 1);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
