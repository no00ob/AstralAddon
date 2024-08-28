using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AstralAddon.AstralPlayer
{
    public partial class AstralAddonPlayer : ModPlayer
    {
        // Buffs
        public bool corrupted;
        public bool woodSplinters;

        // Pets
        public bool ekubo;

        // Consumables
        public bool healthSoda = false;

        // Biomes
        public bool ZoneAncient;

        // Accessories
        public bool modMinions0 = false;
        public bool modMinions1 = false;
        public bool modMinions2 = false;
        public bool damageReduction0 = false;
        public bool damageReduction1 = false;
        public bool damageReduction2 = false;
        public bool modSummonDamage0 = false;
        public bool modSummonDamage1 = false;

        /*public override void SaveData(TagCompound tag)
        {
            
        }

        public override void LoadData(TagCompound tag)
        {
            
        }*/

        public override void ResetEffects()
        {
            modMinions0 = false;
            modMinions1 = false;
            modMinions2 = false;
            damageReduction0 = false;
            damageReduction1 = false;
            damageReduction2 = false;
            modSummonDamage0 = false;
            modSummonDamage1 = false;

            // OLD
            corrupted = false;
            woodSplinters = false;
            ekubo = false;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            //packet.Write((byte)ExampleModMessageType.ExamplePlayerSyncPlayer);
            packet.Write((byte)Player.whoAmI);
            packet.Write(healthSoda);
            packet.Send(toWho, fromWho);
        }

        public override void UpdateDead()
        {
            corrupted = false;
            woodSplinters = false;
        }

        /*public override void UpdateBiomes()
        {
            if (SubworldLibrary.Subworld.IsActive<AncientParadiseSubworld>())
                ZoneAncient = true;
            else
                ZoneAncient = AstralAddonWorld.ancientParadiseTiles > 30;
        }
        public override bool CustomBiomesMatch(Player other)
        {
            AstralAddonPlayer modOther = other.GetModPlayer<AstralAddonPlayer>();
            return ZoneAncient == modOther.ZoneAncient;
            // If you have several Zones, you might find the &= operator or other logic operators useful:
            // bool allMatch = true;
            // allMatch &= ZoneExample == modOther.ZoneExample;
            // allMatch &= ZoneModel == modOther.ZoneModel;
            // return allMatch;
            // Here is an example just using && chained together in one statemeny 
            // return ZoneExample == modOther.ZoneExample && ZoneModel == modOther.ZoneModel;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            AstralAddonPlayer modOther = other.GetModPlayer<AstralAddonPlayer>();
            modOther.ZoneAncient = ZoneAncient;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneAncient;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneAncient = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {
            //bool usePurity = NPC.AnyNPCs(ModContent.NPCType<PuritySpirit>());
            //player.ManageSpecialBiomeVisuals("ExampleMod:PuritySpirit", usePurity);
            //bool useVoidMonolith = voidMonolith && !usePurity && !NPC.AnyNPCs(NPCID.MoonLordCore);
            //player.ManageSpecialBiomeVisuals("ExampleMod:MonolithVoid", useVoidMonolith, player.Center);
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneAncient)
            {
                return Mod.GetTexture("Backgrounds/AncientBiomeMapBackground");
            }
            return null;
        } */

        public override void UpdateBadLifeRegen()
        {
            if (corrupted)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                Player.lifeRegen -= 8;
            }
            if (woodSplinters)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                Player.lifeRegen -= 2;
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (corrupted)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    Random rand = new Random();
                    int dustType = rand.Next(1, 80);
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, dustType, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default, 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.3f;
                g *= 0.3f;
                b *= 0.3f;
                fullBright = true;
            }
            if (woodSplinters)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dustType = DustID.Blood;
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, dustType, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default, 3f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.1f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.8f;
                g *= 0.1f;
                b *= 0.1f;
                fullBright = false;
            }
        }
        // As a recap. Make a class variable, reset that variable in ResetEffects, and use that variable in the logic of whatever hooks you use.
    }
}