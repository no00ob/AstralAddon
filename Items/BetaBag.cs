using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using AstralVoyage.Items.Armor;

namespace AstralVoyage.Items
{
    public class BetaToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beta Bag");
            Tooltip.SetDefault("<right> to open\nContains beta exclusive items");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 0;
            item.rare = ItemRarityID.Expert;
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType<BetaTestVest>());
        }
    }
}
