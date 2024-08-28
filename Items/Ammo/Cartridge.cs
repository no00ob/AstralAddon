using AstralAddon.Items.Ores;
using AstralAddon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ammo
{
	public class Cartridge : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.knockBack = 1.8f;
			Item.value = 100;
			Item.rare = 1;
			Item.shoot = ModContent.ProjectileType<MagazineBullet>();
			Item.shootSpeed = 10f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient<ShinyIronBar>(4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = CreateRecipe(20);
            recipe.AddIngredient<ShinyLeadBar>(4);
            recipe.AddIngredient(ItemID.MusketBall, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
	}
}
