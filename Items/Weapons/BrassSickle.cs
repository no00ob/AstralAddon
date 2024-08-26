using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class BrassSickle : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Seems familar some how...'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = 1400;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Sickle, 1);
            recipe.AddIngredient(null, "BrassBar", 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
