using AstralVoyage.Items.Ammo;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class Wunderwaffe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses Power Cells as ammo\nShoots a bolt of electricity that splits upon contact\nElectric bolts inflict electrified debuff\n'Good old fashioned lightning gun, sweet!'");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 58;
            Item.height = 24;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5;
            Item.value = Item.sellPrice(0, 3, 12, 40);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item109;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBolt>();
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<PowerCell>();
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            // Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
            mult *= player.bulletDamage;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
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
    }
}
