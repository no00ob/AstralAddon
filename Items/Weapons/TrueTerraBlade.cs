using AstralVoyage.Items.Ores;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class TrueTerraBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'This is the final upgrade'");  
        }

        public override void SetDefaults()
        {
            item.damage = 195;
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
            recipe.AddIngredient(ModContent.ItemType<CosmiteBar>(), 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
