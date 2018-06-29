//css_ref Terraria.dll

using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace WorldCleanupAid
{
    public class WorldCleanupAidWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalweight)
        {
            int runNumber = 0;

            int worldGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

            if (worldGenIndex != -1)
            {
                tasks.Insert(worldGenIndex + 1, new PassLegacy("Hellevators", delegate (GenerationProgress progress)
                {
                    progress.Message = "Making Hellevators";
                    while (runNumber < Main.maxTilesX / 116)
                    {
                        makeHellevator(runNumber);
                        runNumber++;
                    }
                }));
            }
        }

        private void makeHellevator(int runs)
        {
            int placeHellevatorAtBlockX = (runs * 116) + 1;
            int yValueForPlacing = (int)WorldGen.worldSurfaceLow;

            /*while (yValueForPlacing < Main.maxTilesY)
            {
                WorldGen.TileRunner(placeHellevatorAtBlockX, yValueForPlacing, 4, 1, -1, false, 0f, 0f, false, true);
                WorldGen.TileRunner(placeHellevatorAtBlockX, yValueForPlacing, 4, 1, -2, false, 0f, 0f, false, true);
                yValueForPlacing++;
            }*/

            yValueForPlacing = (int)WorldGen.worldSurfaceLow;

            while (yValueForPlacing < Main.maxTilesY)
            {
                /*WorldGen.TileRunner(placeHellevatorAtBlockX, yValueForPlacing, 1, 1, TileID.Rope, true, 0f, 0f, false, true);
                WorldGen.TileRunner(placeHellevatorAtBlockX - 1, yValueForPlacing, 1, 1, TileID.Torches, true, 0f, 0f, false, true);
                WorldGen.TileRunner(placeHellevatorAtBlockX + 1, yValueForPlacing, 1, 1, TileID.Torches, true, 0f, 0f, false, true);
                WorldGen.TileRunner(placeHellevatorAtBlockX - 2, yValueForPlacing, 1, 1, TileID.ClayBlock, true, 0f, 0f, false, true);
                WorldGen.TileRunner(placeHellevatorAtBlockX + 2, yValueForPlacing, 1, 1, TileID.ClayBlock, true, 0f, 0f, false, true);
				*/
                Main.tile[placeHellevatorAtBlockX - 1, yValueForPlacing].type = TileID.Torches;
                Main.tile[placeHellevatorAtBlockX + 1, yValueForPlacing].type = TileID.Torches;
                Main.tile[placeHellevatorAtBlockX, yValueForPlacing].type = TileID.Rope;

                yValueForPlacing++;
            }
        }
    }
}