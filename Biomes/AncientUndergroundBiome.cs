﻿using AstralAddon.Biomes;
using AstralAddon.Utilities;
using AstralAddon.World;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace AstralAddon.Biomes
{
	internal class AncientUndergroundBiome : ModBiome
	{
		public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("AstralAddon/AncientUgBgStyle");
		//public override void SetStaticDefaults() => DisplayName.SetDefault("Underground Spirit");
		//public override int Music => GetMusicFromDepth();

		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => MapBackground;
		public override Color? BackgroundColor => base.BackgroundColor;
		public override string MapBackground => "AstralAddon/Backgrounds/AncientBiomeMapBackground";

		/*private int GetMusicFromDepth()
		{
			Player player = Main.LocalPlayer;
			int music = -1;

			if (player.ZoneRockLayerHeight && player.position.Y / 16 < (Main.rockLayer + Main.maxTilesY - 330) / 2f)
				music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/SpiritLayer1");
			if (player.ZoneRockLayerHeight && player.position.Y / 16 > (Main.rockLayer + Main.maxTilesY - 330) / 2f)
				music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/SpiritLayer2");
			if (player.position.Y / 16 >= Main.maxTilesY - 330)
				music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/SpiritLayer3");
			return music;
		}*/

		public override bool IsBiomeActive(Player player) => (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight && BiomeTileCounts.InAncient);

		public override void OnEnter(Player player) => player.GetAstralPlayer().ZoneAncient = true;
		public override void OnLeave(Player player) => player.GetAstralPlayer().ZoneAncient = false;
	}
}
