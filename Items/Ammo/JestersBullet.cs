using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
    class JestersBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Works same way as Jesters arrows'");  
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            Item.knockBack = 4.0f;
            Item.value = 20;
            Item.rare = 1;
            Item.shoot = Mod.Find<ModProjectile>("JestersBulletBullet").Type;   //The projectile shoot when your weapon using this ammo
            Item.shootSpeed = 8f;                  //The speed of the projectile
            Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
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