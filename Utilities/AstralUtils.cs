using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using SubworldLibrary;
using AstralAddon.AstralPlayer;
using AstralAddon.World.AncientParadise;

namespace AstralAddon.Utilities
{
    public static class AstralUtils
	{
        public static AstralAddonPlayer GetAstralPlayer(this Player player) => player.GetModPlayer<AstralAddonPlayer>();

        public static bool ContainsItem(this Item[] itemCollection, Item item)
        {
            for (int i = 0; i < itemCollection.Length; i++)
            {
                if (itemCollection[i] == item)
                    return true;
            }
            return false;
        }

        public static bool IsAncientSubworldActive() => SubworldSystem.IsActive<AncientParadiseSubworld>();
    }
}
