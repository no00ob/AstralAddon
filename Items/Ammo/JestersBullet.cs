using AstralAddon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
    class JestersBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 4.0f;
            Item.value = 20;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<JestersBulletBullet>();//Mod.Find<ModProjectile>("JestersBulletBullet").Type;   //The projectile shoot when your weapon using this ammo
            Item.shootSpeed = 8f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(ItemID.MusketBall, 20);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.Register();
        }
    }
}