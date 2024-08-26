using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SubworldLibrary;
using AstralAddon.Tiles;
using Terraria.WorldBuilding;

namespace AstralAddon.World.AncientParadise
{
    public class AncientParadiseSubworld : Subworld
    {
        public override int Width => 500;
        public override int Height => 300;

        public override bool ShouldSave => true;
        public override bool NoPlayerSaving => false;

        public override List<GenPass> Tasks => new List<GenPass>()
        {
            new AncientTerrainGenPass()
        };

        // Sets the time to the middle of the day whenever the subworld loads
        public override void OnLoad()
        {
            Main.dayTime = true;
            Main.time = 27000;
        }
    }
}
