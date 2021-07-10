using AstralVoyage.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class WoodriteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Root");
            Tooltip.SetDefault("'Feels organic'");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 3;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<WoodriteOreBlock>();
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
