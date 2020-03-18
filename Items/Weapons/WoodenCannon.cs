using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class WoodenCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a Cannon made out of a wood'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.ranged = true;
            item.width = 48;
            item.height = 34;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 7;
            item.value = 3600;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Rocket;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(null, "WoodenLauncher");
            recipe.AddIngredient(null, "WoodriteBar", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
