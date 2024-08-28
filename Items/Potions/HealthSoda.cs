using AstralAddon.AstralPlayer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Potions
{
    internal class HealthSoda : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Juggernaut Soda"); //[c/27CE21:Juggernaut Soda]
            //Tooltip.SetDefault("Permanently increases maximum life by 100\n'When you need to feel big and strong'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.width = 38;
            Item.height = 38;
            Item.value = 20000;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
        }
    }
}
