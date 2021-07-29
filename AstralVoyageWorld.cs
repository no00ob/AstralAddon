using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;
using System;
using Terraria.ModLoader.IO;
using System.IO;
using AstralVoyage.Tiles;

namespace AstralVoyage
{
    public class AstralVoyageWorld : ModWorld
    {
        public static bool downedEaterOfCosmos; // Bool if this boss has been taken down.
        public static bool downedLivingTree; // Bool if this boss has been taken down.
        public static bool downedEyeOfCosmos; // Bool if this boss has been taken down.
        public static bool downedGuardianOfCosmos; // Bool if this boss has been taken down.
        public static bool downedVoyager;


        public static bool spawnRootOre = false;

        public static bool[] MalorianArmsUpgrades = new bool[5];

        public static int ancientParadiseTiles;

        public override void Initialize()
        {
            downedEaterOfCosmos = false;
            downedLivingTree = false;
            downedEyeOfCosmos = false;
            downedGuardianOfCosmos = false;
            downedVoyager = false;
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                MalorianArmsUpgrades[i] = false;
            }
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedEaterOfCosmos) downed.Add("eoc");
            if (downedGuardianOfCosmos) downed.Add("goc");
            if (downedEyeOfCosmos) downed.Add("eoc2");
            if (downedLivingTree) downed.Add("livtree");
            if (downedVoyager) downed.Add("voyager");

            var maupgrade = new List<bool>();
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                maupgrade.Add(MalorianArmsUpgrades[i]);
            }

            return new TagCompound
            {
                {"downed", downed },
                {"maupgrade", maupgrade }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedEaterOfCosmos = downed.Contains("eoc");
            downedGuardianOfCosmos = downed.Contains("goc");
            downedEyeOfCosmos = downed.Contains("eoc2");
            downedLivingTree = downed.Contains("livtree");
            downedVoyager = downed.Contains("voyager");

            var maupgrade = tag.GetList<bool>("maupgrade");
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                MalorianArmsUpgrades[i] = maupgrade[i];
            }
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedEaterOfCosmos = flags[0];
                downedLivingTree = flags[1];
                downedGuardianOfCosmos = flags[2];
                downedEyeOfCosmos = flags[3];
                downedVoyager = flags[4];
                for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
                {
                    flags[5 + i] = MalorianArmsUpgrades[i];
                }
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte bossFlags = new BitsByte();
            bossFlags[0] = downedEaterOfCosmos;
            bossFlags[1] = downedLivingTree;
            bossFlags[2] = downedGuardianOfCosmos;
            bossFlags[3] = downedEyeOfCosmos;
            bossFlags[4] = downedVoyager;
            BitsByte upgradeFlags = new BitsByte();
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                upgradeFlags[i] = MalorianArmsUpgrades[i];
            }
            writer.Write(bossFlags);
            writer.Write(upgradeFlags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte bossFlags = reader.ReadByte();
            downedEaterOfCosmos = bossFlags[0];
            downedLivingTree = bossFlags[1];
            downedGuardianOfCosmos = bossFlags[2];
            downedEyeOfCosmos = bossFlags[3];
            downedVoyager = bossFlags[4];
            BitsByte upgradeFlags = reader.ReadByte();
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                MalorianArmsUpgrades[i] = upgradeFlags[i];
            }
        }

        public override void ResetNearbyTileEffects()
        {
            ancientParadiseTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            ancientParadiseTiles = tileCounts[ModContent.TileType<CharredSoilBlock>()] + tileCounts[ModContent.TileType<CharredStoneBlock>()] + tileCounts[ModContent.TileType<DivineSandBlock>()];
        }
    }
}