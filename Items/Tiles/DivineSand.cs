using Terraria.ModLoader;
using Terraria.ID;
using AstralVoyage.Tiles;
using Terraria;

namespace AstralVoyage.Items.Tiles
{
    public class DivineSand : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'White as snow'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 0, 3);
            item.createTile = ModContent.TileType<DivineSandBlock>();
            //item.ammo = AmmoID.Sand; Using this Sand in the Sandgun would require PickAmmo code and changes to ExampleSandProjectile or a new ModProjectile.
        }
    }
}