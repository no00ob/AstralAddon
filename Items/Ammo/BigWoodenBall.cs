using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
	public class BigWoodenBall : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a big wooden ball, for your big wooden guns'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
		{
			item.damage = 7;
			item.ranged = true;
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 2.2f;
			item.value = 35;
			item.rare = 1;
			item.shoot = mod.ProjectileType("BigWoodenBallBullet");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 15f;                  //The speed of the projectile
			item.ammo = AmmoID.Rocket;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodriteBar", 3);
            recipe.AddIngredient(null, "WoodenBall", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
	}
}
