using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace AstralVoyage.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void OnKill(NPC npc)

        {
            if (npc.type == Mod.Find<ModNPC>("LivingTree").Type) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))

            {
                if (!AstralVoyageWorld.spawnRootOre)
                {                                                          //Red  Green Blue
                    Main.NewText("Roots of the trees grow thicker underground.", 78, 206, 129);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

                    for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 100E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore

                    {
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);

                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer

                        WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(2, 5), (ushort)Mod.Find<ModTile>("WoodriteOreBlock").Type);   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn

                    }
                }

                AstralVoyageWorld.spawnRootOre = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again

            }
        }
    }
}