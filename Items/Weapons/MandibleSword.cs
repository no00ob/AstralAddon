using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
	public class MandibleSword : ModItem
	{
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
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.AntlionClaw, 1);
            recipe2.AddIngredient(ItemID.AntlionMandible, 10);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
	}
}