using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class CosmiteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Pulsing with power'");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(15, 8));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = 3600;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 999;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.PaleVioletRed.ToVector3() * 0.55f * Main.essScale);
        }
    }
}
