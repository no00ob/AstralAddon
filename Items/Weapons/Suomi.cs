using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class Suomi : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 495;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 70;
            Item.height = 26;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTurn = false;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 8;
            Item.value = 42000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
            Item.shootSpeed = 13f;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 46;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 5);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .70f;
        }
    }
}
