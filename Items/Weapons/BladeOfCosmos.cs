using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class BladeOfCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You shall use the elemental god powers'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 505;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmosBladeProjectile");
            item.shootSpeed = 7f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ElementalBlade", 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
