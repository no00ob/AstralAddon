using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class ElementalBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You shall realise the elemental power'");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 101;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ElementalSickle");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TheLostSword", 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
