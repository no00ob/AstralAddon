using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace AstralVoyage
{
    // This file shows the very basics of using ModPlayer classes since ExamplePlayer can be a bit overwhelming.
    // ModPlayer classes provide a way to attach data to Players and act on that data. 
    // This example will hopefully provide you with an understanding of the basic building blocks of how ModPlayer works. 
    // This example will teach the most commonly sought after effect: "How to do X if the player has Y?"
    // X in this example will be "Apply a debuff to enemies."
    // Y in this example will be "Wearing an accessory."
    // After studying this example, you can change X to other effects by changing the "hook" you use or the code within the hook you use. For example, you could use OnHitByNPC and call Projectile.NewProjectile within that hook to change X to "When the player is hit by NPC, spawn Projectiles".
    // We can change Y to other conditions as well. For example, you could give the player the effect by having a "potion" ModItem give a ModBuff that sets the ModPlayer variable in ModBuff.Update
    // Another example would be an armor set effect. Simply use the ModItem.UpdateArmorSet hook 

    // Below you will see the ModPlayer class, and below that will be another class called SimpleAccessory for the accessory both in the same file for your reading convenience. This accessory will give our effect to our ModPlayer. 

    // This is the ModPlayer class. Make note of the classname, which is SimpleModPlayer, since we will be using this in the accessory item below.
    public class AstralVoyagePlayer : ModPlayer
    {
        // Here we declare the effect variables which will represent whether this player has the effects or not.
        public bool corrupted;
        public bool woodSplinters;
		
		// Bools for custom pets
		public bool ekubo;

        // Here we declare the variables for permanent health upgrades
        public const int maxHealthSoda = 1;
        public int healthSoda;

        // ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and unassign the value when the item in unequipped, but Terraria is not designed that way.)
        public override void ResetEffects()
        {
            corrupted = false;
            woodSplinters = false;
			ekubo = false;

            player.statLifeMax2 += healthSoda * 100;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            //packet.Write((byte)ExampleModMessageType.ExamplePlayerSyncPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(healthSoda);
            packet.Send(toWho, fromWho);
        }

        public override void UpdateDead()
        {
            corrupted = false;
            woodSplinters = false;
        }

        public override TagCompound Save()
        {
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
                {"healthSoda", healthSoda},
            };
            //note that C# 6.0 supports indexer initializers
            //return new TagCompound {
            //	["score"] = score
            //};
        }

        public override void Load(TagCompound tag)
        {
            healthSoda = tag.GetInt("healthSoda");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
        }

        public override void UpdateBadLifeRegen()
        {
            if (corrupted)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                player.lifeRegen -= 8;
            }
            if (woodSplinters)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                player.lifeRegen -= 2;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (corrupted)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    Random rand = new Random();
                    int dustType = rand.Next(1,80);
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, dustType, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
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
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, dustType, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.1f;
                    Main.playerDrawDust.Add(dust);
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