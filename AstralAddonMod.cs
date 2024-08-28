using System;
using Terraria.ModLoader;
using AstralAddon.World;

namespace AstralAddon
{
    class AstralAddonMod : Mod
	{
        internal static AstralAddonMod Instance;

        internal Mod bossChecklist = null;

        public override void Load()
        {
            Instance = this;

            bossChecklist = null;
            ModLoader.TryGetMod("BossChecklist", out bossChecklist);
        }

        public override void Unload()
        {
            bossChecklist = null;
        }

        //public override void UpdateMusic(ref int music, ref SceneEffectPriority priority)/* tModPorter Note: Removed. Use ModSceneEffect.Music and .Priority, aswell as ModSceneEffect.IsSceneEffectActive */
        /*{
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                return;

            if (Main.LocalPlayer.GetModPlayer<AstralAddonPlayer>().ZoneAncient)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/ancient");
                priority = SceneEffectPriority.Environment;
            }

            if (LivingTree.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/fight3");
                priority = SceneEffectPriority.BossLow;
            }

            if (TheEaterOfCosmos_Head.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/boss3");
                priority = SceneEffectPriority.BossMedium;
            }
        }*/

        public override void PostSetupContent()
        {
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "Corrupted Balloon", 1.01f, (Func<bool>)(() => AstralAddonWorld.killedBalloon), "Use a [i:" + Find<ModItem>("CorruptedAirPump").Type + "] at any given time, anywhere.");
            }
        }

        //public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)/* tModPorter Note: Removed. Use ModSystem.ModifySunLightColor */
        /*{
            if (AstralAddonWorld.ancientParadiseTiles <= 0)
            {
                return;
            }

            float ancientStrength = AstralAddonWorld.ancientParadiseTiles / 200f;
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
        }*/
    }
}