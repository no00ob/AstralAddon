using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class EbonstoneShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Might be corrupted'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 7;
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
            recipe.AddIngredient(ItemID.EbonstoneBlock, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
