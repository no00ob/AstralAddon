using Terraria;
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
            Item.width = 30;
            Item.height = 24;
            Item.value = 500;
            Item.rare = 7;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdBrick, 3);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();
        }
    }
}