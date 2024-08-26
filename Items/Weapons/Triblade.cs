using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
	public class Triblade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			//DisplayName.SetDefault("Triblade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("'It's not a damn trident!!'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 247;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 18;
			Item.useAnimation = 18;
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
			recipe.AddIngredient(ModContent.ItemType<TrueEnchantedSword>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}