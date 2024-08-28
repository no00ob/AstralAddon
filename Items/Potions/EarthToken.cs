using AstralAddon.World.AncientParadise;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Potions
{
    internal class EarthToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Earth Soda"); //[c/27CE21:Juggernaut Soda]
            //Tooltip.SetDefault("Teleports you back into Earth from Ancient Paradise");
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
