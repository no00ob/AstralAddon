using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class CosmiteOre : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Pulsing with power'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(15, 8));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 3600;
            item.rare = ItemRarityID.Red;
            CustomRarity = 13;
            item.maxStack = 999;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.PaleVioletRed.ToVector3() * 0.55f * Main.essScale);
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
