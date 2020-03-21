using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class BunnyBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rabbit's Rage");
            Tooltip.SetDefault("'This is an ancient sword inbued with wraith of the rabbits'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 202;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BunnyBladeProjectile");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
