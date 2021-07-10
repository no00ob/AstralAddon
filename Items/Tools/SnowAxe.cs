using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class SnowAxe : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Hrrr...'");  
        }
        public override void SetDefaults()
		{
            item.damage = 2;
            item.melee = true;
            item.width = 32;
            item.height = 28;
            item.useTime = 29;
            item.useAnimation = 29;
            item.axe = 6;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 9);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
