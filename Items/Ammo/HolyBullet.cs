using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
    class HolyBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Works same way as Holy arrows'");  
        }
        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            Item.knockBack = 2.0f;
            Item.value = 16;
            Item.rare = 3;
            Item.shoot = Mod.Find<ModProjectile>("HolyBulletBullet").Type;   //The projectile shoot when your weapon using this ammo
            Item.shootSpeed = 10f;                  //The speed of the projectile
            Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
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
