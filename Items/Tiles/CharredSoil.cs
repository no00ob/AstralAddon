using Terraria.ModLoader;
using Terraria.ID;
using AstralVoyage.Tiles;
using Terraria;

namespace AstralVoyage.Items.Tiles
{
    public class CharredSoil : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 2);
            Item.createTile = ModContent.TileType<CharredSoilBlock>();
            //item.ammo = AmmoID.Sand; Using this Sand in the Sandgun would require PickAmmo code and changes to ExampleSandProjectile or a new ModProjectile.
        }
    }
}