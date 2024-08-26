using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items
{
	public class FutilititeDust : ModItem
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Futilitite Dust");
			//Tooltip.SetDefault("'Oh no, you broke it!'");
		}

		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
		}

		
		}
	}

