using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class IceHammer : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Don't let it melt!'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
		{
            item.damage = 4;
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
			recipe.AddIngredient(ItemID.IceBlock, 10);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
