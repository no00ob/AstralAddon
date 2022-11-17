using Terraria;
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
            Item.width = 20;
            Item.height = 30;
            Item.value = 50;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.ManaPotion);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}
