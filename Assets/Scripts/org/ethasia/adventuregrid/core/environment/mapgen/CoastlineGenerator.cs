using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class CoastlineGenerator
    {

        private const int TOP_LEFT_SECTOR_ID = 0;
        private const int TOP_RIGHT_SECTOR_ID = 1;
        private const int BOTTOM_LEFT_SECTOR_ID = 2;
        private const int BOTTOM_RIGHT_SECTOR_ID = 3;

        private Island islandToGenerate;
        private int coastLineMinHeight;
        private CoastlineGenerationListAltenator coastLinePropagationSectors;
        private IRandomNumberGenerator randomNumberGenerator;

        public CoastlineGenerator()
        {
            coastLinePropagationSectors = new CoastlineGenerationListAltenator();
            randomNumberGenerator = CoreFactory.GetInstance().GetRandomNumberGeneratorInstance();
        }

        public void GenerateCoastline(Island island)
        {
            islandToGenerate = island;
            coastLineMinHeight = randomNumberGenerator.GenerateIntegerBetweenAnd(96, 128);

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
                    if (coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count > 0)
                    {
                        previousSector = coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors()[coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count - 1];
                    }
                    else
                    {
                        previousSector = currentCoastlinePropagationSectors[i - 1];
                    }
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
                    int nextSectorNo = randomNumberGenerator.GenerateRandomPositiveInteger(3);
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
                    int nextSectorNo = randomNumberGenerator.GenerateRandomPositiveInteger(3);
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
                                CoastLineCreationSectorBoundary nextSector = GetSectorBoundaryFromSectorNumber(parentSector, nextSectorNo);

                                if (!coastLinePropagationSectors.ContainsSectorInCurrents(nextSector))
                                {
                                    coastLinePropagationSectors.PutSector(nextSector);
                                    amountOfAddedSectors++;
                                }
                            }
                            
                            if (SectorIsLegitAsExitSector(coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors()[coastLinePropagationSectors.GetCurrentCoastLinePropagationSectors().Count - 1].SectorNo, exitPoint))
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
            CoastLineCreationSectorBoundary sector0 = new CoastLineCreationSectorBoundary(TOP_LEFT_SECTOR_ID, parentSector.FromX, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2, parentSector.FromY, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2);
            CoastLineCreationSectorBoundary sector1 = new CoastLineCreationSectorBoundary(TOP_RIGHT_SECTOR_ID, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2 + 1, parentSector.ToX, parentSector.FromY, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2);
            CoastLineCreationSectorBoundary sector2 = new CoastLineCreationSectorBoundary(BOTTOM_LEFT_SECTOR_ID, parentSector.FromX, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2 + 1, parentSector.ToY);
            CoastLineCreationSectorBoundary sector3 = new CoastLineCreationSectorBoundary(BOTTOM_RIGHT_SECTOR_ID, parentSector.FromX + (parentSector.ToX - parentSector.FromX) / 2 + 1, parentSector.ToX, parentSector.FromY + (parentSector.ToY - parentSector.FromY) / 2 + 1, parentSector.ToY);

            switch (sectorNumber)
            {
                case TOP_LEFT_SECTOR_ID:
                    return sector0;
                case TOP_RIGHT_SECTOR_ID:
                    return sector1;
                case BOTTOM_LEFT_SECTOR_ID:
                    return sector2;
                case BOTTOM_RIGHT_SECTOR_ID:
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
                case TOP_LEFT_SECTOR_ID:
                    return nextSectorNo == TOP_RIGHT_SECTOR_ID || nextSectorNo == BOTTOM_LEFT_SECTOR_ID;
                case TOP_RIGHT_SECTOR_ID:
                    return nextSectorNo == TOP_LEFT_SECTOR_ID || nextSectorNo == BOTTOM_RIGHT_SECTOR_ID;
                case BOTTOM_LEFT_SECTOR_ID:
                    return nextSectorNo == TOP_LEFT_SECTOR_ID || nextSectorNo == BOTTOM_RIGHT_SECTOR_ID;
                case BOTTOM_RIGHT_SECTOR_ID:
                    return nextSectorNo == TOP_RIGHT_SECTOR_ID || nextSectorNo == BOTTOM_LEFT_SECTOR_ID;
            }     

            return false;       
        }

        private bool SectorIsLegitAsEntrySector(int sectorNo, CoastLinePropagationEnterExitPoint entryPoint)
        {
            if (entryPoint == CoastLinePropagationEnterExitPoint.LEFT)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID || sectorNo == BOTTOM_LEFT_SECTOR_ID;
            }
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID || sectorNo == TOP_RIGHT_SECTOR_ID;
            }
            else if (entryPoint == CoastLinePropagationEnterExitPoint.RIGHT)
            {
                return sectorNo == TOP_RIGHT_SECTOR_ID || sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }    
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM)
            {
                return sectorNo == BOTTOM_LEFT_SECTOR_ID || sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT)
            {
                return sectorNo == TOP_RIGHT_SECTOR_ID;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT)
            {
                return sectorNo == BOTTOM_LEFT_SECTOR_ID;
            } 
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT)
            {
                return sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }  
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT_LEFT || entryPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT_UP)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID;
            }
            else if (entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT_UP || entryPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT_RIGHT)
            {
                return sectorNo == TOP_RIGHT_SECTOR_ID;
            }       
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_LEFT || entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_DOWN)
            {
                return sectorNo == BOTTOM_LEFT_SECTOR_ID;
            }   
            else if (entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_RIGHT || entryPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_DOWN)
            {
                return sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }                           

            return false;
        }

        private CoastLinePropagationEnterExitPoint DetermineEntryPointFromAdjacentSectors(CoastLineCreationSectorBoundary previousSector, CoastLineCreationSectorBoundary nextSector)
        {
            if (previousSector.ToX - previousSector.FromX < nextSector.ToX - nextSector.FromX && previousSector.ToY - previousSector.FromY < nextSector.ToY - nextSector.FromY)
            {
                if (previousSector.FromX < nextSector.FromX)
                {
                    if (previousSector.FromY < nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_LEFT;
                    }
                    else if (previousSector.FromY == nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_LEFT_LEFT;
                    }
                    else if (previousSector.FromY > nextSector.FromY && previousSector.FromY < nextSector.ToY)
                    {
                        return CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_LEFT;
                    }

                    return CoastLinePropagationEnterExitPoint.BOTTOM_LEFT;
                }   
                else if (previousSector.FromX == nextSector.FromX)
                {
                    if (previousSector.FromY < nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_LEFT_UP;
                    }

                    return CoastLinePropagationEnterExitPoint.BOTTOM_LEFT_DOWN;
                }     
                else if (previousSector.FromX > nextSector.FromX && previousSector.FromX < nextSector.ToX)
                {
                    if (previousSector.FromY < nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_RIGHT_UP;
                    }

                    return CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_DOWN;
                }      
                else
                {
                    if (previousSector.FromY < nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_RIGHT;
                    }
                    else if (previousSector.FromY == nextSector.FromY)
                    {
                        return CoastLinePropagationEnterExitPoint.TOP_RIGHT_RIGHT;
                    }
                    else if (previousSector.FromY > nextSector.FromY && previousSector.FromY < nextSector.ToY)
                    {
                        return CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT_RIGHT;
                    }

                    return CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT;                    
                }  
            }
            else
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
            }

            return CoastLinePropagationEnterExitPoint.NONE;
        }

        private bool SectorIsLegitAsExitSector(int sectorNo, CoastLinePropagationEnterExitPoint exitPoint)
        {
            if (exitPoint == CoastLinePropagationEnterExitPoint.TOP)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID || sectorNo == TOP_RIGHT_SECTOR_ID;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.RIGHT)
            {
                return sectorNo == TOP_RIGHT_SECTOR_ID || sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM)
            {
                return sectorNo == BOTTOM_LEFT_SECTOR_ID || sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }    
            else if (exitPoint == CoastLinePropagationEnterExitPoint.LEFT)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID || sectorNo == BOTTOM_LEFT_SECTOR_ID;
            }  
            else if (exitPoint == CoastLinePropagationEnterExitPoint.TOP_LEFT)
            {
                return sectorNo == TOP_LEFT_SECTOR_ID;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.TOP_RIGHT)
            {
                return sectorNo == TOP_RIGHT_SECTOR_ID;
            }         
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM_LEFT)
            {
                return sectorNo == BOTTOM_LEFT_SECTOR_ID;
            }
            else if (exitPoint == CoastLinePropagationEnterExitPoint.BOTTOM_RIGHT)
            {
                return sectorNo == BOTTOM_RIGHT_SECTOR_ID;
            }                              

            return false;
        }

        private void GenerateCoastlineInTrivialCase(CoastLineCreationSectorBoundary coastLineGenerationChunkBoundary, CoastLinePropagationEnterExitPoint enterPoint, CoastLinePropagationEnterExitPoint exitPoint)
        {
            if (0 == coastLineGenerationChunkBoundary.ToX - coastLineGenerationChunkBoundary.FromX)
            {
                int shouldSetBlock = randomNumberGenerator.GenerateRandomPositiveInteger(1);

                if (1 == shouldSetBlock)
                {
                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromX));
                }
            }
            else if (1 == coastLineGenerationChunkBoundary.ToX - coastLineGenerationChunkBoundary.FromX)
            {
                if (enterPoint == CoastLinePropagationEnterExitPoint.NONE && exitPoint == CoastLinePropagationEnterExitPoint.NONE)
                {
                    int amountOfSubGenerationSteps = randomNumberGenerator.GenerateRandomPositiveInteger(3);
                    int i = 0;

                    while (i < amountOfSubGenerationSteps)
                    {
                        int sectorToPlaceBlockAt = randomNumberGenerator.GenerateRandomPositiveInteger(3);

                        BlockPosition placementPosition;
                        switch (sectorToPlaceBlockAt)
                        {
                            case TOP_LEFT_SECTOR_ID:
                                placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY);

                                if (islandToGenerate.GetBlockAt(placementPosition).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), placementPosition);
                                    i++;
                                }

                                break;
                            case TOP_RIGHT_SECTOR_ID:
                                placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY);

                                if (islandToGenerate.GetBlockAt(placementPosition).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), placementPosition);
                                    i++;
                                }

                                break;    
                            case BOTTOM_LEFT_SECTOR_ID:
                                placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1);

                                if (islandToGenerate.GetBlockAt(placementPosition).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), placementPosition);
                                    i++;
                                }

                                break; 
                            case BOTTOM_RIGHT_SECTOR_ID:
                                placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1);

                                if (islandToGenerate.GetBlockAt(placementPosition).GetBlockType() == BlockTypes.AIR)
                                {
                                    islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), placementPosition);
                                    i++;
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
                                int nextSectorNo = randomNumberGenerator.GenerateRandomPositiveInteger(3);
                                PlaceBlockBasedOnNumberAndCurrentSector(nextSectorNo, coastLineGenerationChunkBoundary);

                                amountOfBlocksPlaced++;
                            }
                            else
                            {
                                int nextSectorNo = randomNumberGenerator.GenerateRandomPositiveInteger(3);

                                if (SectorIsLegitAsEntrySector(nextSectorNo, enterPoint))
                                {
                                    PlaceBlockBasedOnNumberAndCurrentSector(nextSectorNo, coastLineGenerationChunkBoundary);

                                    amountOfBlocksPlaced++;
                                }
                            }
                        }
                        else
                        {
                            int nextSectorNo = randomNumberGenerator.GenerateRandomPositiveInteger(3);

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
            BlockPosition placementPosition;

            switch (sectorToPlaceBlockAt)
            {
                case TOP_LEFT_SECTOR_ID:
                    placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY);
                    PlaceRockBlockAtIfItIsNotAir(placementPosition);

                    break;
                case TOP_RIGHT_SECTOR_ID:
                    placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY);
                    PlaceRockBlockAtIfItIsNotAir(placementPosition);

                    break;    
                case BOTTOM_LEFT_SECTOR_ID:
                    placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1);
                    PlaceRockBlockAtIfItIsNotAir(placementPosition);

                    break; 
                case BOTTOM_RIGHT_SECTOR_ID:
                    placementPosition = new BlockPosition(coastLineGenerationChunkBoundary.FromX + 1, coastLineMinHeight, coastLineGenerationChunkBoundary.FromY + 1);
                    PlaceRockBlockAtIfItIsNotAir(placementPosition);

                    break;                                                                 
            }            
        }

        private void PlaceRockBlockAtIfItIsNotAir(BlockPosition placementPosition)
        {
            if (islandToGenerate.GetBlockAt(placementPosition).GetBlockType() == BlockTypes.AIR)
            {
                islandToGenerate.PlaceBlockAt(RockBlock.GetInstance(), placementPosition);
            }
        }

        public struct CoastLineCreationSectorBoundary
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