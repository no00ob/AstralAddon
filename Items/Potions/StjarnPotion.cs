using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Potions
{
    class StjarnPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increses max mana by 50");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.value = 50;
            item.rare = ItemRarityID.White;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaPotion);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
