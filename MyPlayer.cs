using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace AstralVoyage
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Pet = false;
        public static bool hasProjectile;
        public override void ResetEffects()
        {
            minionName = false;
            Pet = false;
        }

        public override void SetupStartInventory(IList<Item> items)
        {
            items.RemoveAt(2);         // these lines remove all items from your inventory
            items.RemoveAt(1);
            items.RemoveAt(0);
            // and then we add these ones in to the inventory
            Item item = new Item();
            item.SetDefaults(mod.ItemType("RustyShovel"));   // the custom item being added
            item.stack = 1;         // stack size of the item
            items.Add(item);
        }
    }
}