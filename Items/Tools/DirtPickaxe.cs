using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class DirtPickaxe : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Yep, a Pickaxe made out of a dirt'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
		{
            item.damage = 2;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 19;
            item.useAnimation = 19;
            item.pick = 29;    //pickaxe power
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 12);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
