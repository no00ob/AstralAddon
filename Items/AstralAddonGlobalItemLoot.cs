using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamityMod;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.TreasureBags.MiscGrabBags;
using CalamityMod.World;
using AstralAddon.Items.PermanentBoosters;
using CalamityMod.Items.Placeables.Furniture.DevPaintings;

namespace AstralAddon.Items
{
    public class AstralAddonGlobalItemLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot loot)
        {
            if (item.type == ModContent.ItemType<StarterBag>())
            {
                var calStarterBagExtraSlotRev = loot.DefineConditionalDropSet(DropHelper.If(IsHarderDifficultyExludingMaster));
                calStarterBagExtraSlotRev.Add(ModContent.ItemType<AngelFruit>(), 1, 1, 1); // 100% 1 Angel Fruit if in revenge+ mode :)
                loot.Add(calStarterBagExtraSlotRev);
            }
        }

        public bool IsHarderDifficultyExludingMaster()
        {
            return !Main.masterMode && Main.expertMode && (CalamityWorld.revenge || CalamityWorld.death);
        }
    }
}
