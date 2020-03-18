using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
	public class Stick : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a stick, still dangerous'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
		{
			item.damage = 6;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 0;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
