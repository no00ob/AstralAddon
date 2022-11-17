using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ammo
{
	public class PowerCell : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("High voltage electric charge\nUsed as ammo in some wonder weapons");
        }
        public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBolt>();
            Item.shootSpeed = 10f;
            Item.ammo = Item.type; // The first item in an ammo class sets the AmmoID to it's type
        }
	}
}
