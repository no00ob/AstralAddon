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
			item.damage = 24;
			item.ranged = true;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0.2f;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<Projectiles.ElectricBolt>();
            item.shootSpeed = 10f;
            item.ammo = item.type; // The first item in an ammo class sets the AmmoID to it's type
        }
	}
}
