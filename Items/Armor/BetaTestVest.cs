using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BetaTestVest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Vanity Item"
                + "\n'You practisipated in the beta'");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = 1000;
            Item.rare = 13;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "BetaToken", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}