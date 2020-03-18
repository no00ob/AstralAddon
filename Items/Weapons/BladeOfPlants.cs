using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class BladeOfPlants : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Better Blade Of Grass, forged with the fury of jungle'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BladeofGrass, 1);
            recipe.AddIngredient(ItemID.JungleRose, 1);
            recipe.AddIngredient(ItemID.JungleSpores, 22);
            recipe.AddIngredient(ItemID.Stinger, 22);
            recipe.AddIngredient(ItemID.Vine, 5);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
