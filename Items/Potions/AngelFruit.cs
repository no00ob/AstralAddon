using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;

namespace AstralAddon.Items.Potions
{
    public class AngelFruit : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.urmom.hjson' file.
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DemonHeart);
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(gold: 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.consumable = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.Register();
        }

        public override bool CanUseItem(Player player)
        {
            AstralAddonPlayer modPlayer = player.GetAstralPlayer();

            if (!modPlayer.extraSlot)
                return true;
            else
                return false;
        }

        public override bool? UseItem(Player player)
        {
            AstralAddonPlayer modPlayer = player.GetAstralPlayer();

            if (!modPlayer.extraSlot)
            {
                modPlayer.extraSlot = true;
                player.extraAccessorySlots += 1;
                return true;
            }
            else
                return null;
        }
    }
}