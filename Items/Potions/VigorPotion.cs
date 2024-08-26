using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Potions
{
    class VigorPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Increses max health by 30 for 2 minutes");
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
            recipe.AddIngredient(ItemID.HealthPotion);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}
