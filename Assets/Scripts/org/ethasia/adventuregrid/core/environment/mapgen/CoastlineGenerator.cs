using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class CoastlineGenerator
    {
        private Island islandToGenerate;

        private int coastLineMinHeight;

        private CoastlineGenerationListAltenator coastLinePropagationSectors;

        public CoastlineGenerator()
        {
            coastLinePropagationSectors = new CoastlineGenerationListAltenator();
        }

        public void GenerateCoastline(Island island)
        {
            islandToGenerate = island;
            RandomNumberGenerator.InitWithSeed(606866744);
            coastLineMinHeight = RandomNumberGenerator.GenerateIntegerBetweenAnd(96, 128);

            if (islandToGenerate.GetXzDimension() < 3)
            {
                GenerateCoastlineInTrivialCase(new CoastLineCreationSectorBoundary(0, 0, islandToGenerate.GetXzDimension() - 1, 0, islandToGenerate.GetXzDimension() - 1), CoastLinePropagationEnterExitPoint.NONE, CoastLinePropagationEnterExitPoint.NONE);
            }
            else
            {
                CoastLineCreationSectorBoundary boundary = new CoastLineCreationSectorBoundary(0, 0, island.GetXzDimension() - 1, 0, island.GetXzDimension() - 1);
                coastLinePropagationSectors.PutSector(boundary);

                SubdivideAllCurrentSectors();
            }
        }

        private void SubdivideAllCurrentSectors()
        {
            List<CoastLineCreationSectorBoundary> currentCoastlinePropagationSectors = coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors();
            coastLinePropagationSectors.SwitchToNextPropagationList();

            CoastLineCreationSectorBoundary previousSector = currentCoastlinePropagationSectors[0];
            CoastLineCreationSectorBoundary currentSector = currentCoastlinePropagationSectors[0];
            CoastLineCreationSectorBoundary nextSector = currentCoastlinePropagationSectors[0];
            for (int i = 0; i < currentCoastlinePropagationSectors.Count; i++)
            {
                if (0 != i)
                {
                    previousSector = currentCoastlinePropagationSectors[i - 1];
                }

                currentSector = currentCoastlinePropagationSectors[i];

                if (currentCoastlinePropagationSectors.Count - 1 != i)
                {
                    nextSector = currentCoastlinePropagationSectors[i + 1];
                }
                else
                {
                    nextSector = currentCoastlinePropagationSectors[0];
                }

                CoastLinePropagationEnterExitPoint currentSectorEntryPoint = DetermineEntryPointFromAdjacentSectors(previousSector, currentSector);
                CoastLinePropagationEnterExitPoint currentSectorExitPoint = DetermineEntryPointFromAdjacentSectors(nextSector, currentSector);

                if (0 == i && currentCoastlinePropagationSectors.Count > 1 && currentSectorEntryPoint == CoastLinePropagationEnterExitPoint.NONE)
                {
                    currentSectorEntryPoint = DetermineEntryPointFromAdjacentSectors(currentCoastlinePropagationSectors[currentCoastlinePropagationSectors.Count - 1], currentSector);
                }

                if (currentSector.ToX - currentSector.FromX < 2)
                {
                    GenerateCoastlineInTrivialCase(currentSector, currentSectorEntryPoint, currentSectorExitPoint);
                }
                else
                {
                    GenerateCoastLineForFourSectors(currentSector, currentSectorEntryPoint, currentSectorExitPoint);
                }
            }

            if (coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count != 0)
            {
                SubdivideAllCurrentSectors();
            }
        }        

        private void GenerateCoastLineForFourSectors(CoastLineCreationSectorBoundary parentSector, CoastLinePropagationEnterExitPoint entryPoint, CoastLinePropagationEnterExitPoint exitPoint)
        {
            if (parentSector.ToX - parentSector.FromX < 2)
            {
                GenerateCoastlineInTrivialCase(parentSector, entryPoint, exitPoint);
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.NONE && exitPoint == CoastLinePropagationEnterExitPoint.NONE)
            {
                while (coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count < 4)
                {
                    int nextSectorNo = RandomNumberGenerator.GenerateRandomPositiveInteger(3);
                    if (coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count > 0)
                    {
                        bool nextSectorIsLegit = NextSectorToMoveToIsLegit(nextSectorNo);

                        if (!nextSectorIsLegit)
                        {
                            continue;
                        }                        
                    }

                    CoastLineCreationSectorBoundary nextSectorToRunTo = GetSectorBoundaryFromSectorNumber(parentSector, nextSectorNo);

                    if (!coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Contains(nextSectorToRunTo))
                    {   
                        coastLinePropagationSectors.PutSector(nextSectorToRunTo);
                    }
                }
            }
            else if (entryPoint != CoastLinePropagationEnterExitPoint.NONE)
            {
                bool allSectorsAreFilled = false;
                int amountOfAddedSectors = 0;
                while (!allSectorsAreFilled)
                {
                    int nextSectorNo = RandomNumberGenerator.GenerateRandomPositiveInteger(3);
                    if (0 == amountOfAddedSectors)
                    {
                        if (SectorIsLegitAsEntrySector(nextSectorNo, entryPoint))
                        {
                            CoastLineCreationSectorBoundary nextSectorToRunTo = GetSectorBoundaryFromSectorNumber(parentSector, nextSectorNo);
                            coastLinePropagationSectors.PutSector(nextSectorToRunTo);
                            amountOfAddedSectors++;
                        }
                    }
                    else if (4 == amountOfAddedSectors)
                    {
                        allSectorsAreFilled = true;
                    }
                    else
                    {
                        if (exitPoint != CoastLinePropagationEnterExitPoint.NONE)
                        {
                            if (NextSectorToMoveToIsLegit(nextSectorNo))
                            {
                                coastLinePropagationSectors.PutSector(GetSectorBoundaryFromSectorNumber(parentSector, nextSectorNo));
                                amountOfAddedSectors++;
                            }
                            else if (SectorIsLegitAsExitSector(coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors()[coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count - 1].SectorNo, exitPoint))
                            {
                                allSectorsAreFilled = true;
                            }
                        }
                    }
                }
            }
        }

        private CoastLineCreationSectorBoundary GetSectorBoundaryFromSectorNumber(CoastLineCreationSectorBoundary parentSector, int sectorNumber)
        {
            CoastLineCreationSectorBoundary sector0 = new CoastLineCreationSectorBoundary(0, parentSector.FromX, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2, parentSector.FromY, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2);
            CoastLineCreationSectorBoundary sector1 = new CoastLineCreationSectorBoundary(1, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2 + 1, parentSector.ToX, parentSector.FromY, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2);
            CoastLineCreationSectorBoundary sector2 = new CoastLineCreationSectorBoundary(2, parentSector.FromX, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2 + 1, parentSector.ToY);
            CoastLineCreationSectorBoundary sector3 = new CoastLineCreationSectorBoundary(3, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2 + 1, parentSector.ToX, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2 + 1, parentSector.ToY);

            switch (sectorNumber)
            {
                case 0:
                    return sector0;
                case 1:
                    return sector1;
                case 2:
                    return sector2;
                case 3:
                    return sector3;
            }

            return sector3;
        }

        private bool NextSectorToMoveToIsLegit(int nextSectorNo)
        {
            CoastLineCreationSectorBoundary previousSector = coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors()[coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count - 1];
            short previousSectorNo = previousSector.SectorNo;

            switch (previousSectorNo)
            {
                case 0:
                    return nextSectorNo == 1 || nextSectorNo == 2;
                case 1:
                    return nextSectorNo == 0 || nextSectorNo == 3;
                case 2:
                    return nextSectorNo == 0 || nextSectorNo == 3;
                case 3:
                    return nextSectorNo == 1 || nextSectorNo == 2;
            }     

            return false;       
        }

        private bool SectorIsLegitAsEntrySector(int sectorNo, CoastLinePropagationEnterExitPoint entryPoint)
        {
            if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_LEFT || entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT_LEFT || entryPoint == CoastLinePropagationEnterExitPoint.LEFT)
            {
                return sectorNo == 0 || sectorNo == 2;
            }
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT_UP || entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT_UP || entryPoint == CoastLinePropagationEnterExitPoint.TOP)
            {
                return sectorNo == 0 || sectorNo == 1;
            }
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_RIGHT || entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT_RIGHT || entryPoint == CoastLinePropagationEnterExitPoint.RIGHT)
            {
                return sectorNo == 1 || sectorNo == 3;
            }    
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_DOWN || entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_DOWN || entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM)
            {
                return sectorNo == 2 || sectorNo == 3;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT)
            {
                return sectorNo == 0;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT)
            {
                return sectorNo == 1;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT)
            {
                return sectorNo == 2;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT)
            {
                return sectorNo == 3;
            }  

            return false;
        }

        private CoastLinePropagationEnterExitPoint DetermineEntryPointFromAdjacentSectors(CoastLineCreationSectorBoundary previousSector, CoastLineCreationSectorBoundary nextSector)
        {
            if (previousSector.FromX < nextSector.FromX)
            {
                if (previousSector.FromY < nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.TOP_LEFT;
                }
                else if (previousSector.FromY == nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.LEFT;
                }

                return CoastLinePropagationEnterExitPoint.BOTTOM_LEFT;
            }
            else if (previousSector.FromX == nextSector.FromX)
            {
                if (previousSector.FromY < nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.TOP;
                }
                else if (previousSector.FromY == nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.NONE;
                }

                return CoastLinePropagationEnterExitPoint.BOTTOM;
            }
            else if (previousSector.FromX > nextSector.FromX)
            {
                if (previousSector.FromY < nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.TOP_RIGHT;
                }
                else if (previousSector.FromY == nextSector.FromY)
                {
                    return CoastLinePropagationEnterExitPoint.RIGHT;
                }

                return CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT;
            }

            return CoastLinePropagationEnterExitPoint.NONE;
        }

        private bool SectorIsLegitAsExitSector(int sectorNo, CoastLinePropagationEnterExitPoint exitPoint)
        {
            if (exitPoint == CoastLinePropagationEnterExitPoint.TOP)
            {
                return sectorNo == 0 || sectorNo == 1;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.RIGHT)
            {
                return sectorNo == 1 || sectorNo == 3;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM)
            {
                return sectorNo == 2 || sectorNo == 3;
            }    
            else if (exitPoint == CoastLinePropagationEnterExitPoint.LEFT)
            {
                return sectorNo == 0 || sectorNo == 2;
            }  
            else if (exitPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT)
            {
                return sectorNo == 0;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT)
            {
                return sectorNo == 1;
            }         
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT)
            {
                return sectorNo == 2;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT)
            {
                return sectorNo == 3;
            }                              

            return false;
        }

        private void GenerateCoastlineInTrivialCase(CoastLineCreationSectorBoundary coastLineGenerationChunkBoundary, CoastLinePropagationEnterExitPoint enterPoint, CoastLinePropagationEnterExitPoint exitPoint)
        {
            if (0 == coastLineGenerationChunkBoundary.ToX - coastLineGenerationChunkBoundary.FromX)
            {
                int shouldSetBlock = RandomNumberGenerator.GenerateRandomPositiveInteger(1);

                if (1 == shouldSetBlock)
                {
                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromX));
                }
            }
            else if (1 == coastLineGenerationChunkBoundary.ToX - coastLineGenerationChunkBoundary.FromX)
            {
                if (enterPoint == CoastLinePropagationEnterExitPoint.NONE && exitPoint == CoastLinePropagationEnterExitPoint.NONE)
                {
                    int amountOfSubGenerationSteps = RandomNumberGenerator.GenerateRandomPositiveInteger(3);

                    for (int i = 0; i < amountOfSubGenerationSteps; i++)
                    {
                        int sectorToPlaceBlockAt = RandomNumberGenerator.GenerateRandomPositiveInteger(3);

                        switch (sectorToPlaceBlockAt)
                        {
                            case 0:
                                if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY)).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY));
                                }
                                else
                                {
                                    i--;
                                }

                                break;
                            case 1:
                                if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY)).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY));
                                }
                                else
                                {
                                    i--;
                                }

                                break;    
                            case 2:
                                if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1)).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1));
                                }
                                else
                                {
                                    i--;
                                }

                                break; 
                            case 3:
                                if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1)).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1));
                                }
                                else
                                {
                                    i--;
                                }

                                break;                                                                 
                        }
                    }
                }
                else
                {
                    int amountOfBlocksPlaced = 0;

                    while (amountOfBlocksPlaced < 2)
                    {
                        if (0 == amountOfBlocksPlaced)
                        {
                            if (enterPoint == CoastLinePropagationEnterExitPoint.NONE)
                            {
                                int nextSectorNo = RandomNumberGenerator.GenerateRandomPositiveInteger(3);
                                PlaceBlockBasedOnNumberAndCurrentSector(nextSectorNo, coastLineGenerationChunkBoundary);

                                amountOfBlocksPlaced++;
                            }
                            else
                            {
                                int nextSectorNo = RandomNumberGenerator.GenerateRandomPositiveInteger(3);

                                if (SectorIsLegitAsEntrySector(nextSectorNo, enterPoint))
                                {
                                    PlaceBlockBasedOnNumberAndCurrentSector(nextSectorNo, coastLineGenerationChunkBoundary);

                                    amountOfBlocksPlaced++;
                                }
                            }
                        }
                        else
                        {
                            int nextSectorNo = RandomNumberGenerator.GenerateRandomPositiveInteger(3);

                            if (SectorIsLegitAsExitSector(nextSectorNo, exitPoint))
                            {
                                PlaceBlockBasedOnNumberAndCurrentSector(nextSectorNo, coastLineGenerationChunkBoundary);

                                amountOfBlocksPlaced++;
                            }
                        }
                    }
                }
            }
        }

        private void PlaceBlockBasedOnNumberAndCurrentSector(int sectorToPlaceBlockAt, CoastLineCreationSectorBoundary coastLineGenerationChunkBoundary)
        {
            switch (sectorToPlaceBlockAt)
            {
                case 0:
                    if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY)).GetBlockType() == BlockTypes.AIR)
                    {
                        islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY));
                    }

                    break;
                case 1:
                    if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY)).GetBlockType() == BlockTypes.AIR)
                    {
                        islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY));
                    }

                    break;    
                case 2:
                    if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1)).GetBlockType() == BlockTypes.AIR)
                    {
                        islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1));
                    }

                    break; 
                case 3:
                    if (islandToGenerate.GetBlockAt(new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1)).GetBlockType() == BlockTypes.AIR)
                    {
                        islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1));
                    }

                    break;                                                                 
            }            
        }

        internal struct CoastLineCreationSectorBoundary
        {

            public short SectorNo
            {
                get;
                private set;
            }

            public int FromX
            {
                get;
                private set;
            }

            public int ToX
            {
                get;
                private set;
            }

            public int FromY
            {
                get;
                private set;
            }

            public int ToY
            {
                get;
                private set;
            }            

            public CoastLineCreationSectorBoundary(short sectorNo, int fromX, int toX, int fromY, int toY) 
            {
                SectorNo = sectorNo;
                FromX = fromX;
                ToX = toX;
                FromY = fromY;
                ToY = toY;                
            }      

            public override bool Equals(object other)
            {
                if (other is CoastLineCreationSectorBoundary) 
                {
                    CoastLineCreationSectorBoundary otherBoundary = (CoastLineCreationSectorBoundary)other;

                    return FromX == otherBoundary.FromX 
                        && FromY == otherBoundary.FromY 
                        && ToX == otherBoundary.ToX 
                        && ToY == otherBoundary.ToY;
                }

                return false;
            }      

            public override int GetHashCode()
            {
                return FromX + FromY + ToX + ToY;
            }
        }

        private enum CoastLinePropagationEnterExitPoint
        {
            NONE,
            TOP,
            RIGHT,
            BOTTOM,
            LEFT,
            TOP_LEFT,
            TOP_RIGHT,
            BOTTOM_RIGHT,
            BOTTOM_LEFT,
            TOP_LEFT_LEFT,
            TOP_LEFT_UP,
            TOP_RIGHT_UP,
            TOP_RIGHT_RIGHT,
            BOTTOM_LEFT_LEFT,
            BOTTOM_LEFT_DOWN,
            BOTTOM_RIGHT_RIGHT,
            BOTTOM_RIGHT_DOWN
        }
    }
}