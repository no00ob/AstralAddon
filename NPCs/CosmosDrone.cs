using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AstralVoyage.NPCs
{
    public class CosmosDrone : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 40;
            npc.damage = 70;
            npc.defense = 5;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 0.1f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 44;
            Main.npcFrameCount[npc.type] = 3;
            aiType = NPCID.Probe;  //npc behavior
            animationType = NPCID.Harpy;
        }

       /* public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.5f : 0.5f; //spown at day
        } */
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.5F; // Determines the animation speed. Higher value = faster animation.
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;

            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot()  //Npc drop
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UniversiteOre"), 1); //Item spawn
            }

        }
        public override void AI()
        {
            npc.ai[0]++;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            npc.ai[1]++;
            if (npc.ai[1] >= 180)  // 200 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 50;  //projectile damage
                int type = mod.ProjectileType("CosmicLaser");  //put your projectile
                Main.PlaySound(33, (int)npc.position.X, (int)npc.position.Y, 27);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.ai[1] = 0;
            }
        }
    }
}