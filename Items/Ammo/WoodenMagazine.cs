using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
	public class WoodenMagazine : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a Magazine, for your wooden guns'");  
        }
        public override void SetDefaults()
		{
			item.damage = 6;
			item.ranged = true;
			item.width = 12;
			item.height = 13;
			item.maxStack = 99;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 0;
			item.shoot = mod.ProjectileType("WoodenMagazineBullet");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 8f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(null, "WoodenBall", 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
	}
}
