using AstralAddon.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Tools
{
    public class ToyPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Toy Pickaxe");
        }
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3f;
            Item.value = 250;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.pick = 50;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(ItemID.LavaBucket);
            recipe.AddIngredient(ModContent.ItemType<Plastic>(), 12);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
