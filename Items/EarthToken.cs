using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
    internal class EarthToken : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Soda"); //[c/27CE21:Juggernaut Soda]
            Tooltip.SetDefault("Teleports you back into Earth from Ancient Paradise");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.width = 38;
            item.height = 38;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Red;
            CustomRarity = 13;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.EatingUsing;
        }

        public override bool CanUseItem(Player player)
        {
            return SubworldLibrary.Subworld.IsActive<AncientParadiseSubworld>();
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/soda"));

            SubworldLibrary.Subworld.Exit();
            
            return true;
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = BaseColor.PureGreen;
                }
            }
        }
    }
}
