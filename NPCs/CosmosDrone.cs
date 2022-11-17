using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AstralVoyage.NPCs
{
    public class CosmosDrone : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 40;
            NPC.damage = 70;
            NPC.defense = 5;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = 0.1f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 44;
            Main.npcFrameCount[NPC.type] = 3;
            AIType = NPCID.Probe;  //npc behavior
            AnimationType = NPCID.Harpy;
        }

       /* public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.5f : 0.5f; //spown at day
        } */
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter -= 0.5F; // Determines the animation speed. Higher value = faster animation.
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;

            NPC.spriteDirection = NPC.direction;
        }
        public override void OnKill()  //Npc drop
        {
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("UniversiteOre").Type, 1); //Item spawn
            }

        }
        public override void AI()
        {
            NPC.ai[0]++;
            Player P = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            NPC.netUpdate = true;

            NPC.ai[1]++;
            if (NPC.ai[1] >= 180)  // 200 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
                int damage = 50;  //projectile damage
                int type = Mod.Find<ModProjectile>("CosmicLaser").Type;  //put your projectile
                SoundEngine.PlaySound(SoundID.Critter, NPC.position);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                NPC.ai[1] = 0;
            }
        }
    }
}