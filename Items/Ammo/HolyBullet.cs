using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
    class HolyBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Works same way as Holy arrows'");  
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 2.0f;
            item.value = 16;
            item.rare = 3;
            item.shoot = mod.ProjectileType("HolyBulletBullet");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 10f;                  //The speed of the projectile
            item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 200);
            recipe.AddIngredient(ItemID.PixieDust, 3);
            recipe.AddIngredient(ItemID.UnicornHorn, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 200);
            recipe.AddRecipe();
        }
    }
}
