using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{

    public class CoastlineGenerationListAltenator
    {

        private bool usingFirstPropagationList;
        private List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsOne;
        private List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsTwo;      

        public List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary> GetCurrentCoastLinePropagationSectors()
        {
            if (usingFirstPropagationList)
            {
                return coastLinePropagationSectorsOne;
            }
            else
            {
                return coastLinePropagationSectorsTwo;
            }
        }      

        public CoastlineGenerationListAltenator()
        {
            usingFirstPropagationList = true;
            coastLinePropagationSectorsOne = new List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary>();
            coastLinePropagationSectorsTwo = new List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary>();            
        }  

        public void SwitchToNextPropagationList()
        {
            usingFirstPropagationList = !usingFirstPropagationList;
            ClearCurrentPropagationList();
        }        

        public void PutSector(CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary value)
        {
            if (usingFirstPropagationList)
            {
                coastLinePropagationSectorsOne.Add(value);
            }
            else
            {
                coastLinePropagationSectorsTwo.Add(value);
            }
        }        

        public bool ContainsSectorInCurrents(CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary sector)
        {
            List<CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary> currentSectors = GetCurrentCoastLinePropagationSectors();
            return currentSectors.Contains(sector);
        }

        private void ClearCurrentPropagationList()
        {
            if (usingFirstPropagationList)
            {
                coastLinePropagationSectorsOne.Clear();
            }
            else
            {
                coastLinePropagationSectorsTwo.Clear();
            }            
        }
    }
}