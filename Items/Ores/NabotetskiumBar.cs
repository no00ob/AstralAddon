using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class NabotetskiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
           // Tooltip.SetDefault("'DESC'");  
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.value = 500;
            Item.rare = ItemRarityID.Lime;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NabotetskiumOre>(), 3);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}