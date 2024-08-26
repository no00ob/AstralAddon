using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items
{
    public class Plastic : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Plastic Sheet");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = 1;
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.SiltBlock, 1);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
