using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Tiles;

namespace AstralAddon.Items.Ores
{
    public class FutilititeOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Futilitite Ore");
            //Tooltip.SetDefault("'Whew, nice save!'");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = 750;
            Item.rare = ItemRarityID.LightRed;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<FutilititeOreBlock>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ModContent.ItemType<FutilititeBar>());
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
            
            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FutilititeDust>());
            recipe.AddIngredient(ItemID.PixieDust, 2);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}
