using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using AstralAddon.Items.Armor;

namespace AstralAddon.Items
{
    public class BetaToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Beta Bag");
            //Tooltip.SetDefault("<right> to open\nContains beta exclusive items");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = 0;
            Item.rare = ItemRarityID.Expert;
            Item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            //player.QuickSpawnItem(ModContent.ItemType<BetaTestVest>());
        }
    }
}
