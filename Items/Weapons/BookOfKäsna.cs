using Terraria.ID;
using Terraria.ModLoader;

namespace Thumod.Items.Weapons
{
    public class BookOfKäsna: ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A book made out of sponge... Weird.");
        }
        public override void SetDefaults()
        {
            item.damage = 75;
            item.magic = true;
            item.width = 30;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 5;
            item.UseSound = SoundID.Item8;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("BallOfKäsna");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "KäsnatiteBar", 14);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
