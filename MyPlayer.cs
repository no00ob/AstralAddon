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
            items.RemoveAt(2);         //this remove all the items from your inventory
            items.RemoveAt(1);
            items.RemoveAt(0);
            //and replace with this ones
            Item item = new Item();
            item.SetDefaults(mod.ItemType("RustyShovel"));   //this is an example of how to add your moded item
            item.stack = 1;         //this is the stack of the item
            items.Add(item);
        }
    }
}