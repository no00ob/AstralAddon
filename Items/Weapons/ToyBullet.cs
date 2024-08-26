using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items;

namespace AstralAddon.Items.Weapons
{
	public class ToyBullet : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("'It may be a toy, but it still hurts.'");
		}

		public override void SetDefaults() {
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.ToyBullet>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		public override void OnConsumeAmmo(Item ammo, Player player) {
			if (Main.rand.NextBool(5)) {
				player.AddBuff(BuffID.Wrath, 300);
			}
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(ItemID.Gel, 2);
			//recipe.AddIngredient(ModContent.ItemType<Plastic>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
