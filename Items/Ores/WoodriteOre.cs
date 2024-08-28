using AstralAddon.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class WoodriteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Living Root");
            //Tooltip.SetDefault("'Feels organic'");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 3;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<WoodriteOreBlock>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
