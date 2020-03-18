using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class AssaultRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is a nice lookin' weapon'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 58;
            item.height = 20;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 1000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.TheUndertaker, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.TheUndertaker, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
