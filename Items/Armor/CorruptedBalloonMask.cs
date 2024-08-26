using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CorruptedBalloonMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Corrupted Balloon Mask");
            //Tooltip.SetDefault("'I wonder how it got corrupted.'");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 22;
            Item.value = Item.sellPrice(00, 00, 75, 00);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 0;
			Item.vanity = true;
        }
    }
}