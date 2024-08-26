using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Biomes
{
	public class SpiritUgBgStyle : ModUndergroundBackgroundStyle
	{
		public override void FillTextureArray(int[] textureSlots)
		{
			for (int i = 1; i < 4; ++i)
				textureSlots[i] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/AncientBiomeUG" + i);
			textureSlots[4] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/AncientBiomeUG5");
			textureSlots[5] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/AncientBiomeUG4");
		}
	}
}