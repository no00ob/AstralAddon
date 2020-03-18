using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class WoodriteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Feels organic'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 3;
            item.rare = 0;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("WoodriteOreBlock");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
