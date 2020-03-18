using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class WoodenRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a rifle made out of a wood'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 60;
            item.height = 20;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 4;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 16);
            recipe.AddIngredient(ItemID.Acorn, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
