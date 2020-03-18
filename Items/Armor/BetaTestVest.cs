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
            item.width = 30;
            item.height = 20;
            item.value = 1000;
            item.rare = 13;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BetaToken", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}