using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class SandstoneShortsword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 3;
            item.knockBack = 3;
            item.value = 5;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sandstone, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
