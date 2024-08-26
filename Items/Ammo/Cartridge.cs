using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
	public class Cartridge : ModItem
	{
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Finely engineered'");  
        }
        public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1.8f;
			Item.value = 100;
			Item.rare = 1;
			Item.shoot = Mod.Find<ModProjectile>("MagazineBullet").Type;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 10f;                  //The speed of the projectile
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = CreateRecipe(20);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
	}
}
