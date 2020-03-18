using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class WoodenPickaxe : ModItem
	{
		public override void SetDefaults()
		{
            item.damage = 3;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 19;
            item.useAnimation = 19;
            item.pick = 31;    //pickaxe power
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 5;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 12);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
