using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class RustyShovel : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Come 'ere cupcake'");  
        }

        public override void SetDefaults()
		{
            Item.damage = 4;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.pick = 3;    //pickaxe power
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 1;
            Item.rare = -1;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddRecipeGroup("Wood", 3);
			recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 5);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.Register();
        }
	}
}
