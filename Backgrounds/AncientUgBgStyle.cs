using AstralVoyage;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Backgrounds
{
	public class AncientUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			return Main.LocalPlayer.GetModPlayer<AstralVoyagePlayer>().ZoneAncient;
		}

		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/AncientBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/AncientBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/AncientBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/AncientBiomeUG3");
		}
	}
}