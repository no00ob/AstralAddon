using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SubworldLibrary;
using AstralAddon.Sounds;
using AstralAddon.Utilities;
using AstralAddon.World.AncientParadise;
using CalamityMod.CalPlayer;
using CalamityMod;

namespace AstralAddon.Items
{
    public class AncientRune : ModItem
    {
        public override void SetDefaults()
        {
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.width = 38;
            Item.height = 38;
            Item.value = Item.sellPrice(0);
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            Item.UseSound = AstralAddonSounds.AncientRune;
        }

        public override bool CanUseItem(Player player)
        {
            return AstralUtils.IsAncientSubworldActive() || !SubworldSystem.AnyActive();
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            //SoundEngine.PlaySound(AstralAddonSounds.AncientRune, player.position);

            if (player.itemAnimation > 0 && (AstralUtils.IsAncientSubworldActive() || !SubworldSystem.AnyActive()) && player.itemTime == 0)
            {
                player.itemTime = Item.useTime;

                if (!AstralUtils.IsAncientSubworldActive())
                {
                    SubworldSystem.Enter<AncientParadiseSubworld>();
                }
                else
                {
                    SubworldSystem.Exit();
                }
            }  
            return true;
        }
    }
}
