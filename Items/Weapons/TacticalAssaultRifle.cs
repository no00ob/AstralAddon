using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class TacticalAssaultRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("18% Chance not to consume ammo\n3 round burst");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 62;
            Item.height = 24;
            Item.useAnimation = 12;
            Item.useTime = 4;
            Item.reuseDelay = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5;
            Item.value = 1000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item31;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0.5f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.) 
            // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
            return !(player.itemAnimation < Item.useAnimation - 2);
        }
    }
}
