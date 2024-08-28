using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class BladeOfCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'You shall use the godly elemental powers'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 505;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 7;
            Item.value = 10000;
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.TerraBlade2;
            Item.shootSpeed = 7f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
