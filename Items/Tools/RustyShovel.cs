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
            item.damage = 4;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 21;
            item.useAnimation = 21;
            item.pick = 3;    //pickaxe power
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = 1;
            item.rare = -1;
            item.UseSound = SoundID.Item7;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 5);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
