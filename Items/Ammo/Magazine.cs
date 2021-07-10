using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
	public class Magazine : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a Magazine, for your guns'");  
        }
        public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 12;
			item.height = 13;
			item.maxStack = 99;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.8f;
			item.value = 100;
			item.rare = 1;
			item.shoot = mod.ProjectileType("MagazineBullet");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 10f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
	}
}
