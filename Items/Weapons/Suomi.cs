using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    class Suomi : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KP31");
            Tooltip.SetDefault("70% Chance not to consume ammo\n'Embodiment of Sisu'");  
        }

        public override void SetDefaults()
        {
            item.damage = 495;
            item.ranged = true;
            item.width = 70;
            item.height = 26;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTurn = false;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8;
            item.value = 42000;
            item.rare = ItemRarityID.Red;
            CustomRarity = 14;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Bullet;
            item.crit = 46;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 5);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .70f;
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = BaseColor.DarkBlue;
                }
            }
        }
    }
}
