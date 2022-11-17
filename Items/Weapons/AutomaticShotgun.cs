using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class AutomaticShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("fully auto, 18% Change not to consume ammo");  
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 19;
            Item.useTime = 44;
            Item.useAnimation = 44;
            Item.useStyle = 5;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 6;
            Item.value = 90000;
            Item.rare = 4;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 10; //idk why but all the guns in the vanilla source have this
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Shotgun, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.Anvils);
        }
        // What if I wanted this gun to have a 38% chance not to consume ammo?
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() > .18f;
        }

        // What if I wanted it to shoot like a shotgun?
        // Shotgun style: Multiple Projectiles, Random spread 
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}

