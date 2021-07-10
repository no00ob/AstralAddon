using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class NabotetskiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
           // Tooltip.SetDefault("'DESC'");  
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 1000;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 999;
        }
    }
}
