using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class BrassSickle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Seems familar some how...'");  
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = 1400;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sickle, 1);
            recipe.AddIngredient(null, "BrassBar", 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
