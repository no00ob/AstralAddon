using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items.Ores;

namespace AstralAddon.Items.Tools
{
    public class DiamondPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Diamond Pickaxe");
        }
        public override void SetDefaults()
        {
            Item.damage = 46;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 26;
            Item.height = 26;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(01,00,00,00);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.pick = 300;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ToyPickaxe>(), 1);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.Diamond, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
