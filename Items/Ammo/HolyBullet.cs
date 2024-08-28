using AstralAddon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
    class HolyBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2.0f;
            Item.value = 16;
            Item.rare = 3;
            Item.shoot = ModContent.ProjectileType<HolyBulletBullet>();//Mod.Find<ModProjectile>("HolyBulletBullet").Type;   //The projectile shoot when your weapon using this ammo
            Item.shootSpeed = 10f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(200);
            recipe.AddIngredient(ItemID.MusketBall, 200);
            recipe.AddIngredient(ItemID.PixieDust, 3);
            recipe.AddIngredient(ItemID.UnicornHorn, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
