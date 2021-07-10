using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
    public class BrassHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Seems familar some how...'");  
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 24;
            item.useAnimation = 24;
            item.hammer = 44;   //hammer power
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 400;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassBar", 8);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
