using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class WoodriteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a Woodrite Helmet."
                + "\n10% increased ranged damage"
                + "\n5% increased minion damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 200;
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage *= 1.1f;
            player.minionDamage *= 1.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("WoodriteBreastplate") && legs.type == mod.ItemType("WoodriteLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 max minions";
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodriteBar", 20);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}