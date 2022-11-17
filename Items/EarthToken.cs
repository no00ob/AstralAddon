using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.width = 38;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Red;
            CustomRarity = 13;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.EatFood;
        }

        public override bool CanUseItem(Player player)
        {
            return SubworldLibrary.Subworld.IsActive<AncientParadiseSubworld>();
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/soda"));

            SubworldLibrary.Subworld.Exit();
            
            return true;
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.OverrideColor = BaseColor.PureGreen;
                }
            }
        }
    }
}
