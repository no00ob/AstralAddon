using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
	public class MandibleSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			//DisplayName.SetDefault("Mandible Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("'Whew! That is Sharp!'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.75f;
			Item.value = 1015;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AntlionClaw, 1);
			recipe.AddIngredient(ItemID.AntlionMandible, 10);
			recipe.AddRecipeGroup("EvilBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}