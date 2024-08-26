using Terraria.DataStructures;
using AstralAddon.Projectiles;
using AstralAddon.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items;
using Microsoft.Xna.Framework;

namespace AstralAddon.Items.Weapons
{
	public class BlessedSaltShaker : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("'Purify the unpure!'");
		}

		public override void SetDefaults() {
			Item.damage = 65;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 12;
			Item.width = 20;
			Item.height = 26;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item46;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Salty>();
			Item.shootSpeed = 8f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
																												// float scale = 1f - (Main.rand.NextFloat() * .3f);
																												// perturbedSpeed = perturbedSpeed * scale; 
				//Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SaltShaker>());
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}