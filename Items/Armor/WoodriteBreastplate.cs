using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class WoodriteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("This is a Woodrite Breastplate."
                + "\n10% increased minion damage"
                + "\n+1 max minions");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 300;
            item.rare = 1;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage *= 1.1f;
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodriteBar", 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}