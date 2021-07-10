using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class HeroSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The Hero Sword'");  
        }

        public override void SetDefaults()
        {
            item.damage = 67;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 80000;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HeroSwordProjectile");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
