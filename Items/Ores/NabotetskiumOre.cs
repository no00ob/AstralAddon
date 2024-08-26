using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class NabotetskiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
           // Tooltip.SetDefault("'DESC'");  
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000;
            Item.rare = ItemRarityID.Lime;
            Item.maxStack = 999;
        }
    }
}
