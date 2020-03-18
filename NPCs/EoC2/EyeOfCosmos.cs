using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralVoyage;

namespace AstralVoyage.NPCs.EoC2
{
    [AutoloadBossHead]
    public class EyeOfCosmos : ModNPC
    {
        public override void SetDefaults()
        {
            npc.aiStyle = 5;  //5 is the flying AI
            npc.lifeMax = 650000;   //boss life
            npc.damage = 200;  //boss damage
            npc.defense = 40;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            animationType = NPCID.DemonEye;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 1, 5, 1);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //music = MusicID.Boss2;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/boss1");
            npc.netAlways = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Frozen] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Cursed] = true;
            npc.buffImmune[BuffID.Ichor] = true;
            npc.buffImmune[BuffID.Bleeding] = true;
            npc.buffImmune[BuffID.Weak] = true;
            npc.buffImmune[BuffID.Horrified] = true;
            npc.buffImmune[BuffID.Chilled] = true;
            npc.buffImmune[BuffID.Stoned] = true;
            npc.buffImmune[BuffID.Electrified] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.Slow] = true;



        }
        //        public override void AutoloadHead(ref string headTexture, ref string bossHeadTexture)
        //        {
        //            bossHeadTexture = "AstralVoyage/NPCs/Boss/LivingTree_Head_Boss"; //the boss head texture
        //        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;   //boss drops
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UniversiteOre"), 47);
            AstralVoyageWorld.downedEyeOfCosmos = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.579f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode
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
            if (npc.ai[1] >= 200)  // 200 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 100;  //projectile damage
                int type = mod.ProjectileType("LivingTreeProjectile");  //put your projectile
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.ai[1] = 0;
            }
        }
    }
}