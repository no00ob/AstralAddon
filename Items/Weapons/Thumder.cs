using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThumodRe.Items.Weapons
{
	public class Thumder : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thumder"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'The swordiest sword'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 1636;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.25f;
			Item.value = Item.sellPrice(06, 00, 00, 00);
			Item.rare = ItemRarityID.Expert;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}