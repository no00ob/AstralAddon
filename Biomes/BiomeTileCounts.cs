using System;
using AstralAddon.Tiles;
using Terraria.ModLoader;

namespace AstralAddon.Biomes
{
	internal class BiomeTileCounts : ModSystem
	{
		public int ancientCount;

		public static bool InAncient => ModContent.GetInstance<BiomeTileCounts>().ancientCount > 40;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
            ancientCount = tileCounts[ModContent.TileType<DivineSandBlock>()] + tileCounts[ModContent.TileType<CharredStoneBlock>()] + tileCounts[ModContent.TileType<CharredSoilBlock>()];
		}
	}
}