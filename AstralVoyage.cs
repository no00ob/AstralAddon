using AstralVoyage.NPCs.EoC;
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
				AutoloadSounds = true
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

        public override void UpdateMusic(ref int music)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.LocalPlayer.active && TheEaterOfCosmos_Head.bossOn == true)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/boss1");
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/boss2");
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/boss4");
                }
            }
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // To include a description:
                bossChecklist.Call("AddBossWithInfo", "Eater Of The Cosmos", 15.999f, (Func<bool>)(() => AstralVoyageWorld.downedEaterOfCosmos), "Use a [i:" + ItemType("WormholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Living Tree", 1.001f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("SuspiciousLookingSprout") + "] at night.");
                bossChecklist.Call("AddBossWithInfo", "Guardian Of The Cosmos", 15.998f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("BlackholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Eye Of The Cosmos", 15.997f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("CometCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Voyager", 17.998f, (Func<bool>)(() => AstralVoyageWorld.downedVoyager), "Use a [i:" + ItemType("AnomaliousMatter") + "] after beating the three cosmic guardians at any given time, any where.");
            }
        }

    }
}