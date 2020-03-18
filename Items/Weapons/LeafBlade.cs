using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class LeafBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Blade, forged with the fury of Leafeaus'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.melee = true;
            item.width = 44;
            item.height = 68;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 30000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LeafBladeProjectile");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BladeOfPlants", 1);
            recipe.AddIngredient(ItemID.JungleRose, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddIngredient(ItemID.JungleSpores, 30);
            recipe.AddIngredient(ItemID.Stinger, 25);
            recipe.AddIngredient(ItemID.Vine, 8);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
