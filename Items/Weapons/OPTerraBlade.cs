using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class OPTerraBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is the  cheaty final upgrade'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 100000;
            item.melee = true;
            item.width = 56;
            item.height = 86;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 100000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TrueTerraBladeSickle");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(null, "UniversiteBar", 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
