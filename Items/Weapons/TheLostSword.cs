using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class TheLostSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Brother of the Hero Sword'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 60;
            Item.height = 68;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 80000;
            Item.rare = 7;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = Mod.Find<ModProjectile>("TheLostSwordProjectile").Type;
            Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "LeafBlade", 1);
            recipe.AddIngredient(ItemID.JungleRose, 2);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
