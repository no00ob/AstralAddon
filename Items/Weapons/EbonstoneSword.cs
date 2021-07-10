using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
	public class EbonstoneSword : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Might be corrupted'");  
        }

        public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 32;
			item.height = 32;
            item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 5;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
