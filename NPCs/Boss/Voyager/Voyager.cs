using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon;
using AstralAddon.Buffs;

namespace AstralAddon.NPCs.Boss.Voyager
{
    [AutoloadBossHead]
    public class Voyager : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.aiStyle = 5;  //5 is the flying AI
            NPC.lifeMax = 3500000;   //boss life
            NPC.damage = 606;  //boss damage
            NPC.defense = 80;    //boss defense
            NPC.knockBackResist = 0f;
            NPC.width = 34;
            NPC.height = 44;
            AnimationType = NPCID.DemonEye;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[NPC.type] = 3;    //boss frame/animation 
            NPC.value = Item.buyPrice(0, 1, 5, 1);
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Music = Mod.GetSoundSlot(SoundType.Music, "Sounds/Music/battle_4");
            NPC.netAlways = true;
            NPC.buffImmune[24] = true;
            NPC.buffImmune[BuffID.Poisoned] = true;
            NPC.buffImmune[BuffID.Venom] = true;
            NPC.buffImmune[BuffID.Frozen] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Cursed] = true;
            NPC.buffImmune[BuffID.Ichor] = true;
            NPC.buffImmune[BuffID.Bleeding] = true;
            NPC.buffImmune[BuffID.Weak] = true;
            NPC.buffImmune[BuffID.Horrified] = true;
            NPC.buffImmune[BuffID.Chilled] = true;
            NPC.buffImmune[BuffID.Stoned] = true;
            NPC.buffImmune[BuffID.Electrified] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.Slow] = true;



        }
        //        public override void AutoloadHead(ref string headTexture, ref string bossHeadTexture)
        //        {
        //            bossHeadTexture = "AstralVoyage/NPCs/Boss/LivingTree_Head_Boss"; //the boss head texture
        //        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;   //boss drops
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("UniversiteOre").Type, 87);
            AstralAddonWorld.downedVoyager = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.749f * bossLifeScale);  //boss life scale in expertmode
            NPC.damage = (int)(NPC.damage * 0.7f);  //boss damage increase in expermode
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
            if (NPC.ai[1] >= 120)  // 120 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
                int damage = 150;  //projectile damage
                int type = Mod.Find<ModProjectile>("AnomaliousLaser").Type;  //put your projectile
                SoundEngine.PlaySound(SoundID.Item17, NPC.position);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                NPC.ai[1] = 0;
            }
        }
    }
}