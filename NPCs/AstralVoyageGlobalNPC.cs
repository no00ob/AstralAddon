using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AstralVoyage.NPCs
{
    public class AstralVoyageGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool corrupted;

        public override void ResetEffects(NPC npc)
        {
            corrupted = false;
        }

        public override void SetDefaults(NPC npc)
        {
            // We want our ExampleJavelin buff to follow the same immunities as BoneJavelin
            npc.buffImmune[BuffType<Buffs.Corrupted>()] = npc.buffImmune[BuffID.BoneJavelin];
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (corrupted)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 32;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (corrupted)
            {
                if (Main.rand.Next(4) < 3)
                {
                    Random rand = new Random();
                    int dustType = rand.Next(1, 80);
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, dustType, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }
    }
}