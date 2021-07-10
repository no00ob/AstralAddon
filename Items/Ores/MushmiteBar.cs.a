using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class MushmiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Shroomites little brother'");  
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 10;
            item.rare = 0;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GlowingMushroom, 10);
            recipe.AddIngredient(ItemID.Obsidian, 1);
            recipe.AddIngredient(null, "WoodriteBar", 1);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
