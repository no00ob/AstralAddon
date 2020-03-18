using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class WoodenPistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a Pistol made out of a wood'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 30;
            item.height = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
