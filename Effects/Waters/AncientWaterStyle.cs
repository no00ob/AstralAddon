using AstralVoyage.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Effects.Waters
{
	public class AncientWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("AncientSurfaceBgStyle");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("AncientWaterfallStyle");

		public override int GetSplashDust() 
			=> ModContent.DustType<AncientWaterSplash>();

		public override int GetDropletGore() 
			=> mod.GetGoreSlot("Gores/AncientDroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 0.282f;
			b = 0.219f;
		}

		public override Color BiomeHairColor() 
			=> Color.Orange;
	}
}