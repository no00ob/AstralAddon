using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class TheLostSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Brother of the Hero Sword'");  
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.melee = true;
            item.width = 60;
            item.height = 68;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 80000;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("TheLostSwordProjectile");
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LeafBlade", 1);
            recipe.AddIngredient(ItemID.JungleRose, 2);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
