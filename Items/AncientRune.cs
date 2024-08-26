using AstralAddon.Utilities;
using AstralAddon.World.AncientParadise;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items
{
    internal class AncientRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ancient Rune"); //[c/27CE21:Juggernaut Soda]
            //Tooltip.SetDefault("Allows travel between worlds");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.width = 38;
            Item.height = 38;
            Item.value = Item.sellPrice(0);
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            //SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/soda"));

            if (!AstralUtils.IsAncientSubworldActive())
            {
                SubworldLibrary.SubworldSystem.Enter<AncientParadiseSubworld>();
            }
            else
            {
                SubworldLibrary.SubworldSystem.Exit();
            }
            
            return true;
        }
    }
}
