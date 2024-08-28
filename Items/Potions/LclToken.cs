using AstralAddon.World.AncientParadise;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Potions
{
    internal class LclToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("LCL Soda"); //[c/27CE21:Juggernaut Soda]
            //Tooltip.SetDefault("Teleports you into the Ancient Paradise");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.width = 38;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.EatFood;
        }
    }
}
