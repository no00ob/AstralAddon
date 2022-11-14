using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThumodRe.Items.Ores;

namespace ThumodRe.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ToyChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("'A kids size.'");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 12000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 6;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(ItemID.LavaBucket);
            recipe.AddIngredient(ModContent.ItemType<Plastic>(), 25);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}