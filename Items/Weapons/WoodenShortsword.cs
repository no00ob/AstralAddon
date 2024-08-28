using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class WoodenShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'This is terrible idea'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 4;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = 3;
            Item.knockBack = 3;
            Item.value = 5;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
