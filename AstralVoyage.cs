using AstralVoyage.NPCs.EoC;
using AstralVoyage.NPCs.LT;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage
{
	class AstralVoyage : Mod
	{
		public AstralVoyage()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
			};
        }

        public override void Load()
        {
            for (int k = 1; k <= 4; k++)
            {
                Main.instance.LoadTiles(TileID.Loom);
                Main.tileTexture[TileID.Loom] = GetTexture("Tiles/AnimatedLoom");
                // What if....Replace a vanilla item texture and equip texture.
                //Main.itemTexture[ItemID.CopperHelmet] = GetTexture("Resprite/CopperHelmet_Item");
                //Item copperHelmet = new Item();
                //copperHelmet.SetDefaults(ItemID.CopperHelmet);
                //Main.armorHeadLoaded[copperHelmet.headSlot] = true;
                //Main.armorHeadTexture[copperHelmet.headSlot] = GetTexture("Resprite/CopperHelmet_Head");
            }
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                return;

            if (Main.LocalPlayer.GetModPlayer<AstralVoyagePlayer>().ZoneAncient)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/ancient");
                priority = MusicPriority.Environment;
            }

            if (LivingTree.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/fight3");
                priority = MusicPriority.BossLow;
            }

            if (TheEaterOfCosmos_Head.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/boss3");
                priority = MusicPriority.BossMedium;
            }
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // To include a description:
                bossChecklist.Call("AddBossWithInfo", "Astrum Vermis", 15.999f, (Func<bool>)(() => AstralVoyageWorld.downedEaterOfCosmos), "Use a [i:" + ItemType("WormholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Living Tree", 1.001f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("SuspiciousLookingSprout") + "] at night in a forest biome.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Bellatur", 15.998f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("BlackholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Magus", 15.997f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("CometCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Voyager", 17.998f, (Func<bool>)(() => AstralVoyageWorld.downedVoyager), "Use a [i:" + ItemType("AnomaliousMatter") + "] after beating the three cosmic guardians at any given time, any where.");
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            if (AstralVoyageWorld.ancientParadiseTiles <= 0)
            {
                return;
            }

            float ancientStrength = AstralVoyageWorld.ancientParadiseTiles / 200f;
            ancientStrength = Math.Min(ancientStrength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            // Remove some green and more red.
            sunR -= (int)(15f * ancientStrength * (backgroundColor.R / 255f));
            sunG -= (int)(5f * ancientStrength * (backgroundColor.G / 255f));
            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;
        }
    }
}