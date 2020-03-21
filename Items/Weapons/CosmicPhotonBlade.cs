using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class CosmicPhotonBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Photon Blade");
            Tooltip.SetDefault("'The final form'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 842;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 80000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmosBladeProjectile");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BladeOfCosmos", 1);
            recipe.AddIngredient(null, "UniversiteBar", 20);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
}
