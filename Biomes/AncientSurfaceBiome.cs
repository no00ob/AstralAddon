using AstralAddon.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;

namespace AstralAddon.Biomes
{
	internal class AncientSurfaceBiome : ModBiome
	{
		//public override void SetStaticDefaults() => DisplayName.SetDefault("Ancient Paradise");
		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("AstralAddon/AncientParadiseWaterStyle");
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("AstralAddon/AncientParadiseSurfaceBgStyle");
		public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Crimson;

		public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ancient_biome");

		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => MapBackground;
		public override Color? BackgroundColor => base.BackgroundColor;
		public override string MapBackground => "AstralAddon/Backgrounds/AncientBiomeMapBackground";

		public override bool IsBiomeActive(Player player)
		{
			bool surface = player.ZoneSkyHeight || player.ZoneOverworldHeight;
			return BiomeTileCounts.InAncient && surface;
		}

		public override void OnEnter(Player player) => player.GetAstralPlayer().ZoneAncient = true;
		public override void OnLeave(Player player) => player.GetAstralPlayer().ZoneAncient = false;
	}
}
