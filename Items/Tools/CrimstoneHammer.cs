using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class CrimstoneHammer : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Seems red'");  
        }
        public override void SetDefaults()
		{
            item.damage = 7;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 37;
            item.useAnimation = 37;
            item.hammer = 32;   //hammer power
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 5;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimstoneBlock, 10);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
