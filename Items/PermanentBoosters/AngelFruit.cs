using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;
using CalamityMod.CalPlayer;
using Terraria.Audio;

namespace AstralAddon.Items.PermanentBoosters
{
    public class AngelFruit : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.rare = ItemRarityID.Master;
            Item.maxStack = 9999;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.EatFood; // HoldUp
            Item.UseSound = SoundID.Item2; // Item4
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            CalamityPlayer calamityPlayer = player.Calamity();

            return !Main.masterMode && !calamityPlayer.extraAccessoryML;
        }

        public override bool? UseItem(Player player)
        {
            CalamityPlayer calamityPlayer = player.Calamity();

            if (player.itemAnimation > 0 && !calamityPlayer.extraAccessoryML && player.itemTime == 0)
            {
                SoundEngine.PlaySound(SoundID.Item29);
                player.itemTime = Item.useTime;
                calamityPlayer.extraAccessoryML = true;
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.Register();
        }
    }
}