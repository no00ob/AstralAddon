﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items
{
    internal class HealthSoda : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Juggernaut Soda"); //[c/27CE21:Juggernaut Soda]
            Tooltip.SetDefault("Permanently increases maximum life by 100\n'When you need to feel big and strong'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.width = 38;
            Item.height = 38;
            Item.value = 20000;
            Item.rare = ItemRarityID.Red;
            CustomRarity = 13;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.EatFood;
        }

        public override bool CanUseItem(Player player)
        {
            // Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
            // This check also prevents this item from being used before vanilla health upgrades are maxed out.
            return player.statLifeMax == 500 && player.GetModPlayer<AstralVoyagePlayer>().healthSoda < AstralVoyagePlayer.maxHealthSoda;
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            // Do not do this: player.statLifeMax += 2;
            player.statLifeMax2 += 100;
            player.statLife += 100;
            if (Main.myPlayer == player.whoAmI)
            {
                // This spawns the green numbers showing the heal value and informs other clients as well.
                player.HealEffect(100, true);
            }

            SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/soda"));

            // This is very important. This is what makes it permanent.
            player.GetModPlayer<AstralVoyagePlayer>().healthSoda += 1;
            // This handles the 2 achievements related to using any life increasing item or getting to exactly 500 hp and 200 mp.
            // Ignored since our item is only useable after this achievement is reached
            // AchievementsHelper.HandleSpecialEvent(player, 2);
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
