using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Materials
{
    public class Rag : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = 0;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
