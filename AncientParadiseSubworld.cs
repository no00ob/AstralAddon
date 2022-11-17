using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SubworldLibrary;
using AstralVoyage.Tiles;
using Terraria.WorldBuilding;

namespace AstralVoyage
{
    public class AncientParadiseSubworld : Subworld
    {
        public override int width => 500;
        public override int height => 300;

        public override ModSystem modWorld => ModContent.GetInstance<AstralVoyageWorld>();

	    public override bool saveSubworld => false;
        public override bool disablePlayerSaving => true;
        public override bool saveModData => false;

        public override List<GenPass> tasks => new List<GenPass>()
        {
            new SubworldGenPass(progress =>
            {
                progress.Message = "Loading"; //Sets the text above the worldgen progress bar
		        Main.worldSurface = Main.maxTilesY - 42; //Hides the underground layer just out of bounds
		        Main.rockLayer = Main.maxTilesY; //Hides the cavern layer way out of bounds
		        for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY)); //Controls the progress bar, should only be set between 0f and 1f
				        Main.tile[i, j].HasTile = true;
                        Main.tile[i, j].TileType = (ushort)ModContent.TileType<CharredStoneBlock>();
                    }
                }
            })
        };

        public override void Load()
        {
            Main.dayTime = true;
            Main.time = 27000;
        }
    }
}
