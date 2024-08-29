using AstralAddon.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class SpongeBook: ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("A book made out of sponge... Weird.");
        }
        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 28;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.AmberBolt; //Mod.Find<ModProjectile>("SpongeBall").Type
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(null, "KäsnatiteBar", 14);
            recipe.AddIngredient<Plastic>(5);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
