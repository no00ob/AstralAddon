using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
    class JestersBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Works same way as Jesters arrows'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 4.0f;
            item.value = 20;
            item.rare = 1;
            item.shoot = mod.ProjectileType("JestersBulletBullet");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 8f;                  //The speed of the projectile
            item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 20);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
    }
}