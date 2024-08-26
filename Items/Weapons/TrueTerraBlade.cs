using AstralAddon.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class TrueTerraBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'This is the final upgrade'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 195;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 56;
            Item.height = 86;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = 100000;
            Item.rare = 11;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("TrueTerraBladeSickle").Type;
            Item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            //recipe.AddIngredient(ModContent.ItemType<CosmiteBar>(), 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
