using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class Flaren : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("40% Change not to consume ammo");  
        }

        public override void SetDefaults()
        {
            item.damage = 37;
            item.ranged = true;
            item.width = 40;
            item.height = 22;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 6;
            item.value = 60000;
            item.rare = 4;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Flare;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlareGun, 1);
            recipe.AddIngredient(ItemID.Shotgun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        // What if I wanted this gun to have a 38% chance not to consume ammo?
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .40f;
		}

        // What if I wanted it to shoot like a shotgun?
        // Shotgun style: Multiple Projectiles, Random spread 
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
