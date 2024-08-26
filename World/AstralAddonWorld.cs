using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using System.Collections.Generic;
using System;
using Terraria.ModLoader.IO;
using System.IO;
using AstralAddon.Tiles;
using Terraria.WorldBuilding;

namespace AstralAddon.World
{
    public class AstralAddonWorld : ModSystem
    {
        // Boss
        public static bool killedBalloon;

        // Biomes
        public static int ancientParadiseTiles;

        // Misc
        public static bool[] MalorianArmsUpgrades = new bool[5];

        public override void OnWorldLoad()
        {
            killedBalloon = false;
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                MalorianArmsUpgrades[i] = false;
            }
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["aaKilledBalloon"] = killedBalloon;

            var maupgrades = new List<bool>();
            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                maupgrades.Add(MalorianArmsUpgrades[i]);
            }

            tag["aaMAUpgrades"] = maupgrades;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            killedBalloon = tag.GetBool("aaKilledBalloon");

            var maupgrades = tag.GetList<bool>("aaMAUpgrades");

            for (int i = 0; i < MalorianArmsUpgrades.Length - 1; i++)
            {
                MalorianArmsUpgrades[i] = maupgrades[i];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte bossFlags = new BitsByte();
            bossFlags[0] = killedBalloon;
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
            killedBalloon = bossFlags[0];
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

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            ancientParadiseTiles = tileCounts[ModContent.TileType<CharredSoilBlock>()] + tileCounts[ModContent.TileType<CharredStoneBlock>()] + tileCounts[ModContent.TileType<DivineSandBlock>()];
        }
    }
}