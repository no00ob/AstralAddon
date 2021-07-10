using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    class Suomi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KP31");
            Tooltip.SetDefault("70% Chance not to consume ammo\n'True Might of a small country'");  
        }

        public override void SetDefaults()
        {
            item.damage = 235;
            item.ranged = true;
            item.width = 64;
            item.height = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 42000;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }
    }
}
