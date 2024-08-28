using AstralAddon.Items.Ores;
using AstralAddon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class CosmicPhotonBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Photon Blade");
            //Tooltip.SetDefault("'The final form'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 842;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = 80000;
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CosmosBladeProjectile>();//Mod.Find<ModProjectile>("CosmosBladeProjectile").Type;
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(null, "BladeOfCosmos", 1);
            //recipe.AddIngredient(ModContent.ItemType<CosmiteBar>(), 20);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
