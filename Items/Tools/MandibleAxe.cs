using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Tools
{
    public class MandibleAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An axe made out of antlion mandibles.");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 46;
            Item.height = 44;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.axe = 15;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.HardenedSand, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
