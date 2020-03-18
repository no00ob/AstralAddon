using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
	public class DirtHammer : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Yep, a Hammer made out of a dirt'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
		{
            item.damage = 1;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 36;
            item.useAnimation = 36;
            item.hammer = 23;   //hammer power
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 8);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
