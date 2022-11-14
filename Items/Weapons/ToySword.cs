using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThumodRe.Items.Weapons
{
	public class ToySword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Toy Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'A blade filled with dreams'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.25f;
			Item.value = 800;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(ItemID.LavaBucket);
			recipe.AddIngredient(ItemID.LavaBucket);
			recipe.AddIngredient(ModContent.ItemType<Plastic>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}