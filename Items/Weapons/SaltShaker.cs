using Terraria.DataStructures;
using AstralAddon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items;
using Microsoft.Xna.Framework;
using AstralAddon.Items.Ores;

namespace AstralAddon.Items.Weapons
{
	public class SaltShaker : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("'Recommended for ghost hunting'");
		}

		public override void SetDefaults() {
			Item.damage = 21;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 20;
			Item.height = 26;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = Item.sellPrice(00, 00, 80, 00);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item39;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Salty>();
			Item.shootSpeed = 6f;
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

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ModContent.ItemType<Salt>(), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}