using Terraria.ModLoader;

namespace AstralVoyage.Items
{
    public class BetaToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be made into beta exclusive items.");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 100;
            item.rare = 12;
            item.maxStack = 1;
        }
    }
}
